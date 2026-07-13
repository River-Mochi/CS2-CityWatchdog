// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleTR.cs
// Purpose: Turkish (tr-TR) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleTR : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleTR(Setting setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title += " (" + Mod.ModVersion + ")";
            }

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Eylemler" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Para-Kilometre Taşları" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Hakkında" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "KULLANIM" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Bildirimler" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Şehir içi bilgi göstergesi" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini HUD bildirimleri" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "YENİ ŞEHİR BAŞLANGICI" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Para" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Sınırsız kaydı dönüştür" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "TANI" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Talimatları göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Aşağıdaki kullanım talimatlarını gösterir veya gizler." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Görünüm düğmeleri>\n" +
                    "1. [i] düğmesi: binalar, simler, araçlar ve alt menü ikonları dahil OYUNUN TÜM üzerine gelme ipuçlarını gizler/gösterir.\n" +
                    "2. Yol adı düğmesi: yol adı etiketlerini gizler/gösterir. Kısayol: \\.\n" +
                    "3. Bölge adı düğmesi: sınırları değiştirmeden bölge adlarını gizler/gösterir.\n" +
                    "4. Yol oku düğmesi: tek yön oklarını zorla aç/kapat (yol adlarını da gizler).\n" +
                    "5. CWD başlık çubuğu ikonu: City Watchdog panel ipuçlarını gösterir/gizler.\n" +
                    "\n" +
                    "<Bildirim uyarıları>\n" +
                    "1. Paneli açmak için sol üstte City Watchdog düğmesine tıkla veya Shift+N kullan.\n" +
                    "2. Sıralama düğmesi: artan/azalan.\n" +
                    "3. Tümünü değiştir ile hızlıca hepsini kapat/aç, ya da bölüm açıp tek tek değiştir.\n" +
                    "4. Yalnızca ikonları gösterir/gizler; şehir sorununu çözmez.\n" +
                    "\n" +
                    "<Para yardımcıları>\n" +
                    "1. Para ekle/çıkar: <Para kısayol tutarı>, varsayılan tuşlar [ ve ].\n" +
                    "2. Otomatik para, şehir seçtiğin limitin altına düşerse para ekler.\n" +
                    "3. Sınırsız para kaydını dönüştürme sadece sınırsız para ile başlayan şehirler içindir ve <geri alınamaz>.\n" +
                    "\n" +
                    "<Alt menü ipuçları>\n" +
                    "Para göstergesi, para ve nüfus çubuğuna eğilim değerleri ve üzerine gelince ek ayrıntılar ekler.\n" +
                    "\n" +
                    "<Özel kilometre taşı>\n" +
                    "Şehri yüklemeden veya başlatmadan önce Para-Kilometre Taşları > YENİ ŞEHİR BAŞLANGICI bölümünden başlangıç parasını ve kilometre taşını ayarla." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bildirim ikonlarını değiştir" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Oyundaki <[Tümünü değiştir]> ikon düğmesiyle aynı eylem için <kısayol>.\n" +
                    "Listelenen tüm şehir bildirim ikonlarını anında gösterir veya gizler." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Tüm bildirim ikonlarını anında göster/gizle" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Bildirim panelini aç/kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Şehirde\n" +
                    "<bildirim panelini> açıp kapatan <kısayol>.\n" +
                    "Sol üst ikona tıklamakla aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Bildirim panelini aç/kapat" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Panel düğmeli başlasın" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Etkinse [ ✓ ], City Watchdog sol üst düğmeden küçük yalnızca düğmeler görünümünde açılır.\n" +
                    "Tam panel için başlık oku veya satır sayacı düğmesini kullan." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Temel oyunun yol adı etiketlerini anında gizleyen veya gösteren <kısayol>.\n" +
                    "City Watchdog panelindeki Yol adı ikonu ile aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Tüm fare ipuçlarını kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Binalar, simler, araçlar ve alt menü ikonları dahil OYUNUN TÜM üzerine gelme ipuçlarını anında gizler/gösterir.\n" +
                    "<City Watchdog'un kendi para/nüfus pencereleri açık kalır>; bunlar Para göstergesi ile kontrol edilir.\n" +
                    "City Watchdog panelindeki [i] ikonu ile aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Tüm oyun ipuçlarını gizle/göster" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Para + nüfus ipuçlarını göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Açık önerilir>\n" +
                    "Alt oyun menüsü: çubuktaki <para ve nüfus okları> yanında eğilim değerlerini gösterir.\n" +
                    "Hafif bir üzerine gelme özelliğidir, <yalnızca gösterim>;\n" +
                    "oyunun bilgi panelini açmaktan daha hızlı olabilir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Para göstergesi sıklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Alt çubuk eğilim metninin para ve nüfus için saatlik mi aylık mı değer göstereceğini seç.\n" +
                    "Aylık, bütçe geliri eksi giderleri ve 24 saatlik nüfus tahminini kullanır." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Saatlik (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Aylık (/ay)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Para ipucu stili" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Para ipucunda ne kadar ayrıntı görüneceğini seç.\n" +
                    "Kompakt = ilk kurulum varsayılanı.\n" +
                    "<Mini> /ay ve /h için yalnızca 2 net değer gösterir.\n" +
                    "<Kompakt> büyük sayıları kısaltır (15,212,318 yerine 15.21M).\n" +
                    "<Tam veri> uzun değerleri ve toplamları gösterir." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Tam veri" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Para yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Para ipucu sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Para üzerine gel.\n" +
                    "Küçük ipuçlarını okumakta zorlanan oyuncular için." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Nüfus yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Nüfus ipucu sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Nüfus üzerine gel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "En önemli bildirim sayılarını küçük bir şehir HUD'unda gösterir.\n" +
                    "Tam City Watchdog panelini açmadan hızlı uyarı şeridi olarak kullan.\n" +
                    "Bir ikona tıklamak ilgili sorun noktasına atlar.\n" +
                    "Aynı ikona tıklamaya devam edersen eşleşen noktalar arasında döner ve ilkine gelir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Hızlı başlangıç ayarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Önerilen Mini HUD ayarını uygular:\n" +
                    "Favoriler, 5 ikon, yatay, üst orta, %100 boyut, koyu panel.\n" +
                    "Sıfır sayılı uyarılar görünür kalır.\n" +
                    "Genişletilmiş Watchdog panelinde **Mavi yıldız** favorilerini istediğin zaman ekle/kaldır.\n" +
                    "Başlangıç **Mavi yıldız** favorileri **[Önerilen]** ile gelir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD modu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD'un hangi bildirim satırlarını kullanacağını seç.\n" +
                    "**En aktifler** en yüksek güncel sayıları gösterir.\n" +
                    "**Favoriler**, ana City Watchdog panelinde **Mavi yıldız** işaretli satırları içerir.\n" +
                    "İstediğin kadar favori seçebilirsin,\n" +
                    "ama Mini HUD bu **mavi yıldız favorileri** listesinden yalnızca en yüksek 5 veya 10 güncel sayıyı gösterir." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "En aktif uyarılar" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriler" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "İkon sayısı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Mini HUD'un aynı anda kaç bildirim ikonu göstereceğini seç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "İkon boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Mini HUD ikonlarını ve sayıları ölçekler.\n" +
                    "90% = kompakt. 100% = varsayılan. Daha iyi görünürlük için 130%'a çıkar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Yön" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Mini HUD ikonlarının satır mı sütun mu dizileceğini seç." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Yatay" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Dikey" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD konumu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Mini HUD'un nerede görüneceğini seç.\n" +
                    "Sürüklenebilir, şehir arayüzünde taşımanı sağlar." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Üst orta" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Üst sağ" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Sürüklenebilir" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Koyu veya cam stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Mini HUD arka plan stilini seç.\n" +
                    "Cam panel berraktan bulutlu beyaza gider; koyulaşmaz.\n" +
                    "Daha koyu oyun tarzı HUD için koyu panel kullan." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Koyu panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Cam panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Arka plan opaklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Mini HUD arka plan saydamlığını ayarlar.\n" +
                    "Düşük = daha saydam. Yüksek = daha dolu.\n" +
                    "Cam daha beyaz/bulutlu olur. Koyu daha dolu/koyu olur." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Sıfır uyarıları gizle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Etkinse [ ✓ ], Mini HUD sayısı 0 olan bildirim satırlarını gizler." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Başlangıç parası" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Yeni <sınırlı para> şehri veya ilk yüklenen şehir için başlangıç bakiyesini ayarlar,\n" +
                    "uygulandıktan sonra Oyun varsayılanına döner.\n" +
                    "Bir şehir zaten yüklüyse gri görünür.\n" +
                    "Şehri başlatmadan/yüklemeden önce ayarla. Bir kez uygulanır; sonra <Para kısayol tutarı> veya <Otomatik para> kullan." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Oyun varsayılanı" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Kilometre taşı seçici" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Seçili kilometre taşını şehir yüklenir yüklenmez açmak için <şehir yüklemeden veya başlatmadan önce> etkinleştir.\n" +
                    "- Şehir yüklendikten sonra AÇILAMAZ, ama yanlışlıkla açık kaldıysa kapatılabilir.\n" +
                    "- Unutup şehir yüklediysen oyunu yeniden başlat ve şehre girmeden önce kilometre taşını seç.\n" +
                    "- Mod, şehre kaydedilmiş kilometre taşı değişikliklerini geri alamaz; gerekirse eski kayıt kullan." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kilometre taşı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Sonraki şehir yüklemesinde açılacak kilometre taşı seviyesini seç.\n" +
                    "Bu yalnızca <yüklü şehir yokken> ve [Kilometre taşı seçici] etkin [ ✓ ] olduktan sonra değiştirilebilir.\n" +
                    "Şehir zaten seçilen seviyede veya üstündeyse hiçbir şey olmaz.\n" +
                    "Sadece seçilen kilometre taşı mevcut olandan yüksekse değişir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Para kısayol tutarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Bu tutarı Para ekle ve Para çıkar kısayollarıyla kullan.\n" +
                    "<Mod varsayılanı = 40.000>\n" +
                    "Şehirde kısayolu kullanmadıkça hiçbir şey yapmaz.\n" +
                    "Otomatik para için Otomatik para ekle seçeneğini aç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Para ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Şehir içinde <Para ekle> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Para ekle" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Para çıkar" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Şehir içinde <Para çıkar> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Para çıkar" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Otomatik para ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Etkinse [ ✓ ], City Watchdog şehir yüklüyken bakiyeyi kontrol eder.\n" +
                    "- Bakiye <eşik altında> ise\n" +
                    "  seçili otomatik tutarı ekler.\n" +
                    "- Bu otomasyon yerine gerektiğinde manuel para kısayolunu (<[> veya <]>) kullanman önerilir,\n" +
                    "  ama istersen bu seçenek var." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Otomatik para eşiği" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Otomatik para etkinse ve şehir bakiyesi bu değerin altına düşerse,\n" +
                    "seçili otomatik tutar eklenir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Otomatik para tutarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Otomatik para her tetiklendiğinde eklenen tutar.\n" +
                    "Şehri güvenle eşiğin üstüne çıkaracak kadar yüksek seç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Sınırsız para dönüştürücü" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<ÖNCE şehir yedeği al>.\n" +
                    "Sınırsız para ile başlayan bir şehri normal para zorlukları olan şehre dönüştürür.\n" +
                    "Yüklü şehir <Sınırsız para> türündeyse <[Sınırsız para kaydını dönüştür]> düğmesini açar.\n" +
                    "City Watchdog bu dönüşümü geri alamaz.\n" +
                    "Normal şehirlerin varsa bunu kullanman gerekmez." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Sınırsız para şehrini normale dönüştür" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "<Sınırsız para> ile başlayan şehirler içindir.\n" +
                    "O şehir yüklüyken kaydı normal sınırlı para bütçesine dönüştürür.\n" +
                    "Yüklü şehir <Sınırsız para> türünde değilse ve\n" +
                    "<Sınırsız para dönüştürücü> AÇIK [ ✓ ] değilse düğme <devre dışı/gri> olur.\n" +
                    "Yedek al ve riski kendin üstlen; City Watchdog geri alamaz." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Bu şehri Sınırsız Para'dan normal sınırlı paraya dönüştür?\n" +
                    "ÖNCE yedek kaydet; City Watchdog geri alamaz.\n" +
                    "Emin misin?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod adı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Bu modun görünen adı." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Sürüm" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Geçerli mod sürümü." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Yazarın Paradox Mods sayfasını açar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Günlüğe hata raporu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Normal oyun için gerekli değil.>\n" +
                    "Testçiler ve oyun yamaları sonrası kontroller için: <Logs/CityWatchdog.log> içine rapor yazar\n" +
                    "ve oyundaki canlı bildirim prefabları ile Watchdog'un kontrol ettiği ikonları karşılaştırır." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Günlüğü aç" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Varsa </Logs/CityWatchdog.log> dosyasını açar.\n" +
                    "Günlük dosyası yoksa onun yerine Logs/ klasörünü açar." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
