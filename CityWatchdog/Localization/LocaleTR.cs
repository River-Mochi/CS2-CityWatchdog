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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Eylemler" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Para-Kilometre Taşı" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Hakkında" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "KULLANIM" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Bildirimler" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Şehir içi bilgi görünümü" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini HUD Bildirimleri" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "YENİ ŞEHİR BAŞLANGIÇ AYARLARI" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Para" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Sınırsız kaydı dönüştür" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "TANI" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Talimatları göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Aşağıdaki kullanım talimatlarını gösterir veya gizler." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Görüntü anahtarları>\n" +
                    "1. [i] düğmesi: oyundaki TÜM hover ipuçlarını göster/gizle.\n" +
                    "2. Yol adı düğmesi: yol adlarını göster/gizle. Kısayol: \\.\n" +
                    "3. Bölge adı düğmesi: sınırları değiştirmeden adları göster/gizle.\n" +
                    "4. Yol oku düğmesi: tek yön oklarını zorla aç/kapat (yol adlarını da gizler).\n" +
                    "5. CWD başlık simgesi: City Watchdog panel ipuçlarını göster/gizle.\n\n" +
                    "<Bildirim uyarıları>\n" +
                    "1. Sol üstte City Watchdog düğmesine tıkla veya Shift+N kullan.\n" +
                    "2. Sıralama düğmesi: artan/azalan.\n" +
                    "3. Toggle All hızlıca tümünü aç/kapatır; bölüm açarak tek tek değiştir.\n" +
                    "4. Sadece simgeleri gizler; şehir sorununu çözmez.\n\n" +
                    "<Para yardımcıları>\n" +
                    "1. Para ekle/çıkar: varsayılan [ ve ] tuşlarını kullan.\n" +
                    "2. Otomatik para, şehir seçtiğin limitin altına düşünce para ekler.\n" +
                    "3. Sınırsız Para kaydı dönüştürme sadece o şehirler içindir ve <geri alınamaz>.\n\n" +
                    "<Alt menü ipuçları>\n" +
                    "Money View para/nüfus trendlerini ve hover detaylarını ekler.\n\n" +
                    "<Özel kilometre taşı>\n" +
                    "Şehri yüklemeden veya başlatmadan önce başlangıç parasını ve kilometre taşını ayarla."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bildirim simgelerini değiştir" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Kısayol>, oyun içi <[TOGGLE ALL]> simge düğmesiyle aynı işi yapar.\n" +
                    "Listelenen tüm şehir bildirim simgelerini anında gösterir veya gizler." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Tüm bildirim simgelerini anında göster/gizle" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Bildirim panelini aç/kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Kısayol> şehirdeki\n" +
                    "<bildirim panelini> açar veya kapatır.\n" +
                    "Sol üst simgeye tıklamakla aynıdır."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Bildirim panelini aç/kapat" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Sadece düğmelerle başla" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Açıkken [ ✓ ], City Watchdog küçük sadece-düğme görünümünde başlar.\n" +
                    "Tam panel için başlık oku veya satır sayısı düğmesini kullan." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Kısayol> vanilla yol adı etiketlerini anında gizler/gösterir.\n" +
                    "City Watchdog araç çubuğundaki Yol Adı simgesiyle aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Yol adlarını gizle/göster" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Tüm fare üstü ipuçlarını kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Kısayol> oyundaki TÜM hover ipuçlarını gizler/gösterir.\n" +
                    "<City Watchdog para/nüfus popupları açık kalır>; Money View ile kontrol edilir.\n" +
                    "City Watchdog panelindeki [i] simgesiyle aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Oyun hover ipuçlarını gizle/göster" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Para + nüfus ipuçlarını göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Önerilir>\n" +
                    "Alt menü: para ve nüfus oklarına trend değerleri ekler.\n" +
                    "Hafif bir toolbar hover özelliği <sadece görüntü>;\n" +
                    "Oyunun bilgi panelini açma ihtiyacını azaltır."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View sıklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Alt toolbar trendi saatlik mi aylık mı göstersin seç.\n" +
                    "Aylık: bütçe geliri eksi gider; nüfus için 24 saatlik tahmin." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Saatlik (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Aylık (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Para ipucu stili" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Para ipucunda ne kadar detay görünsün seç.\n" +
                    "Kompakt = ilk kurulum varsayılanı.\n" +
                    "<Mini> sadece /mo ve /h için 2 Net değer gösterir.\n" +
                    "<Kompakt> büyük sayıları kısaltır (15,212,318 yerine 15.21M).\n" +
                    "<Tam veri> uzun değerleri ve toplamları gösterir." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Tam veri" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Para yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Money View sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Para üzerine gel.\n" +
                    "Küçük ipuçlarını okumakta zorlanan oyuncular için."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Nüfus yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Nüfus ipucu sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Nüfus üzerine gel."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Önemli bildirim sayılarıyla küçük bir şehir HUD’u gösterir.\n" +
                    "Tam paneli açmadan hızlı uyarı şeridi olarak kullan.\n" +
                    "Simgeye tıklamak eşleşen sorun noktasına götürür.\n" +
                    "Aynı simgeye tekrar tıklayarak diğer noktalar arasında dön."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Önerilen başlangıç seti" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Önerilen Mini HUD ayarını uygular:\n" +
                    "Favoriler, 5 simge, yatay, üst orta, %100 boyut, koyu panel.\n" +
                    "Sıfır sayılı uyarılar görünür kalır.\n" +
                    "Geniş Watchdog panelinde **Mavi Yıldız** favorilerini ekle/kaldır.\n" +
                    "Başlangıç **Mavi Yıldız** favorileri **[Önerilen]** ile gelir."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD modu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Mini HUD hangi bildirim satırlarını kullansın seç.\n" +
                    "**En aktif** mevcut en yüksek sayıları gösterir.\n" +
                    "**Favoriler**, ana panelde **Mavi Yıldız** olan satırları içerir.\n" +
                    "İstediğin kadar favori seçebilirsin,\n" +
                    "ama Mini HUD bu listeden yalnızca ilk 5 veya 10 sayıyı gösterir." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "En aktif uyarılar" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Favoriler" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Mini HUD simge sayısı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Mini HUD aynı anda kaç simge göstersin seç." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Mini HUD boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Mini HUD simgelerini ve sayıları ölçekler.\n" +
                    "90% = kompakt. 100% = varsayılan. Daha iyi görünürlük için 130% kadar artır." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Mini HUD yönü" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Simgeler satır mı sütun mu seç." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Yatay" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Dikey" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Mini HUD konumu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Mini HUD nerede görünsün seç.\n" +
                    "Sürüklenebilir modda şehir arayüzünde taşıyabilirsin." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Üst orta" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Üst sağ" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Sürüklenebilir" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Mini HUD stili" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Mini HUD arka plan stilini seç.\n" +
                    "Cam panel şeffaftan bulutlu beyaza gider; koyulaşmaz.\n" +
                    "Daha koyu vanilla tarzı HUD için Koyu panel kullan." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Koyu panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Cam panel" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Mini HUD opaklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Mini HUD arka plan şeffaflığını ayarlar.\n" +
                    "Düşük = daha şeffaf. Yüksek = daha katı.\n" +
                    "Cam daha beyaz/bulutlu olur. Koyu daha katı/koyu olur." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Sıfır uyarıları gizle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Açıkken [ ✓ ], Mini HUD sayısı 0 olan satırları gizler." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Başlangıç parası" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Yeni <sınırlı para> şehri veya ilk yüklenen şehir için başlangıç bakiyesini ayarlar,\n" +
                    "uygulandıktan sonra Oyun Varsayılanına döner.\n" +
                    "Şehir zaten yüklüyse gri olur.\n" +
                    "Şehri başlatmadan/yüklemeden önce ayarla. Sonra <Para Kısayol Miktarı> veya <Otomatik Para> kullan." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Oyun Varsayılanı" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Kilometre taşı seçici" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "<Şehir yüklemeden veya başlatmadan önce> aç, yüklenince seçilen kilometre taşı açılsın.\n" +
                    "- Şehir yüklendikten sonra açılamaz, ama yanlışlıkla açıksa kapatılabilir.\n" +
                    "- Unuttuysan oyunu yeniden başlatıp şehre girmeden seç.\n" +
                    "- Mod kaydedilmiş kilometre taşı değişikliklerini geri alamaz; gerekirse eski kayıt kullan."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kilometre taşı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Sonraki şehir yüklemesinde açılacak kilometre taşını seç.\n" +
                    "Sadece <şehir yüklü değilken> ve [Kilometre taşı seçici] açıkken [ ✓ ] ayarlanır.\n" +
                    "Şehir zaten o seviyede veya üstündeyse hiçbir şey olmaz.\n" +
                    "Değişiklik yalnızca seçilen seviye daha yüksekse olur."
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Para kısayol miktarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Para Ekle ve Para Çıkar kısayollarıyla bu miktar kullanılır.\n" +
                    "<Mod varsayılanı = 40.000>\n" +
                    "Şehirde kısayolu kullanmadıkça hiçbir şey yapmaz.\n" +
                    "Otomasyon için Otomatik Para Ekle seçeneğini aç."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Para ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Şehirde <Para ekle> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Para ekle" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Para çıkar" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Şehirde <Para çıkar> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Para çıkar" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Otomatik para ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Açıkken [ ✓ ], City Watchdog şehir bakiyesini kontrol eder.\n" +
                    "- Bakiye <eşik altında> ise, \n" +
                    "  seçilen otomatik miktarı ekler.\n" +
                    "- Gerektikçe manuel kısayol (<[> veya <]>) kullanmanı öneririm" +
                    "  otomatik yerine; ama seçenek burada."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Otomatik para eşiği" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Otomatik para açıksa ve bakiye bu değerin altına düşerse,\n" +
                    "seçilen otomatik miktar eklenir." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Otomatik para miktarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Otomatik tetiklenince eklenen miktar.\n" +
                    "Bakiyeyi güvenle eşik üstüne çıkaracak kadar yüksek seç." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Sınırsız Para dönüştürücü" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<ÖNCE şehir yedeği al>.\n" +
                    "Sınırsız Para ile başlayan şehri normal para mücadeleli şehre dönüştürür.\n" +
                    "Yüklü şehir <Sınırsız Para> türündeyse <[Sınırsız Para Kaydını Dönüştür]> düğmesini açar.\n" +
                    "City Watchdog bu dönüşümü geri alamaz.\n" +
                    "Normal şehirlerin varsa gerek yok." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Sınırsız Para şehrini normale dönüştür" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<Sınırsız Para> ile başlayan şehirler için.\n" +
                    "Şehir yüklüyken kaydı normal sınırlı para bütçesine dönüştürür.\n" +
                    "Yüklü şehir <Sınırsız Para> değilse düğme <devre dışı/gri> olur\n" +
                    "ve <Sınırsız Para dönüştürücü> AÇIK [ ✓ ] olmalıdır.\n" +
                    "Yedek al ve riski sana ait; City Watchdog geri alamaz." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Bu şehri Sınırsız Para’dan normal sınırlı paraya dönüştür?\n" +
                    "ÖNCE yedek al; City Watchdog geri alamaz.\n" +
                    "Emin misin?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod adı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Bu modun görünen adı." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Sürüm" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Geçerli mod sürümü." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Yazarın Paradox Mods sayfasını açar." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug raporunu günlüğe yaz" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Normal oyun için gerekmez.>\n" +
                    "Test ve oyun yaması kontrolü için <Logs/CityWatchdog.log> raporu yazar\n" +
                    "canlı oyun bildirim prefablarını Watchdog’un kontrol ettiği ikonlarla karşılaştırır." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Günlüğü aç" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Varsa </Logs/CityWatchdog.log> dosyasını açar.\n" +
                    "Günlük yoksa Logs/ klasörünü açar." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
