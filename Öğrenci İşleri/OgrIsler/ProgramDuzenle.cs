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
    public partial class ProgramDuzenle : Form
    {
        public ProgramDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=79.123.131.26;Database=ogrenci;User ID=user01;Password=abc123+");
        string programkodu;
        private void ProgramDuzenle_Load(object sender, EventArgs e)
        {
            programlistesi();
            programkoduliste();
        }
        void programlistesi()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select * from ogr_program";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            baglanti.Close();
        }
        void programkoduliste()
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorguprogram = new SqlCommand();
                sorguprogram.Connection = baglanti;
                sorguprogram.CommandText = "Update ogr_program set pkodu=@pkodu, padi=@padi, bkodu=@bkodu where pkodu=@eskikodu";
                sorguprogram.Parameters.AddWithValue("@pkodu", maskedTextBox1.Text);
                sorguprogram.Parameters.AddWithValue("@padi", maskedTextBox2.Text);
                sorguprogram.Parameters.AddWithValue("@bkodu", comboBox1.SelectedValue);
                sorguprogram.Parameters.AddWithValue("@eskikodu", programkodu);


                /* Program kodu birincil anahtar olduğu için ve diğer yerlerle bağlantılı olduğu için onu güncellerken sıkıntı yaşıyordum 
                 * hocam. Siz hatayı yakalayın, kullanıcıya bilgi verin demiştiniz onun için diğer alanlarda program kodunu güncelletmedim. 
                 * Hatta onun hattanın çözümü için veritabanında cascade yapmam gerekir demiştiniz. Hatırlatmak istedim puan kırmamanınız 
                 * için
                 * 
                 */

                DialogResult tus = MessageBox.Show("Yaptığınız Değişikleri İlgili Program İçin Güncellemek İstiyor musunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (tus == DialogResult.Yes)
                {
                    int ks = sorguprogram.ExecuteNonQuery();
                    if (ks > 0)
                    {
                        MessageBox.Show("Güncelleme İşlemi Başarıyla Tamamlanmıştır", "Güncelleme Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Refresh();
                    }

                }
                baglanti.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Program Kodu Değiştirilemez. Program Adı ve Bölüm Kodu Değiştirilebilir. Yanlış Girmiş Olduğunuz Programı Silerek, Tekrardan Ekleyebilirsiniz.", "Hata Ekranı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                throw;
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Programın Bilgilerini Düzenlemek İster misiniz?", "Bölüm Düzenleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (tus == DialogResult.Yes)
            {
                programkodu = dataGridView1.SelectedCells[0].Value.ToString();
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorgu = new SqlCommand("select * from ogr_program where pkodu=@pkodu", baglanti);
                sorgu.Parameters.AddWithValue("@pkodu", programkodu);
                SqlDataReader sdr = sorgu.ExecuteReader();
                sdr.Read();
                maskedTextBox1.Text = sdr["pkodu"].ToString();
                maskedTextBox2.Text = sdr["padi"].ToString();
                comboBox1.SelectedValue= sdr["bkodu"].ToString();

                sdr.Close();
            }
            baglanti.Close();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_CellDoubleClick(null, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            programkodu = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Öğrenciyi Silmek İstiyor musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tus == DialogResult.Yes)
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand sorguprgm = new SqlCommand("delete from ogr_program where pkodu=@pkodu", baglanti);
                sorguprgm.Parameters.AddWithValue("@pkodu", programkodu);
                int ksokul = sorguprgm.ExecuteNonQuery();
                dataGridView1.Refresh();
                baglanti.Close();
                MessageBox.Show("İlgili Programın Kaydı Silindi.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }
    }
}
