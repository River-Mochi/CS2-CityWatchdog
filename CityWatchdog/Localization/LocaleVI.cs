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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Hành động" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "Tiền và cột mốc" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Giới thiệu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "CÁCH DÙNG" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Thông báo" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Trình xem thông tin trong thành phố" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Thông báo Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "CÀI ĐẶT BẮT ĐẦU THÀNH PHỐ MỚI" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Tiền" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Chuyển đổi save tiền vô hạn" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "CHẨN ĐOÁN" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Hiện hướng dẫn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Hiện hoặc ẩn the usage instructions below." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Display toggles>\n1. [i] button: show/hide all game hover tooltips.\n2. Road Name button: show/hide road name labels. Phím tắt: \\.\n3. District Name button: show/hide district names without changing boundaries.\n4. Road Arrow button: show/hide one-way road arrows and also hide road names.\n5. CWD title icon: show/hide panel tooltips.\n\n<Notification alerts>\nMở City Watchdog with the top-left button or Shift+N. Sort, Toggle All, or expand sections to change specific icons. This hides icons only; it does not fix city problems.\n\n<Tiền helpers>\nUse [ and ] to add/subtract money. Automatic money adds money below your chosen limit. Tiền vô hạn conversion is not reversible.\n\n<Bottom menu tooltips>\nTiền View adds money and population trend values to the bottom toolbar.\n\n<Custom milestone>\nSet Tiền ban đầu and milestones before loading or starting a city." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bật/tắt biểu tượng thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<Phím tắt> for the same action as the in-game <[TOGGLE ALL]> icon button.\nIt shows or hides all listed city notification icons instantly." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Hiện/ẩn ngay mọi biểu tượng thông báo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Mở/đóng bảng thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<Phím tắt> for opening or closing the\n<bảng thông báo> trong thành phố.\nWorks the same as clicking Top Left icon to open the full panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Mở/đóng bảng thông báo" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Bắt đầu dạng chỉ nút" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "Khi bật [ ✓ ], opening City Watchdog from the top-left button starts in the smaller buttons-only view.\nUse the title-bar arrow or the row-count button to expand the full panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<Phím tắt> to instantly hide or show the vanilla road name labels trong thành phố.\nSame as clicking the Road-Name icon in the City Watchdog panel toolbar." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "Ẩn/hiện tên đường" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "Tắt mọi tooltip khi rê chuột" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<Phím tắt> to instantly hide or show ALL game hover tooltips — buildings, cims, tools, and bottom menu icons.\n<City Watchdog's own money/population popups stay on>; those are controlled by the Tiền View option above.\nSame as clicking the [i] icon on the City Watchdog panel inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "Ẩn/hiện mọi tooltip của game" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Hiện tooltip tiền + dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Recommend Enable>\nBottom game menu: Shows trend values with the game's bottom toolbar <money and population arrows>.\nThis is a lightweight hover over toolbar feature <display only>;\nSaves time and possible better performance than opening game's Info view panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Tần suất Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "Chọn whether the bottom-toolbar trend text shows hourly or monthly values for money and population.\nMonthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Theo giờ (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Theo tháng (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Kiểu tooltip tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "Chọn how much detail appears in the money hover tooltip.\nGọn = default on first install.\n<Mini> shows only 2 Net values for /mo and /h.\n<Gọn> shortens large values (15.21M instead of 15,212,318).\n<Dữ liệu đầy đủ> shows long values and Total fields." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Gọn" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dữ liệu đầy đủ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Cỡ chữ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Adjusts <font size> of Tiền View tooltip numbers.\nMặc định của game = 100%\n<Mặc định của mod = 120%>\nHover over Tiền at bottom of the screen.\nRequested by players who have hard time seeing smaller tooltips in the game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Cỡ chữ dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Adjusts <font size> of population tooltip numbers.\nMặc định của game = 100%\n<Mặc định của mod = 120%>\nHover over Population at bottom of the screen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "Hiện một HUD nhỏ trong thành phố with the most important notification counts.\nUse it as a quick alert strip without opening the full City Watchdog panel.\nClicking an icon jumps to one matching problem spot.\nKeep clicking the same icon to rotate through matching spots, then back to the first one." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Cấu hình đề xuất" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Applies a recommended Mini HUD setup:\nYêu thích, 5 icons, vertical, draggable, hide zero alerts, glass style off.\nKéo được vertical preset starts near the top-right side.\nStarter Blue-Star Yêu thích: Not enough electricity, Electricity bottleneck, Battery depleted, Electric cable not connected, Power line not connected, Not enough water, Backed up sewer, Water pipe not connected, Sewer pipe not connected, Abandoned, High rent, Traffic jam, Road required, No pedestrian access, Lack of Labor, Water damage, On fire, Burned down, Garbage piling up, Traffic accident, Crime scene, Pathfinding failed, No vehicles.\nChange Sao xanhs anytime in the City Watchdog city panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Chế độ Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "Chọn which notification rows the Mini HUD uses.\n**Top active** alerts shows the highest current counts.\n**Yêu thích** includes all rows marked with **Sao xanh** in the main City Watchdog panel.\nYou can pick as many favorites as you want,\nbut Mini HUD still shows only the top 5 or top 10 current counts from that **favorites blue-star** list." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "Cảnh báo hoạt động nhiều nhất" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "Yêu thích" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Số biểu tượng Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "Chọn how many notification icons the Mini HUD can show at once." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Hướng Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "Chọn whether Mini HUD icons are arranged in a row or a column." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "Ngang" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "Dọc" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Vị trí Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "Chọn where the Mini HUD appears.\nKéo được lets you move it trong thành phố UI." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "Trên giữa" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "Trên phải" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "Kéo được" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "Ẩn cảnh báo bằng 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "Khi bật [ ✓ ], the Mini HUD hides notification rows with a count of 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "Kiểu kính" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)), "Adds a soft glass-style background behind the Mini HUD for readability." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Tiền ban đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Sets the starting balance for a new <limited money> city or the first loaded city,\nthen resets to Mặc định của game after it applies.\nThis is grayed out if a city is already loaded.\nSet this before starting/loading a city. It applies once, then use <Số tiền phím tắt> or <Tự động thêm tiền> afterward." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định của game" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Chọn cột mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Enable <before loading or starting a city> to unlock a chosen milestone immediately after the city loads.\n- Cannot be turned ON after a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n- If you forgot and loaded a city, just restart the game, and pick milestone before entering a city.\n- Mod không thể hoàn tác milestone changes already saved into a city; use an earlier save if needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Cột mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Pick a milestone level to unlock on the next city load.\nThis is <only adjustable outside a loaded city>, and only after [Chọn cột mốc] is enabled [ ✓ ].\nIf the city is already at or past the milestone selected, then nothing will happen.\nA change only happens if the milestone selected here is higher than what the city has." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Số tiền phím tắt" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Use this amount with the Thêm tiền and Trừ tiền hotkeys.\n<Mặc định của mod = 40,000>\nThis does nothing unless you use the hotkey to add/subtract money (trong thành phố).\nFor automated money, enable the Tự động thêm tiền option." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Phím tắt to <Thêm tiền> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Thêm tiền" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Trừ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Phím tắt to <Trừ tiền> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Trừ tiền" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Tự động thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Khi bật [ ✓ ], City Watchdog checks the city balance while a city is loaded.\n- If the balance is <below the threshold>, \n  it adds the selected automatic amount.\n- Recommend to use Manual money with hotkey (<[> or <]>) as needed  instead of this automated option, but this is here if you want it." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Ngưỡng tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "If Tự động thêm tiền is enabled and the city balance falls below this value,\nAdd the selected automatic amount." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Amount added each time Tự động thêm tiền triggers.\nChọn a value high enough to bring the city safely above the threshold." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Bộ chuyển đổi tiền vô hạn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<Hãy sao lưu thành phố trước>.\nConverts a city that started as Tiền vô hạn to a normal city with regular money challenges.\nEnabling this unlocks the <[Convert Tiền vô hạn Save]> button when the loaded city is <Tiền vô hạn> type.\nCity Watchdog không thể hoàn tác this conversion.\nIf you have normal cities, do not worry about this; it is not needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Chuyển thành phố tiền vô hạn sang bình thường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "For cities started with <Tiền vô hạn>.\nWhile that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\nButton is <disabled/greyed-out> unless the loaded city is an <Tiền vô hạn> type\nand <Bộ chuyển đổi tiền vô hạn> is ON [ ✓ ].\nMake a backup save, and use at your own risk; City Watchdog không thể hoàn tác this conversion." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert this city from Tiền vô hạn to normal limited money?\nSave a backup FIRST; City Watchdog không thể hoàn tác this.\nAre you sure?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Tên mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Phiên bản" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Mở the author's Paradox Mods page." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Ghi báo cáo debug vào log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Not needed for normal gameplay.>\nFor testers and post game-patch checks: writes a <Logs/CityWatchdog.log> report\ncomparing live game notification prefabs with the notification icons Watchdog currently controls." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Mở log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Mởs </Logs/CityWatchdog.log> if it exists.\nIf the log file is missing, opens the Logs/ folder instead." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
