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
    public partial class OgrenciDuzenle : Form
    {
        public OgrenciDuzenle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;Database=ogrenci;User ID=user01;Password=abc123+");
        private void OgrenciDuzenle_Load(object sender, EventArgs e)
        {
            OgrListe();
        }

        void OgrListe()
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select ogr_bilgi.ogrno,ogr_bilgi.adi+' '+ogr_bilgi.soyadi as 'adisoyadi',ogr_bolum.badi,ogr_program.padi,ogr_okul.sinif,ogr_ogrenim.ogr_tur_adi,ogr_danisman.dadi from ogr_bilgi,ogr_okul,ogr_danisman,ogr_bolum,ogr_program,ogr_ogrenim where ogr_bilgi.ogrno=ogr_okul.ogrno and ogr_bolum.bkodu=ogr_program.bkodu and ogr_okul.pkodu=ogr_program.pkodu and ogr_ogrenim.ogr_tur=ogr_okul.ogr_tur and ogr_okul.dkodu=ogr_danisman.dkodu";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            baglanti.Close();

        }
        string ogrencino;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            DialogResult tus = MessageBox.Show("Seçili Öğrencinin Bilgilerini Güncellemek İstiyor musunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus==DialogResult.Yes)
            {
              
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgubilgi = new SqlCommand("select * from ogr_bilgi where ogrno=@ogrno",baglanti);
                sorgubilgi.Parameters.AddWithValue("@ogrno", ogrencino);
                SqlDataReader sdrbilgi = sorgubilgi.ExecuteReader();
                sdrbilgi.Read();
                maskedTextBox1.Text = sdrbilgi["tckimlik"].ToString();
                maskedTextBox2.Text = sdrbilgi["adi"].ToString();
                maskedTextBox3.Text = sdrbilgi["soyadi"].ToString();
                if (sdrbilgi["cinsiyet"].ToString()=="E")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked= true;
                }
                dateTimePicker1.Text = sdrbilgi["dtarih"].ToString();
                sdrbilgi.Close();
                baglanti.Close();
                BolumListe();
                ProgramListe();
                OgrenimListe();
                DanismanListe();
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorguokul = new SqlCommand("select * from ogr_okul where ogrno=@ogrno", baglanti);
                sorguokul.Parameters.AddWithValue("@ogrno", ogrencino);
                SqlDataReader sdrokul = sorguokul.ExecuteReader();
                sdrokul.Read();
                maskedTextBox4.Text = sdrokul["ogrno"].ToString();
                listBox1.SelectedValue = sdrokul["ogr_tur"].ToString();
                if (sdrokul["sinif"].ToString()=="1")
                {
                    radioButton3.Checked = true;
                }
                else
                {
                    radioButton4.Checked = true;
                }
                string pkodu = sdrokul["pkodu"].ToString();
                string dkodu = sdrokul["dkodu"].ToString();
                // comboBox2.SelectedValue = sdrokul["pkodu"].ToString();
                sdrokul.Close();             
                baglanti.Close();
                comboBox2.SelectedValue = pkodu;
                listBox2.SelectedValue = dkodu;
               
                
            }
        }
        void BolumListe()
        {
            if (baglanti.State==ConnectionState.Closed)
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
        void ProgramListe()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select * from ogr_program", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            comboBox2.DisplayMember = "padi";
            comboBox2.ValueMember = "pkodu";
            comboBox2.DataSource = dt;
            comboBox2.Refresh();
            baglanti.Close();
        }

        void OgrenimListe()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select * from ogr_ogrenim", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            listBox1.DisplayMember = "ogr_tur_adi";
            listBox1.ValueMember = "ogr_tur";
            listBox1.DataSource = dt;
            listBox1.Refresh();
            baglanti.Close();
        }

        void DanismanListe()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select * from ogr_danisman where bkodu=@bolumkodu", baglanti);
            sorgu.Parameters.AddWithValue("@bolumkodu", comboBox1.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            listBox2.DisplayMember = "dadi";
            listBox2.ValueMember = "dkodu";
            listBox2.DataSource = dt;
            listBox2.Refresh();
            baglanti.Close();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ProgramListe();
            DanismanListe();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand("select bkodu from ogr_program where pkodu=@pkodu", baglanti);
            sorgu.Parameters.AddWithValue("@pkodu", comboBox2.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            string bkodu = Convert.ToString(sorgu.ExecuteScalar());
            comboBox1.SelectedValue = bkodu;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgubilgi = new SqlCommand();
            sorgubilgi.Connection = baglanti;
            sorgubilgi.CommandText = "Update ogr_bilgi set ogrno=@ogrno,tckimlik=@tckimlik,adi=@adi,soyadi=@soyadi,cinsiyet=@cinsiyet,dtarih=@dtarih where ogrno=@eskiogrno";
            sorgubilgi.Parameters.AddWithValue("@ogrno", maskedTextBox4.Text);
            sorgubilgi.Parameters.AddWithValue("@tckimlik", maskedTextBox1.Text);
            sorgubilgi.Parameters.AddWithValue("@adi", maskedTextBox2.Text);
            sorgubilgi.Parameters.AddWithValue("@soyadi", maskedTextBox3.Text);
            if (radioButton1.Checked==true)
            {
                sorgubilgi.Parameters.AddWithValue("@cinsiyet","E");
            }
            else if (radioButton2.Checked==true)
            {
                sorgubilgi.Parameters.AddWithValue("@cinsiyet", "K");
            }
            
            sorgubilgi.Parameters.AddWithValue("@dtarih",dateTimePicker1.Value);
            sorgubilgi.Parameters.AddWithValue("@eskiogrno",ogrencino);

            SqlCommand sorguokul = new SqlCommand();
            sorguokul.Connection = baglanti;
            sorguokul.CommandText = "update ogr_okul set ogrno=@ogrno,pkodu=@pkodu,sinif=@sinif,ogr_tur=@ogr_tur,dkodu=@dkodu where ogrno=@eskiogrno";
            sorguokul.Parameters.AddWithValue("@ogrno", maskedTextBox4.Text);
            sorguokul.Parameters.AddWithValue("@pkodu", comboBox2.SelectedValue);
            if (radioButton3.Checked==true)
            {
                sorguokul.Parameters.AddWithValue("@sinif", "1");
            }
            else
            {
                sorguokul.Parameters.AddWithValue("@sinif", "2");
            }
            sorguokul.Parameters.AddWithValue("@ogr_tur",listBox1.SelectedValue);
            sorguokul.Parameters.AddWithValue("@dkodu",listBox2.SelectedValue);
            sorguokul.Parameters.AddWithValue("@eskiogrno", ogrencino);

            DialogResult tus = MessageBox.Show("Yaptığınız Değişikleri İlgili Öğrenci İçin Güncellemek İstiyor musunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus==DialogResult.Yes)
            {
                int ksbilgi = sorgubilgi.ExecuteNonQuery();
                int ksokul = sorguokul.ExecuteNonQuery();
                OgrListe();
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Öğrenciyi Silmek İstiyor musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus==DialogResult.Yes)
            {
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgubilgi = new SqlCommand("delete from ogr_bilgi where ogrno=@eskiogrno",baglanti);
                sorgubilgi.Parameters.AddWithValue("@eskiogrno", ogrencino);
                SqlCommand sorguokul = new SqlCommand("delete from ogr_okul where ogrno=@eskiogrno", baglanti);
                sorguokul.Parameters.AddWithValue("@eskiogrno", ogrencino);
                int ksokul = sorguokul.ExecuteNonQuery();
                int ksbilgi = sorgubilgi.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("İlgili Öğrencinin Kaydı Silindi.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OgrListe();
            }

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ogrencino = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_CellDoubleClick(null, null);
        }
    }
}
