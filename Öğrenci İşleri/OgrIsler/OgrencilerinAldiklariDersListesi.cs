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
    public partial class OgrencilerinAldiklariDersListesi : Form
    {
        public OgrencilerinAldiklariDersListesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;Database=ogrenci;User ID=user01; Password=abc123+");
        private void OgrencilerinAldiklariDersListesi_Load(object sender, EventArgs e)
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select * from ogr_program where bkodu=@bkodu";
            sorgu.Parameters.AddWithValue("@bkodu", comboBox1.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            comboBox2.DisplayMember = "padi";
            comboBox2.ValueMember = "pkodu";
            comboBox2.DataSource = dt;
            comboBox2.Refresh();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select * from ogr_dersler where pkodu=@pkodu";
            sorgu.Parameters.AddWithValue("@pkodu", comboBox2.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            comboBox3.DisplayMember = "dersadi";
            comboBox3.ValueMember = "derskodu";
            comboBox3.DataSource = dt;
            comboBox3.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select ogr_okul.ogrno,ogr_dersler.pkodu,ogr_alinandersler.derskodu,ogr_dersler.dersadi, ogr_bilgi.adi+' '+ogr_bilgi.soyadi as'adisoyadi' from ogr_okul,ogr_dersler,ogr_alinandersler,ogr_bilgi where ogr_okul.ogrno=ogr_alinandersler.ogrno and ogr_dersler.derskodu=ogr_alinandersler.derskodu and ogr_bilgi.ogrno=ogr_alinandersler.ogrno and ogr_alinandersler.derskodu=@derskodu";
            sorgu.Parameters.AddWithValue("@derskodu", comboBox3.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            baglanti.Close();
        }
    }
}
