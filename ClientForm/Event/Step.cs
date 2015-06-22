using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
namespace ClientForm.Event
{
    static class Step
    {
        static public int LoopIndex = 1;
        public enum StepEnum
        {
            SIGNIN, LOGIN, USERINFO, TEST, QPAPER,NEXT,MASSAGE
        }
        public delegate void StepDoneHandler(object serder,StepDoneEventArgs data);
        static public event StepDoneHandler StepDone;
        static public void OnStepDone(object sender,StepDoneEventArgs data)
        {
            if (StepDone != null)
            {
                StepDone(sender, data);
            }

        }

    }
 }
