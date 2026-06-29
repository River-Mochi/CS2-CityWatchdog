// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleKO.cs
// Purpose: Korean (ko-KR) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleKO(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "작업" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "돈-마일스톤" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "정보" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "사용법" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "알림" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "도시 내 정보 뷰어" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini HUD 알림" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "새 도시 시작 설정" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "돈" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "무제한 자금 저장 변환" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "진단" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "사용법 표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "표시/숨김 the usage instructions below." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<Display toggles>\n1. [i] button: show/hide all game hover tooltips.\n2. Road Name button: show/hide road name labels. 단축키: \\.\n3. District Name button: show/hide district names without changing boundaries.\n4. Road Arrow button: show/hide one-way road arrows and also hide road names.\n5. CWD title icon: show/hide panel tooltips.\n\n<Notification alerts>\n열기 City Watchdog with the top-left button or Shift+N. Sort, Toggle All, or expand sections to change specific icons. This hides icons only; it does not fix city problems.\n\n<돈 helpers>\nUse [ and ] to add/subtract money. Automatic money adds money below your chosen limit. 무제한 돈 conversion is not reversible.\n\n<Bottom menu tooltips>\n돈 View adds money and population trend values to the bottom toolbar.\n\n<Custom milestone>\nSet 초기 자금 and milestones before loading or starting a city." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "알림 아이콘 전환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<단축키> for the same action as the in-game <[TOGGLE ALL]> icon button.\nIt shows or hides all listed city notification icons instantly." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "모든 알림 아이콘 즉시 표시/숨김" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "알림 패널 열기/닫기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<단축키> for opening or closing the\n<알림 패널> 도시에서.\nWorks the same as clicking Top Left icon to open the full panel." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "알림 패널 열기/닫기" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "버튼 전용 시작" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "활성화 시 [ ✓ ], opening City Watchdog from the top-left button starts in the smaller buttons-only view.\nUse the title-bar arrow or the row-count button to expand the full panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "도로 이름 숨김/표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<단축키> to instantly hide or show the vanilla road name labels 도시에서.\nSame as clicking the Road-Name icon in the City Watchdog panel toolbar." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "도로 이름 숨김/표시" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "모든 마우스오버 툴팁 비활성화" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<단축키> to instantly hide or show ALL game hover tooltips — buildings, cims, tools, and bottom menu icons.\n<City Watchdog's own money/population popups stay on>; those are controlled by the 돈 View option above.\nSame as clicking the [i] icon on the City Watchdog panel inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "모든 게임 호버 툴팁 숨김/표시" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "돈 + 인구 툴팁 표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<Recommend Enable>\nBottom game menu: Shows trend values with the game's bottom toolbar <money and population arrows>.\nThis is a lightweight hover over toolbar feature <display only>;\nSaves time and possible better performance than opening game's Info view panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 빈도" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "선택 whether the bottom-toolbar trend text shows hourly or monthly values for money and population.\nMonthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "시간당 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "월간 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "돈 툴팁 스타일" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "선택 how much detail appears in the money hover tooltip.\n간단 = default on first install.\n<Mini> shows only 2 Net values for /mo and /h.\n<간단> shortens large values (15.21M instead of 15,212,318).\n<전체 데이터> shows long values and Total fields." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "미니" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "간단" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "전체 데이터" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "돈 글자 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Adjusts <font size> of 돈 View tooltip numbers.\n게임 기본값 = 100%\n<모드 기본값 = 120%>\nHover over 돈 at bottom of the screen.\nRequested by players who have hard time seeing smaller tooltips in the game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "인구 글자 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Adjusts <font size> of population tooltip numbers.\n게임 기본값 = 100%\n<모드 기본값 = 120%>\nHover over Population at bottom of the screen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "도시에 작은 HUD를 표시합니다 with the most important notification counts.\nUse it as a quick alert strip without opening the full City Watchdog panel.\nClicking an icon jumps to one matching problem spot.\nKeep clicking the same icon to rotate through matching spots, then back to the first one." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "추천 프리셋" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "Applies a recommended Mini HUD setup:\n즐겨찾기, 5 icons, vertical, draggable, hide zero alerts, glass style off.\n드래그 가능 vertical preset starts near the top-right side.\nStarter Blue-Star 즐겨찾기: Not enough electricity, Electricity bottleneck, Battery depleted, Electric cable not connected, Power line not connected, Not enough water, Backed up sewer, Water pipe not connected, Sewer pipe not connected, Abandoned, High rent, Traffic jam, Road required, No pedestrian access, Lack of Labor, Water damage, On fire, Burned down, Garbage piling up, Traffic accident, Crime scene, Pathfinding failed, No vehicles.\nChange 파란 별s anytime in the City Watchdog city panel." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD 모드" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "선택 which notification rows the Mini HUD uses.\n**Top active** alerts shows the highest current counts.\n**즐겨찾기** includes all rows marked with **파란 별** in the main City Watchdog panel.\nYou can pick as many favorites as you want,\nbut Mini HUD still shows only the top 5 or top 10 current counts from that **favorites blue-star** list." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "상위 활성 알림" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "즐겨찾기" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Mini HUD 아이콘 수" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "선택 how many notification icons the Mini HUD can show at once." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Mini HUD 방향" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "선택 whether Mini HUD icons are arranged in a row or a column." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "가로" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "세로" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Mini HUD 위치" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "선택 where the Mini HUD appears.\n드래그 가능 lets you move it 도시에서 UI." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "상단 중앙" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "상단 오른쪽" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "드래그 가능" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "0개 알림 숨기기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "활성화 시 [ ✓ ], the Mini HUD hides notification rows with a count of 0." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "유리 스타일" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)), "Adds a soft glass-style background behind the Mini HUD for readability." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "초기 자금" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Sets the starting balance for a new <limited money> city or the first loaded city,\nthen resets to 게임 기본값 after it applies.\nThis is grayed out if a city is already loaded.\nSet this before starting/loading a city. It applies once, then use <돈 단축키 금액> or <자동 돈 추가> afterward." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "게임 기본값" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "마일스톤 선택기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Enable <before loading or starting a city> to unlock a chosen milestone immediately after the city loads.\n- Cannot be turned ON after a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n- If you forgot and loaded a city, just restart the game, and pick milestone before entering a city.\n- Mod 되돌릴 수 없습니다 milestone changes already saved into a city; use an earlier save if needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "마일스톤" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Pick a milestone level to unlock on the next city load.\nThis is <only adjustable outside a loaded city>, and only after [마일스톤 선택기] is enabled [ ✓ ].\nIf the city is already at or past the milestone selected, then nothing will happen.\nA change only happens if the milestone selected here is higher than what the city has." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "돈 단축키 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Use this amount with the 돈 추가 and 돈 빼기 hotkeys.\n<모드 기본값 = 40,000>\nThis does nothing unless you use the hotkey to add/subtract money (도시에서).\nFor automated money, enable the 자동 돈 추가 option." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "단축키 to <돈 추가> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "돈 추가" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "돈 빼기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "단축키 to <돈 빼기> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "돈 빼기" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "자동 돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "활성화 시 [ ✓ ], City Watchdog checks the city balance while a city is loaded.\n- If the balance is <below the threshold>, \n  it adds the selected automatic amount.\n- Recommend to use Manual money with hotkey (<[> or <]>) as needed  instead of this automated option, but this is here if you want it." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "자동 돈 임계값" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "If 자동 돈 추가 is enabled and the city balance falls below this value,\nAdd the selected automatic amount." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "자동 돈 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Amount added each time 자동 돈 추가 triggers.\n선택 a value high enough to bring the city safely above the threshold." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "무제한 돈 변환기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<먼저 도시를 백업하세요>.\nConverts a city that started as 무제한 돈 to a normal city with regular money challenges.\nEnabling this unlocks the <[Convert 무제한 돈 Save]> button when the loaded city is <무제한 돈> type.\nCity Watchdog 되돌릴 수 없습니다 this conversion.\nIf you have normal cities, do not worry about this; it is not needed." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "무제한 돈 도시를 일반으로 변환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "For cities started with <무제한 돈>.\nWhile that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\nButton is <disabled/greyed-out> unless the loaded city is an <무제한 돈> type\nand <무제한 돈 변환기> is ON [ ✓ ].\nMake a backup save, and use at your own risk; City Watchdog 되돌릴 수 없습니다 this conversion." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert this city from 무제한 돈 to normal limited money?\nSave a backup FIRST; City Watchdog 되돌릴 수 없습니다 this.\nAre you sure?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "모드 이름" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "버전" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "열기 the author's Paradox Mods page." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "디버그 보고서를 로그에 작성" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<Not needed for normal gameplay.>\nFor testers and post game-patch checks: writes a <Logs/CityWatchdog.log> report\ncomparing live game notification prefabs with the notification icons Watchdog currently controls." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "열기s </Logs/CityWatchdog.log> if it exists.\nIf the log file is missing, opens the Logs/ folder instead." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
