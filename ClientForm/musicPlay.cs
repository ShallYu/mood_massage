using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace ClientForm
{
    public partial class musicPlay : UserControl
    {
        public musicPlay()
        {
            InitializeComponent();
        }

        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            progressBar1.Value = e.Location.X * 100 / progressBar1.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }




    }
}
