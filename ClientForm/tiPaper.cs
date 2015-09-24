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
    public partial class tiPaper : UserControl
    {
        public tiPaper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
            Event.Step.OnStepDone(this, sdea);
        }
    }
}
