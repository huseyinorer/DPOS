using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace impostemalı2
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TKDK yeni = new TKDK();
            yeni.Show();
            this.Hide();
        }
    }
}
