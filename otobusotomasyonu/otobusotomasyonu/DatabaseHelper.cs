using System;
using System.Data;
using System.Data.SqlClient;

namespace otobusotomasyonu
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = @"Server=localhost;Database=ServisTakipDB;Trusted_Connection=True;";

        // Kayıt ekleme veya güncelleme (Servise Biniş, Fabrikaya Giriş, vb.)
        public static void KayitEkleGuncelle(string adSoyad, string servis, DateTime tarih, string hareketTipi, TimeSpan saat)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            // Önce kayıt var mı kontrol et
            string kontrolSorgu = @"SELECT ID FROM Kayitlar 
                                   WHERE AdSoyad=@adSoyad AND Servis=@servis AND Tarih=@tarih";
            using SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, con);
            kontrolKomut.Parameters.AddWithValue("@adSoyad", adSoyad);
            kontrolKomut.Parameters.AddWithValue("@servis", servis);
            kontrolKomut.Parameters.AddWithValue("@tarih", tarih.Date);

            object result = kontrolKomut.ExecuteScalar();

            if (result == null) // Kayıt yoksa ekle
            {
                string insertSorgu = @"INSERT INTO Kayitlar 
                                       (AdSoyad, Servis, Tarih, ServiseBinisSaat, FabrikaGirisSaat, FabrikadanCikisSaat, ServiseDonusSaat, YedekListe) 
                                       VALUES (@adSoyad, @servis, @tarih, NULL, NULL, NULL, NULL, NULL)";
                using SqlCommand insertKomut = new SqlCommand(insertSorgu, con);
                insertKomut.Parameters.AddWithValue("@adSoyad", adSoyad);
                insertKomut.Parameters.AddWithValue("@servis", servis);
                insertKomut.Parameters.AddWithValue("@tarih", tarih.Date);
                insertKomut.ExecuteNonQuery();
            }

            // Kolon adını belirle
            string kolonAdi = hareketTipi switch
            {
                "Servise Biniş" => "ServiseBinisSaat",
                "Fabrikaya Giriş" => "FabrikaGirisSaat",
                "Fabrikadan Çıkış" => "FabrikadanCikisSaat",
                "Servise Dönüş" => "ServiseDonusSaat",
                _ => null
            };

            if (kolonAdi == null) return;

            string updateSorgu = $"UPDATE Kayitlar SET {kolonAdi} = @saat WHERE AdSoyad = @adSoyad AND Servis = @servis AND Tarih = @tarih";
            using SqlCommand updateKomut = new SqlCommand(updateSorgu, con);
            updateKomut.Parameters.AddWithValue("@saat", saat);
            updateKomut.Parameters.AddWithValue("@adSoyad", adSoyad);
            updateKomut.Parameters.AddWithValue("@servis", servis);
            updateKomut.Parameters.AddWithValue("@tarih", tarih.Date);
            updateKomut.ExecuteNonQuery();
        }

        // Yedek listeye ekle / güncelle
        public static void YedekListeyeEkle(string servis, string adSoyad, DateTime tarih)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            // Yedek liste boş satır var mı diye kontrol et
            string kontrolSorgu = @"SELECT ID FROM Kayitlar 
                                   WHERE Servis = @servis AND Tarih = @tarih AND YedekListe IS NULL";
            using SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, con);
            kontrolKomut.Parameters.AddWithValue("@servis", servis);
            kontrolKomut.Parameters.AddWithValue("@tarih", tarih.Date);
            object result = kontrolKomut.ExecuteScalar();

            if (result == null)
            {
                // Boş satır yoksa ekle
                string insertSorgu = @"INSERT INTO Kayitlar (AdSoyad, Servis, Tarih, YedekListe) 
                                       VALUES (@bos, @servis, @tarih, @yedekAd)";
                using SqlCommand insertKomut = new SqlCommand(insertSorgu, con);
                insertKomut.Parameters.AddWithValue("@bos", "");
                insertKomut.Parameters.AddWithValue("@servis", servis);
                insertKomut.Parameters.AddWithValue("@tarih", tarih.Date);
                insertKomut.Parameters.AddWithValue("@yedekAd", adSoyad);
                insertKomut.ExecuteNonQuery();
            }
            else
            {
                // Zaten boş satır varsa sadece yedek adı güncelle
                string updateSorgu = @"UPDATE Kayitlar SET YedekListe = @yedekAd WHERE ID = @id";
                using SqlCommand updateKomut = new SqlCommand(updateSorgu, con);
                updateKomut.Parameters.AddWithValue("@yedekAd", adSoyad);
                updateKomut.Parameters.AddWithValue("@id", result);
                updateKomut.ExecuteNonQuery();
            }
        }

        // Belirli servis için kayıtları getir
        public static DataTable KayitlariGetir(string servisAdi)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string sorgu = @"SELECT AdSoyad, Servis, Tarih, ServiseBinisSaat, FabrikaGirisSaat, FabrikadanCikisSaat, ServiseDonusSaat, YedekListe 
                             FROM Kayitlar WHERE Servis = @servis ORDER BY Tarih DESC";

            using SqlCommand komut = new SqlCommand(sorgu, con);
            komut.Parameters.AddWithValue("@servis", servisAdi);
            using SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Servis kontenjanını getir
        public static int KontenjanGetir(string servisAdi)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string sorgu = "SELECT Kontenjan FROM ServisKontenjan WHERE ServisAdi = @servisAdi";
            using SqlCommand komut = new SqlCommand(sorgu, con);
            komut.Parameters.AddWithValue("@servisAdi", servisAdi);

            object result = komut.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int kontenjan))
                return kontenjan;
            else
                return -1; // Bulunamadıysa -1 döner
        }

        // Servis kontenjanını güncelle
        public static void KontenjanGuncelle(string servisAdi, int yeniKontenjan)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string sorgu = "UPDATE ServisKontenjan SET Kontenjan = @kontenjan WHERE ServisAdi = @servisAdi";
            using SqlCommand komut = new SqlCommand(sorgu, con);
            komut.Parameters.AddWithValue("@kontenjan", yeniKontenjan);
            komut.Parameters.AddWithValue("@servisAdi", servisAdi);
            komut.ExecuteNonQuery();
        }

        // Rapor verilerini getir (Tarih aralığı, servis ve vardiya filtreli)
        public static DataTable RaporGetir(string servis, DateTime baslangic, DateTime bitis, string vardiya)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        AdSoyad,
                        Servis,
                        Tarih,
                        ServiseBinisSaat,
                        FabrikaGirisSaat,
                        FabrikadanCikisSaat,
                        ServiseDonusSaat,
                        YedekListe
                    FROM Kayitlar
                    WHERE 
                        Tarih BETWEEN @Baslangic AND @Bitis
                ";

                if (servis != "Tümü")
                {
                    query += " AND Servis = @Servis";
                }

                if (vardiya != "Tüm Vardiyalar")
                {
                    query += @"
                        AND (
                            (@Vardiya = '1. Vardiya' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '07:00:00' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '15:00:00') OR
                            (@Vardiya = '2. Vardiya' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '15:00:00' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '23:00:00') OR
                            (@Vardiya = '3. Vardiya' AND (FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '23:00:00' OR FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '07:00:00')) OR
                            (@Vardiya = 'Memur Vardiyası' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '08:00:00' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '09:00:00')
                        )
                    ";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Baslangic", baslangic);
                    cmd.Parameters.AddWithValue("@Bitis", bitis);

                    if (servis != "Tümü")
                        cmd.Parameters.AddWithValue("@Servis", servis);

                    cmd.Parameters.AddWithValue("@Vardiya", vardiya);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // İstatistikleri getir (En çok kullanılan servis, en yoğun vardiya, toplam çalışan ve yedek kişi sayısı)
        public static DataTable IstatistikGetir()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = @"
        SELECT 
            -- En çok kullanılan servis
            (SELECT TOP 1 Servis FROM Kayitlar GROUP BY Servis ORDER BY COUNT(*) DESC) AS EnCokKullanilanServis,
            
            -- En az kullanılan servis
            (SELECT TOP 1 Servis FROM Kayitlar GROUP BY Servis ORDER BY COUNT(*) ASC) AS EnAzKullanilanServis,

            -- En yoğun vardiya
            (SELECT TOP 1 
                CASE 
                    WHEN FabrikaGirisSaat IS NOT NULL AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '07:00:00' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '15:00:00' THEN '1. Vardiya'
                    WHEN FabrikaGirisSaat IS NOT NULL AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '15:00:00' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '23:00:00' THEN '2. Vardiya'
                    WHEN FabrikaGirisSaat IS NOT NULL AND (FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '23:00:00' OR FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '07:00:00') THEN '3. Vardiya'
                    WHEN FabrikaGirisSaat IS NOT NULL AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '08:00:00' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '09:00:00' THEN 'Memur Vardiyası'
                    ELSE NULL
                END as Vardiya
             FROM Kayitlar
             WHERE FabrikaGirisSaat IS NOT NULL
             GROUP BY 
                CASE 
                    WHEN FabrikaGirisSaat IS NOT NULL AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '07:00:00' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '15:00:00' THEN '1. Vardiya'
                    WHEN FabrikaGirisSaat IS NOT NULL AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '15:00:00' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '23:00:00' THEN '2. Vardiya'
                    WHEN FabrikaGirisSaat IS NOT NULL AND (FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '23:00:00' OR FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '07:00:00') THEN '3. Vardiya'
                    WHEN FabrikaGirisSaat IS NOT NULL AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') >= '08:00:00' AND FORMAT(FabrikaGirisSaat, 'HH:mm:ss') < '09:00:00' THEN 'Memur Vardiyası'
                    ELSE NULL
                END
             ORDER BY COUNT(*) DESC
            ) AS EnYogunVardiya,

            -- Toplam çalışan sayısı
            (SELECT COUNT(DISTINCT AdSoyad) FROM Kayitlar) AS ToplamCalisan,

            -- Toplam yedek kişi sayısı
            (SELECT COUNT(*) FROM Kayitlar WHERE YedekListe IS NOT NULL AND YedekListe <> '') AS ToplamYedek
    ";

            using SqlCommand cmd = new SqlCommand(query, con);
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

    }
}
