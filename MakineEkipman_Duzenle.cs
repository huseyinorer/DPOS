using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace impostemalı2
{

    public partial class MakineEkipman_Duzenle : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");

        //Formda PlaceHolder Olarak Çalışır
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public MakineEkipman_Duzenle()
        {
            InitializeComponent();
        }

        int proje_ID;
        string makine_Adi;
        int tedarikci_Sayisi;
        public MakineEkipman_Duzenle(int projeID,string makineAdi,int tedarikciSayisi)
        {
            InitializeComponent();
            proje_ID = projeID;
            makine_Adi = makineAdi;
            tedarikci_Sayisi = tedarikciSayisi;
        }

        private void MakineEkipman_Duzenle_Load(object sender, EventArgs e)
        {
            marka_model_Combobox();
            if (tedarikci_Sayisi == 1)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }else if(tedarikci_Sayisi==3)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
            }

            SendMessage(textBox4.Handle, EM_SETCUEBANNER, 0, "Yeni Marka");
            SendMessage(textBox5.Handle, EM_SETCUEBANNER, 0, "Yeni Model");
            SendMessage(textBox9.Handle, EM_SETCUEBANNER, 0, "Yeni Marka");
            SendMessage(textBox8.Handle, EM_SETCUEBANNER, 0, "Yeni Model");
            SendMessage(textBox14.Handle, EM_SETCUEBANNER, 0, "Yeni Marka");
            SendMessage(textBox13.Handle, EM_SETCUEBANNER, 0, "Yeni Model");

            makineVerileriGetir();
            formDoldur();
            List<GroupBox> gb = new List<GroupBox>();
            gb.Add(groupBox1);
            gb.Add(groupBox2);
            gb.Add(groupBox3);


            for (int i = 0; i < tedarikci_Sayisi; i++)
            {
              tedarikciGetir(mB[i].tedarikciID);
                gb[i].Text = tedarikciAdı[i];
                
            }

            


        }
        
        private void markaEkle(string textbox)
        {
            if(textbox=="")
            {
                MessageBox.Show("Boş Bırakmayınız.");
                return;

            }

            try
            {
                bool check = true;
                baglan.Open();
                SqlCommand comd = new SqlCommand("select marka from Marka", baglan);
                SqlDataReader dr = comd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["marka"].ToString() == textbox)
                        check = false;
                    else
                        check = true;

                }
                baglan.Close();

                if (check == true)
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("insert into Marka (marka) values ('" + textbox+ "')", baglan);
                    cmd.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                    MessageBox.Show("Bu Marka Zaten Bulunmakta.");
            }
            catch
            {
                MessageBox.Show("Marka Eklenemedi");

            }

        }
        private void modelEkle(string textbox)
        {


            if (textbox == "")
            {
                MessageBox.Show("Boş Bırakmayınız.");
                return;

            }


            try
            {
                bool check = true;
                baglan.Open();
                SqlCommand comd = new SqlCommand("select model from Model", baglan);
                SqlDataReader dr = comd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["model"].ToString() == textbox)
                        check = false;
                    else
                        check = true;

                }
                baglan.Close();
                if (check == true)
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("insert into Model (model) values ('" + textbox+ "')", baglan);
                    cmd.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                    MessageBox.Show("Bu Model Zaten Bulunmakta.");
            }
            catch
            {
                MessageBox.Show("Model Eklenemedi");

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            markaEkle(textBox4.Text);
            marka_model_Combobox();
            textBox4.Text = "";
            SendMessage(textBox4.Handle, EM_SETCUEBANNER, 0, "Yeni Marka");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            modelEkle(textBox5.Text);
            marka_model_Combobox();
            textBox5.Text = "";
            SendMessage(textBox5.Handle, EM_SETCUEBANNER, 0, "Yeni Model");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            markaEkle(textBox9.Text);
            marka_model_Combobox();
            textBox9.Text = "";
            SendMessage(textBox9.Handle, EM_SETCUEBANNER, 0, "Yeni Marka");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            modelEkle(textBox8.Text);
            marka_model_Combobox();
            textBox8.Text = "";
            SendMessage(textBox8.Handle, EM_SETCUEBANNER, 0, "Yeni Model");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            markaEkle(textBox14.Text);
            marka_model_Combobox();
            textBox14.Text = "";
            SendMessage(textBox14.Handle, EM_SETCUEBANNER, 0, "Yeni Marka");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            modelEkle(textBox13.Text);
            marka_model_Combobox();
            textBox13.Text = "";
            SendMessage(textBox13.Handle, EM_SETCUEBANNER, 0, "Yeni Model");
        }

        private void marka_model_Combobox()
        {
            comboBox2.Items.Clear();
            comboBox7.Items.Clear();
            comboBox10.Items.Clear();

            comboBox3.Items.Clear();
            comboBox6.Items.Clear();
            comboBox9.Items.Clear();

            try
            { 
                ///***MARKA****//////

                baglan.Open();
                
                string marka = "select marka from  Marka";
                SqlCommand kmt = new SqlCommand(marka, baglan);


                SqlDataReader dr1 = kmt.ExecuteReader();
                while (dr1.Read())
                {
                    comboBox2.Items.Add(dr1["marka"].ToString());

                }
                baglan.Close();


                baglan.Open();
                SqlCommand kmt2 = new SqlCommand(marka, baglan);
                SqlDataReader dr2 = kmt2.ExecuteReader();
                while (dr2.Read())
                {
                    comboBox7.Items.Add(dr2["marka"].ToString());

                }
                baglan.Close();

                baglan.Open();
                SqlCommand kmt3 = new SqlCommand(marka, baglan);
                SqlDataReader dr3 = kmt3.ExecuteReader();
                while (dr3.Read())
                {
                    comboBox10.Items.Add(dr3["marka"].ToString());

                }

                baglan.Close();

                ///***Model***///////
                baglan.Open();

                string model = "select model from  Model";
                SqlCommand kmt4 = new SqlCommand(model, baglan);
                SqlDataReader dr4 = kmt4.ExecuteReader();
                while (dr4.Read())
                {
                    comboBox3.Items.Add(dr4["model"].ToString());

                }

                baglan.Close();

                baglan.Open();
                SqlCommand kmt5 = new SqlCommand(model, baglan);
                SqlDataReader dr5 = kmt5.ExecuteReader();
                while (dr5.Read())
                {
                    comboBox6.Items.Add(dr5["model"].ToString());

                }

                baglan.Close();

                baglan.Open();
                SqlCommand kmt6 = new SqlCommand(model, baglan);
                SqlDataReader dr6 = kmt6.ExecuteReader();
                while (dr6.Read())
                {
                    comboBox9.Items.Add(dr6["model"].ToString());

                }

                baglan.Close();

            }
            catch
            {

                MessageBox.Show("Marka ve Model Veritabanı Hatası");
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            int birimFiyat, miktar;
            if (int.TryParse(textBox2.Text, out birimFiyat) && int.TryParse(textBox1.Text, out miktar))
            {
                textBox3.Text = (birimFiyat * miktar).ToString();

            }
            else
                MessageBox.Show("Birim Fiyat  ve Miktar Sayı Olmak Zorunda.");
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            int birimFiyat, miktar;
            if (int.TryParse(textBox11.Text, out birimFiyat) && int.TryParse(textBox1.Text, out miktar))
            {
                textBox10.Text = (birimFiyat * miktar).ToString();

            }
            else
                MessageBox.Show("Birim Fiyat  ve Miktar Sayı Olmak Zorunda.");
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            int birimFiyat, miktar;
            if (int.TryParse(textBox16.Text, out birimFiyat) && int.TryParse(textBox1.Text, out miktar))
            {
                textBox15.Text = (birimFiyat * miktar).ToString();

            }
            else
                MessageBox.Show("Birim Fiyat  ve Miktar Sayı Olmak Zorunda.");
        }

        struct makineBilgi
        {
          public  int tedarikciID;
          public  string makineOzellik;
          public  string marka;
          public  string model;
          public  string mensei;
          public  string birimFiyat;
          public  string toplamFiyat;
        };
        List<string> tedarikciAdı = new List<string>();

        private void tedarikciGetir(int tedarikciID)
        {

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select Tedarikci_Ad from Tedarikciler where Tedarikci_ID="+tedarikciID+"", baglan);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tedarikciAdı.Add(dr["Tedarikci_Ad"].ToString().Trim());
                }
                baglan.Close();
            }
            catch 
            {
                MessageBox.Show("Tedarikci Verileri Alınamadı");
                
            }

            baglan.Close();

        }
        string miktar;
        string birim;
        makineBilgi[] mB;
        private void makineVerileriGetir()
        {
            
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select* from proje_Makine_Ekipman where proje_ID="+proje_ID+" and proje_MakineEkipman_Adi='"+makine_Adi+"'", baglan);
                SqlDataReader dr = cmd.ExecuteReader();
                mB = new makineBilgi[tedarikci_Sayisi];
                int count = 0;
                while (dr.Read())
                {
                    mB[count].tedarikciID = Convert.ToInt32(dr["proje_MakineEkipman_Tedarikci_ID"].ToString().Trim());
                    mB[count].makineOzellik = dr["proje_MakineEkipman_TeknikOzellik"].ToString().Trim();
                    mB[count].marka=dr["proje_MakineEkipman_Marka"].ToString().Trim();
                    mB[count].model=dr["proje_MakineEkipman_Model"].ToString().Trim();
                    mB[count].mensei=dr["proje_MakineEkipman_Mensei"].ToString().Trim();
                    mB[count].birimFiyat=dr["proje_MakineEkipman_BirimFiyat"].ToString().Trim();
                    mB[count].toplamFiyat=dr["proje_MakineEkipman_ToplamFiyat"].ToString().Trim();
                    birim = dr["proje_MakineEkipman_Birimi"].ToString().Trim();
                    miktar = dr["proje_MakineEkipman_Miktar"].ToString().Trim();
                    count++;
                }

                baglan.Close();
                
            }
            catch 
            {
                
                MessageBox.Show("Makine Özellikleri Getirilemedi.");
            }

            baglan.Close();

        }
        private void formDoldur()
        {
            if (tedarikci_Sayisi == 1)
            {
                comboBox5.SelectedIndex = comboBox5.FindString(birim);
                textBox1.Text = miktar;

                comboBox2.SelectedIndex = comboBox2.FindString(mB[0].marka);
                comboBox3.SelectedIndex = comboBox3.FindString(mB[0].model);
                comboBox4.SelectedIndex = comboBox4.FindString(mB[0].mensei);

                textBox2.Text = mB[0].birimFiyat;
                textBox3.Text = mB[0].toplamFiyat;

                richTextBox1.Text = mB[0].makineOzellik;




            }
            else if(tedarikci_Sayisi==3)
            {
                comboBox5.SelectedIndex = comboBox5.FindString(birim);
                textBox1.Text = miktar;


                //tedarikci 1
                comboBox2.SelectedIndex = comboBox2.FindString(mB[0].marka);
                comboBox3.SelectedIndex = comboBox3.FindString(mB[0].model);
                comboBox4.SelectedIndex = comboBox4.FindString(mB[0].mensei);

                textBox2.Text = mB[0].birimFiyat;
                textBox3.Text = mB[0].toplamFiyat;
                richTextBox1.Text = mB[0].makineOzellik;


                //tedarikci 2
                comboBox7.SelectedIndex = comboBox7.FindString(mB[1].marka);
                comboBox6.SelectedIndex = comboBox6.FindString(mB[1].model);
                comboBox1.SelectedIndex = comboBox1.FindString(mB[1].mensei);

                textBox11.Text = mB[1].birimFiyat;
                textBox10.Text = mB[1].toplamFiyat;
                richTextBox2.Text = mB[1].makineOzellik;



                //tedarikçi 3
                comboBox10.SelectedIndex = comboBox10.FindString(mB[2].marka);
                comboBox9.SelectedIndex = comboBox9.FindString(mB[2].model);
                comboBox8.SelectedIndex = comboBox8.FindString(mB[2].mensei);

                textBox16.Text = mB[2].birimFiyat;
                textBox15.Text = mB[2].toplamFiyat;
                richTextBox3.Text = mB[2].makineOzellik;
                

            }





        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //makine Ekipman tablosundan siler
                baglan.Open();
                SqlCommand cmd = new SqlCommand("delete from proje_Makine_Ekipman where proje_ID=" + proje_ID + " and proje_MakineEkipman_Adi='" + makine_Adi + "'", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();

                //sartname tablosundan siler
                baglan.Open();
                SqlCommand cmd2 = new SqlCommand("delete from proje_Sartname where proje_ID="+proje_ID+" and sartname_makineAdi='"+makine_Adi+"'", baglan);
                cmd2.ExecuteNonQuery();
                baglan.Close();
            }
            catch 
            {
                MessageBox.Show(makine_Adi + " Kaydı Silinemedi");
                
                
            }

            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (tedarikci_Sayisi == 1)
            {
                //birim,miktar
                if (textBox6.Text != "")
                    birim = textBox6.Text;
                else
                    birim = comboBox5.SelectedItem.ToString();
            
                miktar = textBox1.Text;


                //tedarikci 1
                mB[0].marka = comboBox2.SelectedItem.ToString();
                mB[0].model = comboBox3.SelectedItem.ToString();
                mB[0].mensei = comboBox4.SelectedItem.ToString();

                mB[0].birimFiyat = textBox2.Text;
                mB[0].toplamFiyat = textBox3.Text;
                mB[0].makineOzellik = richTextBox1.Text;




            }
            else if (tedarikci_Sayisi == 3)
            {
                //birim,miktar
                //birim,miktar
                if (textBox6.Text != "")
                    birim = textBox6.Text;
                else
                    birim = comboBox5.SelectedItem.ToString();

                miktar = textBox1.Text;
                


                //tedarikci 1
                mB[0].marka = comboBox2.SelectedItem.ToString();
                mB[0].model = comboBox3.SelectedItem.ToString();
                mB[0].mensei = comboBox4.SelectedItem.ToString();

                mB[0].birimFiyat=textBox2.Text;
                mB[0].toplamFiyat=textBox3.Text;
                mB[0].makineOzellik=richTextBox1.Text;


                //tedarikci 2
                mB[1].marka = comboBox7.SelectedItem.ToString();
                mB[1].model = comboBox6.SelectedItem.ToString();
                mB[1].mensei = comboBox1.SelectedItem.ToString();

                mB[1].birimFiyat=textBox11.Text;
                mB[1].toplamFiyat=textBox10.Text;
                mB[1].makineOzellik=richTextBox2.Text;



                //tedarikçi 3
                mB[2].marka = comboBox10.SelectedItem.ToString();
                mB[2].model = comboBox9.SelectedItem.ToString();
                mB[2].mensei = comboBox8.SelectedItem.ToString();

                mB[2].birimFiyat=textBox16.Text;
                mB[2].toplamFiyat=textBox15.Text;
                mB[2].makineOzellik=richTextBox3.Text;


            }


            for (int i = 0; i < tedarikci_Sayisi; i++)
            {
                guncelle(proje_ID,mB[i].tedarikciID,makine_Adi,i);
            }
           
            Sartname_Duzenle sD = new Sartname_Duzenle(proje_ID, makine_Adi,birim,miktar);
            sD.ShowDialog();
            this.Close();
        }

        private void guncelle(int proje_id,int tedarikciID,string makineAdi,int index)
        {


            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("update proje_Makine_Ekipman set proje_MakineEkipman_TeknikOzellik='"+mB[index].makineOzellik+ "', proje_MakineEkipman_Marka='" + mB[index].marka+ "',proje_MakineEkipman_Model='" + mB[index].model+ "',proje_MakineEkipman_Mensei='" + mB[index].mensei+ "',proje_MakineEkipman_Birimi='" + birim+ "',proje_MakineEkipman_Miktar='" + miktar+ "',proje_MakineEkipman_BirimFiyat='" + mB[index].birimFiyat+ "',proje_MakineEkipman_ToplamFiyat='" + mB[index].toplamFiyat+ "'  where proje_ID=" + proje_id+" and proje_MakineEkipman_Adi='"+makineAdi+"' and proje_MakineEkipman_Tedarikci_ID="+tedarikciID+"", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();

            }
            catch (Exception)
            {


            }
            baglan.Close();
           


        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if(comboBox5.SelectedIndex!=-1)
                comboBox5.SelectedIndex = -1;
        }
    }
}
