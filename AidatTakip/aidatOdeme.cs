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
    public partial class aidatOdeme : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        public aidatOdeme()
        {
            InitializeComponent();
        }

        private void btn_odeme_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into dt_aidatOdeme (Binaİsmi,DaireNo,AidatTutar,OdenecekAidat) values (@Binaİsmi,@DaireNo,@AidatTutar,@OdenecekAidat)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Binaİsmi", cbx_bina.Text);
            komut.Parameters.AddWithValue("@DaireNo", cbx_daire.Text);
            komut.Parameters.AddWithValue("@AidatTutar", txt_aidat.Text);
            komut.Parameters.AddWithValue("@OdenecekAidat", txt_tutar.Text);


            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Aidat Ödeme İşlemi Başarılı");
        }

        private void aidatOdeme_Load(object sender, EventArgs e)
        {
            sorgu();
        }

        public void sorgu()
        {
            cbx_bina.Items.Clear();

            baglanti.Open();
            komut = baglanti.CreateCommand();
            komut.CommandType = CommandType.Text;
            komut.CommandText = "select * from dt_AidatTakip ";
            komut.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cbx_bina.Items.Add(dr["Binaİsmi"].ToString());
                cbx_daire.Items.Add(dr["DaireNo"].ToString());
            }
            baglanti.Close();
        }

        private void cbx_daire_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = baglanti.CreateCommand();
            komut.CommandType = CommandType.Text;
            komut.CommandText = "select * from dt_AidatTakip where DaireNo = '" + cbx_daire.SelectedItem.ToString() + "' ";
            komut.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txt_aidat.Text = dr["Fiyat"].ToString();
            }
            baglanti.Close();
        }

        private void btn_iade_Click(object sender, EventArgs e)
        {

        }
    }
    }
