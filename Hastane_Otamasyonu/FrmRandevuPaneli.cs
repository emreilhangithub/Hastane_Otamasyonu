using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hastane_Otamasyonu
{
    public partial class FrmRandevuPaneli : Form
    {
        public FrmRandevuPaneli()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable(); //datatable oluşturduk
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Tbl_Randevular ", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Bransları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

            //Durum Çekme
            string[] durum = { "True", "False"};

            foreach (string k in durum)
            {
                CmbDurum.Items.Add(k);
                //comboBox1.Items.Add(weekDays2[i]);
            }




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            MskTarih.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();           
            MskSaat.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            CmbDoktor.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            CmbDurum.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            MskTc.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            RchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Randevular WHERE Randevuid=@r1;", bgl.baglanti());
            komut.Parameters.AddWithValue("r1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
           if (MskTc.Text == "" || MskTc.Text == String.Empty) //boşluk

            { 
               MessageBox.Show("Lütfen Tc Giriniz", "Boş Alan Hatası");
            }           

            else
            { 

            SqlCommand komut = new SqlCommand("update Tbl_Randevular set RandevuTarih=@r1,RandevuSaat=@r2,RandevuBrans=@r3,RandevuDoktor=@r4,RandevuDurum=@r5,HastaTc=@r6,HastaSikayet=@r7 where Randevuid=@r8", bgl.baglanti());
            komut.Parameters.AddWithValue("@r1", MskTarih.Text);
            komut.Parameters.AddWithValue("@r2", MskSaat.Text);
            komut.Parameters.AddWithValue("@r3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@r4", CmbDoktor.Text);
            komut.Parameters.AddWithValue("@r5", CmbDurum.Text);
            komut.Parameters.AddWithValue("@r6", MskTc.Text);
            komut.Parameters.AddWithValue("@r7", RchSikayet.Text);
            komut.Parameters.AddWithValue("@r8", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Show();
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable(); //datatable oluşturduk
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Tbl_Randevular ", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
    }
}
