using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace massage{
{
    public partial class MoodVector : UserControl
    {
        dataSimulator s1 = new dataSimulator();
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

            
            int[] cor = new int[4];
            for (int i = 0; i < cor.Length; i++)
            {
                cor[i] = s1.getAlpha();
            }
            Graphics g = e.Graphics;
            g.DrawPie(new Pen(Color.White), cor[0] * this.Width / 100, cor[1] * this.Height / 100, 10, 10, 0, 360);
            g.DrawPie(new Pen(Color.Red), cor[2] * this.Width / 100, cor[3] * this.Height / 100, 10, 10, 0, 360);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();
        }
    }
}
