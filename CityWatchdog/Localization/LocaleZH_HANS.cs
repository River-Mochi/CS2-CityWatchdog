// <copyright file="LocaleZH_HANS.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleZH_HANS.cs
// Purpose: Simplified Chinese (zh-HANS) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "悬停时显示详情" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "在底部工具栏的原版金钱和人口箭头旁显示数值趋势。\n这是轻量级的工具栏悬停<仅显示>功能；\n不会改变城市金钱或人口。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "金钱视图频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "选择底部工具栏趋势文字显示金钱和人口的小时值还是月度值。\n月度金钱使用预算收入减支出，人口使用 24 小时预测。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金钱提示样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "选择鼠标悬停金钱时提示中显示多少详细信息。\n紧凑 = 首次安装默认值。\n<迷你> 只显示 /mo 和 /h 的 2 个净值。\n<紧凑> 会缩短大数值（15.21M 而不是 15,212,318）。\n<完整数据> 显示长数值和总计字段。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "紧凑" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金钱字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "调整 Money View 提示数字的<字体大小>。\n游戏默认 = 100%\n<模组默认 = 120%>\n将鼠标悬停在屏幕底部的金钱上。\n为觉得游戏小提示难以看清的玩家而添加。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "调整人口提示数字的<字体大小>。\n游戏默认 = 100%\n<模组默认 = 120%>\n将鼠标悬停在屏幕底部的人口上。" },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金钱快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "将此金额用于添加金钱和减少金钱快捷键。\n<模组默认 = 40,000>\n除非你在城市中使用快捷键添加/减少金钱，否则不会执行任何操作。\n如需自动金钱，请启用自动添加金钱选项。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "添加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市中<添加金钱>的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "添加金钱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "减少金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市中<减少金钱>的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "减少金钱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自动添加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "启用 [ ✓ ] 后，City Watchdog 会在城市加载时检查城市余额。\n- 如果余额<低于阈值>，\n  就会添加所选的自动金额。\n- 建议按需使用快捷键（<[> 或 <]>）手动加钱，而不是使用此自动选项；但如果你需要，它也在这里。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自动金钱阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "如果启用了自动添加金钱且城市余额低于此值，\n则添加所选的自动金额。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自动金钱金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "每次触发自动添加金钱时添加的金额。\n请选择足够高的值，让城市安全地回到阈值以上。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "设置新的<有限金钱>城市或第一个加载城市的起始余额，\n应用后重置为游戏默认值。\n如果城市已经加载，此项会灰显。\n在开始/加载城市前设置 → 应用一次 → 然后使用<金钱快捷键金额>或<自动添加金钱>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认值" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换通知图标" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<快捷键>执行与游戏内 <[TOGGLE ALL]> 图标按钮相同的操作。\n立即显示或隐藏所有列出的城市通知图标。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即显示/隐藏所有通知图标" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打开/关闭通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<快捷键>用于在城市中打开或关闭\n<通知面板>。\n与点击左上角图标打开完整面板相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打开/关闭通知面板" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隐藏/显示道路名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<快捷键>可立即隐藏或显示城市中的原版道路名称标签。\n与点击 City Watchdog 面板工具栏中的道路名称图标相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隐藏/显示道路名称" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "禁用所有鼠标悬停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "关闭游戏的悬停提示——包括在建筑/市民/工具上跟随光标的提示，以及游戏 UI 按钮上的小弹窗（顶部栏名称、原版按钮等）。\n<City Watchdog 自己的金钱/人口弹窗保持开启>；它们由上面的 Money View 选项控制。\n与在城市中点击 City Watchdog 面板上的 [i] 图标相同。" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑选择器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "在加载或开始城市前启用，可在城市加载后立即解锁所选里程碑。\n城市已加载时不能开启，但如果误开了，可以将其关闭。\nCity Watchdog 无法撤销已经保存进城市的里程碑变化；如有需要，请使用较早的存档。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "选择下次城市加载时要解锁的里程碑等级。\n只能在未加载城市时调整，并且只有在 [里程碑选择器] 已启用 [ ✓ ] 后才能调整。" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "无限金钱转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<请先备份城市>。\n将以无限金钱开始的城市转换为具有普通金钱挑战的正常城市。\n当加载的城市是<无限金钱>类型时，启用此项会解锁 <[转换无限金钱存档]> 按钮。\nCity Watchdog 无法撤销此转换。\n如果你有普通城市，不必担心；不需要此功能。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将无限金钱存档城市转换为普通" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "适用于以<无限金钱>开始的城市。\n在该城市加载时，将存档转换为普通有限金钱预算，让城市重新拥有普通金钱挑战。\n按钮会<禁用/灰显>，除非加载的城市是<无限金钱>类型，\n并且<无限金钱转换器>为 ON [ ✓ ]。\n请制作备份存档，并自行承担风险；City Watchdog 无法撤销此转换。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将此城市从无限金钱转换为普通有限金钱？\n请先保存备份；City Watchdog 无法撤销。\n确定吗？" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "模组名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此模组的显示名称。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "当前模组版本。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打开作者的 Paradox Mods 页面。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "调试报告到日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<正常游戏不需要。>\n供测试人员和游戏补丁后检查使用：写入 <Logs/CityWatchdog.log> 报告，\n比较实时游戏通知 prefab 与 Watchdog 当前控制的通知图标。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "如果存在，则打开 </Logs/CityWatchdog.log>。\n如果日志文件缺失，则改为打开 Logs/ 文件夹。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "显示说明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "显示或隐藏下面的使用说明。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<通知面板>\n1. 点击 City Watchdog 按钮（左上角），或按 Shift+N 打开面板。\n2. 按 ASC/DESC 排序。\n3. 使用 Toggle All 快速全部关闭/开启，或展开某个分组来更改特定图标。\n4. 只显示或隐藏图标；不会修复城市的根本问题。\n\n<金钱工具>\n1. 添加或减少金钱：使用默认<金钱快捷键金额> [ 或 ]。\n2. 自动添加金钱会在城市加载时监视预算，并在低于阈值时添加金钱。\n3. Money View 会在金钱和人口工具栏以及鼠标悬停提示中添加数值。\n4. 转换无限金钱存档仅适用于以无限金钱开始的城市，并且<不可逆>。\n\n<自定义里程碑>\n在加载或开始城市前，在选项菜单中设置初始金钱并选择里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
