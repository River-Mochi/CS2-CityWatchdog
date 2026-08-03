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

    public sealed class LocaleVI : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleVI(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (Người gác thành phố)";

            Dictionary<string, string> entries = new()
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kActions), "Hành động" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMoneyTab), "Khởi đầu TP" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kAbout), "Giới thiệu" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutUsage), "CÁCH DÙNG" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kNotifications), "Thông báo" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoneyViewGroup), "Thông tin trong thành phố" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMiniHudGroup), "Cảnh báo Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "THIẾT LẬP THÀNH PHỐ MỚI" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "Tiền" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "Đổi bản lưu vô hạn" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "CHẨN ĐOÁN" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "Hiện hướng dẫn" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "Hiện hoặc ẩn hướng dẫn bên dưới." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. Dùng biểu tượng dấu chân ở góc trái trên, hoặc Shift+N, để mở bảng chính.\n" +
                    "<Nút hiển thị>\n" +
                    "1. Biểu tượng thanh tiêu đề: hiện/ẩn chú thích của City Watchdog.\n" +
                    "\n" +
                    "2. Nút **[i]**: ẩn/hiện <TẤT CẢ> chú thích của trò chơi: công trình, dân, công cụ và menu dưới.\n" +
                    "3. Nút đường: ẩn/hiện tên đường. Phím tắt: \\.\n" +
                    "4. Nút quận: ẩn/hiện tên quận.\n" +
                    "5. Nút mũi tên đường: hiện/ẩn mũi tên một chiều (cũng ẩn tên đường).\n" +
                    "\n" +
                    "<Cảnh báo>\n" +
                    "1. Nút sắp xếp đổi A→Z, Z→A, chỉ cảnh báo đang có.\n" +
                    "2. <[0/63]> = biểu tượng đang hiện/tổng. Bấm để bung/thu tất cả dòng.\n" +
                    "3a. [Hiện biểu tượng] tắt/bật ngay mọi biểu tượng cảnh báo vấn đề.\n" +
                    "3b. Bộ nhớ [1 | 2]: bấm để tải; giữ 1 giây để lưu các ô đang chọn.\n" +
                    "3c. Ẩn biểu tượng không sửa được vấn đề trong thành phố.\n" +
                    "\n" +
                    "<Trợ giúp>\n" +
                    "1. Thêm / trừ tiền: dùng phím mặc định <[ hoặc ]> cho <Số tiền phím tắt>.\n" +
                    "2. Tiền tự động thêm tiền khi thành phố xuống dưới giới hạn bạn đặt.\n" +
                    "3. Đổi bản lưu Tiền vô hạn chỉ dùng cho thành phố bắt đầu bằng Tiền vô hạn và <không hoàn tác>.\n" +
                    "\n" +
                    "<Chú thích menu dưới>\n" +
                    "Xem tiền thêm chi tiết như xu hướng khi rê chuột lên tiền hoặc dân số.\n" +
                    "\n" +
                    "<Mốc tùy chỉnh>\n" +
                    "Khởi đầu TP đặt tiền ban đầu hoặc mốc trước khi tải hay bắt đầu thành phố."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "Bật/tắt biểu tượng cảnh báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<Phím tắt> giống nút <[HIỆN BIỂU TƯỢNG]> trong trò chơi.\n" +
                    "Hiện hoặc ẩn ngay mọi biểu tượng cảnh báo vấn đề."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "Hiện/ẩn ngay biểu tượng cảnh báo vấn đề" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "Mở/đóng bảng cảnh báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<Phím tắt> để mở hoặc đóng\n" +
                    "<bảng cảnh báo> trong thành phố.\n" +
                    "Giống bấm biểu tượng góc trái trên."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "Mở/đóng bảng cảnh báo" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "Mở dạng chỉ nút" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "Khi bật [ ✓ ], City Watchdog mở trước ở giao diện nhỏ chỉ có nút.\n" +
                    "Dùng mũi tên tiêu đề hoặc nút số dòng để mở bảng đầy đủ."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<Phím tắt> để ẩn/hiện tên đường gốc của trò chơi.\n" +
                    "Giống biểu tượng Tên đường trong City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "Ẩn/hiện tên đường" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "Tắt mọi chú thích khi rê chuột" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<Phím tắt> để ẩn/hiện TẤT CẢ chú thích khi rê chuột của trò chơi: công trình, dân, công cụ và biểu tượng dưới.\n" +
                    "<Cửa sổ tiền/dân số của City Watchdog vẫn bật>; do Xem tiền điều khiển.\n" +
                    "Giống biểu tượng [i] trong bảng City Watchdog."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "Ẩn/hiện chú thích khi rê chuột của trò chơi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "Giao diện game lớn hơn" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "Khi bật [ ✓ ], <toàn bộ giao diện trò chơi> sẽ lớn hơn — cả bảng game và mod.\n" +
                    "Dùng tùy chọn <Tỷ lệ giao diện> của game mà không cần tham số <--developerMode>.\n" +
                    "Ô [x] này đồng bộ với nút đổi tỷ lệ trên thanh tiêu đề City Watchdog.\n" +
                    "Chỉ đổi cỡ chữ: Tùy chọn > Giao diện > <Tỷ lệ chữ>.\n" +
                    "Vẫn bật cho đến khi bạn tắt, kể cả khi gỡ City Watchdog.\n" +
                    "- Tắt trước khi gỡ mod để trở về kích thước bình thường.\n" +
                    "- Hoặc chạy một lần với <--developerMode> rồi tắt Tùy chọn > Giao diện > Tỷ lệ giao diện (dev)."
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "Độ đục bảng chính" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "Điều chỉnh độ trong suốt của nền bảng thông báo chính.\n" +
                    "Giá trị thấp trong suốt hơn. Giá trị cao tối và đục hơn."
                },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "Xu hướng tiền + dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<Nên bật>\n" +
                    "Menu dưới: hiện xu hướng ở mũi tên <tiền và dân số>.\n" +
                    "Tính năng rê chuột nhẹ <chỉ hiển thị>;\n" +
                    "tiết kiệm thời gian và có thể nhẹ hơn mở bảng thông tin của trò chơi."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "Tần suất Xem tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "Chọn số theo giờ hoặc theo tháng ở thanh dưới.\n" +
                    "Theo tháng dùng thu nhập trừ chi phí và dự báo dân số 24 giờ."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Theo giờ (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Theo tháng (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "Kiểu chú thích tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "Chọn mức chi tiết trong chú thích tiền.\n" +
                    "Gọn = mặc định lần cài đầu.\n" +
                    "<Tối giản> chỉ hiện 2 giá trị ròng cho /mo và /h.\n" +
                    "<Gọn> rút ngắn số lớn (15.21M thay vì 15,212,318).\n" +
                    "<Dữ liệu đầy đủ> hiện số dài và tổng."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Tối giản" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Gọn" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dữ liệu đầy đủ" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "Cỡ chữ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số trong Xem tiền.\n" +
                    "Mặc định trò chơi = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Tiền ở dưới màn hình.\n" +
                    "Cho người chơi khó đọc chú thích nhỏ."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "Cỡ chữ dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số dân số.\n" +
                    "Mặc định trò chơi = 100%\n" +
                    "<Mặc định mod = 120%>\n" +
                    "Rê chuột lên Dân số ở dưới màn hình."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "Hiện HUD nhỏ với các số cảnh báo quan trọng.\n" +
                    "Dùng như thanh cảnh báo nhanh không cần mở bảng đầy đủ.\n" +
                    "Bấm biểu tượng sẽ nhảy tới một vấn đề phù hợp.\n" +
                    "Bấm tiếp cùng biểu tượng để xoay qua các điểm rồi về điểm đầu."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "Bấm: khởi động nhanh" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Áp dụng <khởi động nhanh> cho Mini HUD:\n" +
                    "Thêm một **bộ Sao xanh yêu thích ban đầu**.\n" +
                    "Ở chế độ Yêu thích, Mini HUD hiện 5 hoặc 10 số đếm hiện tại cao nhất trong danh sách **Sao xanh**.\n" +
                    "Thêm/xóa **Sao xanh** trong bảng City Watchdog.\n" +
                    "Đặt: Yêu thích, 5 biểu tượng, ngang, kéo được, 100%, bảng tối và ẩn số đếm 0.\n" +
                    "Chạy lại Khởi động nhanh bất cứ lúc nào để đặt lại các tùy chọn này."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "Chế độ bảng nhỏ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "Chọn các dòng cảnh báo bảng nhỏ dùng.\n" +
                    "**Số lượng cao nhất** hiện các số đếm hiện tại cao nhất.\n" +
                    "**Yêu thích** dùng các dòng có **sao xanh dương** trong bảng chính City Watchdog.\n" +
                    "Bạn có thể chọn bao nhiêu yêu thích cũng được,\n" +
                    "nhưng bảng nhỏ chỉ hiện 5 hoặc 10 số cao nhất từ danh sách **sao xanh dương** đó."
                },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Cảnh báo nhiều nhất" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Yêu thích" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Số biểu tượng" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "Chọn số biểu tượng Mini HUD có thể hiện." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "Cỡ biểu tượng" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "Phóng to/thu nhỏ biểu tượng và số của Mini HUD.\n" +
                    "90% = gọn. 100% = mặc định. Tối đa 130% để dễ nhìn."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Hướng" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "Chọn hàng ngang hoặc cột dọc." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Ngang" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Dọc" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "Vị trí HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "Chọn nơi Mini HUD xuất hiện.\n" +
                    "Kéo được cho phép di chuyển trong giao diện thành phố."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Trên giữa" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Trên phải" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Kéo được" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "Kiểu tối hoặc kính" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "Chọn nền Mini HUD.\n" +
                    "Kính từ trong sang trắng mờ; không tối hơn.\n" +
                    "Dùng nền tối để có HUD tối kiểu trò chơi."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Bảng tối" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Bảng kính" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "Độ đục nền" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "Chỉnh độ trong suốt nền Mini HUD.\n" +
                    "Thấp = trong hơn. Cao = đặc hơn.\n" +
                    "Kính trắng hơn. Tối đậm hơn."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Ẩn cảnh báo 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "Khi bật [ ✓ ], Mini HUD ẩn các dòng có số 0." },

                // --------------------------------------------------------------------
                // City Start tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "Tiền ban đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "Đặt số dư cho thành phố <tiền giới hạn> được tải tiếp theo — mới hoặc đã có.\n" +
                    "Sau khi áp dụng một lần, tùy chọn này trở về mặc định trò chơi.\n" +
                    "Bị xám khi đã tải thành phố.\n" +
                    "Đặt trước khi tải hoặc bắt đầu thành phố. Sau đó dùng <Số tiền phím tắt> khi cần."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định trò chơi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "Chọn mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "Bật <trước khi tải hoặc bắt đầu> để mở mốc đã chọn khi tải thành phố.\n" +
                    "- Không thể bật khi đã vào thành phố, nhưng có thể tắt nếu bật nhầm.\n" +
                    "- Quên thì khởi động lại trò chơi và chọn trước khi vào thành phố.\n" +
                    "- Mod không hoàn tác mốc đã lưu; dùng bản lưu cũ nếu cần."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "Mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "Chọn mốc để mở ở lần tải thành phố tiếp theo.\n" +
                    "Chỉ chỉnh được <ngoài thành phố đã tải> và khi [Chọn mốc] bật [ ✓ ].\n" +
                    "Nếu thành phố đã ở mốc đó hoặc cao hơn, sẽ không đổi.\n" +
                    "Chỉ đổi nếu mốc chọn cao hơn hiện tại."
                },

                // --------------------------------------------------------------------
                // City Start tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "Số tiền phím tắt" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "Dùng số này với phím Thêm tiền và Trừ tiền.\n" +
                    "<Mặc định mod = 40,000>\n" +
                    "Không làm gì nếu không dùng phím tắt trong thành phố.\n" +
                    "Muốn tự động thì bật Tiền tự động."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "Phím tắt để <Thêm tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "Thêm tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Trừ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "Phím tắt để <Trừ tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "Trừ tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "Tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "Khi bật [ ✓ ], City Watchdog kiểm tra số dư thành phố.\n" +
                    "- Nếu số dư <dưới ngưỡng>, hệ thống thêm đủ tiền để đạt ngưỡng.\n" +
                    "- Luôn thêm ít nhất Số tiền tự động đã chọn.\n" +
                    "- Nếu chỉ thỉnh thoảng cần tiền, nên dùng phím tắt thủ công (<[> hoặc <]>)."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "Ngưỡng tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "Nếu Tiền tự động đang bật và số dư thấp hơn giá trị này,\n" +
                    "tiền sẽ được thêm cho đến khi đạt ít nhất ngưỡng này."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "Số tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "Số tiền tối thiểu được thêm mỗi lần Tiền tự động chạy.\n" +
                    "Nếu cần nhiều hơn để đạt ngưỡng, City Watchdog sẽ thêm số lớn hơn."
                },

                // --------------------------------------------------------------------
                // City Start tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "Bộ đổi Tiền vô hạn" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Sao lưu thành phố TRƯỚC>.\n" +
                    "Đổi thành phố bắt đầu bằng Tiền vô hạn thành thành phố bình thường.\n" +
                    "Bật mục này mở nút <[Đổi bản lưu Tiền vô hạn]> khi thành phố đã tải là kiểu <Tiền vô hạn>.\n" +
                    "City Watchdog không thể hoàn tác.\n" +
                    "Thành phố bình thường không cần dùng."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "Đổi thành phố Tiền vô hạn thành bình thường" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Dành cho thành phố bắt đầu bằng <Tiền vô hạn>.\n" +
                    "Khi thành phố đó đang tải, đổi bản lưu sang ngân sách tiền giới hạn bình thường.\n" +
                    "Nút sẽ <tắt/xám> trừ khi thành phố là kiểu <Tiền vô hạn>\n" +
                    "và <Bộ đổi Tiền vô hạn> đang BẬT [ ✓ ].\n" +
                    "Hãy sao lưu và tự chịu rủi ro; City Watchdog không hoàn tác."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "Đổi thành phố này từ Tiền vô hạn sang tiền giới hạn bình thường?\n" +
                    "Sao lưu TRƯỚC; City Watchdog không hoàn tác.\n" +
                    "Bạn chắc chứ?"
                },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Tên mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "Tên hiển thị của mod này." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "Phiên bản" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "Phiên bản mod hiện tại." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "Mở trang Paradox Mods của tác giả." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "Báo cáo chẩn đoán" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<Không cần cho chơi bình thường.>\n" +
                    "Cho người thử nghiệm và kiểm tra sau cập nhật trò chơi: ghi báo cáo vào <Logs/CityWatchdog.log>\n" +
                    "so sánh các thông báo trực tiếp của trò chơi với biểu tượng do Watchdog điều khiển."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "Mở nhật ký" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "Mở </Logs/CityWatchdog.log> nếu có.\n" +
                    "Nếu thiếu, mở thư mục Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
