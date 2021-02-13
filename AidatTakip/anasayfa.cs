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
    public partial class anasayfa : Form
    {
       
        public anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaT BinaT= new BinaT();
            BinaT.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kiracı kiraci = new kiracı();

            kiraci.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kullanici kullanici = new kullanici();

            kullanici.Show();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aidatTakip aidatTakip = new aidatTakip();

            aidatTakip.Show();

            this.Hide();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aidatOdeme aidatOdeme = new aidatOdeme();

            aidatOdeme.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tahsilat tahsilat = new tahsilat();

            tahsilat.Show();
            this.Hide();
        }
    }
}
