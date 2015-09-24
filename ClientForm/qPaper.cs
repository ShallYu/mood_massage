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
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]  
    public partial class qPaper : UserControl
    {
        
        public qPaper()
        {
            string baseUri = Application.StartupPath;
            InitializeComponent();

            webBrowser1.Url = new Uri(baseUri + @"\query.html");
            webBrowser1.ObjectForScripting = this;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
            this.Width = this.ParentForm.Width;
            this.Height = this.ParentForm.Height-50;      
        }

        public void querySave(string str)
        {
            /*
            if (!System.IO.Directory.Exists(Application.StartupPath + @"\" + CurrentUser.currentUser["Username"]))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\" + CurrentUser.currentUser["Username"]);
            }
            string path = Application.StartupPath + @"\"+CurrentUser.currentUser["Username"]+ @"\"+ DateTime.Now.Year+ DateTime.Now.Month+ DateTime.Now.Day +".txt";

            StreamWriter sw1 = new StreamWriter(path, true);
                sw1.WriteLine(MusicList.getPrevious());
                sw1.WriteLine(str);
                sw1.WriteLine("");
            sw1.Close();
            */

            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
            Event.Step.OnStepDone(this, sdea);
        }

    }
}
