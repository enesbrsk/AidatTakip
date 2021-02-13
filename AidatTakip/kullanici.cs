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

namespace AidatTakip
{
    public partial class kullanici : Form
    {
        SqlCommand komut;
        SqlDataAdapter da;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");

        public kullanici()
        {
            InitializeComponent();
        }
        void KullaniciGetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select * From dt_Login", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into dt_Login (Ad,Soyad,TelNo,DogumT,TcNo,KullaniciAdi,Sifre,Resim) values (@Ad,@Soyad,@TelNo,@DogumT,@TcNo,@KullaniciAdi,@Sifre,@Resim)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Ad", txt_ad.Text);
            komut.Parameters.AddWithValue("@Soyad", txt_soyad.Text);
            komut.Parameters.AddWithValue("@TelNo", txt_tel.Text);
            komut.Parameters.AddWithValue("@DogumT", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@TcNo", txt_tc.Text);
            komut.Parameters.AddWithValue("@KullaniciAdi",txt_kullanici.Text);
            komut.Parameters.AddWithValue("@Sifre", txt_sifre.Text);
            komut.Parameters.AddWithValue("@Resim", txt_resim.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            KullaniciGetir();

            MessageBox.Show("Kullanıcı Kayıt İşlemi Başarılı");
        }

        private void kullanici_Load(object sender, EventArgs e)
        {
            KullaniciGetir();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon No";
            dataGridView1.Columns[4].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[5].HeaderText = "TC No";
            dataGridView1.Columns[6].HeaderText = "Kullanıcı Adı";
            dataGridView1.Columns[7].HeaderText = "Şifre";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txt_resim.Text = openFileDialog1.FileName;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            
            txt_ad.Text = dataGridView1.Rows[select].Cells[1].Value.ToString();
            txt_soyad.Text = dataGridView1.Rows[select].Cells[2].Value.ToString();
            txt_tel.Text = dataGridView1.Rows[select].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[select].Cells[4].Value.ToString();
            txt_tc.Text = dataGridView1.Rows[select].Cells[5].Value.ToString();
            txt_kullanici.Text = dataGridView1.Rows[select].Cells[6].Value.ToString();
            txt_sifre.Text = dataGridView1.Rows[select].Cells[7].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[select].Cells[8].Value.ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From dt_Login Where KullaniciAdi=@KullaniciAdi";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@KullaniciAdi", txt_kullanici.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            KullaniciGetir();

            MessageBox.Show("Kullanıcı Silme İşlemi Başarılı");
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
