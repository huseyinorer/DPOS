using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace impostemalı2
{
    public partial class BelgeleriIndir : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");

        public BelgeleriIndir()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        struct tedarikciBilgileri {
           public int tID;
            public string tAd;
            public string tVergiNo;
            public string tVergiDaire;
            public string tSicilNo;
            public string tAdres;
            public string tTel;
            public string tFaks;
            public string tEposta;
        

        };

        struct yatirimciBilgileri {
            public string yatirimciAdi;
            public string yatirimciAdres;
            public string yatirimciTel;
            public string yatirimciFaks;
            public string yatirimciEposta;

        };

        struct yatirimBilgileri {
            public string yAdi;
            public string davetTarihi;
            public string gecerlilikTarihi;
            public string sonSunumTarihi;

        };

        List<int> tedarikciID = new List<int>();
        List<string> tedarikciAdı = new List<string>();
        List<string> tedarikciSunumTarih = new List<string>();
        tedarikciBilgileri[] tB;
        yatirimBilgileri yB;
        yatirimciBilgileri ycB;
        private void makineEkipman_sablonaGonderilecekVeriler()
        {
            int projeID =Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString().Trim());
            tedarikciAdı.Clear();
            tedarikciID.Clear();
            tedarikciSunumTarih.Clear();
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select T.Tedarikci_ID,T.Tedarikci_Ad,t.Tedarikci_Adres,t.Tedarikci_Vergi_No,t.Tedarikci_Vergi_Dairesi,t.Tedarikci_Ticari_Sicil_No,t.Tedarikci_Tel,t.Tedarikci_Faks,t.Tedarikci_E_Posta from Tedarikciler as T where T.Tedarikci_ID in(select proje_MakineEkipman_Tedarikci_ID from proje_Makine_Ekipman where proje_ID="+projeID+" group by proje_MakineEkipman_Tedarikci_ID)", baglan);
                SqlDataReader dr = cmd.ExecuteReader();

                
                tB=new tedarikciBilgileri[3];
                int countTB = 0;
                while (dr.Read())
                {
                    tedarikciID.Add(Convert.ToInt32(dr["Tedarikci_ID"]));
                    tedarikciAdı.Add((dr["Tedarikci_Ad"].ToString()));

                    tB[countTB].tID = Convert.ToInt32(dr["Tedarikci_ID"].ToString());
                    tB[countTB].tAd = dr["Tedarikci_Ad"].ToString();
                    tB[countTB].tVergiNo = dr["Tedarikci_Vergi_No"].ToString();
                    tB[countTB].tVergiDaire = dr["Tedarikci_Vergi_Dairesi"].ToString();
                    tB[countTB].tSicilNo = dr["Tedarikci_Ticari_Sicil_No"].ToString();
                    tB[countTB].tAdres = dr["Tedarikci_Adres"].ToString();
                    tB[countTB].tTel = dr["Tedarikci_Tel"].ToString();
                    tB[countTB].tFaks = dr["Tedarikci_Faks"].ToString();
                    tB[countTB].tEposta = dr["Tedarikci_E_Posta"].ToString();
                 //   tB[countTB].tSunumTarihi ="xx.xx.xxxx";

                    countTB++;
                }
                baglan.Close();

                baglan.Open();
                SqlCommand cmd2 = new SqlCommand("select proje_Adi, proje_Davet_Tarihi,proje_Gecerlilik_Tarihi,proje_Son_Sunum_Tarihi from proje_Yatirim where proje_ID=" + projeID + "", baglan);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                yB = new yatirimBilgileri();
                while (dr2.Read())
                {
                    yB.yAdi = dr2["proje_Adi"].ToString();
                    yB.davetTarihi = dr2["proje_Davet_Tarihi"].ToString();
                    yB.sonSunumTarihi = dr2["proje_Son_Sunum_Tarihi"].ToString();
                    yB.gecerlilikTarihi = dr2["proje_Gecerlilik_Tarihi"].ToString();
                    

                }
                baglan.Close();

                baglan.Open();
                string yatirimciAdı = dataGridView1.SelectedCells[4].Value.ToString().Trim();
                ycB = new yatirimciBilgileri();
                SqlCommand cmd3 = new SqlCommand("select Ad_Soyad,Telefon,Faks,E_posta,Yatırımcı_Adres from Yatirimci_Tuzel_Kisi where Ad_Soyad='"+yatirimciAdı+"'", baglan);
                SqlDataReader dr3 = cmd3.ExecuteReader();
                           
                while (dr3.Read())
                {
                    
                    ycB.yatirimciAdi = dr3["Ad_Soyad"].ToString();
                    ycB.yatirimciAdres = dr3["Yatırımcı_Adres"].ToString();
                    ycB.yatirimciTel= dr3["Telefon"].ToString();
                    ycB.yatirimciFaks= dr3["Faks"].ToString();
                    ycB.yatirimciEposta= dr3["E_posta"].ToString();

                }


                baglan.Close();

                baglan.Open();
                cmd3 = new SqlCommand("select * from Yatirimci_Gercek_Kisi where Ad_Soyad='" + yatirimciAdı + "'", baglan);
               SqlDataReader dr4 = cmd3.ExecuteReader();

                while (dr4.Read())
                {

                    ycB.yatirimciAdi = dr4["Ad_Soyad"].ToString();
                    ycB.yatirimciAdres = dr4["Yatırımcı_Adres"].ToString();
                    ycB.yatirimciTel = dr4["Telefon"].ToString();
                    ycB.yatirimciFaks = dr4["Faks"].ToString();
                    ycB.yatirimciEposta = dr4["E_posta"].ToString();

                }
                baglan.Close();

                baglan.Open();
                SqlCommand cmd4 = new SqlCommand("select * from proje_Tedarikciler where proje_ID=" + projeID + "", baglan);
                SqlDataReader dr5 = cmd4.ExecuteReader();
                while (dr5.Read())
                {

                    tedarikciSunumTarih.Add(dr5["sunum_Tarihi"].ToString());

                }
                baglan.Close();
            }
            catch 
            {

                MessageBox.Show("Database Hasası Oluştu xd");
            }
            baglan.Close();
        }

        string filename;
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0 && dataGridView1.Rows.Count != 1)
            {
                //6 mak,7 hizmet,8 yapı




                makineEkipman_sablonaGonderilecekVeriler();
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.Filter = "All Files (*.*)|*.*";



                saveFileDialog1.FilterIndex = 1;







                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.Enabled = false;
                    filename = saveFileDialog1.FileName;
                    
                    backgroundWorker1.RunWorkerAsync();
                    //MakineEkipman_belgeleriOlustur(saveFileDialog1.FileName);

                }




            }
            else
                MessageBox.Show("Veritabanında İndirilmeye Hazır Belge Bulunmamaktadır.");

        }        
        private void MakineEkipman_belgeleriOlustur(string FileName)
        {

          
            
                    pictureBox1.Visible = true;

                    Directory.CreateDirectory(FileName);
                    int projeID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString().Trim());
                    //   sablonaGonderilecekVeriler();
                    for (int i = 0; i < tedarikciAdı.Count; i++)
                    {
                        ExcelSablonu(projeID, tedarikciID[i], tedarikciAdı[i], FileName, "TFiyat");

                    }

                    for (int i = 0; i < tedarikciAdı.Count; i++)
                    {
                        word_ciktisi(FileName, dataGridView1.SelectedCells[2].Value.ToString(), tedarikciAdı[i], i, "TeklifSunum");
                        word_ciktisi(FileName, dataGridView1.SelectedCells[2].Value.ToString(), tedarikciAdı[i], i, "TeklifDavet");

                    }
                    ExcelSablonu(projeID, 0, "", FileName, "Sartname");

                    MessageBox.Show("Belgeler " + FileName + " adresinde oluşturuldu");

            pictureBox1.Visible = false;
            dataGridView1.Enabled = true;


        }
        private void BelgeleriIndir_Load(object sender, EventArgs e)
        {
            gridYukle();
            pictureBox1.Visible = false;
         //   sablonaGonderilecekVeriler();
        }
        private void gridYukle()
        {


            try
            {
                baglan.Open();

               // string goster = "SELECT K.proje_ID,K.proje_Tedbir AS Tedbir, K.proje_Adi AS ProjeAdı, K.proje_Adres AS Adres, K.proje_Yatirimci AS Yatırımcı, T.TedarikciSayisi, H.MakineSayısı/T.TedarikciSayisi as MakineSayisi FROM dbo.proje_Yatirim AS K INNER JOIN (SELECT proje_ID, COUNT(proje_ID) AS TedarikciSayisi FROM  dbo.proje_Tedarikciler GROUP BY proje_ID) AS T ON K.proje_ID = T.proje_ID INNER JOIN(SELECT proje_ID, COUNT(proje_ID)AS MakineSayısı FROM dbo.proje_Makine_Ekipman  GROUP BY proje_ID) AS H ON H.proje_ID = K.proje_ID WHERE(K.proje_ID IN (SELECT proje_ID FROM dbo.proje_Tedarikciler AS proje_Tedarikciler_1 GROUP BY proje_ID)) AND(K.proje_ID IN (SELECT proje_ID FROM dbo.proje_Makine_Ekipman GROUP BY proje_ID))";
                string goster = "select* from vw_indirilecekBelgeler";
                SqlCommand kmt = new SqlCommand(goster, baglan);
                SqlDataAdapter da = new SqlDataAdapter(kmt);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglan.Close();


            }
            catch
            {


            }

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
        private void word_ciktisi(string dosyaYolu,string projeAdı,string tedarikci_Adi,int index,string BelgeAdi)
        {
          
            try
            {

                if (BelgeAdi == "TeklifDavet")
                { //  copy letter format to .docx
                    File.Copy(Environment.CurrentDirectory + "\\Sablon\\TeklifDavet.docx", dosyaYolu + "\\Teklif Davet-" + projeAdı + " " + tedarikci_Adi + ".docx", true);
                }else if(BelgeAdi=="TeklifSunum")
                    File.Copy(Environment.CurrentDirectory + "\\Sablon\\TeklifSunumFormu.doc", dosyaYolu + "\\Teklif Sunum-" + projeAdı + " " + tedarikci_Adi + ".doc", true);

                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                //  create Word document object
                Microsoft.Office.Interop.Word.Document aDoc = null;
                object filename="";
                if (BelgeAdi == "TeklifDavet")
                {
                    filename = dosyaYolu + "\\Teklif Davet-" + projeAdı + " " + tedarikci_Adi + ".docx";
                }
                else if (BelgeAdi == "TeklifSunum")
                {
                    filename = dosyaYolu + "\\Teklif Sunum-" + projeAdı + " " + tedarikci_Adi + ".doc";
                }
                //  create & define filename object with .docx
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


                    if (BelgeAdi == "TeklifDavet")
                    {
                        FindAndReplace(wordApp, "<TAdi>", tB[index].tAd);
                        FindAndReplace(wordApp, "<TAdres>", tB[index].tAdres);
                        FindAndReplace(wordApp, "<YatirimciAdi>", ycB.yatirimciAdi.TrimEnd());
                        FindAndReplace(wordApp, "<DavetTarihi>", yB.davetTarihi.TrimEnd());
                        FindAndReplace(wordApp, "<YatirimAdi>", yB.yAdi);
                        FindAndReplace(wordApp, "<YatirimAdres>", dataGridView1.SelectedCells[3].Value.ToString());
                        FindAndReplace(wordApp, "<YatirimciAdres>", ycB.yatirimciAdres);
                        FindAndReplace(wordApp, "<YatirimciTel>", ycB.yatirimciTel);
                        FindAndReplace(wordApp, "<YatirimciFaks>", ycB.yatirimciFaks);
                        FindAndReplace(wordApp, "<YatirimciEposta>", ycB.yatirimciEposta);
                        FindAndReplace(wordApp, "<GecerlilikTarihi>", yB.gecerlilikTarihi.TrimEnd());
                        FindAndReplace(wordApp, "<SunumTarihi>", tedarikciSunumTarih[index].TrimEnd());
                    }
                    else if (BelgeAdi == "TeklifSunum")
                    {
                        FindAndReplace(wordApp, "<TAdi>", tB[index].tAd);
                        FindAndReplace(wordApp, "<TAdres>", tB[index].tAdres);
                        FindAndReplace(wordApp, "<TVergiNo>", tB[index].tVergiNo);
                        FindAndReplace(wordApp, "<TVergiD>", tB[index].tVergiDaire);
                        FindAndReplace(wordApp, "<TSicilNo>", tB[index].tSicilNo);
                        FindAndReplace(wordApp, "<TTel>", tB[index].tTel);
                        FindAndReplace(wordApp, "<TFaks>", tB[index].tFaks);
                        FindAndReplace(wordApp, "<TEposta>", tB[index].tEposta);
                        FindAndReplace(wordApp, "<SunumTarih>", tedarikciSunumTarih[index].TrimEnd());
                        FindAndReplace(wordApp, "<YatirimciAdi>", ycB.yatirimciAdi);
                        FindAndReplace(wordApp, "<YatirimciAdres>", ycB.yatirimciAdres);
                        FindAndReplace(wordApp, "<YatirimAdi>", yB.yAdi);
                        FindAndReplace(wordApp, "<DavetTarih>", yB.davetTarihi.TrimEnd());
                        FindAndReplace(wordApp, "<GecerlilikTarih>", yB.gecerlilikTarihi.TrimEnd());
                    }
                    //  Call FindAndReplace()function for each change
                    //FindAndReplace(wordApp, "<FirmaAdı>", "Horer ltd. şti.");
                    //FindAndReplace(wordApp, "<FirmaAdres>", "maraşşşşş");
                    //FindAndReplace(wordApp, "<FirmaVergiNo>", "123456789");
                    //FindAndReplace(wordApp, "<VergiDairesi>", "erciyes dağı");
                    //FindAndReplace(wordApp, "<SicilNo>", "5555555");
                    //FindAndReplace(wordApp, "<Tel>", "333 333 33 33");
                    //FindAndReplace(wordApp, "<Faks>", "111 111 11 11");
                    //FindAndReplace(wordApp, "<Email>", "lol@lol.com");

                 

                    //yatirim adı,davet tarihi,gecerlilik tarihi

                    //  save .docx after modified
                    aDoc.Save();
                    aDoc.Close();
                    wordApp.Quit();

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

        private void ExcelSablonu(int projeID,int tedarikiciID,string tedarikciAdı,string dosyaYolu,string tip)
        {
            string projeAdı = dataGridView1.SelectedCells[2].Value.ToString();
            string projeAdres= dataGridView1.SelectedCells[3].Value.ToString();


            var app = new Microsoft.Office.Interop.Excel.Application();
            var wb1 = app.Workbooks.Add();

            if (tip=="TFiyat")
                wb1.SaveAs(dosyaYolu + "\\Teklif Fiyatları-" + projeAdı + " " + tedarikciAdı + ".xlsx");
            else if(tip=="Sartname")
                wb1.SaveAs(dosyaYolu + "\\Teknik Sartname-" + projeAdı + " " + tedarikciAdı + ".xlsx");

            wb1.Close();
          //  MessageBox.Show(dosyaYolu + "\\" + projeAdı + " " + tedarikciAdı + ".xlsx");

            if(tip=="TFiyat")
                File.Copy(Environment.CurrentDirectory +"\\Sablon\\TeklifFiyatlari.xlsx", dosyaYolu + "\\Teklif Fiyatları-" + projeAdı + " " + tedarikciAdı + ".xlsx", true);
            else if(tip=="Sartname")
                File.Copy(Environment.CurrentDirectory + "\\Sablon\\TeknikSartname.xlsx", dosyaYolu + "\\Teknik Sartname-" + projeAdı + " " + tedarikciAdı + ".xlsx", true);

            object m = Type.Missing;

            // open excel.
            // Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            // open the workbook.
            Workbook wb=null;
            if (tip=="TFiyat")
                wb = app.Workbooks.Open(dosyaYolu + "\\Teklif Fiyatları-" + projeAdı + " " + tedarikciAdı + ".xlsx", m, false, m, m, m, m, m, m, m, m, m, m, m, m);
            else if(tip=="Sartname")
                wb = app.Workbooks.Open(dosyaYolu + "\\Teknik Sartname-" + projeAdı + " " + tedarikciAdı + ".xlsx", m, false, m, m, m, m, m, m, m, m, m, m, m, m);


            // get the active worksheet. (Replace this if you need to.) 
            Worksheet ws = (Worksheet)wb.ActiveSheet;

            // get the used range. 
            Range r = (Range)ws.UsedRange;

            // call the replace method to replace instances. 
            // bool success = (bool)r.Replace("<name>", text.Trim(), XlLookAt.xlWhole, XlSearchOrder.xlByRows, true, m, m, m);

            // save and close. 
            if (tip == "TFiyat")
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("select proje_MakineEkipman_Adi,proje_MakineEkipman_TeknikOzellik,proje_MakineEkipman_Model,proje_MakineEkipman_Marka,proje_MakineEkipman_Mensei,proje_MakineEkipman_Birimi,proje_MakineEkipman_Miktar,proje_MakineEkipman_BirimFiyat,proje_MakineEkipman_ToplamFiyat from proje_Makine_Ekipman where proje_MakineEkipman_Tedarikci_ID=" + tedarikiciID + " and proje_ID=" + projeID + "", baglan);
                SqlDataReader dr = cmd.ExecuteReader();

                r.Cells[2, 3] = projeAdı;
                r.Cells[3, 3] = projeAdres;
                int k = 5;
                // Loop through the rows and output the data
                while (dr.Read())
                {
                    r.Cells[k, 1] = k - 4;
                    for (int i = 1; i < dr.FieldCount + 1; i++)
                    {
                        string value = dr[i - 1].ToString();
                        if (value.Contains(","))
                            value = "\"" + value + "\"";

                        r.Cells[k, i + 1] = value;
                    }
                    k++;
                }
                baglan.Close();
            }            else if (tip == "Sartname")
            {

                baglan.Open();
                SqlCommand cmd = new SqlCommand("select sartname_makineAdi,sartname_makineOzellik,sartname_makineBirim,sartname_makineMiktar from proje_Sartname where proje_ID="+projeID+"", baglan);
                SqlDataReader dr = cmd.ExecuteReader();

                r.Cells[2, 3] = projeAdı;
                r.Cells[3, 3] = projeAdres;
                int k = 5;
                // Loop through the rows and output the data
                while (dr.Read())
                {
                    r.Cells[k, 1] = k - 4;
                    for (int i = 1; i < dr.FieldCount + 1; i++)
                    {
                        string value = dr[i - 1].ToString();
                        if (value.Contains(","))
                            value = "\"" + value + "\"";

                        r.Cells[k, i + 1] = value;
                    }
                    k++;
                }
                baglan.Close();

            }
            // Range Line = (Range)ws.Rows[3];
            //   Line.Insert();



            wb.Save();
            app.Quit();
            app = null;


            baglan.Close();


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MakineEkipman_belgeleriOlustur(filename);
        }

        
    }
}
