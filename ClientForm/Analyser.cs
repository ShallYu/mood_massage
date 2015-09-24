using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientForm
{
    class Analyser
    {
        Timer timer1 = new Timer();
        public Analyser()
        {
            timer1.Interval = 3000;
            timer1.Tick += analysis;
        }
        public void Start()
        {
            timer1.Start();
        }

        private void analysis(object sender, EventArgs e)
        {
            
        }
    }
}
