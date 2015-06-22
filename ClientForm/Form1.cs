using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        private Dictionary<Event.Step.StepEnum, Type> CtlDict = new Dictionary<Event.Step.StepEnum, Type>();
        public Form1()
        {
            InitializeComponent();
            //ShowInit();
            CtlDict.Add(Event.Step.StepEnum.LOGIN, typeof(LogInCom));
            CtlDict.Add(Event.Step.StepEnum.QPAPER, typeof(qPaper));
            CtlDict.Add(Event.Step.StepEnum.SIGNIN, typeof(SignInCom));
            CtlDict.Add(Event.Step.StepEnum.TEST, typeof(MoodTest));
            CtlDict.Add(Event.Step.StepEnum.USERINFO, typeof(UserInfo));

            Event.Step.StepDone += new Event.Step.StepDoneHandler(StepHandler);
            Event.Step.StepDone += new Event.Step.StepDoneHandler(DownZero);
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.SIGNIN);
            Event.Step.OnStepDone(this, sdea);
        }
        private void StepHandler(object sender,Event.StepDoneEventArgs e)
        {
          //  Control ctl = new Massage();
          //  panel1.Controls.Add(ctl);
            
         if (e.stepIndex != Event.Step.StepEnum.NEXT)
            {
                Type t = CtlDict[e.stepIndex];
                if (panel1.HasChildren)
                {
                    panel1.Controls[0].Dispose();
                    panel1.Controls.Clear();
                }
                //MessageBox.Show(e.stepIndex.ToString());
                Control ctl = (Control)Activator.CreateInstance(t);
                setMiddle(ctl);
                panel1.Controls.Add(ctl);
            }
            else
            {
                LoopNext();
            }
            
            

        }
        private void DownZero(object sender,Event.StepDoneEventArgs e)
        {
            if (e.stepIndex == Event.Step.StepEnum.USERINFO)
            {
                Event.Step.LoopIndex = 1;
            }
        }
        private void setMiddle(Control ctl)
        {
            ctl.Left = (this.Width - ctl.Width) / 2;
            ctl.Top = (this.Height - ctl.Height) / 2;
        }


        private void LoopNext()
        {
            if (Event.Step.LoopIndex > 2)
            {
                Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
                Event.Step.OnStepDone(this, sdea);
                Event.Step.LoopIndex = 1;
            }
            else
            {
                Event.StepDoneEventArgs sdea;
                if (Event.Step.LoopIndex % 2 == 1)
                {
                    sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.TEST);
                }
                else
                {
                    sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.QPAPER);
                }
                Event.Step.OnStepDone(this, sdea);
                Event.Step.LoopIndex += 1;
            }
            
            

        }

        private void 用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
            Event.Step.OnStepDone(this, sdea);
        }

        private void 登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.SIGNIN);
            Event.Step.OnStepDone(this, sdea);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
