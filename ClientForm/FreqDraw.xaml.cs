using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientForm
{
    /// <summary>
    /// FreqDraw.xaml 的交互逻辑
    /// </summary>
    public partial class FreqDraw : UserControl
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        Random r1 = new Random();

        public FreqDraw()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Tick +=timer1_Tick;
            timer1.Enabled = true;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            AlphaMask.Height = r1.Next(200);
            BetaMask.Height = r1.Next(200);
            GammaMask.Height = r1.Next(200);
            ThetaMask.Height = r1.Next(200);
        }


    }
}
