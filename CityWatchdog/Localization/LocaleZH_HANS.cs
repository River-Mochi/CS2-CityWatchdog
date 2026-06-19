// <copyright file="LocaleZH_HANS.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

//
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
            string title = Mod.ModName + " (看门狗)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "快捷键" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "关于" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "调试" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "信息查看器" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金钱" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "里程碑" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "存档转换" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "快捷键" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "诊断" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用说明" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "悬停时显示详情" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "在底部工具栏原版的<金钱和人口箭头>旁显示数值趋势。\n" +
                    "这是轻量的工具栏悬停<仅显示>功能；\n" +
                    "不会改变城市金钱或人口。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "选择底部工具栏的趋势文字显示金钱和人口的每小时值还是每月值。\n" +
                    "每月金钱使用预算收入减支出，人口使用 24 小时预测。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金钱提示样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "选择鼠标悬停金钱时提示里显示多少细节。\n" +
                    "紧凑 = 首次安装默认。\n" +
                    "<迷你> 只显示 /mo 和 /h 的 2 个净值。\n" +
                    "<紧凑> 缩短大数字（15.21M 而不是 15,212,318）。\n" +
                    "<完整数据> 显示长数字和总计字段。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "紧凑" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金钱字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "调整 Money View 提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<模组默认 = 120%>\n" +
                    "将鼠标悬停在屏幕底部的金钱上。\n" +
                    "这是为看不清游戏小提示的玩家加入的。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "调整人口提示数字的<字体大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<模组默认 = 120%>\n" +
                    "将鼠标悬停在屏幕底部的人口上。" },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金钱快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "此金额用于添加金钱和减少金钱快捷键。\n" +
                    "<模组默认 = 40,000>\n" +
                    "除非你在城市中使用快捷键添加/减少金钱，否则不会生效。\n" +
                    "如需自动加钱，请启用自动添加金钱选项。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "添加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市中执行<添加金钱>的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "添加金钱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "减少金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市中执行<减少金钱>的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "减少金钱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自动添加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "启用 [ ✓ ] 后，City Watchdog 会在城市加载时检查城市余额。\n" +
                    "- 如果余额<低于阈值>，\n" +
                    "  就会添加所选的自动金额。\n" +
                    "- 建议需要时使用手动金钱快捷键（<[> 或 <]>）  而不是这个自动选项，但如果你想用，它就在这里。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自动金钱阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果自动添加金钱已启用，且城市余额低于此值，\n" +
                    "就会添加所选的自动金额。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自动金钱金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自动添加金钱触发时添加的金额。\n" +
                    "请选择足够高的数值，让城市安全回到阈值以上。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "设置新<有限金钱>城市或首次加载城市的起始余额，\n" +
                    "应用后会重置为游戏默认。\n" +
                    "如果城市已经加载，此项会变灰。\n" +
                    "在开始/加载城市前设置 → 应用一次 → 之后使用<金钱快捷键金额>或<自动添加金钱>。" },

                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换通知图标" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "与游戏内 <[TOGGLE ALL]> 图标按钮相同操作的<快捷键>。\n" +
                    "可立即显示或隐藏所有列出的城市通知图标。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即显示/隐藏所有通知图标" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打开/关闭通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "用于在城市中打开或关闭\n" +
                    "<通知面板>的<快捷键>。\n" +
                    "效果与点击左上角图标打开完整面板相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打开/关闭通知面板" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隐藏/显示道路名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<快捷键>可立即隐藏或显示城市中的原版道路名称标签。\n" +
                    "与点击 City Watchdog 面板工具栏中的道路名称图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隐藏/显示道路名称" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "禁用所有鼠标悬停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<快捷键>立即隐藏/显示所有游戏悬停提示 — 建筑、cims、工具和底部菜单图标。\n" +
                    "<City Watchdog 自己的金钱/人口弹窗保持开启>；它们由上方的 Money View 选项控制。\n" +
                    "与点击城市内 City Watchdog 面板上的 [i] 图标效果相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隐藏/显示所有游戏悬停提示" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑选择器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在加载或开始城市前启用，可在城市加载后立即解锁所选里程碑。\n" +
                    "城市已加载时不能开启，但如果误开，可以关闭。\n" +
                    "City Watchdog 无法撤销已经保存到城市中的里程碑变化；需要时请使用较早存档。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "选择下次加载城市时要解锁的里程碑等级。\n" +
                    "只能在没有加载城市时调整，并且必须先启用 [里程碑选择器] [ ✓ ]。" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "无限金钱转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<请先备份城市>。\n" +
                    "将以无限金钱开始的城市转换为有正常金钱挑战的普通城市。\n" +
                    "当加载的城市是<无限金钱>类型时，启用此项会解锁 <[转换无限金钱存档]> 按钮。\n" +
                    "City Watchdog 无法撤销此转换。\n" +
                    "如果你的是普通城市，不用担心；不需要使用它。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将无限金钱城市转换为普通城市" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "用于以<无限金钱>开始的城市。\n" +
                    "该城市加载时，此项会将存档转换为普通有限金钱预算，让城市重新拥有正常金钱挑战。\n" +
                    "除非加载的城市是<无限金钱>类型\n" +
                    "且<无限金钱转换器>为 ON [ ✓ ]，否则按钮会<禁用/变灰>。\n" +
                    "请先备份存档并自行承担风险；City Watchdog 无法撤销此转换。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "要将此城市从无限金钱转换为普通有限金钱吗？\n" +
                    "请先备份；City Watchdog 无法撤销此操作。\n" +
                    "确定吗？" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "模组名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此模组的显示名称。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "当前模组版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打开作者的 Paradox Mods 页面。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "调试报告写入日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<正常游戏不需要。>\n" +
                    "供测试者和游戏补丁后检查使用：写入 <Logs/CityWatchdog.log> 报告，\n" +
                    "比较实时游戏通知 prefab 与 Watchdog 当前控制的通知图标。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "如果存在，则打开 </Logs/CityWatchdog.log>。\n" +
                    "如果日志文件缺失，则打开 Logs/ 文件夹。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "显示说明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "显示或隐藏下面的使用说明。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<显示开关>\n" +
                    "1. [i] 按钮：隐藏/显示所有游戏悬停提示（建筑、cims、工具、底部菜单图标）。\n" +
                    "2. 道路名称按钮：隐藏/显示道路名称标签。快捷键：\\。\n" +
                    "3. 道路箭头按钮：强制单行道箭头开/关（也会隐藏道路名称）。\n" +
                    "4. CWD 标题栏图标：显示/隐藏 City Watchdog 面板提示。\n" +
                    "\n" +
                    "<通知警报>\n" +
                    "1. 点击 City Watchdog 按钮（左上角），或按 Shift+N，打开面板。\n" +
                    "2. 排序按钮用于升序/降序。\n" +
                    "3. Toggle All 可快速全部 Off/On，或展开某个分类修改具体图标。\n" +
                    "4. 只显示或隐藏图标；不会修复城市本身的问题。\n" +
                    "\n" +
                    "<金钱工具>\n" +
                    "1. 添加或减少金钱：使用<金钱快捷键金额>的默认按键 [ 和 ]。\n" +
                    "2. 自动添加金钱会在城市低于你设置的限制时加钱。\n" +
                    "3. 转换无限金钱存档只用于以无限金钱开始的城市，并且<不可逆>。\n" +
                    "\n" +
                    "<底部菜单提示>\n" +
                    "Money View 会在金钱和人口工具栏添加趋势值，并在鼠标悬停时显示额外详情。\n" +
                    "\n" +
                    "<自定义里程碑>\n" +
                    "在加载或开始城市前，到选项菜单设置初始金钱并选择里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
