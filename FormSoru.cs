using System;
using System.Drawing;
using System.Windows.Forms;

namespace KelimeEzber
{
    public partial class FormSoru : Form
    {
        private readonly EzberOturumu oturum;
        private readonly Button[] secenekButonlari;

        private static readonly Color YanlisCevapRengi = Color.FromArgb(255, 190, 190);

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
                secenekButonlari[i].Enabled = true;
            }

            // tıklanan buton odakta kalmasın diye yeni kelimede odak temizlenir
            ActiveControl = null;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ActiveControl = null;
        }

        // oturum bitmeden pencere kapatılırsa yanlışlıkla çıkılmasın diye onay isteniyor
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!oturum.Bitti && e.CloseReason == CloseReason.UserClosing)
            {
                var cevap = MessageBox.Show($"Oturum henüz bitmedi.\n\n" +
                                            $"Cevaplanan: {oturum.SoruNo - 1}/{oturum.ToplamKelime}\n" +
                                            $"İlk denemede doğru: {oturum.IlkDenemedeDogru}\n" +
                                            $"Puan: {oturum.Puan}\n\n" +
                                            "Oturumu bitirmek istediğine emin misin?",
                    "Oturumu Bitir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (cevap == DialogResult.No)
                    e.Cancel = true;
            }

            base.OnFormClosing(e);
        }

        // dört butonun Click olayı da buraya bağlı
        private void SecenekTiklandi(object sender, EventArgs e)
        {
            var buton = (Button)sender;

            if (!oturum.CevapVer(buton.Text))
            {
                buton.BackColor = YanlisCevapRengi;
                // aynı yanlış şık tekrar seçilemesin
                buton.Enabled = false;
                ActiveControl = null;
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
