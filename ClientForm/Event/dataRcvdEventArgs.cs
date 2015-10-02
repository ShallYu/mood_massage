using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientForm.Event
{
    class dataRcvdEventArgs
    {
        public double[,] data;
        public int length = 1500;
        public int total = 36;
    }
}
