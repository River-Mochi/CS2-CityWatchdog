// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License; you may not use this file except in compliance with this License.
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
            string title = Mod.ModName + " (감시견)";

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
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "정보 표시" },
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
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "하단 툴바의 기본 돈/인구 화살표 옆에 숫자 추세 값을 표시합니다.\n" +
                    "툴바에 가볍게 띄우는 마우스 오버 <표시 전용> 기능입니다.\n" +
                    "도시의 돈이나 인구를 바꾸지 않습니다."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 빈도" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "하단 툴바의 추세 텍스트를 돈과 인구에 대해 시간별 또는 월별 값으로 표시할지 선택합니다.\n" +
                    "월별 돈 값은 예산 수입에서 지출을 뺀 값이며, 인구는 24시간 예측을 사용합니다."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "시간별 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "월별 (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "돈 툴팁 스타일" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "돈 마우스 오버 툴팁에 표시할 세부 정보 양을 선택합니다.\n" +
                    "간단 = 첫 설치 기본값.\n" +
                    "<미니>는 /mo 및 /h의 순수 값 2개만 표시합니다.\n" +
                    "<간단>은 큰 값을 짧게 표시합니다 (15,212,318 대신 15.21M).\n" +
                    "<전체 데이터>는 긴 값과 합계 필드를 표시합니다."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "미니" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "간단" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "전체 데이터" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "돈 글자 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Money View 툴팁 숫자의 <글자 크기>를 조정합니다.\n" +
                    "게임 기본값 = 100%\n" +
                    "<모드 기본값 = 120%>\n" +
                    "화면 하단의 돈 위에 마우스를 올려 보세요.\n" +
                    "게임의 작은 툴팁을 보기 어려운 플레이어 요청으로 추가되었습니다."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "인구 글자 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "인구 툴팁 숫자의 <글자 크기>를 조정합니다.\n" +
                    "게임 기본값 = 100%\n" +
                    "<모드 기본값 = 120%>\n" +
                    "화면 하단의 인구 위에 마우스를 올려 보세요."
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "돈 단축키 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "이 금액은 돈 추가 및 돈 차감 단축키에 사용됩니다.\n" +
                    "<모드 기본값 = 40,000>\n" +
                    "도시 안에서 단축키로 돈을 추가/차감하지 않으면 아무 일도 하지 않습니다.\n" +
                    "자동 돈 추가를 원하면 자동 돈 추가 옵션을 켜세요."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "도시 안에서 <돈 추가>를 실행하는 단축키입니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "돈 추가" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "돈 차감" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "도시 안에서 <돈 차감>을 실행하는 단축키입니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "돈 차감" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "자동 돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "켜짐 [ ✓ ] 상태이면, City Watchdog은 도시가 로드된 동안 도시 잔액을 확인합니다.\n" +
                    "- 잔액이 <기준값 아래>로 내려가면, \n" +
                    "  선택한 자동 금액을 추가합니다.\n" +
                    "- 이 자동 옵션보다는 필요할 때 수동 돈 단축키 (<[> 또는 <]>) 사용을 권장합니다\n" +
                    "  그래도 원하면 이 옵션을 사용할 수 있습니다."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "자동 돈 기준값" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "자동 돈 추가가 켜져 있고 도시 잔액이 이 값 아래로 내려가면,\n" +
                    "선택한 자동 금액을 추가합니다."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "자동 돈 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "자동 돈 추가가 실행될 때마다 더해지는 금액입니다.\n" +
                    "도시를 안전하게 기준값 위로 올릴 만큼 충분히 큰 값을 선택하세요."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "초기 자금" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "새 <제한 자금> 도시 또는 처음 로드하는 도시의 시작 잔액을 설정합니다.\n" +
                    "적용된 후에는 게임 기본값으로 되돌아갑니다.\n" +
                    "이미 도시가 로드되어 있으면 회색으로 비활성화됩니다.\n" +
                    "도시 시작/로드 전에 설정 → 한 번 적용 → 이후에는 <돈 단축키 금액> 또는 <자동 돈 추가>를 사용하세요."
                },
                { m_Settings.GetOptionLocaleID("GameDefault"), "게임 기본값" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "알림 아이콘 전환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "게임 내 <[TOGGLE ALL]> 아이콘 버튼과 같은 동작을 하는 <단축키>입니다.\n" +
                    "목록에 있는 모든 도시 알림 아이콘을 즉시 표시하거나 숨깁니다."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "모든 알림 아이콘 즉시 표시/숨김" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "알림 패널 열기/닫기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "도시 안에서\n" +
                    "<알림 패널>을 열거나 닫는 <단축키>입니다.\n" +
                    "왼쪽 위 아이콘을 클릭해 전체 패널을 여는 것과 같습니다."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "알림 패널 열기/닫기" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "도로 이름 숨김/표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "도시 안의 기본 도로 이름 라벨을 즉시 숨기거나 표시하는 <단축키>입니다.\n" +
                    "City Watchdog 패널 툴바의 도로 이름 아이콘을 클릭하는 것과 같습니다."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "도로 이름 숨김/표시" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "모든 마우스 오버 툴팁 끄기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)),
                    "게임의 마우스 오버 툴팁을 끕니다 — 건물/시민/도구 위에서 커서를 따라오는 툴팁과\n" +
                    "게임 UI 버튼의 작은 팝업(상단 바 이름, 기본 버튼 등)을 모두 포함합니다.\n" +
                    "<City Watchdog 자체 돈/인구 팝업은 계속 켜져 있습니다>; 위의 Money View 옵션으로 제어합니다.\n" +
                    "도시 안 City Watchdog 패널의 [i] 아이콘을 클릭하는 것과 같습니다."
                },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "마일스톤 선택기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "도시를 로드하거나 시작하기 전에 켜면, 도시 로드 직후 선택한 마일스톤을 즉시 해제합니다.\n" +
                    "도시가 로드된 동안에는 켤 수 없지만, 실수로 켜 둔 경우에는 끌 수 있습니다.\n" +
                    "City Watchdog은 이미 도시 저장 파일에 저장된 마일스톤 변경을 되돌릴 수 없습니다. 필요하면 이전 저장 파일을 사용하세요."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "마일스톤" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "다음 도시 로드 때 해제할 마일스톤 레벨을 선택합니다.\n" +
                    "도시가 로드되지 않은 상태에서만, 그리고 [마일스톤 선택기]가 켜짐 [ ✓ ] 상태일 때만 조정할 수 있습니다."
                },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "무제한 자금 변환기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<먼저 도시 백업을 만드세요>.\n" +
                    "무제한 자금으로 시작한 도시를 일반 돈 관리가 있는 정상 도시로 변환합니다.\n" +
                    "이 옵션을 켜면 로드된 도시가 <무제한 자금> 유형일 때 <[무제한 자금 저장 변환]> 버튼이 활성화됩니다.\n" +
                    "City Watchdog은 이 변환을 되돌릴 수 없습니다.\n" +
                    "일반 도시라면 걱정하지 마세요. 이 기능은 필요 없습니다."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "무제한 자금 저장 도시를 일반으로 변환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<무제한 자금>으로 시작한 도시용입니다.\n" +
                    "그 도시가 로드된 동안 저장 파일을 일반 제한 자금 예산으로 변환하여 일반 돈 관리가 다시 적용되게 합니다.\n" +
                    "로드된 도시가 <무제한 자금> 유형이고\n" +
                    "<무제한 자금 변환기>가 ON [ ✓ ] 이 아니면 버튼은 <비활성/회색>입니다.\n" +
                    "백업 저장을 만들고 본인 책임으로 사용하세요. City Watchdog은 이 변환을 되돌릴 수 없습니다."
                },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "이 도시를 무제한 자금에서 일반 제한 자금으로 변환할까요?\n" +
                    "먼저 백업을 저장하세요. City Watchdog은 되돌릴 수 없습니다.\n" +
                    "정말 진행할까요?"
                },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "모드 이름" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "이 모드의 표시 이름입니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "버전" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "현재 모드 버전입니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "제작자의 Paradox Mods 페이지를 엽니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "디버그 보고서를 로그로" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<일반 플레이에는 필요 없습니다.>\n" +
                    "테스터와 게임 패치 후 확인용: <Logs/CityWatchdog.log> 보고서를 작성하여\n" +
                    "실제 게임 알림 프리팹과 Watchdog이 현재 제어하는 알림 아이콘을 비교합니다."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "존재하면 </Logs/CityWatchdog.log>를 엽니다.\n" +
                    "로그 파일이 없으면 대신 Logs/ 폴더를 엽니다."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "사용법 표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "아래 사용법 안내를 표시하거나 숨깁니다." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<표시 전환>\n" +
                    "1. [i] 버튼: 모든 게임 마우스 오버 툴팁 숨김/표시 (건물, 시민, 도구).\n" +
                    "2. 도로 이름 버튼: 도로 이름 라벨 숨김/표시. 단축키: \\.\n" +
                    "3. 도로 화살표 버튼: 일방통행 도로 화살표를 강제로 ON/OFF (도로 이름도 숨김).\n" +
                    "4. CWD 제목 표시줄 아이콘: City Watchdog 패널 툴팁 표시/숨김.\n" +
                    "\n" +
                    "<알림 경고>\n" +
                    "1. City Watchdog 버튼(왼쪽 위)을 클릭하거나 Shift+N을 눌러 패널을 엽니다.\n" +
                    "2. 오름차순/내림차순 정렬 버튼.\n" +
                    "3. Toggle All로 빠르게 모두 Off/On, 또는 섹션을 펼쳐 특정 아이콘을 변경합니다.\n" +
                    "4. 아이콘만 표시하거나 숨깁니다. 도시 문제 자체를 고치지는 않습니다.\n" +
                    "\n" +
                    "<돈 도우미>\n" +
                    "1. 돈 추가 또는 차감: <돈 단축키 금액> 기본 키 [ 및 ] 를 사용합니다.\n" +
                    "2. 자동 돈 추가는 도시가 설정한 한도보다 낮아지면 돈을 추가합니다.\n" +
                    "3. 무제한 자금 저장 변환은 무제한 자금으로 시작한 도시만 대상이며 <되돌릴 수 없습니다>.\n" +
                    "\n" +
                    "<하단 메뉴 툴팁>\n" +
                    "Money View는 돈 및 인구 툴바에 추세 값을 추가하고 마우스 오버 시 추가 정보를 보여 줍니다.\n" +
                    "\n" +
                    "<사용자 지정 마일스톤>\n" +
                    "도시를 로드하거나 시작하기 전에 옵션 메뉴에서 초기 자금과 마일스톤을 설정하세요."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
