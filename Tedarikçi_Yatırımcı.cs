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
using System.Runtime.InteropServices;

namespace impostemalı2
{
    public partial class Tedarikçi_Yatırımcı : Form
    {
        public Tedarikçi_Yatırımcı()
        {
            InitializeComponent();
            
        }

        SqlConnection baglan = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\impos2.mdf;Integrated Security=True;Connect Timeout=30");
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        SqlCommand komut = new SqlCommand();
        
        private void Form4_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            tedarikciGrid();
            yatirimciGrid("Yatirimci_Gercek_Kisi");
            radioButton1.Checked = true;
            SendMessage(textBox1.Handle, EM_SETCUEBANNER, 0, "TC, Ad Soyad");
            SendMessage(textBox2.Handle, EM_SETCUEBANNER, 0, "Ad, VergiNo, SicilNo");

        }
                
        public void tedarikciGrid() {

            baglan.Open();

            string göster = "select * from Tedarikciler";//veriyi kaydettikten sonra datagridviev i günceller
            SqlCommand kmt = new SqlCommand(göster, baglan);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;

            baglan.Close();
        }

        public void yatirimciGrid(string tablo) {
            baglan.Open();

            string göster = "select * from "+tablo;//veriyi kaydettikten sonra datagridviev i günceller
            SqlCommand kmt = new SqlCommand(göster, baglan);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;

            baglan.Close();
        }   

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                (dataGridView3.DataSource as DataTable).DefaultView.RowFilter =string.Format("Ad_Soyad LIKE '{0}%' OR Yatırımcı_TC LIKE '{0}%'", textBox1.Text) ;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = string.Format("Tedarikci_Ad LIKE '{0}%' OR Tedarikci_Vergi_No LIKE '{0}%' OR Tedarikci_Ticari_Sicil_No LIKE '{0}%'", textBox2.Text);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            yatirimciGrid("Yatirimci_Gercek_Kisi");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            yatirimciGrid("Yatirimci_Tuzel_Kisi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string yatirimci_Tc = dataGridView3.SelectedCells[0].Value.ToString();
            string yatirimci_Ad_Soyad = dataGridView3.SelectedCells[1].Value.ToString();
            string yaritimci_Telefon = dataGridView3.SelectedCells[2].Value.ToString();
            string yatirimci_Faks = dataGridView3.SelectedCells[3].Value.ToString();
            string yatirimci_E_Posta = dataGridView3.SelectedCells[4].Value.ToString();
            string yatirimci_Adres = dataGridView3.SelectedCells[5].Value.ToString();
            
            if (radioButton1.Checked == true) {
                YatirimciEkle yt = new YatirimciEkle(yatirimci_Tc, yatirimci_Ad_Soyad, yaritimci_Telefon, yatirimci_Faks, yatirimci_E_Posta, yatirimci_Adres);
                yt.ShowDialog();

            }
            else {

                string yatirimci_Vergi_Dairesi = dataGridView3.SelectedCells[6].Value.ToString();
                string yatirimci_Vergi_No = dataGridView3.SelectedCells[7].Value.ToString();

                YatirimciEkle yt = new YatirimciEkle(yatirimci_Tc, yatirimci_Ad_Soyad, yaritimci_Telefon, yatirimci_Faks, yatirimci_E_Posta, yatirimci_Adres,yatirimci_Vergi_Dairesi,yatirimci_Vergi_No);
                yt.ShowDialog();
            }

            if (radioButton1.Checked == true)
                yatirimciGrid("Yatirimci_Gercek_Kisi");
            else
                yatirimciGrid("Yatirimci_Tuzel_Kisi");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tedarikci_ID=Convert.ToInt32(dataGridView4.SelectedCells[0].Value.ToString());
            string tedarikci_Ad = dataGridView4.SelectedCells[1].Value.ToString();
            string tedarikci_Adres= dataGridView4.SelectedCells[2].Value.ToString();
            string tedarikci_Vergi_no=dataGridView4.SelectedCells[3].Value.ToString();
            string tedarikci_Vergi_Dairesi= dataGridView4.SelectedCells[4].Value.ToString();
            string tedarikci_Ticari_Sicil_no= dataGridView4.SelectedCells[5].Value.ToString();
            string tedarikci_Telefon= dataGridView4.SelectedCells[6].Value.ToString();
            string tedarikci_Faks= dataGridView4.SelectedCells[7].Value.ToString();
            string tedarikci_E_Posta= dataGridView4.SelectedCells[8].Value.ToString();


            TedarikciEkle td = new TedarikciEkle(tedarikci_ID, tedarikci_Ad, tedarikci_Adres, tedarikci_Vergi_no, tedarikci_Vergi_Dairesi, tedarikci_Ticari_Sicil_no, tedarikci_Telefon, tedarikci_Faks, tedarikci_E_Posta);
            td.ShowDialog();
            tedarikciGrid();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Yatırımcıyı Silmek İstediğinizden Emin Misiniz ?", "Silme Uyarısı", MessageBoxButtons.YesNo);
            
            if (onay==DialogResult.Yes)
            {
               
                try
            {


                    string silinecek_Tc;

                    string command = "";
                    if (radioButton1.Checked == true)
                    {
                        silinecek_Tc = dataGridView3.SelectedCells[0].Value.ToString();
                        command = "delete from Yatirimci_Gercek_Kisi where Yatırımcı_TC='" + silinecek_Tc + "'";
                  
                    }
                    else
                    {

                        silinecek_Tc = dataGridView3.SelectedCells[0].Value.ToString();
                        command = "delete from Yatirimci_Tuzel_Kisi where Yatırımcı_TC='" + silinecek_Tc + "'";
                       
                    }
                    //command = "delete from Yatirimci_Tuzel_Kisi where Yatırımcı_TC='123212'";
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand(command, baglan);


                    cmd.ExecuteNonQuery();

                    baglan.Close();


                }
            catch 
            {
                    MessageBox.Show("Silme Başarısız.","Silme Hatası !",MessageBoxButtons.OK);
             
            }

            }

            baglan.Close();

            if (radioButton1.Checked == true)
                yatirimciGrid("Yatirimci_Gercek_Kisi");
            else
                yatirimciGrid("Yatirimci_Tuzel_Kisi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Tedarikçiyi Silmek İstediğinizden Emin Misiniz ?", "Silme Uyarısı", MessageBoxButtons.YesNo);
            if(onay==DialogResult.Yes)
            { 
            try
            {
                    int silinecek_Tedarikci_ID=Convert.ToInt32(dataGridView4.SelectedCells[0].Value.ToString().TrimEnd());
                    baglan.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Tedarikciler where Tedarikci_ID=" + silinecek_Tedarikci_ID + " ", baglan);
                    cmd.ExecuteNonQuery();
                    baglan.Close();




                }
            catch 
            {

                    MessageBox.Show("Silme Başarısız.", "Silme Hatası !", MessageBoxButtons.OK);
                }

            }


            tedarikciGrid();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YatirimciEkle yT = new YatirimciEkle();
            yT.ShowDialog();
            if (radioButton1.Checked == true)
                yatirimciGrid("Yatirimci_Gercek_Kisi");
            else
                yatirimciGrid("Yatirimci_Tuzel_Kisi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TedarikciEkle tD = new TedarikciEkle();
            tD.ShowDialog();
            tedarikciGrid();
        }

       
    }
}
