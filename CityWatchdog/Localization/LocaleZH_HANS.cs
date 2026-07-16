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
            string title = Mod.ModName + " (城市守望者)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "迷你HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "金钱-里程碑" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "关于" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "城内信息" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "迷你HUD警报" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新城市开局设置" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金钱" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "转换无限金钱存档" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "诊断" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "显示说明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "显示或隐藏下方使用说明。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. 点击城市左上角爪印图标，或按 Shift+N，打开主面板。\n" +
                    "<显示开关>\n" +
                    "1. 标题栏图标：显示/隐藏 City Watchdog 工具提示。\n" +
                    "\n" +
                    "2. **[i]** 按钮：隐藏/显示游戏 <全部> 悬停提示：建筑、市民、工具、底部菜单图标。\n" +
                    "3. 道路按钮：隐藏/显示道路名称。快捷键：\\.\n" +
                    "4. 区域按钮：隐藏/显示区域名称。\n" +
                    "5. 道路箭头按钮：强制单行道箭头 ON/OFF（也会隐藏道路名称）。\n" +
                    "\n" +
                    "<通知警报>\n" +
                    "1. 排序按钮循环 A→Z、Z→A、仅活动列表。\n" +
                    "2. <[0/62]> = 图标 ON/总数。点击展开/折叠所有行。\n" +
                    "3a. [全部切换] 立即关闭/开启所有警报图标。\n" +
                    "3b. 只隐藏图标；不会修复城市问题。\n" +
                    "\n" +
                    "<金钱辅助>\n" +
                    "1. 添加 / 减少金钱：使用 <金钱快捷键金额> 的默认键 <[ 或 ]>。\n" +
                    "2. 自动金钱会在城市低于你设定的限制时加钱。\n" +
                    "3. 转换无限金钱存档只适用于以无限金钱开局的城市，并且 <不可撤销>。\n" +
                    "\n" +
                    "<底部菜单提示>\n" +
                    "金钱视图 会在悬停金钱或人口时添加趋势等额外信息。\n" +
                    "\n" +
                    "<自定义里程碑>\n" +
                    "金钱-里程碑 > 新城市开局设置，可在加载/开始城市前设置初始金钱或里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换警报图标" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<快捷键>，作用同游戏内 <[全部切换]> 按钮。\n" +
                    "立即显示或隐藏所有列出的城市警报图标。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即显示/隐藏所有警报图标" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打开/关闭警报面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<快捷键> 用于打开或关闭\n" +
                    "城市中的 <警报面板>。\n" +
                    "和点击左上角图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打开/关闭警报面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "仅按钮启动" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "启用 [ ✓ ] 时，City Watchdog 会先以小型仅按钮视图打开。\n" +
                    "用标题栏箭头或行数按钮打开完整面板。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隐藏/显示道路名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<快捷键> 立即隐藏/显示游戏原本道路名称。\n" +
                    "和 City Watchdog 面板的道路名称图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隐藏/显示道路名称" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "禁用全部悬停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<快捷键> 隐藏/显示游戏全部悬停提示：建筑、市民、工具、底部图标。\n" +
                    "<City Watchdog 的金钱/人口弹窗会保留>；由 金钱视图 控制。\n" +
                    "和 City Watchdog 面板内的 [i] 图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隐藏/显示游戏悬停提示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "金钱趋势 + 人口提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<推荐开启>\n" +
                    "底部菜单：在 <金钱和人口箭头> 上显示趋势值。\n" +
                    "轻量悬停功能 <仅显示>；\n" +
                    "省时间，也可能比打开游戏信息面板更轻。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "金钱视图 频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "选择底部趋势文字显示每小时或每月数值。\n" +
                    "每月使用收入减支出，以及24小时人口预测。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金钱提示样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "选择金钱悬停提示显示多少细节。\n" +
                    "紧凑 = 首次安装默认。\n" +
                    "<迷你> 只显示 /mo 和 /h 的2个净值。\n" +
                    "<紧凑> 缩短大数字（如 15.21M）。\n" +
                    "<完整数据> 显示长数值和合计。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "紧凑" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金钱字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "调整 金钱视图 数字的 <字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<Mod 默认 = 120%>\n" +
                    "悬停屏幕底部的金钱。\n" +
                    "适合看不清小提示的玩家。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "调整人口数字的 <字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<Mod 默认 = 120%>\n" +
                    "悬停屏幕底部的人口。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "迷你HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "显示小型城市HUD，包含重要警报计数。\n" +
                    "不用打开完整面板，也能快速看警报。\n" +
                    "点击图标会跳到一个对应问题点。\n" +
                    "继续点击同一图标可轮换问题点，再回到第一个。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "点击：快速开始" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "应用迷你面板的<快速开始>：\n" +
                    "包含一组 **蓝色星星收藏**初始设置。\n" +
                    "带 **蓝色星星** 的通知，如果总数量排进前 5 或前 10，就可以显示在迷你面板中。\n" +
                    "在展开的 Watchdog 面板中添加/移除 **蓝色星星**。\n" +
                    "套装包含：收藏、5 个图标、竖排、可拖动、100% 大小、深色面板、隐藏数量为 0 的图标。"
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "迷你面板模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "选择迷你面板使用哪些警报行。\n" +
                    "**最活跃**显示当前数量最高的警报。\n" +
                    "**收藏**使用 City Watchdog 主面板中标记为 **蓝色星星** 的行。\n" +
                    "你可以选择任意数量的收藏，\n" +
                    "但迷你面板只显示该 **蓝色星星** 列表中的前 5 或前 10 个。"
                  },

                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "最活跃警报" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "收藏" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "图标数量" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "选择迷你HUD最多显示多少通知图标。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "图标大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "缩放迷你HUD图标和数字。\n" +
                    "90% = 紧凑。100% = 默认。可增至130%更清楚。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "选择横排或竖排。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "横向" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "纵向" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "选择迷你HUD出现的位置。\n" +
                    "可拖动让你在城市界面中移动它。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "顶部居中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖动" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "深色或玻璃样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "选择迷你HUD背景样式。\n" +
                    "玻璃会从透明变成雾白；不会变暗。\n" +
                    "想要更暗的游戏风HUD请用深色面板。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "深色面板" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "玻璃面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "背景不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "调整迷你HUD背景透明度。\n" +
                    "数值低 = 更透明。数值高 = 更实。\n" +
                    "玻璃会更白。深色会更实/更暗。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "隐藏0警报" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "启用 [ ✓ ] 时，迷你HUD隐藏计数为0的行。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "设置新 <有限金钱> 城市或第一个加载城市的起始余额，\n" +
                    "应用后会重置为游戏默认。\n" +
                    "如果城市已加载则变灰。\n" +
                    "在加载/开始前设置。之后使用 <金钱快捷键金额> 或 <自动金钱>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑选择器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在 <加载或开始前> 启用，可在城市加载后立即解锁指定里程碑。\n" +
                    "- 城市加载后不能开启，但误开时可以关闭。\n" +
                    "- 忘了就重启游戏，并在进城前选择。\n" +
                    "- Mod 不能撤销已经存入城市的里程碑变化；需要时用旧存档。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "选择下次加载城市时解锁的里程碑。\n" +
                    "仅在 <未加载城市时> 且 [里程碑选择器] 启用 [ ✓ ] 后可调。\n" +
                    "如果城市已达到或超过所选里程碑，则不会发生变化。\n" +
                    "只有所选里程碑更高时才会改变。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金钱快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "此金额用于添加金钱和减少金钱快捷键。\n" +
                    "<Mod 默认 = 40,000>\n" +
                    "除非在城市内使用快捷键，否则不会生效。\n" +
                    "想自动加钱请启用自动金钱。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "添加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "城市内 <添加金钱> 的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "添加金钱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "减少金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "城市内 <减少金钱> 的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "减少金钱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自动金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "启用 [ ✓ ] 后，City Watchdog 会检查城市余额。\n" +
                    "- 如果余额 <低于阈值>，\n" +
                    "  会添加所选金额。\n" +
                    "- 更推荐按需要用手动快捷键 (<[> 或 <]>)，\n" +
                    "  但也提供自动选项。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自动金钱阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果启用且城市余额低于此值，\n" +
                    "会添加所选金额。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自动金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自动触发时添加的金额。\n" +
                    "请选择足够让城市安全高于阈值的金额。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "无限金钱转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<先备份城市>。\n" +
                    "把以无限金钱开局的城市转换为普通城市。\n" +
                    "启用后，如果加载城市是 <无限金钱> 类型，会解锁 <[转换无限金钱存档]> 按钮。\n" +
                    "City Watchdog 无法撤销此转换。\n" +
                    "普通城市不需要此功能。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "把无限金钱城市转为普通" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "用于以 <无限金钱> 开局的城市。\n" +
                    "加载该城市时，把存档转换为普通有限金钱预算。\n" +
                    "按钮会 <禁用/变灰>，除非加载城市是 <无限金钱> 类型，\n" +
                    "且 <无限金钱转换器> 为 ON [ ✓ ]。\n" +
                    "请先备份并自行承担风险；City Watchdog 无法撤销。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "要把此城市从无限金钱转换为普通有限金钱吗？\n" +
                    "先保存备份；City Watchdog 无法撤销。\n" +
                    "确定吗？" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此Mod的显示名称。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "当前Mod版本。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打开作者的 Paradox Mods 页面。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "调试报告到日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<正常游玩不需要。>\n" +
                    "供测试和补丁检查：写入 <Logs/CityWatchdog.log> 报告，\n" +
                    "比较游戏实时通知Prefab与 Watchdog 当前控制的图标。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "如果存在，打开 </Logs/CityWatchdog.log>。\n" +
                    "如果日志文件缺失，则打开 Logs/ 文件夹。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
