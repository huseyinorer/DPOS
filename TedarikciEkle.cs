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
    public partial class TedarikciEkle : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");
        string yapilacak_Islem = "";
        private int tedarikci_ID; 

        public TedarikciEkle()
        {
            InitializeComponent();
            button5.Enabled = false;
            yapilacak_Islem = "Kayit_Ekle";
        }
        public TedarikciEkle(int tedarikciID,string tedarikci_Ad, string tedarikci_Adres, string tedarikci_Vergi_no, string tedarikci_Vergi_Dairesi, string tedarikci_Ticari_Sicil_no, string tedarikci_Telefon, string tedarikci_Faks, string tedarikci_E_Posta)
        {
            InitializeComponent();
            tedarikci_ID = tedarikciID;
            textBox1.Text = tedarikci_Ad;
            textBox2.Text = tedarikci_Adres;
            maskedTextBox1.Text = tedarikci_Vergi_no;
            textBox4.Text = tedarikci_Vergi_Dairesi;
            textBox5.Text = tedarikci_Ticari_Sicil_no;
            maskedTextBox2.Text = tedarikci_Telefon;
            maskedTextBox3.Text = tedarikci_Faks;
            textBox6.Text = tedarikci_E_Posta;
            button1.Enabled = false;
            button2.Enabled = false;
            yapilacak_Islem = "Kayit_Guncelle";

        }

        private void TedarikciEkle_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, 255, 255,255);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
           
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            



        }

        private void button2_Click(object sender, EventArgs e)
        {


           

            try
            {
                if (textBox6.Text != "")
                {
                    object email = new System.Net.Mail.MailAddress(textBox6.Text);

                }






                if (textBox1.Text != "" &&
                    textBox2.Text != "" &&
                    maskedTextBox1.Text != "" &&
                    textBox4.Text != "" &&                    
                    maskedTextBox2.Text != "" && 
                   ! (!kontrol_veri_tekrari_tedarikci(maskedTextBox1.Text) || !kontrol_veri_tekrari_tedarikci(textBox5.Text)))
                {
                    baglan.Open();
                    
                    SqlCommand komut = new SqlCommand("insert into Tedarikciler (Tedarikci_Ad,Tedarikci_Adres,Tedarikci_Vergi_No,Tedarikci_Vergi_Dairesi,Tedarikci_Ticari_Sicil_No,Tedarikci_Tel,Tedarikci_Faks,Tedarikci_E_Posta) Values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + maskedTextBox1.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + maskedTextBox2.Text.ToString() + "','" + maskedTextBox3.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglan);
                    
                    int rowcount= komut.ExecuteNonQuery(); 

                    if (rowcount!=0)
                    { 
                    this.Close();
                    MessageBox.Show("Kayıt Eklendi");
                    }
                }
                else
                {

                    MessageBox.Show("-Aynı Vergi No veya Ticari Sicil No İle Daha Önce Kayıt Yapılmış Olabilir.\n-Form Eksik Doldurulmuş Olabilir.", "Kayıt Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            } 
            catch
            {
                MessageBox.Show("Eksiksiz ve Doğru Bir Şekilde Doldurunuz.");
                textBox6.Text = "";

            }

            

            baglan.Close();





          
        }

        private Boolean kontrol_veri_tekrari_tedarikci(string deger)
        {

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select Tedarikci_Vergi_No,Tedarikci_Ticari_Sicil_No from Tedarikciler where Tedarikci_Vergi_No='" + deger + "' or Tedarikci_Ticari_Sicil_No='" +deger+ "'",baglan);
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
                    else if (yapilacak_Islem == "Kayit_Guncelle")
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
                    textBox1.Text != "" &&
                    textBox2.Text != "" &&
                    maskedTextBox2.Text != "" &&
                    textBox5.Text!="" &&
                    !(!kontrol_veri_tekrari_tedarikci(maskedTextBox1.Text) || !kontrol_veri_tekrari_tedarikci(textBox5.Text)))
                {
                    baglan.Open();
                   
                    SqlCommand cmd = new SqlCommand("Update Tedarikciler Set Tedarikci_Ad='"+textBox1.Text+"',Tedarikci_Adres='"+textBox2.Text+"',Tedarikci_Vergi_No='"+maskedTextBox1.Text+"',Tedarikci_Vergi_Dairesi='"+textBox4.Text+"',Tedarikci_Ticari_Sicil_No='"+textBox5.Text+"',Tedarikci_Tel='"+maskedTextBox2.Text+"',Tedarikci_Faks='"+maskedTextBox3.Text+"',Tedarikci_E_Posta='"+textBox6.Text+"' where Tedarikci_ID="+tedarikci_ID+"", baglan);
                    int row_Update = cmd.ExecuteNonQuery();

                    if (row_Update > 0)
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
