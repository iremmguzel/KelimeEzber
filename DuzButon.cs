using System.Windows.Forms;

namespace KelimeEzber
{
    // düz stilde Enter'a bağlı buton kalın çerçeveyle çizilir,
    // iki butonun çerçevesinin aynı kalması için bu çizim kapatılır
    public class DuzButon : Button
    {
        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }
    }
}
