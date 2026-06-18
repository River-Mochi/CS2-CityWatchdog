// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleZH_HANT.cs
// Purpose: Traditional Chinese (zh-HANT) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "快速鍵" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "關於" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "偵錯" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "資訊檢視器" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金錢" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "里程碑" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "存檔轉換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "存檔轉換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診斷" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "診斷" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "懸停时顯示詳情" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "懸停時顯示詳情" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "金錢视图頻率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "選擇底部工具列趨勢文字顯示金錢和人口的小時值还是月度值。\n月度金錢使用预算收入减支出，人口使用 24 小時預測。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小時 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金錢提示樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "選擇滑鼠懸停金錢时提示中顯示多少詳細資訊。\n精簡 = 首次安裝預設值。\n<迷你> 只顯示 /mo 和 /h 的 2 个净值。\n<精簡> 会縮短大數值（15.21M 而不是 15,212,318）。\n<完整資料> 顯示长數值和總計欄位。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "精簡" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整資料" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金錢字型大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "調整 Money View 提示数字的<字型大小>。\n遊戲預設 = 100%\n<模組預設 = 120%>\n将滑鼠懸停在畫面底部的金錢上。\n为觉得游戏小提示难以看清的玩家而新增。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字型大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "調整人口提示数字的<字型大小>。\n遊戲預設 = 100%\n<模組預設 = 120%>\n将滑鼠懸停在畫面底部的人口上。" },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金錢快速鍵金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "将此金額用于新增金錢和減少金錢快速鍵。\n<模組預設 = 40,000>\n除非你在城市中使用快速鍵新增/減少金錢，否则不會執行任何操作。\n如需自動金錢，请啟用自動新增金錢選項。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "新增金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市中<新增金錢>的快速鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "新增金錢" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "減少金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市中<減少金錢>的快速鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "減少金錢" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動新增金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "啟用 [ ✓ ] 后，City Watchdog 会在城市載入时检查城市餘額。\n- 如果餘額<低於閾值>，\n  就会新增所選的自動金額。\n- 建議按需使用快速鍵（<[> 或 <]>）手动加钱，而不是使用此自動選項；但如果你需要，它也在这里。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動金錢閾值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "如果啟用了自動新增金錢且城市餘額低於此值，\n则新增所選的自動金額。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動金錢金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "每次触发自動新增金錢时新增的金額。\n请選擇足够高的值，让城市安全地回到閾值以上。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "设置新的<有限金錢>城市或第一个載入城市的起始餘額，\n套用后重設为游戏預設值。\n如果城市已经載入，此项会灰色顯示。\n在開始/載入城市前设置 → 套用一次 → 然后使用<金錢快速鍵金額>或<自動新增金錢>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏預設值" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "遊戲預設值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<快速鍵>執行与游戏内 <[TOGGLE ALL]> 圖示按鈕相同的操作。\n立即顯示或隐藏所有列出的城市通知圖示。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即顯示/隐藏所有通知圖示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "開啟/關閉通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<快速鍵>用于在城市中開啟或關閉\n<通知面板>。\n与点击左上角圖示開啟完整面板相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "開啟/關閉通知面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隐藏/顯示道路名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隱藏/顯示道路名稱" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隐藏/顯示道路名稱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "隱藏/顯示道路名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "關閉游戏的懸停提示——包括在建築/市民/工具上跟随光标的提示，以及游戏 UI 按鈕上的小彈出視窗（頂部栏名稱、原版按鈕等）。\n<City Watchdog 自己的的金錢/人口彈出視窗保持开启>；它们由上方的 Money View 選項控制。\n与在城市中点击 City Watchdog 面板上的 [i] 圖示相同。" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑選擇器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "在載入或開始城市前啟用，可在城市載入后立即解鎖所選里程碑。\n城市已載入时不能开启，但如果误开了，可以将其關閉。\nCity Watchdog 无法復原已经儲存进城市的里程碑变化；如有需要，请使用較早的存档。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "選擇下次城市載入时要解鎖的里程碑等級。\n只能在未載入城市时調整，并且只有在 [里程碑選擇器] 已啟用 [ ✓ ] 后才能調整。" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限金錢轉換器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<请先備份城市>。\n将以無限金錢開始的城市转换为具有一般金錢挑戰的正常城市。\n当載入的城市是<無限金錢>類型时，啟用此项会解鎖 <[转换無限金錢存档]> 按鈕。\nCity Watchdog 无法復原此转换。\n如果你有一般城市，不必担心；不需要此功能。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将無限金錢存档城市转换为一般" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "适用于以<無限金錢>開始的城市。\n在该城市載入时，将存檔轉換为一般有限金錢预算，让城市重新拥有一般金錢挑戰。\n按鈕会<停用/灰色顯示>，除非載入的城市是<無限金錢>類型，\n并且<無限金錢轉換器>为 ON [ ✓ ]。\n请制作備份存档，并自行自行承擔風險；City Watchdog 无法復原此转换。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将此城市从無限金錢转换为一般有限金錢？\n请先儲存備份；City Watchdog 无法復原。\n確定嗎？" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "模组名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此模组的顯示名稱。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "目前模组版本。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "開啟作者的 Paradox Mods 頁面。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "偵錯报告到記錄" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "偵錯報告到記錄" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟記錄" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "開啟記錄" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "顯示說明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "顯示說明" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<通知面板>\n1. 点击 City Watchdog 按鈕（左上角），或按 Shift+N 開啟面板。\n2. 按 ASC/DESC 排序。\n3. 使用 Toggle All 快速全部關閉/开启，或展开某个群組来變更特定圖示。\n4. 只顯示或隐藏圖示；不會修复城市的根本問題。\n\n<金錢工具>\n1. 新增或減少金錢：使用默认<金錢快速鍵金額> [ 或 ]。\n2. 自動新增金錢会在城市載入时监视预算，并在低於閾值时新增金錢。\n3. Money View 会在金錢和人口工具列以及滑鼠懸停提示中新增數值。\n4. 转换無限金錢存档仅适用于以無限金錢開始的城市，并且<不可逆>。\n\n<自訂里程碑>\n在載入或開始城市前，在選項菜单中设置初始金錢并選擇里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
