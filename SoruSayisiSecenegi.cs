using System.Collections.Generic;
using System.Linq;

namespace KelimeEzber
{
    public class SoruSayisiSecenegi
    {
        private static readonly int[] HazirSayilar = { 10, 20, 30 };

        public int Sayi { get; }
        public bool Tumu { get; }

        private SoruSayisiSecenegi(int sayi, bool tumu)
        {
            Sayi = sayi;
            Tumu = tumu;
        }

        // kelime sayısına eşit ya da büyük hazır sayılar gösterilmez, en sona Tümü eklenir
        // ilk seçenek varsayılan: 10, sözlük küçükse Tümü
        public static List<SoruSayisiSecenegi> Olustur(int kelimeSayisi)
        {
            var secenekler = new List<SoruSayisiSecenegi>();
            if (kelimeSayisi <= 0)
                return secenekler;

            secenekler.AddRange(HazirSayilar
                .Where(sayi => sayi < kelimeSayisi)
                .Select(sayi => new SoruSayisiSecenegi(sayi, false)));
            secenekler.Add(new SoruSayisiSecenegi(kelimeSayisi, true));
            return secenekler;
        }

        // ComboBox listede bu metni gösterir
        public override string ToString()
        {
            return Tumu ? $"Tümü ({Sayi})" : Sayi.ToString();
        }
    }
}
