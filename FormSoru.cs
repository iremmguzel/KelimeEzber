using System;
using System.Drawing;
using System.Windows.Forms;

namespace KelimeEzber
{
    public partial class FormSoru : Form
    {
        private readonly EzberOturumu oturum;
        private readonly Button[] secenekButonlari;

        public FormSoru(EzberOturumu oturum)
        {
            InitializeComponent();
            this.oturum = oturum;
            secenekButonlari = new[] { btnA, btnB, btnC, btnD };
            EkraniGuncelle();
        }

        private void EkraniGuncelle()
        {
            lblSoru.Text = oturum.AktifKelime.Ingilizce;
            lblDurum.Text = $"Soru: {oturum.SoruNo}/{oturum.ToplamKelime}";
            lblPuan.Text = $"Puan: {oturum.Puan}";

            for (int i = 0; i < secenekButonlari.Length; i++)
            {
                secenekButonlari[i].Text = oturum.Secenekler[i];
                // kırmızı yapılan butonları eski görünümüne döndür
                secenekButonlari[i].BackColor = SystemColors.Control;
                secenekButonlari[i].UseVisualStyleBackColor = true;
            }
        }

        // dört butonun Click olayı da buraya bağlı
        private void SecenekTiklandi(object sender, EventArgs e)
        {
            var buton = (Button)sender;

            if (!oturum.CevapVer(buton.Text))
            {
                buton.BackColor = Color.Red;
                return;
            }

            if (oturum.Bitti)
            {
                MessageBox.Show($"Tebrikler, tüm kelimeleri tamamladın!\n\n" +
                                $"İlk denemede doğru: {oturum.IlkDenemedeDogru}/{oturum.ToplamKelime}\n" +
                                $"Toplam puan: {oturum.Puan}",
                    "Oturum Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            EkraniGuncelle();
        }
    }
}
