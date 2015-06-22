using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ClientForm
{
    static class MusicList
    {
        static private int musicIndex = -1;
        static private List<string> filesPath = new List<string>();
        static MusicList()
        {
            foreach (string i in System.IO.Directory.GetFiles(Application.StartupPath + @"\music\", "*.mp3"))
            {
                filesPath.Add(i);
            }
        }

        static public string getMusic()
        {
            if (musicIndex >= 6)
            {
                musicIndex =0;
            }
            else
            {
                musicIndex += 1;
            }
            
            return filesPath[musicIndex];
        }

        static public string getPrevious()
        {
            return filesPath[musicIndex];
        }

    }
            
}
