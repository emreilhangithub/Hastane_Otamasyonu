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
    public partial class FrmDoktorGoruntule : Form
    {
        public FrmDoktorGoruntule()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public string Tc;

        private void FrmDoktorGoruntule_Load(object sender, EventArgs e)
        {
            //Tc getirdik
            LblTc.Text = Tc;

            //Hasta bilgilerini çektik
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Tc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAd.Text = dr[1].ToString();
                LblSoyad.Text = dr[2].ToString();
                LblBrans.Text = dr[3].ToString();
                LblTc.Text = dr[4].ToString();                
                LblSifre.Text = dr[5].ToString();                
            }
            bgl.baglanti().Close();
        }
    }
}
