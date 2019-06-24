using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace impostemalı2
{
    public partial class Makina_Ekipman : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");

        //Formda PlaceHolder Olarak Çalışır
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        

        string Tedbir, Destek, AD;
        int projeID;
        List<int> tedarikciID = new List<int>();
        List<string> tedarikciAdı = new List<string>();
        string teknikOzellik;

        string ExcelMakineTabloDosya_Yolu;

        int tedarikciIndex;
        struct MakineEkipman {
            
            public string Birim;
            public string Miktar;
         
            
        };

        public Makina_Ekipman()
        {
            InitializeComponent();
        }


        public Makina_Ekipman(string tedbir, string destek, int proje_ID, string ad)
        {
            InitializeComponent();
            AD = ad;
            Destek = destek;
            Tedbir = tedbir;
            projeID = proje_ID;
            label11.Text = "'" + tedbir + "' - '" + ad + "' isimli yatırım için Makine Ekipman Sayfası.";
            string[] excel = tedbir.Split('-');
            ExcelMakineTabloDosya_Yolu = Environment.CurrentDirectory + "\\ExcelMakineListesi\\"+destek+"\\"+excel[0]+excel[1]+ " uygun harcama.xlsx";


        }

        private void Makina_Ekipman_Load(object sender, EventArgs e)
        {

            try
            {
                                    
            panel1.BackColor = Color.FromArgb(180, 255, 255, 255);
            comboboxYukle();
            SendMessage(textBox4.Handle, EM_SETCUEBANNER, 0, "Yeni Marka");
            SendMessage(textBox5.Handle, EM_SETCUEBANNER, 0, "Yeni Model");
            SendMessage(textBox7.Handle, EM_SETCUEBANNER, 0, "Diğer");

            tedarikcilerYukle();
            gridYukle();
            marka_model_Combobox();

            groupBox2.Enabled = false;
            textBox6.Visible = false;
            label13.Visible = false;
            button5.Visible = false;

            }
            catch             {

                MessageBox.Show("Makine Ekipman Excel Dosyası Bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /////************** VERİTABANI İŞLEMLERİ **************/////

        //seçilen destek->Tedbir için uygun makineler comboboxa atılır
        private void comboboxYukle() 
        {
            int rCnt = 0;
            int cCnt = 0;
            string workbookPath = ExcelMakineTabloDosya_Yolu;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = app.Workbooks.Open(workbookPath, 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Microsoft.Office.Interop.Excel.Sheets excelSheets = excelWorkbook.Worksheets;
            Microsoft.Office.Interop.Excel.Range range;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Worksheets.get_Item(1);

            string currentSheet = "Sayfa1";
            Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelSheets.get_Item(currentSheet);
            range = xlWorkSheet.UsedRange;

            rCnt = range.Rows.Count;
            cCnt = range.Columns.Count;

            for (int i = 1; i < rCnt + 1; i++)
            {

                comboBox1.Items.Add((excelWorksheet.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value);
            }


            excelWorkbook.Close();
            app.Quit();

            Marshal.ReleaseComObject(excelWorkbook);
            Marshal.ReleaseComObject(app);
        }

        //projede kaç tedarikci oldugunu ve tedarikci bilgileri çekilir
        private void tedarikcilerYukle()
        {
            tedarikciID.Clear();
            tedarikciAdı.Clear();

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select Tedarikci_Ad,Tedarikci_ID from Tedarikciler where Tedarikci_ID  in( select tedarikci_ID from proje_Tedarikciler where proje_ID not in (select  proje_ID from proje_Makine_Ekipman ) and proje_ID=" + projeID + ")", baglan);
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

                //   string göster = "SELECT K.proje_Tedbir AS Tedbir, K.proje_Adi AS ProjeAdı, K.proje_Adres AS Adres, K.proje_Yatirimci AS Yatırımcı, T.TedarikciSayisi, H.MakineSayısı/T.TedarikciSayisi as MakineSayisi FROM dbo.proje_Yatirim AS K INNER JOIN (SELECT proje_ID, COUNT(proje_ID) AS TedarikciSayisi FROM  dbo.proje_Tedarikciler GROUP BY proje_ID) AS T ON K.proje_ID = T.proje_ID INNER JOIN(SELECT proje_ID, COUNT(proje_ID)AS MakineSayısı FROM dbo.proje_Makine_Ekipman  GROUP BY proje_ID) AS H ON H.proje_ID = K.proje_ID WHERE(K.proje_ID IN (SELECT proje_ID FROM dbo.proje_Tedarikciler AS proje_Tedarikciler_1 GROUP BY proje_ID)) AND(K.proje_ID IN (SELECT proje_ID FROM dbo.proje_Makine_Ekipman GROUP BY proje_ID))";
                string goster = " select proje_ID,COUNT(proje_MakineEkipman_Adi) as TedarikciSayisi, proje_MakineEkipman_Adi as MakineAdi,proje_MakineEkipman_Birimi as Birimi,proje_MakineEkipman_Miktar as Miktari  from proje_Makine_Ekipman where proje_ID=" + projeID + " group by proje_MakineEkipman_Adi ,proje_ID,proje_MakineEkipman_Birimi,proje_MakineEkipman_Miktar";
                SqlCommand kmt = new SqlCommand(goster, baglan);
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
        //veritabanından marka model Comboboxlara atılır
        private void marka_model_Combobox() {

            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            try
            {
                baglan.Open();

                string marka = "select marka from  Marka";
                SqlCommand kmt = new SqlCommand(marka, baglan);
                SqlDataReader dr = kmt.ExecuteReader();

                while (dr.Read())
                {
                    
                    comboBox2.Items.Add(dr["marka"].ToString());

                }             
                baglan.Close();

                baglan.Open();

                string model = "select model from  Model";
                SqlCommand kmt2 = new SqlCommand(model, baglan);
                SqlDataReader dr2 = kmt2.ExecuteReader();

                while (dr2.Read())
                {

                    comboBox3.Items.Add(dr2["model"].ToString());

                }
                baglan.Close();
               


            }
            catch
            {


            }

        }




        List<string> mEkle ;
        //makine_Ekipman veritabanına eklenir
        private void makineEkipmanEkle(int projeID,int projeTedarikciID,string makineEkipmanAdı,string makineTeknikOzellik,string makineMarka,string makineModel,string makineMensei,string birim,string miktar,string birimFiyat,string toplamFiyat)
        {
            mEkle.Add("insert into proje_Makine_Ekipman (proje_ID,proje_MakineEkipman_Tedarikci_ID,proje_MakineEkipman_Adi,proje_MakineEkipman_TeknikOzellik,proje_MakineEkipman_Marka,proje_MakineEkipman_Model,proje_MakineEkipman_Mensei,proje_MakineEkipman_Birimi,proje_MakineEkipman_Miktar,proje_MakineEkipman_BirimFiyat,proje_MakineEkipman_ToplamFiyat) values(" + projeID + ", " + projeTedarikciID + ", '" + makineEkipmanAdı + "', '" + makineTeknikOzellik + "', '" + makineMarka + "', '" + makineModel + "', '" + makineMensei + "', '" + birim + "', '" + miktar + "', '" + birimFiyat + "', '" + toplamFiyat + "')");

           
            if(mEkle.Count==tedarikciID.Count)
            {
                baglan.Close();

                try
                {
                    baglan.Open();
                    SqlCommand cmd=new SqlCommand();
                    if (mEkle.Count==1)
                        cmd = new SqlCommand("begin tran "+mEkle[0]+ "; if (select COUNT(*) from proje_Makine_Ekipman where proje_ID="+projeID+" and  proje_MakineEkipman_Adi='"+listBox1.SelectedItem+"')="+tedarikciID.Count+" commit tran; else rollback tran", baglan);
                    else if(mEkle.Count==3)
                        cmd = new SqlCommand("begin tran " + mEkle[0] + ";"+mEkle[1]+";"+mEkle[2]+"; if (select COUNT(*) from proje_Makine_Ekipman where proje_ID=" + projeID + "  and proje_MakineEkipman_Adi='" + listBox1.SelectedItem + "')=" + tedarikciID.Count + " commit tran; else rollback tran", baglan);

                    cmd.ExecuteNonQuery();
                    baglan.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Makine Ekipman Eklenemedix");
                }


                baglan.Close();
            }
        }
        
        //Makine teknik özellik
        //teknik özellik için dinamik oluşmuş textboxlardan alınan verileri birleştirir
        List<List<string>> arr = new List<List<string>>();
        private void makineTeknikOzellikOlustur()
        {
            
            List<string> tknik = new List<string>();
            teknikOzellik = "";
            for (int i = 0; i < list_txtbox.Count; i++)
            {
                if (list_txtbox[i].Text != "")
                {
                    tknik.Add(list_txtbox[i].Text);
                    teknikOzellik += makine_Ozellik[i] + ":" + list_txtbox[i].Text + "\n";
                }
            }
            teknikOzellik += "\n\nAciklama : " + textBox6.Text;
            arr.Add(tknik);
           //  MessageBox.Show(teknikOzellik);

        }

        //gönderilen 3 sayıda max ve min olanı dönderir
        private int[] findMinMax(string sayi1,string sayi2,string sayi3)
        {
            
           
            int S1 = Convert.ToInt32(sayi1);
            int S2 = Convert.ToInt32(sayi2);
            int S3 = Convert.ToInt32(sayi3);

            int max = Math.Max(S1, S2);
            max = Math.Max(max, S3);
         

            int min = Math.Min(S1, S2);
            min = Math.Min(min, S3);


            



            return  new int[]{min,max};
        }


        
        //****TEKNİK SARTNAME*****////
        string[] sartname;
        string makineOzelliksartnameSonHal;
        
        //özelliklere aralık oluşturulur veya birleştirilir
        private void teknikSartNameOlustur()
        {
            sartname = new string[100] ;
            int increase = tedarikciID.Count;
          
            
            int i = 0;
            if (increase == 3)
            {
                int k = 0;
                while (i < arr.Count / increase)
                {
                    for (int t = 0; t < arr[i].Count; t++)
                    {
                        int result;
                        if (int.TryParse(arr[i][t].ToString(), out result)&&int.TryParse(arr[i+1][t].ToString(), out result)&& int.TryParse(arr[i+2][t].ToString(), out result))
                        {
                            int min = findMinMax(arr[i][t].ToString(), arr[i + 1][t].ToString(), arr[i + 2][t].ToString())[0];
                            int max = findMinMax(arr[i][t].ToString(), arr[i+1][t].ToString(), arr[i+2][t].ToString())[1];
                            sartname[k++] += (min-5) + "-" + (max+5)+"\n";
                        }
                        else
                        {
                            sartname[k++] += arr[i][t].ToString() + "/" + arr[i + 1][t].ToString() + "/" + arr[i + 2][t].ToString()+"\n";
                           

                        }

                       
                            }
                 
                    i += increase;
                }
            }
            else if (increase == 1)
            {
                int k = 0;
                while (i<arr.Count/increase)
                {
                    for (int t = 0; t < arr[i].Count; t++)
                    {
                        int result;
                        if (int.TryParse(arr[i][t].ToString(), out result))
                        {
                            sartname[k++] += (Convert.ToInt32(arr[i][t].ToString())-5).ToString()+"-"+ (Convert.ToInt32(arr[i][t].ToString()) + 5).ToString()+"\n";
                        }else
                        {

                            sartname[k++] += arr[i][t].ToString()+"\n";

                        }
                    }
                  
                    i += increase;
                }

            }
            
            makineOzelliksartnameSonHal = "";
            for (int j = 0; j < sartname.Length; j++)
            {
                if (sartname[j] != null)
                    makineOzelliksartnameSonHal += makine_Ozellik[j]+":"+ sartname[j];
                else
                    break;
            }

          


        }
        private void teknikSartNameEkle()
        {
            int index = listBox1.SelectedIndex;
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("insert into proje_Sartname (proje_ID,sartname_makineAdi,sartname_makineOzellik,sartname_makineBirim,sartname_makineMiktar) values ("+projeID+",'"+listBox1.SelectedItem.ToString()+"','"+makineOzelliksartnameSonHal+"','"+mE[index].Birim+"','"+mE[index].Miktar+"')", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();


            }
            catch 
            {

                MessageBox.Show("Sartname Veritabanı Kaydolurken Bir Hata Meydana Geldi");
            }
            baglan.Close();
        }


        //Seçilen makinenin özelliklerini excel sutunlarından. 
        List<string> makine_Ozellik = new List<string>();
      
        //excel dosyasındaki makine adı ve özellikleri comboboxa yüklenir
        private void makina_getir(string find)
        {
            int cCnt = 0;
            string workbookPath = ExcelMakineTabloDosya_Yolu;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = app.Workbooks.Open(workbookPath, 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Microsoft.Office.Interop.Excel.Sheets excelSheets = excelWorkbook.Worksheets;
            Microsoft.Office.Interop.Excel.Range range;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Worksheets.get_Item(1);

            string currentSheet = "Sayfa1";
            Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelSheets.get_Item(currentSheet);
            range = xlWorkSheet.UsedRange;

            cCnt = range.Columns.Count;

            Microsoft.Office.Interop.Excel.Range xlFound = range.EntireRow.Find(find, System.Reflection.Missing.Value, Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
  Microsoft.Office.Interop.Excel.XlSearchOrder.xlByColumns, Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext,
  true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            int ID_Number = 1;
            //~~> Check if a range was returned
            if (!(xlFound == null))
            {
                ID_Number = xlFound.Row;

            }

            for (int k = 2; k < cCnt + 1; k++)
            {
                string makine_özellik_Excel = (excelWorksheet.Cells[ID_Number, k] as Microsoft.Office.Interop.Excel.Range).Value;
                if (makine_özellik_Excel != null)
                    makine_Ozellik.Add(makine_özellik_Excel);
            }

            excelWorkbook.Close();
            app.Quit();

            Marshal.ReleaseComObject(excelWorkbook);
            Marshal.ReleaseComObject(app);
        }

        List<System.Windows.Forms.TextBox> list_txtbox = new List<System.Windows.Forms.TextBox>();
        
        //Process İşlemleri
        public int ms;

        private void button4_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.Rows.Count !=0 && dataGridView1.Rows.Count != 1)
            {
                int projeID=Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString().Trim());
                string makine_Adi=dataGridView1.SelectedCells[2].Value.ToString().Trim();
                int tedarikciSayisi= Convert.ToInt32(dataGridView1.SelectedCells[1].Value.ToString().Trim());

                MakineEkipman_Duzenle mED = new MakineEkipman_Duzenle(projeID, makine_Adi, tedarikciSayisi);
                mED.ShowDialog();
                gridYukle();
            }
            else
                MessageBox.Show("Düzenlenecek Bir Makine Yok veya Seçilmemiş");
        }

        int makineCount = 0;
        MakineEkipman[] mE = new MakineEkipman[100];


        //makinenin ad,fiyat,birim,miktar gibi özelliklerini struc değişkeninde tutulur
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedIndex!=-1 && textBox1.Text!="" && (comboBox5.SelectedIndex!=-1 || textBox7.Text!="") )
            {
                int miktar;
                //  textBox3.Text = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text)).ToString();
                if (farklıMakineKontrlü(comboBox1.SelectedItem.ToString()) == true && int.TryParse(textBox1.Text, out miktar) && comboBox5.SelectedIndex!=-1 || textBox7.Text!="")
                {
                    listBox1.Items.Add(comboBox1.SelectedItem);
               
             
                if(textBox7.Text != "")
                    mE[makineCount].Birim = textBox7.Text;
                else
                    mE[makineCount].Birim = comboBox5.SelectedItem.ToString();

                mE[makineCount].Miktar = textBox1.Text;
              
                makineCount++;
                textBox1.Text = "";

            }
                else
                    MessageBox.Show("-Bu Makine Daha Önce Eklenmiş olabilir, Farklı Bir Seçim Yapınız.\n-Birim ve Miktarı Uygun Seçiniz.");
            }
            else
                MessageBox.Show("Boşlukları Dolduralım");
        }

        //listboxa aynı makinelerin eklenmesini önlemek lazım
        private bool farklıMakineKontrlü(string makineAdı)
        {
            for (int i = 0; i <listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() == makineAdı)
                    return false;

            }

            return true;


        }

        //listboxdan seçilen  makine için dinamik textbox ve label oluşturulur
        private void makineEkipmanGroupBox(int a) 
        {
            makine_Ozellik.Clear();
            groupBox1.Controls.Clear();
            list_txtbox.Clear();
            makina_getir(listBox1.SelectedItem.ToString());
            groupBox1.Text = tedarikciAdı[a].ToString() + " Adlı Tedarikçi İçin Makine Ekipman Kayıt";
            int x_location_lbl = 20;
            int x_location_txtbox = 160;
            int y_location = 20;
            for (int i = 0; i < makine_Ozellik.Count; i++)
            {
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Location = new System.Drawing.Point(x_location_lbl, y_location);
                lbl.Text = makine_Ozellik[i].ToString();
                lbl.Size = new Size(140, 21);
                groupBox1.Controls.Add(lbl);
                System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox();
                tb.Location = new System.Drawing.Point(x_location_txtbox, y_location);
                tb.Size = new Size(80, 21);
                tb.Name = "tbox" + (i + 1);
                y_location += 30;

                if (y_location > 300)
                {
                    x_location_lbl += 250;
                    x_location_txtbox += 260;
                    y_location = 20;

                }
                list_txtbox.Add(tb);
                groupBox1.Controls.Add(tb);

            }
           }

        //makine kaydına başladıgında değişir, bitene kadar 
        private bool kayitDurum=true;

        //listeden seçilen makine
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kayitDurum != false)
            {
                if (listBox1.SelectedItem != null && aynıMakineEklemeKontrolu(projeID, listBox1.SelectedItem.ToString(), tedarikciAdı.Count) == true)
                {
                    // listBox1.Enabled = false;
                    arr.Clear();
                    textBox6.Visible = true;
                    label13.Visible = true;
                    button5.Visible = true;
                    tedarikciIndex = 0;
                    groupBox2.Enabled = true;
                    mEkle = new List<string>();
                    makineEkipmanGroupBox(tedarikciIndex);

                }
                else
                {
                    if (listBox1.SelectedIndex != -1)
                        MessageBox.Show("Listedeki Bu Makine İçin Kayıt Yapılmıştır.");

                    groupBox1.Controls.Clear();
                    groupBox2.Enabled = false;
                    textBox6.Visible = false;
                    label13.Visible = false;
                }
            }
            else
            {
                if (listBox1.SelectedIndex != seciliMakineIndex) { 
                MessageBox.Show("Bu Makine İçin Kayıt Tamamlanmadan Başka Makine Seçemezsiniz.");
                listBox1.SelectedIndex = seciliMakineIndex;
                }

            }
        }

        //Aynı kayıt eklenmemesi için kontrol yapılır veritabanından
        private bool aynıMakineEklemeKontrolu(int projeID,string makineAdı,int tedarikciSayisi)
        {

            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select COUNT(*) As Sayi from proje_Makine_Ekipman where proje_ID="+projeID+" and proje_MakineEkipman_Adi='"+makineAdı+"'", baglan);
                SqlDataReader dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Sayi"]) == tedarikciSayisi)
                    {
                        baglan.Close();
                        return false;
                    }

                }

            }
            catch 
            {

                MessageBox.Show("Database Hatası Meydana Geldi");
            }

            baglan.Close();
            return true;

        }

        //form kontrol
        private bool boslukKontrol()
        {
            if (comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && comboBox4.SelectedIndex != -1 && textBox2.Text != "" && textBox3.Text != "")
                return true;


            return false;

            
        }
        //1 den fazla tedarikçi için next tuşu gibi çalışır
        int seciliMakineIndex;
        private void button5_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            
            if (tedarikciIndex == 0)
            {

                if (boslukKontrol())
                {
                    seciliMakineIndex = listBox1.SelectedIndex;
                    makineTeknikOzellikOlustur();
                    makineEkipmanEkle(projeID, tedarikciID[tedarikciIndex], listBox1.SelectedItem.ToString(), teknikOzellik, comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox4.SelectedItem.ToString(), mE[index].Birim, mE[index].Miktar, textBox2.Text, textBox3.Text);
                    
                    kayitDurum = false;
                    tedarikciIndex++;
                    if (tedarikciIndex < tedarikciAdı.Count)
                        groupBox1.Text = tedarikciAdı[tedarikciIndex].ToString() + " Adlı Tedarikçi İçin Makine Ekipman Kayıt";
                    else
                    {
                      //  MessageBox.Show("aa1");
                        groupBox2.Enabled = false;
                        button5.Image = Properties.Resources.done;
                        textBox6.Visible = false;
                        label13.Visible = false;
                        groupBox1.Controls.Clear();
                    }
                }
                else
                    MessageBox.Show("Formda Boşluklar Var");
            }
            else
            
            if (tedarikciIndex < tedarikciAdı.Count && tedarikciIndex>0)
            {
                if (boslukKontrol())//form elemanları dolu olmalı
                {
                    seciliMakineIndex = listBox1.SelectedIndex;
                    makineTeknikOzellikOlustur();
                    makineEkipmanEkle(projeID, tedarikciID[tedarikciIndex], listBox1.SelectedItem.ToString(), teknikOzellik, comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox4.SelectedItem.ToString(), mE[index].Birim, mE[index].Miktar, textBox2.Text, textBox3.Text);
                    kayitDurum = false;
                    tedarikciIndex++;
                    if (tedarikciIndex < tedarikciAdı.Count)
                        groupBox1.Text = tedarikciAdı[tedarikciIndex].ToString() + " Adlı Tedarikçi İçin Makine Ekipman Kayıt";
                    else
                    {
                      //  MessageBox.Show("aa2");
                        button5.Image = Properties.Resources.done;
                        textBox6.Visible = false;
                        label13.Visible = false;
                        groupBox2.Enabled = false;
                        groupBox1.Controls.Clear();
                    }
                }
                else
                    MessageBox.Show("Formda Boşluklar Var");
            }
            else if(tedarikciIndex==tedarikciAdı.Count)
            {

                if (aynıMakineEklemeKontrolu(projeID, listBox1.SelectedItem.ToString(), tedarikciID.Count)==false)
                {
                    teknikSartNameOlustur();
                    teknikSartNameEkle();
                    MessageBox.Show("Bu makine için kayıt tamamlandı");
                }
                else
                    MessageBox.Show("Makine Şartname Eklenirken Hata Oluştu");
                
                groupBox1.Controls.Clear();
                groupBox2.Enabled= false;
                button5.Image = Properties.Resources.next1;
                groupBox1.Text = "Teknik Özellik";
                textBox6.Visible = false;
                label13.Visible = false;
                kayitDurum = true;
                button5.Visible = false;
             //   listBox1.Enabled = kayitDurum;

               



            }
         
            //her tedarikçi için sayfa itemlerini temizler
            for (int i = 0; i < list_txtbox.Count; i++)//makine özellikleri için textboxlar temizlenir
            {
                list_txtbox[i].Text = "";
            }
            textBox6.Text = "";//'Açıklama' textboxu

            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            textBox2.Text = "";
            textBox3.Text = "";


            gridYukle();

        

        }

        //Belgeleri İndir Button
        private void button9_Click(object sender, EventArgs e)
        {
       
            DialogResult dR = MessageBox.Show("Devam Ederseniz Bu Projeye Makine Ekipman Ekleme İşlemini Bitirmiş Olursunuz.", "Uyarı", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dR==DialogResult.Yes)
            {
                this.Hide();


                BelgeleriIndir bI = new BelgeleriIndir();
                bI.ShowDialog();
                this.Close();
            }
            

            //ExcelSablonu();

        }

        //processbar worker
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 0; i < 101; i++)
            {
                worker.ReportProgress(i);
                System.Threading.Thread.Sleep(ms / 100);

            }
           
                label10.Text = ("Tamamlandı");
                System.Threading.Thread.Sleep(3000);
                label10.Visible = false;
                progressBar1.Value = 0;
            
            
            

        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label10.Text = ("Sayfa Yüklenirken Bekleyiniz: " + e.ProgressPercentage.ToString() + "%");
        }
        
        //Word Şablonu Düzenleme
        public void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }
        private void word_ciktisi()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Word File (*.docx)|*.docx|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }

            try
            {

                //  copy letter format to .docx
                File.Copy("", saveFileDialog1.FileName, true);
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                //  create Word document object
                Microsoft.Office.Interop.Word.Document aDoc = null;
                //  create & define filename object with .docx
                object filename = saveFileDialog1.FileName;
                //  if .docx available
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    //  make visible Word application
                    wordApp.Visible = false;
                    //  open Word document named .docx
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
        ref readOnly, ref missing, ref missing, ref missing,
        ref missing, ref missing, ref missing, ref missing,
        ref missing, ref isVisible, ref missing, ref missing,
        ref missing, ref missing);
                    aDoc.Activate();
                    //  Call FindAndReplace()function for each change
                    FindAndReplace(wordApp, "<FirmaAdı>", "Horer ltd. şti.");
                    FindAndReplace(wordApp, "<FirmaAdres>", "maraşşşşş");
                    FindAndReplace(wordApp, "<FirmaVergiNo>", "123456789");
                    FindAndReplace(wordApp, "<VergiDairesi>", "erciyes dağı");
                    FindAndReplace(wordApp, "<SicilNo>", "5555555");
                    FindAndReplace(wordApp, "<Tel>", "333 333 33 33");
                    FindAndReplace(wordApp, "<Faks>", "111 111 11 11");
                    FindAndReplace(wordApp, "<Email>", "lol@lol.com");


                    //  save .docx after modified
                    aDoc.Save();
                    aDoc.Close();

                }
                else
                    MessageBox.Show("File does not exist.",
            "No File", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Error in process.", "Internal Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            watch.Stop();
            object elapsedMs = watch.Elapsed.TotalSeconds;
            ms = Convert.ToInt32(elapsedMs);

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
        }

     
        //birimfiyat textbox
        private void textBox2_Leave(object sender, EventArgs e)
        {
            int birimFiyat;
            if (int.TryParse(textBox2.Text, out birimFiyat))
            {
                textBox3.Text = (birimFiyat * Convert.ToInt32(mE[listBox1.SelectedIndex].Miktar)).ToString();

            }
            else
                MessageBox.Show("Birim Fiyat Sayı Olmak Zorunda.");
        }

        //marka ekle button
        private void button2_Click(object sender, EventArgs e)
        {
            markaEkle();
            marka_model_Combobox();
            textBox4.Text = "";
            SendMessage(textBox4.Handle, EM_SETCUEBANNER, 0, "Yeni Marka");

        }
        private void markaEkle() {

            try
            {
                bool check=true;
                baglan.Open();
                SqlCommand comd = new SqlCommand("select marka from Marka", baglan);
                SqlDataReader dr = comd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["marka"].ToString() == textBox4.Text)
                        check = false;
                    else
                        check = true;

                }
                baglan.Close();

                if (check == true)
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("insert into Marka (marka) values ('" + textBox4.Text + "')", baglan);
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
        private void modelEkle() {

            try
            {
                bool check = true;
                baglan.Open();
                SqlCommand comd = new SqlCommand("select model from Model", baglan);
                SqlDataReader dr = comd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["model"].ToString() == textBox5.Text)
                        check = false;
                    else
                        check = true;

                }
                baglan.Close();
                if (check == true)
                {
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("insert into Model (model) values ('" + textBox5.Text + "')", baglan);
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

        //model ekle button
        private void button3_Click(object sender, EventArgs e)
        {
            modelEkle();
            marka_model_Combobox();
            textBox5.Text = "";
            SendMessage(textBox5.Handle, EM_SETCUEBANNER, 0, "Yeni Model");

        }

        //Çıkar Butonu
        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && aynıMakineEklemeKontrolu(projeID, listBox1.SelectedItem.ToString(), tedarikciAdı.Count) == true)
            {
                MakineEkipman[] temp = new MakineEkipman[100];
                //temp = mE;
                
                for (int i = 0; i < listBox1.Items.Count-1; i++)
                {

                    if (i >= listBox1.SelectedIndex)
                    {
                        temp[i].Birim =mE[i+1].Birim;
                        temp[i].Miktar = mE[i + 1].Miktar;
                      

                    }else
                    {

                        temp[i].Birim = mE[i].Birim;
                        temp[i].Miktar = mE[i].Miktar;

                    }

                }
                mE = new MakineEkipman[100];
                mE = temp;

                listBox1.Items.Remove(listBox1.SelectedItem.ToString());
                groupBox1.Controls.Clear();
                groupBox2.Enabled = false;
                textBox6.Visible = false;
                label13.Visible = false;


            } 
               
        }
        
        //Excel Şablonu Düzenleme
        public void Excel_ciktisi(string filename, string text)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Excel File (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;


            // the code that you want to measure comes here



            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
            var app_1 = new Microsoft.Office.Interop.Excel.Application();
            var wb_1 = app_1.Workbooks.Add();
            wb_1.SaveAs(saveFileDialog1.FileName);
            wb_1.Close();


            File.Copy(filename, saveFileDialog1.FileName, true);
            // the code that you want to measure comes here


            object m = Type.Missing;

            // open excel.
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            // open the workbook. 
            Workbook wb = app.Workbooks.Open(saveFileDialog1.FileName, m, false, m, m, m, m, m, m, m, m, m, m, m, m);

            // get the active worksheet. (Replace this if you need to.) 
            Worksheet ws = (Worksheet)wb.ActiveSheet;

            // get the used range. 
            Range r = (Range)ws.UsedRange;


            // call the replace method to replace instances. 
            bool success = (bool)r.Replace("<name>", text.Trim(), XlLookAt.xlWhole, XlSearchOrder.xlByRows, true, m, m, m);

            // save and close. 
            wb.Save();
            app.Quit();
            app = null;





        }

        private void ExcelSablonu()
        {

            var app = new Microsoft.Office.Interop.Excel.Application();
            var wb1 = app.Workbooks.Add();
            wb1.SaveAs("C:\\Users\\unknownArtist\\Desktop\\"+AD+" "+tedarikciAdı[0]+".xlsx");
            wb1.Close();

            File.Copy("C:\\Users\\unknownArtist\\Desktop\\TeklifFiyatları.xlsx", "C:\\Users\\unknownArtist\\Desktop\\" + AD + " " + tedarikciAdı[0] + ".xlsx", true);

            object m = Type.Missing;

            // open excel.
            // Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            // open the workbook. 
            Workbook wb = app.Workbooks.Open("C:\\Users\\unknownArtist\\Desktop\\" + AD + " " + tedarikciAdı[0] + ".xlsx", m, false, m, m, m, m, m, m, m, m, m, m, m, m);

            // get the active worksheet. (Replace this if you need to.) 
            Worksheet ws = (Worksheet)wb.ActiveSheet;

            // get the used range. 
            Range r = (Range)ws.UsedRange;

            // call the replace method to replace instances. 
            // bool success = (bool)r.Replace("<name>", text.Trim(), XlLookAt.xlWhole, XlSearchOrder.xlByRows, true, m, m, m);

            // save and close. 

            baglan.Open();
            SqlCommand cmd = new SqlCommand("select proje_MakineEkipman_Adi,proje_MakineEkipman_TeknikOzellik,proje_MakineEkipman_Model,proje_MakineEkipman_Marka,proje_MakineEkipman_Mensei,proje_MakineEkipman_Birimi,proje_MakineEkipman_Miktar,proje_MakineEkipman_BirimFiyat,proje_MakineEkipman_ToplamFiyat from proje_Makine_Ekipman where proje_MakineEkipman_Tedarikci_ID="+2+"", baglan);
            SqlDataReader dr = cmd.ExecuteReader();

            int k = 5;
            // Loop through the rows and output the data
            while (dr.Read())
            {
                r.Cells[k, 1] =k-4;
                for (int i = 1; i < dr.FieldCount+1; i++)
                {
                    string value = dr[i-1].ToString();
                    if (value.Contains(","))
                        value = "\"" + value + "\"";
                    
                    r.Cells[k, i+1] = value;
                }
                k++;
            }

            // Range Line = (Range)ws.Rows[3];
            //   Line.Insert();



            wb.Save();
            app.Quit();
            app = null;


            baglan.Close();


        }


    }
}
