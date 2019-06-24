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
    public partial class HizmetAlimi : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");

        public HizmetAlimi()
        {
            InitializeComponent();
        }

        string Tedbir, Destek, Ad;
        int Proje_ID;

        public HizmetAlimi(string tedbir, string destek, int proje_ID, string ad)
        {
            InitializeComponent();
            Tedbir = tedbir;
            Destek = destek;
            Ad = ad;
            Proje_ID = proje_ID;


        }
        private void HizmetAlimi_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, 255, 255, 255);
            label1.Text = Tedbir + " / " + Ad + " İçin Hizmet Alımı";
            tedarikcilerYukle();
            groupBox2.Enabled = false;
            gridYukle();

        }

        List<int> tedarikciID = new List<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            { listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        int tedarikciIndex;
        private bool kayitDurum = true;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       

        private bool ayniKayitKontrol(int projeID,string hizmetAdi,int tedarikciSayisi)
        {

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select count(*) as Sayi from proje_HizmetAlimi where proje_HizmetAdi='"+hizmetAdi+"' and proje_ID="+projeID+"", baglan);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if(Convert.ToInt32(dr["Sayi"].ToString())==tedarikciSayisi)
                    {
                      //  MessageBox.Show(dr["Sayi"].ToString());
                        baglan.Close();
                        return false;

                    }

                }
                baglan.Close();


            }
            catch (Exception)
            {

                MessageBox.Show("veritabanı Hatası");
            }

            baglan.Close();
            return true;

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(tedarikciIndex==0)
            {
                int fiyat;
                if(richTextBox1.Text!="" && int.TryParse(textBox2.Text,out fiyat))
                {
                        hizmetAlimiEkle(Proje_ID, listBox1.SelectedItem.ToString(), richTextBox1.Text, textBox2.Text);
                    kayitDurum = false;
                    //MessageBox.Show(richTextBox1.Text);
                    tedarikciIndex++;
                    if (tedarikciIndex < tedarikciID.Count)
                        groupBox2.Text = tedarikciAdı[tedarikciIndex];
                    else
                    {
                        groupBox2.Text = "Şartname Özellik";
                        button5.Image = Properties.Resources.done;


                    }
                }




            }
            else if(tedarikciIndex>0 && tedarikciIndex<tedarikciID.Count)
            {

                int fiyat;
                if (richTextBox1.Text != "" && int.TryParse(textBox2.Text, out fiyat))
                {
                      hizmetAlimiEkle(Proje_ID, listBox1.SelectedItem.ToString(), richTextBox1.Text, textBox2.Text);
                    kayitDurum = false;
                 //   MessageBox.Show(richTextBox1.Text);
                    tedarikciIndex++;
                    if (tedarikciIndex < tedarikciID.Count)
                        groupBox2.Text = tedarikciAdı[tedarikciIndex];
                    else
                    {

                        
                        groupBox2.Text = "Şartname Özellik";
                        button5.Image = Properties.Resources.done;


                    }
                }
                
             }
            else if (tedarikciIndex == tedarikciID.Count)
            {
                if(!ayniKayitKontrol(Proje_ID,listBox1.SelectedItem.ToString(),tedarikciID.Count))
                {
                    hizmetAlimiSartname(richTextBox1.Text);
                    MessageBox.Show("Hizmet Alımı ve Şartnamesi Başarı İle Eklenmiştir");


                }

                groupBox2.Text = "Şartname Özellik";
                button5.Image = Properties.Resources.next1;
                groupBox2.Enabled = false;
                kayitDurum = true;
                groupBox1.Enabled = true;
                gridYukle();
                //MessageBox.Show(richTextBox1.Text);
                
                

            }
        }

        List<string> hizmetQuery;
        private void hizmetAlimiEkle(int projeID,string hizmetAdi,string hizmetOzellik,string hizmetFiyat)
        {
            hizmetQuery.Add("insert into proje_HizmetAlimi (proje_ID,proje_HizmetAdi,proje_HizmetOzellik,proje_HizmetFiyat) values ("+projeID+",'"+hizmetAdi+"','"+hizmetOzellik+"','"+hizmetFiyat+"') ");

            if(hizmetQuery.Count==tedarikciID.Count)
            { 
            try
            {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand();
                    if (hizmetQuery.Count == 1)
                        cmd = new SqlCommand("begin tran "+hizmetQuery[0]+"; if (select COUNT(*) from proje_HizmetAlimi where proje_ID="+Proje_ID+" and proje_HizmetAdi='"+hizmetAdi+"')="+tedarikciID.Count+" commit tran; else rollback tran", baglan);
                    else if (hizmetQuery.Count == 3)
                        cmd = new SqlCommand("begin tran "+hizmetQuery[0]+";"+hizmetQuery[1]+";"+hizmetQuery[2]+ "; if (select COUNT(*) from proje_HizmetAlimi where proje_ID=" + Proje_ID + " and proje_HizmetAdi='" + hizmetAdi + "')=" + tedarikciID.Count + " commit tran; else rollback tran", baglan);

                    cmd.ExecuteNonQuery();
                    baglan.Close();

            }
            catch 
            {
                    MessageBox.Show("Hizmet Alımı Eklenemedi");
            }

            }
            baglan.Close();
        }
        List<string> tedarikciAdı = new List<string>();

        private void hizmetAlimiSartname(string sartnameOzellik)
        {
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("insert into proje_HizmetAlimiSartname (projeID,sartname_HizmetAdi,sartname_HizmetOzellik) values ("+Proje_ID+",'"+listBox1.SelectedItem.ToString()+"','"+sartnameOzellik+"')", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();


            }
            catch 
            {
                MessageBox.Show("Veritabanı Hatası");
                
            }


            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem.ToString());
            listBox1.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && kayitDurum == true && ayniKayitKontrol(Proje_ID,listBox1.SelectedItem.ToString(),tedarikciID.Count))
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                tedarikciIndex = 0;
                groupBox2.Text = tedarikciAdı[tedarikciIndex] + " İçin Hizmet Özellikleri";
                hizmetQuery = new List<string>();



            }
            else
                MessageBox.Show("Aynı Hizmet Daha Önce Eklenmiş Olabilir veya Diğer Hizmet Alımı Kaydı Tamamlanmamış Olabilir.");
        }

        private void tedarikcilerYukle()
        {
            tedarikciID.Clear();
            tedarikciAdı.Clear();

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select Tedarikci_Ad,Tedarikci_ID from Tedarikciler where Tedarikci_ID  in( select tedarikci_ID from proje_Tedarikciler where proje_ID not in (select  proje_ID from proje_HizmetAlimi ) and proje_ID=" + Proje_ID+ ")", baglan);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tedarikciAdı.Add(dr["Tedarikci_Ad"].ToString());
                    tedarikciID.Add(Convert.ToInt32(dr["Tedarikci_ID"]));
                    
                }

                baglan.Close();
            }
            catch
            {

                MessageBox.Show("Database Hatası Tedarikcilerder");
            }

            baglan.Close();
        }

        private void gridYukle()
        {
            try
            {

                baglan.Open();
                SqlCommand kmt = new SqlCommand(" select proje_ID, proje_HizmetAdi,COUNT(proje_HizmetAdi) as TedarikciSayisi from proje_HizmetAlimi where proje_ID="+Proje_ID+" group by proje_HizmetAdi ,proje_ID,proje_HizmetAdi", baglan);                
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglan.Close();

            }
            catch
            {
                MessageBox.Show("Grid Yüklenemedi.");

            }


        }
    }
}
