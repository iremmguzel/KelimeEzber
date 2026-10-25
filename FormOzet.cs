using System.Drawing;
using System.Windows.Forms;

namespace KelimeEzber
{
    // oturumun onay ve sonuç mesajları, uygulamanın görünümüyle uyumlu olması için standart MessageBox yerine bu pencerede gösterilir
    // satır sayısı mesaja göre değiştiği için pencere kodla oluşturulur
    public class FormOzet : Form
    {
        private static readonly Color Lacivert = Color.FromArgb(43, 58, 103);
        private static readonly Color ButonCerceveRengi = Color.FromArgb(150, 163, 204);
        private static readonly Color EtiketRengi = Color.FromArgb(95, 107, 133);
        private static readonly Color DegerRengi = Color.FromArgb(51, 51, 51);

        private const int Kenar = 24;
        private const int PencereGenisligi = 500;
        private const int DegerSutunu = 240;
        private const int SatirYuksekligi = 36;

        private int siradakiSatir;

        private FormOzet(string baslik)
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kelime Ezber";

            var serit = new Panel { BackColor = Lacivert, Dock = DockStyle.Top, Height = 64 };
            serit.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 16),
                Text = baslik
            });
            Controls.Add(serit);

            siradakiSatir = serit.Height + Kenar;
        }

        // kullanıcı oturumu bitirmeyi seçerse true döner, Devam et, Esc ve pencereyi kapatma ise oturumu sürdürür
        public static bool BitirmeOnayiAl(IWin32Window sahip, params (string Ad, string Deger)[] satirlar)
        {
            using (var form = new FormOzet("Oturum henüz bitmedi!"))
            {
                form.SatirlariEkle(satirlar);
                form.MetinEkle("Oturumu bitirmek istediğine emin misin?");

                var devam = form.ButonEkle("Devam et", 150, DialogResult.No, anaButon: true);
                form.ButonEkle("Oturumu bitir", 190, DialogResult.Yes, anaButon: false);
                form.Tamamla(devam);

                return form.ShowDialog(sahip) == DialogResult.Yes;
            }
        }

        public static void SonucuGoster(IWin32Window sahip, string tebrik, params (string Ad, string Deger)[] satirlar)
        {
            using (var form = new FormOzet("Oturum bitti"))
            {
                form.MetinEkle(tebrik, FontStyle.Bold);
                form.SatirlariEkle(satirlar);

                var tamam = form.ButonEkle("Tamam", 150, DialogResult.OK, anaButon: true);
                form.Tamamla(tamam);

                form.ShowDialog(sahip);
            }
        }

        private void MetinEkle(string metin, FontStyle stil = FontStyle.Regular)
        {
            Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, stil),
                ForeColor = DegerRengi,
                Location = new Point(Kenar, siradakiSatir),
                Text = metin
            });
            siradakiSatir += SatirYuksekligi + 8;
        }

        private void SatirlariEkle((string Ad, string Deger)[] satirlar)
        {
            foreach (var satir in satirlar)
            {
                Controls.Add(new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = EtiketRengi,
                    Location = new Point(Kenar, siradakiSatir),
                    Text = satir.Ad
                });
                Controls.Add(new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = DegerRengi,
                    Location = new Point(DegerSutunu, siradakiSatir),
                    Text = satir.Deger
                });
                siradakiSatir += SatirYuksekligi;
            }
            siradakiSatir += 8;
        }

        // butonlar sağdan sola dizilir, ana buton en sağda durur
        private DuzButon ButonEkle(string metin, int genislik, DialogResult sonuc, bool anaButon)
        {
            const int bosluk = 8;
            int solKenar = PencereGenisligi - Kenar - genislik;
            foreach (Control kontrol in Controls)
            {
                if (kontrol is DuzButon)
                    solKenar = kontrol.Left - bosluk - genislik;
            }

            var buton = new DuzButon
            {
                BackColor = anaButon ? Lacivert : Color.White,
                DialogResult = sonuc,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 13F),
                ForeColor = anaButon ? Color.White : Lacivert,
                Location = new Point(solKenar, siradakiSatir + 8),
                Size = new Size(genislik, 44),
                Text = metin,
                UseVisualStyleBackColor = false
            };
            buton.FlatAppearance.BorderColor = ButonCerceveRengi;
            buton.FlatAppearance.MouseOverBackColor = anaButon ? Color.FromArgb(58, 76, 128) : Color.FromArgb(233, 237, 247);
            buton.FlatAppearance.MouseDownBackColor = anaButon ? Color.FromArgb(31, 43, 79) : Color.FromArgb(213, 219, 234);
            Controls.Add(buton);
            return buton;
        }

        // Enter ve Esc ana butona basmış sayılır, yanlışlıkla oturum bitirilmez
        private void Tamamla(DuzButon anaButon)
        {
            AcceptButton = anaButon;
            CancelButton = anaButon;
            ActiveControl = anaButon;
            ClientSize = new Size(PencereGenisligi, siradakiSatir + 8 + anaButon.Height + Kenar);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
