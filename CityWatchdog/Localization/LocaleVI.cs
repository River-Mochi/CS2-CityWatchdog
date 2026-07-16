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
            string title = Mod.ModName + " (Người gác thành phố)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Hành động" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Tiền-Mốc" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Giới thiệu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "CÁCH DÙNG" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Thông báo" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Thông tin trong thành phố" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Cảnh báo Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "THIẾT LẬP THÀNH PHỐ MỚI" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Tiền" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Đổi save vô hạn" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "CHẨN ĐOÁN" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Hiện hướng dẫn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Hiện hoặc ẩn hướng dẫn bên dưới." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. Dùng biểu tượng dấu chân ở góc trái trên, hoặc Shift+N, để mở bảng chính.\n" +
                    "<Nút hiển thị>\n" +
                    "1. Biểu tượng thanh tiêu đề: hiện/ẩn tooltip của City Watchdog.\n" +
                    "\n" +
                    "2. Nút **[i]**: ẩn/hiện <TẤT CẢ> tooltip hover của game: công trình, dân, công cụ, menu dưới.\n" +
                    "3. Nút đường: ẩn/hiện tên đường. Phím tắt: \\.\n" +
                    "4. Nút quận: ẩn/hiện tên quận.\n" +
                    "5. Nút mũi tên đường: ép mũi tên 1 chiều ON/OFF (cũng ẩn tên đường).\n" +
                    "\n" +
                    "<Cảnh báo>\n" +
                    "1. Nút sắp xếp đổi A→Z, Z→A, chỉ cảnh báo đang có.\n" +
                    "2. <[0/62]> = icon ON/tổng. Bấm để bung/thu tất cả dòng.\n" +
                    "3a. [Bật/tắt tất cả] tắt/bật ngay mọi icon cảnh báo.\n" +
                    "3b. Chỉ ẩn icon; không sửa lỗi trong thành phố.\n" +
                    "\n" +
                    "<Trợ giúp tiền>\n" +
                    "1. Thêm / trừ tiền: dùng phím mặc định <[ hoặc ]> cho <Số tiền phím tắt>.\n" +
                    "2. Tiền tự động thêm tiền khi thành phố xuống dưới giới hạn bạn đặt.\n" +
                    "3. Đổi save Tiền vô hạn chỉ dùng cho thành phố bắt đầu bằng Tiền vô hạn và <không hoàn tác>.\n" +
                    "\n" +
                    "<Tooltip menu dưới>\n" +
                    "Xem tiền thêm chi tiết như xu hướng khi rê chuột lên tiền hoặc dân số.\n" +
                    "\n" +
                    "<Mốc tùy chỉnh>\n" +
                    "Tiền-Mốc > THIẾT LẬP THÀNH PHỐ MỚI đặt tiền ban đầu hoặc mốc trước khi tải/bắt đầu." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bật/tắt icon cảnh báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Phím tắt> giống nút <[Bật/tắt tất cả]> trong game.\n" +
                    "Hiện hoặc ẩn ngay tất cả icon cảnh báo đã liệt kê." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Hiện/ẩn mọi icon cảnh báo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Mở/đóng bảng cảnh báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Phím tắt> để mở hoặc đóng\n" +
                    "<bảng cảnh báo> trong thành phố.\n" +
                    "Giống bấm icon góc trái trên." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Mở/đóng bảng cảnh báo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Mở dạng chỉ nút" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "Khi bật [ ✓ ], City Watchdog mở trước ở giao diện nhỏ chỉ có nút.\n" +
                    "Dùng mũi tên tiêu đề hoặc nút số dòng để mở bảng đầy đủ." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<Phím tắt> để ẩn/hiện tên đường gốc của game.\n" +
                    "Giống icon Tên đường trong City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Tắt mọi tooltip hover" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<Phím tắt> để ẩn/hiện TẤT CẢ tooltip hover của game: công trình, dân, công cụ và icon dưới.\n" +
                    "<Popup tiền/dân số của City Watchdog vẫn bật>; do Xem tiền điều khiển.\n" +
                    "Giống icon [i] trong bảng City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ẩn/hiện tooltip hover của game" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Xu hướng tiền + dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<Nên bật>\n" +
                    "Menu dưới: hiện xu hướng ở mũi tên <tiền và dân số>.\n" +
                    "Tính năng hover nhẹ <chỉ hiển thị>;\n" +
                    "tiết kiệm thời gian và có thể nhẹ hơn mở bảng Info của game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Tần suất Xem tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Chọn số theo giờ hoặc theo tháng ở thanh dưới.\n" +
                    "Theo tháng dùng thu nhập trừ chi phí và dự báo dân số 24 giờ." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Theo giờ (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Theo tháng (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Kiểu tooltip tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Chọn mức chi tiết trong tooltip tiền.\n" +
                    "Gọn = mặc định lần cài đầu.\n" +
                    "<Mini> chỉ hiện 2 giá trị Net cho /mo và /h.\n" +
                    "<Gọn> rút ngắn số lớn (15.21M thay vì 15,212,318).\n" +
                    "<Dữ liệu đầy đủ> hiện số dài và tổng." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Gọn" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dữ liệu đầy đủ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Cỡ chữ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số trong Xem tiền.\n" +
                    "Mặc định game = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Tiền ở dưới màn hình.\n" +
                    "Cho người chơi khó đọc tooltip nhỏ." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Cỡ chữ dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số dân số.\n" +
                    "Mặc định game = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Dân số ở dưới màn hình." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "Hiện HUD nhỏ với các số cảnh báo quan trọng.\n" +
                    "Dùng như thanh cảnh báo nhanh không cần mở bảng đầy đủ.\n" +
                    "Bấm icon sẽ nhảy tới một vấn đề phù hợp.\n" +
                    "Bấm tiếp cùng icon để xoay qua các điểm rồi về điểm đầu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Bấm: khởi động nhanh" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "Áp dụng <khởi đầu nhanh> cho Mini HUD:\n" +
                    "Bao gồm một **bộ yêu thích Blue Star khởi đầu**.\n" +
                    "Thêm/xóa yêu thích **Blue Star** trong bảng Watchdog đang mở.\n" +
                    "Yêu thích, 5 biểu tượng, dọc, kéo được, kích thước 100%, bảng tối.\n" +
                    "Cảnh báo có số 0 sẽ bị ẩn.\n"
                  },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Chế độ Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Chọn các dòng thông báo Mini HUD dùng.\n" +
                    "**Đang hoạt động cao nhất** hiện các số đếm cao nhất.\n" +
                    "**Yêu thích** dùng các dòng có **Blue Star** trong bảng chính City Watchdog.\n" +
                    "Bạn có thể chọn bao nhiêu yêu thích cũng được,\n" +
                    "nhưng Mini HUD chỉ hiện top 5 hoặc top 10 từ danh sách **Blue Star** đó."
                  },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Cảnh báo đang có nhiều nhất" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Yêu thích" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Số icon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Chọn số icon Mini HUD có thể hiện." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Cỡ icon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Phóng to/thu nhỏ icon và số của Mini HUD.\n" +
                    "90% = gọn. 100% = mặc định. Tối đa 130% để dễ nhìn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Hướng" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Chọn hàng ngang hoặc cột dọc." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Ngang" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Dọc" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Vị trí HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Chọn nơi Mini HUD xuất hiện.\n" +
                    "Kéo được cho phép di chuyển trong UI thành phố." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Trên giữa" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Trên phải" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Kéo được" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Kiểu tối hoặc kính" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Chọn nền Mini HUD.\n" +
                    "Kính từ trong sang trắng mờ; không tối hơn.\n" +
                    "Dùng nền tối để có HUD tối kiểu game." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Bảng tối" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Bảng kính" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Độ đục nền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Chỉnh độ trong suốt nền Mini HUD.\n" +
                    "Thấp = trong hơn. Cao = đặc hơn.\n" +
                    "Kính trắng hơn. Tối đậm hơn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ẩn cảnh báo 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Khi bật [ ✓ ], Mini HUD ẩn các dòng có số 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Tiền ban đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Đặt số dư đầu cho thành phố mới dùng <tiền giới hạn> hoặc thành phố đầu tiên được tải,\n" +
                    "rồi tự về mặc định game.\n" +
                    "Bị xám nếu đã tải thành phố.\n" +
                    "Đặt trước khi tải/bắt đầu. Sau đó dùng <Số tiền phím tắt> hoặc <Tiền tự động>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định game" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Chọn mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Bật <trước khi tải hoặc bắt đầu> để mở mốc đã chọn khi tải thành phố.\n" +
                    "- Không thể bật khi đã vào thành phố, nhưng có thể tắt nếu bật nhầm.\n" +
                    "- Quên thì khởi động lại game và chọn trước khi vào thành phố.\n" +
                    "- Mod không hoàn tác mốc đã lưu; dùng save cũ nếu cần." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Chọn mốc để mở ở lần tải thành phố tiếp theo.\n" +
                    "Chỉ chỉnh được <ngoài thành phố đã tải> và khi [Chọn mốc] bật [ ✓ ].\n" +
                    "Nếu thành phố đã ở mốc đó hoặc cao hơn, sẽ không đổi.\n" +
                    "Chỉ đổi nếu mốc chọn cao hơn hiện tại." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Số tiền phím tắt" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Dùng số này với phím Thêm tiền và Trừ tiền.\n" +
                    "<Mặc định mod = 40,000>\n" +
                    "Không làm gì nếu không dùng phím tắt trong thành phố.\n" +
                    "Muốn tự động thì bật Tiền tự động." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Phím tắt để <Thêm tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Thêm tiền" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Trừ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Phím tắt để <Trừ tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Trừ tiền" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Khi bật [ ✓ ], City Watchdog kiểm tra số dư thành phố.\n" +
                    "- Nếu số dư <dưới ngưỡng>,\n" +
                    "  nó thêm số tiền đã chọn.\n" +
                    "- Nên dùng tiền thủ công bằng phím (<[> hoặc <]>) khi cần\n" +
                    "  thay vì tự động; tùy chọn vẫn có sẵn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Ngưỡng tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Nếu bật và số dư thành phố thấp hơn giá trị này,\n" +
                    "sẽ thêm số tiền đã chọn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Số tiền thêm mỗi lần tự động chạy.\n" +
                    "Chọn đủ lớn để vượt ngưỡng an toàn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Bộ đổi Tiền vô hạn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Sao lưu thành phố TRƯỚC>.\n" +
                    "Đổi thành phố bắt đầu bằng Tiền vô hạn thành thành phố bình thường.\n" +
                    "Bật mục này mở nút <[Đổi save Tiền vô hạn]> khi thành phố đã tải là kiểu <Tiền vô hạn>.\n" +
                    "City Watchdog không thể hoàn tác.\n" +
                    "Thành phố bình thường không cần dùng." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Đổi thành phố Tiền vô hạn thành bình thường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Dành cho thành phố bắt đầu bằng <Tiền vô hạn>.\n" +
                    "Khi thành phố đó đang tải, đổi save sang ngân sách tiền giới hạn bình thường.\n" +
                    "Nút sẽ <tắt/xám> trừ khi thành phố là kiểu <Tiền vô hạn>\n" +
                    "và <Bộ đổi Tiền vô hạn> đang ON [ ✓ ].\n" +
                    "Hãy sao lưu và tự chịu rủi ro; City Watchdog không hoàn tác." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Đổi thành phố này từ Tiền vô hạn sang tiền giới hạn bình thường?\n" +
                    "Sao lưu TRƯỚC; City Watchdog không hoàn tác.\n" +
                    "Bạn chắc chứ?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Tên mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Tên hiển thị của mod này." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Phiên bản" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Phiên bản mod hiện tại." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Mở trang Paradox Mods của tác giả." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Ghi báo cáo debug" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<Không cần cho chơi bình thường.>\n" +
                    "Cho tester và kiểm tra sau patch: ghi báo cáo vào <Logs/CityWatchdog.log>\n" +
                    "so sánh prefab cảnh báo game với icon Watchdog đang điều khiển." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Mở log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Mở </Logs/CityWatchdog.log> nếu có.\n" +
                    "Nếu thiếu, mở thư mục Logs/." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
