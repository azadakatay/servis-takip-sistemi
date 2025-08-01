namespace otobusotomasyonu
{
    partial class bilgiler
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btngeri;
        private System.Windows.Forms.ComboBox vardiya;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            adsoyad = new DataGridViewTextBoxColumn();
            tarih = new DataGridViewTextBoxColumn();
            servis = new DataGridViewTextBoxColumn();
            servisegelisi = new DataGridViewTextBoxColumn();
            fabrikagirisi = new DataGridViewTextBoxColumn();
            fabrikacikisi = new DataGridViewTextBoxColumn();
            servisledonusu = new DataGridViewTextBoxColumn();
            yedekliste = new DataGridViewTextBoxColumn();
            btngeri = new Button();
            vardiya = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnTemizle = new Button();
            yedegiEkle = new Button();
            btnKartSistemi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { adsoyad, tarih, servis, servisegelisi, fabrikagirisi, fabrikacikisi, servisledonusu, yedekliste });
            dataGridView1.Location = new Point(0, -1);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 170;
            dataGridView1.Size = new Size(1316, 520);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // adsoyad
            // 
            adsoyad.HeaderText = "Ad Soyad";
            adsoyad.Name = "adsoyad";
            // 
            // tarih
            // 
            tarih.HeaderText = "Tarih";
            tarih.Name = "tarih";
            // 
            // servis
            // 
            servis.HeaderText = "Servis";
            servis.Name = "servis";
            // 
            // servisegelisi
            // 
            servisegelisi.HeaderText = "Servise Gelişi";
            servisegelisi.Name = "servisegelisi";
            // 
            // fabrikagirisi
            // 
            fabrikagirisi.HeaderText = "Fabrika Girişi";
            fabrikagirisi.Name = "fabrikagirisi";
            // 
            // fabrikacikisi
            // 
            fabrikacikisi.HeaderText = "Fabrikadan Çıkışı";
            fabrikacikisi.Name = "fabrikacikisi";
            // 
            // servisledonusu
            // 
            servisledonusu.HeaderText = "Servisle Dönüşü";
            servisledonusu.Name = "servisledonusu";
            // 
            // yedekliste
            // 
            yedekliste.HeaderText = "Yedek Liste";
            yedekliste.Name = "yedekliste";
            // 
            // btngeri
            // 
            btngeri.Location = new Point(1063, 114);
            btngeri.Name = "btngeri";
            btngeri.Size = new Size(176, 35);
            btngeri.TabIndex = 1;
            btngeri.Text = "Geri";
            btngeri.UseVisualStyleBackColor = true;
            btngeri.Click += btngeri_Click;
            // 
            // vardiya
            // 
            vardiya.FormattingEnabled = true;
            vardiya.Items.AddRange(new object[] { "tüm vardiyalar", "1. vardiya", "2. vardiya", "3. vardiya", "memur vardiyası" });
            vardiya.Location = new Point(1063, 66);
            vardiya.Name = "vardiya";
            vardiya.Size = new Size(176, 23);
            vardiya.TabIndex = 2;
            vardiya.SelectedIndexChanged += vardiya_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(1063, 340);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 3;
            label1.Text = "Durak Sayısı :";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(1181, 340);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 4;
            label2.Text = "label2";
            label2.Click += label2_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Location = new Point(1063, 229);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(176, 35);
            btnTemizle.TabIndex = 5;
            btnTemizle.Text = "Listeyi Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // yedegiEkle
            // 
            yedegiEkle.Location = new Point(1063, 286);
            yedegiEkle.Name = "yedegiEkle";
            yedegiEkle.Size = new Size(176, 35);
            yedegiEkle.TabIndex = 6;
            yedegiEkle.Text = "Yedekleri Servise Al";
            yedegiEkle.UseVisualStyleBackColor = true;
            yedegiEkle.Click += yedegiEkle_Click;
            // 
            // btnKartSistemi
            // 
            btnKartSistemi.Location = new Point(1063, 171);
            btnKartSistemi.Name = "btnKartSistemi";
            btnKartSistemi.Size = new Size(176, 35);
            btnKartSistemi.TabIndex = 7;
            btnKartSistemi.Text = "Cihaza Yönlendir";
            btnKartSistemi.UseVisualStyleBackColor = true;
            btnKartSistemi.Click += btnKartSistemi_Click;
            // 
            // bilgiler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1316, 516);
            Controls.Add(btnKartSistemi);
            Controls.Add(yedegiEkle);
            Controls.Add(btnTemizle);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(vardiya);
            Controls.Add(btngeri);
            Controls.Add(dataGridView1);
            Name = "bilgiler";
            Text = "bilgiler";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);

        }
        private Button btnTemizle;
        private Button yedegiEkle;
        private DataGridViewTextBoxColumn adsoyad;
        private DataGridViewTextBoxColumn tarih;
        private DataGridViewTextBoxColumn servis;
        private DataGridViewTextBoxColumn servisegelisi;
        private DataGridViewTextBoxColumn fabrikagirisi;
        private DataGridViewTextBoxColumn fabrikacikisi;
        private DataGridViewTextBoxColumn servisledonusu;
        private DataGridViewTextBoxColumn yedekliste;
        private Button btnKartSistemi;
    }
}
