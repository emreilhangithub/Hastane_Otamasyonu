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
    public partial class FrmBilgiGoruntule : Form
    {
        public FrmBilgiGoruntule()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public string Tc;

        private void FrmBilgiGoruntule_Load(object sender, EventArgs e)
        {
            //Tc getirdik
            LblTc.Text = Tc;

            //Hasta bilgilerini çektik
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Tc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAd.Text = dr[1].ToString();
                LblSoyad.Text = dr[2].ToString();
                LblTelefon.Text = dr[4].ToString();
                LblSifre.Text = dr[5].ToString();
                LblCinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
