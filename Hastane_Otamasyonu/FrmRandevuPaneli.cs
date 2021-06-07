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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            CmbDoktor.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            /*
            SqlCommand komut = new SqlCommand("update Tbl_Branslar set BransAd=@b1 where Bransid=@b2", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", TxtAd.Text);
            komut.Parameters.AddWithValue("@b2", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
        }
    }
}
