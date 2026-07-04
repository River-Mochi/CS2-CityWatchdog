// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleZH_HANT.cs
// Purpose: Traditional Chinese (zh-HANT) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleZH_HANT(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "金錢與里程碑" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "關於" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用說明" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "城市資訊檢視器" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini HUD 通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新城市開始設定" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金錢" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "轉換無限金錢存檔" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診斷" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "顯示說明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "顯示或隱藏 the usage instructions below." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Display toggles>\n1. [i] button: show/hide all game hover tooltips.\n2. Road Name button: show/hide road name labels. 快捷鍵: \\.\n3. District Name button: show/hide district names without changing boundaries.\n4. Road Arrow button: show/hide one-way road arrows and also hide road names.\n5. CWD title icon: show/hide panel tooltips.\n\n<Notification alerts>\n開啟 City Watchdog with the top-left button or Shift+N. Sort, Toggle All, or expand sections to change specific icons. This hides icons only; it does not fix city problems.\n\n<金錢 helpers>\nUse [ and ] to add/subtract money. Automatic money adds money below your chosen limit. 無限金錢 conversion is not reversible.\n\n<Bottom menu tooltips>\n金錢 View adds money and population trend values to the bottom toolbar.\n\n<Custom milestone>\nSet 初始資金 and milestones before loading or starting a city." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切換通知圖示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<快捷鍵> for the same action as the in-game <[TOGGLE ALL]> icon button.\nIt shows or hides all listed city notification icons instantly." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即顯示/隱藏所有通知圖示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "開啟/關閉通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<快捷鍵> for opening or closing the\n<通知面板> 在城市中.\nWorks the same as clicking Top Left icon to open the full panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "開啟/關閉通知面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "以僅按鈕模式開始" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "啟用時 [ ✓ ], opening City Watchdog from the top-left button starts in the smaller buttons-only view.\nUse the title-bar arrow or the row-count button to expand the full panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隱藏/顯示道路名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<快捷鍵> to instantly hide or show the vanilla road name labels 在城市中.\nSame as clicking the Road-Name icon in the City Watchdog panel toolbar." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隱藏/顯示道路名稱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "停用所有滑鼠懸停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<快捷鍵> to instantly hide or show ALL game hover tooltips — buildings, cims, tools, and bottom menu icons.\n<City Watchdog's own money/population popups stay on>; those are controlled by the 金錢 View option above.\nSame as clicking the [i] icon on the City Watchdog panel inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隱藏/顯示所有遊戲懸停提示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "顯示金錢 + 人口提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Recommend Enable>\nBottom game menu: Shows trend values with the game's bottom toolbar <money and population arrows>.\nThis is a lightweight hover over toolbar feature <display only>;\nSaves time and possible better performance than opening game's Info view panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 頻率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "選擇 whether the bottom-toolbar trend text shows hourly or monthly values for money and population.\nMonthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小時 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金錢提示樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "選擇 how much detail appears in the money hover tooltip.\n精簡 = default on first install.\n<Mini> shows only 2 Net values for /mo and /h.\n<精簡> shortens large values (15.21M instead of 15,212,318).\n<完整資料> shows long values and Total fields." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "精簡" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整資料" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金錢字體大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Adjusts <font size> of 金錢 View tooltip numbers.\n遊戲預設 = 100%\n<模組預設 = 120%>\nHover over 金錢 at bottom of the screen.\nRequested by players who have hard time seeing smaller tooltips in the game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字體大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Adjusts <font size> of population tooltip numbers.\n遊戲預設 = 100%\n<模組預設 = 120%>\nHover over Population at bottom of the screen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "顯示一個小型城市 HUD with the most important notification counts.\nUse it as a quick alert strip without opening the full City Watchdog panel.\nClicking an icon jumps to one matching problem spot.\nKeep clicking the same icon to rotate through matching spots, then back to the first one." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "推薦預設" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Applies a recommended Mini HUD setup:\nFavorites, 5 icons, horizontal, top center, 100% size, dark panel.\nZero-count alerts stay visible.\nAdd/remove **Blue Star** favorites anytime in the expanded Watchdog panel.\nStarter set Blue-Star favorites are included with **[Recommended]**." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD 模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "選擇 which notification rows the Mini HUD uses.\n**Top active** alerts shows the highest current counts.\n**最愛** includes all rows marked with **藍星** in the main City Watchdog panel.\nYou can pick as many favorites as you want,\nbut Mini HUD still shows only the top 5 or top 10 current counts from that **favorites blue-star** list." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "最高活躍警報" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "最愛" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Mini HUD 圖示數量" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "選擇 how many notification icons the Mini HUD can show at once." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Mini HUD size" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "Scale Mini HUD icons and numbers.\n90% = compact. 100% = default. Increase up to 130% for better visibility." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Mini HUD 方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "選擇 whether Mini HUD icons are arranged in a row or a column." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "水平" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "垂直" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Mini HUD 位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "選擇 where the Mini HUD appears.\n可拖曳 lets you move it 在城市中 UI." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "頂部置中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上角" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖曳" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Mini HUD style" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "Choose the Mini HUD background style." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "Dark panel" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "Glass panel" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Mini HUD opacity" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Adjusts Mini HUD background transparency.\nLower values are more transparent. Higher values are more solid." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "隱藏零計數警報" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "啟用時 [ ✓ ], the Mini HUD hides notification rows with a count of 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Sets the starting balance for a new <limited money> city or the first loaded city,\nthen resets to 遊戲預設 after it applies.\nThis is grayed out if a city is already loaded.\nSet this before starting/loading a city. It applies once, then use <金錢快捷鍵金額> or <自動增加金錢> afterward." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "遊戲預設" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑選擇器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Enable <before loading or starting a city> to unlock a chosen milestone immediately after the city loads.\n- Cannot be turned ON after a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n- If you forgot and loaded a city, just restart the game, and pick milestone before entering a city.\n- Mod 無法復原 milestone changes already saved into a city; use an earlier save if needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Pick a milestone level to unlock on the next city load.\nThis is <only adjustable outside a loaded city>, and only after [里程碑選擇器] is enabled [ ✓ ].\nIf the city is already at or past the milestone selected, then nothing will happen.\nA change only happens if the milestone selected here is higher than what the city has." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金錢快捷鍵金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Use this amount with the 增加金錢 and 扣除金錢 hotkeys.\n<模組預設 = 40,000>\nThis does nothing unless you use the hotkey to add/subtract money (在城市中).\nFor automated money, enable the 自動增加金錢 option." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "增加金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "快捷鍵 to <增加金錢> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "增加金錢" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "扣除金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "快捷鍵 to <扣除金錢> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "扣除金錢" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動增加金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "啟用時 [ ✓ ], City Watchdog checks the city balance while a city is loaded.\n- If the balance is <below the threshold>, \n  it adds the selected automatic amount.\n- Recommend to use Manual money with hotkey (<[> or <]>) as needed  instead of this automated option, but this is here if you want it." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動金錢門檻" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "If 自動增加金錢 is enabled and the city balance falls below this value,\nAdd the selected automatic amount." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Amount added each time 自動增加金錢 triggers.\n選擇 a value high enough to bring the city safely above the threshold." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限金錢轉換器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<請先備份城市>.\nConverts a city that started as 無限金錢 to a normal city with regular money challenges.\nEnabling this unlocks the <[Convert 無限金錢 Save]> button when the loaded city is <無限金錢> type.\nCity Watchdog 無法復原 this conversion.\nIf you have normal cities, do not worry about this; it is not needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "將無限金錢城市轉換為普通城市" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "For cities started with <無限金錢>.\nWhile that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\nButton is <disabled/greyed-out> unless the loaded city is an <無限金錢> type\nand <無限金錢轉換器> is ON [ ✓ ].\nMake a backup save, and use at your own risk; City Watchdog 無法復原 this conversion." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert this city from 無限金錢 to normal limited money?\nSave a backup FIRST; City Watchdog 無法復原 this.\nAre you sure?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "模組名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "開啟 the author's Paradox Mods page." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "將除錯報告寫入記錄" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Not needed for normal gameplay.>\nFor testers and post game-patch checks: writes a <Logs/CityWatchdog.log> report\ncomparing live game notification prefabs with the notification icons Watchdog currently controls." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟記錄" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "開啟s </Logs/CityWatchdog.log> if it exists.\nIf the log file is missing, opens the Logs/ folder instead." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
