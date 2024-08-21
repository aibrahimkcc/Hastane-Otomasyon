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
    public partial class frmHastaKayıt : Form
    {
        public frmHastaKayıt()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-06GTKRJ;Initial Catalog=HastaneDb;Integrated Security=True;TrustServerCertificate=True");

        private void mskTel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == txtSifretekrarı.Text)
            {
                conn.Open();
                SqlCommand cmdKaydet = new SqlCommand("INSERT INTO Tbl_hastalar(Hastaad,Hastasoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) VALUES (@a1,@a2,@a3,@a4,@a5,@a6)", conn);
                cmdKaydet.Parameters.AddWithValue("@a1", txtAd.Text);
                cmdKaydet.Parameters.AddWithValue("@a2", txtSoyad.Text);
                cmdKaydet.Parameters.AddWithValue("@a3", mskTC.Text);
                cmdKaydet.Parameters.AddWithValue("@a4", mskTel.Text);
                cmdKaydet.Parameters.AddWithValue("@a5", txtSifre.Text);
                cmdKaydet.Parameters.AddWithValue("@a6", cbox1.Text);
                cmdKaydet.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("KayıtBaşarılı");
            }
            else { MessageBox.Show("Şifreler uyuşmuyor"); }

        }

        private void frmHastaKayıt_Load(object sender, EventArgs e)
        {

        }
    }
}
