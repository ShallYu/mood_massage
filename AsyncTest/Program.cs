using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace AsyncTest
{
    class Program
    {

        static string a = "";
        static public string a1()
        {
            string a = "";
            for (int i = 0; i < 500; i++)
            {
                a += ('a'+i).ToString();
            }
            return a;
        }
        static void Main(string[] args)
        {
            WebClient w1 = new WebClient();
            w1.DownloadStringCompleted += new DownloadStringCompletedEventHandler(LogEvent);
            Uri u1 = new Uri("http://www.baidu.com");
            w1.DownloadStringAsync(u1);
            Console.WriteLine("Loading");
            Thread.Sleep(200);
            Console.Write(a);
            Console.ReadLine();

        }

        private static void LogEvent(object sender, DownloadStringCompletedEventArgs e)
        {
            a = e.Result.ToString();
        }

        
    }
}
