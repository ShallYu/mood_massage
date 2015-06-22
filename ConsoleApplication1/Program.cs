using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientForm;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //dataSimulatorTest();
            FFTTest();

            Console.Read();
        }

        static private void FFTTest()
        {
            FFT fft1 = new FFT();
            dataSimulator ds1 = new dataSimulator();
            //StreamWriter sw1 = new StreamWriter(@"C:\Users\Yu\Desktop\a6.csv");
            
            ds1.Connect("fh02");
            int length = 500;
            //sw1.WriteLine("Alpha,Beta,Gamma,Theta");
            for (int k = 0; k < 240; k++)
            {
                double[,] a = ds1.ReadData(length);
                double alpha = fft1.get_now_alpha(a, length, 27);
                Console.WriteLine(alpha.ToString());
                //sw1.WriteLine(String.Format("{0},{1},{2},{3}", fft1.Alpha_Energy(amp), fft1.Beta_Energy(amp), fft1.Gamma_Energy(amp), fft1.Theta_Energy(amp)));
                //Console.WriteLine(String.Format("Alpha is {0}", fft1.Alpha_Energy(amp)));
                //Console.WriteLine(String.Format("Beta is {0}", fft1.Beta_Energy(amp)));
                //Console.WriteLine(String.Format("Theta is {0}", fft1.Theta_Energy(amp)));
                //Console.WriteLine("-----------------------");
            }
            //sw1.Close();
            Console.WriteLine("Done");
            
            ds1.DisConnect();
       
            
        }
        private void dataSimulatorTest()
        {
            dataSimulator ds1 = new dataSimulator();
            ds1.Connect("fh01");
            double[,] data = ds1.ReadData(5);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    Console.Write(String.Format("{0} ", data[j, i].ToString()));
                }
                Console.WriteLine("\n");

            }
            ds1.DisConnect();
        }
    }
}
