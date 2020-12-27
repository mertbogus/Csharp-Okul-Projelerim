using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ekran_Koruyucu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point ortalama;
        int dgenislik = 180;
        int dyükseklik = 40;
        int R, G, B;
        int sayac = 1;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) //ESC ile kapanmasını istemiştiniz. If ile kontrolünü sağlatıp işlemi gerçekleştirdim.
            {
                Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString(); //Timerden sistem saati ve tarihini alıp bunu stringe dönüştürdüm
            ortalama = new Point(this.Width / 2 - 80, this.Height / 2 - 26);
            label1.Location = new Point(this.Width / 2 - 70, this.Height / 2 - 15); /*Burada ise hocam labeli
            ortalama da sıkıntı çekince kod ile yaptım deneye deneye ortaladım */
            timer1.Interval = 50; //ıntervalin 50 olmasını istemiştiniz
            timer1.Start();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString();
            Graphics graphics = this.CreateGraphics();
            this.dgenislik += 8;  //Burada  ise sürekli genislik ve yüksek değerlerini arttırdım.
            this.dyükseklik += 4;
            this.ortalama.Y -= 2; //kordinaatları küçülttüm burada  ismail hocam
            this.ortalama.X -= 4;
            this.sayac++;
            Random rnd = new Random();
            R = rnd.Next(255);
            G = rnd.Next(255);
            B = rnd.Next(255);
            Color renk;
            renk = Color.FromArgb(R, G, B);
            Pen kalem = new Pen(renk,15);
            graphics.DrawRectangle(kalem, this.ortalama.X, this.ortalama.Y, this.dgenislik, this.dyükseklik);
             if (this.ortalama.X <= 0 && this.ortalama.Y <= 0)
            {
                this.BackColor = Color.White; //arkaplan renginin beyaz olmasını istemiştiniz
                this.Refresh();
                this.dgenislik = 180; /*Bu kısımda başa döneceği için refresh yaptım ve kareye başlangıçtaki 
                değerlerini verdim tekrardan*/
                this.dyükseklik = 40;
                this.ortalama = new Point(this.Width / 2 - 80, this.Height / 2 - 26);
            }
        }
    }
}

        
