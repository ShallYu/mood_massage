using System;
using System.Collections.Generic;
using System.Text;

namespace ClientForm{
    class Music
    {
        string[,] musicVector = new String[3,3];
        public int[] musicIndex = new int[2];
        public Music()
        {
            musicVector[0, 0] = "00";
            musicVector[0, 1] = "01";
            musicVector[0, 2] = "02";
            musicVector[1, 0] = "10";
            musicVector[1, 1] = "11";
            musicVector[1, 2] = "12";
            musicVector[2, 0] = "20";
            musicVector[2, 1] = "21";
            musicVector[2, 2] = "22";
        }

        public string getMusic(int[] moodVector){
            int[] music_arr = toGrid(moodVector);
            musicIndex = music_arr;
            return musicVector[music_arr[0], music_arr[1]];
        }

        private int[] toGrid(int[] moodVector)
        {
            float[] grid = new float[2];
            if (Math.Abs(moodVector[0]) >=Math.Abs( moodVector[1]))
            {
                float base_vec = Math.Abs(moodVector[0]);
                if (base_vec != 0)
                {
                    grid[0] = moodVector[0] / base_vec;
                    grid[1] = moodVector[1] / base_vec;
                }
                else if (moodVector[1] == 0)
                {
                    grid[0] = 0;
                    grid[1] = 0;
                }
                else
                {
                    grid[0] = 0;
                    grid[1] = moodVector[1] / Math.Abs(moodVector[1]);
                }
                
            }
            else
            {
                float base_vec = Math.Abs(moodVector[1]);
                if (base_vec == 0)
                {
                    grid[0] = moodVector[0] / Math.Abs(moodVector[0]);
                    grid[1] = 0;
                }
                else
                {
                    grid[0] = moodVector[0] / base_vec;
                    grid[1] = moodVector[1] / base_vec;
                }


            }

            int[] temp = new int[2];
            temp[0] = float2int(grid[0]) +1;
            temp[1] = float2int(grid[1]) + 1;
            return temp;
            
        }

        private int float2int(float f1){
            int i1 = (int)f1;
            int flag = (int)(f1 / Math.Abs(f1));
            float comp = Math.Abs(f1 - i1);
            if (comp >= 0.5)
            {
                i1 += flag;
            }
            return i1;
        }
    }
}
