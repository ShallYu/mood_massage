using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace ClientForm
{
   
    
    public class Parser
    {
        public const int PARSER_CODE_POOR_SIGNAL = 2;
        public const int PARSER_CODE_HEARTRATE = 3;
        public const int PARSER_CODE_CONFIGURATION = 4;//大包中专注度位
        public const int PARSER_CODE_RAW = 128;        //小包中的第4位，80
        public const int PARSER_CODE_DEBUG_ONE = 132;
        public const int PARSER_CODE_DEBUG_TWO = 133;
        public const int PARSER_CODE_EEG_POWER = 131;// 大包中的第6位，为固定值83

        public const int PST_PACKET_CHECKSUM_FAILED = -2;
        public const int PST_NOT_YET_COMPLETE_PACKET = 0;
        public const int PST_PACKET_PARSED_SUCCESS = 1;
        public const int MESSAGE_READ_RAW_DATA_PACKET = 17;
        public const int MESSAGE_READ_DIGEST_DATA_PACKET = 18;

        private const int RAW_DATA_BYTE_LENGTH = 2;//小包中的原始数据位为2位，高和低
        private const int EEG_DEBUG_ONE_BYTE_LENGTH = 5;
        private const int EEG_DEBUG_TWO_BYTE_LENGTH = 3;
        private const int PARSER_SYNC_BYTE = 170;        //第一位AA
        private const int PARSER_EXCODE_BYTE = 85;
        private const int MULTI_BYTE_CODE_THRESHOLD = 127;//阈值，大于此数为小包

        private const int PARSER_STATE_SYNC = 1;          //判断第一位
        private const int PARSER_STATE_SYNC_CHECK = 2;    //判断第二位
        private const int PARSER_STATE_PAYLOAD_LENGTH = 3;//判断第三位，payload长度位
        private const int PARSER_STATE_PAYLOAD = 4;       //判断第四位
        private const int PARSER_STATE_CHKSUM = 5;        //最后一位，校验和

        private int parserStatus;
        private int payloadLength;//用于存放第三位，即payload长度
        private int payloadBytesReceived;
        private int payloadSum;
        private int checksum;

        private byte[] payload = new byte[256];//用于存放所有除AA AA payload长度 校验位的其他位元素
  
       // string path = @"c:\Users\Andy\Desktop\C#.txt";//保存数据的路径


        public Parser()
        {
            this.parserStatus = PARSER_STATE_SYNC;//第一位
        }

        public int parseByte(byte buffer)
        {
            /// <summary>
            /// 本方法用于判断数据包是否合格，buffer为数据包中的某一个字节，
            /// 首先通过两个同部位AA AA进行判断数据是否为一个完整的包，
            /// 进而利用校验和判断数据包是否为正确的包，
            /// 如果为正确的包，经所有payload位存到byte型数组payload中。
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
           // int returnValue = 0;//用于标记数据包校验是否成功，成功为1，失败为-2
            int returnrawWaveData = 0;
            switch (this.parserStatus)
            {
                case 1:
                    if ((buffer & 0xFF) != PARSER_SYNC_BYTE) break; //=1,是否等于AA
                    this.parserStatus = PARSER_STATE_SYNC_CHECK; break;//=2
                case 2:
                    if ((buffer & 0xFF) == PARSER_SYNC_BYTE)       //是否等于第二个AA
                        this.parserStatus = PARSER_STATE_PAYLOAD_LENGTH;//=3
                    else
                    {
                        this.parserStatus = PARSER_STATE_SYNC; //执行到这，前两个字节不是AA AA，相当于重新开始校验同步，
                    }
                    break;
                case 3:
                    this.payloadLength = (buffer & 0xFF);//小包长度为4，大包长度为32
                    this.payloadBytesReceived = 0;//对payload元素个数进行计数
                    this.payloadSum = 0;         //用于存放所有payload元素的和，最终用于判断是否等于最后的校验和位
                    this.parserStatus = PARSER_STATE_PAYLOAD;//=4
                    break;
                case 4:
                    this.payload[(this.payloadBytesReceived++)] = buffer;//小包第一个为80
                    this.payloadSum += (buffer & 0xFF);
                    if (this.payloadBytesReceived < this.payloadLength) break; //如果未存到payload数据的最后一字节，跳出移到下一位继续存，
                    this.parserStatus = PARSER_STATE_CHKSUM; //=5;  否则parserStatus等于最后一个元素，校验和
                    break;
                case 5:
                    this.checksum = (buffer & 0xFF);//包中的最后一个字节：校验和
                    this.parserStatus = PARSER_STATE_SYNC;//想要的四个字节读取完毕，将parserStatus重新赋值为1，为存下一个四字做准备
                    if (this.checksum != ((this.payloadSum ^ 0xFFFFFFFF) & 0xFF))//如果不相等，数据包不合格，丢弃
                    {
                        //returnValue = -2;
                        // Console.WriteLine("CheckSum ERROR!!");//校验不成功
                    }
                    else
                    {
                        //returnValue = 1;//成功取得一个数据包
                       returnrawWaveData= parsePacketPayload();//校验成功，读取到的包是合格的，接下来调用parsePacketPayload()函数
                    }
                    break;
            }
            //return returnValue;//将判断结果返回
            return returnrawWaveData;//将解析出来的raw值返回
        }

        private int parsePacketPayload()
        {
            /// <summary>
            /// 本方法用于对合格的数据包中的数据（小包为4个字节）进行解析并获取数据值
            /// </summary>
            int i = 0;
            // int extendedCodeLevel = 0;
            int code = 0;
            int valueBytesLength = 0;

            //int signal = 0; 
            //int config = 0; 
            //int heartrate = 0;
            int rawWaveData = 0;//存放解析后的原始数据

            while (i < this.payloadLength)//小包中payload=4；大包payload=32
            {
                //extendedCodeLevel++;

                //85，小包中的此位为128，不执行
                while (this.payload[i] == PARSER_EXCODE_BYTE)//不=85,因为小包中的payload[0]为128（16进制中为80）
                {
                    i++;
                }

                code = this.payload[(i++)] & 0xFF;//i=0;code为128


                if (code > MULTI_BYTE_CODE_THRESHOLD)//  > 阈值127，如果为小包，此时为128>127
                {
                    valueBytesLength = this.payload[(i++)] & 0xFF;//小包中payload[1]结果为02，即数据位为2位
                }
                else
                {
                    valueBytesLength = 1;
                }


                if (code == PARSER_CODE_RAW) //判断是否为128，小包中的第四位(16进制：80)
                {
                    if ((valueBytesLength == RAW_DATA_BYTE_LENGTH))//==2
                    {
                        byte highOrderByte = this.payload[i];//此时i=2
                        byte lowOrderByte = this.payload[(i + 1)];

                        rawWaveData = getRawWaveValue(highOrderByte, lowOrderByte);//移位解析

                        if (rawWaveData > 32768)
                            rawWaveData -= 65536;
                    }
                    i += valueBytesLength;//  i=2+2
                }
               // else return 0;
            }
            this.parserStatus = PARSER_STATE_SYNC;
            return rawWaveData;
        }
        
        /// <summary>
        /// 由高低位计算原始数据值
        /// </summary>
        /// <param name="highOrderByte"></param>
        /// <param name="lowOrderByte"></param>
        /// <returns></returns>
        private int getRawWaveValue(byte highOrderByte, byte lowOrderByte)
        {
            
            /* Sign-extend the signed high byte to the width of a signed int */
            int hi = (int)highOrderByte;

            /* Extend low to the width of an int, but keep exact bits instead of sign-extending */
            int lo = ((int)lowOrderByte) & 0xFF;

            /* Calculate raw value by appending the exact low bits to the sign-extended high bits */
            int value = (hi << 8) | lo;

            return (value);
        }

    }
}
