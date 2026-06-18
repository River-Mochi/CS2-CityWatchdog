// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleKO.cs
// Purpose: Korean (ko-KR) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "동작" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "단축키" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "정보" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "디버그" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "정보 보기" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "돈" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "알림" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "마일스톤" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "저장 변환" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "단축키" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "진단" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "사용법" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "마우스 오버 시 세부 정보 표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "하단 도구 모음의 기본 돈 및 인구 화살표 옆에 숫자 추세 값을 표시합니다.\n가벼운 도구 모음 마우스 오버 <표시 전용> 기능이며,\n도시의 돈이나 인구를 변경하지 않습니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 빈도" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "하단 도구 모음의 추세 텍스트에 돈과 인구의 시간별 또는 월별 값을 표시할지 선택합니다.\n월별 돈은 예산 수입에서 지출을 뺀 값을 사용하고, 인구는 24시간 예측을 사용합니다." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "시간별 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "월별 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "돈 툴팁 스타일" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "돈 마우스 오버 툴팁에 표시할 세부 정보 양을 선택합니다.\n컴팩트 = 첫 설치 기본값.\n<미니>는 /mo 및 /h의 순이익 값 2개만 표시합니다.\n<컴팩트>는 큰 값을 줄여 표시합니다(15,212,318 대신 15.21M).\n<전체 데이터>는 긴 값과 총계 필드를 표시합니다." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "미니" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "컴팩트" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "전체 데이터" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "돈 글꼴 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Money View 툴팁 숫자의 <글꼴 크기>를 조정합니다.\n게임 기본값 = 100%\n<모드 기본값 = 120%>\n화면 아래의 돈 위에 마우스를 올리세요.\n게임의 작은 툴팁이 보기 어려운 플레이어를 위해 요청된 기능입니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "인구 글꼴 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "인구 툴팁 숫자의 <글꼴 크기>를 조정합니다.\n게임 기본값 = 100%\n<모드 기본값 = 120%>\n화면 아래의 인구 위에 마우스를 올리세요." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "돈 단축키 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "이 금액을 돈 추가 및 돈 차감 단축키와 함께 사용합니다.\n<모드 기본값 = 40,000>\n도시에서 단축키로 돈을 추가/차감하지 않으면 아무 작업도 하지 않습니다.\n자동 돈 추가를 사용하려면 자동 돈 추가 옵션을 켜세요." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "도시 안에서 <돈 추가>를 실행하는 단축키입니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "돈 추가" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "돈 차감" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "도시 안에서 <돈 차감>을 실행하는 단축키입니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "돈 차감" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "자동 돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "활성화 [ ✓ ] 시 City Watchdog은 도시가 로드된 동안 도시 잔고를 확인합니다.\n- 잔고가 <임계값 아래>이면 \n  선택한 자동 금액을 추가합니다.\n- 필요할 때는 이 자동 옵션보다 단축키(<[> 또는 <]>)로 수동 돈 기능을 사용하는 것을 권장하지만, 원하면 사용할 수 있습니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "자동 돈 임계값" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "자동 돈 추가가 켜져 있고 도시 잔고가 이 값 아래로 떨어지면,\n선택한 자동 금액을 추가합니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "자동 돈 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "자동 돈 추가가 실행될 때마다 추가되는 금액입니다.\n도시가 안전하게 임계값 위로 올라갈 만큼 큰 값을 선택하세요." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "초기 돈" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "새 <제한된 돈> 도시 또는 처음 로드된 도시의 시작 잔고를 설정하고,\n적용 후 게임 기본값으로 돌아갑니다.\n도시가 이미 로드되어 있으면 회색으로 비활성화됩니다.\n도시 시작/로드 전에 설정 → 한 번 적용 → 이후에는 <돈 단축키 금액> 또는 <자동 돈 추가>를 사용하세요." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "게임 기본값" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "알림 아이콘 전환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<단축키>는 게임 내 <[TOGGLE ALL]> 아이콘 버튼과 같은 동작을 합니다.\n나열된 모든 도시 알림 아이콘을 즉시 표시하거나 숨깁니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "모든 알림 아이콘 즉시 표시/숨기기" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "알림 패널 열기/닫기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<단축키>로 도시의\n<알림 패널>을 열거나 닫습니다.\n왼쪽 위 아이콘을 클릭해 전체 패널을 여는 것과 같습니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "알림 패널 열기/닫기" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "도로 이름 숨기기/표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<단축키>로 도시의 기본 도로 이름 라벨을 즉시 숨기거나 표시합니다.\nCity Watchdog 패널 도구 모음의 도로 이름 아이콘을 클릭하는 것과 같습니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "도로 이름 숨기기/표시" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "모든 마우스 오버 툴팁 비활성화" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "게임의 마우스 오버 툴팁을 끕니다. 건물/시민/도구 위에서 커서를 따라다니는 툴팁과 게임 UI 버튼의 작은 팝업(상단 바 이름, 기본 버튼 등)을 모두 포함합니다.\n<City Watchdog 자체 돈/인구 팝업은 계속 켜져 있습니다>; 위의 Money View 옵션으로 제어됩니다.\n도시 안의 City Watchdog 패널에서 [i] 아이콘을 클릭하는 것과 같습니다." },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "마일스톤 선택기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "도시를 불러오거나 시작하기 전에 활성화하면 도시가 로드된 직후 선택한 마일스톤을 즉시 잠금 해제합니다.\n도시가 로드된 동안에는 켤 수 없지만, 실수로 켜져 있었다면 끌 수 있습니다.\nCity Watchdog은 이미 도시 저장에 반영된 마일스톤 변경을 되돌릴 수 없습니다. 필요하면 이전 저장을 사용하세요." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "마일스톤" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "다음 도시 로드 시 잠금 해제할 마일스톤 레벨을 선택합니다.\n로드된 도시 밖에서만 조정할 수 있으며, [마일스톤 선택기]가 활성화 [ ✓ ]된 후에만 가능합니다." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "무제한 돈 변환기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<먼저 도시를 백업하세요>.\n무제한 돈으로 시작한 도시를 일반 돈 도전이 있는 정상 도시로 변환합니다.\n로드된 도시가 <무제한 돈> 유형일 때 이 옵션을 켜면 <[무제한 돈 저장 변환]> 버튼이 잠금 해제됩니다.\nCity Watchdog은 이 변환을 되돌릴 수 없습니다.\n일반 도시라면 걱정하지 않아도 됩니다. 필요 없습니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "무제한 돈 저장 도시를 일반으로 변환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "<무제한 돈>으로 시작한 도시용입니다.\n해당 도시가 로드되어 있을 때 저장을 일반 제한 돈 예산으로 변환하여 도시가 다시 일반 돈 도전을 갖게 합니다.\n버튼은 로드된 도시가 <무제한 돈> 유형이고\n<무제한 돈 변환기>가 ON [ ✓ ]일 때만 <활성화/회색 해제>됩니다.\n백업 저장을 만들고 본인 책임하에 사용하세요. City Watchdog은 이 변환을 되돌릴 수 없습니다." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "이 도시를 무제한 돈에서 일반 제한 돈으로 변환하시겠습니까?\n먼저 백업을 저장하세요. City Watchdog은 되돌릴 수 없습니다.\n확실합니까?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "모드 이름" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "이 모드의 표시 이름입니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "버전" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "현재 모드 버전입니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "작성자의 Paradox Mods 페이지를 엽니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "디버그 보고서를 로그로" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<일반 플레이에는 필요하지 않습니다.>\n테스터 및 게임 패치 후 확인용: <Logs/CityWatchdog.log> 보고서를 작성하여\n실제 게임 알림 프리팹과 Watchdog이 현재 제어하는 알림 아이콘을 비교합니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "</Logs/CityWatchdog.log>가 있으면 엽니다.\n로그 파일이 없으면 대신 Logs/ 폴더를 엽니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "지침 표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "아래 사용 지침을 표시하거나 숨깁니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<알림 패널>\n1. City Watchdog 버튼(왼쪽 위)을 클릭하거나 Shift+N을 눌러 패널을 엽니다.\n2. ASC/DESC로 정렬합니다.\n3. Toggle All로 빠르게 전체 Off/On하거나, 섹션을 펼쳐 특정 아이콘을 변경합니다.\n4. 아이콘만 표시하거나 숨깁니다. 도시의 근본 문제를 해결하지는 않습니다.\n\n<돈 도우미>\n1. 돈 추가 또는 차감: 기본 <돈 단축키 금액>을 [ 또는 ]로 사용합니다.\n2. 자동 돈 추가는 도시가 로드된 동안 예산을 확인하고 임계값 아래일 때 돈을 추가합니다.\n3. Money View는 돈 및 인구 도구 모음과 마우스 오버 툴팁에 숫자 값을 추가합니다.\n4. 무제한 돈 저장 변환은 무제한 돈으로 시작한 도시 전용이며 <되돌릴 수 없습니다>.\n\n<사용자 지정 마일스톤>\n도시를 로드하거나 시작하기 전에 옵션 메뉴에서 초기 돈을 설정하고 마일스톤을 선택하세요." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
