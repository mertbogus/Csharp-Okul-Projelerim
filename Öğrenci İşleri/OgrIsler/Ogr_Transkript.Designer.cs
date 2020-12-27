namespace OgrIsler
{
    partial class Ogr_Transkript
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ogrencitranskript = new OgrIsler.ogrencitranskript();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTable1TableAdapter = new OgrIsler.ogrencitranskriptTableAdapters.DataTable1TableAdapter();
            this.ogrencitranskiriptt = new OgrIsler.ogrencitranskiriptt();
            this.ogr_notlarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ogr_notlarTableAdapter = new OgrIsler.ogrencitranskiripttTableAdapters.ogr_notlarTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ogrencitranskript)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogrencitranskiriptt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogr_notlarBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(13, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1638, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Öğrenci Bilgileri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Öğrenci Numarası:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(170, 43);
            this.maskedTextBox1.Mask = "000000000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(261, 22);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(576, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Listele";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reportViewer1);
            this.groupBox2.Location = new System.Drawing.Point(13, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1638, 681);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Öğrenci Transkiript";
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSet2";
            reportDataSource3.Value = this.DataTable1BindingSource;
            reportDataSource4.Name = "DataSet3";
            reportDataSource4.Value = this.ogr_notlarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OgrIsler.ogrencitranskript.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(7, 22);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1625, 659);
            this.reportViewer1.TabIndex = 0;
            // 
            // ogrencitranskript
            // 
            this.ogrencitranskript.DataSetName = "ogrencitranskript";
            this.ogrencitranskript.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.ogrencitranskript;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // ogrencitranskiriptt
            // 
            this.ogrencitranskiriptt.DataSetName = "ogrencitranskiriptt";
            this.ogrencitranskiriptt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ogr_notlarBindingSource
            // 
            this.ogr_notlarBindingSource.DataMember = "ogr_notlar";
            this.ogr_notlarBindingSource.DataSource = this.ogrencitranskiriptt;
            // 
            // ogr_notlarTableAdapter
            // 
            this.ogr_notlarTableAdapter.ClearBeforeFill = true;
            // 
            // Ogr_Transkript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Ogr_Transkript";
            this.Text = "Öğrenci Transkript";
            this.Load += new System.EventHandler(this.Ogr_Transkript_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ogrencitranskript)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogrencitranskiriptt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogr_notlarBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private ogrencitranskript ogrencitranskript;
        private System.Windows.Forms.BindingSource ogr_notlarBindingSource;
        private ogrencitranskiriptt ogrencitranskiriptt;
        private ogrencitranskriptTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private ogrencitranskiripttTableAdapters.ogr_notlarTableAdapter ogr_notlarTableAdapter;
    }
}