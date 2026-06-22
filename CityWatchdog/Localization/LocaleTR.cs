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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Eylemler"},
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Para"},
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Kısayollar"},
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Hakkında"},
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug"},

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "KULLANIM"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Bildirimler"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "YENİ ŞEHİR BAŞLANGIÇ AYARLARI"},
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Şehir içi bilgi görünümü"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Para"},
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Kayıt dönüştürme"},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "TANI"},
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Kısayollar"},

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Talimatları göster"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Aşağıdaki kullanım talimatlarını gösterir veya gizler."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Görüntü anahtarları>\n" +
                    "1. [i] düğmesi: binalar, vatandaşlar, araçlar ve alt menü ikonları dahil oyundaki TÜM hover ipuçlarını gizler/gösterir.\n" +
                    "2. Yol adı düğmesi: yol adlarını gizler/gösterir. Kısayol: \\.\n" +
                    "3. Yol oku düğmesi: tek yön yol oklarını zorla gösterir/gizler (yol adlarını da gizler).\n" +
                    "4. CWD başlık çubuğu ikonu: City Watchdog panel ipuçlarını gösterir/gizler.\n" +
                    "\n" +
                    "<Bildirim uyarıları>\n" +
                    "1. Paneli açmak için sol üstteki City Watchdog düğmesine tıklayın veya Shift+N tuşuna basın.\n" +
                    "2. Sıralama düğmesi artan/azalan sıralar.\n" +
                    "3. Toggle All hızlıca hepsini kapatır/açar; bölümleri açıp tek tek değiştirebilirsiniz.\n" +
                    "4. Yalnızca ikonları gizler; şehirdeki sorunu çözmez.\n" +
                    "\n" +
                    "<Para yardımcıları>\n" +
                    "1. Para eklemek/çıkarmak için varsayılan [ ve ] tuşlarını kullanın.\n" +
                    "2. Otomatik para, şehir bakiyesi seçtiğiniz limitin altına düşerse para ekler.\n" +
                    "3. Sınırsız Para kaydı dönüştürme yalnızca Sınırsız Para ile başlayan şehirler içindir ve <geri alınamaz>.\n" +
                    "\n" +
                    "<Alt menü ipuçları>\n" +
                    "Money View, para ve nüfus araç çubuğuna trend değerleri ve hover ayrıntıları ekler.\n" +
                    "\n" +
                    "<Özel milestone>\n" +
                    "Şehri yüklemeden veya başlatmadan önce YENİ ŞEHİR BAŞLANGIÇ AYARLARI içinde başlangıç parası ve milestone seçin."},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), ""},

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bildirim ikonlarını değiştir"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "Oyundaki <[TOGGLE ALL]> düğmesiyle aynı işlem için <kısayol>.\n" +
                    "Listelenen tüm bildirim ikonlarını anında gösterir veya gizler."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Tüm bildirim ikonlarını anında göster/gizle"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Bildirim panelini aç/kapat"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "Şehir içinde\n" +
                    "<bildirim panelini> açmak veya kapatmak için <kısayol>.\n" +
                    "Sol üst ikona tıklamakla aynıdır."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Bildirim panelini aç/kapat"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Yol adlarını gizle/göster"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "Vanilla yol adı etiketlerini anında gizler veya gösterir.\n" +
                    "City Watchdog panelindeki Yol Adı ikonu ile aynıdır."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Yol adlarını gizle/göster"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Tüm mouse-over ipuçlarını devre dışı bırak"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "Binalar, vatandaşlar, araçlar ve alt menü ikonları dahil oyundaki TÜM hover ipuçlarını gizler veya gösterir.\n" +
                    "<City Watchdog para/nüfus popup’ları açık kalır>; bunlar Money View ile kontrol edilir.\n" +
                    "City Watchdog panelindeki [i] ikonu ile aynıdır."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Tüm oyun ipuçlarını gizle/göster"},

                // --------------------------------------------------------------------
                // Actions tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Başlangıç parası"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Yeni <sınırlı para> şehri veya ilk yüklenen şehir için başlangıç bakiyesini ayarlar,\n" +
                    "uygulandıktan sonra Game Default değerine döner.\n" +
                    "Bir şehir yüklüyse gri olur.\n" +
                    "Şehri başlatmadan/yüklemeden önce ayarlayın; sonra <Para kısayol miktarı> veya <Otomatik para ekleme> kullanın."},
                { m_Settings.GetOptionLocaleID("GameDefault"), "Oyun varsayılanı"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Milestone seçici"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Seçilen milestone’u şehir yüklendikten hemen sonra açmak için <şehri yüklemeden veya başlatmadan önce> etkinleştirin.\n" +
                    "Şehir yüklüyken açılamaz, ancak yanlışlıkla açık kaldıysa kapatılabilir.\n" +
                    "Unuttuysanız oyunu yeniden başlatıp şehre girmeden önce seçin.\n" +
                    "City Watchdog kayıtlı milestone değişikliklerini geri alamaz; gerekirse eski kayıt kullanın."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Bir sonraki şehir yüklemesinde açılacak milestone’u seçin.\n" +
                    "Yalnızca şehir yüklü değilken ve [Milestone seçici] [ ✓ ] etkinse değiştirilebilir."},

                // --------------------------------------------------------------------
                // Money tab - In City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Para + nüfus ToolTips göster"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Önerilir>\n" +
                    "Alt oyun menüsü: para ve nüfus oklarının yanında trend değerleri gösterir.\n" +
                    "Hafif hover özelliğidir, <sadece görüntüleme> içindir;\n" +
                    "oyun bilgi panelini açmaktan daha hızlı ve hafif olabilir."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View sıklığı"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Para ve nüfus trend yazısının saatlik mi aylık mı gösterileceğini seçin.\n" +
                    "Aylık, bütçe gelirinden giderleri çıkarır ve 24 saatlik nüfus projeksiyonu kullanır."},
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Saatlik (/h)"},
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Aylık (/mo)"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Para ipucu stili"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Para hover ipucunda ne kadar ayrıntı görüneceğini seçin.\n" +
                    "Compact = ilk kurulum varsayılanı.\n" +
                    "<Mini> yalnızca /mo ve /h için 2 Net değer gösterir.\n" +
                    "<Compact> büyük sayıları kısaltır.\n" +
                    "<Full data> uzun değerleri ve Total alanlarını gösterir."},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Tam veri"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Para yazı boyutu"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Money View sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Para üzerine gelin."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Nüfus yazı boyutu"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Nüfus ipucu sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Nüfus üzerine gelin."},

                // --------------------------------------------------------------------
                // Money tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Para kısayol miktarı"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Para Ekle ve Para Çıkar kısayolları ile bu miktar kullanılır.\n" +
                    "<Mod varsayılanı = 40,000>\n" +
                    "Şehir içinde kısayolu kullanmazsanız hiçbir şey yapmaz.\n" +
                    "Otomatik para için Otomatik para ekleme seçeneğini açın."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Para ekle"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Şehir içinde <Para ekle> kısayolu."},
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Para ekle"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Para çıkar"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Şehir içinde <Para çıkar> kısayolu."},
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Para çıkar"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Otomatik para ekle"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Etkin [ ✓ ] olduğunda City Watchdog, şehir yüklüyken bakiyeyi kontrol eder.\n" +
                    "- Bakiye <eşik altına> düşerse,\n" +
                    "  seçilen otomatik miktarı ekler.\n" +
                    "- Gerekince manuel kısayol (<[> veya <]>) önerilir, ama bu seçenek de vardır."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Otomatik para eşiği"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Otomatik para açıksa ve bakiye bu değerin altına düşerse,\n" +
                    "seçilen otomatik miktarı ekler."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Otomatik para miktarı"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Otomatik tetiklendiğinde eklenen miktar.\n" +
                    "Şehri eşiğin güvenli üstüne çıkaracak kadar yüksek seçin."},

                // --------------------------------------------------------------------
                // Money tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Sınırsız Para dönüştürücü"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<ÖNCE şehir yedeği alın>.\n" +
                    "Sınırsız Para ile başlayan bir şehri normal bütçeli şehre dönüştürür.\n" +
                    "Yüklü şehir <Sınırsız Para> tipindeyse <[Sınırsız Para kaydını dönüştür]> düğmesini açar.\n" +
                    "City Watchdog bu dönüşümü geri alamaz."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Sınırsız Para şehrini normale dönüştür"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<Sınırsız Para> ile başlayan şehirler içindir.\n" +
                    "O şehir yüklüyken kaydı normal sınırlı bütçeye dönüştürür.\n" +
                    "Düğme, şehir <Sınırsız Para> tipinde ve <Sınırsız Para dönüştürücü> ON [ ✓ ] değilse <devre dışı/gri> olur.\n" +
                    "Yedek alın ve riski size ait olmak üzere kullanın."},

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Bu şehri Sınırsız Para’dan normal sınırlı paraya dönüştürmek istiyor musunuz?\n" +
                    "ÖNCE yedek alın; City Watchdog geri alamaz.\n" +
                    "Emin misiniz?"},

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod adı"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Bu modun görünen adı."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Sürüm"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Geçerli mod sürümü."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Yazarın Paradox Mods sayfasını açar."},

                // --------------------------------------------------------------------
                // Debug tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Log’a debug raporu"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Normal oyun için gerekmez.>\n" +
                    "Testçiler ve yama sonrası kontroller için <Logs/CityWatchdog.log> dosyasına rapor yazar."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log aç"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Varsa </Logs/CityWatchdog.log> dosyasını açar.\n" +
                    "Dosya yoksa Logs/ klasörünü açar."},
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
