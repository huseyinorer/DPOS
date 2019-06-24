using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using excel = Microsoft.Office.Interop.Excel;

namespace impostemalı2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-G0UGFCF\\ALAADDIN;Initial Catalog=impos2;Integrated Security=True");


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TKDK yeni = new TKDK();
            yeni.Show();
            this.Hide();
        }

        private void form6kayitno_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (comboBox1.SelectedIndex == 0)
            {
                richbox.Text = "";
                com.Text = "";
                com.Items.Clear();

                string[] makina = new string[24];
                makina[0] = "Balya Makinesi";
                makina[1] = "Balya Parçalama Makinesi";
                makina[2] = "Balya Sarma Makinesi";
                makina[3] = "Balya Yükleme Makinesi";
                makina[4] = "Balya Yükleme Tertibatlı Römork";
                makina[5] = "Ot Dağıtma Tırmığı";
                makina[6] = "Ot Toplama Tertibatlı Römork";
                makina[7] = "Ot Toplama Tırmığı";
                makina[8] = "Ot / Çayır Biçme Makinesi";
                makina[9] = "Römork";
                makina[10] = "Mısır Silaj Makinesi";
                makina[11] = "Ot Silaj Makinesi";
                makina[12] = "Silaj Paketleme Makinesi";
                makina[13] = "Yem Ezme Makinesi";
                makina[14] = "Yem Hazırlama Sistemi";
                makina[15] = "Yem Karma ve Dağıtma Makinesi";
                makina[16] = "Yem Kırma Makinesi";
                makina[17] = "Yem Kırma ve Karıştırma Makinesi";
                makina[18] = "Yem Silosu";
                makina[19] = "Traktör Ön Yükleyici";
                makina[20] = "Traktör Ön Yükleyici Ataşmanı";
                makina[21] = "Otomatik Yemleme Sistemi";
                makina[22] = "Yemlik";
                makina[23] = "Konveyör";

                com.Items.Add(makina[0]);
                com.Items.Add(makina[1]);
                com.Items.Add(makina[2]);
                com.Items.Add(makina[3]);
                com.Items.Add(makina[4]);
                com.Items.Add(makina[5]);
                com.Items.Add(makina[6]);
                com.Items.Add(makina[7]);
                com.Items.Add(makina[8]);
                com.Items.Add(makina[9]);
                com.Items.Add(makina[10]);
                com.Items.Add(makina[11]);
                com.Items.Add(makina[12]);
                com.Items.Add(makina[13]);
                com.Items.Add(makina[14]);
                com.Items.Add(makina[15]);
                com.Items.Add(makina[16]);
                com.Items.Add(makina[17]);
                com.Items.Add(makina[18]);
                com.Items.Add(makina[19]);
                com.Items.Add(makina[20]);
                com.Items.Add(makina[21]);
                com.Items.Add(makina[22]);
                com.Items.Add(makina[23]);

            }



            else if (comboBox1.SelectedIndex == 1)
            {
                richbox.Text = "";
                com.Text = "";
                com.Items.Clear();
                string[] makina = new string[11];
                makina[0] = "İlaçlama makinesi";
                makina[1] = "Havalandırma Fanı";
                makina[2] = "Hayvan Ayak Banyoluğu";
                makina[3] = "Hayvan Fırçası";
                makina[4] = "Hayvan Kantarı";
                makina[5] = "Hayvan Yatağı";
                makina[6] = "Kırkma Makinesi";
                makina[7] = "Travay";
                makina[8] = "Yatak Durak Demir Seti";
                makina[9] = "Yemlik Kilit Seti";
                makina[10] = "Çit";

                com.Items.Add(makina[0]);
                com.Items.Add(makina[1]);
                com.Items.Add(makina[2]);
                com.Items.Add(makina[3]);
                com.Items.Add(makina[4]);
                com.Items.Add(makina[5]);
                com.Items.Add(makina[6]);
                com.Items.Add(makina[7]);
                com.Items.Add(makina[8]);
                com.Items.Add(makina[9]);
                com.Items.Add(makina[10]);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                richbox.Text = "";
                com.Text = "";
                com.Items.Clear();
                string[] makina = new string[1];
                makina[0] = "Hayvan Taşıma Römorku/Dorse";
                com.Items.Add(makina[0]);
            }
            else if (comboBox1.SelectedIndex == 3)
            {

                richbox.Text = "";
                com.Text = "";
                com.Items.Clear();
                string[] makina = new string[3];
                makina[0] = "Hayvan Suluğu";
                makina[1] = "Su Tankı";
                makina[2] = "Hidrofor";

                com.Items.Add(makina[0]);
                com.Items.Add(makina[1]);
                com.Items.Add(makina[2]);
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                richbox.Text = "";
                com.Text = "";
                com.Items.Clear();
                string[] makina = new string[10];
                makina[0] = "Sıvı Gübre Dağıtma Tankeri";
                makina[1] = "Tesviye Küreği";
                makina[2] = "Gübre Dolum ve Paketleme Makinesi";
                makina[3] = "Gübre Karıştırma Makinesi";
                makina[4] = "Gübre Kurutma Tamburu";
                makina[5] = "Gübre Pompası";
                makina[6] = "Gübre Seperatörü";
                makina[7] = "Katı Gübre Dağıtma Römorku";
                makina[8] = "Mobil Gübre Sıyırıcısı (Elektrikli)";
                makina[9] = "Otomatik Gübre Sıyırıcı";

                com.Items.Add(makina[0]);
                com.Items.Add(makina[1]);
                com.Items.Add(makina[2]);
                com.Items.Add(makina[3]);
                com.Items.Add(makina[4]);
                com.Items.Add(makina[5]);
                com.Items.Add(makina[6]);
                com.Items.Add(makina[7]);
                com.Items.Add(makina[8]);
                com.Items.Add(makina[9]);

            }
            else if (comboBox1.SelectedIndex == 5)
            {
                richbox.Text = "";
                com.Text = "";
                com.Items.Clear();
                string[] makina = new string[5];
                makina[0] = "Bilgisayar";
                makina[1] = "Yazıcı / Tarayıcı";
                makina[2] = "Üretim İzleme Otomasyonu";
                makina[3] = "Sürü Yönetim Sistemi";
                makina[4] = "Hayvan Tanımlama Cihazı";

                com.Items.Add(makina[0]);
                com.Items.Add(makina[1]);
                com.Items.Add(makina[2]);
                com.Items.Add(makina[3]);
                com.Items.Add(makina[4]);

            }
            else if (comboBox1.SelectedIndex == 6)
            {
                richbox.Text = "";
                com.Text = "";
                com.Items.Clear();
                string[] makina = new string[8];



                makina[0] = "Biyogaz Sistemi";
                makina[1] = "Solar Panel";
                makina[2] = "Invertör";
                makina[3] = "İzleme Sistemi";
                makina[4] = "Solar Kablo";
                makina[5] = "Sayaç";
                makina[6] = " Şarj Regülatörü";
                makina[7] = "Enerji Depolama Sistemi";

                com.Items.Add(makina[0]);
                com.Items.Add(makina[1]);
                com.Items.Add(makina[2]);
                com.Items.Add(makina[3]);
                com.Items.Add(makina[4]);
                com.Items.Add(makina[5]);
                com.Items.Add(makina[6]);
                com.Items.Add(makina[7]);

            }
            else if (comboBox1.SelectedIndex == 7)
            {
                richbox.Text = "";
                com.Text = "";
                com.Items.Clear();
                string[] makina = new string[20];


                makina[0] = "Alarm Sistem Kiti";
                makina[1] = "Ekran";
                makina[2] = "Güvenlik Kamerası";
                makina[3] = "Kayıt Cihazı (DVR)";
                makina[4] = "Kamera - Ekran Ara Birimi";
                makina[5] = "Boru ve Fittings";
                makina[6] = "Vana";
                makina[7] = "Dedektör";
                makina[8] = "Hijyen İstasyonu";
                makina[9] = "Filtrasyon Sistemi";
                makina[10] = "Izgara / Süzgeç";
                makina[11] = "Jeneratör";
                makina[12] = "Kompresör";
                makina[13] = "Kondenser";
                makina[14] = "Regülatör";
                makina[15] = "Su Arıtma / Hazırlama Ünitesi";
                makina[16] = "Forklift(Elektrikli)";
                makina[17] = "Zararlı / Pest Kontrol Sistemi";
                makina[18] = "Pompa";
                makina[19] = "Enerji tasarrufu sağlayan sistemler";
                makina[20] = "Su motorları ve dinamolar";



                com.Items.Add(makina[0]);
                com.Items.Add(makina[1]);
                com.Items.Add(makina[2]);
                com.Items.Add(makina[3]);
                com.Items.Add(makina[4]);
                com.Items.Add(makina[5]);
                com.Items.Add(makina[6]);
                com.Items.Add(makina[7]);
                com.Items.Add(makina[8]);
                com.Items.Add(makina[9]);
                com.Items.Add(makina[10]);
                com.Items.Add(makina[11]);
                com.Items.Add(makina[12]);
                com.Items.Add(makina[13]);
                com.Items.Add(makina[14]);
                com.Items.Add(makina[15]);
                com.Items.Add(makina[16]);
                com.Items.Add(makina[17]);
                com.Items.Add(makina[18]);
                com.Items.Add(makina[19]);
                com.Items.Add(makina[20]);






            }
            else
            {
                richbox.Text = "";
                com.Text = "";
                com.Items.Clear();
            }





        }

        private void com_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com.SelectedIndex == 0)
            {
                richbox.Text = ("Tip" + Environment.NewLine + "Kapasite" + Environment.NewLine + "Balya ebadı" + Environment.NewLine + "İş genişliği" + Environment.NewLine + "Bağlayıcı sayısı" + Environment.NewLine + "Haşpaylı" + Environment.NewLine + "File sarma" + Environment.NewLine + "Gerekli traktör gücü" + Environment.NewLine + "Sıkıştırma sistemi" + Environment.NewLine + "PTO devri ");
            }

            else if (com.Text == "Balya Parçalama Makinesi")
            {
                richbox.Text = ("Tip" + Environment.NewLine + "Gerekli traktör gücü" + Environment.NewLine + "Kapasite" + Environment.NewLine + "Bıçak sayısı" + Environment.NewLine + "Tahrik sistemi" + Environment.NewLine + "PTO devri");

            }

            else if (com.Text == "Balya Sarma Makinesi")
            {
                richbox.Text = ("Tip" + Environment.NewLine + "Balya ebadı" + Environment.NewLine + "Gerekli traktör gücü" + Environment.NewLine + "Tahrik sistemi" + Environment.NewLine + "Balya tutucu" + Environment.NewLine + "Streç boyu" + Environment.NewLine + "PTO devri");

            }

            else if (com.Text == "Balya Yükleme Makinesi")
            {
                richbox.Text = ("Kapasite" + Environment.NewLine + "Taşıyıcı zincir sayısı" + Environment.NewLine + "Gerekli traktör gücü" + Environment.NewLine + "Ağırlık");

            }
            else if (com.Text == "Balya Yükleme Tertibatlı Römork")
            {
                richbox.Text = ("Tip" + Environment.NewLine + "Kapasite" + Environment.NewLine + "Boyut(ilave dahil)" + Environment.NewLine + "Lastik ebadı" + Environment.NewLine + "Dingil sayısı" + Environment.NewLine + "Toplama Sistemi");

            }
            else if (com.Text == "Ot Dağıtma Tırmığı")
            {
                richbox.Text = ("İş genişliği" + Environment.NewLine + "Rotor sayısı" + Environment.NewLine + "Kol sayısı" + Environment.NewLine + "Gerekli traktör gücü");
            }
            else if (com.Text == "Ot Toplama Tertibatlı Römork")
            {
                richbox.Text = ("Tip" + Environment.NewLine + "Kapasite" + Environment.NewLine + "Boyut(ilave dahil)" + Environment.NewLine + "Lastik ebadı" + Environment.NewLine + "Dingil sayısı" + Environment.NewLine + "Toplama Sistemi");
            }
            else if (com.Text == "Ot Toplama Tırmığı")
            {
                richbox.Text = ("Tip" + Environment.NewLine + "İş genişliği" + Environment.NewLine + "Gerekli traktör gücü" + Environment.NewLine + "Rotor sayısı" + Environment.NewLine + "Kol sayısı" + Environment.NewLine + "Tırmık sayısı");
            }
            else if (com.Text == "Ot / Çayır Biçme Makinesi")
            {
                richbox.Text = ("Tip" + Environment.NewLine + "Disk / tambur sayısı" + Environment.NewLine + "Bıçak sayısı" + Environment.NewLine + "İş genişliği" + Environment.NewLine + "Koşullandırıcı" + Environment.NewLine + "Gerekli traktör gücü" + Environment.NewLine + "PTO devri");

            }
            else if (com.Text == "Römork")
            {


                richbox.Text = ("Tip" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Boyut(ilave dahil)" + Environment.NewLine +
"Lastik ebadı" + Environment.NewLine +
"Dingil sayısı" + Environment.NewLine +
"Boşaltma yönü");
            }
            else if (com.Text == "Mısır Silaj Makinesi")
            {

                richbox.Text = ("Sıra sayısı" + Environment.NewLine +
"Güç iletimi" + Environment.NewLine +
"İş genişliği" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Gerekli traktör gücü" + Environment.NewLine +
"Kesici bıçak sayısı" + Environment.NewLine +
"Fan bıçak sayısı" + Environment.NewLine +
"PTO devri");
            }
            else if (com.Text == "Ot Silaj Makinesi")
            {

                richbox.Text = ("Güç iletimi" + Environment.NewLine +
"İş genişliği" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Gerekli traktör gücü" + Environment.NewLine +
"Bıçak sayısı" + Environment.NewLine +
"PTO devri");
            }
            else if (com.Text == "Silaj Paketleme Makinesi")
            {


                richbox.Text = ("Tip" + Environment.NewLine +
          "Tahrik sistemi" + Environment.NewLine +
          "Paket boyutu" + Environment.NewLine +
          "Kapasite" + Environment.NewLine +
          "Gerekli traktör gücü" + Environment.NewLine +
          "Konveyör" + Environment.NewLine +
          "Balya ağırlığı" + Environment.NewLine +
          "Presleme sistemi" + Environment.NewLine +
          "Paket malzemesi" + Environment.NewLine +
          "Mobil" + Environment.NewLine +
          "PTO devri");
            }
            else if (com.Text == "Yem Ezme Makinesi")
            {

                richbox.Text = ("Tahrik sistemi" + Environment.NewLine +
                 "Kapasite" + Environment.NewLine +
                     "Gerekli traktör gücü" + Environment.NewLine +
 "Devir sayısı" + Environment.NewLine +
 "Top sayısı" + Environment.NewLine +
 "Motor gücü" + Environment.NewLine +
 "PTO devri");
            }
            else if (com.Text == "Yem Hazırlama Sistemi")
            {

                richbox.Text = ("Ham madde silo sayısı" + Environment.NewLine +
       "Ham madde silo kapasiteleri" + Environment.NewLine +
       "Tip" + Environment.NewLine +
       "Kırıcı kapasitesi" + Environment.NewLine +
       "Karıştıma kapasitesi" + Environment.NewLine +
       "Karıştırma süresi" + Environment.NewLine +
       "Kırma motor gücü" + Environment.NewLine +
       "Karıştıma motor gücü" + Environment.NewLine +
       "Bıçak sayısı" + Environment.NewLine +
       "Kantar" + Environment.NewLine +
       "Helezon sayısı" + Environment.NewLine +
       "Helezon motor güçleri" + Environment.NewLine +
       "Helezon kapasiteleri" + Environment.NewLine +
       "Çuval doldurma kapasitesi" + Environment.NewLine +
       "Rasyon hazne kapasitesi");

            }
            else if (com.Text == "Yem Karma ve Dağıtma Makinesi")
            {


                richbox.Text = ("Tip" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Helezon sayısı" + Environment.NewLine +
"Bıçak sayısı" + Environment.NewLine +
"Gerekli traktör gücü" + Environment.NewLine +
"Aktarma sistemi" + Environment.NewLine +
"Yükleme kepçesi" + Environment.NewLine +
"Boşaltma yönü" + Environment.NewLine +
"Kantar" + Environment.NewLine +
"Konveyör" + Environment.NewLine +
"Dingil sayısı" + Environment.NewLine +
"Hidrolik besleme sistemi" + Environment.NewLine +
"Frezeli yükleme" + Environment.NewLine +
"PTO devri");
            }
            else if (com.Text == "Yem Kırma Makinesi")
            {

                richbox.Text = ("Tahrik sistemi" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Gerekli traktör gücü" + Environment.NewLine +
"Devir sayısı" + Environment.NewLine +
"Çekiç sayısı" + Environment.NewLine +
"Motor gücü" + Environment.NewLine +
"PTO devri");
            }
            else if (com.Text == "Yem Kırma ve Karıştırma Makinesi")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Karıştırma süresi" + Environment.NewLine +
"Kırma motor gücü" + Environment.NewLine +
"Karıştırma motor gücü" + Environment.NewLine +
            "Bıçak sayısı" + Environment.NewLine +
"Kantar");

            }
            else if (com.Text == "Yem Silosu")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Havalandırma" + Environment.NewLine +
"Yükleme sistemi" + Environment.NewLine +
"Taban tipi" + Environment.NewLine +
"Boşaltma sistemi");

            }
            else if (com.Text == "Traktör Ön Yükleyici")
            {
                richbox.Text = ("Kaldırma kapasitesi" + Environment.NewLine +
"Kumanda sistemi" + Environment.NewLine +
"Ataşman dengeleme sistemi" + Environment.NewLine +
"Anti şok sistemi" + Environment.NewLine +
"Ataşman hacmi" + Environment.NewLine +
"Ataşman boyut");
            }
            else if (com.Text == "Traktör Ön Yükleyici Ataşmanı")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
                "Kapasite" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Ağırlık");

            }
            else if (com.Text == "Otomatik Yemleme Sistemi")
            {
                richbox.Text = ("Kapasite");

            }
            else if (com.Text == "Yemlik")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Malzeme" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Ağırlık");
            }
            else if (com.Text == "Konveyör")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
                "Boy" + Environment.NewLine +
"Boru çapı/ Bant Genişliği" + Environment.NewLine +
 "Motor gücü" + Environment.NewLine +
 "Kapasite");

            }
        
        
            else if (com.Text == "İlaçlama makinesi")
            {

                richbox.Text = ("Tip" + Environment.NewLine + "Motor gücü" + Environment.NewLine + "Depo kapasitesi");





            }
            else if (com.Text == "Havalandırma Fanı")
            {

                richbox.Text = (

                "Fan gücü" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Motor gücü");


            }
            else if (com.Text == "Hayvan Ayak Banyoluğu")
            {
                richbox.Text = ("Malzeme" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Kapasite");


            }
            else if (com.Text == "Hayvan Fırçası")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Fırça adedi" + Environment.NewLine +
"Fırça çapı" + Environment.NewLine +
"Motor gücü" + Environment.NewLine +
"Sensör");

            }
            else if (com.Text == "Hayvan Kantarı")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Hassasiyet" + Environment.NewLine +
"Mobil" + Environment.NewLine +
"Malzeme");



            }
            else if (com.Text == "Hayvan Ultrason Cihazı")
            {

                richbox.Text = ("Ekran" + Environment.NewLine +
"Ekran modu" + Environment.NewLine +
"Dahili hafıza" + Environment.NewLine +
"Frekans" + Environment.NewLine +
"Prob tipi" + Environment.NewLine +
"Bilgisayara bağlanabilme");



            }
            else if (com.Text == "Hayvan Yatağı")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Katman sayısı");



            }
            else if (com.Text == "Kırkma Makinesi")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Dahili motor" + Environment.NewLine +
"Motor gücü");




            }
            else if (com.Text == "Travay")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Mobil" + Environment.NewLine +
"Kaldırma sistemi" + Environment.NewLine +
"Ağırlık");



            }
            else if (com.Text == "Yatak Durak Demir Seti")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Boru çapları" + Environment.NewLine +
"Göğüs tahtası" + Environment.NewLine +
"Ayarlanabilir");

            }
            else if (com.Text == "Yemlik Kilit Seti")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Boru çapları" + Environment.NewLine +
"Bireysel kilitleme" + Environment.NewLine +
"Kilitleme mekanizması");






            }
            else if (com.Text == "Çit")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Malzeme");





            }
       else if (com.Text == "Hayvan Taşıma Römorku/Dorse")
            {

                richbox.Text = ("Kapasite" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Dingil sayısı" + Environment.NewLine +
"Lastik ebadı" + Environment.NewLine +
"Yükleme rapması" + Environment.NewLine +
"Yemlik" + Environment.NewLine +
"Suluk" + Environment.NewLine +
"Brandalı" + Environment.NewLine +
"Havalandırma");

            }
            
      
            else if (com.Text == "Hayvan Suluğu")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Tip" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Bölme sayısı" + Environment.NewLine +
"Otomatik" + Environment.NewLine +
"Isıtıcı");
            }
            else if (com.Text == "Su Tankı")
            {

                richbox.Text = (
                    "Tip" + Environment.NewLine +
"Malzeme" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Boyut");





            }
            else if (com.Text == "Hidrofor")
            {

                richbox.Text = ("Debi" + Environment.NewLine +
"Motor gücü" + Environment.NewLine +
"Tip" + Environment.NewLine +
"Basınç");
            }
      
           else if (com.Text == "Sıvı Gübre Dağıtma Tankeri")
            {

                richbox.Text = (

                    "Kapasite" + Environment.NewLine +
"Dingil sayısı" + Environment.NewLine +
"Lastik ebadı" + Environment.NewLine +
"Vakum pompa gücü" + Environment.NewLine +
"Boşaltma sistemi" + Environment.NewLine +
"Güç gereksinimi");





            }
            else if (com.Text == "Tesviye Küreği")
            {

                richbox.Text = (
                    "Tip" + Environment.NewLine +
"İş genişliği" + Environment.NewLine +
"Kürek saç kalınlığı" + Environment.NewLine +
"Yönlendirme" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Ağırlık");
            }
            else if (com.Text == "Gübre Dolum ve Paketleme Makinesi")
            {

                richbox.Text = ("Kapasite");
            }
            else if (com.Text == "Gübre Karıştırma Makinesi")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Motor gücü" + Environment.NewLine +
"Kanat sayısı" + Environment.NewLine +
"Platform" + Environment.NewLine +
"Malzeme");

            }
            else if (com.Text == "Gübre Kurutma Tamburu")
            {

                richbox.Text = (
                    "Kapasite" + Environment.NewLine +
"Motor gücü" + Environment.NewLine +
"Tambur devri" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Malzeme");
            }
            else if (com.Text == "Gübre Pompası")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Motor gücü" + Environment.NewLine +
"Dahili karıştırıcı" + Environment.NewLine +
"Malzeme" + Environment.NewLine +
"Kapasite");




            }
            else if (com.Text == "Gübre Seperatörü")
            {

                richbox.Text = (
"Kapasite" + Environment.NewLine +
"Malzeme" + Environment.NewLine +
"Motor gücü" + Environment.NewLine +
"Platform" + Environment.NewLine +
"Kontrol panosu" + Environment.NewLine +
"Dahili gübre pompası");
            }
            else if (com.Text == "Katı Gübre Dağıtma Römorku")
            {

                richbox.Text = ("Tipi(Zincirli, helezonlu)" + Environment.NewLine +
"Kapasite(Ton)" + Environment.NewLine +
"Boyut(Exbxy)" + Environment.NewLine +
"Dingil sayısı" + Environment.NewLine +
"Lastik ebadı" + Environment.NewLine +
"Konveyör sayısı" + Environment.NewLine +
"Serpme genişliği" + Environment.NewLine +
"Güç gereksinimi" + Environment.NewLine +
"Zincir / helezon sayısı");
            }
            else if (com.Text == "Mobil Gübre Sıyırıcısı (Elektrikli)")
            {

                richbox.Text = ("Motor gücü" + Environment.NewLine +
"Otomasyon" + Environment.NewLine +
"Kapasite");





            }
            else if (com.Text == "Otomatik Gübre Sıyırıcı")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Yol sayısı" + Environment.NewLine +
"Tahrik ünite sayısı" + Environment.NewLine +
"Motor güçleri" + Environment.NewLine +
"Malzeme" + Environment.NewLine +
"Zincir / halat kalınlığı");




            }

      
           else if (com.Text == "Bilgisayar")
            {

                richbox.Text = (

                    "Tip" + Environment.NewLine +
                    "İşlemci" + Environment.NewLine +
"Ram" + Environment.NewLine +
"Disk Kapasitesi" + Environment.NewLine +
"Ekran Kartı" + Environment.NewLine +
"Ekran Boyutu");




            }
            else if (com.Text == "Yazıcı/Tarayıcı")
            {

                richbox.Text = (

"Tip" + Environment.NewLine +
"Baskı süresi" + Environment.NewLine +
"Tarama Süresi");




            }
            else if (com.Text == "Üretim İzleme Otomasyonu")
            {

                richbox.Text = (


"Kullanım amacı" + Environment.NewLine +
"Yazılım Özellikleri");


            }
            else if (com.Text == "Sürü Yönetim Sistemi")
            {

                richbox.Text = (

"Tanımlayıcı ünite sayısı" + Environment.NewLine +
"Sağımhane entegrasyonu" + Environment.NewLine +
"Hayvan kayıt bilgisi tutma" + Environment.NewLine +
"Verim kayıt bilgisi tutma" + Environment.NewLine +
"Üreme kayıt bilgisi tutma" + Environment.NewLine +
"El terminali" + Environment.NewLine +
"Kızgınlık takibi" + Environment.NewLine +
"Ayırma kapısı" + Environment.NewLine +
"Yazılım" + Environment.NewLine +
"Dahili pc" + Environment.NewLine +
"Süt takip panel sayısı" + Environment.NewLine +
"Bireysel otomatik yemleme entegrasyonu" + Environment.NewLine +
"Raporlama ve analiz sistemi" + Environment.NewLine +
"Mastit tayini" + Environment.NewLine +
"Alıcı anten sayısı" + Environment.NewLine +
"Süt ölçer sayısı" + Environment.NewLine +
"Ağırlık ölçme entegrasyon" + Environment.NewLine +
"Kantar ünitesi");



            }
            else if (com.Text == "Hayvan Tanımlama Cihazı")
            {

                richbox.Text = (

"Tip" + Environment.NewLine +
"Veri alış verişi" + Environment.NewLine +
"Malzeme");




            }
      
            else if (com.Text == "Biyogaz Sistemi")
            {

                richbox.Text = ("Kapasite");







            }
            else if (com.Text == "Solar Panel")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Panel Gücü" + Environment.NewLine +
"Panel Hücre Sayısı" + Environment.NewLine +
"Boyut");

            }
            else if (com.Text == "Invertör")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Çıkış Gücü" + Environment.NewLine +
"Montaj Tipi" + Environment.NewLine +
"Giriş Gerilimi" + Environment.NewLine +
"Çıkış Gerilimi" + Environment.NewLine +
"MPPT Sayısı");


            }
            else if (com.Text == "İzleme Sistemi")
            {

                richbox.Text = ("Bağlantı Şekli" + Environment.NewLine +
"Bağlantı Hızı" + Environment.NewLine +
"İnvertör Bağlantı Sayısı" + Environment.NewLine +
"Monitör");

            }
            else if (com.Text == "Solar Kablo")
            {

                richbox.Text = ("Solar Kablo Kesiti");


            }
            else if (com.Text == "Sayaç")
            {

                richbox.Text = ("Sayaç Tipi" + Environment.NewLine +
"Sayaç Faz Sayısı");


            }
            else if (com.Text == "Şarj Regülatörü")
            {

                richbox.Text = ("Sistem Voltajı" + Environment.NewLine +
"Maksimum Şarj Akımı");


            }
            else if (com.Text == "Enerji Depolama Sistemi")
            {

                richbox.Text = ("Kapasite" + Environment.NewLine +
"Voltaj");


            }
      
            else if (com.Text == "Alarm Sistem Kiti")
            {

                richbox.Text = (
"Kontrol Paneli" + Environment.NewLine +
"Siren Sistemi" + Environment.NewLine +
"Dijital Gösterge" + Environment.NewLine +
"Keypad Özelliği" + Environment.NewLine +
"Uzaktan Kontrol" + Environment.NewLine +
"Kayıt Sayısı");


            }
            else if (com.Text == "Ekran")
            {

                richbox.Text = ("Boyut" + Environment.NewLine +
"Görüntü Özelliği" + Environment.NewLine +
"Ses Sistemi" + Environment.NewLine +
"Ağırlık" + Environment.NewLine +
"Güç Tüketimi" + Environment.NewLine +
"Derinlik" + Environment.NewLine +
"Çözünürlük");


            }
            else if (com.Text == "Güvenlik Kamerası")
            {

                richbox.Text = ("Lens" + Environment.NewLine +
"Çalışma gerilimi" + Environment.NewLine +
"Çözünürlük" + Environment.NewLine +
"Led & Hd");


            }
            else if (com.Text == "Kayıt Cihazı (DVR)")
            {

                richbox.Text = ("Ana işlemci" + Environment.NewLine +
"İşletim sistemi" + Environment.NewLine +
"Video giriş - çıkış" + Environment.NewLine +
"Ses giriş-çıkış" + Environment.NewLine +
"Görüntü çözünürlük" + Environment.NewLine +
"Görüntü kalitesi" + Environment.NewLine +
"Network özelliği" + Environment.NewLine +
                    "Alan işgali" + Environment.NewLine +
"Güç tüketimi" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Ağırlık");


            }
            else if (com.Text == "Kamera-Ekran Ara Birimi")
            {

                richbox.Text = ("Ağ arabirimi" + Environment.NewLine +
"Azami kaydetme hızı" + Environment.NewLine +
"Azami bant genişliği" + Environment.NewLine +
"Desteklenen protokol" + Environment.NewLine +
"Kullanıcı kaydı" + Environment.NewLine +
"Kullanıcı seviyesi" + Environment.NewLine +
"Ayırma" + Environment.NewLine +
"Güvenlik yöntemi" + Environment.NewLine +
"Zaman senkranizasyonu" + Environment.NewLine +
"Azami kapasite");

            }
            else if (com.Text == "Basınçlı Yıkama Makinesi")
            {

                richbox.Text = ("Motor Gücü" + Environment.NewLine +
"Debi" + Environment.NewLine +
"Çalışma Basıncı" + Environment.NewLine +
"Ağırlık" + Environment.NewLine +
"Deterjan Tankı" + Environment.NewLine +
"Hortum Uzunluğu" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Pompa Tipi");


            }
            else if (com.Text == "Boru ve Fittings")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Boru çapı" + Environment.NewLine +
"Basınç" + Environment.NewLine +
"Boru Et Kalınlığı" + Environment.NewLine +
"Boru iç çap" + Environment.NewLine +
"Boru dış çap");

            }
            else if (com.Text == "Vana")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Çap" + Environment.NewLine +
"Tip");


            }
            else if (com.Text == "Dedektör")
            {

                richbox.Text = ("Tip");


            }
            else if (com.Text == "Hijyen İstasyonu")
            {

                richbox.Text = ("Paspas Rampası" + Environment.NewLine +
"Malzeme" + Environment.NewLine +
"Paspas Tavası" + Environment.NewLine +
"Tutunma Barı" + Environment.NewLine +
"Turnike Sistemi" + Environment.NewLine +
"Turnike Kol Sayısı" + Environment.NewLine +
"Dezenfektasyon");


            }
            else if (com.Text == "Filtrasyon Sistemi")
            {

                richbox.Text = ("Kapasite" + Environment.NewLine +
"Malzeme" + Environment.NewLine +
"Ebat" + Environment.NewLine +
"Ultrafiltrasyon(UF) sistemi" + Environment.NewLine +
                    "Nano filtrasyon(NF) sistemi" + Environment.NewLine +
"Ters ozmoz(RO) sistemi" + Environment.NewLine +
"Membran sistemleri ünitesi" + Environment.NewLine +
"Otomotik cip temizlik" + Environment.NewLine +
"Basınçlı yıkama" + Environment.NewLine +
"Yağ ve çöp ayırıcı" + Environment.NewLine +
"Pompa gücü" + Environment.NewLine +
"PLC Kontroli");


            }
            else if (com.Text == "Izgara/Süzgeç")
            {

                richbox.Text = ("Malzeme Türü" + Environment.NewLine +
"Boyut" + Environment.NewLine +
"Tip");

            }
            else if (com.Text == "Jeneratör")
            {

                richbox.Text = ("Silindir Sayısı" + Environment.NewLine +
"Silindir Hacmi" + Environment.NewLine +
"Su Kapasitesi" + Environment.NewLine +
"Yakıt Tüketimi" + Environment.NewLine +
"Prime Güç" + Environment.NewLine +
"Standby gücü" + Environment.NewLine +
"Kabin" + Environment.NewLine +
"Otomatik Transfer Panosu" + Environment.NewLine +
"Governor Tipi");


            }
            else if (com.Text == "Kompresör")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Güç" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Soğutucu Gaz" + Environment.NewLine +
"Silindir Hacmi" + Environment.NewLine +
"Basma Hacmi");


            }
            else if (com.Text == "Kondenser")
            {

                richbox.Text = ("Kapasite" + Environment.NewLine +
"Fan tipi" + Environment.NewLine +
"Motor gücü" + Environment.NewLine +
"Fan çapı" + Environment.NewLine +
"Isı transfer yüzeyi" + Environment.NewLine +
"Fan sayısı" + Environment.NewLine +
"Tatve");

            }
            else if (com.Text == "Regülatör")
            {

                richbox.Text = ("Ağırlık" + Environment.NewLine +
"Güç" + Environment.NewLine +
"Malzeme" + Environment.NewLine +
"Boyut");

            }
            else if (com.Text == "Su Arıtma/Hazırlama Ünitesi")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Arıtma kalitesi" + Environment.NewLine +
"Çalışma basıncı" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Tip" + Environment.NewLine +
"Uv dozajı" + Environment.NewLine +
"Uv lamba ömrü");

            }
            else if (com.Text == "Forklift (Elektrikli)")
            {

                richbox.Text = ("Akü voltaj kapasitesi" + Environment.NewLine +
"Yürüyüş motor gücü" + Environment.NewLine +
"Kaldırma motor gücü" + Environment.NewLine +
"Forklift uzunluğu" + Environment.NewLine +
"Forklift genişliği" + Environment.NewLine +
"Forklift boyu" + Environment.NewLine +
"Forklift ağırlığı" + Environment.NewLine +
"Asansör tipi" + Environment.NewLine +
"Asansör kaldırma yüksekliği" + Environment.NewLine +
"Serbest kaldırma yüksekliği" + Environment.NewLine +
"Asansör açık yüksekliği" + Environment.NewLine +
"Asansör kapalı yüksekliği" + Environment.NewLine +
"Çatal ölçüsü" + Environment.NewLine +
"Lastik tipi" + Environment.NewLine +
"Lastik sayısı" + Environment.NewLine +
"Kaldırma kapasitesi");

            }
            else if (com.Text == "Zararlı/Pest Kontrol Sistemi")
            {

                richbox.Text = ("Malzeme" + Environment.NewLine +
"Tip" + Environment.NewLine +
"Ağırlık" + Environment.NewLine +
"Ebat" + Environment.NewLine +
"Güç" + Environment.NewLine +
"Kapasite" + Environment.NewLine +
"Etki alanı" + Environment.NewLine +
"Ses şiddeti");

            }
            else if (com.Text == "Pompa")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Gövde Malzeme" + Environment.NewLine +
"Güç" + Environment.NewLine +
"Basma yüksekliği" + Environment.NewLine +
"Batma derinliği" + Environment.NewLine +
"Devir sayısı");

            }
            else if (com.Text == "Enerji tasarrufu sağlayan sistemler")
            {

                richbox.Text = ("Tip");


            }
            else if (com.Text == "Su motorları ve dinamolar")
            {

                richbox.Text = ("Tip" + Environment.NewLine +
"Basma yüksekliği" + Environment.NewLine +
"Güç" + Environment.NewLine +
"Devir sayısı");

            }
            else
            {
                MessageBox.Show("Makine Seçin...! .", "UYARI!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            if (txtmarka.Text != "" 
                )
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into marka (marka) Values ('" + txtmarka.Text.ToString() + "')", baglan);
                
                komut.ExecuteNonQuery();

                


                baglan.Close();

                

                MessageBox.Show("KAYIT TAMAMLANDI.", "mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtmarka.Text = "";
                


            }

            else
            {
                MessageBox.Show("Marka Giriniz...!", "UYARI!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglan.Open();

            SqlDataAdapter Da = new SqlDataAdapter("Select * from marka", baglan);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);

            cmmarka_model.DataSource = Dt;
            cmmarka_model.DisplayMember = ("marka");
            cmmarka_model.ValueMember = "id";
            baglan.Close();

        }


        private void btkaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            try
            {

                if(form6kayitno.Text!=""&&
                    comboBox1.Text != "" &&
                    cmmarka_model.Text != "" &&
                    comboBox2.Text != "" &&
                    com.Text != "" &&
                    richbox.Text != "" &&
                    cmmensei.Text != "" &&
                    txtadet.Text != "" &&
                    txtbirimfiyat.Text != "" &&
                    txttoplamfiyat.Text != "" )
                {
                    SqlCommand komut = new SqlCommand("insert into Makine_alımı1012 (Kayıt_no,Yatırım_türü,Marka,Model,Makine_adı,Makine_özellikleri,Mensei,Adet,Birim_fiyat,Toplam_fiyat) Values ('" + form6kayitno.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + cmmarka_model.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + com.Text.ToString() + "','" + richbox.Text.ToString() + "','" + cmmensei.Text.ToString() + "','" + txtadet.Text.ToString() + "','" + txtbirimfiyat.Text.ToString() + "','" + txttoplamfiyat.Text.ToString() + "')", baglan);

                    komut.ExecuteNonQuery();

                    string getir = "select * from Makine_alımı1012";//veriyi kaydettikten sonra datagridviev i günceller
                    SqlCommand kmt = new SqlCommand(getir, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(kmt);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    form6kayitno.Text = "";
                    comboBox1.Text = "";
                    cmmarka_model.Text = "";
                    comboBox2.Text = "";
                    com.Text = "";
                    richbox.Text = "";
                    cmmensei.Text = "";
                    txtadet.Text = "";
                    txtbirimfiyat.Text = "";
                    txttoplamfiyat.Text= "";
                    
                    MessageBox.Show("KAYIT TAMAMLANDI.", "mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("BOŞLUKLARI DOLDURUNUZ!", "mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               

            }
            catch (Exception)
            {

                MessageBox.Show("Bu kimlik ile kayıtlı kullanıcı daha önce eklendi. Lütfen kullanıcı kimliğini kontrol edin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglan.Close();

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            baglan.Open();
            SqlDataAdapter Da = new SqlDataAdapter("Select * from marka", baglan);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);

            cmmarka_model.DataSource = Dt;
            cmmarka_model.DisplayMember = ("marka");
            cmmarka_model.ValueMember = "id";
            baglan.Close();

            baglan.Open();
            SqlDataAdapter Db = new SqlDataAdapter("Select * from model", baglan);
            DataTable Dy = new DataTable();
            Db.Fill(Dy);

            comboBox2.DataSource = Dy;
            comboBox2.DisplayMember = "model";
            comboBox2.ValueMember = "id";
            baglan.Close();
            comboBox2.Text = "";
            cmmarka_model.Text = "";

        }

        private void bthesapla_Click(object sender, EventArgs e)
        {
            if(txtadet.Text!=""&&
                txtbirimfiyat.Text!="")
            {
                double sayi1 = Convert.ToDouble(txtadet.Text);
                double sayi2 = Convert.ToDouble(txtbirimfiyat.Text);
                double carpim = sayi1 * sayi2;
                txttoplamfiyat.Text = Convert.ToString(carpim);
            }
            else
            {
                MessageBox.Show("Adet ve Birim Fiyat Giriniz.!", "UYARI!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_model_ekle_Click(object sender, EventArgs e)
        {
            
            if (txtmodelekle.Text != "")
            {
                baglan.Open();
               
                 SqlCommand komut = new SqlCommand("insert into model (model) Values ('" + txtmodelekle.Text.ToString() + "')", baglan);

             
                komut.ExecuteNonQuery();

              

                baglan.Close();

                MessageBox.Show("KAYIT TAMAMLANDI.", "mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmodelekle.Text = "";
                
            }
            else
            {
                MessageBox.Show("Model Girin.!!!", "UYARI!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglan.Open();
            SqlDataAdapter Db = new SqlDataAdapter("Select * from model", baglan);
            DataTable Dy = new DataTable();
            Db.Fill(Dy);

            comboBox2.DataSource = Dy;
            comboBox2.DisplayMember = "model";
            comboBox2.ValueMember = "id";
            baglan.Close();



        }

        private void cmmarka_model_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            TKDK yeni = new TKDK();
            yeni.Show();
            this.Hide();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

                Microsoft.Office.Interop.Excel.Application uygulama = new Microsoft.Office.Interop.Excel.Application();
                uygulama.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook kitap = uygulama.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sayfa1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
            Microsoft.Office.Interop.Excel.Worksheet sayfa2 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];

            int StartCol = 1;

            int StartRow = 1; 

            for (int j = 0; j < dataGridView1.Columns.Count; j++)

            {

                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sayfa1.Cells[StartRow, StartCol + j];

                myRange.Value2 = dataGridView1.Columns[j].HeaderText;

            }

            StartRow++;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)

            {

                for (int j = 0; j < dataGridView1.Columns.Count; j++)

                {

                    try

                    {

                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sayfa1.Cells[StartRow + i, StartCol + j];

                        myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;

                    }

                    catch

                    {

                        ;

                    }

                } 

            }


           




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            string getir = "select * from Makine_alımı1012";//veriyi kaydettikten sonra datagridviev i günceller
            SqlCommand kmt = new SqlCommand(getir, baglan);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application(); // yeni bir word nesnesi oluşturduk
word.Visible = true; // açılan word dosyasının görünürlüğünü true yapmamız gerekir.
Microsoft.Office.Interop.Word.Document wordDocument; // bir word dokümanı oluşturduk
object wordObj = System.Reflection.Missing.Value;
wordDocument = word.Documents.Add(ref wordObj);
//yazı özelliklerini ayarladığmız kısım
word.Selection.TypeText("adqwdqwdqwd qweqwdqdq qeqweqweqwdqwdqdq sqdqwdqdasdaddasdwdqwdawd");
word.Selection.Font.Size = 24;
word.Selection.Font.Name = "Arial";
word = null;
        }
    }
}

