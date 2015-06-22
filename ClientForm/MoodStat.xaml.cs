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

namespace ClientForm
{
    /// <summary>
    /// MoodStat.xaml 的交互逻辑
    /// </summary>
    public partial class MoodStat : UserControl
    {
        public MoodStat()
        {
            InitializeComponent();
            rect1.DataContext = this;
            Binding rect_b = new Binding(){ Path = new PropertyPath("Height")};
            //rect1.SetBinding(rect1.Width, rect_b);
        }
    }
}
