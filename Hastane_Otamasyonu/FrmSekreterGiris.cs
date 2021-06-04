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

namespace Hastane_Otamasyonu
{
    public partial class FrmSekreterGiris : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Sekreterler where SekreterTc=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("p1", MskTc.Text);
            komut.Parameters.AddWithValue("p2", TxtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FrmSekreterDetay fr = new FrmSekreterDetay();
                fr.Tcnumara = MskTc.Text; //diger forma bilgiyi gönderdim
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Sifre");
            }
            bgl.baglanti().Close();
        }
    }
}
