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
        int length = 900;
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
                double alpha = fft1.get_now_alpha(a, length, 27);
                panel1.Width = (int)(this.Width * Math.Abs(12 - alpha) / 12);
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
