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
            string title = Mod.ModName + " (街の見張り)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "ミニHUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "資金・マイルストーン" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "情報" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使い方" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "都市内情報表示" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "ミニHUD通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "新規都市スタート設定" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "資金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "無限資金セーブ変換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診断" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "説明を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "下の使い方説明を表示/非表示にします。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "A. 都市左上の肉球アイコン、または Shift+N でメインパネルを開きます。\n" +
                    "<表示切替>\n" +
                    "1. タイトルバーアイコン: City Watchdog のツールチップを表示/非表示。\n" +
                    "\n" +
                    "2. **[i]** ボタン: 建物、市民、ツール、下部メニューなど、ゲームのホバーツールチップを <すべて> 表示/非表示。\n" +
                    "3. 道路ボタン: 道路名を表示/非表示。ホットキー: \\.\n" +
                    "4. 地区ボタン: 地区名を表示/非表示。\n" +
                    "5. 道路矢印ボタン: 一方通行矢印をON/OFF（道路名も非表示）。\n" +
                    "\n" +
                    "<通知アラート>\n" +
                    "1. 並び替えは A→Z、Z→A、アクティブのみ。\n" +
                    "2. <[0/63]> = アイコンON/合計。クリックで全行を展開/折りたたみ。\n" +
                    "3a. [すべて切替] で全通知アイコンを即OFF/ON。\n" +
                    "3b. アイコンを隠すだけで、都市の問題は直しません。\n" +
                    "\n" +
                    "<資金ヘルプ>\n" +
                    "1. 資金追加/減少: <資金ホットキー額> に既定キー <[ または ]> を使います。\n" +
                    "2. 自動資金は、都市資金が設定した下限を下回ると資金を追加します。\n" +
                    "3. 無限資金セーブ変換は、無限資金で始めた都市専用で、<元に戻せません>。\n" +
                    "\n" +
                    "<下部メニューツールチップ>\n" +
                    "マネービュー は資金や人口にマウスを置いた時、トレンドなどの詳細を追加します。\n" +
                    "\n" +
                    "<カスタムマイルストーン>\n" +
                    "資金・マイルストーン > 新規都市スタート設定で、都市をロード/開始する前に初期資金やマイルストーンを設定します。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "通知アイコン切替" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "ゲーム内 <[すべて切替]> ボタンと同じ動作の <ホットキー>。\n" +
                    "一覧の都市通知アイコンを即表示/非表示にします。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "全通知アイコンを即表示/非表示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "都市内の <通知パネル> を\n" +
                    "開く/閉じる <ホットキー>。\n" +
                    "左上アイコンをクリックするのと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "ボタンのみで開始" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "有効 [ ✓ ] だと、City Watchdog は小さいボタンのみ表示で開きます。\n" +
                    "タイトル矢印か行数ボタンでフルパネルを開けます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "道路名の表示切替" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<ホットキー> でゲーム標準の道路名ラベルを即表示/非表示。\n" +
                    "City Watchdog パネルの道路名アイコンと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "道路名の表示切替" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "全ホバーツールチップ無効" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "建物、市民、ツール、下部アイコンなど、ゲームのホバーツールチップを <すべて> 表示/非表示にする <ホットキー>。\n" +
                    "<City Watchdog の資金/人口ポップアップは残ります>; マネービュー が制御します。\n" +
                    "City Watchdog パネルの [i] アイコンと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "ゲームのホバーツールチップ表示切替" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "資金トレンド + 人口ツールチップ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<おすすめ>\n" +
                    "下部メニュー: <資金と人口の矢印> にトレンド値を表示。\n" +
                    "軽いホバー機能 <表示のみ>。\n" +
                    "ゲームの情報パネルを開くより手早く、軽い場合があります。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "マネービュー 頻度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "下部バーのトレンドを時間ごと/月ごとで選択します。\n" +
                    "月ごとは収入−支出と24時間の人口予測を使います。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "時間ごと (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "月ごと (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "資金ツールチップ形式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "資金ツールチップの詳細量を選びます。\n" +
                    "コンパクト = 初回既定。\n" +
                    "<ミニ> は /mo と /h の純増減2つだけ表示。\n" +
                    "<コンパクト> は大きな数値を短縮（15.21M など）。\n" +
                    "<全データ> は長い値と合計を表示。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "ミニ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "コンパクト" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "全データ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "資金フォントサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "マネービュー の数値 <フォントサイズ> を調整。\n" +
                    "ゲーム既定 = 100%\n" +
                    "<Mod既定 = 120%>\n" +
                    "画面下の資金にマウスを置きます。\n" +
                    "小さいツールチップが見づらいプレイヤー向け。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口フォントサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "人口ツールチップ数値の <フォントサイズ> を調整。\n" +
                    "ゲーム既定 = 100%\n" +
                    "<Mod既定 = 120%>\n" +
                    "画面下の人口にマウスを置きます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "ミニHUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "重要な通知数を小さなHUDで表示します。\n" +
                    "フルパネルを開かずに使える簡易アラートバーです。\n" +
                    "アイコンをクリックすると該当問題へジャンプ。\n" +
                    "同じアイコンを続けてクリックすると候補を巡回します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "クリック: クイック開始" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "ミニHUDの <クイック開始> を適用:\n" +
                    "お気に入り、5アイコン、縦、ドラッグ可、100%、暗いパネル。\n" +
                    "0件のアラートは非表示。\n" +
                    "**青い星のお気に入りスターターセット** を含みます。\n" +
                    "展開した Watchdog パネルで **青い星** を追加/削除できます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "ミニHUDモード" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "ミニHUDが使う通知行を選びます。\n" +
                    "**上位アクティブ** は現在数の多いものを表示。\n" +
                    "**お気に入り** はメインパネルの **青い星** 行を使います。\n" +
                    "お気に入りはいくつでも選べますが、\n" +
                    "ミニHUDはその中の上位5件または10件だけ表示します。" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "上位アクティブ" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "お気に入り" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "アイコン数" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "ミニHUDに表示する通知アイコン数を選びます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "アイコンサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "ミニHUDのアイコンと数字を拡大縮小。\n" +
                    "90% = コンパクト。100% = 既定。見やすくするなら最大130%。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "向き" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "横並びか縦並びを選びます。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "横" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "縦" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "HUD位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "ミニHUDの表示位置を選びます。\n" +
                    "ドラッグ可なら都市UI内で動かせます。" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "上中央" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "ドラッグ可" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "暗い/ガラススタイル" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "ミニHUDの背景を選びます。\n" +
                    "ガラスは透明から白く曇るだけで、暗くなりません。\n" +
                    "暗いパネルはゲーム風の暗いHUDです。" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "暗いパネル" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "ガラスパネル" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "背景の不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "ミニHUD背景の透明度を調整。\n" +
                    "低いほど透明。高いほど濃く表示。\n" +
                    "ガラスは白く、暗いパネルはより濃くなります。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "0件アラートを隠す" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "有効 [ ✓ ] なら、ミニHUDは件数0の行を隠します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "新しい <有限資金> 都市、または最初にロードした都市の開始資金を設定し、\n" +
                    "適用後にゲーム既定へ戻します。\n" +
                    "都市がロード済みだと無効です。\n" +
                    "ロード/開始前に設定。以後は <資金ホットキー額> または <自動資金> を使います。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム既定" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "マイルストーン選択" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "都市ロード時に指定マイルストーンを即解除するには <ロード/開始前> に有効化。\n" +
                    "- 都市ロード後はON不可。ただし誤ONならOFF可能。\n" +
                    "- 忘れたらゲームを再起動し、都市に入る前に選択。\n" +
                    "- 保存済みのマイルストーン変更は元に戻せません。古いセーブを使用。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "マイルストーン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "次回ロード時に解除するマイルストーンを選びます。\n" +
                    "<都市ロード外> かつ [マイルストーン選択] 有効 [ ✓ ] の時だけ調整可。\n" +
                    "都市がすでに同じ/上位なら何もしません。\n" +
                    "選択したものが現在より上位の場合だけ変更します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "資金ホットキー額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "資金追加/減少ホットキーで使う金額です。\n" +
                    "<Mod既定 = 40,000>\n" +
                    "都市内でホットキーを使わない限り何もしません。\n" +
                    "自動化するなら自動資金を有効にします。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "資金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "都市内で <資金追加> するホットキー。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "資金追加" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "資金減少" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "都市内で <資金減少> するホットキー。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "資金減少" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "有効 [ ✓ ] なら、City Watchdog が都市資金を確認します。\n" +
                    "- 資金が <しきい値未満> なら、\n" +
                    "  選択額を追加します。\n" +
                    "- 必要な時に手動ホットキー (<[> または <]>) を使うのがおすすめですが、\n" +
                    "  自動用に用意しています。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動資金しきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "有効時、都市資金がこの値を下回ると、\n" +
                    "選択した金額を追加します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動追加額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "自動資金が発動するたびに追加する金額。\n" +
                    "しきい値を十分超える額を選んでください。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<先に都市のバックアップを作成>。\n" +
                    "無限資金で開始した都市を通常の資金チャレンジ都市へ変換します。\n" +
                    "ロード中の都市が <無限資金> タイプなら <[無限資金セーブを変換]> ボタンを有効化します。\n" +
                    "City Watchdog では元に戻せません。\n" +
                    "通常の都市では不要です。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "無限資金都市を通常へ変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<無限資金> で開始した都市用。\n" +
                    "その都市をロード中に、通常の有限資金予算へ変換します。\n" +
                    "ボタンは都市が <無限資金> タイプで、\n" +
                    "<無限資金コンバーター> がON [ ✓ ] の時だけ有効です。\n" +
                    "必ずバックアップし、自己責任で使用してください。元に戻せません。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "この都市を無限資金から通常の有限資金へ変換しますか？\n" +
                    "先にバックアップを保存してください。City Watchdog では元に戻せません。\n" +
                    "よろしいですか？" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod名" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "このModの表示名。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "現在のModバージョン。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "作者の Paradox Mods ページを開きます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "デバッグ報告をログへ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<通常プレイでは不要です。>\n" +
                    "テスターやパッチ確認用: <Logs/CityWatchdog.log> にレポートを書き、\n" +
                    "ゲーム内通知Prefabと Watchdog が制御するアイコンを比較します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "</Logs/CityWatchdog.log> があれば開きます。\n" +
                    "なければ Logs/ フォルダーを開きます。" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
