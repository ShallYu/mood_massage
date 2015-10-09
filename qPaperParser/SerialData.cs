using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qPaperParser
{
    class SerialData
    {
        private void spInit()
        {
            sp = new SerialPort();
            sp.PortName = "COM40";
            sp.BaudRate = 57600;
            sp.DataBits = 8;
            sp.Parity = Parity.Even;
            try
            {
                sp.Open();
                try
                {
                    sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);//事件

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("无法连接串口");
            }



        }

        public void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                if (sp.IsOpen)
                {
                    // int a=sp.ReadBufferSize;
                    byte[] sp_buffer = new byte[sp.ReadBufferSize + 1];

                    int count = sp.Read(sp_buffer, 0, sp.ReadBufferSize);

                    for (int i = 0; i < count; i++)
                    {
                        float receivedrawWaveData = parser.parseByte(sp_buffer[i]);

                        if (receivedrawWaveData != 0)
                        {
                            receivedrawWaveData = receivedrawWaveData * 0.21973F;//转化为实际电压值，微伏
                            ///////////////////////////
                            // lock (buffer)
                            //{

                            buffer[num++] = receivedrawWaveData;

                            //}
                            //写数据到txt

                            ////////////////                           
                        }
                    }
                }
            }));
        }
    }
}
