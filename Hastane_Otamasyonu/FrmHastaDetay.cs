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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;

        sqlbaglantisi bgl = new sqlbaglantisi();
        

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            //Ad soyad bilgileri çekme
            LblTc.Text = tc;
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar where HastaTc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",tc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevu Geçmişi
            DataTable dt = new DataTable(); //datatable oluşturduk
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where HastaTc="+tc,bgl.baglanti());
            //datagride veri aktarmak için kullanırız
            da.Fill(dt);//data adapterin içini doldur tablodan gelecek olan degerle
            dataGridView1.DataSource = dt; //data gridin veri kaynagı = dt gelen tablo

            //Bransları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());            
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();            
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Doktor Çekme
            CmbDoktor.Items.Clear(); //comboxdan bir şey çekince onu silsin
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                CmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //doktoru seçtikden sonra randevular gelecek data gridden
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuBrans='"+CmbBrans.Text+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt; 


        }

        private void LnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.tcno = LblTc.Text;
            fr.Show();
        }
    }
}
