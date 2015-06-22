using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mood_massage1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private string a = "good";
        public string A
        {
            get
            {
                return a;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Control p1 = new WaveGraph();
            Border1.Child = p1;
            
        }
    }
}
