// <copyright file="LocaleZH_HANS.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANS.cs
// Purpose: Simplified Chinese (zh-HANS) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource


    public sealed class LocaleZH_HANS : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleZH_HANS(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (城市守望者)";

            Dictionary<string, string> entries = new()
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kActions), "操作" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMiniHudTab), "迷你HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMoneyTab), "城市开局" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kAbout), "关于" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutUsage), "使用" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kNotifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoneyViewGroup), "城内信息" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMiniHudGroup), "迷你HUD警报" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "新城市开局设置" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "金钱" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "转换无限金钱存档" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "诊断" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "显示说明" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "显示或隐藏下方使用说明。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. 点击城市左上角爪印图标，或按 Shift+N，打开主面板。\n" +
                    "<显示开关>\n" +
                    "1. 标题栏图标：显示/隐藏 City Watchdog 工具提示。\n" +
                    "\n" +
                    "2. **[i]** 按钮：隐藏/显示游戏 <全部> 悬停提示：建筑、市民、工具、底部菜单图标。\n" +
                    "3. 道路按钮：隐藏/显示道路名称。快捷键：\\.\n" +
                    "4. 区域按钮：隐藏/显示区域名称。\n" +
                    "5. 道路箭头按钮：显示/隐藏单行道箭头（也会隐藏道路名称）。\n" +
                    "\n" +
                    "<通知警报>\n" +
                    "1. 排序按钮循环 A→Z、Z→A、仅活动列表。\n" +
                    "2. <[0/62]> = 显示图标/总数。点击展开/折叠所有行。\n" +
                    "3a. [全部切换] 立即关闭/开启所有警报图标。\n" +
                    "3b. 只隐藏图标；不会修复城市问题。\n" +
                    "\n" +
                    "<金钱辅助>\n" +
                    "1. 添加 / 减少金钱：使用 <金钱快捷键金额> 的默认键 <[ 或 ]>。\n" +
                    "2. 自动金钱会在城市低于你设定的限制时加钱。\n" +
                    "3. 转换无限金钱存档只适用于以无限金钱开局的城市，并且 <不可撤销>。\n" +
                    "\n" +
                    "<底部菜单提示>\n" +
                    "金钱视图会在悬停金钱或人口时添加趋势等额外信息。\n" +
                    "\n" +
                    "<自定义里程碑>\n" +
                    "城市开局 > 新城市开局设置，可在加载/开始城市前设置初始金钱或里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "切换警报图标" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<快捷键>，作用同游戏内 <[全部切换]> 按钮。\n" +
                    "立即显示或隐藏所有列出的城市警报图标。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "立即显示/隐藏所有警报图标" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "打开/关闭警报面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<快捷键> 用于打开或关闭\n" +
                    "城市中的 <警报面板>。\n" +
                    "和点击左上角图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "打开/关闭警报面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "仅按钮启动" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "启用 [ ✓ ] 时，City Watchdog 会先以小型仅按钮视图打开。\n" +
                    "用标题栏箭头或行数按钮打开完整面板。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "隐藏/显示道路名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<快捷键> 立即隐藏/显示游戏原本道路名称。\n" +
                    "和 City Watchdog 面板的道路名称图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "隐藏/显示道路名称" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "禁用全部悬停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<快捷键> 隐藏/显示游戏全部悬停提示：建筑、市民、工具、底部图标。\n" +
                    "<City Watchdog 的金钱/人口弹窗会保留>；由金钱视图控制。\n" +
                    "和 City Watchdog 面板内的 [i] 图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "隐藏/显示游戏悬停提示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "放大游戏界面" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "启用 [ ✓ ] 后，<整个游戏界面>都会放大，包括游戏和模组面板。\n" +
                    "无需 <--developerMode> 即可使用游戏自带的<界面缩放>。\n" +
                    "会一直保持开启，直到你关闭；移除 City Watchdog 后也一样。\n" +
                    "功能与标题栏的缩放按钮相同。\n" +
                    "只调整文字：选项 > 界面 > <文字缩放>。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "主面板不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "调整主通知面板背景的透明度。\n" +
                    "数值越低越透明；数值越高越深、越不透明。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "金钱趋势 + 人口提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<推荐开启>\n" +
                    "底部菜单：在 <金钱和人口箭头> 上显示趋势值。\n" +
                    "轻量悬停功能 <仅显示>；\n" +
                    "省时间，也可能比打开游戏信息面板更轻。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "金钱视图频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "选择底部趋势文字显示每小时或每月数值。\n" +
                    "每月使用收入减支出，以及24小时人口预测。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "金钱提示样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "选择金钱悬停提示显示多少细节。\n" +
                    "紧凑 = 首次安装默认。\n" +
                    "<迷你> 只显示 /mo 和 /h 的2个净值。\n" +
                    "<紧凑> 缩短大数字（如 15.21M）。\n" +
                    "<完整数据> 显示长数值和合计。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "紧凑" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "金钱字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "调整金钱视图数字的 <字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<模组默认 = 120%>\n" +
                    "悬停屏幕底部的金钱。\n" +
                    "适合看不清小提示的玩家。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "人口字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "调整人口数字的 <字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<模组默认 = 120%>\n" +
                    "悬停屏幕底部的人口。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "迷你HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "显示小型城市HUD，包含重要警报计数。\n" +
                    "不用打开完整面板，也能快速看警报。\n" +
                    "点击图标会跳到一个对应问题点。\n" +
                    "继续点击同一图标可轮换问题点，再回到第一个。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "点击：快速开始" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "为 Mini HUD 应用<快速开始>设置：\n" +
                    "加入一组初始**蓝星收藏**。\n" +
                    "在收藏模式下，Mini HUD 会显示**蓝星**列表中当前数量最高的 5 或 10 项。\n" +
                    "可在 City Watchdog 面板中添加/移除**蓝星**。\n" +
                    "设置为：收藏、5 个图标、横向、可拖动、100%、深色面板，并隐藏数量为 0 的项目。\n" +
                    "随时再次运行快速开始即可重置这些设置。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "迷你面板模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "选择迷你面板使用哪些警报行。\n" +
                    "**数量最高**显示当前数量最高的警报。\n" +
                    "**收藏**使用 City Watchdog 主面板中标记为 **蓝色星星** 的行。\n" +
                    "你可以选择任意数量的收藏，\n" +
                    "但迷你面板只显示该 **蓝色星星** 列表中数量最高的 5 或 10 个。"
                  },

                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "数量最高警报" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "收藏" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "图标数量" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "选择迷你HUD最多显示多少通知图标。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "图标大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "缩放迷你HUD图标和数字。\n" +
                    "90% = 紧凑。100% = 默认。可增至130%更清楚。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "选择横排或竖排。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "横向" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "纵向" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "HUD位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "选择迷你HUD出现的位置。\n" +
                    "可拖动让你在城市界面中移动它。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "顶部居中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖动" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "深色或玻璃样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "选择迷你HUD背景样式。\n" +
                    "玻璃会从透明变成雾白；不会变暗。\n" +
                    "想要更暗的游戏风HUD请用深色面板。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "深色面板" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "玻璃面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "背景不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "调整迷你HUD背景透明度。\n" +
                    "数值低 = 更透明。数值高 = 更实。\n" +
                    "玻璃会更白。深色会更实/更暗。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "隐藏0警报" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "启用 [ ✓ ] 时，迷你HUD隐藏计数为0的行。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "初始金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "设置新 <有限金钱> 城市或第一个加载城市的起始余额，\n" +
                    "应用后会重置为游戏默认。\n" +
                    "如果城市已加载则变灰。\n" +
                    "在加载/开始前设置。之后使用 <金钱快捷键金额> 或 <自动金钱>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "里程碑选择器" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "在 <加载或开始前> 启用，可在城市加载后立即解锁指定里程碑。\n" +
                    "- 城市加载后不能开启，但误开时可以关闭。\n" +
                    "- 忘了就重启游戏，并在进城前选择。\n" +
                    "- 模组不能撤销已经存入城市的里程碑变化；需要时用旧存档。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "选择下次加载城市时解锁的里程碑。\n" +
                    "仅在 <未加载城市时> 且 [里程碑选择器] 启用 [ ✓ ] 后可调。\n" +
                    "如果城市已达到或超过所选里程碑，则不会发生变化。\n" +
                    "只有所选里程碑更高时才会改变。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "金钱快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "此金额用于添加金钱和减少金钱快捷键。\n" +
                    "<模组默认 = 40,000>\n" +
                    "除非在城市内使用快捷键，否则不会生效。\n" +
                    "想自动加钱请启用自动金钱。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "添加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "城市内 <添加金钱> 的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "添加金钱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "减少金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "城市内 <减少金钱> 的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "减少金钱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "自动金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "启用 [ ✓ ] 后，City Watchdog 会检查城市余额。\n" +
                    "- 如果余额 <低于阈值>，\n" +
                    "  会添加所选金额。\n" +
                    "- 更推荐按需要用手动快捷键 (<[> 或 <]>)，\n" +
                    "  但也提供自动选项。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "自动金钱阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "如果启用且城市余额低于此值，\n" +
                    "会添加所选金额。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "自动金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "每次自动触发时添加的金额。\n" +
                    "请选择足够让城市安全高于阈值的金额。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "无限金钱转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<先备份城市>。\n" +
                    "把以无限金钱开局的城市转换为普通城市。\n" +
                    "启用后，如果加载城市是 <无限金钱> 类型，会解锁 <[转换无限金钱存档]> 按钮。\n" +
                    "City Watchdog 无法撤销此转换。\n" +
                    "普通城市不需要此功能。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "把无限金钱城市转为普通" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "用于以 <无限金钱> 开局的城市。\n" +
                    "加载该城市时，把存档转换为普通有限金钱预算。\n" +
                    "按钮会 <禁用/变灰>，除非加载城市是 <无限金钱> 类型，\n" +
                    "且 <无限金钱转换器> 已启用 [ ✓ ]。\n" +
                    "请先备份并自行承担风险；City Watchdog 无法撤销。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "要把此城市从无限金钱转换为普通有限金钱吗？\n" +
                    "先保存备份；City Watchdog 无法撤销。\n" +
                    "确定吗？" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "模组名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "此模组的显示名称。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "当前模组版本。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "打开作者的 Paradox Mods 页面。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "诊断报告" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<正常游玩不需要。>\n" +
                    "供测试和游戏更新后检查：写入 <Logs/CityWatchdog.log> 报告，\n" +
                    "比较游戏实时通知预制件与 Watchdog 当前控制的图标。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "打开日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
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
