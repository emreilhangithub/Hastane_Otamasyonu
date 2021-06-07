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


        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            RchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDoktorGoruntule fr = new FrmDoktorGoruntule();
            fr.Tc = LblTc.Text;
            fr.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDoktorDuzenle fr = new FrmDoktorDuzenle();
            fr.TCNO = LblTc.Text;
            fr.Show();
        }
    }
}
