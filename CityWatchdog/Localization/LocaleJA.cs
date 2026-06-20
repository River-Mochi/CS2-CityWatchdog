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
            string title = Mod.ModName + " (見張り役)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "アクション" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "ホットキー" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "情報" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "デバッグ" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "情報表示" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "お金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "マイルストーン" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "セーブ変換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "ホットキー" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "診断" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使い方" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "ホバー時に詳細を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "下部ツールバーのバニラのお金・人口矢印の横に、数値の傾向を表示します。\n" +
                    "これはツールバーの軽いホバー表示で、<表示のみ>です。\n" +
                    "都市のお金や人口は変更しません。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View の頻度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "下部ツールバーの傾向テキストを、お金と人口について時間ごと表示にするか月ごと表示にするか選びます。\n" +
                    "月ごとは、お金は予算収入から支出を引いた値、人口は24時間予測を使います。"
                },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "時間ごと (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "月ごと (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "お金ツールチップの表示形式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "お金のホバー時ツールチップに表示する詳細量を選びます。\n" +
                    "コンパクト = 初回インストール時の既定値。\n" +
                    "<ミニ> は /mo と /h の純額2つだけを表示します。\n" +
                    "<コンパクト> は大きな値を短く表示します (15,212,318 ではなく 15.21M)。\n" +
                    "<全データ> は長い値と合計欄を表示します。"
                },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "ミニ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "コンパクト" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "全データ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "お金の文字サイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Money View ツールチップの数値の<文字サイズ>を調整します。\n" +
                    "ゲーム既定値 = 100%\n" +
                    "<Mod既定値 = 120%>\n" +
                    "画面下のお金にマウスを重ねてください。\n" +
                    "ゲーム内の小さいツールチップが見づらいプレイヤー向けの設定です。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口の文字サイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "人口ツールチップの数値の<文字サイズ>を調整します。\n" +
                    "ゲーム既定値 = 100%\n" +
                    "<Mod既定値 = 120%>\n" +
                    "画面下の人口にマウスを重ねてください。"
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "お金ホットキーの金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "この金額を、お金を追加・減少するホットキーで使います。\n" +
                    "<Mod既定値 = 40,000>\n" +
                    "都市内でホットキーを使ってお金を追加/減少しない限り、何もしません。\n" +
                    "自動でお金を追加したい場合は、自動お金追加オプションを有効にしてください。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "お金を追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "都市内で<お金を追加>するホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "お金を追加" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "お金を減らす" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "都市内で<お金を減らす>ホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "お金を減らす" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動お金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "有効 [ ✓ ] のとき、City Watchdog は都市が読み込まれている間、都市の残高を確認します。\n" +
                    "- 残高が<しきい値を下回る>と、\n" +
                    "  選択した自動金額を追加します。\n" +
                    "- 必要なときは、この自動オプションより手動のお金ホットキー (<[> または <]>) の使用がおすすめです" +
                    "  ただし必要ならこの機能も使えます。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動お金追加のしきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "自動お金追加が有効で、都市の残高がこの値を下回った場合、\n" +
                    "選択した自動金額を追加します。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動追加金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "自動お金追加が発動するたびに追加される金額です。\n" +
                    "都市を安全にしきい値より上に戻せるだけの金額を選んでください。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "新しい<資金制限あり>都市、または最初に読み込む都市の開始残高を設定します。\n" +
                    "適用後はゲーム既定値に戻ります。\n" +
                    "すでに都市が読み込まれている場合はグレー表示になります。\n" +
                    "都市の開始/読み込み前に設定 → 1回だけ適用 → その後は<お金ホットキーの金額>または<自動お金追加>を使ってください。"
                },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム既定値" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "通知アイコンを切り替え" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "ゲーム内の <[TOGGLE ALL]> アイコンボタンと同じ動作をする<ホットキー>です。\n" +
                    "一覧にある都市通知アイコンをすべて即座に表示または非表示にします。"
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "すべての通知アイコンを即座に表示/非表示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "都市内の\n" +
                    "<通知パネル>を開く/閉じる<ホットキー>です。\n" +
                    "左上アイコンをクリックしてフルパネルを開くのと同じです。"
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "道路名を非表示/表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "都市内のバニラ道路名ラベルを即座に非表示または表示する<ホットキー>です。\n" +
                    "City Watchdog パネルのツールバーにある道路名アイコンをクリックするのと同じです。"
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "道路名を非表示/表示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "すべてのマウスオーバー・ツールチップを無効化" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<ホットキー>ですべてのゲーム・ホバー・ツールチップを即座に非表示/表示 — 建物、Cim、ツール、下部メニューのアイコン。\n" +
                    "<City Watchdog 独自のお金/人口ポップアップはオンのまま>。これらは上の Money View オプションで制御されます。\n" +
                    "街の City Watchdog パネルの [i] アイコンをクリックするのと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "全てのホバー・ツールチップを非表示/表示" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "マイルストーン選択" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "都市を読み込む/開始する前に有効にすると、読み込み直後に選んだマイルストーンを解除します。\n" +
                    "都市が読み込まれている間は ON にできませんが、誤って有効のままだった場合は OFF にできます。\n" +
                    "忘れて都市を読み込んでしまった場合は、ゲームを再起動してから、都市に入る前にマイルストーンを選んでください。\n" +
                    "City Watchdog は、すでに都市に保存されたマイルストーン変更を元に戻せません。必要なら古いセーブを使ってください。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "マイルストーン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "次に都市を読み込んだときに解除するマイルストーンレベルを選びます。\n" +
                    "これは都市が読み込まれていないときだけ、かつ [マイルストーン選択] が有効 [ ✓ ] のときだけ変更できます。"
                },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<先に必ず都市のバックアップを作ってください>。\n" +
                    "無限資金で開始した都市を、通常のお金チャレンジがある普通の都市に変換します。\n" +
                    "これを有効にすると、読み込んだ都市が<無限資金>タイプのときに <[無限資金セーブを変換]> ボタンが使えるようになります。\n" +
                    "City Watchdog はこの変換を元に戻せません。\n" +
                    "普通の都市なら心配いりません。この機能は不要です。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "無限資金セーブ都市を通常に変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<無限資金>で開始した都市用です。\n" +
                    "その都市が読み込まれている間に、セーブを通常の制限あり予算へ変換し、通常のお金チャレンジを戻します。\n" +
                    "読み込んだ都市が<無限資金>タイプで、\n" +
                    "<無限資金コンバーター> が ON [ ✓ ] でない限り、ボタンは<無効/グレー表示>です。\n" +
                    "バックアップセーブを作り、自己責任で使ってください。City Watchdog はこの変換を元に戻せません。"
                },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "この都市を無限資金から通常の制限あり資金へ変換しますか？\n" +
                    "先にバックアップを保存してください。City Watchdog は元に戻せません。\n" +
                    "本当に実行しますか？"
                },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod名" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "このModの表示名です。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "現在のModバージョンです。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "作者の Paradox Mods ページを開きます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "デバッグ報告をログへ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<通常プレイでは不要です。>\n" +
                    "テスターやゲームパッチ後の確認用: <Logs/CityWatchdog.log> にレポートを書き込み、\n" +
                    "ゲーム内の通知Prefabと、Watchdogが現在制御している通知アイコンを比較します。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "存在する場合は </Logs/CityWatchdog.log> を開きます。\n" +
                    "ログファイルがない場合は、代わりに Logs/ フォルダーを開きます。"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "説明を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "下の使用説明を表示または非表示にします。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<表示切り替え>\n" +
                    "1. [i] ボタン: ゲームのホバー・ツールチップをすべて非表示/表示 (建物、Cim、ツール、下部メニューのアイコン)。\n" +
                    "2. 道路名ボタン: 道路名ラベルを非表示/表示。ホットキー: \\.\n" +
                    "3. 道路矢印ボタン: 一方通行の矢印を強制 ON/OFF (道路名も非表示)。\n" +
                    "4. CWD タイトルバーアイコン: City Watchdog パネルのツールチップを表示/非表示。\n" +
                    "\n" +
                    "<通知アラート>\n" +
                    "1. City Watchdog ボタン (左上) をクリック、または Shift+N でパネルを開きます。\n" +
                    "2. 昇順/降順の並べ替えボタン。\n" +
                    "3. Toggle All ですばやく全OFF/ON、またはセクションを開いて個別に変更します。\n" +
                    "4. アイコンを表示/非表示にするだけで、都市の問題そのものは修正しません。\n" +
                    "\n" +
                    "<お金ヘルパー>\n" +
                    "1. お金の追加/減少: <お金ホットキーの金額> の既定キー [ と ] を使います。\n" +
                    "2. 自動お金追加は、都市が設定した下限を下回ったときにお金を追加します。\n" +
                    "3. 無限資金セーブ変換は、無限資金で開始した都市だけが対象で、<元に戻せません>。\n" +
                    "\n" +
                    "<下部メニューのツールチップ>\n" +
                    "Money View はお金と人口ツールバーに傾向値を追加し、ホバー時に追加詳細を表示します。\n" +
                    "\n" +
                    "<カスタムマイルストーン>\n" +
                    "都市を読み込む/開始する前に、オプションメニューで初期資金とマイルストーンを設定してください。"
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
