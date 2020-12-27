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

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void sistemeKayıtlıBölümVeProgramlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BolumListele blmliste = new BolumListele();
            blmliste.MdiParent = this;
            blmliste.WindowState = FormWindowState.Maximized;
            blmliste.Show();
        }

        private void programEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bölümDüzenleSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlmDuzenle blmduzenle = new BlmDuzenle();
            blmduzenle.MdiParent = this;
            blmduzenle.WindowState = FormWindowState.Maximized;
            blmduzenle.Show();
        }

        private void programDüzenleSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramDuzenle prgmduzenle = new ProgramDuzenle();
            prgmduzenle.MdiParent = this;
            prgmduzenle.WindowState = FormWindowState.Maximized;
            prgmduzenle.Show();
        }

        private void danışmanDersKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanismanDersKaydi danismanderskaydi = new DanismanDersKaydi();
            danismanderskaydi.MdiParent = this;
            danismanderskaydi.WindowState = FormWindowState.Maximized;
            danismanderskaydi.Show();
        }

        private void derseGöreNotGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciNotGir ogrnotgir = new OgrenciNotGir();
            ogrnotgir.MdiParent = this;
            ogrnotgir.WindowState = FormWindowState.Maximized;
            ogrnotgir.Show();
        }

        private void öğrenciDanışmanıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ogrenci_DanismanDegistircs ogrdanismandegistir = new Ogrenci_DanismanDegistircs();
            ogrdanismandegistir.MdiParent = this;
            ogrdanismandegistir.WindowState = FormWindowState.Maximized;
            ogrdanismandegistir.Show();
        }

        private void böToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BolumlereKayitliDanismanlar bolumlerekayitlidanismanlar = new BolumlereKayitliDanismanlar();
            bolumlerekayitlidanismanlar.MdiParent = this;
            bolumlerekayitlidanismanlar.WindowState = FormWindowState.Maximized;
            bolumlerekayitlidanismanlar.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            ÖgrenciDersSilmeİslemleri ogrenciderssilmeis = new ÖgrenciDersSilmeİslemleri();
            ogrenciderssilmeis.MdiParent = this;
            ogrenciderssilmeis.WindowState = FormWindowState.Maximized;
            ogrenciderssilmeis.Show();
        }

        private void öğrencilereAitDersListeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrencilerinAldiklariDersListesi ogrencilerinaldiklaridrslistelesi = new OgrencilerinAldiklariDersListesi();
            ogrencilerinaldiklaridrslistelesi.MdiParent = this;
            ogrencilerinaldiklaridrslistelesi.WindowState = FormWindowState.Maximized;
            ogrencilerinaldiklaridrslistelesi.Show();
        }

        private void öğrenciTranskriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ogr_Transkript ogr_transkiript = new Ogr_Transkript();
            ogr_transkiript.MdiParent = this;
            ogr_transkiript.WindowState = FormWindowState.Maximized;
            ogr_transkiript.Show();
        }

        private void bölümlereKayıtlıDanışmanListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ogr_rapordanisman ogr_raporlamadanisman = new Ogr_rapordanisman();
            ogr_raporlamadanisman.MdiParent = this;
            ogr_raporlamadanisman.WindowState = FormWindowState.Maximized;
            ogr_raporlamadanisman.Show();
        }

        private void öğrenciDersKayıtListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bölümlereKayıtlıProgramlarListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rapor_BolumlereKayıtlıProgram ogr_bolumakayitliprogramlar = new Rapor_BolumlereKayıtlıProgram();
            ogr_bolumakayitliprogramlar.MdiParent = this;
            ogr_bolumakayitliprogramlar.WindowState = FormWindowState.Maximized;
            ogr_bolumakayitliprogramlar.Show();
        }

    }
    }
    
    

