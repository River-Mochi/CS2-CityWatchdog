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

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleZH_HANT(CwdSettings setting)
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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kActions), "操作" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMiniHudTab), "迷你HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMoneyTab), "城市開局" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kAbout), "關於" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutUsage), "使用" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kNotifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoneyViewGroup), "城內資訊" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMiniHudGroup), "迷你HUD警報" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "新城市開局設定" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "金錢" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "轉換無限金錢存檔" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "診斷" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "顯示說明" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "顯示或隱藏下方使用說明。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. 點擊城市左上角爪印圖示，或按 Shift+N，開啟主面板。\n" +
                    "<顯示開關>\n" +
                    "1. 標題列圖示：顯示/隱藏 City Watchdog 工具提示。\n" +
                    "\n" +
                    "2. **[i]** 按鈕：隱藏/顯示遊戲 <全部> 懸停提示：建築、市民、工具、底部選單圖示。\n" +
                    "3. 道路按鈕：隱藏/顯示道路名稱。快捷鍵：\\.\n" +
                    "4. 區域按鈕：隱藏/顯示區域名稱。\n" +
                    "5. 道路箭頭按鈕：顯示/隱藏單行道箭頭（也會隱藏道路名稱）。\n" +
                    "\n" +
                    "<通知警報>\n" +
                    "1. 排序按鈕循環 A→Z、Z→A、僅啟用清單。\n" +
                    "2. <[0/62]> = 顯示圖示/總數。點擊展開/摺疊所有列。\n" +
                    "3a. [顯示圖示] 立即關閉/開啟所有問題警報圖示。\n" +
                    "3b. 預設 [1 | 2]：點擊載入；按住 1 秒儲存目前勾選狀態。\n" +
                    "3c. 隱藏圖示不會修復城市問題。\n" +
                    "\n" +
                    "<輔助工具>\n" +
                    "1. 新增 / 減少金錢：使用 <金錢快捷鍵金額> 的預設鍵 <[ 或 ]>。\n" +
                    "2. 自動金錢會在城市低於你設定的限制時加錢。\n" +
                    "3. 轉換無限金錢存檔只適用於以無限金錢開局的城市，並且 <不可撤銷>。\n" +
                    "\n" +
                    "<底部選單提示>\n" +
                    "金錢視圖會在懸停金錢或人口時新增趨勢等額外資訊。\n" +
                    "\n" +
                    "<自訂里程碑>\n" +
                    "城市開局可在載入或開始城市前設定初始金錢或里程碑。"
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "切換警報圖示" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<快捷鍵>，作用同遊戲內 <[顯示圖示]> 按鈕。\n" +
                    "立即顯示或隱藏所有問題警報圖示。"
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "立即顯示/隱藏問題警報圖示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "開啟/關閉警報面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<快捷鍵> 用於開啟或關閉\n" +
                    "城市中的 <警報面板>。\n" +
                    "和點擊左上角圖示相同。"
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "開啟/關閉警報面板" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "僅按鈕啟動" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "啟用 [ ✓ ] 時，City Watchdog 會先以小型僅按鈕檢視開啟。\n" +
                    "用標題列箭頭或列數按鈕開啟完整面板。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "隱藏/顯示道路名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<快捷鍵> 立即隱藏/顯示遊戲原本道路名稱。\n" +
                    "和 City Watchdog 面板的道路名稱圖示相同。"
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "隱藏/顯示道路名稱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "停用全部懸停提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<快捷鍵> 隱藏/顯示遊戲全部懸停提示：建築、市民、工具、底部圖示。\n" +
                    "<City Watchdog 的金錢/人口彈窗會保留>；由金錢視圖控制。\n" +
                    "和 City Watchdog 面板內的 [i] 圖示相同。"
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "隱藏/顯示遊戲懸停提示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "放大遊戲介面" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "啟用 [ ✓ ] 後，<整個遊戲介面>都會放大，包括遊戲和模組面板。\n" +
                    "無需 <--developerMode> 啟動參數即可使用遊戲內建的<介面縮放>。\n" +
                    "此 [x] 核取方塊與 City Watchdog 標題列的縮放按鈕同步。\n" +
                    "只調整文字：選項 > 介面 > <文字縮放>。\n" +
                    "會持續開啟直到你關閉；移除 City Watchdog 後也一樣。\n" +
                    "- 解除安裝前關閉即可恢復正常大小。\n" +
                    "- 或用 <--developerMode> 啟動一次，然後關閉 選項 > 介面 > 介面縮放 (dev)。"
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "主面板不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "調整主要通知面板背景的透明度。\n" +
                    "數值越低越透明；數值越高越深、越不透明。"
                },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "金錢趨勢 + 人口提示" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<建議開啟>\n" +
                    "底部選單：在 <金錢和人口箭頭> 上顯示趨勢值。\n" +
                    "輕量懸停功能 <僅顯示>；\n" +
                    "省時間，也可能比開啟遊戲資訊面板更輕。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "金錢視圖頻率" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "選擇底部趨勢文字顯示每小時或每月數值。\n" +
                    "每月使用收入減支出，以及24小時人口預測。"
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小時 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "金錢提示樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "選擇金錢懸停提示顯示多少細節。\n" +
                    "精簡 = 首次安裝預設。\n" +
                    "<迷你> 只顯示 /mo 和 /h 的2個淨值。\n" +
                    "<精簡> 縮短大數字（如 15.21M）。\n" +
                    "<完整資料> 顯示長數值和合計。"
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "精簡" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整資料" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "金錢字體大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "調整金錢視圖數字的 <字體大小>。\n" +
                    "遊戲預設 = 100%\n" +
                    "<模組預設 = 120%>\n" +
                    "懸停螢幕底部的金錢。\n" +
                    "適合看不清小提示的玩家。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "人口字體大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "調整人口數字的 <字體大小>。\n" +
                    "遊戲預設 = 100%\n" +
                    "<模組預設 = 120%>\n" +
                    "懸停螢幕底部的人口。"
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "迷你HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "顯示小型城市HUD，包含重要警報計數。\n" +
                    "不用開啟完整面板，也能快速查看警報。\n" +
                    "點擊圖示會跳到一個對應問題點。\n" +
                    "繼續點擊同一圖示可輪換問題點，再回到第一個。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "點擊：快速開始" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "為 Mini HUD 套用<快速開始>設定：\n" +
                    "加入一組初始**藍星收藏**。\n" +
                    "在收藏模式下，Mini HUD 會顯示**藍星**清單中目前數量最高的 5 或 10 項。\n" +
                    "可在 City Watchdog 面板中新增/移除**藍星**。\n" +
                    "設定為：收藏、5 個圖示、橫向、可拖曳、100%、深色面板，並隱藏數量為 0 的項目。\n" +
                    "隨時再次執行快速開始即可重設這些設定。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "迷你面板模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "選擇迷你面板使用哪些警報列。\n" +
                    "**數量最高**顯示目前數量最高的警報。\n" +
                    "**收藏**使用 City Watchdog 主面板中標記為 **藍色星星** 的列。\n" +
                    "你可以選擇任意數量的收藏，\n" +
                    "但迷你面板只顯示該 **藍色星星** 清單中數量最高的 5 或 10 個。"
                },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "數量最高警報" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "收藏" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "圖示數量" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "選擇迷你HUD最多顯示多少通知圖示。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "圖示大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "縮放迷你HUD圖示和數字。\n" +
                    "90% = 精簡。100% = 預設。可增至130%更清楚。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "方向" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "選擇橫排或直排。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "橫向" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "直向" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "HUD位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "選擇迷你HUD出現的位置。\n" +
                    "可拖曳讓你在城市介面中移動它。"
                },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "頂部置中" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "可拖曳" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "深色或玻璃樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "選擇迷你HUD背景樣式。\n" +
                    "玻璃會從透明變成霧白；不會變暗。\n" +
                    "想要更暗的遊戲風HUD請用深色面板。"
                },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "深色面板" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "玻璃面板" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "背景不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "調整迷你HUD背景透明度。\n" +
                    "數值低 = 更透明。數值高 = 更實。\n" +
                    "玻璃會更白。深色會更實/更暗。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "隱藏0警報" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "啟用 [ ✓ ] 時，迷你HUD隱藏計數為0的列。" },

                // --------------------------------------------------------------------
                // City Start tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "初始金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "設定下一個載入的 <有限金錢> 城市餘額——新城市或現有城市皆可。\n" +
                    "套用一次後，此設定會重設為遊戲預設。\n" +
                    "城市已載入時會變灰。\n" +
                    "請在載入或開始城市前設定。之後需要時使用 <金錢快捷鍵金額>。"
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "遊戲預設" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "里程碑選擇器" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "在 <載入或開始前> 啟用，可在城市載入後立即解鎖指定里程碑。\n" +
                    "- 城市載入後不能開啟，但誤開時可以關閉。\n" +
                    "- 忘了就重新啟動遊戲，並在進城前選擇。\n" +
                    "- 模組不能撤銷已經存入城市的里程碑變化；需要時用舊存檔。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "選擇下次載入城市時解鎖的里程碑。\n" +
                    "僅在 <未載入城市時> 且 [里程碑選擇器] 啟用 [ ✓ ] 後可調。\n" +
                    "如果城市已達到或超過所選里程碑，則不會發生變化。\n" +
                    "只有所選里程碑更高時才會改變。"
                },

                // --------------------------------------------------------------------
                // City Start tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "金錢快捷鍵金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "此金額用於新增金錢和減少金錢快捷鍵。\n" +
                    "<模組預設 = 40,000>\n" +
                    "除非在城市內使用快捷鍵，否則不會生效。\n" +
                    "想自動加錢請啟用自動金錢。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "新增金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "城市內 <新增金錢> 的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "新增金錢" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "減少金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "城市內 <減少金錢> 的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "減少金錢" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "自動金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "啟用 [ ✓ ] 後，City Watchdog 會檢查城市餘額。\n" +
                    "- 如果餘額 <低於門檻>，會新增足夠金額以達到門檻。\n" +
                    "- 一律至少新增所選的自動金錢金額。\n" +
                    "- 如果只是偶爾需要，建議使用手動快捷鍵 (<[> 或 <]>)。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "自動金錢門檻" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "如果自動金錢已啟用且城市餘額低於此值，\n" +
                    "會持續加錢，直到至少達到此門檻。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "自動金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "每次自動金錢觸發時新增的最低金額。\n" +
                    "如果達到門檻需要更多，City Watchdog 會新增較大的金額。"
                },

                // --------------------------------------------------------------------
                // City Start tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "無限金錢轉換器" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<先備份城市>。\n" +
                    "把以無限金錢開局的城市轉換為普通城市。\n" +
                    "啟用後，如果載入城市是 <無限金錢> 類型，會解鎖 <[轉換無限金錢存檔]> 按鈕。\n" +
                    "City Watchdog 無法撤銷此轉換。\n" +
                    "普通城市不需要此功能。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "把無限金錢城市轉為普通" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "用於以 <無限金錢> 開局的城市。\n" +
                    "載入該城市時，把存檔轉換為普通有限金錢預算。\n" +
                    "按鈕會 <停用/變灰>，除非載入城市是 <無限金錢> 類型，\n" +
                    "且 <無限金錢轉換器> 已啟用 [ ✓ ]。\n" +
                    "請先備份並自行承擔風險；City Watchdog 無法撤銷。"
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "要把此城市從無限金錢轉換為普通有限金錢嗎？\n" +
                    "先儲存備份；City Watchdog 無法撤銷。\n" +
                    "確定嗎？"
                },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "模組名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "此模組的顯示名稱。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "目前模組版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "開啟作者的 Paradox Mods 頁面。" },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "診斷報告" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<正常遊玩不需要。>\n" +
                    "供測試和遊戲更新後檢查：寫入 <Logs/CityWatchdog.log> 報告，\n" +
                    "比較遊戲即時通知預製件與 Watchdog 目前控制的圖示。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "開啟日誌" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "如果存在，開啟 </Logs/CityWatchdog.log>。\n" +
                    "如果日誌檔案缺失，則開啟 Logs/ 資料夾。"
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
