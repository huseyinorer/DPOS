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
    public partial class YatirimciEkle : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");
        private string yapilacak_Islem = "";

        public YatirimciEkle()
        {
            InitializeComponent();
            button5.Enabled = false;
            radioButton1.Checked = true;
            yapilacak_Islem = "Kayit_Ekle";

        }

        public YatirimciEkle(string yatirimci_Tc, string yatirimci_Ad_Soyad, string yaritimci_Telefon, string yatirimci_Faks, string yatirimci_E_Posta, string yatirimci_Adres)
        {
            //Gerçek Kişi Güncelleme
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            maskedTextBox1.Enabled = false;//TC güncellenemez ->Primary Key
            maskedTextBox1.Text = yatirimci_Tc;
            textBox2.Text = yatirimci_Adres;
            textBox3.Text = yatirimci_Ad_Soyad;
            maskedTextBox2.Text = yaritimci_Telefon;
            maskedTextBox3.Text = yatirimci_Faks;
            textBox6.Text = yatirimci_E_Posta;
            yapilacak_Islem = "Gercek_Kayit_Guncelle";
        }

        public YatirimciEkle(string yatirimci_Tc, string yatirimci_Ad_Soyad, string yaritimci_Telefon, string yatirimci_Faks, string yatirimci_E_Posta, string yatirimci_Adres, string yatirimci_Vergi_Dairesi, string yatirimci_Vergi_No)
        {
            //Tüzel Kişi Güncelleme
            InitializeComponent();
            radioButton2.Checked = true;
            radioButton1.Enabled = false;
           radioButton2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            maskedTextBox1.Enabled = false; // Tc Güncellenemez -> Primary Key
            maskedTextBox4.Enabled = true;
            textBox5.Enabled = true;
            maskedTextBox1.Text = yatirimci_Tc;
            textBox2.Text = yatirimci_Adres;
            textBox3.Text = yatirimci_Ad_Soyad;
            maskedTextBox2.Text = yaritimci_Telefon;
            maskedTextBox3.Text = yatirimci_Faks;
            textBox6.Text = yatirimci_E_Posta;
            maskedTextBox4.Text = yatirimci_Vergi_No;
            textBox5.Text = yatirimci_Vergi_Dairesi;
            yapilacak_Islem = "Tuzel_Kayit_Guncelle";

        }

        private void YatirimciEkle_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, 255, 255, 255);
           
           
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = false;
            label5.Enabled = false;
           maskedTextBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = true;
            label5.Enabled = true;
            maskedTextBox4.Enabled = true;
            textBox5.Enabled = true;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";          
            textBox5.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox6.Text != "")
                {
                    object email = new System.Net.Mail.MailAddress(textBox6.Text);

                }
                if (maskedTextBox1.Text != "" &&
                    textBox2.Text != "" &&
                    textBox3.Text != "" &&
                    maskedTextBox2.Text != "" &&
                    !(!kontrol_veri_tekrari_yatirimci(maskedTextBox1.Text)||!kontrol_veri_tekrari_yatirimci(maskedTextBox4.Text)))
                {
                    baglan.Open();
                    SqlCommand komut;
                    if (radioButton1.Checked == true)
                        komut = new SqlCommand("insert into Yatirimci_Gercek_Kisi (Yatırımcı_TC,Ad_Soyad,Telefon,Faks,E_posta,Yatırımcı_Adres) Values ('" + maskedTextBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + maskedTextBox2.Text + "','" + maskedTextBox3.Text.ToString() + "','" + textBox6.Text + "','" + textBox2.Text + "')", baglan);
                    else
                        komut = new SqlCommand("insert into Yatirimci_Tuzel_Kisi (Yatırımcı_TC,Ad_Soyad,Telefon,Faks,E_posta,Yatırımcı_Adres,Vergi_Dairesi,Vergi_No) Values ('" + maskedTextBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + maskedTextBox2.Text + "','" + maskedTextBox3.Text.ToString() + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + maskedTextBox4.Text + "')", baglan);


                    int rowcount =  komut.ExecuteNonQuery();

                    if (rowcount != 0)
                    {
                        this.Close();
                        MessageBox.Show("Kayıt Eklendi", "Kayıt Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {

                    MessageBox.Show("-Aynı TC No veya Vergi No İle Daha Önce Kayıt Yapılmış Olabilir.\n-Form Eksik Doldurulmuş Olabilir.", "Kayıt Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
            catch
            {
                MessageBox.Show("Eksiksiz ve Doğru Bir Şekilde Doldurunuz.");
               

            }



            baglan.Close();
        }

        private bool kontrol_veri_tekrari_yatirimci(string deger) {


            try
            {
                baglan.Open();
                SqlCommand cmd;
              

                cmd = new SqlCommand("select  G.Yatırımcı_TC,T.Yatırımcı_TC from Yatirimci_Gercek_Kisi as G full join Yatirimci_Tuzel_Kisi as T on G.Yatırımcı_TC=T.Yatırımcı_TC where G.Yatırımcı_TC='"+deger+"' or T.Yatırımcı_TC='"+deger+"'", baglan);
                SqlDataReader dr = cmd.ExecuteReader();
                int dublicate_Count = 0;
                while (dr.Read())
                {

                    dublicate_Count++;


                }
                
                if (dublicate_Count > 0)
                {
                    
                    baglan.Close();
                    if (yapilacak_Islem == "Kayit_Ekle")
                        return false;
                    else if (yapilacak_Islem == "Gercek_Kayit_Guncelle" || yapilacak_Islem == "Tuzel_Kayit_Guncelle")
                        return true;
                        
                }
            }
            catch (Exception)
            {

                throw;
            }
            baglan.Close();
            return true;



        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {

            
            if (textBox6.Text != "")
            {
                object email = new System.Net.Mail.MailAddress(textBox6.Text);

            }
            if (maskedTextBox1.Text != "" &&
                textBox2.Text != "" &&
                textBox3.Text != "" &&
                maskedTextBox2.Text != "" &&
                !(!kontrol_veri_tekrari_yatirimci(maskedTextBox1.Text) || !kontrol_veri_tekrari_yatirimci(maskedTextBox4.Text)))
            {
                    baglan.Open();
                    string tedarikci_Guncelleme = "";
                    if(yapilacak_Islem == "Gercek_Kayit_Guncelle")
                        tedarikci_Guncelleme = "Update Yatirimci_Gercek_Kisi Set Yatırımcı_TC='" + maskedTextBox1.Text + "',Ad_Soyad='" + textBox3.Text + "',Telefon='" + maskedTextBox2.Text + "',Faks='" + maskedTextBox3.Text + "',E_posta='" + textBox6.Text + "',Yatırımcı_Adres='" + textBox2.Text + "' where Yatırımcı_TC='" + maskedTextBox1.Text + "'";
                    else
                        tedarikci_Guncelleme = "update Yatirimci_Tuzel_Kisi set Yatırımcı_TC='" + maskedTextBox1.Text + "',Ad_Soyad='" + textBox3.Text + "',Telefon='" + maskedTextBox2.Text + "',Faks='" + maskedTextBox3.Text + "',E_posta='" + textBox6.Text + "',Yatırımcı_Adres='" + textBox2.Text + "',Vergi_Dairesi='" + textBox5.Text + "',Vergi_No='" + maskedTextBox4.Text + "' where Yatırımcı_TC='" + maskedTextBox1.Text + "'";


                    SqlCommand cmd = new SqlCommand(tedarikci_Guncelleme, baglan);
                       int row_Update= cmd.ExecuteNonQuery();

                    if (row_Update>0)
                          MessageBox.Show("Güncelleme Tamamlandı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Zorunlu Alanları Doldurunuz.", "Form Eksik.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            baglan.Close();
            }
            catch 
            {

                MessageBox.Show("-Aynı TC No veya Vergi No İle Daha Önce Kayıt Yapılmış Olabilir.\n-Form Eksik Doldurulmuş Olabilir.", "Kayıt Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            this.Close();
        }

    }
    }

