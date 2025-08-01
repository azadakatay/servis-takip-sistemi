using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace otobusotomasyonu
{
    public partial class bilgiler : Form
    {
        private string servisAdi;

        public bilgiler(string servisAdi)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.servisAdi = servisAdi;
            this.Text = servisAdi;

            dataGridView1.Dock = DockStyle.Fill;
            this.Load += bilgiler_Load;
            vardiya.SelectedIndexChanged += vardiya_SelectedIndexChanged;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint; //  Satır numarası eklendi

            // Sütunları oluştur
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("adsoyad", "Ad Soyad");
                dataGridView1.Columns.Add("tarih", "Tarih");
                dataGridView1.Columns.Add("servis", "Servis");
                dataGridView1.Columns.Add("servisegelisi", "Servise Geliş");
                dataGridView1.Columns.Add("fabrikagirisi", "Fabrika Girişi");
                dataGridView1.Columns.Add("fabrikacikisi", "Fabrika Çıkışı");
                dataGridView1.Columns.Add("servisledonusu", "Servis Dönüş");
                dataGridView1.Columns.Add("yedekliste", "Yedek Liste");
            }

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            btngeri.Click += btngeri_Click;
            label2.Click += label2_Click;
            yedegiEkle.Click += yedegiEkle_Click;
        }
        private void bilgiler_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Segoe UI", 10);
            vardiya.Font = new Font("Segoe UI", 10);
            vardiya.DropDownStyle = ComboBoxStyle.DropDownList;

            // DataGridView stil
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = true; //  Satır numarası için açık olmalı
            dataGridView1.MultiSelect = false;

            // Butonlar
            foreach (var btn in new[] { btngeri, btnKartSistemi })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.FromArgb(0, 122, 204);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            btnTemizle.FlatStyle = FlatStyle.Flat;
            btnTemizle.FlatAppearance.BorderSize = 0;
            btnTemizle.BackColor = Color.FromArgb(220, 53, 69);
            btnTemizle.ForeColor = Color.White;
            btnTemizle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Vardiya listesi
            vardiya.Items.Clear();
            vardiya.Items.AddRange(new[] {
                "tüm vardiyalar", "1. vardiya", "2. vardiya", "3. vardiya", "memur vardiyası"
            });
            vardiya.SelectedIndex = 0;

            dataGridView1.Rows.Clear();
            var dt = DatabaseHelper.KayitlariGetir(servisAdi);
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    row["AdSoyad"].ToString(),
                    Convert.ToDateTime(row["Tarih"]).ToString("yyyy-MM-dd"),
                    row["Servis"].ToString(),
                    row["ServiseBinisSaat"] == DBNull.Value ? "" : row["ServiseBinisSaat"].ToString(),
                    row["FabrikaGirisSaat"] == DBNull.Value ? "" : row["FabrikaGirisSaat"].ToString(),
                    row["FabrikadanCikisSaat"] == DBNull.Value ? "" : row["FabrikadanCikisSaat"].ToString(),
                    row["ServiseDonusSaat"] == DBNull.Value ? "" : row["ServiseDonusSaat"].ToString(),
                    ""
                );
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "yedekliste" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.CellStyle.BackColor = Color.LightGoldenrodYellow;
                e.CellStyle.ForeColor = Color.DarkRed;
            }
        }
        public void YedekListeyeEkle(string adSoyad, string neredenGeldi)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["yedekliste"].Value?.ToString() == adSoyad)
                    return;
            }

            dataGridView1.Rows.Add(new object[] { "", "", "", "", "", "", "", adSoyad });
        }
        public void YeniKayitEkle(string adSoyad, string tarih, string servis, string saat, string hareketTipi)
        {
            DateTime tarihDT = DateTime.Parse(tarih);
            TimeSpan saatTS = TimeSpan.Parse(saat);
            DatabaseHelper.KayitEkleGuncelle(adSoyad, servis, tarihDT, hareketTipi, saatTS);

            switch (hareketTipi)
            {
                case "Servise Biniş":
                    dataGridView1.Rows.Add(adSoyad, tarih, servis, saat, "", "", "", ""); break;
                case "Fabrikaya Giriş":
                    GüncelleSonKayit(servis, adSoyad, "fabrikagirisi", saat); break;
                case "Fabrikadan Çıkış":
                    GüncelleSonKayit(servis, adSoyad, "fabrikacikisi", saat); break;
                case "Servise Dönüş":
                    GüncelleSonKayit(servis, adSoyad, "servisledonusu", saat); break;
            }
        }
        private void GüncelleSonKayit(string servis, string adSoyad, string kolonAdi, string yeniDeger)
        {
            int kolonIndex = dataGridView1.Columns[kolonAdi]?.Index ?? -1;
            if (kolonIndex == -1) return;

            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                var row = dataGridView1.Rows[i];
                if (row.IsNewRow) continue;
                if (row.Cells["servis"].Value?.ToString() == servis && row.Cells["adsoyad"].Value?.ToString() == adSoyad)
                {
                    row.Cells[kolonIndex].Value = yeniDeger;
                    break;
                }
            }
        }
        private void yedegiEkle_Click(object sender, EventArgs e)
        {
            int kontenjan = DatabaseHelper.KontenjanGetir(servisAdi);
            if (kontenjan <= 0)
            {
                MessageBox.Show("Serviste boş kontenjan yok.");
                return;
            }

            int ilkKontenjan = kontenjan;
            int eklenecekKisiSayisi = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                string yedekAd = row.Cells["yedekliste"].Value?.ToString();

                if (!string.IsNullOrEmpty(yedekAd) && kontenjan > 0)
                {
                    string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                    string saat = DateTime.Now.ToString("HH:mm:ss");

                    row.Cells["adsoyad"].Value = yedekAd;
                    row.Cells["tarih"].Value = tarih;
                    row.Cells["servis"].Value = servisAdi;
                    row.Cells["servisledonusu"].Value = saat;
                    row.Cells["yedekliste"].Value = "";

                    DatabaseHelper.KayitEkleGuncelle(yedekAd, servisAdi, DateTime.Now, "Servise Dönüş", TimeSpan.Parse(saat));

                    kontenjan--;
                    eklenecekKisiSayisi++;
                }
            }

            if (eklenecekKisiSayisi > 0)
            {
                DatabaseHelper.KontenjanGuncelle(servisAdi, ilkKontenjan - eklenecekKisiSayisi);
                MessageBox.Show($"{eklenecekKisiSayisi} kişi yedek listeden servise alındı.", "Başarılı");
            }
            else
            {
                MessageBox.Show("Yedek listeden alınacak kişi bulunamadı veya kontenjan yetersiz.");
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        private void vardiya_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenVardiya = vardiya.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(secilenVardiya)) return;

            int durakSayisi = 0;
            List<DateTime> servisGelisSaatleri = new List<DateTime>();

            // Eğer tüm vardiyalar seçiliyse filtreleme yapmadan hepsini gösterir
            if (secilenVardiya == "tüm vardiyalar")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.Visible = true;

                    string servisGelisStr = row.Cells["servisegelisi"].Value?.ToString();
                    if (DateTime.TryParse(servisGelisStr, out DateTime servisGelisDT))
                    {
                        servisGelisSaatleri.Add(servisGelisDT);
                    }
                }

                // Durak sayısı hesapla
                servisGelisSaatleri.Sort();
                for (int i = 1; i < servisGelisSaatleri.Count; i++)
                {
                    TimeSpan fark = servisGelisSaatleri[i] - servisGelisSaatleri[i - 1];
                    if (fark.TotalMinutes > 1)
                        durakSayisi++;
                }
                if (servisGelisSaatleri.Count > 0)
                    durakSayisi += 1;

                label2.Text = durakSayisi.ToString();
                return;
            }

            // Diğer vardiyalar için önce hepsini gizle
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.Visible = false;
            }

            // Seçilen vardiyaya göre filtreleme yap
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string servisGelisStr = row.Cells["servisegelisi"].Value?.ToString();
                string fabrikaGirisStr = row.Cells["fabrikagirisi"].Value?.ToString();

                if (!TimeSpan.TryParse(fabrikaGirisStr, out TimeSpan fabrikaGirisSaat))
                {
                    row.Visible = false;
                    continue;
                }

                bool uygunMu = false;

                switch (secilenVardiya)
                {
                    case "1. vardiya":
                        if (fabrikaGirisSaat >= TimeSpan.FromHours(7) && fabrikaGirisSaat < TimeSpan.FromHours(8))
                            uygunMu = true;
                        break;
                    case "2. vardiya":
                        if (fabrikaGirisSaat >= TimeSpan.FromHours(15) && fabrikaGirisSaat < TimeSpan.FromHours(16))
                            uygunMu = true;
                        break;
                    case "3. vardiya":
                        if (fabrikaGirisSaat >= TimeSpan.FromHours(23) && fabrikaGirisSaat < TimeSpan.FromHours(24))
                            uygunMu = true;
                        break;
                    case "memur vardiyası":
                        if (fabrikaGirisSaat >= TimeSpan.FromHours(8) && fabrikaGirisSaat < TimeSpan.FromHours(9))
                            uygunMu = true;
                        break;
                }

                if (uygunMu)
                {
                    row.Visible = true;
                    if (DateTime.TryParse(servisGelisStr, out DateTime servisGelisDT))
                    {
                        servisGelisSaatleri.Add(servisGelisDT);
                    }
                }
            }

            // Durak sayısı hesapla
            servisGelisSaatleri.Sort();
            for (int i = 1; i < servisGelisSaatleri.Count; i++)
            {
                TimeSpan fark = servisGelisSaatleri[i] - servisGelisSaatleri[i - 1];
                if (fark.TotalMinutes > 1)
                    durakSayisi++;
            }
            if (servisGelisSaatleri.Count > 0)
                durakSayisi += 1;

            label2.Text = durakSayisi.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btngeri_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Form1)
                {
                    form.Show();
                    form.BringToFront();
                    break;
                }
            }
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Listeyi temizlemek istediğinize emin misiniz?\nBu işlem sadece ekrandaki listeyi temizler ve veri tabanını etkilemez.",
                "Onay Gerekli", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                label2.Text = "0";
            }
        }

        private void btnKartSistemi_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        //  Sıra numarası yazdırmak için gerekli event
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                string rowNumber = (e.RowIndex + 1).ToString();
                e.Graphics.DrawString(rowNumber, dataGridView1.DefaultCellStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 6);
            }
        }
    }
}
