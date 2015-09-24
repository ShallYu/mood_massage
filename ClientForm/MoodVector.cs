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
        //dataSimulator s1 = new dataSimulator();
        public MoodVector()
        {
            InitializeComponent();
            setPanelBG();

        }

        private void setPanelBG()
        {
            Bitmap panelBG = new Bitmap(panel1.Width, panel1.Height);
            Graphics g = Graphics.FromImage(panelBG);
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, this.Height));
            Pen linePen = new Pen(Color.Yellow);
            g.DrawLine(linePen, new Point(0, this.Height / 2), new Point(this.Width, this.Height / 2));
            g.DrawLine(linePen, new Point(this.Width / 2, 0), new Point(this.Width / 2, this.Height));
            g.DrawString("α", DefaultFont, Brushes.White, new PointF(this.Width - 12, this.Height / 2 + 2));
            g.DrawString("β", DefaultFont, Brushes.White, new PointF(this.Width/2 +2, 2));
            panel1.BackgroundImage = panelBG;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

          
            Graphics g = e.Graphics;
            g.DrawPie(new Pen(Color.White), nowPoint[0] * this.Width / 2000, nowPoint[1] * this.Height / 2000, 10, 10, 0, 360);
            g.DrawPie(new Pen(Color.Red), targetPoint[0] * this.Width /2000, targetPoint[1] * this.Height / 2000, 10, 10, 0, 360);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        public int[] nowPoint = new int[2];

        public int[] targetPoint = new int[2];

        internal void refresh()
        {
            panel1.Refresh();
        }
    }
}
