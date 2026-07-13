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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "동작" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "미니 HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "자금-마일스톤" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "정보" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "사용법" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "알림" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "도시 정보 표시" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "미니 HUD 알림" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "새 도시 시작 설정" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "자금" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "무제한 자금 저장 변환" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "진단" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "사용법 보기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "아래 사용법 설명을 표시하거나 숨깁니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<표시 토글>\n" +
                    "1. [i] 버튼: 건물, 시민, 도구, 하단 메뉴 아이콘 등 게임의 모든 마우스오버 툴팁을 숨기거나 표시합니다.\n" +
                    "2. 도로명 버튼: 도로 이름 라벨을 숨기거나 표시합니다. 단축키: \\.\n" +
                    "3. 구역명 버튼: 구역 경계는 그대로 두고 이름만 숨기거나 표시합니다.\n" +
                    "4. 도로 화살표 버튼: 일방통행 화살표를 강제로 켜거나 끕니다(도로명도 함께 숨김).\n" +
                    "5. CWD 제목 표시줄 아이콘: City Watchdog 패널 툴팁을 표시/숨김.\n" +
                    "\n" +
                    "<알림 경고>\n" +
                    "1. 왼쪽 위 City Watchdog 버튼을 클릭하거나 Shift+N을 눌러 패널을 엽니다.\n" +
                    "2. 정렬 버튼으로 오름차순/내림차순.\n" +
                    "3. 모두 전환으로 빠르게 전체 끄기/켜기, 또는 섹션을 펼쳐 개별 변경.\n" +
                    "4. 아이콘만 표시/숨김하며 도시 문제 자체는 해결하지 않습니다.\n" +
                    "\n" +
                    "<자금 도우미>\n" +
                    "1. 자금 추가/차감: <자금 단축키 금액>을 사용합니다. 기본 키는 [ 및 ] 입니다.\n" +
                    "2. 자동 자금 추가는 도시 자금이 설정한 한도보다 낮아지면 자금을 추가합니다.\n" +
                    "3. 무제한 자금 저장 변환은 무제한 자금으로 시작한 도시에만 적용되며 <되돌릴 수 없습니다>.\n" +
                    "\n" +
                    "<하단 메뉴 툴팁>\n" +
                    "자금 표시는 하단 자금/인구 툴바에 추세 값과 마우스오버 세부 정보를 추가합니다.\n" +
                    "\n" +
                    "<사용자 지정 마일스톤>\n" +
                    "도시를 불러오거나 시작하기 전에 자금-마일스톤 > 새 도시 시작 설정에서 초기 자금과 마일스톤을 설정하세요." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "알림 아이콘 전환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "게임 내 <[모두 전환]> 아이콘 버튼과 같은 동작의 <단축키>입니다.\n" +
                    "목록의 모든 도시 알림 아이콘을 즉시 표시하거나 숨깁니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "모든 알림 아이콘 즉시 표시/숨김" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "알림 패널 열기/닫기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "도시 안에서\n" +
                    "<알림 패널>을 열거나 닫는 <단축키>입니다.\n" +
                    "왼쪽 위 아이콘 클릭과 같습니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "알림 패널 열기/닫기" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "버튼 전용 보기로 시작" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "활성화 [ ✓ ] 시 왼쪽 위 버튼으로 City Watchdog을 열면 작은 버튼 전용 보기로 시작합니다.\n" +
                    "제목 표시줄 화살표나 행 수 버튼으로 전체 패널을 펼칩니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "도로명 숨김/표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "기본 게임 도로 이름 라벨을 즉시 숨기거나 표시하는 <단축키>입니다.\n" +
                    "City Watchdog 패널 툴바의 도로명 아이콘과 같습니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "도로명 숨김/표시" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "모든 마우스오버 툴팁 끄기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "건물, 시민, 도구, 하단 메뉴 아이콘 등 게임의 모든 마우스오버 툴팁을 즉시 숨기거나 표시하는 <단축키>입니다.\n" +
                    "<City Watchdog 자체 자금/인구 팝업은 계속 켜짐>; 위의 자금 표시 옵션으로 제어합니다.\n" +
                    "City Watchdog 패널의 [i] 아이콘과 같습니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "모든 게임 툴팁 숨김/표시" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "자금 + 인구 툴팁 표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<활성화 추천>\n" +
                    "하단 게임 메뉴: 툴바의 <자금 및 인구 화살표>에 추세 값을 표시합니다.\n" +
                    "가벼운 마우스오버 기능이며 <표시 전용>입니다.\n" +
                    "게임 정보 패널을 여는 것보다 빠르고 성능에도 더 좋을 수 있습니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "자금 표시 주기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "하단 툴바의 추세 텍스트를 자금/인구의 시간별 또는 월별 값으로 표시할지 선택합니다.\n" +
                    "월별은 예산 수입에서 지출을 뺀 값과 24시간 인구 예측을 사용합니다." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "시간별 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "월별 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "자금 툴팁 스타일" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "자금 툴팁에 표시할 세부 정보 양을 선택합니다.\n" +
                    "간단 = 첫 설치 기본값.\n" +
                    "<미니>는 /mo 및 /h 순수익 2개만 표시합니다.\n" +
                    "<간단>은 큰 값을 줄여 표시합니다(15,212,318 대신 15.21M).\n" +
                    "<전체 데이터>는 긴 값과 합계를 표시합니다." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "미니" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "간단" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "전체 데이터" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "자금 글자 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "자금 표시 툴팁 숫자의 <글자 크기>를 조정합니다.\n" +
                    "게임 기본값 = 100%\n" +
                    "<모드 기본값 = 120%>\n" +
                    "화면 아래 자금에 마우스를 올리세요.\n" +
                    "작은 툴팁이 읽기 어려운 플레이어를 위해 추가되었습니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "인구 글자 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "인구 툴팁 숫자의 <글자 크기>를 조정합니다.\n" +
                    "게임 기본값 = 100%\n" +
                    "<모드 기본값 = 120%>\n" +
                    "화면 아래 인구에 마우스를 올리세요." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "미니 HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "중요한 알림 수를 작은 도시 HUD로 표시합니다.\n" +
                    "전체 City Watchdog 패널을 열지 않고 빠른 알림 띠처럼 사용하세요.\n" +
                    "아이콘을 클릭하면 해당 문제 위치로 이동합니다.\n" +
                    "같은 아이콘을 계속 클릭하면 일치하는 위치를 순환하고 처음으로 돌아갑니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "빠른 시작 설정" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "추천 미니 HUD 설정을 적용합니다:\n" +
                    "즐겨찾기, 5개 아이콘, 가로, 상단 중앙, 100% 크기, 어두운 패널.\n" +
                    "0개 알림도 계속 표시됩니다.\n" +
                    "확장된 Watchdog 패널에서 언제든 **파란 별** 즐겨찾기를 추가/제거할 수 있습니다.\n" +
                    "시작용 **파란 별** 즐겨찾기는 **[추천]**에 포함됩니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "미니 HUD 모드" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "미니 HUD가 사용할 알림 행을 선택합니다.\n" +
                    "**상위 활성**은 현재 수가 가장 높은 알림을 표시합니다.\n" +
                    "**즐겨찾기**는 City Watchdog 메인 패널에서 **파란 별**로 표시된 모든 행을 포함합니다.\n" +
                    "즐겨찾기는 원하는 만큼 선택할 수 있지만,\n" +
                    "미니 HUD는 해당 **파란 별 즐겨찾기** 목록에서 현재 수 상위 5개 또는 10개만 표시합니다." },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "상위 활성 알림" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "즐겨찾기" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "아이콘 수" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "미니 HUD가 한 번에 표시할 알림 아이콘 수를 선택합니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "아이콘 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "미니 HUD 아이콘과 숫자의 크기를 조정합니다.\n" +
                    "90% = 작게. 100% = 기본. 더 잘 보이게 130%까지 올릴 수 있습니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "방향" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "미니 HUD 아이콘을 행 또는 열로 배치할지 선택합니다." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "가로" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "세로" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD 위치" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "미니 HUD가 표시될 위치를 선택합니다.\n" +
                    "드래그 가능은 도시 UI에서 이동할 수 있습니다." },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "상단 중앙" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "상단 오른쪽" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "드래그 가능" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "어두운/유리 스타일" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "미니 HUD 배경 스타일을 선택합니다.\n" +
                    "유리 패널은 투명에서 흐린 흰색으로 변하며 더 어두워지지 않습니다.\n" +
                    "어두운 패널은 게임 스타일의 더 어두운 HUD에 사용하세요." },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "어두운 패널" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "유리 패널" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "배경 불투명도" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "미니 HUD 배경 투명도를 조정합니다.\n" +
                    "낮을수록 더 투명합니다. 높을수록 더 진합니다.\n" +
                    "유리는 더 하얗고 흐려집니다. 어두운 패널은 더 진하고 어두워집니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "0개 알림 숨기기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "활성화 [ ✓ ] 시 미니 HUD는 수가 0인 알림 행을 숨깁니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "초기 자금" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "새 <제한 자금> 도시 또는 처음 불러온 도시의 시작 잔액을 설정하고,\n" +
                    "적용 후 게임 기본값으로 되돌립니다.\n" +
                    "이미 도시가 불러와져 있으면 회색으로 비활성화됩니다.\n" +
                    "도시를 시작/불러오기 전에 설정하세요. 한 번 적용된 뒤에는 <자금 단축키 금액> 또는 <자동 자금 추가>를 사용하세요." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "게임 기본값" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "마일스톤 선택" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "<도시를 불러오거나 시작하기 전> 활성화하면 도시 로드 직후 선택한 마일스톤을 해제합니다.\n" +
                    "- 도시가 불러와진 뒤에는 켤 수 없지만, 실수로 켜둔 경우 끌 수 있습니다.\n" +
                    "- 잊고 도시를 불러왔다면 게임을 재시작한 뒤 도시 진입 전에 마일스톤을 선택하세요.\n" +
                    "- 이미 도시에 저장된 마일스톤 변경은 되돌릴 수 없습니다. 필요하면 이전 저장을 사용하세요." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "마일스톤" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "다음 도시 로드 시 해제할 마일스톤 수준을 선택합니다.\n" +
                    "<도시가 불러와져 있지 않을 때만> 조정 가능하며, [마일스톤 선택]이 활성화 [ ✓ ] 된 뒤에만 가능합니다.\n" +
                    "도시가 이미 선택한 마일스톤 이상이면 아무 일도 일어나지 않습니다.\n" +
                    "선택한 마일스톤이 현재보다 높을 때만 변경됩니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "자금 단축키 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "자금 추가 및 자금 차감 단축키에 사용할 금액입니다.\n" +
                    "<모드 기본값 = 40,000>\n" +
                    "도시 안에서 단축키를 사용하지 않으면 아무 일도 하지 않습니다.\n" +
                    "자동화하려면 자동 자금 추가를 켜세요." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "자금 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "도시 안에서 <자금 추가> 단축키입니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "자금 추가" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "자금 차감" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "도시 안에서 <자금 차감> 단축키입니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "자금 차감" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "자동 자금 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "활성화 [ ✓ ] 시 City Watchdog은 도시가 불러와진 동안 잔액을 확인합니다.\n" +
                    "- 잔액이 <기준값 아래>이면\n" +
                    "  선택한 자동 금액을 추가합니다.\n" +
                    "- 이 자동 옵션 대신 필요할 때 수동 자금 단축키(<[> 또는 <]>) 사용을 권장하지만\n" +
                    "  원한다면 사용할 수 있습니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "자동 자금 기준값" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "자동 자금 추가가 활성화되어 있고 도시 잔액이 이 값 아래로 떨어지면,\n" +
                    "선택한 자동 금액이 추가됩니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "자동 자금 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "자동 자금 추가가 발동할 때마다 추가되는 금액입니다.\n" +
                    "도시가 안전하게 기준값 위로 올라가도록 충분한 값을 선택하세요." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "무제한 자금 변환기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<먼저 도시 백업을 만드세요>.\n" +
                    "무제한 자금으로 시작한 도시를 일반 자금 난이도의 도시로 변환합니다.\n" +
                    "불러온 도시가 <무제한 자금> 유형일 때 <[무제한 자금 저장 변환]> 버튼을 잠금 해제합니다.\n" +
                    "City Watchdog은 이 변환을 되돌릴 수 없습니다.\n" +
                    "일반 도시는 신경 쓰지 않아도 됩니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "무제한 자금 도시를 일반으로 변환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "<무제한 자금>으로 시작한 도시용입니다.\n" +
                    "그 도시가 불러와진 동안 저장을 일반 제한 자금 예산으로 변환합니다.\n" +
                    "불러온 도시가 <무제한 자금> 유형이고\n" +
                    "<무제한 자금 변환기>가 켜짐 [ ✓ ] 상태일 때만 버튼이 <활성/비활성> 상태에서 켜집니다.\n" +
                    "백업을 만들고 본인 책임으로 사용하세요. City Watchdog은 되돌릴 수 없습니다." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "이 도시를 무제한 자금에서 일반 제한 자금으로 변환할까요?\n" +
                    "먼저 백업을 저장하세요. City Watchdog은 되돌릴 수 없습니다.\n" +
                    "계속할까요?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "모드 이름" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "이 모드의 표시 이름입니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "버전" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "현재 모드 버전입니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "제작자의 Paradox Mods 페이지를 엽니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "디버그 보고서를 로그에 기록" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<일반 플레이에는 필요 없습니다.>\n" +
                    "테스터 및 게임 패치 후 점검용: <Logs/CityWatchdog.log>에 보고서를 작성하여\n" +
                    "게임의 실제 알림 프리팹과 Watchdog이 제어하는 알림 아이콘을 비교합니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "있으면 </Logs/CityWatchdog.log>를 엽니다.\n" +
                    "로그 파일이 없으면 Logs/ 폴더를 대신 엽니다." },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
