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
    public partial class FrmDoktorDetay : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        public string tc;

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            //Doktor Tc Getirdik
            LblTc.Text = tc;

            //Doktor Bilgilerini Getirdik
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTc = @d1",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",tc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
                }
            bgl.baglanti().Close();

            DataTable dt = new DataTable(); //datatable oluşturduk
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuDoktor='"+LblAdSoyad.Text+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
