namespace KelimeEzber
{
    public class Kelime
    {
        public string Ingilizce { get; }
        public string Turkce { get; }

        public Kelime(string ingilizce, string turkce)
        {
            Ingilizce = ingilizce;
            Turkce = turkce;
        }
    }
}
