using System;
using System.Collections.Generic;
using System.Text;

namespace ClientForm.Event
{
    class StepDoneEventArgs :EventArgs
    {

        public StepDoneEventArgs(Step.StepEnum stepEnum)
        {
            this.stepIndex = stepEnum;
        }
        public Step.StepEnum stepIndex;

    }
}
