namespace KelimeEzber
{
    public class Sozluk
    {
        public string Ad { get; }
        public string DosyaYolu { get; }

        public Sozluk(string ad, string dosyaYolu)
        {
            Ad = ad;
            DosyaYolu = dosyaYolu;
        }

        // ComboBox listede bu Ad değerini gösterir
        public override string ToString()
        {
            return Ad;
        }
    }
}
