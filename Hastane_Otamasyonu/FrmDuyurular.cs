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
    public partial class FrmDuyurular : Form
    {

        sqlbaglantisi bgl = new sqlbaglantisi();

        public FrmDuyurular()
        {
            InitializeComponent();
            DataTable dt1 = new DataTable(); //datatable oluşturduk
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Tbl_Duyurular order by Duyuruid desc", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
