using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace ClientForm
{
    public partial class Massage : UserControl
    {

        //Man man1 = new Man();
        //Music music1 = new Music();
        Random r1 = new Random();
        int nowMood = -2;
        Int32[] targetMood = new Int32[2];
        dataSimulator ds1 = new dataSimulator();
        FFT fft1 = new FFT();
        String[] music_name = { "minus.mp3", "plus.mp3" };
        int music_index = 0;
        public Massage()
        {   
            InitializeComponent();
            targetMood[1] = -4;
            ds1.Connect("fh03");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            Event.Step.LoopIndex = 1;
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
            Event.Step.OnStepDone(this, sdea);
            
        }


        public void axClose()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void moodVector1_Click(object sender, EventArgs e)
        {
           
            MouseEventArgs args = (MouseEventArgs)e;
            //int[] mood_vec = new int[2];
            //mood_vec[0] = targetMood[0] - man1.moodStat[0];
            //mood_vec[1] = targetMood[1] - man1.moodStat[1];
            //string music_choose = music1.getMusic(mood_vec);
            //string file_name = System.IO.Directory.GetFiles(Application.StartupPath + @"\music\"+music_choose+ ".mp3")[0];
            //axWindowsMediaPlayer1.currentMedia = axWindowsMediaPlayer1.newMedia(file_name);
            //axWindowsMediaPlayer1.Ctlcontrols.play();
            MessageBox.Show("clicked");
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int length = 500;
            double[,] a = ds1.ReadData(length);
            double alpha_e = fft1.get_now_alpha(a, length, 27);
            if (alpha_e <= 10)
            {
                 nowMood = (int)(alpha_e * panel1.Width / 10);
                 toolStripStatusLabel1.Text = nowMood.ToString();
                 toolStripStatusLabel2.Text = targetMood[1].ToString();
            }
            panel1.Refresh();
            if (Math.Abs(nowMood - targetMood[1]) <= 3)
            {
                timer1.Stop();
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                MessageBox.Show("恭喜！您已达到目标情绪！");
                Event.Step.LoopIndex = 1;
                Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
                Event.Step.OnStepDone(this, sdea);
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r1 = new Rectangle(0,panel1.Height/2, panel1.Width, panel1.Height/2);
            Rectangle r_target = new Rectangle(targetMood[1] - 2, panel1.Height / 3, 4, panel1.Height);
            Rectangle r_now = new Rectangle(nowMood - 2,panel1.Height/3, 4, panel1.Height);
            LinearGradientBrush myBrush = new LinearGradientBrush(r1, Color.Blue, Color.Red, LinearGradientMode.Horizontal);
            g.FillRectangle(myBrush, r1);
            g.FillRectangle(new SolidBrush(Color.Yellow), r_target);
            g.FillRectangle(new SolidBrush(Color.Black), r_now);
            g.DrawRectangle(new Pen(myBrush), r1);
            g.DrawRectangle(new Pen(Color.Yellow),r_target);
            g.DrawRectangle(new Pen(Color.Black), r_now);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs mea1 = (MouseEventArgs)e;
            targetMood[1] = mea1.X;
            toolStripStatusLabel3.Text = "";
            timer1.Start();
            panel1.Refresh();

            int length = 500;
            double[,] a = ds1.ReadData(length);
            double alpha_e = fft1.get_now_alpha(a, length, 27);
            nowMood = (int)(alpha_e * panel1.Width / 10);
            if (targetMood[1] - nowMood < 0)
            {
                music_index = 0;
            }
            else
            {
                music_index = 1;
            }
            //MessageBox.Show(Application.StartupPath + @"\music\" + music_name[music_index]);
            String file_name = Application.StartupPath + @"\music\" + music_name[music_index];
            axWindowsMediaPlayer1.currentMedia = axWindowsMediaPlayer1.newMedia(file_name);
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }




    }
}
