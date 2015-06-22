using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class SignInCom : UserControl
    {
        public SignInCom()
        {
            InitializeComponent();
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentUser.SignIn(nameBox.Text, pwdBox.Text);
                Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
                Event.Step.OnStepDone(this, sdea);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            Event.StepDoneEventArgs seda = new Event.StepDoneEventArgs(Event.Step.StepEnum.LOGIN);
            Event.Step.OnStepDone(this, seda);
        }
    }
}
