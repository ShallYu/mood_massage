using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Form2 : Form
    {
        dataSimulator ds1 = new dataSimulator();
        public Form2()
        {
            InitializeComponent();
            ds1.Connect("fh02");
        }
    }
}
