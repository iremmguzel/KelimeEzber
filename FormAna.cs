using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KelimeEzber
{
    public partial class FormAna : Form
    {
        public FormAna()
        {
            InitializeComponent();
        }

        private void FormAna_Load(object sender, EventArgs e)
        {
            SozlukleriDoldur();
        }

        private void SozlukleriDoldur()
        {
            comboBoxSozlukler.Items.Clear();

            foreach (Sozluk sozluk in SozlukYonetici.SozlukleriListele())
                comboBoxSozlukler.Items.Add(sozluk);

            if (comboBoxSozlukler.Items.Count > 0)
            {
                comboBoxSozlukler.SelectedIndex = 0;
            }
            else
            {
                btnBaslat.Enabled = false;
                comboBoxSoruSayisi.Enabled = false;
                MessageBox.Show("Program klasöründe .txt uzantılı sözlük dosyası bulunamadı.",
                    "Kelime Ezber", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxSozlukler_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoruSayilariniDoldur();
        }

        // seçenekler seçili sözlüğün kelime sayısına göre yenilenir
        private void SoruSayilariniDoldur()
        {
            var onceki = comboBoxSoruSayisi.SelectedItem as SoruSayisiSecenegi;
            comboBoxSoruSayisi.Items.Clear();

            int kelimeSayisi = 0;
            if (comboBoxSozlukler.SelectedItem is Sozluk sozluk)
            {
                try
                {
                    kelimeSayisi = SozlukYonetici.SozlukYukle(sozluk).Count;
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    // hata mesajı burada değil, Başlat'a basılınca gösterilir
                }
            }

            foreach (SoruSayisiSecenegi secenek in SoruSayisiSecenegi.Olustur(kelimeSayisi))
                comboBoxSoruSayisi.Items.Add(secenek);

            comboBoxSoruSayisi.Enabled = comboBoxSoruSayisi.Items.Count > 0;
            if (!comboBoxSoruSayisi.Enabled)
                return;

            // önceki seçim yeni sözlükte de varsa korunur, yoksa ilk seçenek seçilir
            int index = 0;
            if (onceki != null)
            {
                for (int i = 0; i < comboBoxSoruSayisi.Items.Count; i++)
                {
                    var secenek = (SoruSayisiSecenegi)comboBoxSoruSayisi.Items[i];
                    if (secenek.Tumu == onceki.Tumu && (secenek.Tumu || secenek.Sayi == onceki.Sayi))
                    {
                        index = i;
                        break;
                    }
                }
            }
            comboBoxSoruSayisi.SelectedIndex = index;
        }

        // Başlat'a basıldığı anda seçili sözlük yüklenip oturum başlatılır
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (comboBoxSozlukler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir sözlük seçin.");
                return;
            }

            var sozluk = (Sozluk)comboBoxSozlukler.SelectedItem;
            List<Kelime> kelimeler;

            try
            {
                kelimeler = SozlukYonetici.SozlukYukle(sozluk);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("Sözlük okunamadı:\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!EzberOturumu.YeterliMi(kelimeler))
            {
                MessageBox.Show($"\"{sozluk.Ad}\" sözlüğünden soru oluşturulamıyor.\n" +
                                $"En az {EzberOturumu.SecenekSayisi} farklı anlam içeren kelime olmalı.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var soruSecenegi = comboBoxSoruSayisi.SelectedItem as SoruSayisiSecenegi;
            int soruSayisi = soruSecenegi == null || soruSecenegi.Tumu ? kelimeler.Count : soruSecenegi.Sayi;

            using (var formSoru = new FormSoru(new EzberOturumu(kelimeler, soruSayisi)))
            {
                formSoru.ShowDialog(this);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
