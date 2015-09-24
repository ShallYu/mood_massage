using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace CodeTemp
{
    static class MusicList
    {
        static public String music_type="愉快";
        static private int musicIndex = -1;
        static private List<string> filesPath = new List<string>();
        static MusicList()
        {

        }

        static public void setType(String str){
            music_type= str;
        }

        static public string getMusic()
        {
            filesPath = new List<string>();
            foreach (string i in System.IO.Directory.GetFiles(Application.StartupPath + @"\music\" + music_type + @"\", "*.mp3"))
            {
                filesPath.Add(i);
            }
            Random r1 = new Random();
            musicIndex = r1.Next(filesPath.Count);
            return filesPath[musicIndex];
        }

        static public string getPrevious()
        {
            return filesPath[musicIndex];
        }

    }
            
}
