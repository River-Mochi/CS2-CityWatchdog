// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

//
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
            string title = Mod.ModName + " (Giám sát)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Hành động" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Phím tắt" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Giới thiệu" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Trình xem thông tin" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Tiền" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Thông báo" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Cột mốc" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Chuyển đổi save" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Phím tắt" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "CHẨN ĐOÁN" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "CÁCH DÙNG" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Hiện chi tiết khi rê chuột" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Hiện các giá trị xu hướng dạng số cạnh mũi tên tiền và dân số vanilla ở thanh dưới.\n" +
                    "Đây là phần hiển thị nhẹ khi rê chuột trên thanh <chỉ để xem>;\n" +
                    "không thay đổi tiền hoặc dân số của thành phố." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Tần suất Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Chọn văn bản xu hướng ở thanh dưới hiển thị giá trị theo giờ hay theo tháng cho tiền và dân số.\n" +
                    "Theo tháng dùng thu ngân sách trừ chi phí cho tiền, và dự báo 24 giờ cho dân số." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Theo giờ (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Theo tháng (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Kiểu tooltip tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Chọn mức chi tiết xuất hiện trong tooltip tiền khi rê chuột.\n" +
                    "Gọn = mặc định khi cài lần đầu.\n" +
                    "<Mini> chỉ hiện 2 giá trị Net cho /mo và /h.\n" +
                    "<Gọn> rút ngắn số lớn (15.21M thay vì 15,212,318).\n" +
                    "<Dữ liệu đầy đủ> hiện số dài và các trường Total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Gọn" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dữ liệu đầy đủ" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Cỡ chữ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Điều chỉnh <cỡ chữ> của các số trong tooltip Money View.\n" +
                    "Mặc định của game = 100%\n" +
                    "<Mặc định của mod = 120%>\n" +
                    "Rê chuột lên Tiền ở dưới màn hình.\n" +
                    "Theo yêu cầu của người chơi khó nhìn tooltip nhỏ trong game." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Cỡ chữ dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Điều chỉnh <cỡ chữ> của các số trong tooltip dân số.\n" +
                    "Mặc định của game = 100%\n" +
                    "<Mặc định của mod = 120%>\n" +
                    "Rê chuột lên Dân số ở dưới màn hình." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Số tiền của phím tắt" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Dùng số tiền này với phím tắt Thêm tiền và Trừ tiền.\n" +
                    "<Mặc định của mod = 40,000>\n" +
                    "Không có tác dụng nếu bạn không dùng phím tắt để thêm/trừ tiền trong thành phố.\n" +
                    "Để dùng tiền tự động, bật tùy chọn Tự động thêm tiền." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Phím tắt để <Thêm tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Thêm tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Trừ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Phím tắt để <Trừ tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Trừ tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Tự động thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Khi bật [ ✓ ], City Watchdog kiểm tra số dư thành phố khi có thành phố đang tải.\n" +
                    "- Nếu số dư <dưới ngưỡng>, \n" +
                    "  sẽ thêm số tiền tự động đã chọn.\n" +
                    "- Nên dùng tiền thủ công bằng phím tắt (<[> hoặc <]>) khi cần  thay vì tùy chọn tự động này, nhưng vẫn có nếu bạn muốn." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Ngưỡng tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Nếu Tự động thêm tiền được bật và số dư thành phố xuống dưới giá trị này,\n" +
                    "sẽ thêm số tiền tự động đã chọn." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Số tiền thêm vào mỗi lần Tự động thêm tiền kích hoạt.\n" +
                    "Chọn giá trị đủ cao để đưa thành phố an toàn lên trên ngưỡng." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Tiền ban đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Đặt số dư ban đầu cho thành phố mới với <tiền giới hạn> hoặc thành phố đầu tiên được tải,\n" +
                    "rồi đặt lại về Mặc định của game sau khi áp dụng.\n" +
                    "Tùy chọn này bị mờ nếu đã có thành phố đang tải.\n" +
                    "Đặt trước khi bắt đầu/tải thành phố → áp dụng một lần → sau đó dùng <Số tiền của phím tắt> hoặc <Tự động thêm tiền>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định của game" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bật/tắt biểu tượng thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Phím tắt> cho cùng hành động với nút biểu tượng <[TOGGLE ALL]> trong bảng của game.\n" +
                    "Hiện hoặc ẩn ngay tất cả biểu tượng thông báo thành phố trong danh sách." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Hiện/ẩn ngay tất cả biểu tượng thông báo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Mở/đóng bảng thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Phím tắt> để mở hoặc đóng\n" +
                    "<bảng thông báo> trong thành phố.\n" +
                    "Hoạt động giống như bấm biểu tượng góc trên trái để mở bảng đầy đủ." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Mở/đóng bảng thông báo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Phím tắt> để ẩn hoặc hiện ngay nhãn tên đường vanilla trong thành phố.\n" +
                    "Giống như bấm biểu tượng Tên đường trên thanh công cụ bảng City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ẩn/hiện tên đường" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "Tắt mọi tooltip khi rê chuột" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)),
                    "Tắt tooltip khi rê chuột của game — cả tooltip đi theo con trỏ trên công trình/công dân/công cụ\n" +
                    " và các popup nhỏ trên nút UI của game (tên thanh trên, nút vanilla, v.v.).\n" +
                    "<Popup tiền/dân số riêng của City Watchdog vẫn bật>; chúng được điều khiển bằng tùy chọn Money View ở trên.\n" +
                    "Giống như bấm biểu tượng [i] trên bảng City Watchdog trong thành phố." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Chọn cột mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Bật trước khi tải hoặc bắt đầu thành phố để mở khóa cột mốc đã chọn ngay sau khi thành phố tải xong.\n" +
                    "Không thể bật khi thành phố đang tải, nhưng có thể tắt nếu lỡ để bật.\n" +
                    "City Watchdog không thể hoàn tác thay đổi cột mốc đã lưu vào thành phố; dùng save cũ hơn nếu cần." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Cột mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Chọn cấp cột mốc để mở khóa vào lần tải thành phố tiếp theo.\n" +
                    "Chỉ chỉnh được khi không có thành phố đang tải, và chỉ sau khi [Chọn cột mốc] được bật [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Bộ chuyển đổi tiền vô hạn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Hãy sao lưu thành phố TRƯỚC>.\n" +
                    "Chuyển thành phố bắt đầu bằng Tiền vô hạn thành thành phố thường với thử thách tiền bình thường.\n" +
                    "Bật tùy chọn này sẽ mở khóa nút <[Chuyển save Tiền vô hạn]> khi thành phố đang tải thuộc loại <Tiền vô hạn>.\n" +
                    "City Watchdog không thể hoàn tác chuyển đổi này.\n" +
                    "Nếu bạn có thành phố thường, đừng lo; không cần dùng mục này." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Chuyển thành phố Tiền vô hạn về thường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Dành cho thành phố bắt đầu với <Tiền vô hạn>.\n" +
                    "Khi thành phố đó đang tải, tùy chọn này chuyển save sang ngân sách tiền giới hạn bình thường để thành phố lại có thử thách tiền bình thường.\n" +
                    "Nút sẽ <tắt/bị mờ> trừ khi thành phố đang tải là loại <Tiền vô hạn>\n" +
                    "và <Bộ chuyển đổi tiền vô hạn> đang ON [ ✓ ].\n" +
                    "Hãy sao lưu save và tự chịu rủi ro; City Watchdog không thể hoàn tác chuyển đổi này." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Chuyển thành phố này từ Tiền vô hạn sang tiền giới hạn bình thường?\n" +
                    "Lưu bản sao lưu TRƯỚC; City Watchdog không thể hoàn tác.\n" +
                    "Bạn chắc chứ?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Tên mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Tên hiển thị của mod này." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Phiên bản" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Phiên bản hiện tại của mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Mở trang Paradox Mods của tác giả." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Ghi báo cáo debug vào log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Không cần cho chơi bình thường.>\n" +
                    "Dành cho tester và kiểm tra sau patch game: ghi báo cáo <Logs/CityWatchdog.log>\n" +
                    "so sánh prefab thông báo đang có trong game với các biểu tượng thông báo Watchdog đang kiểm soát." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Mở log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Mở </Logs/CityWatchdog.log> nếu có.\n" +
                    "Nếu thiếu file log, mở thư mục Logs/ thay thế." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Hiện hướng dẫn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Hiện hoặc ẩn hướng dẫn sử dụng bên dưới." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Công tắc hiển thị>\n" +
                    "1. Nút [i]: ẩn/hiện TẤT CẢ tooltip khi rê chuột của game (công trình, cims, công cụ).\n" +
                    "2. Nút Tên đường: ẩn/hiện nhãn tên đường. Phím tắt: \\.\n" +
                    "3. Nút Mũi tên đường: ép bật/tắt mũi tên đường một chiều (cũng ẩn tên đường).\n" +
                    "4. Biểu tượng thanh tiêu đề CWD: hiện/ẩn tooltip bảng City Watchdog.\n" +
                    "\n" +
                    "<Cảnh báo thông báo>\n" +
                    "1. Bấm nút City Watchdog (góc trên trái), hoặc nhấn Shift+N, để mở bảng.\n" +
                    "2. Nút sắp xếp tăng/giảm.\n" +
                    "3. Toggle All để nhanh chóng Off/On tất cả, hoặc mở rộng một mục để đổi biểu tượng cụ thể.\n" +
                    "4. Chỉ hiện hoặc ẩn biểu tượng; không sửa vấn đề thật của thành phố.\n" +
                    "\n" +
                    "<Công cụ tiền>\n" +
                    "1. Thêm hoặc trừ tiền: dùng phím mặc định của <Số tiền của phím tắt> [ và ].\n" +
                    "2. Tự động thêm tiền sẽ thêm tiền khi thành phố xuống thấp hơn giới hạn bạn đặt.\n" +
                    "3. Chuyển save Tiền vô hạn chỉ dành cho thành phố bắt đầu bằng Tiền vô hạn và <không thể đảo ngược>.\n" +
                    "\n" +
                    "<Tooltip menu dưới>\n" +
                    "Money View thêm giá trị xu hướng vào thanh tiền và dân số, cùng chi tiết thêm khi rê chuột.\n" +
                    "\n" +
                    "<Cột mốc tùy chỉnh>\n" +
                    "Đặt Tiền ban đầu và chọn Cột mốc trong menu Tùy chọn trước khi tải hoặc bắt đầu thành phố." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
