using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KelimeEzber
{
    public partial class FormSoru : Form
    {
        private readonly EzberOturumu oturum;
        private readonly Button[] secenekButonlari;

        private static readonly Color YanlisCevapRengi = Color.FromArgb(255, 190, 190);
        private static readonly Color DogruCevapRengi = Color.FromArgb(190, 240, 190);

        // geri bildirim kutusunun renkleri: puan kazanıldı, sonradan bilindi, cevap gösterildi
        private static readonly Color PuanKazanildiRengi = Color.FromArgb(57, 255, 20);
        private static readonly Color DogruBilindiRengi = Color.FromArgb(120, 200, 120);
        private static readonly Color CevapGosterildiRengi = Color.FromArgb(255, 193, 7);

        // doğru cevap yeşil gösterildikten sonra sonraki soruya geçmeden önce beklenen süre
        private readonly Timer gecisZamanlayicisi = new Timer { Interval = 1000 };

        public FormSoru(EzberOturumu oturum)
        {
            InitializeComponent();
            this.oturum = oturum;
            secenekButonlari = new[] { btnA, btnB, btnC, btnD };
            gecisZamanlayicisi.Tick += GecisSuresiDoldu;
            EkraniGuncelle();
        }

        private void EkraniGuncelle()
        {
            lblSoru.Text = oturum.AktifKelime.Ingilizce;
            lblDurum.Text = $"Soru: {oturum.SoruNo}/{oturum.ToplamKelime}";
            lblPuan.Text = $"Puan: {oturum.Puan}";
            lblGeriBildirim.Visible = false;

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
            // son soru cevaplanıp yeşil gösterilirken kapatılırsa sonuç yine gösterilsin
            else if (oturum.Bitti && gecisZamanlayicisi.Enabled)
            {
                gecisZamanlayicisi.Stop();
                OturumSonucunuGoster();
            }

            base.OnFormClosing(e);
        }

        // bekleme sırasında pencere kapanırsa zamanlayıcı kapanmış formda çalışmaya devam etmesin
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gecisZamanlayicisi.Stop();
            gecisZamanlayicisi.Dispose();
            base.OnFormClosed(e);
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

                // yanlışların hepsi elendiyse kalan şık doğru cevaptır, ayrıca tıklanması beklenmez
                var kalanlar = secenekButonlari.Where(b => b.Enabled).ToList();
                if (kalanlar.Count == 1)
                {
                    oturum.CevapVer(kalanlar[0].Text);
                    DogruCevabiGoster(kalanlar[0], $"Doğru cevap: {kalanlar[0].Text}", CevapGosterildiRengi);
                }
                return;
            }

            if (oturum.SonKazanilanPuan > 0)
                DogruCevabiGoster(buton, $"Doğru! +{oturum.SonKazanilanPuan} puan", PuanKazanildiRengi);
            else
                DogruCevabiGoster(buton, "Doğru", DogruBilindiRengi);
        }

        // bekleme sırasında başka şık seçilemesin diye tüm butonlar kapatılıyor
        private void DogruCevabiGoster(Button dogruButon, string mesaj, Color kutuRengi)
        {
            dogruButon.BackColor = DogruCevapRengi;
            // kutu yeni soruda EkraniGuncelle tarafından gizleniyor
            lblGeriBildirim.Text = mesaj;
            lblGeriBildirim.BackColor = kutuRengi;
            lblGeriBildirim.Visible = true;
            // puan güncellenir
            lblPuan.Text = $"Puan: {oturum.Puan}";
            foreach (var b in secenekButonlari)
                b.Enabled = false;
            ActiveControl = null;

            gecisZamanlayicisi.Start();
        }

        private void GecisSuresiDoldu(object sender, EventArgs e)
        {
            gecisZamanlayicisi.Stop();

            if (oturum.Bitti)
            {
                OturumSonucunuGoster();
                Close();
                return;
            }

            EkraniGuncelle();
        }

        private void OturumSonucunuGoster()
        {
            MessageBox.Show($"Tebrikler, tüm kelimeleri tamamladın!\n\n" +
                            $"İlk denemede doğru: {oturum.IlkDenemedeDogru}/{oturum.ToplamKelime}\n" +
                            $"Toplam puan: {oturum.Puan}",
                "Oturum Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
