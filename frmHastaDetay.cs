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

namespace Hastane_Otomasyon_
{
    public partial class frmHastaDetay : Form
    {
        
        public frmHastaDetay()
        {
            InitializeComponent();
            


        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-06GTKRJ;Initial Catalog=HastaneDb;Integrated Security=True;TrustServerCertificate=True");


        private void frmHastaDetay_Load(object sender, EventArgs e)
        {

            label4.Text = frmHastagiris.usernamee;
            

            conn.Open();
            SqlCommand kmtAd = new SqlCommand("Select Hastaad, Hastasoyad From Tbl_hastalar where hastaTC=@a1", conn);
            kmtAd.Parameters.AddWithValue("@a1", frmHastagiris.usernamee);
            
            SqlDataReader reader = kmtAd.ExecuteReader();

            while (reader.Read())
            {
                label3.Text = reader[0].ToString()+" " + reader[1].ToString();
            }


            conn.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBilgiDüzenle fr = new frmBilgiDüzenle();
            fr.Show();
            this.Hide();
        }
    }
}
