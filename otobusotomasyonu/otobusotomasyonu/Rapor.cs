using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace otobusotomasyonu
{
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Rapor_Load(object sender, EventArgs e)
        {
            FormLoadAyarlar();
            IstatistikleriGoster();
        }

        private void FormLoadAyarlar()
        {
            // Servis combobox doldurur
            cBoxRaporservis.Items.Clear();
            cBoxRaporservis.Items.Add("Tümü");
            cBoxRaporservis.Items.Add("Menemen");
            cBoxRaporservis.Items.Add("Aliağa");
            cBoxRaporservis.Items.Add("Bergama");
            cBoxRaporservis.Items.Add("İzmir");
            cBoxRaporservis.Items.Add("Bornova");
            cBoxRaporservis.Items.Add("Karşıyaka");
            cBoxRaporservis.Items.Add("Konak");
            cBoxRaporservis.Items.Add("Çiğli");
            cBoxRaporservis.Items.Add("Balçova");
            cBoxRaporservis.Items.Add("Bayraklı");
            cBoxRaporservis.Items.Add("Gaziemir");
            cBoxRaporservis.Items.Add("Karabağlar");
            cBoxRaporservis.Items.Add("Narlıdere");
            cBoxRaporservis.Items.Add("Buca");
            cBoxRaporservis.Items.Add("Seferihisar");
            cBoxRaporservis.Items.Add("Urla");
            cBoxRaporservis.Items.Add("Foça");
            cBoxRaporservis.Items.Add("Dikili");
            cBoxRaporservis.Items.Add("Menderes");
            cBoxRaporservis.Items.Add("Torbalı");
            cBoxRaporservis.SelectedIndex = 0;

            // Vardiya combobox doldurur
            cBoxRaporvardiya.Items.Clear();
            cBoxRaporvardiya.Items.Add("Tüm Vardiyalar");
            cBoxRaporvardiya.Items.Add("1. Vardiya");
            cBoxRaporvardiya.Items.Add("2. Vardiya");
            cBoxRaporvardiya.Items.Add("3. Vardiya");
            cBoxRaporvardiya.Items.Add("Memur Vardiyası");
            cBoxRaporvardiya.SelectedIndex = 0;

            // Tarihler
            dtpbaslangic.Value = DateTime.Today.AddDays(-7);
            dtpbitis.Value = DateTime.Today;

            // Eventler
            btnRaporla.Click += btnRaporla_Click;
            geributon.Click += Geributon_Click;
            btnExcel.Click += Btnexcel_Click;

            // Sütunlar otomatik
            dataGridrapor.AutoGenerateColumns = true;
        }

        private void btnRaporla_Click(object sender, EventArgs e)
        {
            string servis = cBoxRaporservis.SelectedItem?.ToString();
            string vardiya = cBoxRaporvardiya.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(servis) || string.IsNullOrEmpty(vardiya))
            {
                MessageBox.Show("Lütfen servis ve vardiya seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime baslangic = dtpbaslangic.Value.Date;
            DateTime bitis = dtpbitis.Value.Date;

            if (baslangic > bitis)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = DatabaseHelper.RaporGetir(servis, baslangic, bitis, vardiya);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Seçilen kriterlere ait veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridrapor.DataSource = null;
                    return;
                }

                dataGridrapor.Columns.Clear();
                dataGridrapor.DataSource = dt;

                // Kolon başlıkları
                if (dataGridrapor.Columns.Contains("AdSoyad"))
                    dataGridrapor.Columns["AdSoyad"].HeaderText = "Ad Soyad";

                if (dataGridrapor.Columns.Contains("Servis"))
                    dataGridrapor.Columns["Servis"].HeaderText = "Servis";

                if (dataGridrapor.Columns.Contains("Tarih"))
                {
                    dataGridrapor.Columns["Tarih"].HeaderText = "Tarih";
                    dataGridrapor.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }

                if (dataGridrapor.Columns.Contains("ServiseBinisSaat"))
                    dataGridrapor.Columns["ServiseBinisSaat"].HeaderText = "Servise Biniş";

                if (dataGridrapor.Columns.Contains("FabrikaGirisSaat"))
                    dataGridrapor.Columns["FabrikaGirisSaat"].HeaderText = "Fabrika Giriş";

                if (dataGridrapor.Columns.Contains("FabrikadanCikisSaat"))
                    dataGridrapor.Columns["FabrikadanCikisSaat"].HeaderText = "Fabrika Çıkış";

                if (dataGridrapor.Columns.Contains("ServiseDonusSaat"))
                    dataGridrapor.Columns["ServiseDonusSaat"].HeaderText = "Servise Dönüş";

                if (dataGridrapor.Columns.Contains("YedekListe"))
                    dataGridrapor.Columns["YedekListe"].HeaderText = "Yedek Liste";

                if (dataGridrapor.Columns.Contains("Vardiya"))
                    dataGridrapor.Columns["Vardiya"].HeaderText = "Vardiya";

                dataGridrapor.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rapor alınırken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {
            if (dataGridrapor.DataSource == null)
            {
                MessageBox.Show("Önce bir rapor alın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Dosyası|*.xlsx",
                Title = "Excel Olarak Kaydet",
                FileName = $"ServisRaporu_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = (DataTable)dataGridrapor.DataSource;

                ExportToExcel_EPPlusWithChart(dt, sfd.FileName);
            }
        }

        /// <summary>
        /// EPPlus ile DataTable'ı Excel'e aktarır ve temel bir grafik ekler
        /// </summary>
        private void ExportToExcel_EPPlusWithChart(DataTable dt, string filePath)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var ws = package.Workbook.Worksheets.Add("Servis Raporu");

                    // DataTable'ı hücrelere yükle (başlık dahil)
                    ws.Cells["A1"].LoadFromDataTable(dt, true);

                    // Sütun genişliklerini otomatik ayarla
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();

                    // Basit grafik ekleme - örnek olarak "Servis" ve "Servise Biniş" sütunlarını kullanacağım.
                    // Eğer veriler uygun değilse grafiği atla.
                    if (dt.Columns.Contains("Servis") && dt.Columns.Contains("ServiseBinisSaat"))
                    {
                        // "Servis" kolonundaki benzersiz değerleri ve "ServiseBinisSaat" kolonundaki değerlerin sayısını sayarak bir özet tablosu oluştur.
                        var pivotData = new System.Collections.Generic.Dictionary<string, int>();

                        foreach (DataRow row in dt.Rows)
                        {
                            string servisAd = row["Servis"]?.ToString() ?? "Bilinmiyor";

                            // ServiseBinisSaat hücresi boş değil ve parse edilebiliyorsa say
                            if (row["ServiseBinisSaat"] != DBNull.Value && TimeSpan.TryParse(row["ServiseBinisSaat"].ToString(), out _))
                            {
                                if (pivotData.ContainsKey(servisAd))
                                    pivotData[servisAd]++;
                                else
                                    pivotData[servisAd] = 1;
                            }
                        }

                        if (pivotData.Count > 0)
                        {
                            int chartStartRow = dt.Rows.Count + 3;
                            int chartStartCol = 1;

                            // Özet tablo başlıkları
                            ws.Cells[chartStartRow, chartStartCol].Value = "Servis";
                            ws.Cells[chartStartRow, chartStartCol + 1].Value = "Servise Biniş Sayısı";

                            int i = 1;
                            foreach (var kvp in pivotData)
                            {
                                ws.Cells[chartStartRow + i, chartStartCol].Value = kvp.Key;
                                ws.Cells[chartStartRow + i, chartStartCol + 1].Value = kvp.Value;
                                i++;
                            }

                            // Grafik oluştur
                            var chart = ws.Drawings.AddChart("ServisBinişGrafik", eChartType.ColumnClustered);
                            chart.Title.Text = "Servis Bazında Servise Biniş Sayısı";
                            chart.SetPosition(chartStartRow - 1, 0, chartStartCol + 3, 0);
                            chart.SetSize(600, 400);

                            var series = chart.Series.Add(
                                ws.Cells[chartStartRow + 1, chartStartCol + 1, chartStartRow + i - 1, chartStartCol + 1],
                                ws.Cells[chartStartRow + 1, chartStartCol, chartStartRow + i - 1, chartStartCol]);

                            series.Header = "Servise Biniş Sayısı";
                        }
                    }

                    // Kaydet
                    package.SaveAs(new FileInfo(filePath));
                }
                MessageBox.Show("Veriler başarıyla Excel dosyasına aktarıldı (grafik dahil).", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Dosya kullanımda olabilir veya erişim hatası var: " + ioEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel'e aktarılırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Geributon_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }

        private void IstatistikleriGoster()
        {
            try
            {
                DataTable dt = DatabaseHelper.IstatistikGetir();

                if (dt == null || dt.Rows.Count == 0)
                {
                    lblIstatistik.Text = "İstatistik verisi bulunamadı.";
                    return;
                }

                DataRow row = dt.Rows[0];

                string enCokKullanilanServis = row["EnCokKullanilanServis"]?.ToString() ?? "Veri Yok";
                string enAzKullanilanServis = row.Table.Columns.Contains("EnAzKullanilanServis") ? row["EnAzKullanilanServis"]?.ToString() ?? "Veri Yok" : "Veri Yok";
                string toplamCalisan = row["ToplamCalisan"]?.ToString() ?? "Veri Yok";
                string toplamYedek = row["ToplamYedek"]?.ToString() ?? "Veri Yok";

                lblIstatistik.Text =
                    $"En Çok Kullanılan Servis: {enCokKullanilanServis}\n" +
                    $"En Az Kullanılan Servis: {enAzKullanilanServis}\n" +
                    $"Toplam Çalışan Sayısı: {toplamCalisan}\n" +
                    $"Toplam Yedek Kişi: {toplamYedek}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstatistikler alınırken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblIstatistik_Click(object sender, EventArgs e)
        {
            // boş
        }

        private void btnExcel_Click_1(object sender, EventArgs e)
        {
            // boş
        }
    }
}
