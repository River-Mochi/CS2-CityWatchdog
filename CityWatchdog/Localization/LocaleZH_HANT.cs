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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "金錢-里程碑" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "关于" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用说明" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "城市信息查看器" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini HUD 通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新城市开始設定" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金錢" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "轉換無限金錢存档" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "诊断" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "顯示说明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "顯示或隱藏下面的使用说明。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<顯示开关>\n" +
                    "1. [i] 按鈕：隱藏/顯示所有游戏懸停提示。\n" +
                    "2. 道路名称按鈕：隱藏/顯示道路名称。快捷鍵：\\。\n" +
                    "3. 區域名称按鈕：隱藏/顯示區域名称，不改变边界。\n" +
                    "4. 道路箭头按鈕：强制顯示/隱藏单向箭头（也会隱藏道路名称）。\n" +
                    "5. CWD 标题栏圖示：顯示/隱藏 City Watchdog 面板提示。\n\n" +
                    "<通知警报>\n" +
                    "1. 点击左上角 City Watchdog 按鈕，或按 Shift+N 打开面板。\n" +
                    "2. 排序按鈕：升序/降序。\n" +
                    "3. Toggle All 可快速全开/全关，也可展开分类单独設定。\n" +
                    "4. 只隱藏圖示；不会修复城市问题。\n\n" +
                    "<金錢工具>\n" +
                    "1. 添加或扣除金錢：預設按键 [ 和 ]。\n" +
                    "2. 自动加钱会在低于你设定的限制时加钱。\n" +
                    "3. 轉換無限金錢存档只适用于無限金錢城市，并且<不可撤销>。\n\n" +
                    "<底部菜单提示>\n" +
                    "Money View 会在金錢和人口工具栏加入趋势值和懸停細節。\n\n" +
                    "<自定义里程碑>\n" +
                    "在載入或开始城市前設定初始资金和里程碑。"
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换通知圖示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<快捷鍵> 与游戏内 <[TOGGLE ALL]> 圖示按鈕作用相同。\n" +
                    "立即顯示或隱藏所有列出的城市通知圖示。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即顯示/隱藏所有通知圖示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打开/关闭通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<快捷鍵> 用来打开或关闭\n" +
                    "<通知面板>。\n" +
                    "和点击左上角圖示打开完整面板相同。"
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打开/关闭通知面板" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "仅按鈕模式启动" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "啟用 [ ✓ ] 后，从左上角打开 City Watchdog 会先顯示较小的按鈕视图。\n" +
                    "使用标题栏箭头或列数按鈕展开完整面板。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "隱藏/顯示道路名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<快捷鍵> 立即隱藏或顯示原版道路名称标签。\n" +
                    "和点击 City Watchdog 工具栏里的道路名称圖示相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "隱藏/顯示道路名称" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "停用所有鼠标懸停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<快捷鍵> 立即隱藏或顯示所有游戏懸停提示。\n" +
                    "<City Watchdog 自己的金錢/人口弹窗会保留>；由上方 Money View 控制。\n" +
                    "和点击 City Watchdog 面板里的 [i] 圖示相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "隱藏/顯示所有游戏懸停提示" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "顯示金錢 + 人口提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<建议啟用>\n" +
                    "底部游戏菜单：在金錢和人口箭头旁顯示趋势值。\n" +
                    "这是轻量的工具栏懸停功能<只顯示>；\n" +
                    "比频繁打开游戏信息面板更省事。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "選擇底部工具栏趋势文字顯示每小时还是每月。\n" +
                    "每月使用预算收入减支出；人口使用 24 小时预测。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金錢提示样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "選擇金錢懸停提示顯示多少细节。\n" +
                    "精簡 = 首次安装預設。\n" +
                    "<迷你> 只顯示 /mo 和 /h 的 2 个净值。\n" +
                    "<精簡> 缩短大数字（15.21M 而不是 15,212,318）。\n" +
                    "<完整数据> 顯示长数字和总计。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "精簡" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金錢字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "調整 Money View 提示数字的<字体大小>。\n" +
                    "游戏預設 = 100%\n" +
                    "<模组預設 = 120%>\n" +
                    "懸停在屏幕底部的金錢上。\n" +
                    "适合觉得游戏提示太小的玩家。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口字体大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "調整人口提示数字的<字体大小>。\n" +
                    "游戏預設 = 100%\n" +
                    "<模组預設 = 120%>\n" +
                    "懸停在屏幕底部的人口上。"
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "顯示一个小型城市 HUD，包含重要通知數量。\n" +
                    "不用打开完整面板，也能快速看警报。\n" +
                    "点击圖示会跳到一个对应问题位置。\n" +
                    "继续点击同一圖示可轮换到其他位置，再回到第一个。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "推荐起始設定" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "套用推荐的 Mini HUD 設定：\n" +
                    "收藏、5 个圖示、横向、頂部居中、100% 大小、深色面板。\n" +
                    "零计数警报保持可见。\n" +
                    "可随时在展开的 Watchdog 面板添加/移除 **蓝星** 收藏。\n" +
                    "起始 **蓝星** 收藏包含在 **[推荐]** 中。"
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD 模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "選擇 Mini HUD 使用哪些通知列。\n" +
                    "**最高活跃** 顯示目前數量最高的警报。\n" +
                    "**收藏** 包含主面板中标记 **蓝星** 的所有列。\n" +
                    "你可以選擇任意數量的收藏，\n" +
                    "但 Mini HUD 仍只顯示此收藏列表中最高的 5 或 10 个數量。" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "最高活跃警报" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "收藏" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Mini HUD 圖示數量" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "選擇 Mini HUD 一次最多顯示多少通知圖示。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Mini HUD 大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "缩放 Mini HUD 圖示和数字。\n" +
                    "90% = 精簡。100% = 預設。最高 130% 更清楚。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Mini HUD 方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "選擇圖示排成一列还是一列。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "水平" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "垂直" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Mini HUD 位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "選擇 Mini HUD 顯示位置。\n" +
                    "可拖动模式可在城市 UI 中移动。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "頂部居中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上角" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖动" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Mini HUD 样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "選擇 Mini HUD 背景样式。\n" +
                    "玻璃面板从透明到白色雾面，不会变暗。\n" +
                    "深色面板提供更暗的原版风格 HUD。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "深色面板" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "玻璃面板" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Mini HUD 不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "調整 Mini HUD 背景透明度。\n" +
                    "数值越低越透明；越高越实。\n" +
                    "玻璃会更白/雾面；深色会更实/更暗。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "隱藏零警报" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "啟用 [ ✓ ] 后，Mini HUD 会隱藏计数为 0 的通知列。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始资金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "設定新<有限金錢>城市或首次載入城市的起始余额，\n" +
                    "套用后会重置为游戏預設。\n" +
                    "如果城市已載入，此项会變灰。\n" +
                    "在开始/載入城市前設定。套用一次后使用<金錢快捷鍵金額>或<自动加钱>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏預設" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑選擇器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在<載入或开始城市前>啟用，可在城市載入后解锁指定里程碑。\n" +
                    "- 城市載入后不能开启，但如果误开可以关闭。\n" +
                    "- 如果忘了設定，重启游戏，在进入城市前選擇。\n" +
                    "- 模组无法撤销已保存的里程碑變更；需要时使用旧存档。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "選擇下次城市載入时要解锁的里程碑。\n" +
                    "只能在<未載入城市时>調整，并且 [里程碑選擇器] 已啟用 [ ✓ ]。\n" +
                    "如果城市已经达到或超过该里程碑，则不会发生變更。\n" +
                    "只有所选里程碑高于目前城市时才会更改。"
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金錢快捷鍵金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "此金額用于添加金錢和扣除金錢快捷鍵。\n" +
                    "<模组預設 = 40,000>\n" +
                    "除非在城市中使用快捷鍵，否则不会生效。\n" +
                    "如果要自动加钱，请啟用自动加钱选项。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "添加金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "在城市中 <添加金錢> 的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "添加金錢" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "扣除金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "在城市中 <扣除金錢> 的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "扣除金錢" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自动加钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "啟用 [ ✓ ] 后，City Watchdog 会在城市載入时檢查余额。\n" +
                    "- 如果余额<低于門檻>，\n" +
                    "  会添加选定的自动金額。\n" +
                    "- 建议按需使用手动金錢快捷鍵（<[> 或 <]>）" +
                    "  而不是自动选项；但此功能可用。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自动金錢門檻" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果自动加钱啟用且余额低于此值，\n" +
                    "会添加选定的自动金額。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自动金錢金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自动触发时添加的金額。\n" +
                    "選擇足够高的值，让余额安全高于門檻。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限金錢轉換器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<请先備份城市>。\n" +
                    "将以無限金錢开始的城市轉換为一般金錢挑战城市。\n" +
                    "啟用后，如果載入的城市是<無限金錢>类型，会解锁 <[轉換無限金錢存档]> 按鈕。\n" +
                    "City Watchdog 无法撤销此轉換。\n" +
                    "如果是一般城市，不需要使用此功能。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将無限金錢存档城市轉換为一般城市" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "适用于以<無限金錢>开始的城市。\n" +
                    "当该城市已載入时，会把存档轉換为一般有限金錢预算。\n" +
                    "除非載入的城市是<無限金錢>类型，否则按鈕会<停用/變灰>\n" +
                    "并且<無限金錢轉換器>已开启 [ ✓ ]。\n" +
                    "请先備份并自列承担风险；City Watchdog 无法撤销此轉換。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "将此城市从無限金錢轉換为一般有限金錢？\n" +
                    "请先備份；City Watchdog 无法撤销。\n" +
                    "确定吗？" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "模组名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此模组的顯示名称。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "目前模组版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打开作者的 Paradox Mods 页面。" },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "调试报告写入日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<正常游戏不需要。>\n" +
                    "用于测试和游戏补丁檢查：写入 <Logs/CityWatchdog.log> 报告\n" +
                    "比较游戏目前通知 prefab 与 Watchdog 控制的通知圖示。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "如果存在，打开 </Logs/CityWatchdog.log>。\n" +
                    "如果日志檔案缺失，则打开 Logs/ 檔案夹。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
