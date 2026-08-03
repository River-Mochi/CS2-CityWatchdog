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

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly CwdSettings m_Settings;

        public LocaleJA(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (街の見張り)";

            Dictionary<string, string> entries = new()
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kActions), "操作" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMiniHudTab), "ミニHUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kMoneyTab), "都市開始" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.kAbout), "情報" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutUsage), "使い方" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kNotifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoneyViewGroup), "都市内情報表示" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMiniHudGroup), "ミニHUD通知" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMilestone), "新規都市スタート設定" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kMoney), "資金" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kSaveConversion), "無限資金セーブ変換" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.kAboutDiagnostics), "診断" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "説明を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "下の使い方説明を表示/非表示にします。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. 都市左上の肉球アイコン、または Shift+N でメインパネルを開きます。\n" +
                    "<表示切替>\n" +
                    "1. タイトルバーアイコン: City Watchdog のツールチップを表示/非表示。\n" +
                    "\n" +
                    "2. **[i]** ボタン: 建物、市民、ツール、下部メニューなど、ゲームのホバーツールチップを <すべて> 表示/非表示。\n" +
                    "3. 道路ボタン: 道路名を表示/非表示。ホットキー: \\.\n" +
                    "4. 地区ボタン: 地区名を表示/非表示。\n" +
                    "5. 道路矢印ボタン: 一方通行矢印を表示/非表示（道路名も非表示）。\n" +
                    "\n" +
                    "<通知アラート>\n" +
                    "1. 並び替えは A→Z、Z→A、アクティブのみ。\n" +
                    "2. <[0/63]> = 表示中アイコン/合計。クリックで全行を展開/折りたたみ。\n" +
                    "3a. [アイコン表示] で問題警告アイコンをすべて即非表示/表示。\n" +
                    "3b. プリセット [1 | 2]: クリックで読み込み、1秒長押しで現在のチェック状態を保存。\n" +
                    "3c. アイコンを隠しても都市の問題は解決しません。\n" +
                    "\n" +
                    "<ヘルパー>\n" +
                    "1. 資金追加/減少: <資金ホットキー額> に既定キー <[ または ]> を使います。\n" +
                    "2. 自動資金は、都市資金が設定した下限を下回ると資金を追加します。\n" +
                    "3. 無限資金セーブ変換は、無限資金で始めた都市専用で、<元に戻せません>。\n" +
                    "\n" +
                    "<下部メニューツールチップ>\n" +
                    "資金表示は資金や人口にマウスを置いた時、トレンドなどの詳細を追加します。\n" +
                    "\n" +
                    "<カスタムマイルストーン>\n" +
                    "都市開始で、都市をロード/開始する前に初期資金やマイルストーンを設定します。"
                },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "通知アイコン切替" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "ゲーム内の <[アイコン表示]> ボタンと同じ動作の <ホットキー>。\n" +
                    "問題警告アイコンをすべて即表示/非表示にします。"
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "問題警告アイコンを即表示/非表示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "都市内の <通知パネル> を\n" +
                    "開く/閉じる <ホットキー>。\n" +
                    "左上アイコンをクリックするのと同じです。"
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "通知パネルを開く/閉じる" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "ボタンのみで開始" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "有効 [ ✓ ] だと、City Watchdog は小さいボタンのみ表示で開きます。\n" +
                    "タイトル矢印か行数ボタンでフルパネルを開けます。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "道路名の表示切替" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<ホットキー> でゲーム標準の道路名ラベルを即表示/非表示。\n" +
                    "City Watchdog パネルの道路名アイコンと同じです。"
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "道路名の表示切替" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "全ホバーツールチップ無効" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "建物、市民、ツール、下部アイコンなど、ゲームのホバーツールチップを <すべて> 表示/非表示にする <ホットキー>。\n" +
                    "<City Watchdog の資金/人口ポップアップは残ります>; 資金表示が制御します。\n" +
                    "City Watchdog パネルの [i] アイコンと同じです。"
                },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "ゲームのホバーツールチップ表示切替" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InterfaceScaling)), "ゲームUIを拡大" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InterfaceScaling)),
                    "有効 [ ✓ ] にすると、ゲームとMODの<画面全体>が大きく表示されます。\n" +
                    "<--developerMode> 起動オプションなしで、ゲーム本来の<インターフェーススケール>を使います。\n" +
                    "この [x] チェックは City Watchdog タイトルバーの拡大ボタンと同期します。\n" +
                    "文字だけ変える場合: オプション > インターフェース > <テキストスケール>。\n" +
                    "City Watchdogを削除しても、自分でオフにするまで有効です。\n" +
                    "- アンインストール前にオフにすると通常サイズへ戻ります。\n" +
                    "- または一度 <--developerMode> で起動し、オプション > インターフェース > インターフェーススケール (dev) をオフにします。"
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "メインパネルの不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "通知メインパネルの背景の透明度を調整します。\n" +
                    "値を下げると透明に、上げると暗く不透明になります。"
                },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "資金トレンド + 人口ツールチップ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<おすすめ>\n" +
                    "下部メニュー: <資金と人口の矢印> にトレンド値を表示。\n" +
                    "軽いホバー機能 <表示のみ>。\n" +
                    "ゲームの情報パネルを開くより手早く、軽い場合があります。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "資金表示の頻度" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "下部バーのトレンドを時間ごと/月ごとで選択します。\n" +
                    "月ごとは収入−支出と24時間の人口予測を使います。"
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "時間ごと (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "月ごと (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "資金ツールチップ形式" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "資金ツールチップの詳細量を選びます。\n" +
                    "コンパクト = 初回既定。\n" +
                    "<ミニ> は /mo と /h の純増減2つだけ表示。\n" +
                    "<コンパクト> は大きな数値を短縮（15.21M など）。\n" +
                    "<全データ> は長い値と合計を表示。"
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "ミニ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "コンパクト" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "全データ" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "資金フォントサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "資金表示の数値 <フォントサイズ> を調整。\n" +
                    "ゲーム既定 = 100%\n" +
                    "<Mod既定 = 120%>\n" +
                    "画面下の資金にマウスを置きます。\n" +
                    "小さいツールチップが見づらいプレイヤー向け。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "人口フォントサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "人口ツールチップ数値の <フォントサイズ> を調整。\n" +
                    "ゲーム既定 = 100%\n" +
                    "<Mod既定 = 120%>\n" +
                    "画面下の人口にマウスを置きます。"
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "ミニHUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "重要な通知数を小さなHUDで表示します。\n" +
                    "フルパネルを開かずに使える簡易アラートバーです。\n" +
                    "アイコンをクリックすると該当問題へジャンプ。\n" +
                    "同じアイコンを続けてクリックすると候補を巡回します。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "クリック：クイックスタート" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "Mini HUDの<クイックスタート>を適用します:\n" +
                    "**青い星のお気に入り**の初期セットを追加します。\n" +
                    "お気に入りモードでは、Mini HUDに**青い星**リストの現在数上位5件または10件を表示します。\n" +
                    "**青い星**はCity Watchdogパネルで追加/削除できます。\n" +
                    "設定: お気に入り、5アイコン、横向き、移動可能、100%、暗いパネル、0件を非表示。\n" +
                    "再度実行すると、いつでもこの設定に戻せます。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "ミニ表示モード" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "ミニ表示で使う通知行を選びます。\n" +
                    "**件数上位** は現在件数が多いものを表示します。\n" +
                    "**お気に入り** はメイン City Watchdog パネルの **青い星** の行を使います。\n" +
                    "お気に入りは好きなだけ選べますが、\n" +
                    "ミニ表示はその **青い星** リストから件数上位5件または10件だけ表示します。"
                },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "件数上位" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "お気に入り" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "アイコン数" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "ミニHUDに表示する通知アイコン数を選びます。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "アイコンサイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "ミニHUDのアイコンと数字を拡大縮小。\n" +
                    "90% = コンパクト。100% = 既定。見やすくするなら最大130%。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "向き" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "横並びか縦並びを選びます。" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "横" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "縦" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "HUD位置" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "ミニHUDの表示位置を選びます。\n" +
                    "ドラッグ可なら都市UI内で動かせます。"
                },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "上中央" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "右上" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "ドラッグ可" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "暗い/ガラススタイル" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "ミニHUDの背景を選びます。\n" +
                    "ガラスは透明から白く曇るだけで、暗くなりません。\n" +
                    "暗いパネルはゲーム風の暗いHUDです。"
                },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "暗いパネル" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "ガラスパネル" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "背景の不透明度" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "ミニHUD背景の透明度を調整。\n" +
                    "低いほど透明。高いほど濃く表示。\n" +
                    "ガラスは白く、暗いパネルはより濃くなります。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "0件アラートを隠す" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "有効 [ ✓ ] なら、ミニHUDは件数0の行を隠します。" },

                // --------------------------------------------------------------------
                // City Start tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "次にロードする <有限資金> の都市（新規または既存）の残高を設定します。\n" +
                    "一度適用するとゲーム既定へ戻ります。\n" +
                    "都市がロード済みだと無効です。\n" +
                    "都市のロード/開始前に設定し、その後は必要に応じて <資金ホットキー額> を使います。"
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム既定" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "マイルストーン選択" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "都市ロード時に指定マイルストーンを即解除するには <ロード/開始前> に有効化。\n" +
                    "- 都市ロード後は有効化不可。ただし誤って有効にした場合は無効化可能。\n" +
                    "- 忘れたらゲームを再起動し、都市に入る前に選択。\n" +
                    "- 保存済みのマイルストーン変更は元に戻せません。古いセーブを使用。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "マイルストーン" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "次回ロード時に解除するマイルストーンを選びます。\n" +
                    "<都市ロード外> かつ [マイルストーン選択] 有効 [ ✓ ] の時だけ調整可。\n" +
                    "都市がすでに同じ/上位なら何もしません。\n" +
                    "選択したものが現在より上位の場合だけ変更します。"
                },

                // --------------------------------------------------------------------
                // City Start tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "資金ホットキー額" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "資金追加/減少ホットキーで使う金額です。\n" +
                    "<Mod既定 = 40,000>\n" +
                    "都市内でホットキーを使わない限り何もしません。\n" +
                    "自動化するなら自動資金を有効にします。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "資金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "都市内で <資金追加> するホットキー。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "資金追加" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "資金減少" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "都市内で <資金減少> するホットキー。" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "資金減少" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "自動資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "有効 [ ✓ ] なら、City Watchdog が都市資金を確認します。\n" +
                    "- 資金が <しきい値未満> なら、しきい値に届く額を追加します。\n" +
                    "- 選択した自動資金額以上を必ず追加します。\n" +
                    "- 時々だけ必要な場合は手動ホットキー (<[> または <]>) がおすすめです。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "自動資金しきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "自動資金が有効で都市資金がこの値を下回ると、\n" +
                    "少なくともこのしきい値に届くまで資金を追加します。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "自動追加額" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "自動資金の発動ごとに追加する最低額です。\n" +
                    "しきい値に届くためにさらに必要なら、City Watchdog は大きい方の額を追加します。"
                },

                // --------------------------------------------------------------------
                // City Start tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "無限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<先に都市のバックアップを作成>。\n" +
                    "無限資金で開始した都市を通常の資金チャレンジ都市へ変換します。\n" +
                    "ロード中の都市が <無限資金> タイプなら <[無限資金セーブを変換]> ボタンを有効化します。\n" +
                    "City Watchdog では元に戻せません。\n" +
                    "通常の都市では不要です。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "無限資金都市を通常へ変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "<無限資金> で開始した都市用。\n" +
                    "その都市をロード中に、通常の有限資金予算へ変換します。\n" +
                    "ボタンは都市が <無限資金> タイプで、\n" +
                    "<無限資金コンバーター> が有効 [ ✓ ] の時だけ有効です。\n" +
                    "必ずバックアップし、自己責任で使用してください。元に戻せません。"
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "この都市を無限資金から通常の有限資金へ変換しますか？\n" +
                    "先にバックアップを保存してください。City Watchdog では元に戻せません。\n" +
                    "よろしいですか？"
                },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "Mod名" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "このModの表示名。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "現在のModバージョン。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "作者の Paradox Mods ページを開きます。" },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "診断レポートをログへ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<通常プレイでは不要です。>\n" +
                    "テスターやゲーム更新後の確認用: <Logs/CityWatchdog.log> にレポートを書き、\n" +
                    "ゲーム内通知プレハブと Watchdog が制御するアイコンを比較します。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "ログを開く" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "</Logs/CityWatchdog.log> があれば開きます。\n" +
                    "なければ Logs/ フォルダーを開きます。"
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
