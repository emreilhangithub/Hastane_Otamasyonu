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
    public partial class FrmDoktorDuzenle : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCNO;

        public FrmDoktorDuzenle()
        {
            InitializeComponent();
        }

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            //Doktor Tc Getirdik
            MskTc.Text = TCNO;

            //Doktor Bilgilerini Getirdik
            SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTc = @d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", TCNO);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                CmbBrans.Text = dr[3].ToString();
                TxtSifre.Text = dr[5].ToString();
               
            }
            bgl.baglanti().Close();

            //Bransları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTc=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi", " Bilgi ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
