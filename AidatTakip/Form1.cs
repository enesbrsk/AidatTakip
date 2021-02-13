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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
        

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_pass.PasswordChar = '*';

            baglanti.Open();
        }

        private void Btn_giris_Click(object sender, EventArgs e)
        {
            string user = txt_name.Text;
            string pass = txt_pass.Text;

            con = new SqlConnection("Data Source=DESKTOP-DQ3L64D\\SQLEXPRESS;Initial Catalog=TakipDatabase;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM dt_Login where KullaniciAdi='" + txt_name.Text + "' AND Sifre='" + txt_pass.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                anasayfa anasayfa = new anasayfa();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            con.Close();
        }
    }
}
