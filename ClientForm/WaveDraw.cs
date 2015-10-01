using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;

using System.Text;

using System.Windows.Forms;
using System.IO.Ports;
using System.IO;


namespace ClientForm
{
    public partial class WaveDraw : UserControl
    {
        dataSimulator s1 = new dataSimulator();
        FFT fft = new FFT();
        Object o;
        double[] alpha_list = new double[140];
        int index = 0;
        Graphics panel_g;

        SerialPort sp = null;
        Parser parser = new Parser();

        float[] buffer = new float[5000];//缓冲区
        int num = 0;//缓冲区数据计数

        private void spInit()
        {
            sp = new SerialPort();
            sp.PortName = "COM40";
            sp.BaudRate = 57600;
            sp.DataBits = 8;
            sp.Parity = Parity.Even;
            try
            {
                sp.Open();
                try
                {
                    sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);//事件

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("无法连接串口");
            }
            
            

        }

        public void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                if (sp.IsOpen)
                {
                    // int a=sp.ReadBufferSize;
                    byte[] sp_buffer = new byte[sp.ReadBufferSize + 1];

                    int count = sp.Read(sp_buffer, 0, sp.ReadBufferSize);

                    for (int i = 0; i < count; i++)
                    {
                        float receivedrawWaveData = parser.parseByte(sp_buffer[i]);

                        if (receivedrawWaveData != 0)
                        {
                            receivedrawWaveData = receivedrawWaveData * 0.21973F;//转化为实际电压值，微伏
                            ///////////////////////////
                            // lock (buffer)
                            //{
                            
                            buffer[num++] = receivedrawWaveData;
                            
                             //}
                                 //写数据到txt

                            ////////////////                           
                        }
                    }
                }
            }));
        }
        public WaveDraw()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            panelBGDraw();
            panel_g = panel1.CreateGraphics();
            for (int i = 0; i < alpha_list.Length; i++)
            {
                alpha_list[i] = 0.0;
            }
                //spInit();
                this.BackColor = Color.Black;
            Event.dataRcvd.Received += dataRcvd_Received;
            
        }

        private void panelBGDraw()
        {
            Bitmap panelBG = new Bitmap(panel1.Width, panel1.Height);
            Graphics g = Graphics.FromImage(panelBG);
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, this.Height));
            DrawGrid(g);
            panel1.BackgroundImage = panelBG;
        }

        void dataRcvd_Received(object serder, Event.dataRcvdEventArgs Args)
        {
            o = (double[,])Args.data;
            if (o != null)
            {
                double[,] a = (double[,])o;
                double alpha = fft.get_now_alpha(a, Args.length, 27);
                alpha_list[index] = alpha;
                if(index <alpha_list.Length-1){
                    index +=1;
                }
                else{
                    index = 0;
                }
                label1.Text = String.Format("{0},", alpha);
            }
            DrawArray(panel_g, alpha_list);
            
        }


        private void DrawGrid(Graphics g)
        {
            Pen buttomLimePen = new Pen(Color.Gray);
            for (int i = 0; i <= this.Width; i += this.Width / 10)
            {
                g.DrawLine(buttomLimePen, new Point(i, 0), new Point(i, this.Height));

            }
            for (int i = 0; i <= this.Height; i += this.Height / 10)
            {
                g.DrawLine(buttomLimePen, new Point(0, i), new Point(this.Width, i));

            }

        }

        private void DrawArray(Graphics g,double[] arr)
        {
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            Pen wavePen = new Pen(Color.Cyan);
            GraphicsPath gPath1 = new GraphicsPath();
            Point[] p1 = new Point[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                p1[i].X = i*panel1.Width/arr.Length;
                p1[i].Y = panel1.Height-(int)(arr[i]*panel1.Height/36);
            }
            label1.Text += String.Format("{0}", panel1.Height - (int)(arr[index] * panel1.Height / 36));
            gPath1.AddCurve(p1);
            g.DrawPath(wavePen, gPath1);

        }
    }
}

