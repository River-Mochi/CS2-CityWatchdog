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
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "アクション" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "ミニHUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "資金・マイルストーン" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "情報" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使い方" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "都市内情報表示" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "ミニHUD通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新都市開始設定" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "資金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "無制限資金セーブ変換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診断" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "説明を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "下の使い方説明を表示/非表示にします。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<表示切替>\n" +
                    "1. [i] ボタン: 建物、市民、ツール、下部メニューアイコンなど、ゲーム内の全ホバーツールチップを非表示/表示。\n" +
                    "2. 道路名ボタン: 道路名ラベルを非表示/表示。ホットキー: \\.\n" +
                    "3. 地区名ボタン: 地区境界はそのまま、地区名だけ非表示/表示。\n" +
                    "4. 道路矢印ボタン: 一方通行矢印を強制表示/非表示（道路名も非表示になります）。\n" +
                    "5. CWDタイトルバーアイコン: City Watchdogパネルのツールチップを表示/非表示。\n" +
                    "\n" +
                    "<通知アラート>\n" +
                    "1. 左上のCity Watchdogボタンを押すか、Shift+Nでパネルを開きます。\n" +
                    "2. 並べ替えボタンで昇順/降順。\n" +
                    "3. すべて切替で一括オン/オフ、またはセクションを開いて個別変更。\n" +
                    "4. アイコンを表示/非表示にするだけで、都市の問題自体は直しません。\n" +
                    "\n" +
                    "<資金ヘルプ>\n" +
                    "1. 資金追加/減額: <資金ホットキー額>を使います。標準キーは [ と ] です。\n" +
                    "2. 自動資金追加は、都市の資金が設定した下限を下回ると追加します。\n" +
                    "3. 無制限資金セーブ変換は、無制限資金で開始した都市専用で、<元に戻せません>。\n" +
                    "\n" +
                    "<下部メニューのツールチップ>\n" +
                    "資金表示は、資金と人口のツールバーに傾向値とホバー詳細を追加します。\n" +
                    "\n" +
                    "<カスタムマイルストーン>\n" +
                    "都市を読み込む/開始する前に、資金・マイルストーン > 新都市開始設定で初期資金とマイルストーンを設定します。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "通知アイコン切替" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "ゲーム内の <[すべて切替]> アイコンボタンと同じ動作用の<ホットキー>です。\n" +
                    "一覧の都市通知アイコンをすぐに表示/非表示にします。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "すべての通知アイコンを即時表示/非表示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "都市内の\n" +
                    "<通知パネル>を開閉する<ホットキー>です。\n" +
                    "左上アイコンをクリックするのと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "ボタンのみ表示で開始" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "有効 [ ✓ ] の場合、左上ボタンからCity Watchdogを開くと小さなボタン表示で開始します。\n" +
                    "タイトルバー矢印または行数ボタンで全パネルを開けます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "道路名を非表示/表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "ゲーム本体の道路名ラベルをすぐに非表示/表示する<ホットキー>です。\n" +
                    "City Watchdogパネルの道路名アイコンと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "道路名を非表示/表示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "全マウスオーバーツールチップ無効" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "建物、市民、ツール、下部メニューアイコンなど、ゲーム内の全ホバーツールチップをすぐに非表示/表示する<ホットキー>です。\n" +
                    "<City Watchdog独自の資金/人口ポップアップは表示されたまま>です。上の資金表示オプションで操作します。\n" +
                    "City Watchdogパネル内の [i] アイコンと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "全ゲームホバーツールチップを非表示/表示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "資金+人口ツールチップ表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<有効推奨>\n" +
                    "下部ゲームメニュー: ツールバーの<資金と人口の矢印>に傾向値を表示します。\n" +
                    "軽量なホバー表示機能で<表示のみ>です。\n" +
                    "ゲームの情報ビューを開くより手早く、負荷も軽い場合があります。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "資金表示の頻度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "下部ツールバーの傾向テキストを、資金と人口の時間値または月間値で表示します。\n" +
                    "月間は予算収入−支出と、人口の24時間予測を使います。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "時間ごと (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "月ごと (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "資金ツールチップ形式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "資金ホバーツールチップに表示する詳細量を選びます。\n" +
                    "コンパクト = 初回インストール時の標準。\n" +
                    "<ミニ> は /mo と /h の純額2つだけ表示します。\n" +
                    "<コンパクト> は大きい値を短縮します（15,212,318ではなく15.21M）。\n" +
                    "<全データ> は長い値と合計を表示します。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "ミニ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "コンパクト" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "全データ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "資金の文字サイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "資金表示ツールチップの数字の<文字サイズ>を調整します。\n" +
                    "ゲーム標準 = 100%\n" +
                    "<Mod標準 = 120%>\n" +
                    "画面下部の資金にマウスを重ねます。\n" +
                    "小さいツールチップが読みにくいプレイヤー向けです。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口の文字サイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口ツールチップの数字の<文字サイズ>を調整します。\n" +
                    "ゲーム標準 = 100%\n" +
                    "<Mod標準 = 120%>\n" +
                    "画面下部の人口にマウスを重ねます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "ミニHUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "重要な通知数を小さな都市HUDで表示します。\n" +
                    "City Watchdogの全パネルを開かずに、簡易アラート帯として使えます。\n" +
                    "アイコンをクリックすると一致する問題地点へジャンプします。\n" +
                    "同じアイコンを押すたび候補地点を巡回し、最初に戻ります。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "クイック開始設定" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "おすすめのミニHUD設定を適用します:\n" +
                    "お気に入り、5アイコン、横並び、上中央、100%サイズ、暗いパネル。\n" +
                    "0件のアラートも表示します。\n" +
                    "展開したWatchdogパネルでいつでも**青い星**のお気に入りを追加/削除できます。\n" +
                    "開始用の**青い星**お気に入りは **[おすすめ]** に含まれます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "ミニHUDモード" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "ミニHUDが使う通知行を選びます。\n" +
                    "**上位アクティブ**は現在数が多いアラートを表示します。\n" +
                    "**お気に入り**はCity Watchdogメインパネルで**青い星**を付けた行を使います。\n" +
                    "お気に入りはいくつでも選べますが、\n" +
                    "ミニHUDはその**青い星お気に入り**一覧から現在数上位5または10だけ表示します。" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "上位アクティブ" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "お気に入り" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "アイコン数" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "ミニHUDに同時表示する通知アイコン数を選びます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "アイコンサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "ミニHUDのアイコンと数字を拡大縮小します。\n" +
                    "90% = コンパクト。100% = 標準。見やすさのため130%まで上げられます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "向き" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "ミニHUDアイコンを横並びにするか縦並びにするか選びます。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "横" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "縦" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "ミニHUDの表示位置を選びます。\n" +
                    "ドラッグ可能にすると都市UI内で移動できます。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "上中央" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "ドラッグ可能" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "暗い/ガラス風" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "ミニHUDの背景スタイルを選びます。\n" +
                    "ガラス風パネルは透明から白く曇った表示になり、暗くはなりません。\n" +
                    "暗いパネルはゲーム風の濃いHUDになります。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "暗いパネル" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "ガラス風パネル" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "背景の不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "ミニHUD背景の透明度を調整します。\n" +
                    "低い値ほど透明。高い値ほど不透明。\n" +
                    "ガラス風は白く曇り、暗いパネルはより濃くなります。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "0件アラートを隠す" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "有効 [ ✓ ] の場合、ミニHUDは数が0の通知行を隠します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "新しい<制限資金>都市または最初に読み込む都市の開始残高を設定し、\n" +
                    "適用後にゲーム標準へ戻します。\n" +
                    "都市がすでに読み込まれているとグレー表示になります。\n" +
                    "都市の開始/読み込み前に設定してください。1回だけ適用され、その後は<資金ホットキー額>または<自動資金追加>を使います。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム標準" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "マイルストーン選択" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "<都市の読み込み/開始前>に有効にすると、読み込み直後に選んだマイルストーンを解除します。\n" +
                    "- 都市読み込み後はオンにできませんが、誤ってオンのままならオフにできます。\n" +
                    "- 忘れて都市を読み込んだ場合は、ゲームを再起動して都市に入る前に選んでください。\n" +
                    "- すでに保存されたマイルストーン変更は元に戻せません。必要なら古いセーブを使ってください。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "マイルストーン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "次回都市読み込み時に解除するマイルストーンを選びます。\n" +
                    "<都市が読み込まれていない時だけ>、かつ [マイルストーン選択] が有効 [ ✓ ] の時だけ調整できます。\n" +
                    "都市がすでに選択したマイルストーン以上なら何も起きません。\n" +
                    "選んだマイルストーンが現在より高い場合だけ変更されます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "資金ホットキー額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "資金追加/減額ホットキーで使う金額です。\n" +
                    "<Mod標準 = 40,000>\n" +
                    "都市内でホットキーを使わない限り何もしません。\n" +
                    "自動化する場合は自動資金追加を有効にしてください。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "資金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "都市内で<資金追加>するホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "資金追加" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "資金減額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "都市内で<資金減額>するホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "資金減額" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動資金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "有効 [ ✓ ] の場合、City Watchdogは都市読み込み中に残高を確認します。\n" +
                    "- 残高が<しきい値未満>なら、\n" +
                    "  選んだ自動追加額を加えます。\n" +
                    "- この自動機能より、必要時に手動ホットキー (<[> または <]>) を使うのがおすすめですが、必要なら使えます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動資金しきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動資金追加が有効で、都市残高がこの値を下回ると、\n" +
                    "選んだ自動追加額を加えます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動追加額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動資金追加が発動するたびに加える金額です。\n" +
                    "都市が安全にしきい値を超えるだけの額を選んでください。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無制限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<先に都市のバックアップを作成してください>。\n" +
                    "無制限資金で開始した都市を、通常の資金管理がある都市へ変換します。\n" +
                    "読み込んだ都市が<無制限資金>タイプの時、<[無制限資金セーブを変換]>ボタンを有効にします。\n" +
                    "City Watchdogはこの変換を元に戻せません。\n" +
                    "通常の都市では不要です。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "無制限資金都市を通常へ変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "<無制限資金>で開始した都市用です。\n" +
                    "その都市を読み込んでいる間に、セーブを通常の制限資金予算へ変換します。\n" +
                    "読み込んだ都市が<無制限資金>タイプで、\n" +
                    "<無制限資金コンバーター>がオン [ ✓ ] の時だけボタンが有効です。\n" +
                    "バックアップを作り、自己責任で使ってください。City Watchdogは元に戻せません。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "この都市を無制限資金から通常の制限資金へ変換しますか？\n" +
                    "先にバックアップを保存してください。City Watchdogは元に戻せません。\n" +
                    "よろしいですか？" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod名" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "このModの表示名です。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "現在のModバージョンです。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "作者のParadox Modsページを開きます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "デバッグレポートをログへ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<通常プレイでは不要です。>\n" +
                    "テスターやゲームパッチ後確認用: <Logs/CityWatchdog.log> にレポートを書き込み、\n" +
                    "ゲーム内の実通知PrefabとWatchdogが制御する通知アイコンを比較します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "存在する場合は </Logs/CityWatchdog.log> を開きます。\n" +
                    "ログファイルがない場合は、代わりにLogs/フォルダーを開きます。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
