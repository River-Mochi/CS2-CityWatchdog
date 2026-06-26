// <copyright file="LocaleZH_HANS.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleZH_HANS.cs
// Purpose: Simplified Chinese (zh-HANS) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleZH_HANS : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleZH_HANS(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "资金-里程碑" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "关于" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用说明" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "城市内信息查看器" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "迷你HUD通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新城市开始设置" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "资金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "转换无限资金存档" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "诊断" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "显示说明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "显示或隐藏下面的使用说明。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<显示开关>\n" +
                    "1. [i] 按钮：隐藏/显示游戏所有悬停提示，包括建筑、市民、工具和底部菜单图标。\n" +
                    "2. 道路名称按钮：隐藏/显示道路名称标签。快捷键：\\。\n" +
                    "3. 区域名称按钮：隐藏/显示区域名称标签，不改变区域边界。\n" +
                    "4. 道路箭头按钮：强制开/关单行道路箭头（也会隐藏道路名称）。\n" +
                    "5. CWD 标题栏图标：显示/隐藏 City Watchdog 面板提示。\n" +
                    "\n" +
                    "<通知警告>\n" +
                    "1. 点击左上角 City Watchdog 按钮，或按 Shift+N 打开面板。\n" +
                    "2. 升序/降序排序按钮。\n" +
                    "3. Toggle All 可快速全部关闭/开启，也可展开分组单独调整。\n" +
                    "4. 只显示或隐藏图标；不会修复城市问题本身。\n" +
                    "\n" +
                    "<资金工具>\n" +
                    "1. 增加或减少资金：使用 <资金快捷键金额>，默认按键为 [ 和 ]。\n" +
                    "2. 自动增加资金会在城市资金低于你设置的限制时添加资金。\n" +
                    "3. 转换无限资金存档仅适用于以无限资金创建的城市，且<不可撤销>。\n" +
                    "\n" +
                    "<底部菜单提示>\n" +
                    "Money View 会在资金和人口工具栏加入趋势值，并在悬停时显示更多细节。\n" +
                    "\n" +
                    "<自定义里程碑>\n" +
                    "在加载或开始城市前，在 资金-里程碑 > 新城市开始设置 中设置初始资金和里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换通知图标" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<快捷键> 与游戏内 <[TOGGLE ALL]> 按钮相同。\n" +
                    "立即显示或隐藏所有列出的通知图标。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即显示/隐藏所有通知图标" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打开/关闭通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<快捷键> 在城市中打开或关闭\n" +
                    "<通知面板>。\n" +
                    "效果与点击左上角按钮相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打开/关闭通知面板" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隐藏/显示道路名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<快捷键> 立即隐藏或显示原版道路名称。\n" +
                    "与 City Watchdog 面板工具栏中的道路名称图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隐藏/显示道路名称" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "禁用所有鼠标悬停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<快捷键> 隐藏或显示游戏所有悬停提示：建筑、市民、工具和底部菜单图标。\n" +
                    "<City Watchdog 自己的金钱/人口弹窗仍会显示>；它们由 Money View 控制。\n" +
                    "与 City Watchdog 面板中的 [i] 图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隐藏/显示所有游戏悬停提示" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "显示金钱 + 人口 ToolTips" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<建议启用>\n" +
                    "底部游戏菜单：在金钱和人口箭头旁显示趋势值。\n" +
                    "这是轻量的工具栏悬停功能，<仅显示>；\n" +
                    "比打开游戏信息面板更省时间，也可能更流畅。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "选择底部工具栏趋势文字显示每小时还是每月的金钱和人口数值。\n" +
                    "每月模式使用预算收入减支出，并使用 24 小时人口预测。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金钱提示样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "选择金钱悬停提示显示多少详情。\n" +
                    "Compact = 首次安装默认。\n" +
                    "<Mini> 只显示 /mo 和 /h 的 2 个净值。\n" +
                    "<Compact> 会缩短大数字（15.21M 而不是 15,212,318）。\n" +
                    "<Full data> 显示长数字和 Total 字段。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金钱字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "调整 Money View 提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<Mod 默认 = 120%>\n" +
                    "把鼠标悬停在底部金钱上。\n" +
                    "适合觉得小提示难以阅读的玩家。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "调整人口提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<Mod 默认 = 120%>\n" +
                    "把鼠标悬停在底部人口上。" },

                // --------------------------------------------------------------------
                // Actions tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "迷你HUD通知" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "在城市中显示一个小型 HUD，显示最重要的通知数量。\n" +
                    "可作为快速警告条使用，无需打开完整的 City Watchdog 面板。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "迷你HUD模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "选择迷你HUD使用哪些通知行。\n" +
                    "最活跃警告会显示当前数量最高的项目。\n" +
                    "收藏夹只显示你在 City Watchdog 面板中标星的行。" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "最活跃警告" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "收藏夹" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "迷你HUD图标数量" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "选择迷你HUD一次最多显示多少个通知图标。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "迷你HUD方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "选择迷你HUD图标按行排列还是按列排列。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "水平" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "垂直" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "迷你HUD位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "选择迷你HUD出现的位置。\n" +
                    "可拖动允许你在城市界面中移动它。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "顶部居中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "顶部右侧" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖动" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "隐藏零警告" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "启用 [ ✓ ] 后，迷你HUD会隐藏数量为0的通知行。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "玻璃风格" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)), "在迷你HUD后方加入柔和的玻璃风背景，以提高可读性。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "设置新建<有限金钱>城市或首次加载城市的起始余额，\n" +
                    "应用后会重置为 Game Default。\n" +
                    "如果城市已加载，此项会变灰。\n" +
                    "请在开始/加载城市前设置；之后可用<金钱快捷键金额>或<自动加钱>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑选择器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "在<加载或开始城市前>启用，可在城市加载后立即解锁所选里程碑。\n" +
                    "城市已加载时不能开启，但如果误开可以关闭。\n" +
                    "如果忘记设置，请重启游戏并在进入城市前选择。\n" +
                    "City Watchdog 不能撤销已保存到城市中的里程碑变化；需要时请使用较早存档。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "选择下次加载城市时要解锁的里程碑。\n" +
                    "只能在未加载城市时，并且启用 [里程碑选择器] [ ✓ ] 后调整。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金钱快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "此金额用于添加金钱和减少金钱快捷键。\n" +
                    "<Mod 默认 = 40,000>\n" +
                    "除非在城市中使用快捷键，否则不会生效。\n" +
                    "如需自动金钱，请启用自动加钱。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "添加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市中<添加金钱>的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "添加金钱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "减少金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市中<减少金钱>的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "减少金钱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自动加钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "启用 [ ✓ ] 后，City Watchdog 会在城市加载时检查余额。\n" +
                    "- 如果余额<低于阈值>，\n" +
                    "  会添加所选自动金额。\n" +
                    "- 建议需要时用手动快捷键 (<[> 或 <]>)，但这里也提供自动选项。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自动金钱阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "如果自动加钱已启用且城市余额低于此值，\n" +
                    "会添加所选自动金额。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自动金钱金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "每次自动触发时添加的金额。\n" +
                    "请选择足够高的值，让城市安全高于阈值。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "无限金钱转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<请先备份城市>。\n" +
                    "将以无限金钱开局的城市转换为正常的有限金钱预算城市。\n" +
                    "当加载的城市是<无限金钱>类型时，启用此项会解锁 <[转换无限金钱存档]> 按钮。\n" +
                    "City Watchdog 无法撤销此转换。\n" +
                    "普通城市不需要此功能。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将无限金钱城市转换为普通城市" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "用于以<无限金钱>开始的城市。\n" +
                    "该城市加载时，会把存档转换为正常有限金钱预算。\n" +
                    "按钮会<禁用/变灰>，除非加载的城市是<无限金钱>类型\n" +
                    "且<无限金钱转换器>为 ON [ ✓ ]。\n" +
                    "请先备份并自行承担风险；City Watchdog 无法撤销。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "要把此城市从无限金钱转换为普通有限金钱吗？\n" +
                    "请先备份；City Watchdog 无法撤销。\n" +
                    "确定吗？" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod 名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此 mod 的显示名称。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "当前 mod 版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打开作者的 Paradox Mods 页面。" },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "调试报告到日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<普通游玩不需要。>\n" +
                    "用于测试和游戏补丁后检查：写入 <Logs/CityWatchdog.log> 报告，\n" +
                    "比较游戏实时通知 prefab 与 Watchdog 当前控制的通知图标。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "如果存在，则打开 </Logs/CityWatchdog.log>。\n" +
                    "如果日志文件不存在，则打开 Logs/ 文件夹。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
