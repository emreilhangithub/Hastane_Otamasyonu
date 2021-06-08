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
    public partial class FrmDuyuruPaneli : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public FrmDuyuruPaneli()
        {
            InitializeComponent();
        }

        private void FrmDuyurular_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable(); //datatable oluşturduk
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Tbl_Duyurular order by Duyuruid desc", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            RchDuyuru.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }       

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Duyurular WHERE Duyuruid=@d1;", bgl.baglanti());
            komut.Parameters.AddWithValue("d1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Duyurular set Duyuru=@d1 where Duyuruid=@d2", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", RchDuyuru.Text);
            komut.Parameters.AddWithValue("@d2", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable(); //datatable oluşturduk
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Tbl_Duyurular order by Duyuruid desc", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
    }
}
