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
    public partial class Sartname_Duzenle : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");

        public Sartname_Duzenle()
        {
            InitializeComponent();
        }
        int projeID;
        string makineADI;
        string Birim;
        string Miktar;
        public Sartname_Duzenle(int proje_id,string makineAdi,string birim,string miktar)
        {
            InitializeComponent();
            projeID= proje_id;
            makineADI = makineAdi;
            Birim = birim;
            Miktar = miktar;
           
        }

        private void Sartname_Duzenle_Load(object sender, EventArgs e)
        {
            sartnameGetir();
            groupBox1.Text = makineADI;
            richTextBox1.Text = sartname_teknikOzellik;


        }
        string sartname_teknikOzellik;
        private void sartnameGetir()
        {

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select * from proje_Sartname where proje_ID="+projeID+" and sartname_makineAdi='"+makineADI+"'", baglan);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    sartname_teknikOzellik = dr["sartname_makineOzellik"].ToString();
                }
                baglan.Close();
            }
            catch 
            {

                MessageBox.Show("Bu Makine Sartname Tablosundan Getirilemedi.");
            }
            baglan.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("update proje_Sartname set sartname_makineOzellik='"+richTextBox1.Text.Trim()+"', sartname_makineBirim='"+Birim+"',sartname_makineMiktar='"+Miktar+"'  where proje_ID="+projeID+" and sartname_makineAdi='"+makineADI+"'",baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();

            }
            catch 
            {

                MessageBox.Show("Makine Sartname Düzenlenemedi.");
            }
            baglan.Close();
            this.Close();
        }
    }
}
