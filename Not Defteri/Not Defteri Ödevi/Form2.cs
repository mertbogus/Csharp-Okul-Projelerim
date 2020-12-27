using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_Defteri_Ödevi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string Metin = metin.Trim();
            int boslukluaraktersayisi = metin.Length;
            string[] kelimeler = metin.Split(' ');
            int bosluksayisi = kelimeler.Length - 1;
            int bosluksuzkaraktersayisi = Metin.Length - bosluksayisi;
            int kelimesayisi = kelimeler.Length;
            string[] cumleler = Metin.Split('.');
            int cumlesayisi = cumleler.Length - 1;

            label5.Text = boslukluaraktersayisi.ToString();
            label6.Text = boslukluaraktersayisi.ToString();
            label7.Text = kelimesayisi.ToString();
            label8.Text = cumlesayisi.ToString();
        }
        public string metin;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
