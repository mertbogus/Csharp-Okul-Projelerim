using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrIsler
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        private void AnaEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void sistemeKayıtlıÖğrenciListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciListesi OgrListe = new OgrenciListesi();
            OgrListe.MdiParent = this;
            OgrListe.WindowState = FormWindowState.Maximized;
            OgrListe.Show();
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciEkle ogrEkle = new OgrenciEkle();
            ogrEkle.MdiParent = this;
            ogrEkle.WindowState = FormWindowState.Maximized;
            ogrEkle.Show();
        }

        private void öğrenciDüzenleSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDuzenle ogrDuzenle = new OgrenciDuzenle();
            ogrDuzenle.MdiParent = this;
            ogrDuzenle.WindowState = FormWindowState.Maximized;
            ogrDuzenle.Show();
        }

        private void öğrenciDersKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciDersKaydi derskaydi = new OgrenciDersKaydi();
            derskaydi.MdiParent = this;
            derskaydi.WindowState = FormWindowState.Maximized;
            derskaydi.Show();
        }
    }
}
