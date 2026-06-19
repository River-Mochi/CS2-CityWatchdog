// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

//
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
            string title = Mod.ModName + " (看門狗)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "快速鍵" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "關於" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "除錯" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "資訊檢視器" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金錢" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "里程碑" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "存檔轉換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "快速鍵" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診斷" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用說明" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "懸停時顯示詳細資料" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "在底部工具列原版的<金錢和人口箭頭>旁顯示數值趨勢。\n" +
                    "這是輕量的工具列懸停<僅顯示>功能；\n" +
                    "不會改變城市金錢或人口。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 頻率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "選擇底部工具列的趨勢文字顯示金錢和人口的每小時值還是每月值。\n" +
                    "每月金錢使用預算收入減支出，人口使用 24 小時預測。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小時 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金錢提示樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "選擇滑鼠懸停金錢時提示裡顯示多少細節。\n" +
                    "緊湊 = 首次安裝預設。\n" +
                    "<迷你> 只顯示 /mo 和 /h 的 2 個淨值。\n" +
                    "<緊湊> 縮短大數字（15.21M 而不是 15,212,318）。\n" +
                    "<完整資料> 顯示長數字和總計欄位。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "緊湊" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整資料" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金錢字體大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "調整 Money View 提示數字的<字體大小>。\n" +
                    "遊戲預設 = 100%\n" +
                    "<模組預設 = 120%>\n" +
                    "將滑鼠懸停在螢幕底部的金錢上。\n" +
                    "這是為看不清遊戲小提示的玩家加入的。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字體大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "調整人口提示數字的<字體大小>。\n" +
                    "遊戲預設 = 100%\n" +
                    "<模組預設 = 120%>\n" +
                    "將滑鼠懸停在螢幕底部的人口上。" },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金錢快速鍵金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "此金額用於添加金錢和減少金錢快速鍵。\n" +
                    "<模組預設 = 40,000>\n" +
                    "除非你在城市中使用快速鍵添加/減少金錢，否則不會生效。\n" +
                    "如需自動加錢，請啟用自動添加金錢選項。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "添加金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市中執行<添加金錢>的快速鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "添加金錢" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "減少金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市中執行<減少金錢>的快速鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "減少金錢" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動添加金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "啟用 [ ✓ ] 後，City Watchdog 會在城市載入時檢查城市餘額。\n" +
                    "- 如果餘額<低於閾值>，\n" +
                    "  就會添加所選的自動金額。\n" +
                    "- 建議需要時使用手動金錢快速鍵（<[> 或 <]>）  而不是這個自動選項，但如果你想用，它就在這裡。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動金錢閾值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果自動添加金錢已啟用，且城市餘額低於此值，\n" +
                    "就會添加所選的自動金額。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動金錢金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自動添加金錢觸發時添加的金額。\n" +
                    "請選擇足夠高的數值，讓城市安全回到閾值以上。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "設定新<有限金錢>城市或首次載入城市的起始餘額，\n" +
                    "套用後會重設為遊戲預設。\n" +
                    "如果城市已經載入，此項會變灰。\n" +
                    "在開始/載入城市前設定 → 套用一次 → 之後使用<金錢快速鍵金額>或<自動添加金錢>。" },

                { m_Settings.GetOptionLocaleID("GameDefault"), "遊戲預設" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切換通知圖示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "與遊戲內 <[TOGGLE ALL]> 圖示按鈕相同操作的<快速鍵>。\n" +
                    "可立即顯示或隱藏所有列出的城市通知圖示。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即顯示/隱藏所有通知圖示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "開啟/關閉通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "用於在城市中開啟或關閉\n" +
                    "<通知面板>的<快速鍵>。\n" +
                    "效果與點擊左上角圖示開啟完整面板相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "開啟/關閉通知面板" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隱藏/顯示道路名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<快速鍵>可立即隱藏或顯示城市中的原版道路名稱標籤。\n" +
                    "與點擊 City Watchdog 面板工具列中的道路名稱圖示相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隱藏/顯示道路名稱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "停用所有滑鼠懸停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)),
                    "關閉遊戲的懸停提示 — 包括跟隨游標出現在建築/市民/工具上的提示\n" +
                    " 以及遊戲 UI 按鈕上的小彈窗（頂部列名稱、原版按鈕等）。\n" +
                    "<City Watchdog 自己的金錢/人口彈窗會保持開啟>；它們由上面的 Money View 選項控制。\n" +
                    "與在城市中點擊 City Watchdog 面板裡的 [i] 圖示相同。" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑選擇器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在載入或開始城市前啟用，可在城市載入後立即解鎖所選里程碑。\n" +
                    "城市已載入時不能開啟，但如果誤開，可以關閉。\n" +
                    "City Watchdog 無法撤銷已經儲存到城市中的里程碑變更；需要時請使用較早存檔。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "選擇下次載入城市時要解鎖的里程碑等級。\n" +
                    "只能在沒有載入城市時調整，並且必須先啟用 [里程碑選擇器] [ ✓ ]。" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限金錢轉換器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<請先備份城市>。\n" +
                    "將以無限金錢開始的城市轉換為有正常金錢挑戰的普通城市。\n" +
                    "當載入的城市是<無限金錢>類型時，啟用此項會解鎖 <[轉換無限金錢存檔]> 按鈕。\n" +
                    "City Watchdog 無法撤銷此轉換。\n" +
                    "如果你的是普通城市，不用擔心；不需要使用它。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "將無限金錢城市轉換為普通城市" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "用於以<無限金錢>開始的城市。\n" +
                    "該城市載入時，此項會將存檔轉換為普通有限金錢預算，讓城市重新擁有正常金錢挑戰。\n" +
                    "除非載入的城市是<無限金錢>類型\n" +
                    "且<無限金錢轉換器>為 ON [ ✓ ]，否則按鈕會<停用/變灰>。\n" +
                    "請先備份存檔並自行承擔風險；City Watchdog 無法撤銷此轉換。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "要將此城市從無限金錢轉換為普通有限金錢嗎？\n" +
                    "請先備份；City Watchdog 無法撤銷此操作。\n" +
                    "確定嗎？" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "模組名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此模組的顯示名稱。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "目前模組版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "開啟作者的 Paradox Mods 頁面。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "除錯報告寫入記錄" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<正常遊戲不需要。>\n" +
                    "供測試者和遊戲更新後檢查使用：寫入 <Logs/CityWatchdog.log> 報告，\n" +
                    "比較即時遊戲通知 prefab 與 Watchdog 目前控制的通知圖示。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟記錄" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "如果存在，則開啟 </Logs/CityWatchdog.log>。\n" +
                    "如果記錄檔案缺失，則開啟 Logs/ 資料夾。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "顯示說明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "顯示或隱藏下面的使用說明。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<顯示開關>\n" +
                    "1. [i] 按鈕：隱藏/顯示所有遊戲懸停提示（建築、cims、工具）。\n" +
                    "2. 道路名稱按鈕：隱藏/顯示道路名稱標籤。快速鍵：\\。\n" +
                    "3. 道路箭頭按鈕：強制單行道箭頭開/關（也會隱藏道路名稱）。\n" +
                    "4. CWD 標題列圖示：顯示/隱藏 City Watchdog 面板提示。\n" +
                    "\n" +
                    "<通知警報>\n" +
                    "1. 點擊 City Watchdog 按鈕（左上角），或按 Shift+N，開啟面板。\n" +
                    "2. 排序按鈕用於升序/降序。\n" +
                    "3. Toggle All 可快速全部 Off/On，或展開某個分類修改特定圖示。\n" +
                    "4. 只顯示或隱藏圖示；不會修復城市本身的問題。\n" +
                    "\n" +
                    "<金錢工具>\n" +
                    "1. 添加或減少金錢：使用<金錢快速鍵金額>的預設按鍵 [ 和 ]。\n" +
                    "2. 自動添加金錢會在城市低於你設定的限制時加錢。\n" +
                    "3. 轉換無限金錢存檔只用於以無限金錢開始的城市，並且<不可逆>。\n" +
                    "\n" +
                    "<底部選單提示>\n" +
                    "Money View 會在金錢和人口工具列添加趨勢值，並在滑鼠懸停時顯示額外詳細資料。\n" +
                    "\n" +
                    "<自訂里程碑>\n" +
                    "在載入或開始城市前，到選項選單設定初始金錢並選擇里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
