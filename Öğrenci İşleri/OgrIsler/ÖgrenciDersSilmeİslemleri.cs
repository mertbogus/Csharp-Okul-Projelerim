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
    public partial class ÖgrenciDersSilmeİslemleri : Form
    {
        public ÖgrenciDersSilmeİslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;Database=ogrenci;User ID=user01; Password=abc123+");
        string ogrencino;
        
        private void ÖgrenciDersSilmeİslemleri_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select ogr_okul.ogrno,ogr_bilgi.adi+' '+ogr_bilgi.soyadi as 'adisoyadi',ogr_okul.sinif,ogr_ogrenim.ogr_tur_adi,ogr_danisman.dadi from ogr_bilgi,ogr_okul,ogr_ogrenim,ogr_danisman where ogr_bilgi.ogrno=ogr_okul.ogrno and ogr_okul.ogr_tur=ogr_ogrenim.ogr_tur and ogr_okul.dkodu=ogr_danisman.dkodu and ogr_okul.pkodu=@pkodu";
            sorgu.Parameters.AddWithValue("@pkodu", comboBox2.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            groupBox3.Visible = false;
            ogrencino = "";
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ogrencino = dataGridView1.SelectedCells[0].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ogrencino) == false)
            {
                groupBox3.Visible = true;
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand("select ogr_okul.ogrno,ogr_alinandersler.ogrno,ogr_danisman.dadi,ogr_dersler.derskodu,ogr_dersler.dersadi,ogr_dersler.akts from ogr_okul,ogr_alinandersler,ogr_dersler,ogr_danisman where ogr_okul.ogrno=ogr_alinandersler.ogrno and ogr_danisman.dkodu=ogr_dersler.dkodu and ogr_dersler.derskodu=ogr_alinandersler.derskodu and ogr_alinandersler.ogrno=@ogrno", baglanti);
                sorgu.Parameters.AddWithValue("@ogrno", ogrencino);
                SqlDataAdapter adp = new SqlDataAdapter(sorgu);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView2.DataSource = dt;
                dataGridView2.Refresh();
                baglanti.Close();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        int ks;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult tus = MessageBox.Show("Seçili Olan Dersleri, İlgili Öğrenci Silmek İstiyor musunuz?", "Ders Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tus == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[0].Value) == true)
                        {
                            if (baglanti.State == ConnectionState.Closed)
                            {
                                baglanti.Open();
                            }
                            SqlCommand sorgu = new SqlCommand("delete from ogr_alinandersler where ogrno=@ogrno and derskodu=@dekodu", baglanti);
                            sorgu.Parameters.AddWithValue("@ogrno", ogrencino);
                            sorgu.Parameters.AddWithValue("@dekodu", dataGridView2.Rows[i].Cells[4].Value);
                            ks=sorgu.ExecuteNonQuery();

                        }
                    }
                    if (ks > 0)
                    {
                        MessageBox.Show("Seçmiş Olduğunuz Dersler Başarıyla Silinmiştir. ", "Bilgilendirme Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
