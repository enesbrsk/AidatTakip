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
    public partial class BinaT : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public BinaT()
        {
            InitializeComponent();
        }

        void BinaGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select * From dt_BinaT", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into dt_BinaT (Binaİsmi,il,ilçe,mahalle,binano,cadde,sokak) values (@Binaİsmi,@il,@ilçe,@mahalle,@binano,@cadde,@sokak)";
           
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Binaİsmi", txt_binaismi.Text);
                komut.Parameters.AddWithValue("@il", txt_il.Text);
                komut.Parameters.AddWithValue("@ilçe", txt_ilçe.Text);
                komut.Parameters.AddWithValue("@mahalle", txt_mahalle.Text);
                komut.Parameters.AddWithValue("@binano", txt_binano.Text);
                komut.Parameters.AddWithValue("@cadde", txt_cadde.Text);
                komut.Parameters.AddWithValue("@sokak", txt_sokak.Text);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                BinaGetir();

            MessageBox.Show("Ekleme İşlemi Başarılı");
        }

        private void BinaT_Load(object sender, EventArgs e)
        {
            BinaGetir();
            GridDesing();

        }
        public void GridDesing()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Bina İsmi";
            dataGridView1.Columns[2].HeaderText = "İl";
            dataGridView1.Columns[3].HeaderText = "İlçe";
            dataGridView1.Columns[4].HeaderText = "Mahlle";
            dataGridView1.Columns[5].HeaderText = "Bina No";
            dataGridView1.Columns[6].HeaderText = "Cadde";
            dataGridView1.Columns[7].HeaderText = "Sokak";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
