using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace impostemalı2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void com_SelectedIndexChanged(object sender, EventArgs e)
        {

//            Silaj muamele, çiftlikte hayvan yemi hazırlama, muamele, dağıtma ve depolama sistemleri için makine ve ekipman satın alınması

//"Balya Makinesi

//Tip
//Kapasite
//Balya ebadı
//İş genişliği
//Bağlayıcı sayısı
//Haşpaylı
//File sarma
//Gerekli traktör gücü
//Sıkıştırma sistemi
//PTO devri



//"Balya Parçalama Makinesi

//Tip
//Gerekli traktör gücü
//Kapasite
//Bıçak sayısı
//Tahrik sistemi
//PTO devri
//Balya Sarma Makinesi
//Tip
//Balya ebadı
//Balya sarma süresi
//Gerekli traktör gücü
//Tahrik sistemi
//Balya tutucu
//Streç boyu
//PTO devri


//"Balya Yükleme Makinesi

//Kapasite
//Alıcı zincir sayısı
//Taşıyıcı zincir sayısı
//Gerekli traktör gücü
//Ağırlık


//"Balya Yükleme Tertibatlı Römork

//Tip
//Kapasite
//Boyut(ilave dahil)
//Lastik ebadı
//Dingil sayısı
//Toplama Sistemi


//"Ot Dağıtma Tırmığı

//İş genişliği
//Rotor sayısı
//Kol sayısı
//Gerekli traktör gücü


//"Ot Toplama Tertibatlı Römork

//Tip
//Kapasite
//Boyut(ilave dahil)
//Lastik ebadı
//Dingil sayısı
//Toplama Sistemi

                
//Ot Toplama Tırmığı

//Tip
//İş genişliği
//Gerekli traktör gücü
//Rotor sayısı
//Kol sayısı
//Tırmık sayısı


//Ot / Çayır Biçme Makinesi

//Tip
//Disk / tambur sayısı
//  Bıçak sayısı
//  İş genişliği
//  Koşullandırıcı
//Gerekli traktör gücü
//PTO devri


//Römork

//Tip
//Kapasite
//Boyut(ilave dahil)
//Lastik ebadı
//Dingil sayısı
//Boşaltma yönü


//Mısır Silaj Makinesi

//Sıra sayısı
//Güç iletimi
//İş genişliği
//Kapasite
//Gerekli traktör gücü
//Kesici bıçak sayısı
//Fan bıçak sayısı
//PTO devri


//Ot Silaj Makinesi

//Güç iletimi
//İş genişliği
//Kapasite
//Gerekli traktör gücü
//Bıçak sayısı
//PTO devri


//Silaj Paketleme Makinesi

//Tip
//Tahrik sistemi
//Paket boyutu
//Kapasite
//Gerekli traktör gücü
//Konveyör
//Balya ağırlığı
//Presleme sistemi
//Paket malzemesi
//Mobil
//PTO devri


//Yem Ezme Makinesi

//Tahrik sistemi
//Kapasite
//Gerekli traktör gücü
//Devir sayısı
//Top sayısı
//Motor gücü
//PTO devri


//Yem Hazırlama Sistemi

//Ham madde silo sayısı
//Ham madde silo kapasiteleri
//Tip
//Kırıcı kapasitesi
//Karıştıma kapasitesi
//Karıştırma süresi
//Kırma motor gücü
//Karıştıma motor gücü
//Bıçak sayısı
//Kantar
//Helezon sayısı
//Helezon motor güçleri
//Helezon kapasiteleri
//Çuval doldurma kapasitesi
//Rasyon hazne kapasitesi


//Yem Karma ve Dağıtma Makinesi

//Tip
//Kapasite
//Helezon sayısı
//Bıçak sayısı
//Gerekli traktör gücü
//Aktarma sistemi
//Yükleme kepçesi
//Boşaltma yönü
//Kantar
//Konveyör
//Dingil sayısı
//Hidrolik besleme sistemi
//Frezeli yükleme
//PTO devri


//Yem Kırma Makinesi

//Tahrik sistemi
//Kapasite
//Gerekli traktör gücü
//Devir sayısı
//Çekiç sayısı
//Motor gücü
//PTO devri


//Yem Kırma ve Karıştırma Makinesi

//Tip
//Kapasite
//Karıştırma süresi
//Kırma motor gücü
//Karıştırma motor gücü
//Bıçak sayısı
//Kantar


//Yem Silosu

//Malzeme
//Kapasite
//Havalandırma
//Yükleme sistemi
//Taban tipi
//Boşaltma sistemi


//Traktör Ön Yükleyici

//Kaldırma kapasitesi
//Minimum kaldırma yüksekliği
//Kumanda sistemi
//Ataşman dengeleme sistemi
//Anti şok sistemi
//Ataşman hacmi
//Ataşman boyut


//Traktör Ön Yükleyici Ataşmanı

//Tip
//Kapasite
//Boyut
//Ağırlık


//Otomatik Yemleme Sistemi

//Kapasite


//Yemlik

//Tip
//Malzeme
//Kapasite
//Boyut
//Ağırlık


//Konveyör

//Tip
//Boy
//Boru çapı / Bant Genişliği
//  Motor gücü
//  Kapasite


//Manuel Süt Sağım Makinesi

//Tip
//Güğüm(kova) sayısı
//Vakum pompa kapasitesi
//Güğüm kapasitesi
//Sağım başlık sayısı
//Süt pençe kapasitesi




//Sağım odası tesisleri, süt soğutma ve depolama ile çiftlik içi süt taşıma için makine ve ekipman satın alınması


//Otomatik Süt Sağım Sistemi

//Tip
//Sağım başlık sayısı                
//Vakum pompa kapasitesi
//Süt pompa kapasitesi
//Süt pençe kapasitesi
//Vakum tank kapasitesi
//Yıkama tank kapasitesi
//Süt boru hattı malzeme
//Süt boru hattı çapı
//Vakum boru hattı malzeme
//Vakum boru hattı çapı
//Yıkama boru hattı malzeme
//Yıkama boru hattı çapı
//Süt ön toplayıcı kapasite
//Pulsatör tipi
//Süt ölçüm
//Sağım durak sayısı
//Sağım durak malzeme
//Sürü yönetim sistemi entegrasyon
//Otomatik yıkama sistemi
//Otomatik başlık çıkarıcı
//Yıkama sistem tipi


//Süt Sağım Robotu

//Kapasite


//Süt Soğutma ve Depolama Tankı

//Tip
//Kapasite
//Soğutma Sınıfı
//Otomatik yıkama sistemi
//Kantar
//Malzeme
//Yalıtım malzemesi
//Kompresör gücü
//Cidar sayısı


//Eşanjör

//Kapasite
//Giriş / çıkış sıcaklığı
//  Plaka sayısı
//  Plaka malzeme
//  Eşanjör malzeme
//  Soğutma sistemi


//  Transfer Pompası

//  Kapasite
//Motor gücü
//Pompa malzeme
//Muhafaza
//Muhafaza malzeme


//Isı Geri Kazanım Sistemi

//Kapasite


//Termosifon

//Tip
//Malzeme
//Kapasite
//Güç
//Sıcaklık Aralığı


//Evye

//Tip
//Malzeme
//Ağırlık
//Boyut


//Somatik Hücre Analiz Cihazı

//Ölçüm aralığı
//Ölçme süresi
//Süt örnek miktarı
//Doğruluk oranı
//Güç tüketimi


//Süt Akış Ölçüm Cihazı

//Ölçüm Hassasiyeti


//Süt Analiz Cihazı

//Ölçme süresi
//Ölçüm parametreleri
//Bilgisayar entegrasyonu
//Hafıza
//Otomatik temizleme sistemi


//Köpük Üretim Makinesi

//Kompresör
//Tank kapasitesi
//Tabanca sistemi
//Kompresör gücü


//Paket Tip Atık Su Arıtma Sistemi

//Kapasite


//Hayvan Suluğu

//Malzeme
//Tip
//Boyut
//Kapasite
//Bölme sayısı
//Otomatik
//Isıtıcı


//Su Tankı

//Tip
//Malzeme
//Kapasite
//Boyut


//Hidrofor

//Debi
//Motor gücü
//Tip
//Basınç

//Kendi sağım sistemlerini temizlemek için su kullanan çiftlikler için, atık ve atıksu işleme tesisleri için makine ve ekipman satın alınması

//Sulama sistemleri için makine ve ekipman satın alınması

//İlaçlama makinesi

//Tip
//Motor gücü
//Depo kapasitesi


//Havalandırma Fanı

//Fan gücü
//Boyut
//Motor gücü


//Hayvan Ayak Banyoluğu

//Malzeme
//Boyut
//Kapasite


//Hayvan Fırçası

//Tip
//Fırça adedi
//Fırça çapı
//Motor gücü
//Sensör


//Hayvan Kantarı

//Tip
//Boyut
//Kapasite
//Hassasiyet
//Mobil
//Malzeme


//Buzağı Kulubesi

//Malzeme
//Boyut
//Padok boyutu
//Havalandırma
//Biberon
//Yemlik
//Suluk


//Buzağı Mama Hazırlama Makinesi

//Kapasite
//Motor gücü
//Mobil
//Dağıtım sistemi


//Doğum Krikosu

//Malzeme
//Boyut
//Ağırlık


//Hayvan Ultrason Cihazı

//Ekran
//Ekran modu
//Dahili hafıza
//Frekans
//Prob tipi
//Bilgisayara bağlanabilme


                                
                
//Hayvan Yatağı

//Malzeme
//Boyut
//Katman sayısı


//Kırkma Makinesi

//Tip
//Dahili motor
//Motor gücü


//Kızgınlık Dedektörü

//Ekran
//Ölçüm aralığı
//Prob uzunluğu
//Güç kaynağı


//Travay

//Malzeme
//Boyut
//Mobil
//Kaldırma sistemi
//Ağırlık


//Hayvan Taşıma Römorku / Dorse

//Kapasite
//Boyut
//Dingil sayısı
//Lastik ebadı
//Yükleme rapması
//Yemlik
//Suluk
//Brandalı
//Havalandırma


//Mastit Dedektörü

//Ölçüm aralığı


//Yatak Durak Demir Seti

//Malzeme
//Boyut
//Boru çapları
//Göğüs tahtası
//Ayarlanabilir


//Yemlik Kilit Seti

//Malzeme
//Boyut
//Boru çapları
//Bireysel kilitleme
//Kilitleme mekanizması


//Çit

//Tip
//Boyut
//Malzeme


//Sıvı Gübre Dağıtma Tankeri

//Kapasite
//Dingil sayısı
//Lastik ebadı
//Vakum pompası
//Vakum pompa gücü
//Boşaltma sistemi
//Güç gereksinimi


//Tesviye Küreği

//Tip
//İş genişliği
//Kürek saç kalınlığı
//Yönlendirme
//Boyut
//Ağırlık


//Gübre Dolum ve Paketleme Makinesi

//Kapasite


//Gübre Karıştırma Makinesi

//Tip
//Motor gücü
//Kanat sayısı
//Platform
//Malzeme


//Gübre Kurutma Tamburu

//Motor gücü
//Tambur devri
//Boyut
//Malzeme


//Gübre Pompası

//Tip
//Motor gücü
//Dahili karıştırıcı
//Malzeme
//Kapasite


//Gübre Seperatörü

//Kapasite
//Malzeme
//Motor gücü
//Platform
//Kontrol panosu


//Katı Gübre Dağıtma Römorku

//Tipi(Zincirli, helezonlu)
//Kapasite(Ton)
//Boyut(Exbxy)
//Dingil sayısı
//Lastik ebadı
//Konveyör sayısı
//Serpme genişliği
//Güç gereksinimi
//Zincir / helezon sayısı


//Mobil Gübre Sıyırıcısı(Elektrikli)

//IPARD 2 28 / 12 / 2015
//Motor gücü
//Otomasyon
//Kapasite


//Otomatik Gübre Sıyırıcı

//Tip
//Boyut
//Yol sayısı
//Tahrik ünite sayısı
//Motor güçleri
//Malzeme
//Zincir / halat kalınlığı


//Bilgisayar

//Tip
//İşlemci
//Ram
//Disk Kapasitesi
//Ekran Kartı
//Ekran Boyutu


//Yazıcı / Tarayıcı

//Tip
//Baskı süresi
//Tarama Süresi


//Üretim İzleme Otomasyonu

//Kullanım amacı
//Yazılım Özellikleri


//Sürü Yönetim Sistemi

//Tanımlayıcı ünite sayısı
//Sağımhane entegrasyonu
//Hayvan kayıt bilgisi tutma
//Verim kayıt bilgisi tutma
//Üreme kayıt bilgisi tutma
//El terminali
//Kızgınlık takibi
//Ayırma kapısı
//Yazılım
//Dahili pc
//Süt takip panel sayısı
//Bireysel otomatik yemleme entegrasyonu
//Raporlama ve analiz sistemi
//Mastit tayini
//Alıcı anten sayısı
//Süt ölçer sayısı
//Ağırlık ölçme entegrasyon
//Kantar ünitesi


//Hayvan Tanımlama Cihazı

//Tip
//Veri alış verişi
//Malzeme



//Solar Panel

//Tip
//Panel Gücü
//Panel Hücre Sayısı
//Boyut


//Invertör

//Tip
//Çıkış Gücü
//Montaj Tipi
//Giriş Gerilimi
//Çıkış Gerilimi
//MPPT Sayısı


//İzleme Sistemi

//Bağlantı Şekli
//Bağlantı Hızı
//İnvertör Bağlantı Sayısı
//Monitör


//Solar Kablo

//Solar Kablo Kesiti


//Sayaç

//Sayaç Tipi
//Sayaç Faz Sayısı


//Şarj Regülatörü

//Sistem Voltajı
//Maksimum Şarj Akımı


//Enerji Depolama Sistemi

//Kapasite
//Voltaj


//Alarm Sistem Kiti

//Kontrol Paneli
//Siren Sistemi
//Dijital Gösterge
//Keypad Özelliği
//Uzaktan Kontrol
//Kayıt Sayısı


//Ekran

//Boyut
//Görüntü Özelliği
//Ses Sistemi
//Ağırlık
//Güç Tüketimi
//Derinlik
//Çözünürlük


//Güvenlik Kamerası

//Lens
//Çalışma gerilimi
//Çözünürlük
//Led & Hd


//Kayıt Cihazı(DVR)

//Ana işlemci
//İşletim sistemi
//Video giriş - çıkış
//Ses giriş - çıkış
//Görüntü çözünürlük
//Görüntü kalitesi
//Network özelliği
//Alan işgali
//Güç tüketimi
//Boyut
//Ağırlık


//Kamera - Ekran Ara Birimi

//Ağ arabirimi
//Azami kaydetme hızı
//Azami bant genişliği
//Desteklenen protokol
//Kullanıcı kaydı
//Kullanıcı seviyesi
//Ayırma
//Güvenlik yöntemi
//Zaman senkranizasyonu
//Azami kapasite


//Basınçlı Yıkama Makinesi

//Motor Gücü
//Debi
//Çalışma Basıncı
//Ağırlık
//Deterjan Tankı
//Hortum Uzunluğu
//Boyut
//Pompa Tipi


//Boru ve Fittings

//Malzeme
//Boru çapı
//Basınç
//Boru Et Kalınlığı
//Boru iç çap
//Boru dış çap


//Vana

//Malzeme
//Çap
//Tip


//Dedektör

//Tip


//Hijyen İstasyonu

//Paspas Rampası
//Malzeme
//Paspas Tavası
//Tutunma Barı
//Turnike Sistemi
//Turnike Kol Sayısı
//Dezenfektasyon


//Filtrasyon Sistemi

//Kapasite
//Malzeme
//Ebat
//Ultrafiltrasyon(UF) sistemi
//Nano filtrasyon(NF) sistemi
//Ters ozmoz(RO) sistemi
//Membran sistemleri ünitesi
//Otomotik cip temizlik
//Basınçlı yıkama
//Yağ ve çöp ayırıcı
//Pompa gücü
//PLC Kontroli


//Izgara / Süzgeç

//Malzeme Türü
//Boyut
//Tip


//Jeneratör

//Silindir Sayısı
//Silindir Hacmi
//Su Kapasitesi
//Yakıt Tüketimi
//Prime Güç
//Standby gücü
//Kabin
//Otomatik Transfer Panosu
//Governor Tipi


//Kompresör

//Tip
//Güç
//Kapasite
//Soğutucu Gaz
//Silindir Hacmi
//Basma Hacmi


//Kondenser

//Kapasite
//Fan tipi
//Motor gücü
//Fan çapı
//Isı transfer yüzeyi
//Fan sayısı
//Tatve


//Regülatör

//Ağırlık
//Güç
//Malzeme
//Boyut


//Su Arıtma / Hazırlama Ünitesi

//Malzeme
//Arıtma kalitesi
//Çalışma basıncı
//Kapasite
//Tip
//Uv dozajı
//Uv lamba ömrü


//Forklift(Elektrikli)

//Akü voltaj kapasitesi
//Yürüyüş motor gücü
//Kaldırma motor gücü
//Forklift uzunluğu
//Forklift genişliği
//Forklift boyu
//Forklift ağırlığı
//Asansör tipi
//Asansör kaldırma yüksekliği
//Serbest kaldırma yüksekliği
//Asansör açık yüksekliği
//Asansör kapalı yüksekliği
//Çatal ölçüsü
//Lastik tipi
//Lastik sayısı
//Kaldırma kapasitesi


//Zararlı / Pest Kontrol Sistemi

//Malzeme
//Tip
//Ağırlık
//Ebat
//Güç
//Kapasite
//Etki alanı
//Ses şiddeti


//Pompa

//Tip
//Gövde Malzeme
//Güç
//Basma yüksekliği
//Batma derinliği
//Devir sayısı


//Enerji tasarrufu sağlayan sistemler

//Tip


//Su motorları ve dinamolar

//Tip
//Basma yüksekliği
//Güç
//Devir sayısı


        }
    }
}
