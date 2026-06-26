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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "アクション" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "資金・マイルストーン" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "情報" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使い方" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "都市内情報ビューアー" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "ミニHUD通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新しい都市の開始設定" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "資金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "無制限セーブを変換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診断" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "説明を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "下の使い方説明を表示または非表示にします。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<表示切り替え>\n" +
                    "1. [i] ボタン: 建物、市民、ツール、下部メニューアイコンなど、ゲームのホバーツールチップをすべて非表示/表示します。\n" +
                    "2. 道路名ボタン: 道路名ラベルを非表示/表示します。ホットキー: \\。\n" +
                    "3. 地区名ボタン: 地区の境界を変えずに地区名ラベルを非表示/表示します。\n" +
                    "4. 道路矢印ボタン: 一方通行矢印を強制的にオン/オフします（道路名も非表示になります）。\n" +
                    "5. CWD タイトルバーアイコン: City Watchdog パネルのツールチップを表示/非表示します。\n" +
                    "\n" +
                    "<通知アラート>\n" +
                    "1. 左上の City Watchdog ボタンをクリックするか Shift+N を押して、パネルを開きます。\n" +
                    "2. 昇順/降順の並べ替えボタン。\n" +
                    "3. Toggle All ですべてをすばやくオフ/オン、またはセクションを展開して個別に変更できます。\n" +
                    "4. アイコンを表示/非表示するだけで、都市の問題そのものは修正しません。\n" +
                    "\n" +
                    "<資金ヘルパー>\n" +
                    "1. 資金の追加/減少: <資金ホットキー額> を標準キー [ と ] で使います。\n" +
                    "2. 自動資金追加は、都市の資金が設定した下限を下回ると資金を追加します。\n" +
                    "3. 無制限資金セーブの変換は、無制限資金で開始した都市専用で、<元に戻せません>。\n" +
                    "\n" +
                    "<下部メニューのツールチップ>\n" +
                    "Money View は資金と人口のツールバーに傾向値を追加し、ホバー時に詳細を表示します。\n" +
                    "\n" +
                    "<カスタム マイルストーン>\n" +
                    "都市を読み込む/開始する前に、資金・マイルストーン > 新しい都市の開始設定で初期資金とマイルストーンを設定します。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "通知アイコンを切り替え" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "ゲーム内の <[TOGGLE ALL]> ボタンと同じ動作の<ホットキー>です。\n" +
                    "一覧の通知アイコンをすぐに表示/非表示にします。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "すべての通知アイコンを即時表示/非表示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "都市内で\n" +
                    "<通知パネル>を開閉する<ホットキー>です。\n" +
                    "左上アイコンのクリックと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "通知パネルを開く/閉じる" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "道路名を非表示/表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "バニラの道路名ラベルをすぐに非表示/表示します。\n" +
                    "City Watchdog パネルの道路名アイコンと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "道路名を非表示/表示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "すべてのマウスオーバーツールチップを無効化" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "建物、市民、ツール、下部メニューアイコンなど、ゲーム内すべてのホバーツールチップを非表示/表示します。\n" +
                    "<City Watchdog のお金/人口ポップアップは残ります>。これは Money View で制御します。\n" +
                    "City Watchdog パネルの [i] アイコンと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "ゲームの全ツールチップを非表示/表示" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "お金 + 人口 ToolTips を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<有効推奨>\n" +
                    "下部メニュー: お金と人口の矢印に傾向値を表示します。\n" +
                    "軽量なホバー表示機能で<表示のみ>です。\n" +
                    "情報ビューを開くより早く、軽い場合があります。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View の頻度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "お金と人口の傾向値を時間単位または月単位で表示するか選びます。\n" +
                    "月単位では予算収入－支出と、人口の24時間予測を使います。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "毎時 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "毎月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "お金ツールチップの形式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "お金ツールチップに表示する詳細量を選びます。\n" +
                    "Compact = 初回インストール時の既定。\n" +
                    "<Mini> は /mo と /h の Net 2値のみ。\n" +
                    "<Compact> は大きな値を短縮します。\n" +
                    "<Full data> は長い値と Total 項目を表示します。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Full data" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "お金のフォントサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Money View の数値フォントサイズを調整します。\n" +
                    "ゲーム既定 = 100%\n" +
                    "<Mod 既定 = 120%>\n" +
                    "画面下のお金にマウスを合わせます。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口のフォントサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口ツールチップの数値フォントサイズを調整します。\n" +
                    "ゲーム既定 = 100%\n" +
                    "<Mod 既定 = 120%>\n" +
                    "画面下の人口にマウスを合わせます。" },

                // --------------------------------------------------------------------
                // Actions tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "ミニHUD通知" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "都市内に小さなHUDを表示し、重要な通知数を確認できます。\n" +
                    "City Watchdog のフルパネルを開かずに、簡易アラートバーとして使えます。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "ミニHUDモード" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "ミニHUDで使う通知行を選びます。\n" +
                    "上位アクティブは現在数が多い通知を表示します。\n" +
                    "お気に入りは City Watchdog パネルで星を付けた行だけを表示します。" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "上位アクティブ通知" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "お気に入り" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "ミニHUDアイコン数" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "ミニHUDに同時表示できる通知アイコン数を選びます。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "ミニHUDの向き" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "ミニHUDアイコンを横並びまたは縦並びにします。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "横" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "縦" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "ミニHUD位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "ミニHUDを表示する位置を選びます。\n" +
                    "ドラッグ可能にすると都市UI内で移動できます。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "上中央" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "上右" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "ドラッグ可能" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "0件の通知を隠す" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "有効 [ ✓ ] の場合、件数が0の通知行をミニHUDで隠します。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "ガラス風スタイル" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)), "見やすくするため、ミニHUDの背後に柔らかいガラス風背景を追加します。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "新しい<有限資金>都市、または最初にロードした都市の開始残高を設定します。\n" +
                    "適用後は Game Default に戻ります。\n" +
                    "都市がロード済みの場合は無効です。\n" +
                    "都市の開始/ロード前に設定し、その後は<お金ホットキー金額>または<自動お金追加>を使ってください。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム既定" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Milestone セレクター" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "都市をロード/開始する<前>に有効にすると、ロード後すぐに選択した Milestone を解除します。\n" +
                    "都市ロード中はオンにできませんが、誤ってオンのままならオフにできます。\n" +
                    "忘れた場合はゲームを再起動し、都市に入る前に選んでください。\n" +
                    "保存済みの Milestone 変更は City Watchdog では元に戻せません。必要なら古いセーブを使ってください。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "次回都市ロード時に解除する Milestone を選択します。\n" +
                    "都市がロードされていない状態で、[Milestone セレクター] [ ✓ ] が有効なときのみ変更できます。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "お金ホットキー金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "お金を追加/減少するホットキーで使う金額です。\n" +
                    "<Mod 既定 = 40,000>\n" +
                    "都市内でホットキーを使わない限り何もしません。\n" +
                    "自動化する場合は自動お金追加を有効にしてください。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "お金を追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "都市内で<お金を追加>するホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "お金を追加" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "お金を減らす" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "都市内で<お金を減らす>ホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "お金を減らす" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動お金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "有効 [ ✓ ] の場合、City Watchdog は都市ロード中に残高を確認します。\n" +
                    "- 残高が<しきい値未満>なら、\n" +
                    "  選択した金額を追加します。\n" +
                    "- 通常は必要時に手動ホットキー (<[> または <]>) を使うのがおすすめです。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動お金しきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動お金追加が有効で残高がこの値を下回ると、\n" +
                    "選択した金額を追加します。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動追加金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動追加が発動するたびに追加される金額です。\n" +
                    "しきい値を安全に超える値を選んでください。" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<先に都市のバックアップを作成してください>。\n" +
                    "無限資金で開始した都市を、通常の資金制限あり都市へ変換します。\n" +
                    "ロード中の都市が<無限資金>タイプの場合、<[無限資金セーブを変換]>ボタンが使えます。\n" +
                    "City Watchdog では変換を元に戻せません。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "無限資金都市を通常に変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "<無限資金>で開始した都市用です。\n" +
                    "その都市をロード中に、通常の有限資金予算へ変換します。\n" +
                    "都市が<無限資金>タイプで、<無限資金コンバーター>が ON [ ✓ ] の場合のみボタンが有効です。\n" +
                    "バックアップを作り、自己責任で使用してください。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "この都市を無限資金から通常の有限資金に変換しますか？\n" +
                    "先にバックアップしてください。City Watchdog では元に戻せません。\n" +
                    "よろしいですか？" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod 名" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "この Mod の表示名です。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "現在の Mod バージョンです。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "作者の Paradox Mods ページを開きます。" },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "ログへデバッグレポート" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<通常プレイでは不要です。>\n" +
                    "テスターやゲームパッチ後の確認用に、<Logs/CityWatchdog.log> へレポートを書き出します。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "</Logs/CityWatchdog.log> があれば開きます。\n" +
                    "なければ Logs/ フォルダーを開きます。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
