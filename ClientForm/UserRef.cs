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
    public partial class UserRef : UserControl
    {
        public UserRef()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.TEST);
            Event.Step.OnStepDone(this, sdea);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MusicList.setType("愉快");
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.TEST);
            Event.Step.OnStepDone(this, sdea);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
            Event.Step.OnStepDone(this, sdea);
        }


    }
}
