using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClientForm
{
    class BufferSave
    {
        static Int32 bufferLength = 4000;
        static Int64 filePartLength = 8*1024  *1024;
        static string path = "./";
        double[] buffer;
        Int32 fileLength;
        Int32 fileIndex;
        StreamWriter sw1;


        public BufferSave()
        {
            fileLength = 0;
            fileIndex = 0;//(int)CurrentUser.currentUser["BufferIndex"]+1;
            buffer = new double[bufferLength];
            this.sw1 = new StreamWriter(path + fileIndex.ToString()+".txt", true);
        }

        private bool fileCheck(string dir)
        {
            string[] subDir= dir.Split('/');
            return false;
        }
        public void Close()
        {
            sw1.Close();
        }

        public void Save(float f1)
        {
            fileLength += 1;
            if (fileLength >= filePartLength)
            {
                fileIndex += 1;
                this.sw1.Close();
                this.sw1 = new StreamWriter(path + fileIndex.ToString()+".txt", true);
            }
            this.sw1.Write(f1);
        }
        

    }
}
