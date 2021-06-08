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
    public partial class FrmHastaGiris : Form
    {
        sqlbaglantisi bgl= new sqlbaglantisi();

        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();           
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTc=@p1 and HastaSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("p1", MskTc.Text);
            komut.Parameters.AddWithValue("p2", TxtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if(dr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc = MskTc.Text; //diger forma bilgiyi gönderdim
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Sifre");
            }
            bgl.baglanti().Close();



        }

        private void FrmHastaGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Kapatmak İstediginizden Emin Misiniz ?", "Bti Danışmanlık Hospital",
         MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
