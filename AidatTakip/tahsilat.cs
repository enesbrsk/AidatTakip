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
    public partial class tahsilat : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        public tahsilat()
        {
            InitializeComponent();
        }

        private void tahsilat_Load(object sender, EventArgs e)
        {
            tahsilatEdilen();
            tahsilateEdilmeyen();

        }
        public void tahsilateEdilmeyen()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select * From dt_aidatOdeme where OdenecekAidat  IS NULL", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        public void tahsilatEdilen()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select * From dt_aidatOdeme where OdenecekAidat  IS NOT NULL", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
