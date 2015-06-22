using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;


namespace ClientForm
{
    class Man
    {
        public int[] moodStat = new int[2];
        Random r1 = new Random();
        Timer t1 = new Timer();
        Music music1;

        public Man()
        {
            moodStat[0]=r1.Next(2000)-1000;
            moodStat[1]=r1.Next(2000)-1000;
            //t1.Interval = 1000;
            //t1.Elapsed += moodChage;
        }

        void moodChage(object sender, ElapsedEventArgs e)
        {
            moodStat[0] += (music1.musicIndex[0] - 1) * 50;
            moodStat[1] += (music1.musicIndex[1] - 1) * 50;
        }

        public void Listen(Music m1)
        {
            this.music1 = m1;
            moodStat[0] += (music1.musicIndex[0] - 1) * 50;
            moodStat[1] += (music1.musicIndex[1] - 1) * 50;
           //t1.Start();
        }
        public void StopListen()
        {
            t1.Stop();
        }
    }
}
