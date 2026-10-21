using System;
using System.Collections.Generic;
using System.Linq;

namespace KelimeEzber
{
    // Bir ezber oturumunun soru sırası, şıklar ve puan hesabı burada tutuluyor.
    // Form sadece ekranı güncelliyor.
    public class EzberOturumu
    {
        public const int SecenekSayisi = 4;
        private const int DogruCevapPuani = 10;

        private readonly List<Kelime> kelimeler;
        private readonly List<string> tumAnlamlar;
        private readonly Random random;

        private int index;
        private bool ilkDeneme;

        public int Puan { get; private set; }
        public int IlkDenemedeDogru { get; private set; }
        public int SonKazanilanPuan { get; private set; }
        public List<string> Secenekler { get; private set; }

        public int ToplamKelime => kelimeler.Count;
        public int SoruNo => index + 1;
        public bool Bitti => index >= kelimeler.Count;
        public Kelime AktifKelime => Bitti ? null : kelimeler[index];

        public EzberOturumu(List<Kelime> sozluk) : this(sozluk, new Random())
        {
        }

        public EzberOturumu(List<Kelime> sozluk, Random random)
        {
            if (!YeterliMi(sozluk))
                throw new ArgumentException($"Sözlükte en az {SecenekSayisi} farklı anlam olmalı.", nameof(sozluk));

            this.random = random;
            kelimeler = Karistir(sozluk);
            tumAnlamlar = sozluk.Select(k => k.Turkce).Distinct().ToList();

            SoruyuHazirla();
        }

        // 4 farklı şık üretebilmek için en az 4 farklı anlam gerekiyor
        public static bool YeterliMi(List<Kelime> sozluk)
        {
            return sozluk != null && sozluk.Select(k => k.Turkce).Distinct().Count() >= SecenekSayisi;
        }

        // doğru cevapta true döner ve sonraki soruya geçer
        public bool CevapVer(string cevap)
        {
            if (Bitti)
                return false;

            SonKazanilanPuan = 0;

            if (cevap != AktifKelime.Turkce)
            {
                ilkDeneme = false;
                return false;
            }

            // sadece ilk denemede bilinirse puan veriliyor
            if (ilkDeneme)
            {
                Puan += DogruCevapPuani;
                IlkDenemedeDogru++;
                SonKazanilanPuan = DogruCevapPuani;
            }

            index++;
            SoruyuHazirla();
            return true;
        }

        private void SoruyuHazirla()
        {
            ilkDeneme = true;

            if (Bitti)
            {
                Secenekler = new List<string>();
                return;
            }

            string dogru = AktifKelime.Turkce;

            // aynı anlam iki kez çıkmasın diye yanlışlar doğru cevap hariç tutularak seçiliyor
            var secenekler = Karistir(tumAnlamlar.Where(a => a != dogru).ToList())
                .Take(SecenekSayisi - 1)
                .ToList();
            secenekler.Add(dogru);

            Secenekler = Karistir(secenekler);
        }

        private List<T> Karistir<T>(List<T> kaynak)
        {
            var liste = new List<T>(kaynak);
            for (int i = liste.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                T gecici = liste[i];
                liste[i] = liste[j];
                liste[j] = gecici;
            }
            return liste;
        }
    }
}
