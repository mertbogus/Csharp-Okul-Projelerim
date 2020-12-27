namespace OgrIsler
{
    partial class Rapor_BolumlereKayıtlıProgram
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ogr_programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bolumlerebagliprogramlar = new OgrIsler.bolumlerebagliprogramlar();
            this.ogr_programTableAdapter = new OgrIsler.bolumlerebagliprogramlarTableAdapters.ogr_programTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ogr_programBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bolumlerebagliprogramlar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1639, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bölüm Seçme İşlemi";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(514, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "Listele";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(127, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bölüm Seç:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reportViewer1);
            this.groupBox2.Location = new System.Drawing.Point(13, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1638, 673);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bölüme Bağlı Programlar";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet3";
            reportDataSource1.Value = this.ogr_programBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OgrIsler.programabaglibolumler.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 36);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1626, 631);
            this.reportViewer1.TabIndex = 0;
            // 
            // ogr_programBindingSource
            // 
            this.ogr_programBindingSource.DataMember = "ogr_program";
            this.ogr_programBindingSource.DataSource = this.bolumlerebagliprogramlar;
            // 
            // bolumlerebagliprogramlar
            // 
            this.bolumlerebagliprogramlar.DataSetName = "bolumlerebagliprogramlar";
            this.bolumlerebagliprogramlar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ogr_programTableAdapter
            // 
            this.ogr_programTableAdapter.ClearBeforeFill = true;
            // 
            // Rapor_BolumlereKayıtlıProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Rapor_BolumlereKayıtlıProgram";
            this.Text = "Bölümlere Kayıtlı Programlar";
            this.Load += new System.EventHandler(this.Rapor_BolumlereKayıtlıProgram_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ogr_programBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bolumlerebagliprogramlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ogr_programBindingSource;
        private bolumlerebagliprogramlar bolumlerebagliprogramlar;
        private bolumlerebagliprogramlarTableAdapters.ogr_programTableAdapter ogr_programTableAdapter;
    }
}