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
        Timer draw_timer = new Timer();
        FFT fft1 = new FFT();
        dataSimulator ds1 = new dataSimulator();
        Object o;
        int length = 900;
        public MoodStat()
        {
            InitializeComponent();
            draw_timer.Interval = 900;
            draw_timer.Tick += draw_timer_Tick;
            ds1.Connect("fh02");
            draw_timer.Start();
        }

        void draw_timer_Tick(object sender, EventArgs e)
        {
            o = ds1.ReadData(length);
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
            draw_timer.Stop();
        }

    }
}
