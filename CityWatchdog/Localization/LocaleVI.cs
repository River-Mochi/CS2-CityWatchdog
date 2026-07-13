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
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Thao tác" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Tiền-Mốc" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Giới thiệu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "CÁCH DÙNG" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Thông báo" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Thông tin trong thành phố" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Thông báo Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "THIẾT LẬP THÀNH PHỐ MỚI" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Tiền" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Chuyển bản lưu vô hạn" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "CHẨN ĐOÁN" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Hiện hướng dẫn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Hiện hoặc ẩn hướng dẫn bên dưới." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Nút hiển thị>\n" +
                    "1. Nút [i]: ẩn/hiện TẤT CẢ tooltip khi rê chuột của game - công trình, dân, công cụ, icon menu dưới.\n" +
                    "2. Nút tên đường: ẩn/hiện nhãn tên đường. Phím tắt: \\.\n" +
                    "3. Nút tên quận: ẩn/hiện tên quận mà không đổi ranh giới.\n" +
                    "4. Nút mũi tên đường: ép bật/tắt mũi tên đường một chiều (cũng ẩn tên đường).\n" +
                    "5. Icon CWD trên thanh tiêu đề: hiện/ẩn tooltip của bảng City Watchdog.\n" +
                    "\n" +
                    "<Cảnh báo>\n" +
                    "1. Bấm nút City Watchdog ở góc trên trái, hoặc Shift+N, để mở bảng.\n" +
                    "2. Nút sắp xếp: tăng/giảm.\n" +
                    "3. Chuyển tất cả để tắt/bật nhanh, hoặc mở từng mục để đổi riêng.\n" +
                    "4. Chỉ hiện/ẩn icon; không sửa lỗi của thành phố.\n" +
                    "\n" +
                    "<Hỗ trợ tiền>\n" +
                    "1. Thêm hoặc trừ tiền: dùng <Số tiền phím tắt>, phím mặc định [ và ].\n" +
                    "2. Tự thêm tiền sẽ thêm tiền khi thành phố thấp hơn giới hạn bạn đặt.\n" +
                    "3. Chuyển bản lưu Tiền vô hạn chỉ dành cho thành phố bắt đầu bằng Tiền vô hạn và <không hoàn tác>.\n" +
                    "\n" +
                    "<Tooltip menu dưới>\n" +
                    "Xem tiền thêm xu hướng tiền/dân số vào thanh dưới và thêm chi tiết khi rê chuột.\n" +
                    "\n" +
                    "<Mốc tùy chỉnh>\n" +
                    "Đặt Tiền ban đầu và chọn Mốc trong Tiền-Mốc > THIẾT LẬP THÀNH PHỐ MỚI trước khi tải hoặc tạo thành phố." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Chuyển icon thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Phím tắt> cho cùng thao tác với nút icon <[Chuyển tất cả]> trong game.\n" +
                    "Hiện hoặc ẩn ngay tất cả icon thông báo trong danh sách." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Hiện/ẩn ngay mọi icon thông báo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Mở/đóng bảng thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Phím tắt> để mở hoặc đóng\n" +
                    "<bảng thông báo> trong thành phố.\n" +
                    "Giống như bấm icon góc trên trái." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Mở/đóng bảng thông báo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Mở bảng dạng nút nhỏ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Khi bật [ ✓ ], mở City Watchdog từ nút góc trên trái sẽ bắt đầu ở dạng nhỏ chỉ có nút.\n" +
                    "Dùng mũi tên thanh tiêu đề hoặc nút đếm dòng để mở bảng đầy đủ." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Phím tắt> để ẩn hoặc hiện ngay nhãn tên đường của game gốc.\n" +
                    "Giống icon Tên đường trong thanh công cụ City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Tắt mọi tooltip rê chuột" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Phím tắt> để ẩn hoặc hiện ngay TẤT CẢ tooltip khi rê chuột của game — công trình, dân, công cụ và icon menu dưới.\n" +
                    "<Popup tiền/dân số riêng của City Watchdog vẫn bật>; chúng do tùy chọn Xem tiền điều khiển.\n" +
                    "Giống icon [i] trong bảng City Watchdog." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ẩn/hiện mọi tooltip của game" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Hiện tooltip tiền + dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Nên bật>\n" +
                    "Menu dưới: hiện giá trị xu hướng với <mũi tên tiền và dân số> trên thanh công cụ.\n" +
                    "Tính năng nhẹ khi rê chuột, <chỉ hiển thị>;\n" +
                    "tiết kiệm thời gian và có thể mượt hơn mở bảng thông tin của game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Tần suất xem tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Chọn văn bản xu hướng ở thanh dưới hiển thị theo giờ hay theo tháng cho tiền và dân số.\n" +
                    "Theo tháng dùng thu nhập ngân sách trừ chi phí và dự báo dân số 24 giờ." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Theo giờ (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Theo tháng (/tháng)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Kiểu tooltip tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Chọn mức chi tiết trong tooltip tiền.\n" +
                    "Gọn = mặc định khi cài lần đầu.\n" +
                    "<Mini> chỉ hiện 2 giá trị ròng cho /tháng và /h.\n" +
                    "<Gọn> rút gọn số lớn (15.21M thay vì 15,212,318).\n" +
                    "<Đầy đủ> hiện giá trị dài và tổng." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Gọn" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Đầy đủ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Cỡ chữ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Điều chỉnh <cỡ chữ> của số trong tooltip tiền.\n" +
                    "Mặc định game = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Tiền ở dưới màn hình.\n" +
                    "Dành cho người khó nhìn tooltip nhỏ." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Cỡ chữ dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Điều chỉnh <cỡ chữ> của số trong tooltip dân số.\n" +
                    "Mặc định game = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Dân số ở dưới màn hình." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Hiện HUD nhỏ của thành phố với các bộ đếm thông báo quan trọng nhất.\n" +
                    "Dùng như dải cảnh báo nhanh mà không cần mở toàn bộ bảng City Watchdog.\n" +
                    "Bấm icon sẽ nhảy tới một điểm có vấn đề phù hợp.\n" +
                    "Bấm tiếp cùng icon để xoay qua các điểm rồi quay lại điểm đầu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Thiết lập nhanh đề xuất" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Áp dụng thiết lập Mini HUD đề xuất:\n" +
                    "Yêu thích, 5 icon, ngang, trên giữa, cỡ 100%, nền tối.\n" +
                    "Cảnh báo có số 0 vẫn hiển thị.\n" +
                    "Thêm/bỏ yêu thích **Sao xanh** bất cứ lúc nào trong bảng Watchdog đã mở rộng.\n" +
                    "Bộ yêu thích **Sao xanh** ban đầu nằm trong **[Đề xuất]**." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Chế độ Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Chọn các dòng thông báo Mini HUD dùng.\n" +
                    "**Đang cao nhất** hiện các số hiện tại cao nhất.\n" +
                    "**Yêu thích** gồm mọi dòng có **Sao xanh** trong bảng City Watchdog chính.\n" +
                    "Bạn có thể chọn bao nhiêu yêu thích cũng được,\n" +
                    "nhưng Mini HUD chỉ hiện top 5 hoặc top 10 số hiện tại từ danh sách **yêu thích sao xanh** đó." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Cảnh báo cao nhất" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Yêu thích" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Số icon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Chọn số icon thông báo Mini HUD có thể hiện cùng lúc." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Cỡ icon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Phóng to/thu nhỏ icon và số của Mini HUD.\n" +
                    "90% = gọn. 100% = mặc định. Tăng tới 130% để dễ nhìn hơn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Hướng" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Chọn icon Mini HUD xếp theo hàng hay cột." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Ngang" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Dọc" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Vị trí HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Chọn nơi Mini HUD xuất hiện.\n" +
                    "Kéo được cho phép di chuyển nó trong giao diện thành phố." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Trên giữa" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Trên phải" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Kéo được" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Kiểu tối hoặc kính" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Chọn kiểu nền Mini HUD.\n" +
                    "Nền kính từ trong sang trắng mờ; không tối hơn.\n" +
                    "Dùng nền tối nếu muốn HUD kiểu game tối hơn." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Nền tối" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Nền kính" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Độ đậm nền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Điều chỉnh độ trong suốt của nền Mini HUD.\n" +
                    "Thấp hơn = trong hơn. Cao hơn = đặc hơn.\n" +
                    "Kính sẽ trắng/mờ hơn. Tối sẽ đặc/tối hơn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ẩn cảnh báo số 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Khi bật [ ✓ ], Mini HUD ẩn các dòng thông báo có số đếm 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Tiền ban đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Đặt số dư khởi đầu cho thành phố <tiền giới hạn> mới hoặc thành phố đầu tiên được tải,\n" +
                    "rồi trở về mặc định game sau khi áp dụng.\n" +
                    "Bị mờ nếu đã tải thành phố.\n" +
                    "Đặt trước khi tạo/tải thành phố. Áp dụng một lần, sau đó dùng <Số tiền phím tắt> hoặc <Tự thêm tiền>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định game" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Chọn mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Bật <trước khi tải hoặc tạo thành phố> để mở khóa mốc đã chọn ngay sau khi thành phố tải xong.\n" +
                    "- Không thể bật sau khi đã tải thành phố, nhưng có thể tắt nếu lỡ để bật.\n" +
                    "- Nếu quên và đã tải thành phố, hãy khởi động lại game rồi chọn mốc trước khi vào thành phố.\n" +
                    "- Mod không thể hoàn tác mốc đã lưu vào thành phố; dùng bản lưu cũ hơn nếu cần." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Chọn cấp mốc để mở khóa ở lần tải thành phố tiếp theo.\n" +
                    "Chỉ chỉnh được <ngoài thành phố đã tải>, và chỉ sau khi [Chọn mốc] được bật [ ✓ ].\n" +
                    "Nếu thành phố đã ở mốc đó hoặc cao hơn, sẽ không có gì xảy ra.\n" +
                    "Chỉ thay đổi nếu mốc đã chọn cao hơn hiện tại." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Số tiền phím tắt" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Dùng số này với phím tắt Thêm tiền và Trừ tiền.\n" +
                    "<Mặc định mod = 40,000>\n" +
                    "Không làm gì nếu bạn không dùng phím tắt trong thành phố.\n" +
                    "Muốn tự động thì bật Tự thêm tiền." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Phím tắt để <Thêm tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Thêm tiền" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Trừ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Phím tắt để <Trừ tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Trừ tiền" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Tự thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Khi bật [ ✓ ], City Watchdog kiểm tra số dư thành phố khi thành phố đã tải.\n" +
                    "- Nếu số dư <dưới ngưỡng>,\n" +
                    "  nó thêm số tiền tự động đã chọn.\n" +
                    "- Nên dùng tiền thủ công bằng phím tắt (<[> hoặc <]>) khi cần\n" +
                    "  thay vì tùy chọn tự động này, nhưng nó vẫn có nếu bạn muốn." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Ngưỡng tự thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Nếu Tự thêm tiền bật và số dư thành phố thấp hơn giá trị này,\n" +
                    "số tiền tự động đã chọn sẽ được thêm." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền thêm mỗi lần tự động kích hoạt.\n" +
                    "Chọn đủ cao để thành phố vượt an toàn qua ngưỡng." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Bộ đổi tiền vô hạn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Sao lưu thành phố TRƯỚC>.\n" +
                    "Chuyển thành phố bắt đầu bằng Tiền vô hạn thành thành phố bình thường có thử thách tiền.\n" +
                    "Bật mục này sẽ mở khóa nút <[Chuyển bản lưu Tiền vô hạn]> khi thành phố đã tải là loại <Tiền vô hạn>.\n" +
                    "City Watchdog không thể hoàn tác chuyển đổi này.\n" +
                    "Nếu bạn có thành phố bình thường thì không cần dùng." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Chuyển thành phố Tiền vô hạn thành bình thường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Dành cho thành phố bắt đầu bằng <Tiền vô hạn>.\n" +
                    "Khi thành phố đó đã tải, chuyển bản lưu sang ngân sách tiền giới hạn bình thường.\n" +
                    "Nút bị <tắt/mờ> trừ khi thành phố đã tải là loại <Tiền vô hạn>\n" +
                    "và <Bộ đổi tiền vô hạn> đang BẬT [ ✓ ].\n" +
                    "Hãy sao lưu và tự chịu rủi ro; City Watchdog không thể hoàn tác." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Chuyển thành phố này từ Tiền vô hạn sang tiền giới hạn bình thường?\n" +
                    "Lưu bản sao TRƯỚC; City Watchdog không thể hoàn tác.\n" +
                    "Bạn chắc chứ?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Tên mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Tên hiển thị của mod này." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Phiên bản" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Phiên bản mod hiện tại." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Mở trang Paradox Mods của tác giả." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Ghi báo cáo debug vào log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Không cần cho chơi bình thường.>\n" +
                    "Dành cho kiểm thử và kiểm tra sau patch game: ghi báo cáo vào <Logs/CityWatchdog.log>\n" +
                    "so sánh thông báo thật của game với các icon Watchdog đang điều khiển." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Mở log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Mở </Logs/CityWatchdog.log> nếu có.\n" +
                    "Nếu thiếu file log, mở thư mục Logs/ thay thế." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
