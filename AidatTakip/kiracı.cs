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
    public partial class kiracı : Form
    {
        public kiracı()
        {
            InitializeComponent();
        }
        SqlCommand komut;
        SqlDataAdapter da;

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
        private void kiracı_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * From dt_BinaT ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["Binaİsmi"]);
            }
            baglanti.Close();
            kiraciGetir();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Bina İsmi";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].HeaderText = "Telefon No";
            dataGridView1.Columns[5].HeaderText = "Daire No";
            dataGridView1.Columns[6].HeaderText = "Kat No";
            dataGridView1.Columns[7].HeaderText = "Doğum Tarihi";

        }
        void kiraciGetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select * From dt_kiraci", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into dt_kiraci (Binaİsmi,Ad,Soyad,TelNo,DaireNo,KatNo,DogumT,Resim) values (@Binaİsmi,@Ad,@Soyad,@TelNo,@DaireNo,@KatNo,@DogumT,@Resim)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Binaİsmi", comboBox1.Text);
            komut.Parameters.AddWithValue("@Ad", txt_ad.Text);
            komut.Parameters.AddWithValue("@Soyad", txt_soyad.Text);
            komut.Parameters.AddWithValue("@TelNo", txt_tel.Text);
            komut.Parameters.AddWithValue("@DaireNo", txt_daire.Text);
            komut.Parameters.AddWithValue("@KatNo", txt_kat.Text);
            komut.Parameters.AddWithValue("@DogumT", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@Resim", txt_resim.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            kiraciGetir();

            MessageBox.Show("Kayıt İşlemi Başarılı");

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
            comboBox1.Text = dataGridView1.Rows[select].Cells[1].Value.ToString();
            txt_ad.Text = dataGridView1.Rows[select].Cells[2].Value.ToString();
            txt_soyad.Text = dataGridView1.Rows[select].Cells[3].Value.ToString();
            txt_tel.Text = dataGridView1.Rows[select].Cells[4].Value.ToString();
            txt_daire.Text = dataGridView1.Rows[select].Cells[5].Value.ToString();
            txt_kat.Text = dataGridView1.Rows[select].Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[select].Cells[7].Value.ToString();
            txt_resim.Text = dataGridView1.Rows[select].Cells[8].Value.ToString();

            pictureBox1.ImageLocation = dataGridView1.Rows[select].Cells[8].Value.ToString();

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From dt_kiraci Where Ad=@Ad ";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Ad", txt_ad.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            kiraciGetir();

            MessageBox.Show("Silme İşlemi Başarılı");
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
