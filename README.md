# Kelime Ezber

C# ve Windows Forms ile yazılmış, çoktan seçmeli sorularla İngilizce kelime ezberlemeye yarayan bir masaüstü uygulamasıdır.

Sakarya Üniversitesi Bilgisayar Mühendisliği 2024-2025 Bahar Dönemi Nesneye Dayalı Programlama dersi ödevi olarak geliştirdim. Teslimden sonra bazı hataları düzelttim. Soru sayısı seçimi özelliği ve süre sayacı ekleyip arayüzü yeniden tasarladım.

## Nasıl çalışır?

### 1. Sözlük ve soru sayısı seçimi

<img src="docs/ana-ekran.png" alt="Sözlük ve soru sayısı seçimi" width="280" align="left">

Program açıldığında klasördeki tüm `.txt` sözlük dosyaları listelenir. Sözlük seçildikten sonra bu oturumda kaç kelime sorulacağı seçilir: 10, 20, 30 ya da Tümü. Sözlükteki kelime sayısını aşan seçenekler gösterilmez.

Enter oturumu başlatır, Esc programı kapatır. Boş, hatalı ya da çok küçük sözlük dosyalarında uyarı verilir.

<br clear="left">

### 2. Soru ekranı

<img src="docs/soru-ekrani.png" alt="Soru ekranı" width="280" align="left">

Kelimeler her oturumda rastgele sırayla sorulur. Her soruda 1 doğru ve 3 yanlış şık gösterilir, yanlış şıklar sözlüğün tamamından seçilir.

Üst şeritte soru sırası, puan ve süre yer alır. Süre sadece soru cevap beklerken işler ve pencere arka plana alınınca durur.

<br clear="left">

### 3. İlk denemede doğru cevap

<img src="docs/dogru-cevap.png" alt="İlk denemede doğru cevap" width="280" align="left">

İlk denemede doğru bilinen kelime 10 puan kazandırır. Doğru şık yeşile döner, kazanılan puan gösterilir ve kısa bir süre sonra sonraki soruya geçilir.

<br clear="left">

### 4. Bilinemeyen kelime

<img src="docs/kelime-not-al.png" alt="Bilinemeyen kelimede doğru cevabın gösterilmesi" width="280" align="left">

Yanlış seçilen şık kırmızıya döner ve tekrar seçilemez. Tüm yanlış şıklar elenirse doğru cevap gösterilir.

Bir kez yanlış cevaplanan kelime puan kazandırmaz. Kullanıcının doğru cevabı inceleyebilmesi için soru otomatik geçilmez, bunun yerine sonraki kelimeye Devam butonu ile geçilir.

<br clear="left">

### 5. Oturumu yarıda bırakma

<img src="docs/oturum-bitmedi.png" alt="Oturumu bitirme onayı" width="280" align="left">

Oturum bitmeden pencere kapatılmak istenirse o ana kadarki sonuçlarla birlikte onay istenir.

Enter ve Esc oturumu sürdürür. Oturum yalnızca "Oturumu bitir" ile sonlanır.

<br clear="left">

### 6. Oturum sonu

<img src="docs/oturum-bitti.png" alt="Oturum sonu" width="280" align="left">

Tüm sorular cevaplandığında ilk denemede bilinen kelime sayısı, toplam puan ve süre gösterilir.

<br clear="left">

## Kurulum

Gereksinimler:

- Windows
- Visual Studio 2019 veya 2022 (".NET masaüstü geliştirme" iş yüküyle)
- .NET Framework 4.8

Adımlar:

1. Depoyu klonlayın:
   ```bash
   git clone https://github.com/iremmguzel/KelimeEzber
   ```
2. `KelimeEzber.sln` dosyasını Visual Studio ile açın.
3. **F5** ile derleyip çalıştırın.

`Sozlukler/` klasöründeki sözlük dosyaları derleme sırasında otomatik olarak `.exe` dosyasının yanına kopyalanır.

## Sözlük formatı

Her satırda bir kelime ve anlamı bulunur. Kelime ve anlamı arasında tab karakteri olmalıdır. Dosya UTF-8 olarak kaydedilmelidir.

```
computer	bilgisayar
keyboard	klavye
mobile phone	cep telefonu
```

Dosyanın ilk satırına `#` ile başlayan bir başlık yazılırsa listede sözlüğün adı olarak bu başlık görünür. Böylece dosya adında Türkçe karakter ve boşluk kullanmaya gerek kalmaz:

```
# Yazılım Terimleri
algorithm	algoritma
```

Yeni sözlük eklerken:

- `.txt` dosyasını `Sozlukler/` klasörüne koyup projeyi yeniden derlemek yeterlidir.
- Dosya adları küçük harfle, Türkçe karaktersiz ve boşluksuz verilmelidir (ör. `yazilim_terimleri.txt`).
- Başlık satırı yoksa listede görünen ad dosya adından üretilir (`temel_kelimeler` → `Temel Kelimeler`).
- Soru oluşturabilmek için sözlükte en az 4 farklı anlam bulunmalıdır.

## Proje yapısı

| Dosya | Görevi |
|---|---|
| `Kelime.cs` | Kelime ve anlamını tutan model sınıfı |
| `Sozluk.cs` | Sözlüğün listede görünen adını ve dosya yolunu tutar |
| `SozlukYonetici.cs` | Sözlük dosyalarını listeleme ve okuma |
| `EzberOturumu.cs` | Soru seçimi ve sırası, şık üretimi ve puan hesabı |
| `SoruSayisiSecenegi.cs` | Sözlüğün kelime sayısına göre soru sayısı seçeneklerini üretir |
| `FormAna.cs` | Sözlük ve soru sayısı seçme ekranı |
| `FormSoru.cs` | Çoktan seçmeli soru ekranı |
| `FormOzet.cs` | Oturum sonu ve oturumu bitirme onayı pencereleri |
| `DuzButon.cs` | Uygulamadaki butonlarda kullanılan düz stilli buton |

Oturum mantığı `EzberOturumu` sınıfında toplandığı için formlar sadece ekranı güncelliyor. Bu sayede mantık arayüzden bağımsız olarak değiştirilebilir ve test edilebilir.
