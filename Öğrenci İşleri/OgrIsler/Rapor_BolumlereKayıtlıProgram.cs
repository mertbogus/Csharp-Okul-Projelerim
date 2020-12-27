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

namespace OgrIsler
{
    public partial class Rapor_BolumlereKayıtlıProgram : Form
    {
        public Rapor_BolumlereKayıtlıProgram()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;Database=ogrenci;User ID=user01; Password=abc123+");
        private void Rapor_BolumlereKayıtlıProgram_Load(object sender, EventArgs e)
        {
            bolumlistele();
        }
        void bolumlistele()
        {
            
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand("Select * from ogr_bolum order by badi asc", baglanti);
                SqlDataAdapter adp = new SqlDataAdapter(sorgu);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comboBox1.DisplayMember = "badi";
                comboBox1.ValueMember = "bkodu";
                comboBox1.DataSource = dt;
                comboBox1.Refresh();
                baglanti.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ogr_programTableAdapter.Fillbolum(this.bolumlerebagliprogramlar.ogr_program,comboBox1.SelectedValue.ToString());
            this.reportViewer1.RefreshReport();
        }
    }
}
