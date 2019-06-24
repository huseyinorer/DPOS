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
    public partial class Yonetim : Form
    {

        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");

        public Yonetim()
        {
            InitializeComponent();
            kullanicilar();
        }
        string Yetki;
        public Yonetim(string yetki)
        {
            InitializeComponent();
            kullanicilar();
            Yetki = yetki;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.delta.gen.tr");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void Yonetim_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 255, 255, 255);
        }

        private bool kullaniciKontrol(string kullaniciAdi)
        {

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select kullanici_Adi from kullanicilar where kullanici_Adi='" + kullaniciAdi + "'", baglan);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (dr["kullanici_Adi"].ToString().TrimEnd() == kullaniciAdi)
                    {
                        baglan.Close();
                        return false;

                    }

                }

            }
            catch
            {

                MessageBox.Show("Veritabanı Hatası");
            }

            baglan.Close();
            return true;
        }
        private void kullanicilar()
        {
            listBox1.Items.Clear();
            try
            {
                baglan.Open();

                SqlCommand cmd = new SqlCommand("select kullanici_Adi from kullanicilar", baglan);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    listBox1.Items.Add(dr["kullanici_Adi"].ToString().TrimEnd());


                }
                baglan.Close();

            }
            catch (Exception)
            {

                MessageBox.Show("Veritabanı Hatası");
            }
            baglan.Close();


        }

        string yetki;
        private void kullaniciEkle()
        {

            try
            {
                string sifre = "";

                if (textBox2.Text == textBox3.Text)
                {
                    sifre = textBox2.Text;

                    if (radioButton1.Checked == true)
                        yetki = "User";
                    else if (radioButton2.Checked == true)
                        yetki = "Admin";

                    if (kullaniciKontrol(textBox1.Text) == true)
                    {
                        baglan.Open();

                        SqlCommand cmd = new SqlCommand("insert into kullanicilar (kullanici_Adi,kullanici_Sifre,kullanici_Yetki) values ('" + textBox1.Text + "','" + sifre + "','" + yetki + "') ", baglan);
                        cmd.ExecuteNonQuery();
                        baglan.Close();

                    }
                    else
                        MessageBox.Show("Bu İsimde Bir Kullanıcı Ekleyemezsiniz");
                }
                else
                    MessageBox.Show("Şifreler Birbirinden Farklı");

            }
            catch
            {

                MessageBox.Show("Veritabanına Eklenirken Hata");
            }


            baglan.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            kullaniciEkle();
            kullanicilar();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 back = new Form3(Yetki);
            back.ShowDialog();
        }

        private void Yonetim_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem.ToString() == "Admin")
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("delete from kullanicilar where kullanici_Adi='" + listBox1.SelectedItem + "'", baglan);
                    cmd.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                    MessageBox.Show("Admin Silinemez");
            }
            catch (Exception)
            {

                MessageBox.Show("Silme İşleminde Bir Hata Oluştu");
            }
            kullanicilar();
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sifre = "";

            if (textBox4.Text == textBox5.Text)
            {
                sifre = textBox4.Text;


                try
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("update kullanicilar set kullanici_Sifre='"+sifre+"' where kullanici_Adi='"+listBox1.SelectedItem.ToString().TrimEnd()+"'", baglan);
                    cmd.ExecuteNonQuery();
                    baglan.Close();

                }
                catch 
                {
                    MessageBox.Show("Güncelleme Hatası, Şifresini Değiştirmek İstediğiniz Kullanıcıyı Seçmediniz");
                    
                }
                textBox4.Text = "";
                textBox5.Text = "";
                baglan.Close();
            }
        }
    }
}
