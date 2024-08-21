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
using System.Security.Cryptography;

namespace Hastane_Otomasyon_
{
    public partial class frmBilgiDüzenle : Form
    {
        public frmBilgiDüzenle()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-06GTKRJ;Initial Catalog=HastaneDb;Integrated Security=True;TrustServerCertificate=True");


        public string Tckimlik;

        private void button1_Click(object sender, EventArgs e)
        {   


            conn.Open();
            SqlCommand güncelle = new SqlCommand(
                @"Update Tbl_hastalar 
                
                SET Hastaad=@a1, 
                
                Hastasoyad=@a2,
                HastaTC=@a3,
                HastaTelefon=@a4,
                HastaSifre=@a5,
                HastaCinsiyet=@a6

                WHERE HastaTC=@a7", conn);
            güncelle.Parameters.AddWithValue("@a1",txtAd.Text);
            güncelle.Parameters.AddWithValue("@a2",txtSoyad.Text);
            güncelle.Parameters.AddWithValue("@a3",mskTC.Text);
            güncelle.Parameters.AddWithValue("@a4",mskTel.Text);
            güncelle.Parameters.AddWithValue("@a5",txtSifre.Text);
            güncelle.Parameters.AddWithValue("@a6",cbox1.Text);
            güncelle.Parameters.AddWithValue("@a7",frmHastagiris.usernamee);
            güncelle.ExecuteNonQuery();
            conn.Close();

            frmHastaDetay fr = new frmHastaDetay();
            fr.Show();
            this.Hide();
        }

        private void frmBilgiDüzenle_Load(object sender, EventArgs e)
        {

        }
    }
}
