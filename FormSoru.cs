using System;
using System.Diagnostics;
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

        // geri bildirim kutusunun renkleri: Puan Kazanıldı, Sonradan Bilindi, Cevap Gösterildi
        private static readonly Color PuanKazanildiRengi = Color.FromArgb(102, 187, 106);
        private static readonly Color DogruBilindiRengi = Color.FromArgb(165, 214, 167);
        private static readonly Color CevapGosterildiRengi = Color.FromArgb(247, 222, 100);

        // doğru cevap yeşil gösterildikten sonra sonraki soruya geçmeden önce beklenen süre
        private readonly Timer gecisZamanlayicisi = new Timer { Interval = 1000 };

        // süre sadece soru cevap beklerken ve pencere etkinken işler
        private readonly Stopwatch kronometre = new Stopwatch();
        private readonly Timer sureGostergesi = new Timer { Interval = 200 };
        private bool cevapBekleniyor;
        private bool pencereEtkin;

        public FormSoru(EzberOturumu oturum)
        {
            InitializeComponent();
            this.oturum = oturum;
            secenekButonlari = new[] { btnA, btnB, btnC, btnD };
            gecisZamanlayicisi.Tick += GecisSuresiDoldu;
            sureGostergesi.Tick += (s, e) => SureyiGoster();
            sureGostergesi.Start();
            EkraniGuncelle();
        }

        private void EkraniGuncelle()
        {
            lblSoru.Text = oturum.AktifKelime.Ingilizce;
            lblDurum.Text = $"Soru: {oturum.SoruNo}/{oturum.ToplamSoru}";
            lblPuan.Text = $": {oturum.Puan}";
            lblGeriBildirim.Visible = false;
            lblGeriBildirim.Width = panel2.Width;
            btnDevam.Visible = false;
            AcceptButton = null;

            for (int i = 0; i < secenekButonlari.Length; i++)
            {
                secenekButonlari[i].Text = oturum.Secenekler[i];
                // kırmızı yapılan butonlar eski görünümüne döndürülür
                secenekButonlari[i].BackColor = SystemColors.Control;
                secenekButonlari[i].UseVisualStyleBackColor = true;
                secenekButonlari[i].Enabled = true;
            }

            // tıklanan butonun odakta kalmaması için yeni kelimede odak temizlenir
            ActiveControl = null;

            cevapBekleniyor = true;
            KronometreyiAyarla();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PuanVeSureyiHizala();
        }

        private void PuanVeSureyiHizala()
        {
            const int sagBosluk = 10;

            int baslikGenisligi = Math.Max(lblPuanBaslik.PreferredWidth, lblSureBaslik.PreferredWidth);

            // değer sütunu en uzun süre metnine göre ayarlanır
            string sureMetni = lblSure.Text;
            lblSure.Text = ": 0:00:00";
            int degerGenisligi = lblSure.PreferredWidth;
            lblSure.Text = sureMetni;

            int degerX = panel1.ClientSize.Width - sagBosluk - degerGenisligi;
            int baslikX = degerX - baslikGenisligi;

            lblPuanBaslik.SetBounds(baslikX, lblPuanBaslik.Top, baslikGenisligi, lblPuanBaslik.Height);
            lblSureBaslik.SetBounds(baslikX, lblSureBaslik.Top, baslikGenisligi, lblSureBaslik.Height);
            lblPuan.SetBounds(degerX, lblPuan.Top, degerGenisligi, lblPuan.Height);
            lblSure.SetBounds(degerX, lblSure.Top, degerGenisligi, lblSure.Height);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ActiveControl = null;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (!btnDevam.Visible)
                ActiveControl = null;

            pencereEtkin = true;
            KronometreyiAyarla();
        }

        // başka programa geçilince, küçültülünce ya da mesaj kutusu açılınca süre durur
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            pencereEtkin = false;
            KronometreyiAyarla();
        }

        private void KronometreyiAyarla()
        {
            if (cevapBekleniyor && pencereEtkin)
                kronometre.Start();
            else
                kronometre.Stop();

            SureyiGoster();
        }

        private void SureyiGoster()
        {
            lblSure.Text = $": {SureMetni()}";
        }

        private string SureMetni()
        {
            var sure = kronometre.Elapsed;
            return sure.TotalHours >= 1 ? sure.ToString(@"h\:mm\:ss") : sure.ToString(@"mm\:ss");
        }

        // oturum bitmeden pencere kapatıldığında yanlışlıkla çıkılmaması için onay istenir
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!oturum.Bitti && e.CloseReason == CloseReason.UserClosing)
            {
                var cevap = MessageBox.Show($"Oturum henüz bitmedi.\n\n" +
                                            $"Cevaplanan: {oturum.SoruNo - 1}/{oturum.ToplamSoru}\n" +
                                            $"İlk denemede doğru: {oturum.IlkDenemedeDogru}\n" +
                                            $"Puan: {oturum.Puan}\n" +
                                            $"Süre: {SureMetni()}\n\n" +
                                            "Oturumu bitirmek istediğine emin misin?",
                    "Oturumu Bitir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (cevap == DialogResult.No)
                    e.Cancel = true;
            }
            // son soru cevaplanıp yeşil gösterilirken kapatılırsa sonuç yine gösterilir
            else if (oturum.Bitti && (gecisZamanlayicisi.Enabled || btnDevam.Visible))
            {
                gecisZamanlayicisi.Stop();
                OturumSonucunuGoster();
            }

            base.OnFormClosing(e);
        }

        // bekleme sırasında pencere kapanırsa zamanlayıcı kapanmış formda çalışmaya devam etmez
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gecisZamanlayicisi.Stop();
            gecisZamanlayicisi.Dispose();
            sureGostergesi.Stop();
            sureGostergesi.Dispose();
            base.OnFormClosed(e);
        }

        // dört butonun Click olayı da buraya bağlı
        private void SecenekTiklandi(object sender, EventArgs e)
        {
            var buton = (Button)sender;

            if (!oturum.CevapVer(buton.Text))
            {
                buton.BackColor = YanlisCevapRengi;
                // aynı yanlış şık tekrar seçilemez
                buton.Enabled = false;
                ActiveControl = null;

                // yanlışların hepsi elendiyse kalan şık doğru cevaptır, ayrıca tıklanması beklenmez
                var kalanlar = secenekButonlari.Where(b => b.Enabled).ToList();
                if (kalanlar.Count == 1)
                {
                    oturum.CevapVer(kalanlar[0].Text);
                    // kullanıcı bilemediği kelimelerde doğru cevabı inceleyebilmesi için otomatik olarak geçilmez, sıradaki kelimeye Devam butonuyla geçilir
                    DogruCevabiGoster(kalanlar[0], "Bu kelimeyi not al!", CevapGosterildiRengi, otomatikGec: false);
                }
                return;
            }

            if (oturum.SonKazanilanPuan > 0)
                DogruCevabiGoster(buton, "Doğru!", PuanKazanildiRengi, otomatikGec: true, puanMetni: $"+{oturum.SonKazanilanPuan} puan");
            else
                DogruCevabiGoster(buton, "Doğru", DogruBilindiRengi, otomatikGec: true);
        }

        // bekleme sırasında başka şık seçilemesin diye tüm butonlar kapatılır
        private void DogruCevabiGoster(Button dogruButon, string mesaj, Color kutuRengi, bool otomatikGec, string puanMetni = null)
        {
            // kazanılan puan, ortadaki mesajdan ayrı olarak kutunun sağında gösterilir
            lblPuanArtisi.Text = puanMetni;
            lblPuanArtisi.Visible = puanMetni != null;

            dogruButon.BackColor = DogruCevapRengi;
            // kutu yeni soruda EkraniGuncelle tarafından gizlenir
            lblGeriBildirim.Text = mesaj;
            lblGeriBildirim.BackColor = kutuRengi;
            lblGeriBildirim.Visible = true;
            // puan güncellenir
            lblPuan.Text = $": {oturum.Puan}";
            foreach (var b in secenekButonlari)
                b.Enabled = false;
            ActiveControl = null;

            // yeşil bekleme ve Devam beklenirken süre durur
            cevapBekleniyor = false;
            KronometreyiAyarla();

            if (otomatikGec)
            {
                gecisZamanlayicisi.Start();
                return;
            }

            // kutu daralıp sağında Devam butonu gösterilir
            lblGeriBildirim.Width = btnDevam.Left - lblGeriBildirim.Left - 10;
            btnDevam.Visible = true;
            AcceptButton = btnDevam;
        }

        private void GecisSuresiDoldu(object sender, EventArgs e)
        {
            gecisZamanlayicisi.Stop();
            SonrakiSoruyaGec();
        }

        private void btnDevam_Click(object sender, EventArgs e)
        {
            SonrakiSoruyaGec();
        }

        private void SonrakiSoruyaGec()
        {
            if (oturum.Bitti)
            {
                btnDevam.Visible = false;
                OturumSonucunuGoster();
                Close();
                return;
            }

            EkraniGuncelle();
        }

        private void OturumSonucunuGoster()
        {
            string tebrik = oturum.TumKelimelerSoruluyor
                ? "Tebrikler, tüm kelimeleri tamamladın!"
                : $"Tebrikler, {oturum.ToplamSoru} soruyu tamamladın!";

            MessageBox.Show($"{tebrik}\n\n" +
                            $"İlk denemede doğru: {oturum.IlkDenemedeDogru}/{oturum.ToplamSoru}\n" +
                            $"Toplam puan: {oturum.Puan}\n" +
                            $"Süre: {SureMetni()}",
                "Oturum Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
