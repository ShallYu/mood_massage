using System;
using System.Collections.Generic;

using System.Text;

//using System.Diagnostics;

namespace ClientForm
{
    public class FFT
    {
        public FFT()
        {     
        }

        private static void bitrp(ref double[] xreal, ref double[] ximag, int n)
        {
            // 位反转置换 Bit-reversal Permutation
            int i, j, a, b, p;
            for (i = 1, p = 0; i < n; i *= 2)
            {
                p++;
            }
            for (i = 0; i < n; i++)
            {
                a = i;
                b = 0;
                for (j = 0; j < p; j++)
                {
                    b = b * 2 + a % 2;
                    a = a / 2;
                }
                if (b > i)
                {
                    double t = xreal[i];
                    xreal[i] = xreal[b];
                    xreal[b] = t;
                    t = ximag[i];
                    ximag[i] = ximag[b];
                    ximag[b] = t;
                }
            }
        }
        public double get_now_alpha(double[,] data,int length,int port)
        {

            double[] xreal = new double[length];
                for (int i = 0; i < length; i++)
                {
                    xreal[i] = data[port, i];
                }
                double[] ximag = new double[xreal.Length];
                xreal.CopyTo(ximag, 0);

                fft_T(ref xreal, ref ximag);
                double[] amp=F_Amp(xreal, ximag);
                return Alpha_Energy(amp);
        }
        public double[][] fft_T(ref double[] xreal, ref double[] ximag)
        {
            //n值为2的N次方
            int n = 2;
            while (n <= xreal.Length)
            {
                n *= 2;
            }
            n /= 2;
            // 快速傅立叶变换，将复数 x 变换后仍保存在 x 中，xreal, ximag 分别是 x 的实部和虚部
            double[] wreal = new double[n / 2];
            double[] wimag = new double[n / 2];
            double treal, timag, ureal, uimag, arg;
            int m, k, j, t, index1, index2;
            bitrp(ref xreal, ref ximag, n);
            // 计算 1 的前 n / 2 个 n 次方根的共轭复数 W'j = wreal [j] + i * wimag [j] , j = 0, 1, ... , n / 2 - 1
            arg = (double)(-2 * Math.PI / n);
            treal = (double)Math.Cos(arg);
            timag = (double)Math.Sin(arg);
            wreal[0] = 1.0f;
            wimag[0] = 0.0f;
            for (j = 1; j < n / 2; j++)
            {
                wreal[j] = wreal[j - 1] * treal - wimag[j - 1] * timag;
                wimag[j] = wreal[j - 1] * timag + wimag[j - 1] * treal;
            }
            for (m = 2; m <= n; m *= 2)
            {
                for (k = 0; k < n; k += m)
                {
                    for (j = 0; j < m / 2; j++)
                    {
                        index1 = k + j;
                        index2 = index1 + m / 2;
                        t = n * j / m;    // 旋转因子 w 的实部在 wreal [] 中的下标为 t
                        treal = wreal[t] * xreal[index2] - wimag[t] * ximag[index2];
                        timag = wreal[t] * ximag[index2] + wimag[t] * xreal[index2];
                        ureal = xreal[index1];
                        uimag = ximag[index1];
                        xreal[index1] = ureal + treal;
                        ximag[index1] = uimag + timag;
                        xreal[index2] = ureal - treal;
                        ximag[index2] = uimag - timag;
                    }
                }
            }
            double[][] result = {xreal,ximag};
            return result;
        }

        public double[] F_Amp(double[] xreal, double[] ximag)//求幅度然后取模值
        {
            for (int i = 0; i < xreal.Length; i++)
            {
                xreal[i] /= xreal.Length/2;
                ximag[i] /= xreal.Length / 2;
                xreal[i] = (double)(Math.Pow((Math.Pow(xreal[i], 2.0) + Math.Pow(ximag[i], 2.0)), 0.5));
            }
            return xreal;
        }
        public double Delta_Energy(double[] amplf)//求能量
        {
            double Delta_E = 0;
            for (int i = 1; i <= 3; i++)
            {
                Delta_E += Math.Pow(amplf[i], 2.0);
            }
            return Delta_E;
        }
        public double Theta_Energy(double[] amplf)//求能量
        {
            double Theta_E = 0;
            for (int i = 4; i <= 7; i++)
            {
                Theta_E += Math.Pow(amplf[i], 2.0);
            }

            return Theta_E;
        }
        public double Alpha_Energy(double[] amplf)//求能量
        {
            double Alpha_E = 0;
            for (int i = 8; i <= 12; i++)
            {
                Alpha_E += Math.Pow(amplf[i], 2.0);
            }

            return Alpha_E;
        }
        public double Beta_Energy(double[] amplf)//求能量
        {
            double Beta_E = 0;
            for (int i = 13; i <= 30; i++)
            {
                Beta_E += Math.Pow(amplf[i], 2.0);
            }

            return Beta_E;
        }
        public double Gamma_Energy(double[] amplf)//求能量
        {
            double Gamma_E = 0;
            for (int i = 31; i <= 45; i++)
            {
                Gamma_E += Math.Pow(amplf[i], 2.0);
            }

            return Gamma_E;
        }
        //public static int IFFT(float[] xreal, float[] ximag)
        //{
        //    //n值为2的N次方
        //    int n = 2;
        //    while (n <= xreal.Length)
        //    {
        //        n *= 2;
        //    }
        //    n /= 2;
        //    // 快速傅立叶逆变换
        //    float[] wreal = new float[n / 2];
        //    float[] wimag = new float[n / 2];
        //    float treal, timag, ureal, uimag, arg;
        //    int m, k, j, t, index1, index2;
        //    bitrp(xreal, ximag, n);
        //    // 计算 1 的前 n / 2 个 n 次方根 Wj = wreal [j] + i * wimag [j] , j = 0, 1, ... , n / 2 - 1
        //    arg = (float)(2 * Math.PI / n);
        //    treal = (float)(Math.Cos(arg));
        //    timag = (float)(Math.Sin(arg));
        //    wreal[0] = 1.0f;
        //    wimag[0] = 0.0f;
        //    for (j = 1; j < n / 2; j++)
        //    {
        //        wreal[j] = wreal[j - 1] * treal - wimag[j - 1] * timag;
        //        wimag[j] = wreal[j - 1] * timag + wimag[j - 1] * treal;
        //    }
        //    for (m = 2; m <= n; m *= 2)
        //    {
        //        for (k = 0; k < n; k += m)
        //        {
        //            for (j = 0; j < m / 2; j++)
        //            {
        //                index1 = k + j;
        //                index2 = index1 + m / 2;
        //                t = n * j / m;    // 旋转因子 w 的实部在 wreal [] 中的下标为 t
        //                treal = wreal[t] * xreal[index2] - wimag[t] * ximag[index2];
        //                timag = wreal[t] * ximag[index2] + wimag[t] * xreal[index2];
        //                ureal = xreal[index1];
        //                uimag = ximag[index1];
        //                xreal[index1] = ureal + treal;
        //                ximag[index1] = uimag + timag;
        //                xreal[index2] = ureal - treal;
        //                ximag[index2] = uimag - timag;
        //            }
        //        }
        //    }
        //    for (j = 0; j < n; j++)
        //    {
        //        xreal[j] /= n;
        //        ximag[j] /= n;
        //    }
        //    return n;
        //}
   
        //static void Main(string[] args)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
            
        //    float[] a = {
        //        0.5751f,0.4514f,0.0439f,0.0272f,0.3127f,0.0129f,0.3840f,0.6831f,
        //        0.0928f,0.0353f,0.6124f ,0.6085f,0.0158f,0.0164f,0.1901f,0.5869f};
        //    float[] b = {
        //        0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,
        //        0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f};
        //    int n = FFT(a,b);
        //    Console.WriteLine("FFT:");
        //    Console.WriteLine("FFT的返回值N = {0}", n);
        //    Console.WriteLine();
        //    Console.WriteLine("i\ta\tb");
        //    Console.WriteLine();
        //    for (int i = 0; i < n; i++)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}", i, a[i], b[i]);
        //    }
        //    //Console.ReadLine();
        //    sw.Stop();
        //    Console.WriteLine(sw.Elapsed);
        //}
    }
}
