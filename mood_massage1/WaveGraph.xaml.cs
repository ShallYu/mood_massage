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
    /// WaveGraph.xaml 的交互逻辑
    /// </summary>
    public partial class WaveGraph : UserControl
    {
        public WaveGraph()
        {
            
            InitializeComponent();
            DrawingVisual ghostVisual;

            Width = 300;
            Height = 350;
            ghostVisual = new DrawingVisual();
            using (DrawingContext dc = ghostVisual.RenderOpen())
            {

                dc.DrawEllipse(Brushes.Black, new Pen(Brushes.Red, 10),
                new Point(95, 95), 15, 15);

                dc.DrawEllipse(Brushes.Black, new Pen(Brushes.Red, 10),
                new Point(170, 105), 15, 15);

                Pen p = new Pen(Brushes.Black, 10);
                p.StartLineCap = PenLineCap.Round;
                p.EndLineCap = PenLineCap.Round;
                dc.DrawLine(p, new Point(75, 160), new Point(175, 150));
            }


            this.AddVisualChild(ghostVisual);
            this.AddLogicalChild(ghostVisual);
        }
        }

        
    }
