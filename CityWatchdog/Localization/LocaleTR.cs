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


    public sealed class LocaleTR : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleTR(CwdSettings setting)
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
                { m_Settings.GetOptionTabLocaleID(CwdSettings.Actions), "Eylemler" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MoneyTab), "Para-Kilometre Taşları" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.About), "Hakkında" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutUsage), "KULLANIM" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Notifications), "Bildirimler" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MoneyViewGroup), "Şehir içi bilgi" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MiniHudGroup), "Mini HUD uyarıları" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Milestone), "YENİ ŞEHİR BAŞLANGICI" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Money), "Para" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.SaveConversion), "Sınırsız kaydı çevir" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutDiagnostics), "TANI" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Talimatları göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Aşağıdaki kullanım talimatlarını gösterir veya gizler." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
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
                    "2. <[0/62]> = simgeler ON/toplam. Tıkla: tüm satırları aç/kapat.\n" +
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
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Uyarı simgelerini değiştir" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "Oyundaki <[Tümünü değiştir]> düğmesiyle aynı iş için <kısayol>.\n" +
                    "Listelenen şehir uyarı simgelerini hemen gösterir/gizler." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Tüm uyarı simgelerini göster/gizle" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Uyarı panelini aç/kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "Şehirdeki <uyarı panelini>\n" +
                    "açmak veya kapatmak için <kısayol>.\n" +
                    "Sol üst simgeye tıklamakla aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Uyarı panelini aç/kapat" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Sadece düğmelerle başla" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "Açıkken [ ✓ ], City Watchdog önce küçük sadece-düğme görünümünde açılır.\n" +
                    "Tam panel için başlık oku veya satır sayacı düğmesini kullan." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Kısayol> ile temel oyunun yol adlarını hemen gizle/göster.\n" +
                    "City Watchdog panelindeki Yol Adı simgesiyle aynı." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Tüm hover ipuçlarını kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "Binalar, vatandaşlar, araçlar ve alt simgeler dahil oyunun TÜM hover ipuçlarını gizle/göster <kısayolu>.\n" +
                    "<City Watchdog para/nüfus popupları açık kalır>; onları Para Görünümü kontrol eder.\n" +
                    "City Watchdog panelindeki [i] simgesiyle aynı." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Oyun hover ipuçlarını gizle/göster" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Ana panel opaklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Ana bildirim panelinin arka plan şeffaflığını ayarlar.\n" +
                    "Düşük değerler daha şeffaf, yüksek değerler daha koyu ve opaktır." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Para trendleri + nüfus ipuçları" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Önerilir>\n" +
                    "Alt menü: <para ve nüfus oklarında> trend değerleri gösterir.\n" +
                    "Hafif hover özelliği <sadece görüntü>;\n" +
                    "oyun Bilgi panelini açmaktan daha hızlı olabilir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Para Görünümü sıklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Alt çubuk trendleri için saatlik veya aylık değer seç.\n" +
                    "Aylık, gelir eksi gider ve 24 saat nüfus tahmini kullanır." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Saatlik (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Aylık (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Para ipucu stili" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Para hover ipucunda ne kadar detay olacağını seç.\n" +
                    "Kompakt = ilk kurulum varsayılanı.\n" +
                    "<Mini> sadece /mo ve /h için 2 net değer gösterir.\n" +
                    "<Kompakt> büyük sayıları kısaltır (15.21M gibi).\n" +
                    "<Tam veri> uzun değerleri ve toplamları gösterir." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Tam veri" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Para yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Para Görünümü sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Para üstüne gel.\n" +
                    "Küçük ipuçlarını okumakta zorlanan oyuncular için." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Nüfus yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Nüfus sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Nüfus üstüne gel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Önemli uyarı sayaçlarıyla küçük bir HUD gösterir.\n" +
                    "Tam paneli açmadan hızlı uyarı şeridi olarak kullan.\n" +
                    "Bir simgeye tıklayınca uygun soruna gider.\n" +
                    "Aynı simgeye basmaya devam ederek sorunlar arasında gezer." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Tıkla: hızlı başlangıç" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Mini panel için <hızlı başlangıç> uygular:\n" +
                    "**Mavi yıldız favorileri** için başlangıç seti içerir.\n" +
                    "**Mavi yıldız** olan bir uyarı, toplam sayıya göre ilk 5 veya 10 içindeyse mini panelde görünebilir.\n" +
                    "Genişletilmiş Watchdog panelinde **mavi yıldız** ekle/kaldır.\n" +
                    "Set içeriği: Favoriler, 5 ikon, dikey, sürüklenebilir, %100 boyut, koyu panel, sayısı 0 olan ikonlar gizlenir."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Mini panel modu" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Mini panelin hangi uyarı satırlarını kullanacağını seç.\n" +
                    "**En aktifler** en yüksek güncel sayıları gösterir.\n" +
                    "**Favoriler** ana City Watchdog panelindeki **mavi yıldız** satırlarını kullanır.\n" +
                    "İstediğin kadar favori seçebilirsin,\n" +
                    "ama mini panel bu **mavi yıldız** listesinden sadece ilk 5 veya 10 taneyi gösterir."
                  },            
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "En aktif uyarılar" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriler" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Simge sayısı" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Mini HUD kaç bildirim simgesi göstersin seç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Simge boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Mini HUD simgeleri ve sayıları ölçekler.\n" +
                    "90% = kompakt. 100% = varsayılan. Daha görünür için 130%’a kadar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Yön" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Satır veya sütun seç." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Yatay" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Dikey" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "HUD konumu" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Mini HUD nerede görünsün seç.\n" +
                    "Sürüklenebilir, şehir arayüzünde taşımanı sağlar." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Üst orta" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Üst sağ" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Sürüklenebilir" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Koyu veya cam stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Mini HUD arka plan stilini seç.\n" +
                    "Cam panel saydamdan beyaz buğuya gider; koyulaşmaz.\n" +
                    "Daha koyu oyun tarzı HUD için Koyu panel kullan." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Koyu panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Cam panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Arka plan opaklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Mini HUD arka plan şeffaflığını ayarlar.\n" +
                    "Düşük = daha şeffaf. Yüksek = daha dolu.\n" +
                    "Cam beyazlaşır. Koyu daha koyu/dolu olur." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "0 uyarıları gizle" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Açıkken [ ✓ ], Mini HUD sayacı 0 olan satırları gizler." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Başlangıç parası" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Yeni <sınırlı para> şehri veya ilk yüklenen şehir için başlangıç bakiyesini ayarlar,\n" +
                    "sonra oyun varsayılanına döner.\n" +
                    "Şehir zaten yüklüyse gri olur.\n" +
                    "Yüklemeden/başlatmadan önce ayarla. Sonra <Para kısayol tutarı> veya <Otomatik para> kullan." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Oyun varsayılanı" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Kilometre taşı seçici" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "<Yüklemeden veya başlatmadan önce> aç; seçilen kilometre taşı yüklemede açılır.\n" +
                    "- Şehir yüklüyken ON yapılamaz, ama yanlışlıkla açıksa OFF yapılabilir.\n" +
                    "- Unuttuysan oyunu yeniden başlat ve şehre girmeden önce seç.\n" +
                    "- Mod, kayda geçmiş kilometre taşı değişikliklerini geri alamaz; eski kayıt kullan." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Kilometre taşı" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Sonraki şehir yüklemesinde açılacak kilometre taşını seç.\n" +
                    "Sadece <şehir yüklü değilken> ve [Kilometre taşı seçici] açık [ ✓ ] iken ayarlanır.\n" +
                    "Şehir zaten o seviyede veya üstündeyse bir şey olmaz.\n" +
                    "Sadece seçilen seviye daha yüksekse değişir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Para kısayol tutarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Bu tutarı Para Ekle ve Para Çıkar kısayollarıyla kullan.\n" +
                    "<Mod varsayılanı = 40,000>\n" +
                    "Şehirde kısayol kullanmazsan bir şey yapmaz.\n" +
                    "Otomatik para için Otomatik Para seçeneğini aç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Para ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Şehirde <Para ekle> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "Para ekle" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Para çıkar" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Şehirde <Para çıkar> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "Para çıkar" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "Otomatik para" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "Açıkken [ ✓ ], City Watchdog şehir bakiyesini kontrol eder.\n" +
                    "- Bakiye <eşik altındaysa>,\n" +
                    "  seçilen otomatik tutarı ekler.\n" +
                    "- Genelde gerektiğinde manuel kısayol (<[> veya <]>) kullanmak daha iyi\n" +
                    "  ama isteyen için seçenek var." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Otomatik para eşiği" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "Açıkken şehir bakiyesi bu değerin altına düşerse,\n" +
                    "seçilen tutarı ekler." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Otomatik para tutarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Otomatik para her tetiklendiğinde eklenen tutar.\n" +
                    "Şehri eşiğin üstüne çıkaracak kadar seç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Sınırsız para dönüştürücü" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<ÖNCE şehir yedeği al>.\n" +
                    "Sınırsız Para ile başlayan şehri normal şehre çevirir.\n" +
                    "Yüklü şehir <Sınırsız Para> tipindeyse <[Sınırsız Para kaydını çevir]> düğmesini açar.\n" +
                    "City Watchdog bunu geri alamaz.\n" +
                    "Normal şehirlerin için gerekli değil." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Sınırsız Para şehrini normale çevir" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "<Sınırsız Para> ile başlayan şehirler için.\n" +
                    "Şehir yüklüyken kaydı normal sınırlı bütçeye çevirir.\n" +
                    "Düğme, şehir <Sınırsız Para> değilse veya\n" +
                    "<Sınırsız para dönüştürücü> ON [ ✓ ] değilse <devre dışı/gri> olur.\n" +
                    "Yedek al ve risk sana ait; City Watchdog geri alamaz." },
                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Bu şehir Sınırsız Para’dan normal sınırlı paraya çevrilsin mi?\n" +
                    "ÖNCE yedek kaydet; City Watchdog geri alamaz.\n" +
                    "Emin misin?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Mod adı" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Bu modun görünen adı." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Sürüm" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Güncel mod sürümü." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "Yazarın Paradox Mods sayfasını açar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "Debug raporu loga" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<Normal oyun için gerekmez.>\n" +
                    "Testçiler ve yamalar için: <Logs/CityWatchdog.log> içine rapor yazar\n" +
                    "ve canlı oyun bildirimlerini Watchdog ikonlarıyla karşılaştırır." },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Log aç" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
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
