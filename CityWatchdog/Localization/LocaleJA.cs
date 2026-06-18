// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleJA.cs
// Purpose: Japanese (ja-JP) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "ホットキー" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "情報" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "デバッグ" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "情報ビューアー" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "資金" },
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
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "画面下部ツールバーのバニラの資金・人口矢印の横に、数値の推移を表示します。\nこれは軽量なツールバーホバー表示で、<表示のみ>です。\n都市の資金や人口は変更しません。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Money View の頻度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "画面下部ツールバーの推移テキストに、資金と人口の時間値または月間値を表示するか選びます。\n月間の資金は予算収入から支出を引いた値を使い、人口は24時間予測を使います。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "時間ごと (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "月ごと (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "資金ツールチップの形式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "資金ホバーのツールチップに表示する詳細量を選びます。\nコンパクト = 初回インストール時の既定値。\n<ミニ> は /mo と /h の純額2つだけを表示します。\n<コンパクト> は大きな値を短縮します（15,212,318 ではなく 15.21M）。\n<全データ> は長い値と合計フィールドを表示します。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "ミニ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "コンパクト" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "全データ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "資金の文字サイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Money View ツールチップの数値の<文字サイズ>を調整します。\nゲーム既定値 = 100%\n<Mod 既定値 = 120%>\n画面下部の資金にマウスを合わせてください。\nゲーム内の小さいツールチップが見づらいプレイヤー向けです。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口の文字サイズ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口ツールチップの数値の<文字サイズ>を調整します。\nゲーム既定値 = 100%\n<Mod 既定値 = 120%>\n画面下部の人口にマウスを合わせてください。" },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "資金ホットキー金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "この金額を、資金追加と資金減少のホットキーで使用します。\n<Mod 既定値 = 40,000>\n都市内でホットキーを使って資金を追加/減少しない限り、何もしません。\n自動資金追加を使う場合は、自動資金追加オプションを有効にしてください。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "資金を追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "都市内で<資金を追加>するホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "資金を追加" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "資金を減らす" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "都市内で<資金を減らす>ホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "資金を減らす" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動資金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "有効 [ ✓ ] の場合、City Watchdog は都市が読み込まれている間、都市の残高を確認します。\n- 残高が<しきい値未満>の場合、\n  選択した自動金額を追加します。\n- 必要に応じてホットキー（<[> または <]>）で手動資金を使うことを推奨しますが、この自動オプションも用意されています。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動資金しきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動資金追加が有効で、都市の残高がこの値を下回った場合、\n選択した自動金額を追加します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動資金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動資金追加が発動するたびに追加される金額です。\n都市を安全にしきい値より上に戻せる十分な値を選んでください。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "新しい<資金制限あり>都市、または最初に読み込まれた都市の開始残高を設定し、\n適用後にゲーム既定値へ戻します。\nすでに都市が読み込まれている場合はグレー表示になります。\n都市を開始/読み込みする前に設定 → 一度適用 → その後は<資金ホットキー金額>または<自動資金追加>を使用してください。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム既定値" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "通知アイコンを切り替え" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<ホットキー>で、ゲーム内の <[TOGGLE ALL]> アイコンボタンと同じ操作をします。\n一覧の都市通知アイコンをすべて即座に表示または非表示にします。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "すべての通知アイコンを即時表示/非表示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<ホットキー>で都市内の\n<通知パネル>を開閉します。\n左上アイコンをクリックして完全なパネルを開くのと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "道路名を非表示/表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<ホットキー>で都市内のバニラ道路名ラベルを即座に非表示または表示します。\nCity Watchdog パネルのツールバーにある道路名アイコンをクリックするのと同じです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "道路名を非表示/表示" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "すべてのマウスオーバーツールチップを無効化" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "ゲームのホバーツールチップを無効にします。建物/市民/ツール上でカーソルについてくるものと、ゲームUIボタン上の小さなポップアップ（上部バー名、バニラボタンなど）の両方です。\n<City Watchdog 独自の資金/人口ポップアップは有効のまま>です。上の Money View オプションで制御します。\n都市内の City Watchdog パネルの [i] アイコンをクリックするのと同じです。" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "マイルストーン選択" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "都市を読み込むまたは開始する前に有効にすると、都市読み込み直後に選択したマイルストーンを解除します。\n都市が読み込まれている間はオンにできませんが、誤って有効のままの場合はオフにできます。\nCity Watchdog は、すでに都市に保存されたマイルストーン変更を元に戻せません。必要なら古いセーブを使ってください。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "マイルストーン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "次回の都市読み込み時に解除するマイルストーンレベルを選びます。\n都市が読み込まれていない時だけ調整でき、[マイルストーン選択] が有効 [ ✓ ] の後だけ使用できます。" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<先に都市のバックアップを作成してください>。\n無限資金で開始した都市を、通常の資金チャレンジがある通常都市へ変換します。\n読み込まれている都市が<無限資金>タイプの場合、これを有効にすると <[無限資金セーブを変換]> ボタンが使えるようになります。\nCity Watchdog はこの変換を元に戻せません。\n通常都市の場合、この機能は不要です。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "無限資金セーブ都市を通常に変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "<無限資金>で開始した都市用です。\nその都市が読み込まれている間に、セーブを通常の資金制限あり予算へ変換し、通常の資金チャレンジが戻ります。\nボタンは、読み込まれた都市が<無限資金>タイプで、\n<無限資金コンバーター>が ON [ ✓ ] でない限り、<無効/グレー表示>です。\nバックアップを作成し、自己責任で使用してください。City Watchdog はこの変換を元に戻せません。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "この都市を無限資金から通常の資金制限ありに変換しますか？\n先にバックアップを保存してください。City Watchdog は元に戻せません。\nよろしいですか？" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod 名" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "この Mod の表示名です。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "現在の Mod バージョンです。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "作者の Paradox Mods ページを開きます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "デバッグ報告をログへ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<通常プレイでは不要です。>\nテスターやゲームパッチ後の確認用：<Logs/CityWatchdog.log> レポートを書き出し、\nゲーム内のライブ通知 prefab と、Watchdog が現在制御している通知アイコンを比較します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "</Logs/CityWatchdog.log> が存在する場合は開きます。\nログファイルがない場合は、代わりに Logs/ フォルダーを開きます。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "説明を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "下の使用説明を表示または非表示にします。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<通知パネル>\n1. City Watchdog ボタン（左上）をクリック、または Shift+N を押してパネルを開きます。\n2. ASC/DESC で並べ替えます。\n3. Toggle All で一括オフ/オン、またはセクションを展開して個別に変更します。\n4. アイコンを表示/非表示にするだけで、都市の根本問題は修正しません。\n\n<資金ヘルパー>\n1. 資金を追加または減少：既定の <資金ホットキー金額> を [ または ] で使います。\n2. 自動資金追加は都市が読み込まれている間に予算を監視し、しきい値未満なら資金を追加します。\n3. Money View は資金と人口ツールバーに数値を追加し、マウスホバーでツールチップを表示します。\n4. 無限資金セーブ変換は、無限資金で開始した都市専用で、<元に戻せません>。\n\n<カスタムマイルストーン>\n都市を読み込むまたは開始する前に、オプションメニューで初期資金を設定し、マイルストーンを選んでください。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
