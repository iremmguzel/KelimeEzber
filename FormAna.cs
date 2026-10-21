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
                MessageBox.Show("Program klasöründe .txt uzantılı sözlük dosyası bulunamadı.",
                    "Kelime Ezber", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Başlat'a basıldığı anda seçili sözlük yüklenip oturum başlatılıyor
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

            using (var formSoru = new FormSoru(new EzberOturumu(kelimeler)))
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
