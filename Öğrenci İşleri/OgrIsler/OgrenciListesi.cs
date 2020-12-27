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
    public partial class OgrenciListesi : Form
    {
        public OgrenciListesi()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26; database=ogrenci; User ID=user01;Password=abc123+");
        private void OgrenciListesi_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select ogr_bilgi.ogrno,ogr_bilgi.adi+' '+ogr_bilgi.soyadi as 'adisoyadi',ogr_bolum.badi,ogr_program.padi,ogr_okul.sinif,ogr_ogrenim.ogr_tur_adi,ogr_danisman.dadi from ogr_bilgi,ogr_okul,ogr_bolum,ogr_program,ogr_ogrenim,ogr_danisman where ogr_bilgi.ogrno=ogr_okul.ogrno and ogr_okul.pkodu=ogr_program.pkodu and ogr_program.bkodu=ogr_bolum.bkodu and ogr_okul.ogr_tur=ogr_ogrenim.ogr_tur and ogr_okul.dkodu=ogr_danisman.dkodu";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = dt.Rows.Count.ToString();
            baglanti.Close();
            BolumListe();
        }
        void BolumListe()
        {
            if (baglanti.State==ConnectionState.Closed)
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
            string ogrno = maskedTextBox1.Text;
            string adi = maskedTextBox2.Text;
            string soyadi = maskedTextBox3.Text;

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            if (String.IsNullOrEmpty(ogrno) != true)
            {
                sorgu.CommandText = "select ogr_bilgi.ogrno,ogr_bilgi.adi+' '+ogr_bilgi.soyadi as 'adisoyadi',ogr_bolum.badi,ogr_program.padi,ogr_okul.sinif,ogr_ogrenim.ogr_tur_adi,ogr_danisman.dadi from ogr_bilgi,ogr_okul,ogr_bolum,ogr_program,ogr_ogrenim,ogr_danisman where ogr_bilgi.ogrno=ogr_okul.ogrno and ogr_okul.pkodu=ogr_program.pkodu and ogr_program.bkodu=ogr_bolum.bkodu and ogr_okul.ogr_tur=ogr_ogrenim.ogr_tur and ogr_okul.dkodu=ogr_danisman.dkodu and ogr_okul.ogrno=@ogrno";
                sorgu.Parameters.AddWithValue("@ogrno", ogrno);
            }
            else
            {
                sorgu.CommandText = "select ogr_bilgi.ogrno,ogr_bilgi.adi+' '+ogr_bilgi.soyadi as 'adisoyadi',ogr_bolum.badi,ogr_program.padi,ogr_okul.sinif,ogr_ogrenim.ogr_tur_adi,ogr_danisman.dadi from ogr_bilgi,ogr_okul,ogr_bolum,ogr_program,ogr_ogrenim,ogr_danisman where ogr_bilgi.ogrno=ogr_okul.ogrno and ogr_okul.pkodu=ogr_program.pkodu and ogr_program.bkodu=ogr_bolum.bkodu and ogr_okul.ogr_tur=ogr_ogrenim.ogr_tur and ogr_okul.dkodu=ogr_danisman.dkodu and (ogr_bilgi.adi like @adi and ogr_bilgi.soyadi like @soyadi)";
                adi = '%' + adi + '%';
                soyadi = '%' + soyadi + '%';
                sorgu.Parameters.AddWithValue("@adi", adi);
                sorgu.Parameters.AddWithValue("@soyadi", soyadi);
            }
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = dt.Rows.Count.ToString();
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select * from ogr_program where bkodu=@bkodu", baglanti);
            sorgu.Parameters.AddWithValue("@bkodu", comboBox1.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            comboBox2.DisplayMember = "padi";
            comboBox2.ValueMember = "pkodu";
            comboBox2.DataSource = dt;
            comboBox2.Refresh();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select ogr_bilgi.ogrno,ogr_bilgi.adi+' '+ogr_bilgi.soyadi as 'adisoyadi',ogr_bolum.badi,ogr_program.padi,ogr_okul.sinif,ogr_ogrenim.ogr_tur_adi,ogr_danisman.dadi from ogr_bilgi,ogr_okul,ogr_bolum,ogr_program,ogr_ogrenim,ogr_danisman where ogr_bilgi.ogrno=ogr_okul.ogrno and ogr_okul.pkodu=ogr_program.pkodu and ogr_program.bkodu=ogr_bolum.bkodu and ogr_okul.ogr_tur=ogr_ogrenim.ogr_tur and ogr_okul.dkodu=ogr_danisman.dkodu and ogr_okul.pkodu=@programkodu";
            sorgu.Parameters.AddWithValue("@programkodu", comboBox2.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = dt.Rows.Count.ToString();
            baglanti.Close();

        }
    }
}
