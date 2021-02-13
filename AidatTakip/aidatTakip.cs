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
    public partial class aidatTakip : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        public aidatTakip()
        {
            InitializeComponent();
        }
        void AidatGetir()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select * From dt_AidatTakip", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        
        public void ComboBoxGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * From dt_kiraci ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cbx_binaismi.Items.Add(read["Binaİsmi"]);
                cbx_daireno.Items.Add(read["DaireNo"]);
            }

        }
        public void hatırlatıcı()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;

            DateTime myDateTime = DateTime.Now;
            string bugün = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            con = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM dt_AidatTakip where Tarih  >= '" + bugün + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tahsil Edilmeyen Aidatlar Var Lütfen Kontrol Ediniz");
            }

            con.Close();
        }

        private void aidatTakip_Load(object sender, EventArgs e)
        {
            hatırlatıcı();
            ComboBoxGetir();
            AidatGetir();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into dt_AidatTakip (Binaİsmi,DaireNo,Fiyat,Tarih) values (@Binaİsmi,@DaireNo,@Fiyat,@Tarih)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Binaİsmi", cbx_binaismi.Text);
            komut.Parameters.AddWithValue("@DaireNo", cbx_daireno.Text);
            komut.Parameters.AddWithValue("@Fiyat", txt_tutar.Text);
            komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);

            
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            AidatGetir();

            MessageBox.Show("Kayıt İşlemi Başarılı");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
