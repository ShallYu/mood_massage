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
            spInit();
            this.BackColor = Color.Black;
            timer1.Start();

            
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

        private void DrawArray(Graphics g,float[,] arr)
        {
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            Pen wavePen = new Pen(Color.Yellow);
            GraphicsPath gPath1 = new GraphicsPath();
            Point[] p1 = new Point[arr.Length/32];
            for (int i = 0; i < arr.Length; i++)
            {
                p1[i].X = i;
                p1[i].Y = (int)arr[1,i];
            }
            gPath1.AddCurve(p1);
            g.DrawPath(wavePen, gPath1);

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap panelBG = new Bitmap(panel1.Width, panel1.Height);
            Graphics g = Graphics.FromImage(panelBG);
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, this.Height));
            DrawGrid(g);
            //DrawArray(g,s1.ReadData(this.Width));
            panel1.BackgroundImage = panelBG;
        
        }
    }
}

