using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace KelimeEzber
{
    public static class SozlukYonetici
    {
        // sözlükler .exe dosyasının bulunduğu klasörden okunur
        private static string Klasor => AppDomain.CurrentDomain.BaseDirectory;

        // dosya adları Türkçe karakter ve boşluk içermez, listede görünecek ad ilk satırdaki başlıktan alınır
        private const string BaslikIsareti = "#";

        public static List<Sozluk> SozlukleriListele()
        {
            return Directory.GetFiles(Klasor, "*.txt")
                .Select(yol => new Sozluk(AdiBul(yol), yol))
                .OrderBy(s => s.Ad, StringComparer.Create(new CultureInfo("tr-TR"), true))
                .ToList();
        }

        // başlık satırı yoksa dosya adından üretilir:
        // temel_kelimeler -> Temel Kelimeler
        private static string AdiBul(string yol)
        {
            string ilkSatir = File.ReadLines(yol, Encoding.UTF8).FirstOrDefault() ?? "";
            if (ilkSatir.StartsWith(BaslikIsareti))
            {
                string baslik = ilkSatir.Substring(BaslikIsareti.Length).Trim();
                if (baslik.Length > 0)
                    return baslik;
            }

            string dosyaAdi = Path.GetFileNameWithoutExtension(yol).Replace('_', ' ');
            return new CultureInfo("tr-TR").TextInfo.ToTitleCase(dosyaAdi);
        }

        public static List<Kelime> SozlukYukle(Sozluk sozluk)
        {
            string yol = sozluk.DosyaYolu;
            if (!File.Exists(yol))
                throw new FileNotFoundException("Sözlük dosyası bulunamadı.", yol);

            var kelimeler = new List<Kelime>();

            foreach (string satir in File.ReadAllLines(yol, Encoding.UTF8))
            {
                if (satir.StartsWith(BaslikIsareti))
                    continue;

                // satır formatı: kelime<TAB>anlam
                // bazı dosyalarda arada iki tab olabilir, boş parçalar atlanır
                string[] parcalar = satir.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parcalar.Length < 2)
                    continue;

                string ingilizce = parcalar[0].Trim();
                string turkce = parcalar[1].Trim();
                if (ingilizce.Length == 0 || turkce.Length == 0)
                    continue;

                kelimeler.Add(new Kelime(ingilizce, turkce));
            }

            return kelimeler;
        }
    }
}
