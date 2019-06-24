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
    public partial class yatirimGuncelle : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");

        public yatirimGuncelle()
        {
            InitializeComponent();
        }

        int proje_ID;
        public yatirimGuncelle(int projeID)
        {
            InitializeComponent();
            proje_ID = projeID;
            yatirimciCombobox();
            projeGetir();
            

        }

        
        private void yatirimciCombobox()
        {

            comboBox4.Items.Clear();

            try
            {
                baglan.Open();
                SqlCommand cmd_Gercek = new SqlCommand("select Ad_Soyad from Yatirimci_Gercek_Kisi", baglan);
                SqlCommand cmd_Tuzel = new SqlCommand("select Ad_Soyad from Yatirimci_Tuzel_Kisi", baglan);
                SqlDataReader dr_Gercek = cmd_Gercek.ExecuteReader();
                while (dr_Gercek.Read())
                {
                    comboBox4.Items.Add(dr_Gercek["Ad_Soyad"].ToString().TrimEnd());
                }
                baglan.Close();
                baglan.Open();
                SqlDataReader dr_Tuzel = cmd_Tuzel.ExecuteReader();
                while (dr_Tuzel.Read())
                {
                    comboBox4.Items.Add(dr_Tuzel["Ad_Soyad"].ToString().TrimEnd());
                }


                baglan.Close();



            }
            catch
            {
                MessageBox.Show("Veriler Yüklenirken Bir Hata Oluştu.", "Veritabanı Hatası", MessageBoxButtons.OK);

            }


        }
        private void projeGetir()
        {
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select * from proje_Yatirim where proje_ID="+proje_ID+"", baglan);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    p_Adi.Text = dr["proje_Adi"].ToString().TrimEnd();
                    comboBox4.SelectedIndex = comboBox4.FindString(dr["proje_Yatirimci"].ToString().TrimEnd());
                    dateTimePicker1.Text = dr["proje_Davet_Tarihi"].ToString().TrimEnd();
                    dateTimePicker2.Text = dr["proje_Gecerlilik_Tarihi"].ToString().TrimEnd();
                    dateTimePicker3.Text = dr["proje_Son_Sunum_Tarihi"].ToString().TrimEnd();
                    richTextBox1.Text = dr["proje_Adres"].ToString().TrimEnd();


                }
                baglan.Close();
            }
            catch
            {
                MessageBox.Show("Yatırım Getirilirken Hata Oldu");
                
            }
            baglan.Close();


        }

        private void yatirimGuncelle_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, 255, 255, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YatirimciEkle yeni_Yatirimci = new YatirimciEkle();
            yeni_Yatirimci.ShowDialog();
            yatirimciCombobox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("update proje_Yatirim set proje_Adi='"+p_Adi.Text+"',proje_Yatirimci='"+comboBox4.SelectedItem+"',proje_Davet_Tarihi='"+dateTimePicker1.Value.ToShortDateString()+"',proje_Gecerlilik_Tarihi='"+dateTimePicker2.Value.ToShortDateString()+"',proje_Son_Sunum_Tarihi='"+dateTimePicker3.Value.ToShortDateString()+"',proje_Adres='"+richTextBox1.Text+"' where proje_ID="+proje_ID+"", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
            }
            catch 
            {
                MessageBox.Show("Güncelleme Başarısız.");
                
            }

            baglan.Close();
            this.Close();
        }
    }
}
