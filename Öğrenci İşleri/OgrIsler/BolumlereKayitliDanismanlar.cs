using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OgrIsler
{
    public partial class BolumlereKayitliDanismanlar : Form
    {
        public BolumlereKayitliDanismanlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26; database=ogrenci; User ID=user01;Password=abc123+");
        private void BolumlereKayitliDanismanlar_Load(object sender, EventArgs e)
        {
            BolumListe();
        }
        void BolumListe()
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
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select ogr_danisman.dkodu,ogr_danisman.dadi,ogr_bolum.badi,ogr_bolum.bkodu from ogr_danisman,ogr_bolum where ogr_danisman.bkodu=ogr_bolum.bkodu and ogr_danisman.bkodu=@bkodu";
            sorgu.Parameters.AddWithValue("@bkodu", comboBox1.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
