using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Not_Defteri_Ödevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void DosyaAc()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Dosya Seç";
            of.Filter = "Text Dosyaları(*.txt|*.txt|Tüm Dosyalar (*.*)|*.*";
            DialogResult tus = of.ShowDialog();
            if (tus==DialogResult.OK)
            {
                StreamReader sr = new StreamReader(of.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                islem = false;
                Dosyadi = of.FileName;
                this.Text = of.SafeFileName + "-Not Defteri";
            }
        }
        void Dosyakaydet(string gelendosya)
        {
            StreamWriter sw = new StreamWriter(gelendosya);
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
        }
        void FarkliKaydet()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Dosya Seç";
            sf.Filter = "Text Dosyaları(*.txt|*.txt|Tüm Dosyalar (*.*)|*.*";
            sf.FileName = "";
            DialogResult tus = sf.ShowDialog();
            if (tus==DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                Dosyadi = sf.FileName;
                string[] dizi = Dosyadi.Split('\\');
                this.Text = dizi[dizi.Length - 1] + "-Not Defteri";
            }
        }
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Karakter Sayısı: " + richTextBox1.Text.Length.ToString();
            islem = true;
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void ileriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void tarihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime tarihsaat = DateTime.Now;
            richTextBox1.Text += tarihsaat.ToShortDateString() + " " + tarihsaat.ToLongTimeString();

        }

        private void sözcükKaydırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sözcükKaydırToolStripMenuItem.Checked == true)
            {
                richTextBox1.WordWrap = true;
            }
            else
            {
                sözcükKaydırToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog df = new FontDialog();
            DialogResult tus = df.ShowDialog();
            if (tus==DialogResult.OK)
            {
                richTextBox1.SelectionFont = df.Font;
            }
        }

        private void renkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult tus = ShowDialog();
            if (tus == DialogResult.OK)
            {
                richTextBox1.SelectionColor = cd.Color;
            }
        }

        private void sağaHizalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void ortalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void solaHizalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkinda hk = new Hakkinda();
            hk.ShowDialog();
        }

        private void istatikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ista = new Form2();
            ista.metin = richTextBox1.Text;
            ista.Show();
        }
        bool islem = false;
        string Dosyadi = "Yeni Metin Belgesi";
        private void Form1_Load(object sender, EventArgs e)
        {
            Dosyadi = "Yeni Metin Belgesi";
            this.Text = Dosyadi + "-Not Defteri";
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (islem==true)
            {
                DialogResult tus = MessageBox.Show("Yaptığınız Değişiklikleri Kaydetmek İstiyor musunuz?", "Kayıt İşlemi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (tus==DialogResult.Yes)
                {
                    if (Dosyadi == "Yeni Metin Belgesi")
                    {
                        FarkliKaydet();
                    }
                    else
                    {
                        Dosyakaydet(Dosyadi);
                    }
                    richTextBox1.Clear();
                    islem = false;
                    this.Text = "Yeni Metin Belgesi - Not Defteri";
                }
                else if (tus==DialogResult.No)
                {
                    richTextBox1.Clear();
                    islem = false;
                    this.Text = "Yeni Metin Belgesi - Not Defteri";
                }
            }
            else
            {
                richTextBox1.Clear();
            }
            Dosyadi = "Yeni Metin Belgesi";
            this.Text = "Not Defteri - " + Dosyadi;
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (islem==true)
            {
                DialogResult tus = MessageBox.Show("Yaptığınız Değişiklikleri Kaydetmek İstiyor musunuz?", "Kayıt İşlemi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (tus==DialogResult.Yes)
                {
                    if (Dosyadi=="Yeni Metin Belgesi")

                    {
                        FarkliKaydet();
                    }
                    else
                    {
                        Dosyakaydet(Dosyadi);
                    }
                    DosyaAc();
                }
                else if (tus== DialogResult.No)
                {
                    DosyaAc();
                }
            }
            else
            {
                DosyaAc();
            }
        }

        private void kaydetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Dosyadi=="Yeni Metin Belgesi")
            {
                FarkliKaydet();
            }
            else
            {
                Dosyakaydet(Dosyadi);
            }
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FarkliKaydet();
        }

        private void baskıOnizlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.ShowDialog();
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (islem==true)
            {
                DialogResult tus = MessageBox.Show("Yaptığınız Değişiklikleri Kaydetmek İstiyor musunuz?", "Kayıt İşlemi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (tus==DialogResult.Yes)
                {
                    if (Dosyadi=="Yeni Metin Belgesi")
                    {
                        FarkliKaydet();
                    }
                    else
                    {
                        Dosyakaydet(Dosyadi);
                    }
                }
                else if (tus==DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

        }
    }
}
