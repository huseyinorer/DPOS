using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using wordeaktar = Microsoft.Office.Interop.Word;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;

namespace impostemalı2
{
    public partial class TKDK : Form
    {
        
        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");
      
    


        public TKDK()
        {
            InitializeComponent();
        }

        string Yetki;
        public TKDK(string yetki)
        {
            InitializeComponent();
            Yetki = yetki;
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            yatirimci_Combobox_Veri_Yukle();
            yatırımlar_Combobox_Veri_Yukle();
            gridViewiYukle();
           
        }
      
       
       
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "101")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("101-1 : Süt Üreten Tarımsal İşletmeler");
                comboBox3.Items.Add("101-2 : Kırmızı Et Üreten Tarımsal İşletmeler");
                comboBox3.Items.Add("101-3 : Kanatlı Et Üreten Tarımsal İşletmeler");
                comboBox3.Items.Add("101-4 : Yumurta Üreten Tarımsal İşletmeler");


            }
            else if (comboBox1.SelectedItem.ToString() == "103")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("103-1 : Süt Ve Süt Ürünlerinin İşlenmesi Ve Pazarlanması");
                comboBox3.Items.Add("103-2 : Kırmızı Et Ve Et Ürünlerinin İşlenmesi ve Pazarlanması");
                comboBox3.Items.Add("103-3 : Kanatlı Eti Ve Et İşlenmesi Ve Pazarlanması");
                comboBox3.Items.Add("103-4 : Su Ürünlerinin İşlenmesi ve Pazarlanması");
                comboBox3.Items.Add("103-5 : Meyve Ve Sebze İşlenmesi ve Pazarlanması");


            }else if(comboBox1.SelectedItem.ToString()=="302")
            {

                comboBox3.Items.Clear();
                comboBox3.Items.Add("302-1 : Bitkisel Üretim Çeşitlendirilmesi Ve Bitkisel Ürünlerin İşlenmesi Ve Pazarlanması");
                comboBox3.Items.Add("302-2 : Arıcılık Ve Arı Ürünlerinin Üretimi, İşlenmesi Ve Pazarlanması");
                comboBox3.Items.Add("302-3 : ZanaatKarlık Ve Yerel Ürün İşletmeleri");
                comboBox3.Items.Add("302-4 : Kırsal Turizm Ve Rekreasyon Faaliyetleri");
                comboBox3.Items.Add("302-5 : Su Ürünleri Yetiştiriciliği");
                comboBox3.Items.Add("302-6 : Makine Parkları");
                comboBox3.Items.Add("302-7 : Yenilenebilir Enerji Yatırımları");

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {


                radioButtons_CheckedChanged(1);
                tedarikci_Combobox_Veri_Yukle();


            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    MessageBox.Show("Tedarikçi Eklenecek Yatırımcıyı Seçiniz.");
                    radioButton1.Checked = false;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


            if (comboBox2.SelectedItem != null)
            {


                radioButtons_CheckedChanged(3);
                tedarikci_Combobox_Veri_Yukle();


            }
            else
            {
                if (radioButton2.Checked == true) { 
                MessageBox.Show("Tedarikçi Eklenecek Yatırımcıyı Seçiniz.");
                radioButton2.Checked = false;
                }
            }
        }

        List<ComboBox> combolist_Tedarikci = new List<ComboBox>();
        List<int> combolist_Tedarikci_ID = new List<int>();
        List<DateTimePicker> dateList = new List<DateTimePicker>();
        private void radioButtons_CheckedChanged(int tedarikciSayisi)
        {
            combolist_Tedarikci.Clear();
            dateList.Clear();
           groupBox1.Controls.Clear();
            int Y_Combobox = 28;

            for (int i = 0; i < tedarikciSayisi; i++)
            {
                Label lbl = new Label();
                lbl.Text = "Tedarikçi-"+(i+1)+" : ";
                lbl.Size = new Size(60, 21);
                lbl.Location = new Point(10, Y_Combobox+5);
                this.groupBox1.Controls.Add(lbl);
            

                ComboBox combo = new ComboBox();
                combo.Size = new Size(150, 21);
                combo.Location = new Point(80, Y_Combobox);
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combolist_Tedarikci.Add(combo);
                this.groupBox1.Controls.Add(combo);

               

                DateTimePicker date_time = new DateTimePicker();
                date_time.Location = new Point(240, Y_Combobox);
                date_time.Format = DateTimePickerFormat.Short;
                date_time.Size = new Size(100, 24);
               // date_time.ValueChanged += new EventHandler(DateTimeValueChanged);
                date_time.Tag = i;
                dateList.Add(date_time);
                this.groupBox1.Controls.Add(date_time);

                
                Y_Combobox += 27;



            }

            Button btn_Yeni_Tedarikci = new Button();
            btn_Yeni_Tedarikci.Size = new Size(80, 24);
            btn_Yeni_Tedarikci.Location = new Point(285, 0);
            btn_Yeni_Tedarikci.Image = Properties.Resources.addnewdatasource_16x16;
            btn_Yeni_Tedarikci.Text = "Yeni Ekle";
            btn_Yeni_Tedarikci.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Yeni_Tedarikci.Click += (s, e) => {
                TedarikciEkle yeni_Ekle = new TedarikciEkle();
                yeni_Ekle.ShowDialog();
                tedarikci_Combobox_Veri_Yukle();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                groupBox1.Controls.Clear();
            };

            this.groupBox1.Controls.Add(btn_Yeni_Tedarikci);

        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YatirimciEkle yeni_Yatirimci = new YatirimciEkle();
            yeni_Yatirimci.ShowDialog();
            yatirimci_Combobox_Veri_Yukle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 yeni = new Form3(Yetki);
            yeni.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void yatirimci_Combobox_Veri_Yukle()
        {
            comboBox4.Items.Clear();

            try
            {
                baglan.Open();
                SqlCommand cmd_Gercek = new SqlCommand("select Ad_Soyad from Yatirimci_Gercek_Kisi",baglan);
                SqlCommand cmd_Tuzel = new SqlCommand("select Ad_Soyad from Yatirimci_Tuzel_Kisi", baglan);
                SqlDataReader dr_Gercek = cmd_Gercek.ExecuteReader();
                while (dr_Gercek.Read())
                {
                    comboBox4.Items.Add(dr_Gercek["Ad_Soyad"].ToString());
                }
                baglan.Close();
                baglan.Open();
                SqlDataReader dr_Tuzel = cmd_Tuzel.ExecuteReader();
                while (dr_Tuzel.Read())
                {
                    comboBox4.Items.Add(dr_Tuzel["Ad_Soyad"].ToString());
                }


                baglan.Close();



            }
            catch 
            {
                MessageBox.Show("Veriler Yüklenirken Bir Hata Oluştu.", "Veritabanı Hatası", MessageBoxButtons.OK);
                
            }


        }

        private void tedarikci_Combobox_Veri_Yukle()
        {

         //   combolist_Tedarikci.Clear();

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select Tedarikci_ID,Tedarikci_Ad from Tedarikciler", baglan);
               
                SqlDataReader dr = cmd.ExecuteReader();
               
                while (dr.Read())
                {
                    for (int i = 0; i < combolist_Tedarikci.Count; i++)
                    {
                        combolist_Tedarikci[i].Items.Add(dr["Tedarikci_Ad"].ToString());
                       
                    }
                    combolist_Tedarikci_ID.Add( Convert.ToInt32(dr["Tedarikci_ID"]));

                }
                baglan.Close();
              
                

            }
            catch
            {
                MessageBox.Show("Veriler Yüklenirken Bir Hata Oluştu.", "Veritabanı Hatası", MessageBoxButtons.OK);

            }


        }

        private void yatırımlar_Combobox_Veri_Yukle()
        {
            comboBox2.Items.Clear();
          //  comboboxControl.Clear();

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand(" select proje_ID,proje_Adi,proje_Tedbir from proje_Yatirim where proje_ID not in(select  proje_ID from proje_Tedarikciler group by proje_ID)", baglan);
                
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                   
                    int projeID = Convert.ToInt32(dr["proje_ID"].ToString().TrimEnd());
                    //comboboxControl.Add(projeID);
                    comboBox2.Items.Add(dr["proje_Tedbir"].ToString().TrimEnd() + "/" + dr["proje_Adi"].ToString());
                    

                }
                baglan.Close();



            }
            catch
            {
                MessageBox.Show("Veriler Yüklenirken Bir Hata Oluştu. q", "Veritabanı Hatası", MessageBoxButtons.OK);

            }


            baglan.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count != 0 && dataGridView1.Rows.Count != 1)
            {
                //5 makine,6 hizmet
                int makineSayisi = Convert.ToInt32(dataGridView1.SelectedCells[5].Value.ToString());
                if (makineSayisi == 0)
                {
                    string makine_ProjeTedbir = dataGridView1.SelectedCells[0].Value.ToString();
                    string makine_ProjeAdi = dataGridView1.SelectedCells[1].Value.ToString();
                    string[] destek = makine_ProjeTedbir.Split('-');
                    int makine_ProjeID = proje_ID_Getir(makine_ProjeAdi, makine_ProjeTedbir);

                    Makina_Ekipman mak_Ek = new Makina_Ekipman(makine_ProjeTedbir.TrimEnd(), destek[0].TrimEnd(), makine_ProjeID, makine_ProjeAdi.TrimEnd());
                    mak_Ek.ShowDialog();
                }
                else
                    MessageBox.Show("Bu Yatırıma Daha Önce Makine Ekipman Eklenmiştir.");
                gridViewiYukle();
            }
            else
                MessageBox.Show("Tabloda Kayıt Bulunmamaktadır.");

        }
        private void proje_Yatirim_Ekle()
        {


            try
            {

                string adres = "";


                if (il.Text != "")
                    adres += il.Text + " İli ";
                if (ilce.Text != "")
                    adres += ilce.Text + " İlçesi ";
                if (köymahalle.Text != "")
                    adres += köymahalle.Text + " Köyü/Mahallesi ";
                if (mevki.Text != "")
                    adres += mevki.Text + " Mevkisi ";
                if (adaparsel.Text != "")
                    adres += " Ada/Parsel: " + adaparsel.Text;
                if (alan.Text != "")
                    adres += " Alan: " + alan.Text;
                if (vasfi.Text != "")
                    adres += " Vasfı: " + vasfi.Text;



                baglan.Open();
                SqlCommand conn = new SqlCommand("insert into proje_Yatirim (proje_Destek,proje_Tedbir,proje_Adi,proje_Davet_Tarihi,proje_Gecerlilik_Tarihi,proje_Son_Sunum_Tarihi,proje_Yatirimci,proje_Adres) Values ('" + comboBox1.SelectedItem.ToString() + "','" + comboBox1.SelectedItem.ToString() + "-" + (comboBox3.SelectedIndex + 1) + "','" + p_Adi.Text + "','" + dateTimePicker1.Value.ToShortDateString().ToString().Trim() + "','" + dateTimePicker2.Value.ToShortDateString().ToString().Trim() + "','" + dateTimePicker3.Value.ToShortDateString().ToString().Trim() + "','" + comboBox4.SelectedItem.ToString() + "','" + adres + "')", baglan);


                int rowcount = conn.ExecuteNonQuery();

                if (rowcount != 0)
                {
                    baglan.Close();
                }

            }
            catch
            {

                MessageBox.Show("Database Hatası", "Eklenemedi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglan.Close();
        }
        private void proje_Tedarikci_Ekle(int proje_ID) {
            //dinamik oluşturulan combobox(Tedarikciler) ve date_time verilerini proje_Tedarike insert.
            try
            {
                int length = 0;
                if (radioButton1.Checked == true)
                    length = 1;
                else if (radioButton2.Checked == true)
                    length = 3;

                for (int i = 0; i < length; i++)
                {
                    int tedarikci_ID = combolist_Tedarikci_ID[combolist_Tedarikci[i].SelectedIndex];

                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("insert into proje_Tedarikciler (proje_ID,tedarikci_ID,sunum_Tarihi) Values (" + proje_ID + ","+tedarikci_ID+",'" + dateList[i].Value.ToShortDateString() + "')", baglan);
                  //  MessageBox.Show(cmd.CommandText.ToString());

                    cmd.ExecuteNonQuery();
                    baglan.Close();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Database Hatası mı????//"+e.Message, "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglan.Close();
        }
      
        private int proje_ID_Getir(string proje_Adi,string proje_Tedbir)
        {
            //Seçilen tedarikçileri proje_tedarik tablosuna kaydederken gerekli olan PROJE_ID 
            //getirveyakontrol true ise Proje_Adi nin IDsini, false ise aynı isimli proje olup olmadığını kontrol eder
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select proje_ID,proje_Adi from proje_Yatirim where proje_Adi='" + proje_Adi + "' AND proje_Tedbir='"+proje_Tedbir+"'", baglan);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
              //      MessageBox.Show(cmd.CommandText.ToString());
                    int ID= Convert.ToInt32(dr["proje_ID"]);
                    if (proje_Adi == dr["proje_Adi"].ToString())
                    {
                        baglan.Close();
                        return ID; }

                    baglan.Close();
                    return 0;
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("Database Hatası");
            }
            baglan.Close();
            return 0;

        }
        
       // private bool proje_Aynı_kayıt_Kontrol
        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count != 0 && dataGridView1.Rows.Count != 1)
            {

                int hizmetSayisi = Convert.ToInt32(dataGridView1.SelectedCells[6].Value.ToString());
                if (hizmetSayisi == 0)
                {


                    string makine_ProjeTedbir = dataGridView1.SelectedCells[0].Value.ToString();
                    string makine_ProjeAdi = dataGridView1.SelectedCells[1].Value.ToString();
                    string[] destek = makine_ProjeTedbir.Split('-');
                    int makine_ProjeID = proje_ID_Getir(makine_ProjeAdi, makine_ProjeTedbir);

                    HizmetAlimi hA = new HizmetAlimi(makine_ProjeTedbir.TrimEnd(), destek[0].TrimEnd(), makine_ProjeID, makine_ProjeAdi.TrimEnd());
                    hA.ShowDialog();
                    gridViewiYukle();
                }
                else
                    MessageBox.Show("Bu Yatırıma Daha Önce Hizmet Alımı Eklenmiştir.");
            }
            else
                MessageBox.Show("Tabloda Kayıt Bulunmamaktadır");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null || comboBox3.SelectedItem != null || p_Adi.Text != "" || comboBox4.SelectedItem!=null)
            {
                if (proje_ID_Getir(p_Adi.Text, comboBox1.SelectedItem.ToString() + "-" + (comboBox3.SelectedIndex + 1)) == 0)
                    proje_Yatirim_Ekle();
                else
                    MessageBox.Show("Bu Destek Kapsamından Aynı Ada Sahip Bir Yatırım Kayıtlı.");
                
            }
            else 
                MessageBox.Show("Yatırım Formunu Eksiksiz Doldurunuz.", "Eksik Form", MessageBoxButtons.OK, MessageBoxIcon.Information);

            yatırımlar_Combobox_Veri_Yukle();
        }

        private bool tedarikciTarihKontrol(int projeID)
        {
            try
            {
                baglan.Open();
                string davetTarihi="";
                string sonSunumTarihi="";
                SqlCommand cmd = new SqlCommand("select * from proje_Yatirim where proje_ID="+projeID+"", baglan);
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    davetTarihi = dr["proje_Davet_Tarihi"].ToString().TrimEnd();
                    sonSunumTarihi = dr["proje_Son_Sunum_Tarihi"].ToString().TrimEnd();

                }

                baglan.Close();

                ///////
                int length = 0;
                if (radioButton1.Checked == true)
                    length = 1;
                else if (radioButton2.Checked == true)
                    length = 3;

               
                DateTime davetTarih=DateTime.Parse(davetTarihi);
                DateTime sonSunumTarih = DateTime.Parse(sonSunumTarihi);




                for (int i = 0; i < length; i++)
                {


                    if (combolist_Tedarikci[i].SelectedIndex == -1)
                    {
                        MessageBox.Show((i + 1) + ". Tedarikçi Seçilmemiş.");
                        return false;


                    }
                    if (DateTime.Compare(dateList[i].Value.Date, davetTarih.Date) < 0 || DateTime.Compare(dateList[i].Value.Date, sonSunumTarih.Date) > 0)
                    {
                       

                        MessageBox.Show(combolist_Tedarikci[i].SelectedItem.ToString()+" İçin Tarih  "+davetTarihi+"-"+sonSunumTarihi+" Aralığında Olmalı","Tarih !",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return false;

                    }

                   

                }


            }
            catch
            {

                MessageBox.Show("Veritabanı Hatasıasd");
            }

            return true;

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && (radioButton1.Checked==true || radioButton2.Checked==true))
            {
                string[] yatirimci_combobox = comboBox2.SelectedItem.ToString().TrimEnd().Split('/');

                if (radioButton2.Checked == true)
                {
                    if (combolist_Tedarikci[0].SelectedIndex != combolist_Tedarikci[1].SelectedIndex &&
                        combolist_Tedarikci[0].SelectedIndex != combolist_Tedarikci[2].SelectedIndex &&
                        combolist_Tedarikci[1].SelectedIndex != combolist_Tedarikci[2].SelectedIndex)
                    {
                        int projeID = proje_ID_Getir(yatirimci_combobox[1].TrimEnd(), yatirimci_combobox[0].TrimEnd());

                        if (tedarikciTarihKontrol(projeID) == true)
                        {
                            proje_Tedarikci_Ekle(projeID);

                            radioButton1.Checked = false;
                            radioButton2.Checked = false;
                            yatırımlar_Combobox_Veri_Yukle();
                            groupBox1.Controls.Clear();
                            gridViewiYukle();


                        }

                    }
                    else
                        MessageBox.Show("Lütfen Farklı Tedarikçiler Seçiniz.","Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Warning);



                }
                else if (radioButton1.Checked == true)
                {
                    
                    int projeID = proje_ID_Getir(yatirimci_combobox[1].TrimEnd(), yatirimci_combobox[0].TrimEnd());
                    if (tedarikciTarihKontrol(projeID) == true)
                    {
                        proje_Tedarikci_Ekle(projeID);

                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        yatırımlar_Combobox_Veri_Yukle();
                        groupBox1.Controls.Clear();
                        gridViewiYukle();


                    }
                }
            }
            else
                MessageBox.Show("1- Tedarikçi Eklemek İstediğiniz Yatırımı Seçiniz.\n2- Eklemek İstediğiniz Tedarikçi Sayısını Seçiniz","Uyarı !",MessageBoxButtons.OK,MessageBoxIcon.Warning);

          



        }

        private void button4_Click(object sender, EventArgs e)
        {
           



            
        }

     
        private void gridViewiYukle()
        {

            try
            {
                baglan.Open();

                string göster = "select * from vw_TKDK";
                SqlCommand kmt = new SqlCommand(göster, baglan);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglan.Close();


            }
            catch 
            {

               
            }






        }

        private void button9_Click(object sender, EventArgs e)
        {
            BelgeleriIndir bı = new BelgeleriIndir();
            bı.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

       
    }
}


