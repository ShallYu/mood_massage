using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ClientForm.Event
{
    static class dataRcvd
    {

        public delegate void dataRcvdHandler(object serder, dataRcvdEventArgs data);
        static public event dataRcvdHandler Received;
        static public void OnReceived(object sender, dataRcvdEventArgs data)
        {
            if (Received != null)
            {
                Received(sender, data);
            }

        }
    }
}
