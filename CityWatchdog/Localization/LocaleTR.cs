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
            string title = Mod.ModName + " (Şehir Gözcüsü)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Eylemler" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Para-Kilometre Taşları" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Hakkında" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "KULLANIM" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Bildirimler" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Şehir içi bilgi" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini HUD uyarıları" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "YENİ ŞEHİR BAŞLANGICI" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Para" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Sınırsız kaydı çevir" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "TANI" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Talimatları göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Aşağıdaki kullanım talimatlarını gösterir veya gizler." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. Ana paneli açmak için sol üstteki pati simgesini kullan veya Shift+N bas.\n" +
                    "<Görünüm düğmeleri>\n" +
                    "1. Başlık simgesi: City Watchdog ipuçlarını göster/gizle.\n" +
                    "\n" +
                    "2. **[i]** düğmesi: binalar, vatandaşlar, araçlar ve alt menü dahil oyunun <TÜM> hover ipuçlarını göster/gizle.\n" +
                    "3. Yol düğmesi: yol adlarını göster/gizle. Kısayol: \\.\n" +
                    "4. Bölge düğmesi: bölge adlarını göster/gizle.\n" +
                    "5. Yol oku düğmesi: tek yön oklarını aç/kapat (yol adlarını da gizler).\n" +
                    "\n" +
                    "<Bildirim uyarıları>\n" +
                    "1. Sıralama: A→Z, Z→A, sadece aktif liste.\n" +
                    "2. <[0/63]> = simgeler ON/toplam. Tıkla: tüm satırları aç/kapat.\n" +
                    "3a. [Tümünü değiştir] tüm uyarı simgelerini hemen kapatır/açar.\n" +
                    "3b. Sadece simgeleri gizler; şehir sorununu çözmez.\n" +
                    "\n" +
                    "<Para yardımı>\n" +
                    "1. Para ekle / çıkar: <Para kısayol tutarı> için varsayılan <[ veya ]> tuşlarını kullan.\n" +
                    "2. Otomatik para, şehir paran ayarladığın sınırın altına düşünce para ekler.\n" +
                    "3. Sınırsız Para kaydını çevirme sadece o şekilde başlayan şehirler içindir ve <geri alınamaz>.\n" +
                    "\n" +
                    "<Alt menü ipuçları>\n" +
                    "Para Görünümü, para veya nüfus üstüne gelince trend gibi ek bilgiler ekler.\n" +
                    "\n" +
                    "<Özel kilometre taşı>\n" +
                    "Para-Kilometre Taşları > YENİ ŞEHİR BAŞLANGICI, yüklemeden/başlatmadan önce başlangıç parasını veya kilometre taşlarını ayarlar." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Uyarı simgelerini değiştir" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "Oyundaki <[Tümünü değiştir]> düğmesiyle aynı iş için <kısayol>.\n" +
                    "Listelenen şehir uyarı simgelerini hemen gösterir/gizler." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Tüm uyarı simgelerini göster/gizle" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Uyarı panelini aç/kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "Şehirdeki <uyarı panelini>\n" +
                    "açmak veya kapatmak için <kısayol>.\n" +
                    "Sol üst simgeye tıklamakla aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Uyarı panelini aç/kapat" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Sadece düğmelerle başla" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Açıkken [ ✓ ], City Watchdog önce küçük sadece-düğme görünümünde açılır.\n" +
                    "Tam panel için başlık oku veya satır sayacı düğmesini kullan." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Kısayol> ile temel oyunun yol adlarını hemen gizle/göster.\n" +
                    "City Watchdog panelindeki Yol Adı simgesiyle aynı." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Tüm hover ipuçlarını kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "Binalar, vatandaşlar, araçlar ve alt simgeler dahil oyunun TÜM hover ipuçlarını gizle/göster <kısayolu>.\n" +
                    "<City Watchdog para/nüfus popupları açık kalır>; onları Para Görünümü kontrol eder.\n" +
                    "City Watchdog panelindeki [i] simgesiyle aynı." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Oyun hover ipuçlarını gizle/göster" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Para trendleri + nüfus ipuçları" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Önerilir>\n" +
                    "Alt menü: <para ve nüfus oklarında> trend değerleri gösterir.\n" +
                    "Hafif hover özelliği <sadece görüntü>;\n" +
                    "oyun Bilgi panelini açmaktan daha hızlı olabilir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Para Görünümü sıklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Alt çubuk trendleri için saatlik veya aylık değer seç.\n" +
                    "Aylık, gelir eksi gider ve 24 saat nüfus tahmini kullanır." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Saatlik (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Aylık (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Para ipucu stili" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Para hover ipucunda ne kadar detay olacağını seç.\n" +
                    "Kompakt = ilk kurulum varsayılanı.\n" +
                    "<Mini> sadece /mo ve /h için 2 net değer gösterir.\n" +
                    "<Kompakt> büyük sayıları kısaltır (15.21M gibi).\n" +
                    "<Tam veri> uzun değerleri ve toplamları gösterir." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Tam veri" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Para yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Para Görünümü sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Para üstüne gel.\n" +
                    "Küçük ipuçlarını okumakta zorlanan oyuncular için." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Nüfus yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Nüfus sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Nüfus üstüne gel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Önemli uyarı sayaçlarıyla küçük bir HUD gösterir.\n" +
                    "Tam paneli açmadan hızlı uyarı şeridi olarak kullan.\n" +
                    "Bir simgeye tıklayınca uygun soruna gider.\n" +
                    "Aynı simgeye basmaya devam ederek sorunlar arasında gezer." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Tıkla: hızlı başlangıç" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Mini HUD için <hızlı başlangıç> uygular:\n" +
                    "Favoriler, 5 simge, dikey, sürüklenebilir, %100, koyu panel.\n" +
                    "0 sayılı uyarılar gizlenir.\n" +
                    "**Mavi Yıldız favori başlangıç seti** içerir.\n" +
                    "Genişletilmiş Watchdog panelinde **Mavi Yıldız** favorileri ekle/kaldır." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD modu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Mini HUD hangi bildirim satırlarını kullansın seç.\n" +
                    "**En aktif** en yüksek güncel sayaçları gösterir.\n" +
                    "**Favoriler** ana panelde **Mavi Yıldız** olan satırları kullanır.\n" +
                    "İstediğin kadar favori seçebilirsin,\n" +
                    "ama Mini HUD sadece ilk 5 veya 10 sayacı gösterir." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "En aktif uyarılar" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriler" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Simge sayısı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Mini HUD kaç bildirim simgesi göstersin seç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Simge boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Mini HUD simgeleri ve sayıları ölçekler.\n" +
                    "90% = kompakt. 100% = varsayılan. Daha görünür için 130%’a kadar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Yön" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Satır veya sütun seç." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Yatay" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Dikey" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD konumu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Mini HUD nerede görünsün seç.\n" +
                    "Sürüklenebilir, şehir arayüzünde taşımanı sağlar." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Üst orta" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Üst sağ" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Sürüklenebilir" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Koyu veya cam stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Mini HUD arka plan stilini seç.\n" +
                    "Cam panel saydamdan beyaz buğuya gider; koyulaşmaz.\n" +
                    "Daha koyu oyun tarzı HUD için Koyu panel kullan." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Koyu panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Cam panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Arka plan opaklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Mini HUD arka plan şeffaflığını ayarlar.\n" +
                    "Düşük = daha şeffaf. Yüksek = daha dolu.\n" +
                    "Cam beyazlaşır. Koyu daha koyu/dolu olur." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "0 uyarıları gizle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Açıkken [ ✓ ], Mini HUD sayacı 0 olan satırları gizler." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Başlangıç parası" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Yeni <sınırlı para> şehri veya ilk yüklenen şehir için başlangıç bakiyesini ayarlar,\n" +
                    "sonra oyun varsayılanına döner.\n" +
                    "Şehir zaten yüklüyse gri olur.\n" +
                    "Yüklemeden/başlatmadan önce ayarla. Sonra <Para kısayol tutarı> veya <Otomatik para> kullan." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Oyun varsayılanı" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Kilometre taşı seçici" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "<Yüklemeden veya başlatmadan önce> aç; seçilen kilometre taşı yüklemede açılır.\n" +
                    "- Şehir yüklüyken ON yapılamaz, ama yanlışlıkla açıksa OFF yapılabilir.\n" +
                    "- Unuttuysan oyunu yeniden başlat ve şehre girmeden önce seç.\n" +
                    "- Mod, kayda geçmiş kilometre taşı değişikliklerini geri alamaz; eski kayıt kullan." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kilometre taşı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Sonraki şehir yüklemesinde açılacak kilometre taşını seç.\n" +
                    "Sadece <şehir yüklü değilken> ve [Kilometre taşı seçici] açık [ ✓ ] iken ayarlanır.\n" +
                    "Şehir zaten o seviyede veya üstündeyse bir şey olmaz.\n" +
                    "Sadece seçilen seviye daha yüksekse değişir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Para kısayol tutarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Bu tutarı Para Ekle ve Para Çıkar kısayollarıyla kullan.\n" +
                    "<Mod varsayılanı = 40,000>\n" +
                    "Şehirde kısayol kullanmazsan bir şey yapmaz.\n" +
                    "Otomatik para için Otomatik Para seçeneğini aç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Para ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Şehirde <Para ekle> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Para ekle" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Para çıkar" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Şehirde <Para çıkar> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Para çıkar" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Otomatik para" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Açıkken [ ✓ ], City Watchdog şehir bakiyesini kontrol eder.\n" +
                    "- Bakiye <eşik altındaysa>,\n" +
                    "  seçilen otomatik tutarı ekler.\n" +
                    "- Genelde gerektiğinde manuel kısayol (<[> veya <]>) kullanmak daha iyi\n" +
                    "  ama isteyen için seçenek var." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Otomatik para eşiği" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Açıkken şehir bakiyesi bu değerin altına düşerse,\n" +
                    "seçilen tutarı ekler." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Otomatik para tutarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Otomatik para her tetiklendiğinde eklenen tutar.\n" +
                    "Şehri eşiğin üstüne çıkaracak kadar seç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Sınırsız para dönüştürücü" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<ÖNCE şehir yedeği al>.\n" +
                    "Sınırsız Para ile başlayan şehri normal şehre çevirir.\n" +
                    "Yüklü şehir <Sınırsız Para> tipindeyse <[Sınırsız Para kaydını çevir]> düğmesini açar.\n" +
                    "City Watchdog bunu geri alamaz.\n" +
                    "Normal şehirlerin için gerekli değil." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Sınırsız Para şehrini normale çevir" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<Sınırsız Para> ile başlayan şehirler için.\n" +
                    "Şehir yüklüyken kaydı normal sınırlı bütçeye çevirir.\n" +
                    "Düğme, şehir <Sınırsız Para> değilse veya\n" +
                    "<Sınırsız para dönüştürücü> ON [ ✓ ] değilse <devre dışı/gri> olur.\n" +
                    "Yedek al ve risk sana ait; City Watchdog geri alamaz." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Bu şehir Sınırsız Para’dan normal sınırlı paraya çevrilsin mi?\n" +
                    "ÖNCE yedek kaydet; City Watchdog geri alamaz.\n" +
                    "Emin misin?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod adı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Bu modun görünen adı." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Sürüm" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Güncel mod sürümü." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Yazarın Paradox Mods sayfasını açar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug raporu loga" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Normal oyun için gerekmez.>\n" +
                    "Testçiler ve yamalar için: <Logs/CityWatchdog.log> içine rapor yazar\n" +
                    "ve canlı oyun bildirimlerini Watchdog ikonlarıyla karşılaştırır." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log aç" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "</Logs/CityWatchdog.log> varsa açar.\n" +
                    "Yoksa Logs/ klasörünü açar." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
