using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ClientForm
{
    public partial class MoodStat : UserControl
    {
        FFT fft1 = new FFT();
        dataSimulator ds1 = new dataSimulator();
        Object o;
        public MoodStat()
        {
            InitializeComponent();
            ds1.Connect("fh02");
            Event.dataRcvd.Received += dataRcvd_Received;
        }

        void dataRcvd_Received(object serder, Event.dataRcvdEventArgs Args)
        {
            o = (double[,])Args.data;
            if (o != null)
            {
                double[,] a = (double[,])o;
                double alpha = fft1.get_now_alpha(a, Args.length, 27);
                panel1.Height = (int)(this.Height * Math.Abs(Args.total - alpha) / Args.total);
            }
        }

        private void MoodStat_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect1 = new Rectangle(0,0,this.Width,this.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect1,Color.Blue,Color.Red,LinearGradientMode.Horizontal);
            g.FillRectangle(brush, rect1);
        }

        public void Close()
        {
            ds1.DisConnect();
        }

    }
}
