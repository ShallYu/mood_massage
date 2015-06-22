using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace massage
{
    public partial class Form1 : Form
    {
        Music music1 = new Music();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] test = new int[2];
            test[0] = System.Int32.Parse(textBox1.Text);
            test[1] = System.Int32.Parse(textBox2.Text);
            label1.Text = music1.getMusic(test);
        }
    }
}
