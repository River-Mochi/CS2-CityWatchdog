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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Hành động" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Tiền-Mốc" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Giới thiệu" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "CÁCH DÙNG" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Thông báo" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Xem thông tin trong thành phố" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Thông báo Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "THIẾT LẬP THÀNH PHỐ MỚI" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Tiền" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Chuyển save tiền vô hạn" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "CHẨN ĐOÁN" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Hiện hướng dẫn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Hiện hoặc ẩn phần hướng dẫn bên dưới." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Nút hiển thị>\n" +
                    "1. Nút [i]: ẩn/hiện TẤT CẢ tooltip khi rê chuột trong game.\n" +
                    "2. Nút tên đường: ẩn/hiện tên đường. Phím tắt: \\.\n" +
                    "3. Nút tên quận: ẩn/hiện tên quận, không đổi ranh giới.\n" +
                    "4. Nút mũi tên đường: ép bật/tắt mũi tên một chiều (cũng ẩn tên đường).\n" +
                    "5. Biểu tượng CWD: ẩn/hiện tooltip của bảng City Watchdog.\n\n" +
                    "<Cảnh báo>\n" +
                    "1. Bấm City Watchdog ở góc trên trái hoặc nhấn Shift+N để mở bảng.\n" +
                    "2. Nút sắp xếp: tăng/giảm.\n" +
                    "3. Toggle All bật/tắt nhanh tất cả, hoặc mở từng mục để chỉnh riêng.\n" +
                    "4. Chỉ ẩn biểu tượng; không sửa vấn đề thật của thành phố.\n\n" +
                    "<Công cụ tiền>\n" +
                    "1. Thêm hoặc trừ tiền: dùng phím mặc định [ và ].\n" +
                    "2. Tự động thêm tiền khi thành phố thấp hơn giới hạn bạn đặt.\n" +
                    "3. Chuyển save Tiền vô hạn chỉ dành cho thành phố bắt đầu bằng Tiền vô hạn và <không thể hoàn tác>.\n\n" +
                    "<Tooltip menu dưới>\n" +
                    "Money View thêm xu hướng tiền/dân số và chi tiết khi rê chuột.\n\n" +
                    "<Mốc tùy chỉnh>\n" +
                    "Đặt tiền ban đầu và mốc trước khi tải hoặc bắt đầu thành phố."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bật/tắt biểu tượng cảnh báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Phím tắt> cùng chức năng với nút <[TOGGLE ALL]> trong game.\n" +
                    "Hiện hoặc ẩn ngay tất cả biểu tượng cảnh báo trong danh sách." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Hiện/ẩn ngay tất cả biểu tượng cảnh báo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Mở/đóng bảng cảnh báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Phím tắt> để mở hoặc đóng\n" +
                    "<bảng cảnh báo> trong thành phố.\n" +
                    "Giống bấm biểu tượng góc trên trái để mở bảng đầy đủ."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Mở/đóng bảng cảnh báo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Bắt đầu chỉ nút" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Khi bật [ ✓ ], City Watchdog mở ở chế độ nhỏ chỉ có nút.\n" +
                    "Dùng mũi tên thanh tiêu đề hoặc nút số dòng để mở bảng đầy đủ." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Phím tắt> để ẩn/hiện nhãn tên đường vanilla.\n" +
                    "Giống bấm biểu tượng Tên đường trên thanh City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ẩn/hiện tên đường" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Tắt mọi tooltip rê chuột" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Phím tắt> để ẩn/hiện TẤT CẢ tooltip rê chuột của game.\n" +
                    "<Popup tiền/dân số riêng của City Watchdog vẫn bật>; chúng do Money View điều khiển.\n" +
                    "Giống bấm biểu tượng [i] trong bảng City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ẩn/hiện tooltip của game" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Hiện tooltip tiền + dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Khuyên bật>\n" +
                    "Menu dưới: hiện giá trị xu hướng với mũi tên tiền và dân số.\n" +
                    "Tính năng nhẹ khi rê chuột trên thanh công cụ <chỉ hiển thị>;\n" +
                    "Đỡ phải mở bảng Info của game."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Tần suất Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Chọn xu hướng ở menu dưới theo giờ hay theo tháng.\n" +
                    "Theo tháng dùng thu nhập trừ chi phí, dân số dùng dự báo 24 giờ." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Theo giờ (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Theo tháng (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Kiểu tooltip tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Chọn mức chi tiết trong tooltip tiền.\n" +
                    "Gọn = mặc định lần đầu cài.\n" +
                    "<Mini> chỉ hiện 2 giá trị Net cho /mo và /h.\n" +
                    "<Gọn> rút ngắn số lớn (15.21M thay vì 15,212,318).\n" +
                    "<Dữ liệu đầy đủ> hiện số dài và tổng." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Gọn" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dữ liệu đầy đủ" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Cỡ chữ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số trong tooltip Money View.\n" +
                    "Mặc định game = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Tiền ở dưới màn hình.\n" +
                    "Dành cho người chơi thấy tooltip nhỏ khó đọc."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Cỡ chữ dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số trong tooltip dân số.\n" +
                    "Mặc định game = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Dân số ở dưới màn hình."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Hiện HUD nhỏ với các số cảnh báo quan trọng.\n" +
                    "Dùng như dải cảnh báo nhanh mà không mở bảng đầy đủ.\n" +
                    "Bấm biểu tượng để nhảy tới một điểm có vấn đề tương ứng.\n" +
                    "Bấm tiếp cùng biểu tượng để xoay qua các điểm khác rồi về điểm đầu."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Bộ khởi đầu khuyên dùng" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Áp dụng thiết lập Mini HUD khuyên dùng:\n" +
                    "Yêu thích, 5 biểu tượng, ngang, trên giữa, 100%, bảng tối.\n" +
                    "Cảnh báo số 0 vẫn hiện.\n" +
                    "Thêm/bỏ yêu thích **Sao xanh** trong bảng Watchdog mở rộng.\n" +
                    "Bộ **Sao xanh** ban đầu nằm trong **[Khuyên dùng]**."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Chế độ Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Chọn các dòng thông báo Mini HUD dùng.\n" +
                    "**Đang hoạt động cao** hiện số hiện tại cao nhất.\n" +
                    "**Yêu thích** gồm các dòng có **Sao xanh** trong bảng chính.\n" +
                    "Bạn có thể chọn bao nhiêu yêu thích tùy ý,\n" +
                    "nhưng Mini HUD chỉ hiện top 5 hoặc top 10 số cao nhất từ danh sách đó." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Cảnh báo hoạt động cao" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Yêu thích" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Số biểu tượng Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Chọn số biểu tượng Mini HUD có thể hiện cùng lúc." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Kích thước Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Phóng/thu biểu tượng và số của Mini HUD.\n" +
                    "90% = gọn. 100% = mặc định. Tăng đến 130% để dễ nhìn hơn." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Hướng Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "Chọn xếp thành hàng hay cột." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Ngang" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Dọc" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Vị trí Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Chọn nơi Mini HUD xuất hiện.\n" +
                    "Kéo được cho phép di chuyển trong UI thành phố." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Trên giữa" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Trên phải" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Kéo được" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Kiểu Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Chọn kiểu nền Mini HUD.\n" +
                    "Nền kính từ trong sang trắng mờ; không tối hơn.\n" +
                    "Dùng nền tối cho HUD kiểu vanilla tối hơn." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Nền tối" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Nền kính" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Độ mờ Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Chỉnh độ trong suốt nền Mini HUD.\n" +
                    "Thấp hơn = trong hơn. Cao hơn = đặc hơn.\n" +
                    "Kính trắng/mờ hơn. Tối thì đặc/tối hơn." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ẩn cảnh báo số 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "Khi bật [ ✓ ], Mini HUD ẩn các dòng có số 0." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Tiền ban đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Đặt số dư bắt đầu cho thành phố mới <tiền giới hạn> hoặc thành phố tải đầu tiên,\n" +
                    "rồi đặt lại về mặc định game sau khi áp dụng.\n" +
                    "Bị khóa nếu đã tải thành phố.\n" +
                    "Đặt trước khi bắt đầu/tải thành phố. Sau đó dùng <Số tiền phím tắt> hoặc <Tự động thêm tiền>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định game" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Chọn mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Bật <trước khi tải hoặc bắt đầu thành phố> để mở khóa mốc đã chọn sau khi tải.\n" +
                    "- Không thể bật sau khi đã tải thành phố, nhưng có thể tắt nếu bật nhầm.\n" +
                    "- Nếu quên, khởi động lại game và chọn trước khi vào thành phố.\n" +
                    "- Mod không thể hoàn tác mốc đã lưu; hãy dùng save cũ nếu cần."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Chọn mốc mở khóa ở lần tải thành phố tiếp theo.\n" +
                    "Chỉ chỉnh được <ngoài thành phố đã tải>, và sau khi [Chọn mốc] bật [ ✓ ].\n" +
                    "Nếu thành phố đã ở mốc đó hoặc cao hơn thì không xảy ra gì.\n" +
                    "Chỉ thay đổi nếu mốc chọn cao hơn hiện tại."
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Số tiền phím tắt" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Dùng số tiền này với phím Thêm tiền và Trừ tiền.\n" +
                    "<Mặc định mod = 40.000>\n" +
                    "Không làm gì trừ khi dùng phím tắt trong thành phố.\n" +
                    "Muốn tự động thì bật Tự động thêm tiền."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Phím tắt để <Thêm tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Thêm tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Trừ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Phím tắt để <Trừ tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Trừ tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Tự động thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Khi bật [ ✓ ], City Watchdog kiểm tra số dư thành phố.\n" +
                    "- Nếu số dư <dưới ngưỡng>, \n" +
                    "  sẽ thêm số tiền tự động đã chọn.\n" +
                    "- Nên dùng tiền thủ công bằng phím tắt (<[> hoặc <]>) khi cần" +
                    "  thay vì tự động, nhưng tùy chọn này vẫn có."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Ngưỡng tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Nếu tự động thêm tiền bật và số dư thấp hơn giá trị này,\n" +
                    "sẽ thêm số tiền đã chọn." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Số tiền thêm mỗi lần tự động kích hoạt.\n" +
                    "Chọn đủ cao để vượt an toàn qua ngưỡng." },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Bộ chuyển Tiền vô hạn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Hãy sao lưu thành phố TRƯỚC>.\n" +
                    "Chuyển thành phố bắt đầu bằng Tiền vô hạn sang thành phố thường.\n" +
                    "Mở nút <[Chuyển save Tiền vô hạn]> khi thành phố tải là loại <Tiền vô hạn>.\n" +
                    "City Watchdog không thể hoàn tác chuyển đổi này.\n" +
                    "Nếu là thành phố thường thì không cần." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Chuyển thành phố Tiền vô hạn sang thường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Dành cho thành phố bắt đầu với <Tiền vô hạn>.\n" +
                    "Khi thành phố đó đang tải, chuyển save sang ngân sách tiền giới hạn thường.\n" +
                    "Nút sẽ <tắt/màu xám> trừ khi thành phố là loại <Tiền vô hạn>\n" +
                    "và <Bộ chuyển Tiền vô hạn> đang BẬT [ ✓ ].\n" +
                    "Hãy sao lưu và tự chịu rủi ro; City Watchdog không thể hoàn tác." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Chuyển thành phố này từ Tiền vô hạn sang tiền giới hạn thường?\n" +
                    "Sao lưu TRƯỚC; City Watchdog không thể hoàn tác.\n" +
                    "Bạn chắc chứ?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Tên mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Tên hiển thị của mod này." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Phiên bản" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Phiên bản mod hiện tại." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Mở trang Paradox Mods của tác giả." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Ghi báo cáo debug vào log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Không cần cho chơi bình thường.>\n" +
                    "Cho tester và sau patch game: ghi báo cáo <Logs/CityWatchdog.log>\n" +
                    "so sánh prefab thông báo của game với icon Watchdog đang kiểm soát." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Mở log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Mở </Logs/CityWatchdog.log> nếu có.\n" +
                    "Nếu thiếu file log, mở thư mục Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
