﻿using System;
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
    public partial class Ogr_Transkript : Form
    {
        public Ogr_Transkript()
        {
            InitializeComponent();
        }

        private void Ogr_Transkript_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DataTable1TableAdapter.Fillbilgi(this.ogrencitranskript.DataTable1,maskedTextBox1.Text);
            this.ogr_notlarTableAdapter.Fillnot(this.ogrencitranskiriptt.ogr_notlar,maskedTextBox1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
