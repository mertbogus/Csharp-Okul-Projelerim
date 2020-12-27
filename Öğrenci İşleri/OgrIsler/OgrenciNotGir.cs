using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace OgrIsler
{
    public partial class OgrenciNotGir : Form
    {
        public OgrenciNotGir()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=79.123.131.26; User Id=user01;Password=abc123+;Initial Catalog=ogrenci");
        private void OgrenciNotGir_Load(object sender, EventArgs e)
        {
            
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand("select * from ogr_bolum", baglanti);
                SqlDataAdapter adp = new SqlDataAdapter(sorgu);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comboBox1.DisplayMember = "badi";
                comboBox1.ValueMember = "bkodu";
                comboBox1.DataSource = dt;
                comboBox1.Refresh();
                baglanti.Close();

            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("select * from ogr_program where bkodu=@bkodu", baglanti);
                sorgu.Parameters.AddWithValue("@bkodu", comboBox1.SelectedValue);
                SqlDataAdapter adp = new SqlDataAdapter(sorgu);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comboBox2.DisplayMember = "padi";
                comboBox2.ValueMember = "pkodu";
                comboBox2.DataSource = dt;
                comboBox2.Refresh();

            }
            catch (Exception Ex)
            {

                if (Ex is SqlException)
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    else
                    {
                        baglanti.Close();
                    }
                }
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
                SqlCommand sorguokull = new SqlCommand("select * from ogr_dersler where pkodu=@pkodu", baglanti);
                sorguokull.Parameters.AddWithValue("@pkodu", comboBox2.SelectedValue);
                SqlDataAdapter adp = new SqlDataAdapter(sorguokull);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                listBox1.DisplayMember = "dersadi";
                listBox1.ValueMember = "derskodu";
                listBox1.DataSource = dt;
                listBox1.Refresh();
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
                sorgu.CommandText = "select ogr_bilgi.ogrno,ogr_bilgi.adi+' '+ogr_bilgi.soyadi as 'adisoyadi' from ogr_bilgi,ogr_okul,ogr_dersler,ogr_alinandersler where ogr_bilgi.ogrno=ogr_okul.ogrno and ogr_okul.ogrno=ogr_alinandersler.ogrno and ogr_dersler.derskodu=ogr_alinandersler.derskodu and  ogr_alinandersler.derskodu=@derskodu";
                sorgu.Parameters.AddWithValue("@derskodu", listBox1.SelectedValue);
                SqlDataAdapter adp = new SqlDataAdapter(sorgu);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                baglanti.Close();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int vize = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                int final = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                int basnot = (vize * 40 / 100) + (final * 60 / 100);
                dataGridView1.Rows[i].Cells[2].Value = basnot;
                string harfnot = "";
                if (basnot < 40)
                {
                    harfnot = "FF";
                }
                else if (basnot < 60)
                {
                    harfnot = "DD";
                }
                else if (basnot < 70)
                {
                    harfnot = "CC";
                }
                else if (basnot < 85)
                {
                    harfnot = "BB";
                }
                else
                {
                    harfnot = "AA";
                }
                dataGridView1.Rows[i].Cells[3].Value = harfnot;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    string ogrno = dataGridView1.Rows[i].Cells["Column1"].Value.ToString();

                    string dkodu = listBox1.SelectedValue.ToString();
                    string vize = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string final = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string basnot = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string harfnot = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    SqlCommand sorgunot = new SqlCommand();
                    sorgunot.Connection = baglanti;
                    sorgunot.CommandText = "insert into ogr_notlar(ogrno,derskodu,vize,final,bnot,harfnot) values(@ogrno,@derskodu,@vize,@final,@bnot,@harfnot)";
                    sorgunot.Parameters.AddWithValue("@ogrno", ogrno);
                    sorgunot.Parameters.AddWithValue("@derskodu", dkodu);
                    sorgunot.Parameters.AddWithValue("@vize", vize);
                    sorgunot.Parameters.AddWithValue("@final", final);
                    sorgunot.Parameters.AddWithValue("@bnot", basnot);
                    sorgunot.Parameters.AddWithValue("@harfnot", harfnot);
                    int ks = sorgunot.ExecuteNonQuery();
                    if (ks>0)
                    {
                        MessageBox.Show("Not Girişi Başarıyla Tamamlanmıştır.", "Not Giriş İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    baglanti.Close();
                }
            }
            catch(ArgumentNullException)
            {

                MessageBox.Show("Vize ve Final Boş Bırakılamaz.");
            }
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
