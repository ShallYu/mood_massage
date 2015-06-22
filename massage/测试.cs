using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ClientForm
{
    public partial class 测试 : UserControl
    {

        public 测试()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.currentMedia = axWindowsMediaPlayer1.newMedia(MusicList.getMusic());
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
            Event.Step.OnStepDone(this, sdea);
            
        }

        public void F_Amp(double[] xreal, double[] ximag)//求幅度然后取模值
        {
            for (int i = 0; i < 512; i++)
            {
                xreal[i] /= 256;
                ximag[i] /= 256;
                xreal[i] = (double)(Math.Pow((Math.Pow(xreal[i], 2.0) + Math.Pow(ximag[i], 2.0)),0.5));
            }
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
            double Alpha_E =0;
            for(int i=8;i<=12;i++)
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

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
            {
                Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.NEXT);
                Event.Step.OnStepDone(this, sdea);
            }
            
        }



    }
}
