// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
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
            string title = Mod.ModName + " (Bekçi)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Eylemler" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Kısayollar" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Hakkında" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Hata ayıkla" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Bilgi görüntüleyici" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Para" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Bildirimler" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Kilometre taşı" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Kayıt dönüştürme" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Kısayollar" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "TANI" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "KULLANIM" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Üzerine gelince ayrıntıları göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Alt araç çubuğundaki vanilla <para ve nüfus okları> yanında sayısal eğilim değerleri gösterir.\n" +
                    "Bu hafif bir araç çubuğu hover <yalnızca görüntüleme> özelliğidir;\n" +
                    "şehir parasını veya nüfusunu değiştirmez." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View sıklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Alt araç çubuğu eğilim metninin para ve nüfus için saatlik mi aylık mı değer göstereceğini seçin.\n" +
                    "Aylık para, bütçe gelirinden giderleri çıkarır; nüfus için 24 saatlik projeksiyon kullanır." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Saatlik (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Aylık (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Para tooltip stili" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Para üzerine gelince tooltip içinde ne kadar ayrıntı görüneceğini seçin.\n" +
                    "Kompakt = ilk kurulumdaki varsayılan.\n" +
                    "<Mini> /mo ve /h için sadece 2 Net değer gösterir.\n" +
                    "<Kompakt> büyük değerleri kısaltır (15,212,318 yerine 15.21M).\n" +
                    "<Tam veri> uzun değerleri ve Toplam alanlarını gösterir." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Tam veri" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Para yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Money View tooltip sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Para üzerine gelin.\n" +
                    "Oyundaki küçük tooltipleri görmekte zorlanan oyuncuların isteğiyle eklendi." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Nüfus yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Nüfus tooltip sayılarının <yazı boyutunu> ayarlar.\n" +
                    "Oyun varsayılanı = 100%\n" +
                    "<Mod varsayılanı = 120%>\n" +
                    "Ekranın altındaki Nüfus üzerine gelin." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Para kısayolu miktarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Bu miktarı Para ekle ve Para çıkar kısayollarıyla kullanın.\n" +
                    "<Mod varsayılanı = 40,000>\n" +
                    "Şehirde para ekleme/çıkarma kısayolunu kullanmadığınız sürece hiçbir şey yapmaz.\n" +
                    "Otomatik para için Otomatik para ekle seçeneğini etkinleştirin." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Para ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Şehir içinde <Para ekle> için kısayol." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Para ekle" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Para çıkar" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Şehir içinde <Para çıkar> için kısayol." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Para çıkar" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Otomatik para ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Etkinse [ ✓ ], City Watchdog şehir yüklüyken şehir bakiyesini kontrol eder.\n" +
                    "- Bakiye <eşik değerinin altındaysa>, \n" +
                    "  seçilen otomatik miktarı ekler.\n" +
                    "- Gerektiğinde kısayolla (<[> veya <]>) manuel para kullanmanız önerilir  ama isterseniz bu otomatik seçenek de burada." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Otomatik para eşiği" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Otomatik para ekle etkinse ve şehir bakiyesi bu değerin altına düşerse,\n" +
                    "seçilen otomatik miktarı ekler." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Otomatik para miktarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Otomatik para ekle her tetiklendiğinde eklenecek miktar.\n" +
                    "Şehri güvenli biçimde eşik üstüne çıkaracak kadar yüksek bir değer seçin." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Başlangıç parası" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Yeni bir <sınırlı para> şehri veya ilk yüklenen şehir için başlangıç bakiyesini ayarlar,\n" +
                    "uygulandıktan sonra Oyun varsayılanına döner.\n" +
                    "Bir şehir zaten yüklüyse gri görünür.\n" +
                    "Şehri başlatmadan/yüklemeden önce ayarlayın → bir kez uygulanır → sonra <Para kısayolu miktarı> veya <Otomatik para ekle> kullanın." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Oyun varsayılanı" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bildirim ikonlarını aç/kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "Oyun içi <[TOGGLE ALL]> ikon düğmesiyle aynı eylem için <kısayol>.\n" +
                    "Listelenen tüm şehir bildirim ikonlarını anında gösterir veya gizler." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Tüm bildirim ikonlarını anında göster/gizle" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Bildirim panelini aç/kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "Şehirde <bildirim panelini>\n" +
                    "açmak veya kapatmak için <kısayol>.\n" +
                    "Tam paneli açmak için sol üstteki ikona tıklamakla aynı çalışır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Bildirim panelini aç/kapat" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Yol adlarını gizle/göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "Şehirdeki vanilla yol adı etiketlerini anında gizlemek veya göstermek için <kısayol>.\n" +
                    "City Watchdog panel araç çubuğundaki Yol adı ikonuna tıklamakla aynıdır." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Yol adlarını gizle/göster" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Tüm fare üstü tooltipleri kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)),
                    "Oyunun hover tooltiplerini kapatır — imleci binalar/vatandaşlar/araçlar üzerinde takip edenler\n" +
                    " ve oyun UI düğmelerindeki küçük popuplar (üst çubuk adları, vanilla düğmeler, vb.).\n" +
                    "<City Watchdog’un kendi para/nüfus popupları açık kalır>; bunlar yukarıdaki Money View seçeneğiyle kontrol edilir.\n" +
                    "Şehir içinde City Watchdog panelindeki [i] ikonuna tıklamakla aynıdır." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Kilometre taşı seçici" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Şehir yüklenir yüklenmez seçilen kilometre taşını açmak için şehir yüklemeden veya başlatmadan önce etkinleştirin.\n" +
                    "Bir şehir yüklüyken AÇILAMAZ, ama yanlışlıkla açık kaldıysa KAPATILABİLİR.\n" +
                    "City Watchdog, şehre kaydedilmiş kilometre taşı değişikliklerini geri alamaz; gerekiyorsa eski bir kayıt kullanın." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kilometre taşı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Sonraki şehir yüklemesinde açılacak kilometre taşı seviyesini seçin.\n" +
                    "Yalnızca yüklü bir şehir yokken ve ancak [Kilometre taşı seçici] etkin [ ✓ ] olduktan sonra ayarlanabilir." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Sınırsız para dönüştürücü" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<ÖNCE şehrin yedeğini alın>.\n" +
                    "Sınırsız para ile başlatılmış bir şehri normal para mücadeleleri olan normal bir şehre dönüştürür.\n" +
                    "Bunu etkinleştirmek, yüklü şehir <Sınırsız para> türündeyken <[Sınırsız para kaydını dönüştür]> düğmesini açar.\n" +
                    "City Watchdog bu dönüşümü geri alamaz.\n" +
                    "Normal şehirleriniz varsa endişelenmeyin; buna gerek yok." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Sınırsız para şehrini normale dönüştür" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<Sınırsız para> ile başlatılmış şehirler içindir.\n" +
                    "O şehir yüklüyken kaydı normal sınırlı para bütçesine dönüştürür, böylece şehir tekrar normal para mücadelesine sahip olur.\n" +
                    "Yüklü şehir <Sınırsız para> türünde değilse\n" +
                    "ve <Sınırsız para dönüştürücü> ON [ ✓ ] değilse düğme <devre dışı/gri> olur.\n" +
                    "Yedek kayıt alın ve riski size ait olmak üzere kullanın; City Watchdog bu dönüşümü geri alamaz." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Bu şehir Sınırsız paradan normal sınırlı paraya dönüştürülsün mü?\n" +
                    "ÖNCE yedek alın; City Watchdog bunu geri alamaz.\n" +
                    "Emin misiniz?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod adı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Bu modun görünen adı." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Sürüm" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Geçerli mod sürümü." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Yazarın Paradox Mods sayfasını açar." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug raporunu loga yaz" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Normal oynanış için gerekmez.>\n" +
                    "Testçiler ve oyun yaması sonrası kontroller için: canlı oyun bildirim prefablarını\n" +
                    "Watchdog’un şu anda kontrol ettiği bildirim ikonlarıyla karşılaştıran <Logs/CityWatchdog.log> raporu yazar." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Logu aç" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Varsa </Logs/CityWatchdog.log> dosyasını açar.\n" +
                    "Log dosyası yoksa bunun yerine Logs/ klasörünü açar." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Talimatları göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Aşağıdaki kullanım talimatlarını gösterir veya gizler." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Görünüm anahtarları>\n" +
                    "1. [i] düğmesi: TÜM oyun hover tooltiplerini gizle/göster (binalar, cims, araçlar).\n" +
                    "2. Yol adı düğmesi: yol adı etiketlerini gizle/göster. Kısayol: \\.\n" +
                    "3. Yol oku düğmesi: tek yön yol oklarını aç/kapatmaya zorlar (yol adlarını da gizler).\n" +
                    "4. CWD başlık çubuğu ikonu: City Watchdog panel tooltiplerini göster/gizle.\n" +
                    "\n" +
                    "<Bildirim uyarıları>\n" +
                    "1. Paneli açmak için City Watchdog düğmesine (sol üst) tıklayın veya Shift+N basın.\n" +
                    "2. Artan/azalan sıralama için sıralama düğmesi.\n" +
                    "3. Toggle All ile hızlıca tümünü Off/On yapın veya belirli ikonları değiştirmek için bir bölümü açın.\n" +
                    "4. Sadece ikonları gösterir veya gizler; şehirdeki asıl sorunu çözmez.\n" +
                    "\n" +
                    "<Para yardımcıları>\n" +
                    "1. Para ekle veya çıkar: <Para kısayolu miktarı> varsayılan tuşları [ ve ] kullanın.\n" +
                    "2. Otomatik para ekle, şehir belirlediğiniz limitin altına düşünce para ekler.\n" +
                    "3. Sınırsız para kaydı dönüştürme yalnızca Sınırsız para ile başlatılmış şehirler içindir ve <geri alınamaz>.\n" +
                    "\n" +
                    "<Alt menü tooltipleri>\n" +
                    "Money View, para ve nüfus araç çubuğuna eğilim değerleri ve hover sırasında ek ayrıntılar ekler.\n" +
                    "\n" +
                    "<Özel kilometre taşı>\n" +
                    "Şehir yüklemeden veya başlatmadan önce Seçenekler menüsünden Başlangıç parası ayarlayın ve Kilometre taşlarını seçin." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
