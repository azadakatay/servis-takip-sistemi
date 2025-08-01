namespace otobusotomasyonu
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnServiseBinis = new Button();
            btnFabrikayaGiris = new Button();
            btnFabrikadanCikis = new Button();
            btnServiseDonus = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnAnaSayfa = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            lblKontenjan = new Label();
            cBoxYedekListe = new ComboBox();
            lblYedek = new Label();
            btnListe = new Button();
            lblServisler = new Label();
            lblKisi = new Label();
            btnYedegeAl = new Button();
            panelCihaz = new Panel();
            lblBaslik = new Label();
            pbDurum = new PictureBox();
            lblCihazEkran = new Label();
            lblTarih = new Label();
            lblSaat = new Label();
            lblServisOnerisi = new Label();
            lblKontenjanDurumu = new Label();
            timerSaat = new System.Windows.Forms.Timer(components);
            panelCihaz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDurum).BeginInit();
            SuspendLayout();
            // 
            // btnServiseBinis
            // 
            btnServiseBinis.Location = new Point(41, 27);
            btnServiseBinis.Name = "btnServiseBinis";
            btnServiseBinis.Size = new Size(169, 74);
            btnServiseBinis.TabIndex = 0;
            btnServiseBinis.Text = "Kartı Okutunuz";
            btnServiseBinis.UseVisualStyleBackColor = true;
            btnServiseBinis.Click += btnServiseBinis_Click;
            // 
            // btnFabrikayaGiris
            // 
            btnFabrikayaGiris.Location = new Point(41, 149);
            btnFabrikayaGiris.Name = "btnFabrikayaGiris";
            btnFabrikayaGiris.Size = new Size(169, 74);
            btnFabrikayaGiris.TabIndex = 1;
            btnFabrikayaGiris.Text = "Kartı Okutunuz";
            btnFabrikayaGiris.UseVisualStyleBackColor = true;
            // 
            // btnFabrikadanCikis
            // 
            btnFabrikadanCikis.Location = new Point(41, 270);
            btnFabrikadanCikis.Name = "btnFabrikadanCikis";
            btnFabrikadanCikis.Size = new Size(169, 74);
            btnFabrikadanCikis.TabIndex = 2;
            btnFabrikadanCikis.Text = "Kartı Okutunuz";
            btnFabrikadanCikis.UseVisualStyleBackColor = true;
            // 
            // btnServiseDonus
            // 
            btnServiseDonus.Location = new Point(41, 397);
            btnServiseDonus.Name = "btnServiseDonus";
            btnServiseDonus.Size = new Size(169, 74);
            btnServiseDonus.TabIndex = 3;
            btnServiseDonus.Text = "Kartı Okutunuz";
            btnServiseDonus.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(83, 9);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 8;
            label5.Text = "Servise Biniş";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(83, 131);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 9;
            label6.Text = "Fabrikaya Giriş";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(83, 252);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 10;
            label7.Text = "Fabrikadan Çıkış";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(83, 379);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 11;
            label8.Text = "Servise Dönüş";
            // 
            // btnAnaSayfa
            // 
            btnAnaSayfa.Location = new Point(238, 397);
            btnAnaSayfa.Name = "btnAnaSayfa";
            btnAnaSayfa.Size = new Size(155, 29);
            btnAnaSayfa.TabIndex = 12;
            btnAnaSayfa.Text = "Ana Sayfa";
            btnAnaSayfa.UseVisualStyleBackColor = true;
            btnAnaSayfa.Click += btnAnaSayfa_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(238, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(129, 23);
            comboBox1.TabIndex = 13;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(395, 27);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(129, 23);
            comboBox2.TabIndex = 14;
            // 
            // lblKontenjan
            // 
            lblKontenjan.AutoSize = true;
            lblKontenjan.Location = new Point(425, 456);
            lblKontenjan.Name = "lblKontenjan";
            lblKontenjan.Size = new Size(99, 15);
            lblKontenjan.TabIndex = 15;
            lblKontenjan.Text = "Kalan Kontenjan :";
            // 
            // cBoxYedekListe
            // 
            cBoxYedekListe.FormattingEnabled = true;
            cBoxYedekListe.Items.AddRange(new object[] { "Menemen", "Aliağa", "Bergama", "İzmir", "Bornova", "Karşıyaka", "Konak", "Çiğli", "Balçova", "Bayraklı", "Gaziemir", "Karabağlar", "Narlıdere ", "Buca", "Seferihisar", "Urla", "Foça", "Dikili", "Menderes", "Torbalı" });
            cBoxYedekListe.Location = new Point(544, 27);
            cBoxYedekListe.Name = "cBoxYedekListe";
            cBoxYedekListe.Size = new Size(129, 23);
            cBoxYedekListe.TabIndex = 16;
            cBoxYedekListe.SelectedIndexChanged += cBoxYedekListe_SelectedIndexChanged;
            // 
            // lblYedek
            // 
            lblYedek.AutoSize = true;
            lblYedek.Location = new Point(581, 9);
            lblYedek.Name = "lblYedek";
            lblYedek.Size = new Size(65, 15);
            lblYedek.TabIndex = 17;
            lblYedek.Text = "Yedek Liste";
            // 
            // btnListe
            // 
            btnListe.Location = new Point(238, 442);
            btnListe.Name = "btnListe";
            btnListe.Size = new Size(155, 29);
            btnListe.TabIndex = 18;
            btnListe.Text = "Çalışan Listesi";
            btnListe.UseVisualStyleBackColor = true;
            btnListe.Click += btnListe_Click;
            // 
            // lblServisler
            // 
            lblServisler.AutoSize = true;
            lblServisler.Location = new Point(281, 9);
            lblServisler.Name = "lblServisler";
            lblServisler.Size = new Size(50, 15);
            lblServisler.TabIndex = 19;
            lblServisler.Text = "Servisler";
            // 
            // lblKisi
            // 
            lblKisi.AutoSize = true;
            lblKisi.Location = new Point(438, 9);
            lblKisi.Name = "lblKisi";
            lblKisi.Size = new Size(38, 15);
            lblKisi.TabIndex = 20;
            lblKisi.Text = "Kişiler";
            // 
            // btnYedegeAl
            // 
            btnYedegeAl.Location = new Point(425, 397);
            btnYedegeAl.Name = "btnYedegeAl";
            btnYedegeAl.Size = new Size(155, 29);
            btnYedegeAl.TabIndex = 21;
            btnYedegeAl.Text = "Yedek Listeye Al";
            btnYedegeAl.UseVisualStyleBackColor = true;
            btnYedegeAl.Click += btnYedegeAl_Click;
            // 
            // panelCihaz
            // 
            panelCihaz.BackColor = Color.Gray;
            panelCihaz.BorderStyle = BorderStyle.FixedSingle;
            panelCihaz.Controls.Add(lblBaslik);
            panelCihaz.Controls.Add(pbDurum);
            panelCihaz.Controls.Add(lblCihazEkran);
            panelCihaz.Controls.Add(lblTarih);
            panelCihaz.Controls.Add(lblSaat);
            panelCihaz.Controls.Add(lblServisOnerisi);
            panelCihaz.Controls.Add(lblKontenjanDurumu);
            panelCihaz.Location = new Point(822, 55);
            panelCihaz.Name = "panelCihaz";
            panelCihaz.Size = new Size(430, 380);
            panelCihaz.TabIndex = 22;
            panelCihaz.Paint += panelCihaz_Paint;
            // 
            // lblBaslik
            // 
            lblBaslik.Dock = DockStyle.Top;
            lblBaslik.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBaslik.ForeColor = Color.White;
            lblBaslik.Location = new Point(0, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(428, 50);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "HABAŞ";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbDurum
            // 
            pbDurum.BackColor = Color.Transparent;
            pbDurum.Location = new Point(350, 60);
            pbDurum.Name = "pbDurum";
            pbDurum.Size = new Size(64, 64);
            pbDurum.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDurum.TabIndex = 1;
            pbDurum.TabStop = false;
            // 
            // lblCihazEkran
            // 
            lblCihazEkran.BackColor = Color.Black;
            lblCihazEkran.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCihazEkran.ForeColor = Color.White;
            lblCihazEkran.Location = new Point(20, 140);
            lblCihazEkran.Name = "lblCihazEkran";
            lblCihazEkran.Size = new Size(387, 60);
            lblCihazEkran.TabIndex = 2;
            lblCihazEkran.Text = "📷 Kart Okutun";
            lblCihazEkran.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.BackColor = Color.Black;
            lblTarih.Font = new Font("Segoe UI", 12F);
            lblTarih.ForeColor = Color.LightGray;
            lblTarih.Location = new Point(20, 345);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(88, 21);
            lblTarih.TabIndex = 3;
            lblTarih.Text = "17.07.2025";
            lblTarih.Click += lblTarih_Click;
            // 
            // lblSaat
            // 
            lblSaat.AutoSize = true;
            lblSaat.BackColor = Color.Black;
            lblSaat.Font = new Font("Segoe UI", 12F);
            lblSaat.ForeColor = Color.LightGray;
            lblSaat.Location = new Point(300, 345);
            lblSaat.Name = "lblSaat";
            lblSaat.Size = new Size(49, 21);
            lblSaat.TabIndex = 4;
            lblSaat.Text = "00:00";
            // 
            // lblServisOnerisi
            // 
            lblServisOnerisi.AutoSize = true;
            lblServisOnerisi.BackColor = Color.Transparent;
            lblServisOnerisi.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblServisOnerisi.ForeColor = Color.White;
            lblServisOnerisi.Location = new Point(20, 290);
            lblServisOnerisi.Name = "lblServisOnerisi";
            lblServisOnerisi.Size = new Size(0, 15);
            lblServisOnerisi.TabIndex = 0;
            lblServisOnerisi.Visible = false;
            // 
            // lblKontenjanDurumu
            // 
            lblKontenjanDurumu.AutoSize = true;
            lblKontenjanDurumu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKontenjanDurumu.ForeColor = Color.White;
            lblKontenjanDurumu.Location = new Point(15, 120);
            lblKontenjanDurumu.Name = "lblKontenjanDurumu";
            lblKontenjanDurumu.Size = new Size(0, 19);
            lblKontenjanDurumu.TabIndex = 0;
            // 
            // timerSaat
            // 
            timerSaat.Enabled = true;
            timerSaat.Interval = 1000;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1311, 502);
            Controls.Add(panelCihaz);
            Controls.Add(btnYedegeAl);
            Controls.Add(lblKisi);
            Controls.Add(lblServisler);
            Controls.Add(btnListe);
            Controls.Add(lblYedek);
            Controls.Add(cBoxYedekListe);
            Controls.Add(lblKontenjan);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(btnAnaSayfa);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnServiseDonus);
            Controls.Add(btnFabrikadanCikis);
            Controls.Add(btnFabrikayaGiris);
            Controls.Add(btnServiseBinis);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            panelCihaz.ResumeLayout(false);
            panelCihaz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDurum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Button btnServiseBinis;
        private System.Windows.Forms.Button btnFabrikayaGiris;
        private System.Windows.Forms.Button btnFabrikadanCikis;
        private System.Windows.Forms.Button btnServiseDonus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Button btnAnaSayfa;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label lblKontenjan;
        private ComboBox cBoxYedekListe;
        private Label lblYedek;
        private Button btnListe;
        private Label lblServisler;
        private Label lblKisi;
        private Button btnYedegeAl;
        private Panel panelCihaz;
        private Label lblBaslik;
        private PictureBox pbDurum;
        private Label lblCihazEkran;
        private Label lblSaat;
        private Label lblTarih;
        private System.Windows.Forms.Timer timerSaat;
        private Label lblServisOnerisi;
        private Label lblKontenjanDurumu;
    }
}
