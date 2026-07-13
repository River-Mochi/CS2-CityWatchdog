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
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "迷你 HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "資金-里程碑" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "關於" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "用法" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "城內信息顯示" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "迷你 HUD 通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新城市開始設定" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "資金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "轉換無限資金存檔" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診斷" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "顯示說明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "顯示或隱藏下方使用說明。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<顯示開关>\n" +
                    "1. [i] 按鈕：隱藏/顯示遊戲中所有懸停提示，包括建築、市民、工具、底部選單圖示。\n" +
                    "2. 道路名稱按鈕：隱藏/顯示道路名稱標籤。快捷鍵：\\。\n" +
                    "3. 區域名稱按鈕：隱藏/顯示區域名稱，不改變區域邊界。\n" +
                    "4. 道路箭头按鈕：強制開/关单列道箭头（也会隱藏道路名稱）。\n" +
                    "5. CWD 標題列圖示：顯示/隱藏 City Watchdog 面板提示。\n" +
                    "\n" +
                    "<通知警報>\n" +
                    "1. 點擊左上角 City Watchdog 按鈕，或按 Shift+N 打開面板。\n" +
                    "2. 排序按鈕：升序/降序。\n" +
                    "3. 全部切换可快速全部关/開，也可展開分组單獨修改。\n" +
                    "4. 只顯示或隱藏圖示；不会修复城市問題本身。\n" +
                    "\n" +
                    "<資金輔助>\n" +
                    "1. 增加或扣除資金：使用 <資金快捷鍵金額>，預設键为 [ 和 ]。\n" +
                    "2. 自動加钱会在城市資金低於你設定的限制时加钱。\n" +
                    "3. 轉換無限資金存檔只適用于以無限資金開始的城市，且<不可撤銷>。\n" +
                    "\n" +
                    "<底部選單提示>\n" +
                    "資金顯示会在資金和人口工具列添加趋势值，并在懸停时顯示更多細節。\n" +
                    "\n" +
                    "<自訂里程碑>\n" +
                    "在載入或開始城市前，到 資金-里程碑 > 新城市開始設定 中設定初始資金和里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换通知圖示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<快捷鍵>，与遊戲内 <[全部切换]> 圖示按鈕相同。\n" +
                    "立即顯示或隱藏所有列出的城市通知圖示。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即顯示/隱藏所有通知圖示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打開/关闭通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<快捷鍵>，用于在城市中打開或关闭\n" +
                    "<通知面板>。\n" +
                    "效果与點擊左上角圖示相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打開/关闭通知面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "仅按鈕模式启动" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "啟用 [ ✓ ] 后，从左上角按鈕打開 City Watchdog 时，会先顯示較小的仅按鈕檢視。\n" +
                    "使用標題列箭头或列数按鈕展開完整面板。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隱藏/顯示道路名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<快捷鍵>，立即隱藏或顯示遊戲本体的道路名稱標籤。\n" +
                    "与 City Watchdog 面板工具列中的道路名稱圖示相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隱藏/顯示道路名稱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "停用所有鼠标懸停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<快捷鍵>，立即隱藏或顯示遊戲中所有懸停提示——建築、市民、工具和底部選單圖示。\n" +
                    "<City Watchdog 自己的資金/人口弹窗仍会顯示>；它们由上方資金顯示選項控制。\n" +
                    "与 City Watchdog 面板中的 [i] 圖示相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隱藏/顯示所有遊戲懸停提示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "顯示資金 + 人口提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<建议啟用>\n" +
                    "底部遊戲選單：在工具列的 <資金和人口箭头> 旁顯示趋势值。\n" +
                    "这是轻量懸停功能，<仅顯示>；\n" +
                    "比打開遊戲信息面板更省时，也可能更流畅。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "資金顯示频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "選擇底部工具列趋势文字顯示資金和人口的每小時值或每月值。\n" +
                    "每月使用預算收入减支出，并使用 24 小時人口預測。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小時 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "資金提示樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "選擇資金懸停提示顯示多少細節。\n" +
                    "精簡 = 首次安装預設。\n" +
                    "<迷你> 只顯示 /mo 和 /h 的 2 个净值。\n" +
                    "<精簡> 会缩短大數字（15.21M 而不是 15,212,318）。\n" +
                    "<完整数据> 顯示长數字和總計。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "精簡" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "資金字型大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "調整資金顯示提示數字的<字型大小>。\n" +
                    "遊戲預設 = 100%\n" +
                    "<Mod 預設 = 120%>\n" +
                    "将鼠标懸停在螢幕底部的資金上。\n" +
                    "适合觉得遊戲小提示难读的玩家。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字型大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "調整人口提示數字的<字型大小>。\n" +
                    "遊戲預設 = 100%\n" +
                    "<Mod 預設 = 120%>\n" +
                    "将鼠标懸停在螢幕底部的人口上。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "迷你 HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "顯示一个小型城市 HUD，包含最重要的通知計數。\n" +
                    "可作为快速警報列使用，無需打開完整 City Watchdog 面板。\n" +
                    "點擊圖示会跳轉到一个匹配的問題地點。\n" +
                    "繼續點擊同一圖示会輪換匹配地點，然后回到第一个。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "快速開始設定" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "套用推薦的迷你 HUD 設定：\n" +
                    "收藏、5 个圖示、橫向、頂部置中、100% 大小、深色面板。\n" +
                    "零計數警報仍会顯示。\n" +
                    "可随时在展開的 Watchdog 面板中添加/移除 **藍星** 收藏。\n" +
                    "**藍星** 起始收藏包含在 **[推薦]** 中。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "迷你 HUD 模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "選擇迷你 HUD 使用哪些通知列。\n" +
                    "**最高活跃** 顯示目前計數最高的警報。\n" +
                    "**收藏** 包含 City Watchdog 主面板中所有标记 **藍星** 的列。\n" +
                    "你可以選擇任意数量的收藏，\n" +
                    "但迷你 HUD 只会从该 **藍星收藏** 列表中顯示目前計數最高的 5 或 10 个。" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "最高活跃警報" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "收藏" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "圖示数量" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "選擇迷你 HUD 一次可顯示多少通知圖示。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "圖示大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "缩放迷你 HUD 圖示和數字。\n" +
                    "90% = 精簡。100% = 預設。最高 130%，方便看清。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "選擇迷你 HUD 圖示按列还是按列排列。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "橫向" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "直向" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD 位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "選擇迷你 HUD 出现的位置。\n" +
                    "可拖曳允许你在城市介面中移动它。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "頂部置中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖曳" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "深色或玻璃樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "選擇迷你 HUD 背景樣式。\n" +
                    "玻璃面板会从透明變为泛白霧状；不会變暗。\n" +
                    "使用深色面板可获得更暗的遊戲风格 HUD。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "深色面板" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "玻璃面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "背景不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "調整迷你 HUD 背景透明度。\n" +
                    "數值低 = 更透明。數值高 = 更实。\n" +
                    "玻璃会更白/更霧。深色会更实/更暗。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "隱藏零警報" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "啟用 [ ✓ ] 后，迷你 HUD 会隱藏計數为 0 的通知列。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "設定新的<有限資金>城市或首次載入城市的起始餘額，\n" +
                    "套用后還原为遊戲預設。\n" +
                    "如果城市已經載入，此項会變灰。\n" +
                    "请在開始/載入城市前設定。它只套用一次，之后使用 <資金快捷鍵金額> 或 <自動加钱>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "遊戲預設" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑選擇器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "在<載入或開始城市前>啟用，可在城市載入后立即解锁所选里程碑。\n" +
                    "- 城市載入后不能開启，但如果误開可关闭。\n" +
                    "- 如果忘记并已載入城市，请重启遊戲，并在进入城市前選擇里程碑。\n" +
                    "- Mod 不能撤銷已保存到城市中的里程碑變化；需要时请使用更早的存檔。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "選擇下一次城市載入时要解锁的里程碑等級。\n" +
                    "只能在<没有載入城市时>調整，并且必须先啟用 [里程碑選擇器] [ ✓ ]。\n" +
                    "如果城市已經达到或超过所选里程碑，则不会发生任何事。\n" +
                    "只有所选里程碑高于目前進度时才会變化。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "資金快捷鍵金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "此金額用于增加資金和扣除資金快捷鍵。\n" +
                    "<Mod 預設 = 40,000>\n" +
                    "除非你在城市中使用快捷鍵，否则不会生效。\n" +
                    "如需自動資金，请啟用自動加钱選項。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "增加資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市中<增加資金>的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "增加資金" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "扣除資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市中<扣除資金>的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "扣除資金" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動加钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "啟用 [ ✓ ] 后，City Watchdog 会在城市載入时检查城市餘額。\n" +
                    "- 如果餘額<低於門檻>，\n" +
                    "  它会增加所选自動金額。\n" +
                    "- 建议按需使用手动資金快捷鍵 (<[> 或 <]>)\n" +
                    "  而不是自動選項，但此選項可用。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動資金門檻" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "如果自動加钱已啟用，并且城市餘額低於此值，\n" +
                    "会增加所选自動金額。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "每次自動加钱触发时添加的金額。\n" +
                    "選擇足够高的值，让城市安全高于門檻。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限資金轉換器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<请先备份城市>。\n" +
                    "将以無限資金開始的城市轉換为普通、有資金挑战的城市。\n" +
                    "当載入的城市是 <無限資金> 類型时，啟用此項可解锁 <[轉換無限資金存檔]> 按鈕。\n" +
                    "City Watchdog 无法撤銷此轉換。\n" +
                    "如果你是普通城市，不需要担心这个選項。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将無限資金城市轉換为普通" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "適用于以 <無限資金> 開始的城市。\n" +
                    "載入该城市时，会把存檔轉換为普通有限資金預算。\n" +
                    "除非載入的城市是 <無限資金> 類型\n" +
                    "且 <無限資金轉換器> 已開启 [ ✓ ]，否则按鈕会 <停用/變灰>。\n" +
                    "请先备份并自列承擔風險；City Watchdog 无法撤銷。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "要将此城市从無限資金轉換为普通有限資金吗？\n" +
                    "请先保存备份；City Watchdog 无法撤銷。\n" +
                    "确定吗？" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod 名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此 Mod 的顯示名稱。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "目前 Mod 版本。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打開作者的 Paradox Mods 頁面。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "调试报告写入記錄" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<普通游玩不需要。>\n" +
                    "供测试者和遊戲补丁后检查使用：将报告写入 <Logs/CityWatchdog.log>，\n" +
                    "比较遊戲實際通知預製件与 Watchdog 目前控制的通知圖示。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打開記錄" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "如果存在，则打開 </Logs/CityWatchdog.log>。\n" +
                    "如果記錄檔案缺失，则改为打開 Logs/ 資料夾。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
