using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClientForm
{
    public class dataSimulator
    {
      
        FileStream f1;
        StreamReader sr1;
        private bool is_connected = false;
        public bool isConnected
        {
            get
            {
                return is_connected;
            }
        }
        public dataSimulator()
        {
        }

        public void Connect(String filename)
        {
            try
            {
                sr1 = new StreamReader(@"E:\Creating\EEG\matlab\2\" + filename + ".mat");
                is_connected = true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
        public void DisConnect()
        {
            try
            {
                //f1.Close();
                sr1.Close();
                is_connected = false;
            }
            finally
            {
            }
        }
        public double[,] ReadData(int length)
        {
            try
            {
                double[,] data = new double[32, length];
                for (int i = 0; i < length; i++)
                {
                    String dat_string = sr1.ReadLine();
                    DataFit(ref data, dat_string, i);
                }
                return data;
            }
            catch (EndOfStreamException e)
            {
                this.DisConnect();
                this.Connect("fh02");
                return null;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                this.DisConnect();
                return null;
            }
        }

        private void DataFit(ref double[,] data, string dat_string, int i)
        {
            string[] num = dat_string.Split('\t');
            for (int index = 0; index < num.Length-1; index++)
            {
                data[index, i] = double.Parse(num[index].Trim());
            }
        }
    }
}
