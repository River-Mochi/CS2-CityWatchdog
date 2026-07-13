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
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "迷你 HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "资金-里程碑" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "关于" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "用法" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "城内信息显示" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "迷你 HUD 通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新城市开始设置" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "资金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "转换无限资金存档" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "诊断" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "显示说明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "显示或隐藏下方使用说明。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<显示开关>\n" +
                    "1. [i] 按钮：隐藏/显示游戏中所有悬停提示，包括建筑、市民、工具、底部菜单图标。\n" +
                    "2. 道路名称按钮：隐藏/显示道路名称标签。快捷键：\\。\n" +
                    "3. 区域名称按钮：隐藏/显示区域名称，不改变区域边界。\n" +
                    "4. 道路箭头按钮：强制开/关单行道箭头（也会隐藏道路名称）。\n" +
                    "5. CWD 标题栏图标：显示/隐藏 City Watchdog 面板提示。\n" +
                    "\n" +
                    "<通知警报>\n" +
                    "1. 点击左上角 City Watchdog 按钮，或按 Shift+N 打开面板。\n" +
                    "2. 排序按钮：升序/降序。\n" +
                    "3. 全部切换可快速全部关/开，也可展开分组单独修改。\n" +
                    "4. 只显示或隐藏图标；不会修复城市问题本身。\n" +
                    "\n" +
                    "<资金辅助>\n" +
                    "1. 增加或扣除资金：使用 <资金快捷键金额>，默认键为 [ 和 ]。\n" +
                    "2. 自动加钱会在城市资金低于你设置的限制时加钱。\n" +
                    "3. 转换无限资金存档只适用于以无限资金开始的城市，且<不可撤销>。\n" +
                    "\n" +
                    "<底部菜单提示>\n" +
                    "资金显示会在资金和人口工具栏添加趋势值，并在悬停时显示更多细节。\n" +
                    "\n" +
                    "<自定义里程碑>\n" +
                    "在加载或开始城市前，到 资金-里程碑 > 新城市开始设置 中设置初始资金和里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换通知图标" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<快捷键>，与游戏内 <[全部切换]> 图标按钮相同。\n" +
                    "立即显示或隐藏所有列出的城市通知图标。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即显示/隐藏所有通知图标" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打开/关闭通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<快捷键>，用于在城市中打开或关闭\n" +
                    "<通知面板>。\n" +
                    "效果与点击左上角图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打开/关闭通知面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "仅按钮模式启动" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "启用 [ ✓ ] 后，从左上角按钮打开 City Watchdog 时，会先显示较小的仅按钮视图。\n" +
                    "使用标题栏箭头或行数按钮展开完整面板。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隐藏/显示道路名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<快捷键>，立即隐藏或显示游戏本体的道路名称标签。\n" +
                    "与 City Watchdog 面板工具栏中的道路名称图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隐藏/显示道路名称" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "禁用所有鼠标悬停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<快捷键>，立即隐藏或显示游戏中所有悬停提示——建筑、市民、工具和底部菜单图标。\n" +
                    "<City Watchdog 自己的资金/人口弹窗仍会显示>；它们由上方资金显示选项控制。\n" +
                    "与 City Watchdog 面板中的 [i] 图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隐藏/显示所有游戏悬停提示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "显示资金 + 人口提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<建议启用>\n" +
                    "底部游戏菜单：在工具栏的 <资金和人口箭头> 旁显示趋势值。\n" +
                    "这是轻量悬停功能，<仅显示>；\n" +
                    "比打开游戏信息面板更省时，也可能更流畅。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "资金显示频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "选择底部工具栏趋势文字显示资金和人口的每小时值或每月值。\n" +
                    "每月使用预算收入减支出，并使用 24 小时人口预测。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "资金提示样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "选择资金悬停提示显示多少细节。\n" +
                    "紧凑 = 首次安装默认。\n" +
                    "<迷你> 只显示 /mo 和 /h 的 2 个净值。\n" +
                    "<紧凑> 会缩短大数字（15.21M 而不是 15,212,318）。\n" +
                    "<完整数据> 显示长数字和总计。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "紧凑" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "资金字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "调整资金显示提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<Mod 默认 = 120%>\n" +
                    "将鼠标悬停在屏幕底部的资金上。\n" +
                    "适合觉得游戏小提示难读的玩家。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "调整人口提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<Mod 默认 = 120%>\n" +
                    "将鼠标悬停在屏幕底部的人口上。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "迷你 HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "显示一个小型城市 HUD，包含最重要的通知计数。\n" +
                    "可作为快速警报条使用，无需打开完整 City Watchdog 面板。\n" +
                    "点击图标会跳转到一个匹配的问题地点。\n" +
                    "继续点击同一图标会轮换匹配地点，然后回到第一个。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "快速开始设置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "应用推荐的迷你 HUD 设置：\n" +
                    "收藏、5 个图标、横向、顶部居中、100% 大小、深色面板。\n" +
                    "零计数警报仍会显示。\n" +
                    "可随时在展开的 Watchdog 面板中添加/移除 **蓝星** 收藏。\n" +
                    "**蓝星** 起始收藏包含在 **[推荐]** 中。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "迷你 HUD 模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "选择迷你 HUD 使用哪些通知行。\n" +
                    "**最高活跃** 显示当前计数最高的警报。\n" +
                    "**收藏** 包含 City Watchdog 主面板中所有标记 **蓝星** 的行。\n" +
                    "你可以选择任意数量的收藏，\n" +
                    "但迷你 HUD 只会从该 **蓝星收藏** 列表中显示当前计数最高的 5 或 10 个。" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "最高活跃警报" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "收藏" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "图标数量" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "选择迷你 HUD 一次可显示多少通知图标。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "图标大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "缩放迷你 HUD 图标和数字。\n" +
                    "90% = 紧凑。100% = 默认。最高 130%，方便看清。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "选择迷你 HUD 图标按行还是按列排列。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "横向" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "纵向" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD 位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "选择迷你 HUD 出现的位置。\n" +
                    "可拖动允许你在城市界面中移动它。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "顶部居中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖动" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "深色或玻璃样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "选择迷你 HUD 背景样式。\n" +
                    "玻璃面板会从透明变为发白雾状；不会变暗。\n" +
                    "使用深色面板可获得更暗的游戏风格 HUD。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "深色面板" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "玻璃面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "背景不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "调整迷你 HUD 背景透明度。\n" +
                    "数值低 = 更透明。数值高 = 更实。\n" +
                    "玻璃会更白/更雾。深色会更实/更暗。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "隐藏零警报" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "启用 [ ✓ ] 后，迷你 HUD 会隐藏计数为 0 的通知行。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始资金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "设置新的<有限资金>城市或首次加载城市的起始余额，\n" +
                    "应用后恢复为游戏默认。\n" +
                    "如果城市已经加载，此项会变灰。\n" +
                    "请在开始/加载城市前设置。它只应用一次，之后使用 <资金快捷键金额> 或 <自动加钱>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑选择器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "在<加载或开始城市前>启用，可在城市加载后立即解锁所选里程碑。\n" +
                    "- 城市加载后不能开启，但如果误开可关闭。\n" +
                    "- 如果忘记并已加载城市，请重启游戏，并在进入城市前选择里程碑。\n" +
                    "- Mod 不能撤销已保存到城市中的里程碑变化；需要时请使用更早的存档。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "选择下一次城市加载时要解锁的里程碑等级。\n" +
                    "只能在<没有加载城市时>调整，并且必须先启用 [里程碑选择器] [ ✓ ]。\n" +
                    "如果城市已经达到或超过所选里程碑，则不会发生任何事。\n" +
                    "只有所选里程碑高于当前进度时才会变化。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "资金快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "此金额用于增加资金和扣除资金快捷键。\n" +
                    "<Mod 默认 = 40,000>\n" +
                    "除非你在城市中使用快捷键，否则不会生效。\n" +
                    "如需自动资金，请启用自动加钱选项。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "增加资金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市中<增加资金>的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "增加资金" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "扣除资金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市中<扣除资金>的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "扣除资金" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自动加钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "启用 [ ✓ ] 后，City Watchdog 会在城市加载时检查城市余额。\n" +
                    "- 如果余额<低于阈值>，\n" +
                    "  它会增加所选自动金额。\n" +
                    "- 建议按需使用手动资金快捷键 (<[> 或 <]>)\n" +
                    "  而不是自动选项，但此选项可用。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自动资金阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "如果自动加钱已启用，并且城市余额低于此值，\n" +
                    "会增加所选自动金额。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自动金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "每次自动加钱触发时添加的金额。\n" +
                    "选择足够高的值，让城市安全高于阈值。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "无限资金转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<请先备份城市>。\n" +
                    "将以无限资金开始的城市转换为普通、有资金挑战的城市。\n" +
                    "当加载的城市是 <无限资金> 类型时，启用此项可解锁 <[转换无限资金存档]> 按钮。\n" +
                    "City Watchdog 无法撤销此转换。\n" +
                    "如果你是普通城市，不需要担心这个选项。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将无限资金城市转换为普通" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "适用于以 <无限资金> 开始的城市。\n" +
                    "加载该城市时，会把存档转换为普通有限资金预算。\n" +
                    "除非加载的城市是 <无限资金> 类型\n" +
                    "且 <无限资金转换器> 已开启 [ ✓ ]，否则按钮会 <禁用/变灰>。\n" +
                    "请先备份并自行承担风险；City Watchdog 无法撤销。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "要将此城市从无限资金转换为普通有限资金吗？\n" +
                    "请先保存备份；City Watchdog 无法撤销。\n" +
                    "确定吗？" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod 名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此 Mod 的显示名称。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "当前 Mod 版本。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打开作者的 Paradox Mods 页面。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "调试报告写入日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<普通游玩不需要。>\n" +
                    "供测试者和游戏补丁后检查使用：将报告写入 <Logs/CityWatchdog.log>，\n" +
                    "比较游戏实际通知预制件与 Watchdog 当前控制的通知图标。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "如果存在，则打开 </Logs/CityWatchdog.log>。\n" +
                    "如果日志文件缺失，则改为打开 Logs/ 文件夹。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
