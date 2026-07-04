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
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "金钱-里程碑" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "关于" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用说明" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "城市信息查看器" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini HUD 通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新城市开始设置" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金钱" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "转换无限金钱存档" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "诊断" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "显示说明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "显示或隐藏下面的使用说明。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<显示开关>\n" +
                    "1. [i] 按钮：隐藏/显示所有游戏悬停提示。\n" +
                    "2. 道路名称按钮：隐藏/显示道路名称。快捷键：\\。\n" +
                    "3. 区域名称按钮：隐藏/显示区域名称，不改变边界。\n" +
                    "4. 道路箭头按钮：强制显示/隐藏单向箭头（也会隐藏道路名称）。\n" +
                    "5. CWD 标题栏图标：显示/隐藏 City Watchdog 面板提示。\n\n" +
                    "<通知警报>\n" +
                    "1. 点击左上角 City Watchdog 按钮，或按 Shift+N 打开面板。\n" +
                    "2. 排序按钮：升序/降序。\n" +
                    "3. Toggle All 可快速全开/全关，也可展开分类单独设置。\n" +
                    "4. 只隐藏图标；不会修复城市问题。\n\n" +
                    "<金钱工具>\n" +
                    "1. 添加或扣除金钱：默认按键 [ 和 ]。\n" +
                    "2. 自动加钱会在低于你设定的限制时加钱。\n" +
                    "3. 转换无限金钱存档只适用于无限金钱城市，并且<不可撤销>。\n\n" +
                    "<底部菜单提示>\n" +
                    "Money View 会在金钱和人口工具栏加入趋势值和悬停详情。\n\n" +
                    "<自定义里程碑>\n" +
                    "在加载或开始城市前设置初始资金和里程碑。"
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换通知图标" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<快捷键> 与游戏内 <[TOGGLE ALL]> 图标按钮作用相同。\n" +
                    "立即显示或隐藏所有列出的城市通知图标。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即显示/隐藏所有通知图标" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打开/关闭通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<快捷键> 用来打开或关闭\n" +
                    "<通知面板>。\n" +
                    "和点击左上角图标打开完整面板相同。"
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打开/关闭通知面板" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "仅按钮模式启动" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "启用 [ ✓ ] 后，从左上角打开 City Watchdog 会先显示较小的按钮视图。\n" +
                    "使用标题栏箭头或行数按钮展开完整面板。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隐藏/显示道路名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<快捷键> 立即隐藏或显示原版道路名称标签。\n" +
                    "和点击 City Watchdog 工具栏里的道路名称图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隐藏/显示道路名称" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "禁用所有鼠标悬停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<快捷键> 立即隐藏或显示所有游戏悬停提示。\n" +
                    "<City Watchdog 自己的金钱/人口弹窗会保留>；由上方 Money View 控制。\n" +
                    "和点击 City Watchdog 面板里的 [i] 图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隐藏/显示所有游戏悬停提示" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "显示金钱 + 人口提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<建议启用>\n" +
                    "底部游戏菜单：在金钱和人口箭头旁显示趋势值。\n" +
                    "这是轻量的工具栏悬停功能<只显示>；\n" +
                    "比频繁打开游戏信息面板更省事。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "选择底部工具栏趋势文字显示每小时还是每月。\n" +
                    "每月使用预算收入减支出；人口使用 24 小时预测。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金钱提示样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "选择金钱悬停提示显示多少细节。\n" +
                    "紧凑 = 首次安装默认。\n" +
                    "<迷你> 只显示 /mo 和 /h 的 2 个净值。\n" +
                    "<紧凑> 缩短大数字（15.21M 而不是 15,212,318）。\n" +
                    "<完整数据> 显示长数字和总计。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "紧凑" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金钱字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "调整 Money View 提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<模组默认 = 120%>\n" +
                    "悬停在屏幕底部的金钱上。\n" +
                    "适合觉得游戏提示太小的玩家。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "调整人口提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<模组默认 = 120%>\n" +
                    "悬停在屏幕底部的人口上。"
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "显示一个小型城市 HUD，包含重要通知数量。\n" +
                    "不用打开完整面板，也能快速看警报。\n" +
                    "点击图标会跳到一个对应问题位置。\n" +
                    "继续点击同一图标可轮换到其他位置，再回到第一个。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "推荐起始设置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "应用推荐的 Mini HUD 设置：\n" +
                    "收藏、5 个图标、横向、顶部居中、100% 大小、深色面板。\n" +
                    "零计数警报保持可见。\n" +
                    "可随时在展开的 Watchdog 面板添加/移除 **蓝星** 收藏。\n" +
                    "起始 **蓝星** 收藏包含在 **[推荐]** 中。"
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD 模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "选择 Mini HUD 使用哪些通知行。\n" +
                    "**最高活跃** 显示当前数量最高的警报。\n" +
                    "**收藏** 包含主面板中标记 **蓝星** 的所有行。\n" +
                    "你可以选择任意数量的收藏，\n" +
                    "但 Mini HUD 仍只显示此收藏列表中最高的 5 或 10 个数量。" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "最高活跃警报" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "收藏" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Mini HUD 图标数量" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "选择 Mini HUD 一次最多显示多少通知图标。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Mini HUD 大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "缩放 Mini HUD 图标和数字。\n" +
                    "90% = 紧凑。100% = 默认。最高 130% 更清楚。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Mini HUD 方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "选择图标排成一行还是一列。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "水平" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "垂直" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Mini HUD 位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "选择 Mini HUD 显示位置。\n" +
                    "可拖动模式可在城市 UI 中移动。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "顶部居中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上角" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖动" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Mini HUD 样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "选择 Mini HUD 背景样式。\n" +
                    "玻璃面板从透明到白色雾面，不会变暗。\n" +
                    "深色面板提供更暗的原版风格 HUD。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "深色面板" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "玻璃面板" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Mini HUD 不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "调整 Mini HUD 背景透明度。\n" +
                    "数值越低越透明；越高越实。\n" +
                    "玻璃会更白/雾面；深色会更实/更暗。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "隐藏零警报" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "启用 [ ✓ ] 后，Mini HUD 会隐藏计数为 0 的通知行。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始资金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "设置新<有限金钱>城市或首次加载城市的起始余额，\n" +
                    "应用后会重置为游戏默认。\n" +
                    "如果城市已加载，此项会变灰。\n" +
                    "在开始/加载城市前设置。应用一次后使用<金钱快捷键金额>或<自动加钱>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑选择器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在<加载或开始城市前>启用，可在城市加载后解锁指定里程碑。\n" +
                    "- 城市加载后不能开启，但如果误开可以关闭。\n" +
                    "- 如果忘了设置，重启游戏，在进入城市前选择。\n" +
                    "- 模组无法撤销已保存的里程碑变化；需要时使用旧存档。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "选择下次城市加载时要解锁的里程碑。\n" +
                    "只能在<未加载城市时>调整，并且 [里程碑选择器] 已启用 [ ✓ ]。\n" +
                    "如果城市已经达到或超过该里程碑，则不会发生变化。\n" +
                    "只有所选里程碑高于当前城市时才会更改。"
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金钱快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "此金额用于添加金钱和扣除金钱快捷键。\n" +
                    "<模组默认 = 40,000>\n" +
                    "除非在城市中使用快捷键，否则不会生效。\n" +
                    "如果要自动加钱，请启用自动加钱选项。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "添加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "在城市中 <添加金钱> 的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "添加金钱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "扣除金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "在城市中 <扣除金钱> 的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "扣除金钱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自动加钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "启用 [ ✓ ] 后，City Watchdog 会在城市加载时检查余额。\n" +
                    "- 如果余额<低于阈值>，\n" +
                    "  会添加选定的自动金额。\n" +
                    "- 建议按需使用手动金钱快捷键（<[> 或 <]>）" +
                    "  而不是自动选项；但此功能可用。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自动金钱阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果自动加钱启用且余额低于此值，\n" +
                    "会添加选定的自动金额。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自动金钱金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自动触发时添加的金额。\n" +
                    "选择足够高的值，让余额安全高于阈值。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "无限金钱转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<请先备份城市>。\n" +
                    "将以无限金钱开始的城市转换为普通金钱挑战城市。\n" +
                    "启用后，如果加载的城市是<无限金钱>类型，会解锁 <[转换无限金钱存档]> 按钮。\n" +
                    "City Watchdog 无法撤销此转换。\n" +
                    "如果是普通城市，不需要使用此功能。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将无限金钱存档城市转换为普通城市" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "适用于以<无限金钱>开始的城市。\n" +
                    "当该城市已加载时，会把存档转换为普通有限金钱预算。\n" +
                    "除非加载的城市是<无限金钱>类型，否则按钮会<禁用/变灰>\n" +
                    "并且<无限金钱转换器>已开启 [ ✓ ]。\n" +
                    "请先备份并自行承担风险；City Watchdog 无法撤销此转换。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "将此城市从无限金钱转换为普通有限金钱？\n" +
                    "请先备份；City Watchdog 无法撤销。\n" +
                    "确定吗？" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "模组名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此模组的显示名称。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "当前模组版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打开作者的 Paradox Mods 页面。" },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "调试报告写入日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<正常游戏不需要。>\n" +
                    "用于测试和游戏补丁检查：写入 <Logs/CityWatchdog.log> 报告\n" +
                    "比较游戏当前通知 prefab 与 Watchdog 控制的通知图标。" },

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
