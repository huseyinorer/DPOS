using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace impostemalı2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string Yetki;
        public Form3(string yetki)
        {
            InitializeComponent();
            Yetki = yetki;
            if (yetki == "User")
                button4.Enabled = false;
            else if (yetki == "Admin")
                button4.Enabled = true;

        }

    
        private void Form3_Load(object sender, EventArgs e)
        {
          //  this.Location = new Point(500, 200);
            panel1.BackColor = Color.FromArgb(180, 255, 255, 255);
           
        }

    

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.delta.gen.tr");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VeritabanıYonetim yeni = new VeritabanıYonetim(Yetki);
            yeni.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TKDK yeni = new TKDK(Yetki);
            yeni.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 back = new Form1();
           
            back.ShowDialog();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Yonetim yp = new Yonetim(Yetki);
            yp.Show();
            this.Hide();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
