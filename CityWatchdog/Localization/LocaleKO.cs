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

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleKO(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (도시 파수꾼)";

            Dictionary<string, string> entries = new()
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kActions), "동작" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMiniHudTab), "미니 HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMoneyTab), "도시 시작" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kAbout), "정보" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutUsage), "사용법" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kNotifications), "알림" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoneyViewGroup), "도시 정보 보기" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMiniHudGroup), "미니 HUD 알림" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "새 도시 시작 설정" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "돈" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "무제한 저장 변환" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "진단" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "설명 보기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "아래 사용 설명을 보이거나 숨깁니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. 도시 왼쪽 위 발바닥 아이콘 또는 Shift+N으로 메인 패널을 엽니다.\n" +
                    "<표시 토글>\n" +
                    "1. 제목 아이콘: City Watchdog 툴팁 표시/숨김.\n" +
                    "\n" +
                    "2. **[i]** 버튼: 건물, 시민, 도구, 하단 메뉴 아이콘 등 게임 호버 툴팁을 <전부> 표시/숨김.\n" +
                    "3. 도로 버튼: 도로 이름 표시/숨김. 단축키: \\.\n" +
                    "4. 구역 버튼: 구역 이름 표시/숨김.\n" +
                    "5. 도로 화살표 버튼: 일방통행 화살표 표시/숨김(도로 이름도 숨김).\n" +
                    "\n" +
                    "<알림 경고>\n" +
                    "1. 정렬 버튼: A→Z, Z→A, 활성 목록만.\n" +
                    "2. <[0/63]> = 표시 아이콘/전체. 클릭하면 모든 줄 펼침/접기.\n" +
                    "3a. [아이콘 표시]는 문제 경고 아이콘을 모두 즉시 숨김/표시합니다.\n" +
                    "3b. 프리셋 [1 | 2]: 클릭해 불러오기, 1초 길게 눌러 현재 체크 상태 저장.\n" +
                    "3c. 아이콘을 숨겨도 도시 문제는 해결되지 않습니다.\n" +
                    "\n" +
                    "<도우미>\n" +
                    "1. 돈 추가 / 빼기: <돈 단축키 금액> 기본키 <[ 또는 ]> 사용.\n" +
                    "2. 자동 돈은 도시 돈이 설정한 한도 아래로 내려가면 돈을 추가합니다.\n" +
                    "3. 무제한 돈 저장 변환은 무제한 돈으로 시작한 도시 전용이며 <되돌릴 수 없습니다>.\n" +
                    "\n" +
                    "<하단 메뉴 툴팁>\n" +
                    "돈 보기는 돈/인구에 마우스를 올릴 때 추세 같은 추가 정보를 보여줍니다.\n" +
                    "\n" +
                    "<사용자 마일스톤>\n" +
                    "도시 시작에서 도시 로드/시작 전에 초기 돈 또는 마일스톤을 설정합니다."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "알림 아이콘 토글" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "게임 내 <[아이콘 표시]> 버튼과 같은 동작의 <단축키>.\n" +
                    "문제 경고 아이콘을 모두 즉시 표시/숨김합니다."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "문제 경고 아이콘 즉시 표시/숨김" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "알림 패널 열기/닫기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "도시에서 <알림 패널>을\n" +
                    "열거나 닫는 <단축키>.\n" +
                    "왼쪽 위 아이콘 클릭과 같습니다."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "알림 패널 열기/닫기" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "버튼만으로 시작" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "켜짐 [ ✓ ]이면 City Watchdog이 작은 버튼 전용 보기로 먼저 열립니다.\n" +
                    "제목 화살표나 줄 수 버튼으로 전체 패널을 엽니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "도로 이름 숨김/표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<단축키>로 기본 게임 도로 이름을 즉시 숨김/표시.\n" +
                    "City Watchdog 패널의 도로 이름 아이콘과 같습니다."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "도로 이름 숨김/표시" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "모든 호버 툴팁 끄기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<단축키>로 건물, 시민, 도구, 하단 아이콘 등 게임 호버 툴팁을 전부 숨김/표시.\n" +
                    "<City Watchdog 돈/인구 팝업은 유지>; 돈 보기가 제어합니다.\n" +
                    "City Watchdog 패널의 [i] 아이콘과 같습니다."
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "게임 호버 툴팁 숨김/표시" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "게임 UI 크게" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "활성화 [ ✓ ]하면 게임과 모드의 <전체 인터페이스>가 크게 표시됩니다.\n" +
                    "<--developerMode> 실행 옵션 없이 게임의 <인터페이스 크기 조절>을 사용합니다.\n" +
                    "이 [x] 체크박스는 City Watchdog 제목 표시줄의 크기 조절 버튼과 동기화됩니다.\n" +
                    "글자만 바꾸려면: 옵션 > 인터페이스 > <텍스트 크기 조절>.\n" +
                    "City Watchdog을 제거해도 직접 끌 때까지 유지됩니다.\n" +
                    "- 제거 전에 끄면 기본 크기로 돌아갑니다.\n" +
                    "- 또는 <--developerMode>로 한 번 실행한 뒤 옵션 > 인터페이스 > 인터페이스 크기 조절 (dev)을 끄세요."
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "메인 패널 불투명도" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "기본 알림 패널 배경의 투명도를 조정합니다.\n" +
                    "값이 낮을수록 투명하고, 높을수록 어둡고 불투명합니다."
                },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "돈 추세 + 인구 툴팁" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<추천>\n" +
                    "하단 메뉴: <돈/인구 화살표>에 추세 값을 표시.\n" +
                    "가벼운 호버 기능 <표시만>;\n" +
                    "게임 정보 패널을 여는 것보다 빠르고 가벼울 수 있습니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "돈 보기 주기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "하단 표시의 돈/인구 추세를 시간별 또는 월별로 선택합니다.\n" +
                    "월별은 수입-지출과 24시간 인구 예측을 사용합니다."
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "시간별 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "월별 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "돈 툴팁 스타일" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "돈 호버 툴팁의 정보량을 선택합니다.\n" +
                    "간단 = 첫 설치 기본값.\n" +
                    "<미니>는 /mo와 /h 순수익 2개만 표시.\n" +
                    "<간단>은 큰 숫자를 줄여 표시(15.21M 등).\n" +
                    "<전체 데이터>는 긴 값과 합계를 표시."
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "미니" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "간단" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "전체 데이터" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "돈 글자 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "돈 보기 숫자의 <글자 크기>를 조절합니다.\n" +
                    "게임 기본 = 100%\n" +
                    "<모드 기본 = 120%>\n" +
                    "화면 아래 돈 위에 마우스를 올리세요.\n" +
                    "작은 툴팁이 보기 힘든 플레이어용."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "인구 글자 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "인구 툴팁 숫자의 <글자 크기>를 조절합니다.\n" +
                    "게임 기본 = 100%\n" +
                    "<모드 기본 = 120%>\n" +
                    "화면 아래 인구 위에 마우스를 올리세요."
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "미니 HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "중요 알림 수를 작은 HUD로 표시합니다.\n" +
                    "전체 패널 없이 빠른 알림 바처럼 사용하세요.\n" +
                    "아이콘 클릭 시 해당 문제 위치로 이동.\n" +
                    "같은 아이콘을 계속 클릭하면 위치를 순환 후 처음으로 돌아갑니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "클릭: 빠른 시작" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Mini HUD에 <빠른 시작> 설정을 적용합니다:\n" +
                    "**파란 별 즐겨찾기**의 기본 세트를 추가합니다.\n" +
                    "즐겨찾기 모드에서는 **파란 별** 목록의 현재 개수 상위 5개 또는 10개를 표시합니다.\n" +
                    "**파란 별**은 City Watchdog 패널에서 추가/제거합니다.\n" +
                    "설정: 즐겨찾기, 아이콘 5개, 가로, 드래그 가능, 100%, 어두운 패널, 0개 숨김.\n" +
                    "빠른 시작을 다시 실행하면 언제든 이 설정으로 초기화할 수 있습니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "미니 표시창 모드" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "미니 표시창이 사용할 알림 줄을 선택합니다.\n" +
                    "**개수 상위**는 현재 개수가 가장 높은 알림을 보여줍니다.\n" +
                    "**즐겨찾기**는 메인 City Watchdog 패널의 **파란 별** 줄을 사용합니다.\n" +
                    "즐겨찾기는 원하는 만큼 선택할 수 있지만,\n" +
                    "미니 표시창은 그 **파란 별** 목록에서 개수 상위 5개 또는 10개만 보여줍니다."
                },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "개수 상위 알림" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "즐겨찾기" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "아이콘 수" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "미니 HUD가 한 번에 표시할 아이콘 수를 선택합니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "아이콘 크기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "미니 HUD 아이콘과 숫자 크기 조절.\n" +
                    "90% = 작게. 100% = 기본. 더 잘 보려면 최대 130%."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "방향" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "가로줄 또는 세로줄을 선택합니다." },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "가로" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "세로" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "HUD 위치" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "미니 HUD가 나타날 위치를 선택합니다.\n" +
                    "드래그 가능은 도시 UI에서 움직일 수 있습니다."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "상단 중앙" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "상단 오른쪽" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "드래그 가능" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "어두움/유리 스타일" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "미니 HUD 배경 스타일을 선택합니다.\n" +
                    "유리는 투명에서 흐린 흰색으로만 바뀌며 어두워지지 않습니다.\n" +
                    "어두운 패널은 게임 느낌의 어두운 HUD입니다."
                },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "어두운 패널" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "유리 패널" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "배경 불투명도" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "미니 HUD 배경 투명도를 조절합니다.\n" +
                    "낮을수록 투명. 높을수록 진함.\n" +
                    "유리는 더 하얗고, 어두움은 더 진해집니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "0개 알림 숨김" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "켜짐 [ ✓ ]이면 미니 HUD가 카운트 0인 줄을 숨깁니다." },

                // --------------------------------------------------------------------
                // City Start tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "초기 자금" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "다음에 로드할 <제한 자금> 도시(새 도시 또는 기존 도시)의 잔액을 설정합니다.\n" +
                    "한 번 적용되면 게임 기본값으로 돌아갑니다.\n" +
                    "도시가 이미 로드되어 있으면 비활성화됩니다.\n" +
                    "도시 로드/시작 전에 설정하고, 이후에는 필요할 때 <돈 단축키 금액>을 사용하세요."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "게임 기본값" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "마일스톤 선택" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "로드/시작 <전에> 켜면 도시 로드 직후 선택 마일스톤을 해제합니다.\n" +
                    "- 도시 로드 후에는 켤 수 없지만, 실수로 켠 경우 끌 수 있습니다.\n" +
                    "- 잊었다면 게임을 재시작하고 도시 입장 전에 선택.\n" +
                    "- 이미 저장된 마일스톤 변경은 되돌릴 수 없으니 이전 저장 사용."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "마일스톤" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "다음 도시 로드 때 해제할 마일스톤을 선택합니다.\n" +
                    "[마일스톤 선택]이 켜진 [ ✓ ] 상태에서 <도시 밖>에서만 조절 가능.\n" +
                    "도시가 이미 그 단계 이상이면 아무 일도 없습니다.\n" +
                    "선택한 마일스톤이 더 높을 때만 변경됩니다."
                },

                // --------------------------------------------------------------------
                // City Start tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "돈 단축키 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "돈 추가/빼기 단축키에 사용할 금액입니다.\n" +
                    "<모드 기본 = 40,000>\n" +
                    "도시에서 단축키를 쓰지 않으면 아무 효과 없음.\n" +
                    "자동은 자동 돈 옵션을 켜세요."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "도시에서 <돈 추가> 단축키." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "돈 추가" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "돈 빼기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "도시에서 <돈 빼기> 단축키." },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "돈 빼기" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "자동 돈" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "켜짐 [ ✓ ]이면 City Watchdog이 도시 잔액을 확인합니다.\n" +
                    "- 잔액이 <한도 아래>이면 한도에 도달할 만큼 추가합니다.\n" +
                    "- 선택한 자동 돈 금액 이상을 항상 추가합니다.\n" +
                    "- 가끔만 필요하면 수동 단축키 (<[> 또는 <]>) 사용을 권장합니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "자동 돈 한도" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "자동 돈이 켜져 있고 도시 잔액이 이 값 아래로 떨어지면,\n" +
                    "최소한 이 한도에 도달할 때까지 돈을 추가합니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "자동 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "자동 돈이 작동할 때마다 추가되는 최소 금액입니다.\n" +
                    "한도에 도달하려면 더 필요할 경우 City Watchdog이 더 큰 금액을 추가합니다."
                },

                // --------------------------------------------------------------------
                // City Start tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "무제한 돈 변환기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<먼저 도시 백업>.\n" +
                    "무제한 돈으로 시작한 도시를 일반 돈 도전 도시로 변환합니다.\n" +
                    "로드한 도시가 <무제한 돈> 타입이면 <[무제한 돈 저장 변환]> 버튼이 열립니다.\n" +
                    "City Watchdog은 이 변환을 되돌릴 수 없습니다.\n" +
                    "일반 도시는 필요 없습니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "무제한 돈 도시를 일반으로 변환" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "<무제한 돈>으로 시작한 도시용.\n" +
                    "그 도시가 로드된 상태에서 일반 제한 자금 예산으로 변환합니다.\n" +
                    "도시가 <무제한 돈> 타입이고\n" +
                    "<무제한 돈 변환기>가 켜짐 [ ✓ ]일 때만 버튼이 활성화됩니다.\n" +
                    "백업 후 사용하세요. City Watchdog은 되돌릴 수 없습니다."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "이 도시를 무제한 돈에서 일반 제한 자금으로 변환할까요?\n" +
                    "먼저 백업 저장; City Watchdog은 되돌릴 수 없습니다.\n" +
                    "정말 진행할까요?"
                },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "모드 이름" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "이 모드의 표시 이름." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "버전" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "현재 모드 버전." },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "제작자의 Paradox Mods 페이지를 엽니다." },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "진단 보고서 기록" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<일반 플레이에는 필요 없음.>\n" +
                    "테스트와 게임 업데이트 후 확인용: <Logs/CityWatchdog.log>에 보고서를 쓰고\n" +
                    "게임 알림 프리팹과 Watchdog 제어 아이콘을 비교합니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "기록 열기" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "</Logs/CityWatchdog.log>가 있으면 엽니다.\n" +
                    "없으면 Logs/ 폴더를 엽니다."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
