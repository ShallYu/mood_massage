using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class MoodVector : UserControl
    {
        FFT fft1 = new FFT();
        Point last_point = new Point(0,0);
        Point now_point = new Point(0, 0);
        Graphics g;
        public MoodVector()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            last_point = new Point(panel1.Width / 2, panel1.Height / 2);
            now_point = new Point(panel1.Width / 2, panel1.Height / 2);
            setPanelBG();
            Event.dataRcvd.Received += dataRcvd_Received;

        }

        void dataRcvd_Received(object serder, Event.dataRcvdEventArgs data)
        {
            double alpha = fft1.get_now_alpha(data.data, data.length, 27);
            double beta = fft1.get_now_beta(data.data, data.length, 27);
            if (alpha <= data.total_alpha && beta <= data.total_beta)
            {
                last_point = now_point;
                now_point.X = (int)(alpha * this.Width / data.total_alpha);
                now_point.Y = (int)(this.Width - beta * this.Width / data.total_beta);
            }
            g = panel1.CreateGraphics();
            g.DrawPie(new Pen(Color.Red), now_point.X - 5, now_point.Y - 5, 10, 10, 0, 360);
            g.DrawLine(new Pen(Color.Cyan), last_point, now_point);
            
        }

        private void setPanelBG()
        {
            Bitmap panelBG = new Bitmap(panel1.Width, panel1.Height);
            Graphics g_bg = Graphics.FromImage(panelBG);
            g_bg.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, this.Height));
            Pen linePen = new Pen(Color.Yellow);
            g.DrawLine(linePen, new Point(0, this.Height / 2), new Point(this.Width, this.Height / 2));
            g.DrawLine(linePen, new Point(this.Width / 2, 0), new Point(this.Width / 2, this.Height));
            g.DrawString("α", DefaultFont, Brushes.White, new PointF(this.Width - 12, this.Height / 2 + 2));
            g.DrawString("β", DefaultFont, Brushes.White, new PointF(this.Width/2 +2, 2));
            panel1.BackgroundImage = panelBG;
        }
        public void clear_event()
        {
            Event.dataRcvd.Received -= dataRcvd_Received;
        }
        internal void refresh()
        {
            panel1.Refresh();
        }
    }
}
