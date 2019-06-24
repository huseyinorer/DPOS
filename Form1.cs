using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace impostemalı2
{
    public partial class Form1 : Form
    {

        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 200);
        }

       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.delta.gen.tr");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kullaniciKontrol(txtkullanici.Text,txtsifre.Text))
            {
                Form3 yeni = new Form3(kullaniciYetki);
                yeni.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifresi.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            txtkullanici.Text = "";
            txtsifre.Text = "";
        }

        string kullaniciAdi;
        string kullaniciYetki;
        string kullaniciSifre;

        private bool kullaniciKontrol(string kullanici,string sifre)
        {
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select * from kullanicilar where kullanici_Adi='"+kullanici+"' and kullanici_Sifre='"+sifre+"'", baglan);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    kullaniciYetki = dr["kullanici_Yetki"].ToString().TrimEnd();
                    kullaniciAdi = dr["kullanici_Adi"].ToString().TrimEnd();
                    kullaniciSifre = dr["kullanici_Sifre"].ToString().TrimEnd();
                    if(txtkullanici.Text==kullaniciAdi && txtsifre.Text== kullaniciSifre)
                     return true;
                    

                }

                
                baglan.Close();
            }
            catch 
            {
                MessageBox.Show("Kullanici Bulunamadı veya Veritabanında Bir Hata Oluştu");
                return false;
               
            }
           
            baglan.Close();
            return false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
          //  Environment.Exit(0);
        }

        private void txtsifre_KeyDown(object sender, KeyEventArgs e)
        {
           if( e.KeyCode==Keys.Enter)
            {
                if (kullaniciKontrol(txtkullanici.Text, txtsifre.Text))
                {
                    Form3 yeni = new Form3(kullaniciYetki);
                    yeni.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifresi.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                txtkullanici.Text = "";
                txtsifre.Text = "";
                
            }
        }
    }
}
