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
    public partial class FrmDoktorPaneli : Form
    {

        sqlbaglantisi bgl = new sqlbaglantisi();

        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable(); //datatable oluşturduk
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Tbl_Doktorlar ", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTc,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",TxtAd.Text);
            komut.Parameters.AddWithValue("@d2",TxtSoyad.Text);
            komut.Parameters.AddWithValue("@d3",CmbBrans.Text);
            komut.Parameters.AddWithValue("@d4",MskTc.Text);
            komut.Parameters.AddWithValue("@d5",TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Doktorlar WHERE DoktorTc=@d1;",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", MskTc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
