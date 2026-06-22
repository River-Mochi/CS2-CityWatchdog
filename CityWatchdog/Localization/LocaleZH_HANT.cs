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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "動作"},
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "金錢"},
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "快捷鍵"},
                { m_Settings.GetOptionTabLocaleID(Setting.About), "關於"},
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "偵錯"},

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用說明"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新城市啟動設定"},
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "城市內資訊檢視器"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金錢"},
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "存檔轉換"},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診斷"},
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "快捷鍵"},

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "顯示說明"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "顯示或隱藏下方使用說明。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<显示开关>\n" +
                    "1. [i] 按钮：隐藏/显示游戏所有悬停提示，包括建筑、市民、工具和底部菜单图标。\n" +
                    "2. 道路名称按钮：隐藏/显示道路名称。快捷键：\\。\n" +
                    "3. 道路箭头按钮：强制显示/隐藏单行道箭头（也会隐藏道路名称）。\n" +
                    "4. CWD 标题栏图标：显示/隐藏 City Watchdog 面板提示。\n" +
                    "\n" +
                    "<通知图标>\n" +
                    "1. 点击左上角 City Watchdog 按钮，或按 Shift+N 打开面板。\n" +
                    "2. 排序按钮可切换升序/降序。\n" +
                    "3. Toggle All 可快速全关/全开，也可以展开分组单独调整。\n" +
                    "4. 这里只隐藏图标，不会修复城市本身的问题。\n" +
                    "\n" +
                    "<金钱工具>\n" +
                    "1. 添加或减少金钱：默认快捷键为 [ 和 ]。\n" +
                    "2. 自动加钱会在城市余额低于你设定的限制时加钱。\n" +
                    "3. 无限金钱存档转换只用于以无限金钱开局的城市，且<不可撤销>。\n" +
                    "\n" +
                    "<底部菜单提示>\n" +
                    "Money View 会给金钱和人口工具栏添加趋势值，并在悬停时显示详情。\n" +
                    "\n" +
                    "<自定义里程碑>\n" +
                    "加载或开始城市前，在“新城市启动设置”里设置初始金钱和里程碑。"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), ""},

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换通知图标"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<快捷键> 与游戏内 <[TOGGLE ALL]> 按钮相同。\n" +
                    "立即显示或隐藏所有列出的通知图标。"},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即显示/隐藏所有通知图标"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打开/关闭通知面板"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<快捷键> 在城市中打开或关闭\n" +
                    "<通知面板>。\n" +
                    "效果与点击左上角按钮相同。"},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打开/关闭通知面板"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隐藏/显示道路名称"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<快捷键> 立即隐藏或显示原版道路名称。\n" +
                    "与 City Watchdog 面板工具栏中的道路名称图标相同。"},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隐藏/显示道路名称"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "禁用所有鼠标悬停提示"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<快捷键> 隐藏或显示游戏所有悬停提示：建筑、市民、工具和底部菜单图标。\n" +
                    "<City Watchdog 自己的金钱/人口弹窗仍会显示>；它们由 Money View 控制。\n" +
                    "与 City Watchdog 面板中的 [i] 图标相同。"},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隐藏/显示所有游戏悬停提示"},

                // --------------------------------------------------------------------
                // Actions tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金錢"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "设置新建<有限金钱>城市或首次加载城市的起始余额，\n" +
                    "应用后会重置为 Game Default。\n" +
                    "如果城市已加载，此项会变灰。\n" +
                    "请在开始/加载城市前设置；之后可用<金钱快捷键金额>或<自动加钱>。"},
                { m_Settings.GetOptionLocaleID("GameDefault"), "遊戲預設"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑選擇器"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在<加载或开始城市前>启用，可在城市加载后立即解锁所选里程碑。\n" +
                    "城市已加载时不能开启，但如果误开可以关闭。\n" +
                    "如果忘记设置，请重启游戏并在进入城市前选择。\n" +
                    "City Watchdog 不能撤销已保存到城市中的里程碑变化；需要时请使用较早存档。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "选择下次加载城市时要解锁的里程碑。\n" +
                    "只能在未加载城市时，并且启用 [里程碑选择器] [ ✓ ] 后调整。"},

                // --------------------------------------------------------------------
                // Money tab - In City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "顯示金錢 + 人口 ToolTips"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<建议启用>\n" +
                    "底部游戏菜单：在金钱和人口箭头旁显示趋势值。\n" +
                    "这是轻量的工具栏悬停功能，<仅显示>；\n" +
                    "比打开游戏信息面板更省时间，也可能更流畅。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 频率"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "选择底部工具栏趋势文字显示每小时还是每月的金钱和人口数值。\n" +
                    "每月模式使用预算收入减支出，并使用 24 小时人口预测。"},
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)"},
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金钱提示样式"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "选择金钱悬停提示显示多少详情。\n" +
                    "Compact = 首次安装默认。\n" +
                    "<Mini> 只显示 /mo 和 /h 的 2 个净值。\n" +
                    "<Compact> 会缩短大数字（15.21M 而不是 15,212,318）。\n" +
                    "<Full data> 显示长数字和 Total 字段。"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金钱字体大小"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "调整 Money View 提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<Mod 默认 = 120%>\n" +
                    "把鼠标悬停在底部金钱上。\n" +
                    "适合觉得小提示难以阅读的玩家。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字体大小"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "调整人口提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<Mod 默认 = 120%>\n" +
                    "把鼠标悬停在底部人口上。"},

                // --------------------------------------------------------------------
                // Money tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金錢快捷鍵金額"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "此金额用于添加金钱和减少金钱快捷键。\n" +
                    "<Mod 默认 = 40,000>\n" +
                    "除非在城市中使用快捷键，否则不会生效。\n" +
                    "如需自动金钱，请启用自动加钱。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "增加金錢"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "在城市中<添加金钱>的快捷键。"},
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "增加金錢"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "減少金錢"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "在城市中<减少金钱>的快捷键。"},
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "減少金錢"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動加錢"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "启用 [ ✓ ] 后，City Watchdog 会在城市加载时检查余额。\n" +
                    "- 如果余额<低于阈值>，\n" +
                    "  会添加所选自动金额。\n" +
                    "- 建议需要时用手动快捷键 (<[> 或 <]>)，但这里也提供自动选项。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動金錢門檻"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果自动加钱已启用且城市余额低于此值，\n" +
                    "会添加所选自动金额。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動金錢金額"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自动触发时添加的金额。\n" +
                    "请选择足够高的值，让城市安全高于阈值。"},

                // --------------------------------------------------------------------
                // Money tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限金錢轉換器"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<请先备份城市>。\n" +
                    "将以无限金钱开局的城市转换为正常的有限金钱预算城市。\n" +
                    "当加载的城市是<无限金钱>类型时，启用此项会解锁 <[转换无限金钱存档]> 按钮。\n" +
                    "City Watchdog 无法撤销此转换。\n" +
                    "普通城市不需要此功能。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "將無限金錢城市轉換為普通城市"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "用于以<无限金钱>开始的城市。\n" +
                    "该城市加载时，会把存档转换为正常有限金钱预算。\n" +
                    "按钮会<禁用/变灰>，除非加载的城市是<无限金钱>类型\n" +
                    "且<无限金钱转换器>为 ON [ ✓ ]。\n" +
                    "请先备份并自行承担风险；City Watchdog 无法撤销。"},

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "要把此城市从无限金钱转换为普通有限金钱吗？\n" +
                    "请先备份；City Watchdog 无法撤销。\n" +
                    "确定吗？"},

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod 名稱"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此 mod 的显示名称。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "当前 mod 版本。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打开作者的 Paradox Mods 页面。"},

                // --------------------------------------------------------------------
                // Debug tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "偵錯報告到日誌"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<普通游玩不需要。>\n" +
                    "用于测试和游戏补丁后检查：写入 <Logs/CityWatchdog.log> 报告，\n" +
                    "比较游戏实时通知 prefab 与 Watchdog 当前控制的通知图标。"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟日誌"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "如果存在，则打开 </Logs/CityWatchdog.log>。\n" +
                    "如果日志文件不存在，则打开 Logs/ 文件夹。"},
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
