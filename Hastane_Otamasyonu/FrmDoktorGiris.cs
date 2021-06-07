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
    public partial class FrmDoktorGiris : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {      
            
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTc=@p1 and DoktorSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay fr = new FrmDoktorDetay();
                fr.tc = MskTc.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
            }

            bgl.baglanti().Close();
        }
    }
}
