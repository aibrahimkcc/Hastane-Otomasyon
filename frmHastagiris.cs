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
using System.Security.Cryptography.X509Certificates;

namespace Hastane_Otomasyon_
{
    public partial class frmHastagiris : Form
    {
         public frmHastagiris()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-06GTKRJ;Initial Catalog=HastaneDb;Integrated Security=True;TrustServerCertificate=True");
        private void frmHastagiris_Load(object sender, EventArgs e)
        {

        }

        private void lnkUye_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   

            frmHastaKayıt fr = new frmHastaKayıt();
            fr.Show();
            Hide();
        }

        
        public static string usernamee;
        public string password;

        private void btnGiris_Click(object sender, EventArgs e)
        {

        conn.Open();
            SqlCommand kmtSifre = new SqlCommand("Select HastaTC,HastaSifre From Tbl_hastalar where HastaTC=@a1", conn);
            kmtSifre.Parameters.AddWithValue("@a1", mskTC.Text);

            SqlDataReader reader = kmtSifre.ExecuteReader();

            while (reader.Read())
            {
                 usernamee = reader[0].ToString();
                 password = reader[1].ToString();
            }

            
            if (mskTC.Text == usernamee && password== txtSifre.Text)
            {

                
                frmHastaDetay frm = new frmHastaDetay();
                frm.Show();
                
                
                this.Hide();
            } else
            {
                MessageBox.Show("Kullanıcı adı veya Şifre yanlış","Hatalı giriş",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            conn.Close();
        }
        
    }
}
