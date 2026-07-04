// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleJA.cs
// Purpose: Japanese (ja-JP) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleJA(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "資金・マイルストーン" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "情報" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使い方" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "都市内情報ビュー" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "Mini HUD 通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新都市開始設定" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "資金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "無限資金セーブ変換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診断" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "説明を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "下の使い方を表示/非表示にします。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<表示切替>\n" +
                    "1. [i] ボタン：ゲーム内の全ホバーツールチップを表示/非表示。\n" +
                    "2. 道路名ボタン：道路名を表示/非表示。ホットキー：\\。\n" +
                    "3. 地区名ボタン：境界は変えずに地区名だけ表示/非表示。\n" +
                    "4. 道路矢印ボタン：一方通行矢印を強制表示/非表示（道路名も非表示）。\n" +
                    "5. CWD タイトルアイコン：City Watchdog パネルのツールチップを表示/非表示。\n\n" +
                    "<通知アラート>\n" +
                    "1. 左上の City Watchdog ボタン、または Shift+N でパネルを開きます。\n" +
                    "2. 並び替えボタン：昇順/降順。\n" +
                    "3. Toggle All で一括オン/オフ。セクションを開けば個別変更できます。\n" +
                    "4. アイコンを隠すだけで、都市の問題自体は解決しません。\n\n" +
                    "<資金ヘルプ>\n" +
                    "1. 資金追加/減額：既定キー [ と ] を使います。\n" +
                    "2. 自動追加は、資金が設定した下限を下回ると追加します。\n" +
                    "3. 無限資金セーブ変換は無限資金で始めた都市専用で、<元に戻せません>。\n\n" +
                    "<下部メニューのツールチップ>\n" +
                    "Money View は資金/人口の傾向値とホバー詳細を追加します。\n\n" +
                    "<カスタム マイルストーン>\n" +
                    "都市を読み込む/開始する前に、初期資金とマイルストーンを設定します。"
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "通知アイコン切替" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<ホットキー> はゲーム内 <[TOGGLE ALL]> ボタンと同じ動作です。\n" +
                    "一覧の都市通知アイコンをすぐに表示/非表示にします。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "全通知アイコンを即時表示/非表示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<ホットキー> で都市内の\n" +
                    "<通知パネル>を開閉します。\n" +
                    "左上アイコンで完全パネルを開くのと同じです。"
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "通知パネルを開く/閉じる" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "ボタンだけで開始" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "有効 [ ✓ ] の場合、左上ボタンから小さいボタン専用表示で開きます。\n" +
                    "タイトルバー矢印か行数ボタンで完全パネルに展開します。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "道路名を非表示/表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<ホットキー> でバニラの道路名ラベルを即時表示/非表示。\n" +
                    "City Watchdog ツールバーの道路名アイコンと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "道路名を非表示/表示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "全マウスオーバーツールチップ無効" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<ホットキー> でゲーム内の全ホバーツールチップを表示/非表示。\n" +
                    "<City Watchdog の資金/人口ポップアップは残ります>。上の Money View で制御します。\n" +
                    "City Watchdog パネル内の [i] アイコンと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "ゲーム内ホバーツールチップを表示/非表示" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "資金 + 人口ツールチップを表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<推奨>\n" +
                    "下部メニュー：資金/人口の矢印に傾向値を表示します。\n" +
                    "軽いツールバーホバー機能です<表示のみ>；\n" +
                    "ゲームの情報パネルを開く手間を減らします。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View 頻度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "下部ツールバーの傾向を時間ごと/月ごとで選びます。\n" +
                    "月次は収入−支出、人口は24時間予測を使います。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "毎時 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "毎月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "資金ツールチップ形式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "資金ツールチップの詳細量を選びます。\n" +
                    "コンパクト = 初回既定。\n" +
                    "<Mini> は /mo と /h の純額2つだけ表示。\n" +
                    "<コンパクト> は大きい数を短縮（15,212,318 → 15.21M）。\n" +
                    "<全データ> は長い値と合計を表示します。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "コンパクト" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "全データ" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "資金フォントサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Money View の数値<フォントサイズ>を調整します。\n" +
                    "ゲーム既定 = 100%\n" +
                    "<Mod 既定 = 120%>\n" +
                    "画面下の資金にマウスを合わせます。\n" +
                    "小さいツールチップが読みにくいプレイヤー向けです。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口フォントサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "人口ツールチップ数値の<フォントサイズ>を調整します。\n" +
                    "ゲーム既定 = 100%\n" +
                    "<Mod 既定 = 120%>\n" +
                    "画面下の人口にマウスを合わせます。"
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "重要な通知数を小さな都市HUDで表示します。\n" +
                    "完全パネルを開かずに素早く確認できます。\n" +
                    "アイコンをクリックすると対応する問題地点へ移動します。\n" +
                    "同じアイコンを押し続けると候補地点を順番に巡回します。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "推奨スターター設定" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "推奨 Mini HUD 設定を適用します：\n" +
                    "お気に入り、5アイコン、横向き、上中央、100%、暗いパネル。\n" +
                    "0件アラートも表示します。\n" +
                    "展開した Watchdog パネルで **青い星** お気に入りを変更できます。\n" +
                    "スターターの **青い星** お気に入りは **[推奨]** に含まれます。"
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "Mini HUD モード" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "Mini HUD が使う通知行を選びます。\n" +
                    "**上位アクティブ** は現在数が多いアラートを表示。\n" +
                    "**お気に入り** はメインパネルで **青い星** の行を使います。\n" +
                    "お気に入りはいくつでも選べますが、\n" +
                    "Mini HUD はその中から上位5または10件だけ表示します。" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "上位アクティブ" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "お気に入り" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "Mini HUD アイコン数" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "Mini HUD に同時表示する通知アイコン数を選びます。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "Mini HUD サイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "Mini HUD のアイコンと数字を拡大/縮小します。\n" +
                    "90% = 小さめ。100% = 既定。見やすくするなら最大130%。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "Mini HUD 向き" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "横一列か縦一列を選びます。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "横" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "縦" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "Mini HUD 位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "Mini HUD の表示位置を選びます。\n" +
                    "ドラッグ可なら都市UI内で移動できます。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "上中央" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "ドラッグ可" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "Mini HUD スタイル" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "Mini HUD の背景スタイルを選びます。\n" +
                    "ガラスは透明から白く曇るだけで暗くなりません。\n" +
                    "暗いパネルは暗めのバニラ風HUDです。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "暗いパネル" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "ガラスパネル" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "Mini HUD 不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "Mini HUD 背景の透明度を調整します。\n" +
                    "低いほど透明。高いほど不透明。\n" +
                    "ガラスは白く曇り、暗いパネルはより濃くなります。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "0件アラートを隠す" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "有効 [ ✓ ] の場合、Mini HUD は件数0の行を隠します。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "新しい<有限資金>都市、または最初に読み込む都市の開始資金を設定し、\n" +
                    "適用後にゲーム既定へ戻します。\n" +
                    "都市が読み込み済みの場合は無効です。\n" +
                    "都市開始/読み込み前に設定。適用後は<資金ホットキー額>または<自動資金追加>を使います。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム既定" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "マイルストーン選択" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "<都市を読み込む/開始する前>に有効化すると、読み込み後に選んだマイルストーンを解除します。\n" +
                    "- 都市読み込み後はオンにできませんが、誤ってオンならオフにできます。\n" +
                    "- 忘れた場合はゲームを再起動し、都市に入る前に選びます。\n" +
                    "- すでに保存されたマイルストーン変更は戻せません。必要なら古いセーブを使ってください。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "マイルストーン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "次回読み込み時に解除するマイルストーンを選びます。\n" +
                    "<都市未読み込み時のみ>、かつ [マイルストーン選択] が有効 [ ✓ ] の時だけ調整できます。\n" +
                    "都市がすでに同等以上なら何も起きません。\n" +
                    "選択したものが現在より高い場合だけ変更されます。"
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "資金ホットキー額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "資金追加/減額ホットキーで使う金額です。\n" +
                    "<Mod 既定 = 40,000>\n" +
                    "都市内でホットキーを使わない限り何もしません。\n" +
                    "自動なら、自動資金追加を有効にします。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "資金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "都市内で <資金追加> するホットキー。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "資金追加" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "資金減額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "都市内で <資金減額> するホットキー。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "資金減額" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動資金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "有効 [ ✓ ] の場合、City Watchdog は都市の残高を確認します。\n" +
                    "- 残高が<しきい値未満>なら、\n" +
                    "  選択した金額を追加します。\n" +
                    "- 必要時に手動ホットキー（<[> または <]>）を使うのがおすすめです" +
                    "  が、自動オプションも用意しています。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動資金しきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "自動資金追加が有効で残高がこの値を下回ると、\n" +
                    "選択した金額を追加します。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動資金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "自動発動ごとに追加する金額。\n" +
                    "しきい値を安全に超える額を選んでください。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<先に都市をバックアップしてください>。\n" +
                    "無限資金で始めた都市を通常の資金チャレンジ都市へ変換します。\n" +
                    "<無限資金>タイプの都市で <[無限資金セーブ変換]> ボタンを有効にします。\n" +
                    "City Watchdog はこの変換を元に戻せません。\n" +
                    "通常都市なら不要です。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "無限資金セーブ都市を通常へ変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<無限資金>で開始した都市用です。\n" +
                    "その都市を読み込んだ状態で、通常の有限資金予算へ変換します。\n" +
                    "読み込み中の都市が <無限資金> タイプでない場合、ボタンは<無効/グレー>です\n" +
                    "さらに <無限資金コンバーター> がオン [ ✓ ] である必要があります。\n" +
                    "バックアップして自己責任で使用してください。City Watchdog は戻せません。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "この都市を無限資金から通常の有限資金へ変換しますか？\n" +
                    "先にバックアップしてください。City Watchdog は元に戻せません。\n" +
                    "本当によろしいですか？" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod 名" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "この Mod の表示名。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "現在の Mod バージョン。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "作者の Paradox Mods ページを開きます。" },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "デバッグ報告をログへ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<通常プレイでは不要です。>\n" +
                    "テストやゲーム更新後確認用：<Logs/CityWatchdog.log> に報告を書き込みます\n" +
                    "ゲーム内通知 prefab と Watchdog が制御する通知アイコンを比較します。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "存在すれば </Logs/CityWatchdog.log> を開きます。\n" +
                    "ログがない場合は Logs/ フォルダーを開きます。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
