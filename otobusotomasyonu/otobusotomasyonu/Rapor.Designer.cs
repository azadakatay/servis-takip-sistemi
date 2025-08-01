namespace otobusotomasyonu
{
    partial class Rapor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cBoxRaporservis = new ComboBox();
            cBoxRaporvardiya = new ComboBox();
            dtpbaslangic = new DateTimePicker();
            dtpbitis = new DateTimePicker();
            label5 = new Label();
            geributon = new Button();
            btnRaporla = new Button();
            dataGridrapor = new DataGridView();
            adsoyad = new DataGridViewTextBoxColumn();
            tarih = new DataGridViewTextBoxColumn();
            servis = new DataGridViewTextBoxColumn();
            servisebinis = new DataGridViewTextBoxColumn();
            fabrikagirisi = new DataGridViewTextBoxColumn();
            fabrikacikisi = new DataGridViewTextBoxColumn();
            servisledonusu = new DataGridViewTextBoxColumn();
            vardiya = new DataGridViewTextBoxColumn();
            lblIstatistik = new Label();
            btnExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridrapor).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 69);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Servis :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 103);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Vardiya :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(536, 72);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 2;
            label3.Text = "Başlangıç Tarihi : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(536, 103);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 3;
            label4.Text = "Bitiş Tarihi :";
            // 
            // cBoxRaporservis
            // 
            cBoxRaporservis.FormattingEnabled = true;
            cBoxRaporservis.Location = new Point(114, 61);
            cBoxRaporservis.Name = "cBoxRaporservis";
            cBoxRaporservis.Size = new Size(148, 23);
            cBoxRaporservis.TabIndex = 4;
            // 
            // cBoxRaporvardiya
            // 
            cBoxRaporvardiya.FormattingEnabled = true;
            cBoxRaporvardiya.Location = new Point(114, 95);
            cBoxRaporvardiya.Name = "cBoxRaporvardiya";
            cBoxRaporvardiya.Size = new Size(148, 23);
            cBoxRaporvardiya.TabIndex = 5;
            // 
            // dtpbaslangic
            // 
            dtpbaslangic.Format = DateTimePickerFormat.Short;
            dtpbaslangic.Location = new Point(652, 61);
            dtpbaslangic.Name = "dtpbaslangic";
            dtpbaslangic.Size = new Size(148, 23);
            dtpbaslangic.TabIndex = 6;
            // 
            // dtpbitis
            // 
            dtpbitis.Format = DateTimePickerFormat.Short;
            dtpbitis.Location = new Point(652, 97);
            dtpbitis.Name = "dtpbitis";
            dtpbitis.Size = new Size(148, 23);
            dtpbitis.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.Location = new Point(45, 152);
            label5.Name = "label5";
            label5.Size = new Size(93, 20);
            label5.TabIndex = 8;
            label5.Text = "İstatistikler:";
            // 
            // geributon
            // 
            geributon.Location = new Point(859, 12);
            geributon.Name = "geributon";
            geributon.Size = new Size(113, 30);
            geributon.TabIndex = 9;
            geributon.Text = "Geri";
            geributon.UseVisualStyleBackColor = true;
            // 
            // btnRaporla
            // 
            btnRaporla.Location = new Point(536, 258);
            btnRaporla.Name = "btnRaporla";
            btnRaporla.Size = new Size(197, 48);
            btnRaporla.TabIndex = 10;
            btnRaporla.Text = "Raporla";
            btnRaporla.UseVisualStyleBackColor = true;
            // 
            // dataGridrapor
            // 
            dataGridrapor.AllowUserToAddRows = false;
            dataGridrapor.AllowUserToDeleteRows = false;
            dataGridrapor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridrapor.Location = new Point(45, 335);
            dataGridrapor.Name = "dataGridrapor";
            dataGridrapor.ReadOnly = true;
            dataGridrapor.Size = new Size(906, 330);
            dataGridrapor.TabIndex = 11;
            // 
            // adsoyad
            // 
            adsoyad.Name = "adsoyad";
            // 
            // tarih
            // 
            tarih.Name = "tarih";
            // 
            // servis
            // 
            servis.Name = "servis";
            // 
            // servisebinis
            // 
            servisebinis.Name = "servisebinis";
            // 
            // fabrikagirisi
            // 
            fabrikagirisi.Name = "fabrikagirisi";
            // 
            // fabrikacikisi
            // 
            fabrikacikisi.Name = "fabrikacikisi";
            // 
            // servisledonusu
            // 
            servisledonusu.Name = "servisledonusu";
            // 
            // vardiya
            // 
            vardiya.Name = "vardiya";
            // 
            // lblIstatistik
            // 
            lblIstatistik.BorderStyle = BorderStyle.FixedSingle;
            lblIstatistik.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIstatistik.ForeColor = Color.DarkBlue;
            lblIstatistik.Location = new Point(45, 186);
            lblIstatistik.Name = "lblIstatistik";
            lblIstatistik.Size = new Size(427, 120);
            lblIstatistik.TabIndex = 12;
            lblIstatistik.Text = "İstatistikler buraya gelecek.";
            lblIstatistik.Click += lblIstatistik_Click;
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(754, 258);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(197, 48);
            btnExcel.TabIndex = 13;
            btnExcel.Text = "Excel'e Aktar";
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click_1;
            // 
            // Rapor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1297, 720);
            Controls.Add(btnExcel);
            Controls.Add(lblIstatistik);
            Controls.Add(dataGridrapor);
            Controls.Add(btnRaporla);
            Controls.Add(geributon);
            Controls.Add(label5);
            Controls.Add(dtpbitis);
            Controls.Add(dtpbaslangic);
            Controls.Add(cBoxRaporvardiya);
            Controls.Add(cBoxRaporservis);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Rapor";
            Text = "Rapor";
            Load += Rapor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridrapor).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBoxRaporservis;
        private System.Windows.Forms.ComboBox cBoxRaporvardiya;
        private System.Windows.Forms.DateTimePicker dtpbaslangic;
        private System.Windows.Forms.DateTimePicker dtpbitis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button geributon;
        private System.Windows.Forms.Button btnRaporla;
        private System.Windows.Forms.DataGridView dataGridrapor;
        private System.Windows.Forms.Label lblIstatistik;

        private System.Windows.Forms.DataGridViewTextBoxColumn adsoyad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn servis;
        private System.Windows.Forms.DataGridViewTextBoxColumn servisebinis;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabrikagirisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabrikacikisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn servisledonusu;
        private System.Windows.Forms.DataGridViewTextBoxColumn vardiya;
        private Button btnExcel;
    }
}
