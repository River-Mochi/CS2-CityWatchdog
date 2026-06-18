// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleTR.cs
// Purpose: Turkish (tr-TR) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Kısayollar" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Hakkında" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Hata ayıklama" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Bilgi görüntüleyici" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Para" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Bildirimler" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Kilometre taşı" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Kayıt dönüştürme" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Kısayollar" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "TANILAMA" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "KULLANIM" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Üzerine gelince ayrıntıları göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "Alt araç çubuğundaki vanilla para ve nüfus oklarının yanında sayısal eğilim değerleri gösterir.\nBu hafif bir araç çubuğu üzerine gelme <yalnızca görüntüleme> özelliğidir;\nşehir parasını veya nüfusunu değiştirmez." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View sıklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Alt araç çubuğu eğilim metninin para ve nüfus için saatlik mi aylık mı değerler göstereceğini seçin.\nAylık para için bütçe geliri eksi giderler, nüfus için 24 saatlik projeksiyon kullanılır." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Saatlik (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Aylık (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Para ipucu stili" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Para üzerine gelme ipucunda ne kadar ayrıntı görüneceğini seçin.\nKompakt = ilk kurulumda varsayılan.\n<Mini> /mo ve /h için yalnızca 2 Net değer gösterir.\n<Kompakt> büyük değerleri kısaltır (15,212,318 yerine 15.21M).\n<Tam veri> uzun değerleri ve Toplam alanlarını gösterir." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Tam veri" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Para yazı tipi boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Money View ipucu sayılarının <yazı tipi boyutunu> ayarlar.\nOyun varsayılanı = 100%\n<Mod varsayılanı = 120%>\nEkranın altındaki Para üzerine gelin.\nOyundaki küçük ipuçlarını görmekte zorlanan oyuncular için istenmiştir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Nüfus yazı tipi boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Nüfus ipucu sayılarının <yazı tipi boyutunu> ayarlar.\nOyun varsayılanı = 100%\n<Mod varsayılanı = 120%>\nEkranın altındaki Nüfus üzerine gelin." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Para kısayol tutarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Bu tutarı Para ekle ve Para çıkar kısayollarıyla kullanın.\n<Mod varsayılanı = 40,000>\nKısayolu kullanarak para eklemez/çıkarmazsanız (şehirde) hiçbir şey yapmaz.\nOtomatik para için Otomatik Para Ekle seçeneğini etkinleştirin." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Para ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Şehir içinde <Para ekle> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Para ekle" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Para çıkar" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Şehir içinde <Para çıkar> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Para çıkar" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Otomatik Para Ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Etkin olduğunda [ ✓ ], City Watchdog bir şehir yüklüyken şehir bakiyesini kontrol eder.\n- Bakiye <eşik değerinin altındaysa>, \n  seçilen otomatik tutarı ekler.\n- Bu otomatik seçenek yerine gerektiğinde kısayolla (<[> veya <]>) manuel para kullanmanız önerilir, ancak isterseniz bu seçenek de burada." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Otomatik Para Eşiği" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Otomatik Para Ekle etkinse ve şehir bakiyesi bu değerin altına düşerse,\nseçilen otomatik tutar eklenir." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Otomatik Para Tutarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Otomatik Para Ekle her tetiklendiğinde eklenen tutar.\nŞehri güvenle eşik değerinin üstüne çıkaracak kadar yüksek bir değer seçin." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Başlangıç parası" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Yeni bir <sınırlı para> şehri veya ilk yüklenen şehir için başlangıç bakiyesini ayarlar,\nuygulandıktan sonra Oyun Varsayılanı’na döner.\nBir şehir zaten yüklüyse gri görünür.\nŞehri başlatmadan/yüklemeden önce ayarlayın → bir kez uygulanır → sonra <Para kısayol tutarı> veya <Otomatik Para Ekle> kullanın." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Oyun Varsayılanı" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bildirim simgelerini aç/kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Kısayol>, oyun içi <[TOGGLE ALL]> simge düğmesiyle aynı işlemi yapar.\nListelenen tüm şehir bildirim simgelerini anında gösterir veya gizler." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Tüm bildirim simgelerini anında göster/gizle" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Bildirim panelini aç/kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Kısayol>, şehirde\n<bildirim panelini> açar veya kapatır.\nTam paneli açmak için sol üst simgeye tıklamakla aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Bildirim panelini aç/kapat" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Kısayol>, şehirdeki vanilla yol adı etiketlerini anında gizler veya gösterir.\nCity Watchdog panel araç çubuğundaki Yol adı simgesine tıklamakla aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Tüm fareyle üzerine gelme ipuçlarını devre dışı bırak" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "Oyunun üzerine gelme ipuçlarını kapatır — binalar/cim’ler/araçlar üzerinde imleci takip edenler ve oyun UI düğmelerindeki küçük açılır pencereler (üst çubuk adları, vanilla düğmeler vb.) dahil.\n<City Watchdog’un kendi para/nüfus açılır pencereleri açık kalır>; bunlar yukarıdaki Money View seçeneğiyle kontrol edilir.\nŞehir içindeki City Watchdog panelinde [i] simgesine tıklamakla aynıdır." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Kilometre taşı seçici" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Bir şehri yüklemeden veya başlatmadan önce etkinleştirerek seçilen kilometre taşını şehir yüklendikten hemen sonra açın.\nBir şehir yüklüyken AÇILAMAZ, ancak yanlışlıkla açık bırakıldıysa KAPATILABİLİR.\nCity Watchdog, bir şehre kaydedilmiş kilometre taşı değişikliklerini geri alamaz; gerekirse daha eski bir kayıt kullanın." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kilometre taşı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Sonraki şehir yüklemesinde açılacak kilometre taşı seviyesini seçin.\nYalnızca yüklü şehir dışında ve yalnızca [Kilometre taşı seçici] etkin [ ✓ ] olduktan sonra ayarlanabilir." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Sınırsız Para Dönüştürücü" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<ÖNCE şehrin yedeğini alın>.\nSınırsız Para ile başlamış bir şehri, normal para mücadeleleri olan normal bir şehre dönüştürür.\nYüklü şehir <Sınırsız Para> türündeyken bu seçeneği etkinleştirmek <[Sınırsız Para Kaydını Dönüştür]> düğmesini açar.\nCity Watchdog bu dönüştürmeyi geri alamaz.\nNormal şehirleriniz varsa endişelenmeyin; buna gerek yok." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Sınırsız Para kayıt şehrini normale dönüştür" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "<Sınırsız Para> ile başlayan şehirler için.\nBu şehir yüklüyken kayıt normal sınırlı para bütçesine dönüştürülür, böylece şehir tekrar normal para mücadelelerine sahip olur.\nYüklü şehir <Sınırsız Para> türünde olmadıkça\nve <Sınırsız Para Dönüştürücü> ON [ ✓ ] olmadıkça düğme <devre dışı/gri> kalır.\nYedek kayıt alın ve riski size ait olmak üzere kullanın; City Watchdog bu dönüştürmeyi geri alamaz." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Bu şehri Sınırsız Para’dan normal sınırlı paraya dönüştürmek istiyor musunuz?\nÖNCE bir yedek kaydedin; City Watchdog bunu geri alamaz.\nEmin misiniz?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod adı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Bu modun görünen adı." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Sürüm" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Geçerli mod sürümü." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Yazarın Paradox Mods sayfasını aç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Hata ayıklama raporunu günlüğe yaz" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Normal oyun için gerekli değildir.>\nTest edenler ve oyun yaması sonrası kontroller için: <Logs/CityWatchdog.log> raporu yazar\nve canlı oyun bildirim prefab’larını Watchdog’un şu anda kontrol ettiği bildirim simgeleriyle karşılaştırır." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Günlüğü aç" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Varsa </Logs/CityWatchdog.log> dosyasını açar.\nGünlük dosyası yoksa bunun yerine Logs/ klasörünü açar." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Talimatları göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Aşağıdaki kullanım talimatlarını göster veya gizle." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Bildirim paneli>\n1. Paneli açmak için City Watchdog düğmesine (sol üst) tıklayın veya Shift+N tuşuna basın.\n2. ASC/DESC sıralayın.\n3. Hızlı tümü Kapalı/Açık için Toggle All kullanın veya belirli simgeleri değiştirmek için bir bölümü genişletin.\n4. Yalnızca simgeleri gösterir veya gizler; alttaki şehir sorununu çözmez.\n\n<Para yardımcıları>\n1. Para ekle veya çıkar: varsayılan <Para kısayol tutarı> için [ veya ] kullanın.\n2. Otomatik para ekleme, şehir yüklüyken bütçeyi izler ve eşik altındaysa para ekler.\n3. Money View para ve nüfus araç çubuğuna ve fare üzerine gelme ipuçlarına sayısal değerler ekler.\n4. Sınırsız Para Kaydını Dönüştür yalnızca Sınırsız Para ile başlatılmış şehirler içindir ve <geri alınamaz>.\n\n<Özel kilometre taşı>\nBir şehri yüklemeden veya başlatmadan önce Seçenekler menüsünden Başlangıç Parası ayarlayın ve Kilometre Taşlarını seçin." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
