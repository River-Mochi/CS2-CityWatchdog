// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleVI.cs
// Purpose: Vietnamese (vi-VN) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Hành động"},
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Tiền"},
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Phím tắt"},
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Giới thiệu"},
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug"},

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "CÁCH DÙNG"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Thông báo"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "CÀI ĐẶT KHỞI ĐẦU THÀNH PHỐ MỚI"},
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Xem thông tin trong thành phố"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Tiền"},
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Chuyển đổi save"},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "CHẨN ĐOÁN"},
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Phím tắt"},

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Hiện hướng dẫn"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Hiện hoặc ẩn phần hướng dẫn bên dưới."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Bật/tắt hiển thị>\n" +
                    "1. Nút [i]: ẩn/hiện TẤT CẢ tooltip khi rê chuột của game: công trình, cư dân, công cụ và icon menu dưới.\n" +
                    "2. Nút tên đường: ẩn/hiện tên đường. Phím tắt: \\.\n" +
                    "3. Nút mũi tên đường: ép hiện/ẩn mũi tên đường một chiều (cũng ẩn tên đường).\n" +
                    "4. Icon CWD trên thanh tiêu đề: hiện/ẩn tooltip của bảng City Watchdog.\n" +
                    "\n" +
                    "<Biểu tượng cảnh báo>\n" +
                    "1. Nhấn nút City Watchdog góc trên trái, hoặc Shift+N, để mở bảng.\n" +
                    "2. Nút sắp xếp đổi tăng/giảm.\n" +
                    "3. Toggle All bật/tắt nhanh tất cả, hoặc mở từng nhóm để chỉnh icon riêng.\n" +
                    "4. Chỉ ẩn icon; không sửa nguyên nhân vấn đề trong thành phố.\n" +
                    "\n" +
                    "<Công cụ tiền>\n" +
                    "1. Thêm hoặc trừ tiền: dùng phím mặc định [ và ].\n" +
                    "2. Tự động thêm tiền sẽ thêm tiền khi số dư thành phố thấp hơn giới hạn bạn đặt.\n" +
                    "3. Chuyển đổi save Unlimited Money chỉ dành cho thành phố bắt đầu bằng Unlimited Money và <không hoàn tác được>.\n" +
                    "\n" +
                    "<Tooltip menu dưới>\n" +
                    "Money View thêm giá trị xu hướng cho tiền và dân số, kèm chi tiết khi rê chuột.\n" +
                    "\n" +
                    "<Milestone tùy chỉnh>\n" +
                    "Đặt tiền ban đầu và Milestone trong CÀI ĐẶT KHỞI ĐẦU THÀNH PHỐ MỚI trước khi tải hoặc bắt đầu thành phố."},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), ""},

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bật/tắt icon thông báo"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Phím tắt> cho cùng hành động như nút <[TOGGLE ALL]> trong game.\n" +
                    "Hiện hoặc ẩn ngay tất cả icon thông báo trong danh sách."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Hiện/Ẩn ngay tất cả icon thông báo"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Mở/đóng bảng thông báo"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Phím tắt> để mở hoặc đóng\n" +
                    "<bảng thông báo> trong thành phố.\n" +
                    "Giống như bấm icon góc trên trái."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Mở/Đóng bảng thông báo"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ẩn/hiện tên đường"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Phím tắt> để ẩn hoặc hiện ngay nhãn tên đường vanilla.\n" +
                    "Giống icon Tên đường trong thanh công cụ City Watchdog."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ẩn/Hiện tên đường"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Tắt tất cả tooltip khi rê chuột"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Phím tắt> để ẩn hoặc hiện TẤT CẢ tooltip của game — công trình, cư dân, công cụ và icon menu dưới.\n" +
                    "<Popup tiền/dân số riêng của City Watchdog vẫn bật>; điều khiển bằng Money View.\n" +
                    "Giống icon [i] trong bảng City Watchdog."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ẩn/Hiện tất cả tooltip của game"},

                // --------------------------------------------------------------------
                // Actions tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Tiền ban đầu"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Đặt số dư khởi đầu cho thành phố mới dùng <limited money>, hoặc thành phố đầu tiên được tải,\n" +
                    "rồi tự quay về Game Default sau khi áp dụng.\n" +
                    "Bị mờ nếu đã tải một thành phố.\n" +
                    "Đặt trước khi bắt đầu/tải thành phố. Sau đó dùng <Số tiền phím tắt> hoặc <Tự động thêm tiền>."},
                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định game"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Chọn Milestone"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Bật <trước khi tải hoặc bắt đầu thành phố> để mở khóa milestone đã chọn ngay sau khi tải.\n" +
                    "Không thể bật sau khi thành phố đã tải, nhưng có thể tắt nếu bật nhầm.\n" +
                    "Nếu quên, hãy khởi động lại game và chọn milestone trước khi vào thành phố.\n" +
                    "City Watchdog không thể hoàn tác milestone đã lưu vào thành phố; dùng save cũ nếu cần."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Chọn milestone sẽ mở khóa ở lần tải thành phố tiếp theo.\n" +
                    "Chỉ chỉnh được khi chưa tải thành phố và sau khi [Chọn Milestone] được bật [ ✓ ]."},

                // --------------------------------------------------------------------
                // Money tab - In City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Hiện ToolTips tiền + dân số"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Nên bật>\n" +
                    "Menu dưới: hiện giá trị xu hướng cạnh mũi tên tiền và dân số của game.\n" +
                    "Tính năng rê chuột nhẹ <chỉ hiển thị>;\n" +
                    "tiết kiệm thời gian và có thể nhẹ hơn mở bảng Info của game."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Tần suất Money View"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Chọn trend tiền và dân số hiển thị theo giờ hay theo tháng.\n" +
                    "Theo tháng dùng thu nhập trừ chi phí ngân sách và dự báo dân số 24 giờ."},
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Theo giờ (/h)"},
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Theo tháng (/mo)"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Kiểu tooltip tiền"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Chọn mức chi tiết trong tooltip tiền.\n" +
                    "Compact = mặc định khi cài lần đầu.\n" +
                    "<Mini> chỉ hiện 2 giá trị Net cho /mo và /h.\n" +
                    "<Compact> rút gọn số lớn.\n" +
                    "<Full data> hiện số dài và các trường Total."},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dữ liệu đầy đủ"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Cỡ chữ tiền"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số trong Money View.\n" +
                    "Mặc định game = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Tiền ở cuối màn hình."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Cỡ chữ dân số"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số dân số.\n" +
                    "Mặc định game = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Dân số ở cuối màn hình."},

                // --------------------------------------------------------------------
                // Money tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Số tiền phím tắt"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Dùng số tiền này với phím tắt Thêm tiền và Trừ tiền.\n" +
                    "<Mặc định mod = 40,000>\n" +
                    "Không có tác dụng nếu bạn không dùng phím tắt trong thành phố.\n" +
                    "Muốn tự động thì bật Tự động thêm tiền."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Thêm tiền"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Phím tắt để <Thêm tiền> trong thành phố."},
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Thêm tiền"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Trừ tiền"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Phím tắt để <Trừ tiền> trong thành phố."},
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Trừ tiền"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Tự động thêm tiền"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Khi bật [ ✓ ], City Watchdog kiểm tra số dư khi thành phố đang tải.\n" +
                    "- Nếu số dư <dưới ngưỡng>,\n" +
                    "  sẽ thêm số tiền tự động đã chọn.\n" +
                    "- Nên dùng tiền thủ công với phím (<[> hoặc <]>) khi cần, nhưng tùy chọn này vẫn có."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Ngưỡng tiền tự động"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Nếu tự động thêm tiền bật và số dư thấp hơn giá trị này,\n" +
                    "sẽ thêm số tiền tự động đã chọn."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền tự động"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Số tiền thêm mỗi lần tự động kích hoạt.\n" +
                    "Chọn đủ lớn để đưa thành phố vượt ngưỡng an toàn."},

                // --------------------------------------------------------------------
                // Money tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Bộ chuyển Unlimited Money"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Hãy backup thành phố TRƯỚC>.\n" +
                    "Chuyển thành phố bắt đầu bằng Unlimited Money sang thành phố bình thường có ngân sách.\n" +
                    "Bật mục này sẽ mở nút <[Convert Unlimited Money Save]> khi thành phố đang tải thuộc loại <Unlimited Money>.\n" +
                    "City Watchdog không thể hoàn tác chuyển đổi này."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Chuyển thành phố Unlimited Money về bình thường"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Dành cho thành phố bắt đầu bằng <Unlimited Money>.\n" +
                    "Khi thành phố đó đang tải, chuyển save sang ngân sách limited money bình thường.\n" +
                    "Nút sẽ <tắt/mờ> trừ khi thành phố đang tải là loại <Unlimited Money>\n" +
                    "và <Bộ chuyển Unlimited Money> đang ON [ ✓ ].\n" +
                    "Backup trước và tự chịu rủi ro."},

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Chuyển thành phố này từ Unlimited Money sang tiền giới hạn bình thường?\n" +
                    "Backup TRƯỚC; City Watchdog không thể hoàn tác.\n" +
                    "Bạn chắc chứ?"},

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Tên mod"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Tên hiển thị của mod này."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Phiên bản"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Phiên bản mod hiện tại."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Mở trang Paradox Mods của tác giả."},

                // --------------------------------------------------------------------
                // Debug tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Ghi báo cáo debug vào log"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Không cần cho chơi bình thường.>\n" +
                    "Dành cho tester và kiểm tra sau patch: ghi báo cáo vào <Logs/CityWatchdog.log>."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Mở log"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Mở </Logs/CityWatchdog.log> nếu có.\n" +
                    "Nếu thiếu file log, mở thư mục Logs/."},
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
