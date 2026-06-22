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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "동작"},
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "돈"},
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "단축키"},
                { m_Settings.GetOptionTabLocaleID(Setting.About), "정보"},
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "디버그"},

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "사용법"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "알림"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "새 도시 시작 설정"},
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "도시 내 정보 보기"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "돈"},
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "저장 변환"},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "진단"},
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "단축키"},

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "설명 표시"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "아래 사용 설명을 표시하거나 숨깁니다."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<표시 토글>\n" +
                    "1. [i] 버튼: 건물, 시민, 도구, 하단 메뉴 아이콘 등 게임의 모든 마우스오버 툴팁을 숨기거나 표시합니다.\n" +
                    "2. 도로 이름 버튼: 도로 이름을 숨기거나 표시합니다. 단축키: \\.\n" +
                    "3. 도로 화살표 버튼: 일방통행 화살표를 강제로 표시/숨김합니다(도로 이름도 숨깁니다).\n" +
                    "4. CWD 제목 표시줄 아이콘: City Watchdog 패널 툴팁을 표시/숨김합니다.\n" +
                    "\n" +
                    "<알림 아이콘>\n" +
                    "1. 왼쪽 위 City Watchdog 버튼을 누르거나 Shift+N으로 패널을 엽니다.\n" +
                    "2. 정렬 버튼으로 오름차순/내림차순을 바꿉니다.\n" +
                    "3. Toggle All로 전체를 빠르게 끄거나 켜고, 섹션을 펼쳐 개별 변경도 가능합니다.\n" +
                    "4. 아이콘만 숨기며 도시 문제 자체를 해결하지는 않습니다.\n" +
                    "\n" +
                    "<돈 도우미>\n" +
                    "1. 돈 추가/차감: 기본 키 [ 와 ] 를 사용합니다.\n" +
                    "2. 자동 돈 추가는 도시 잔액이 설정한 한도 아래로 내려가면 돈을 추가합니다.\n" +
                    "3. 무제한 돈 저장 변환은 무제한 돈으로 시작한 도시에만 사용하며 <되돌릴 수 없습니다>.\n" +
                    "\n" +
                    "<하단 메뉴 툴팁>\n" +
                    "Money View는 돈과 인구 툴바에 추세값과 마우스오버 세부 정보를 추가합니다.\n" +
                    "\n" +
                    "<사용자 지정 Milestone>\n" +
                    "도시를 불러오거나 시작하기 전에 새 도시 시작 설정에서 초기 돈과 Milestone을 설정하세요."},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), ""},

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "알림 아이콘 토글"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "게임 내 <[TOGGLE ALL]> 버튼과 같은 동작의 <단축키>입니다.\n" +
                    "목록의 모든 알림 아이콘을 즉시 표시하거나 숨깁니다."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "모든 알림 아이콘 즉시 표시/숨김"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "알림 패널 열기/닫기"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "도시 안에서\n" +
                    "<알림 패널>을 열거나 닫는 <단축키>입니다.\n" +
                    "왼쪽 위 버튼과 같습니다."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "알림 패널 열기/닫기"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "도로 이름 숨기기/표시"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "기본 도로 이름 라벨을 즉시 숨기거나 표시합니다.\n" +
                    "City Watchdog 패널 도구 모음의 도로 이름 아이콘과 같습니다."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "도로 이름 숨기기/표시"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "모든 마우스오버 툴팁 비활성화"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "건물, 시민, 도구, 하단 메뉴 아이콘 등 게임의 모든 툴팁을 숨기거나 표시합니다.\n" +
                    "<City Watchdog의 돈/인구 팝업은 유지됩니다>; Money View에서 제어합니다.\n" +
                    "City Watchdog 패널의 [i] 아이콘과 같습니다."},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "모든 게임 툴팁 숨기기/표시"},

                // --------------------------------------------------------------------
                // Actions tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "초기 돈"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "새 <제한된 돈> 도시 또는 처음 불러온 도시의 시작 잔액을 설정하고,\n" +
                    "적용 후 Game Default로 돌아갑니다.\n" +
                    "도시가 이미 불러와져 있으면 비활성화됩니다.\n" +
                    "도시를 시작/불러오기 전에 설정하고, 이후에는 <돈 단축키 금액> 또는 <자동 돈 추가>를 사용하세요."},
                { m_Settings.GetOptionLocaleID("GameDefault"), "게임 기본값"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Milestone 선택기"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "도시를 불러오거나 시작하기 <전>에 켜면, 도시 로드 후 선택한 Milestone을 바로 해제합니다.\n" +
                    "도시가 불러와진 상태에서는 켤 수 없지만, 실수로 켜져 있으면 끌 수 있습니다.\n" +
                    "잊었다면 게임을 다시 시작하고 도시 진입 전에 선택하세요.\n" +
                    "City Watchdog은 저장된 Milestone 변경을 되돌릴 수 없습니다. 필요하면 이전 저장을 사용하세요."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "다음 도시 로드 때 해제할 Milestone을 선택합니다.\n" +
                    "도시가 불러와져 있지 않고 [Milestone 선택기] [ ✓ ] 가 켜진 경우에만 변경할 수 있습니다."},

                // --------------------------------------------------------------------
                // Money tab - In City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "돈 + 인구 ToolTips 표시"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<사용 권장>\n" +
                    "하단 메뉴: 돈과 인구 화살표 옆에 추세값을 표시합니다.\n" +
                    "가벼운 마우스오버 표시 기능이며 <표시 전용>입니다.\n" +
                    "게임 정보 패널을 여는 것보다 빠르고 가벼울 수 있습니다."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 빈도"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "하단 툴바 추세 텍스트가 돈과 인구를 시간별 또는 월별로 표시할지 선택합니다.\n" +
                    "월별은 예산 수입-지출과 24시간 인구 예측을 사용합니다."},
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "시간별 (/h)"},
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "월별 (/mo)"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "돈 툴팁 스타일"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "돈 툴팁에 표시할 세부 정보 양을 선택합니다.\n" +
                    "Compact = 첫 설치 기본값.\n" +
                    "<Mini>는 /mo 및 /h의 Net 값 2개만 표시합니다.\n" +
                    "<Compact>는 큰 값을 짧게 표시합니다.\n" +
                    "<Full data>는 긴 값과 Total 필드를 표시합니다."},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "전체 데이터"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "돈 글꼴 크기"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Money View 툴팁 숫자의 <글꼴 크기>를 조정합니다.\n" +
                    "게임 기본값 = 100%\n" +
                    "<모드 기본값 = 120%>\n" +
                    "화면 아래 돈에 마우스를 올리세요."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "인구 글꼴 크기"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "인구 툴팁 숫자의 <글꼴 크기>를 조정합니다.\n" +
                    "게임 기본값 = 100%\n" +
                    "<모드 기본값 = 120%>\n" +
                    "화면 아래 인구에 마우스를 올리세요."},

                // --------------------------------------------------------------------
                // Money tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "돈 단축키 금액"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "돈 추가/차감 단축키에 사용할 금액입니다.\n" +
                    "<모드 기본값 = 40,000>\n" +
                    "도시 안에서 단축키를 사용하지 않으면 아무 일도 하지 않습니다.\n" +
                    "자동으로 하려면 자동 돈 추가를 켜세요."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "돈 추가"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "도시 안에서 <돈 추가> 단축키입니다."},
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "돈 추가"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "돈 차감"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "도시 안에서 <돈 차감> 단축키입니다."},
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "돈 차감"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "자동 돈 추가"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "활성화 [ ✓ ] 시 City Watchdog이 도시가 로드된 동안 잔액을 확인합니다.\n" +
                    "- 잔액이 <임계값 아래>이면\n" +
                    "  선택한 자동 금액을 추가합니다.\n" +
                    "- 필요할 때 수동 단축키 (<[> 또는 <]>) 사용을 권장하지만 이 옵션도 제공됩니다."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "자동 돈 임계값"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "자동 돈 추가가 켜져 있고 잔액이 이 값 아래로 내려가면\n" +
                    "선택한 자동 금액을 추가합니다."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "자동 돈 금액"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "자동 실행 때마다 추가되는 금액입니다.\n" +
                    "임계값을 안전하게 넘길 수 있는 값을 선택하세요."},

                // --------------------------------------------------------------------
                // Money tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "무제한 돈 변환기"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<먼저 도시 백업을 만드세요>.\n" +
                    "무제한 돈으로 시작한 도시를 일반 예산 도시로 변환합니다.\n" +
                    "로드된 도시가 <무제한 돈> 유형이면 <[무제한 돈 저장 변환]> 버튼이 활성화됩니다.\n" +
                    "City Watchdog은 이 변환을 되돌릴 수 없습니다."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "무제한 돈 도시를 일반 도시로 변환"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<무제한 돈>으로 시작한 도시용입니다.\n" +
                    "해당 도시가 로드된 동안 저장을 일반 제한 예산으로 변환합니다.\n" +
                    "도시가 <무제한 돈> 유형이고 <무제한 돈 변환기>가 ON [ ✓ ] 일 때만 버튼이 활성화됩니다.\n" +
                    "백업 후 본인 책임으로 사용하세요."},

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "이 도시를 무제한 돈에서 일반 제한 돈으로 변환할까요?\n" +
                    "먼저 백업하세요. City Watchdog은 되돌릴 수 없습니다.\n" +
                    "계속할까요?"},

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "모드 이름"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "이 모드의 표시 이름입니다."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "버전"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "현재 모드 버전입니다."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "작성자의 Paradox Mods 페이지를 엽니다."},

                // --------------------------------------------------------------------
                // Debug tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "로그에 디버그 보고서 작성"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<일반 플레이에는 필요하지 않습니다.>\n" +
                    "테스터 및 패치 후 확인용으로 <Logs/CityWatchdog.log>에 보고서를 기록합니다."},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "</Logs/CityWatchdog.log>가 있으면 엽니다.\n" +
                    "없으면 Logs/ 폴더를 엽니다."},
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
