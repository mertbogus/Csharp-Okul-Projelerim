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
    public partial class BolumListele : Form
    {
        public BolumListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;Database=ogrenci; User ID=user01;Password=abc123+");
        private void BolumListele_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand bolumsorgu = new SqlCommand();
            bolumsorgu.Connection = baglanti;
            bolumsorgu.CommandText = "select ogr_program.pkodu,ogr_program.padi from ogr_program";
            SqlDataAdapter adp = new SqlDataAdapter(bolumsorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            baglanti.Close();
            Bolumlistele();
        }
        void Bolumlistele()
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand programsorgu = new SqlCommand();
            programsorgu.Connection = baglanti;
            programsorgu.CommandText = "select ogr_bolum.bkodu,ogr_bolum.badi from ogr_program, ogr_bolum where ogr_program.bkodu=ogr_bolum.bkodu";
            SqlDataAdapter adp = new SqlDataAdapter(programsorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
            baglanti.Close();
        }
    }
}
