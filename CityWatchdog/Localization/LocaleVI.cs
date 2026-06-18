// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleVI.cs
// Purpose: Vietnamese (vi-VN) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

    public sealed class LocaleVI : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleVI(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Hành động" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Phím tắt" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Giới thiệu" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Gỡ lỗi" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Trình xem thông tin" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Tiền" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Thông báo" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Cột mốc" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Chuyển đổi lưu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Phím tắt" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "CHẨN ĐOÁN" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "CÁCH DÙNG" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Hiện chi tiết khi rê chuột" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "Hiển thị các giá trị xu hướng dạng số bên cạnh mũi tên tiền và dân số mặc định ở thanh công cụ dưới cùng.\nĐây là hiển thị nhẹ khi rê chuột trên thanh công cụ, <chỉ để xem>;\nkhông thay đổi tiền hoặc dân số của thành phố." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Tần suất Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Chọn văn bản xu hướng ở thanh dưới hiển thị giá trị theo giờ hay theo tháng cho tiền và dân số.\nTheo tháng dùng thu nhập ngân sách trừ chi phí cho tiền, và dự báo 24 giờ cho dân số." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Theo giờ (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Theo tháng (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Kiểu chú giải tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Chọn mức chi tiết xuất hiện trong chú giải tiền khi rê chuột.\nGọn = mặc định khi cài lần đầu.\n<Mini> chỉ hiển thị 2 giá trị ròng cho /mo và /h.\n<Gọn> rút ngắn số lớn (15.21M thay vì 15,212,318).\n<Dữ liệu đầy đủ> hiển thị giá trị dài và trường Tổng." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Gọn" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dữ liệu đầy đủ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Cỡ chữ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Điều chỉnh <cỡ chữ> của các số trong chú giải Money View.\nMặc định trò chơi = 100%\n<Mặc định mod = 120%>\nRê chuột lên Tiền ở cuối màn hình.\nĐược yêu cầu bởi người chơi khó nhìn các chú giải nhỏ trong game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Cỡ chữ dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Điều chỉnh <cỡ chữ> của các số trong chú giải dân số.\nMặc định trò chơi = 100%\n<Mặc định mod = 120%>\nRê chuột lên Dân số ở cuối màn hình." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Số tiền phím tắt" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Dùng số tiền này với phím tắt Thêm tiền và Trừ tiền.\n<Mặc định mod = 40,000>\nKhông làm gì trừ khi bạn dùng phím tắt để thêm/trừ tiền (trong thành phố).\nĐể dùng tiền tự động, bật tùy chọn Tự động thêm tiền." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Phím tắt để <Thêm tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Thêm tiền" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Trừ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Phím tắt để <Trừ tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Trừ tiền" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Tự động thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Khi bật [ ✓ ], City Watchdog kiểm tra số dư thành phố khi một thành phố đang được tải.\n- Nếu số dư <dưới ngưỡng>, \n  sẽ thêm số tiền tự động đã chọn.\n- Khuyến nghị dùng tiền thủ công bằng phím tắt (<[> hoặc <]>) khi cần thay vì tùy chọn tự động này, nhưng tùy chọn vẫn có nếu bạn muốn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Ngưỡng tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Nếu Tự động thêm tiền được bật và số dư thành phố giảm dưới giá trị này,\nthêm số tiền tự động đã chọn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền được thêm mỗi khi Tự động thêm tiền kích hoạt.\nChọn giá trị đủ cao để đưa thành phố an toàn lên trên ngưỡng." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Tiền ban đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Đặt số dư khởi đầu cho thành phố mới có <tiền giới hạn> hoặc thành phố đầu tiên được tải,\nsau đó đặt lại về Mặc định trò chơi sau khi áp dụng.\nBị làm mờ nếu thành phố đã được tải.\nĐặt trước khi bắt đầu/tải thành phố → áp dụng một lần → sau đó dùng <Số tiền phím tắt> hoặc <Tự động thêm tiền>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định trò chơi" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bật/tắt biểu tượng thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Phím tắt> cho cùng hành động với nút biểu tượng <[TOGGLE ALL]> trong bảng của trò chơi.\nHiện hoặc ẩn ngay tất cả biểu tượng thông báo thành phố được liệt kê." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Hiện/ẩn ngay tất cả biểu tượng thông báo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Mở/đóng bảng thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Phím tắt> để mở hoặc đóng\n<bảng thông báo> trong thành phố.\nHoạt động giống như bấm biểu tượng góc trên trái để mở bảng đầy đủ." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Mở/đóng bảng thông báo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Phím tắt> để ẩn hoặc hiện ngay nhãn tên đường mặc định trong thành phố.\nGiống như bấm biểu tượng tên đường trên thanh công cụ của bảng City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Tắt tất cả chú giải khi rê chuột" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "Tắt chú giải rê chuột của trò chơi — cả chú giải đi theo con trỏ trên công trình/cư dân/công cụ và các popup nhỏ trên nút UI của trò chơi (tên thanh trên, nút vanilla, v.v.).\n<Popup tiền/dân số riêng của City Watchdog vẫn bật>; chúng được điều khiển bằng tùy chọn Money View ở trên.\nGiống như bấm biểu tượng [i] trên bảng City Watchdog trong thành phố." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Bộ chọn cột mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Bật trước khi tải hoặc bắt đầu một thành phố để mở khóa cột mốc đã chọn ngay sau khi thành phố tải xong.\nKhông thể bật khi thành phố đang được tải, nhưng có thể tắt nếu lỡ để bật.\nCity Watchdog không thể hoàn tác thay đổi cột mốc đã lưu vào thành phố; hãy dùng bản lưu cũ hơn nếu cần." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Cột mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Chọn cấp cột mốc để mở khóa trong lần tải thành phố tiếp theo.\nChỉ chỉnh được bên ngoài thành phố đang tải, và chỉ sau khi [Bộ chọn cột mốc] đã bật [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Bộ chuyển đổi Tiền vô hạn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Hãy sao lưu thành phố TRƯỚC>.\nChuyển đổi thành phố bắt đầu bằng Tiền vô hạn thành thành phố bình thường với thử thách tiền thông thường.\nBật tùy chọn này sẽ mở khóa nút <[Chuyển đổi bản lưu Tiền vô hạn]> khi thành phố đang tải thuộc loại <Tiền vô hạn>.\nCity Watchdog không thể hoàn tác chuyển đổi này.\nNếu bạn có thành phố bình thường, đừng lo; không cần dùng." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Chuyển thành phố lưu Tiền vô hạn thành bình thường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Dành cho thành phố bắt đầu bằng <Tiền vô hạn>.\nKhi thành phố đó đang tải, chuyển bản lưu sang ngân sách tiền giới hạn bình thường để thành phố có lại thử thách tiền thông thường.\nNút sẽ <bị tắt/làm mờ> trừ khi thành phố đang tải thuộc loại <Tiền vô hạn>\nvà <Bộ chuyển đổi Tiền vô hạn> đang ON [ ✓ ].\nHãy tạo bản lưu sao lưu và tự chịu rủi ro; City Watchdog không thể hoàn tác chuyển đổi này." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Chuyển thành phố này từ Tiền vô hạn sang tiền giới hạn bình thường?\nHãy lưu bản sao lưu TRƯỚC; City Watchdog không thể hoàn tác.\nBạn chắc chứ?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Tên mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Tên hiển thị của mod này." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Phiên bản" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Phiên bản mod hiện tại." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Mở trang Paradox Mods của tác giả." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Báo cáo gỡ lỗi vào log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Không cần cho chơi bình thường.>\nDành cho người thử nghiệm và kiểm tra sau bản vá game: ghi báo cáo <Logs/CityWatchdog.log>\nso sánh prefab thông báo đang chạy của game với các biểu tượng thông báo Watchdog hiện đang điều khiển." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Mở log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Mở </Logs/CityWatchdog.log> nếu tồn tại.\nNếu thiếu file log, mở thư mục Logs/ thay thế." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Hiện hướng dẫn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Hiện hoặc ẩn hướng dẫn sử dụng bên dưới." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Bảng thông báo>\n1. Bấm nút City Watchdog (góc trên trái), hoặc nhấn Shift+N, để mở bảng.\n2. Sắp xếp ASC/DESC.\n3. Dùng Toggle All để nhanh chóng tắt/bật tất cả, hoặc mở rộng một mục để đổi từng biểu tượng.\n4. Chỉ hiện hoặc ẩn biểu tượng; không sửa vấn đề thật của thành phố.\n\n<Công cụ tiền>\n1. Thêm hoặc trừ tiền: dùng <Số tiền phím tắt> mặc định [ hoặc ].\n2. Tự động thêm tiền theo dõi ngân sách khi thành phố đang tải và thêm tiền khi dưới ngưỡng.\n3. Money View thêm giá trị số vào thanh tiền và dân số cùng chú giải khi rê chuột.\n4. Chuyển đổi bản lưu Tiền vô hạn chỉ dành cho thành phố bắt đầu bằng Tiền vô hạn và <không thể đảo ngược>.\n\n<Cột mốc tùy chỉnh>\nĐặt Tiền ban đầu và chọn Cột mốc trong menu Tùy chọn trước khi tải hoặc bắt đầu thành phố." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
