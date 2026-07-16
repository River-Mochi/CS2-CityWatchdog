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
            string title = Mod.ModName + " (城市守望者)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "迷你HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "金錢-里程碑" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "關於" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "城內資訊" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "迷你HUD警報" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新城市開局設定" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金錢" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "轉換無限金錢存檔" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診斷" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "顯示說明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "顯示或隱藏下方使用說明。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. 點擊城市左上角爪印圖示，或按 Shift+N，開啟主面板。\n" +
                    "<顯示开关>\n" +
                    "1. 標題列圖示：顯示/隱藏 City Watchdog 工具提示。\n" +
                    "\n" +
                    "2. **[i]** 按钮：隱藏/顯示游戏 <全部> 懸停提示：建築、市民、工具、底部選單圖示。\n" +
                    "3. 道路按钮：隱藏/顯示道路名稱。快捷鍵：\\.\n" +
                    "4. 區域按钮：隱藏/顯示區域名稱。\n" +
                    "5. 道路箭头按钮：强制單行道箭头 ON/OFF（也会隱藏道路名稱）。\n" +
                    "\n" +
                    "<通知警報>\n" +
                    "1. 排序按钮循環 A→Z、Z→A、僅啟用清單。\n" +
                    "2. <[0/63]> = 圖示 ON/總數。點擊展開/摺疊所有行。\n" +
                    "3a. [全部切换] 立即關閉/開啟所有警報圖示。\n" +
                    "3b. 只隱藏圖示；不会修復城市問題。\n" +
                    "\n" +
                    "<金錢輔助>\n" +
                    "1. 新增 / 減少金錢：使用 <金錢快捷鍵金額> 的預設键 <[ 或 ]>。\n" +
                    "2. 自動金錢会在城市低於你設定的限制时加钱。\n" +
                    "3. 轉換無限金錢存檔只適用于以無限金錢開局的城市，并且 <不可撤銷>。\n" +
                    "\n" +
                    "<底部選單提示>\n" +
                    "金錢視圖 会在懸停金錢或人口时新增趨勢等额外資訊。\n" +
                    "\n" +
                    "<自定义里程碑>\n" +
                    "金錢-里程碑 > 新城市開局設定，可在載入/開始城市前設定初始金錢或里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换警報圖示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<快捷鍵>，作用同游戏内 <[全部切换]> 按钮。\n" +
                    "立即顯示或隱藏所有列出的城市警報圖示。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即顯示/隱藏所有警報圖示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "開啟/關閉警報面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<快捷鍵> 用于開啟或關閉\n" +
                    "城市中的 <警報面板>。\n" +
                    "和點擊左上角圖示相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "開啟/關閉警報面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "僅按钮启动" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "啟用 [ ✓ ] 时，City Watchdog 会先以小型僅按钮视图開啟。\n" +
                    "用標題列箭头或行数按钮開啟完整面板。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隱藏/顯示道路名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<快捷鍵> 立即隱藏/顯示游戏原本道路名稱。\n" +
                    "和 City Watchdog 面板的道路名稱圖示相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隱藏/顯示道路名稱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "禁用全部懸停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<快捷鍵> 隱藏/顯示游戏全部懸停提示：建築、市民、工具、底部圖示。\n" +
                    "<City Watchdog 的金錢/人口彈窗会保留>；由 金錢視圖 控制。\n" +
                    "和 City Watchdog 面板内的 [i] 圖示相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隱藏/顯示游戏懸停提示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "金錢趨勢 + 人口提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<推荐開啟>\n" +
                    "底部選單：在 <金錢和人口箭头> 上顯示趨勢值。\n" +
                    "轻量懸停功能 <僅顯示>；\n" +
                    "省时间，也可能比開啟游戏資訊面板更轻。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "金錢視圖 頻率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "選擇底部趨勢文字顯示每小時或每月數值。\n" +
                    "每月使用收入减支出，以及24小时人口預測。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小時 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金錢提示樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "選擇金錢懸停提示顯示多少細節。\n" +
                    "精簡 = 首次安裝預設。\n" +
                    "<迷你> 只顯示 /mo 和 /h 的2个净值。\n" +
                    "<精簡> 缩短大数字（如 15.21M）。\n" +
                    "<完整資料> 顯示长數值和合计。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "精簡" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整資料" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金錢字體大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "調整 金錢視圖 数字的 <字體大小>。\n" +
                    "游戏預設 = 100%\n" +
                    "<Mod 預設 = 120%>\n" +
                    "懸停屏幕底部的金錢。\n" +
                    "適合看不清小提示的玩家。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字體大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "調整人口数字的 <字體大小>。\n" +
                    "游戏預設 = 100%\n" +
                    "<Mod 預設 = 120%>\n" +
                    "懸停屏幕底部的人口。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "迷你HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "顯示小型城市HUD，包含重要警報計數。\n" +
                    "不用開啟完整面板，也能快速看警報。\n" +
                    "點擊圖示会跳到一个對應問題点。\n" +
                    "繼續點擊同一圖示可輪換問題点，再回到第一个。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "點擊：快速開始" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "為 Mini HUD 套用<快速入門>:\n" +
                    "包含一組**入門 Blue Star 收藏**。\n" +
                    "在已展開的 Watchdog 面板中新增/移除 **Blue Star** 收藏。\n" +
                    "收藏，5 個圖示，垂直，可拖曳，100% 大小，深色面板。\n" +
                    "數量為 0 的警報會隱藏。\n"
                  },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "迷你HUD模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "選擇 Mini HUD 使用哪些通知列。\n" +
                    "**最活躍**顯示目前數量最高的警報。\n" +
                    "**收藏**使用 City Watchdog 主面板中標記為 **Blue Star** 的列。\n" +
                    "你可以選擇任意數量的收藏，\n" +
                    "但 Mini HUD 只顯示該 **Blue Star** 清單中的前 5 或前 10 個。"
                  },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "最活跃警報" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "收藏" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "圖示數量" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "選擇迷你HUD最多顯示多少通知圖示。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "圖示大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "缩放迷你HUD圖示和数字。\n" +
                    "90% = 精簡。100% = 預設。可增至130%更清楚。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "選擇橫排或直排。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "橫向" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "直向" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "選擇迷你HUD出現的位置。\n" +
                    "可拖曳让你在城市界面中移動它。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "顶部居中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖曳" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "深色或玻璃樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "選擇迷你HUD背景樣式。\n" +
                    "玻璃会从透明变成雾白；不会变暗。\n" +
                    "想要更暗的游戏风HUD请用深色面板。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "深色面板" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "玻璃面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "背景不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "調整迷你HUD背景透明度。\n" +
                    "數值低 = 更透明。數值高 = 更实。\n" +
                    "玻璃会更白。深色会更实/更暗。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "隱藏0警報" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "啟用 [ ✓ ] 时，迷你HUD隱藏計數为0的行。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "設定新 <有限金錢> 城市或第一个載入城市的起始餘額，\n" +
                    "套用后会重設为游戏預設。\n" +
                    "如果城市已載入则變灰。\n" +
                    "在載入/開始前設定。之后使用 <金錢快捷鍵金額> 或 <自動金錢>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏預設" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑選擇器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在 <載入或開始前> 啟用，可在城市載入后立即解鎖指定里程碑。\n" +
                    "- 城市載入后不能開啟，但误开时可以關閉。\n" +
                    "- 忘了就重启游戏，并在进城前選擇。\n" +
                    "- Mod 不能撤销已經存入城市的里程碑變化；需要时用舊存檔。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "選擇下次載入城市时解鎖的里程碑。\n" +
                    "僅在 <未載入城市时> 且 [里程碑選擇器] 啟用 [ ✓ ] 后可调。\n" +
                    "如果城市已达到或超过所选里程碑，则不会发生變化。\n" +
                    "只有所选里程碑更高时才会改变。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金錢快捷鍵金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "此金額用于新增金錢和減少金錢快捷鍵。\n" +
                    "<Mod 預設 = 40,000>\n" +
                    "除非在城市内使用快捷鍵，否则不会生效。\n" +
                    "想自動加钱请啟用自動金錢。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "新增金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "城市内 <新增金錢> 的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "新增金錢" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "減少金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "城市内 <減少金錢> 的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "減少金錢" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "啟用 [ ✓ ] 后，City Watchdog 会检查城市餘額。\n" +
                    "- 如果餘額 <低於門檻>，\n" +
                    "  会新增所选金額。\n" +
                    "- 更推荐按需要用手动快捷鍵 (<[> 或 <]>)，\n" +
                    "  但也提供自動选项。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動金錢門檻" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果啟用且城市餘額低於此值，\n" +
                    "会新增所选金額。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自動触发时新增的金額。\n" +
                    "请選擇足够让城市安全高于門檻的金額。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限金錢轉換器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<先備份城市>。\n" +
                    "把以無限金錢開局的城市轉換为普通城市。\n" +
                    "啟用后，如果載入城市是 <無限金錢> 类型，会解鎖 <[轉換無限金錢存檔]> 按钮。\n" +
                    "City Watchdog 无法撤销此轉換。\n" +
                    "普通城市不需要此功能。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "把無限金錢城市转为普通" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "用于以 <無限金錢> 開局的城市。\n" +
                    "載入该城市时，把存檔轉換为普通有限金錢预算。\n" +
                    "按钮会 <禁用/變灰>，除非載入城市是 <無限金錢> 类型，\n" +
                    "且 <無限金錢轉換器> 为 ON [ ✓ ]。\n" +
                    "请先備份并自行承担风险；City Watchdog 无法撤销。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "要把此城市从無限金錢轉換为普通有限金錢吗？\n" +
                    "先保存備份；City Watchdog 无法撤销。\n" +
                    "确定吗？" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此Mod的顯示名稱。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "目前Mod版本。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "開啟作者的 Paradox Mods 頁面。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "除錯報告到日誌" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<正常遊玩不需要。>\n" +
                    "供测试和补丁检查：写入 <Logs/CityWatchdog.log> 報告，\n" +
                    "比较游戏实时通知Prefab与 Watchdog 目前控制的圖示。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟日誌" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "如果存在，開啟 </Logs/CityWatchdog.log>。\n" +
                    "如果日誌文件缺失，则開啟 Logs/ 資料夾。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
