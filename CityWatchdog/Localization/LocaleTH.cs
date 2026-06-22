// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleTH.cs
// Purpose: Thai (th-TH) for City Watchdog Options UI menu.

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource
    using Game.UI.Editor;

    public sealed class LocaleTH : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleTH(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "การกระทำ"},
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "เงิน"},
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "ปุ่มลัด"},
                { m_Settings.GetOptionTabLocaleID(Setting.About), "เกี่ยวกับ"},
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "ดีบัก"},

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "วิธีใช้"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "การแจ้งเตือน"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "ตั้งค่าเมืองใหม่ตอนเริ่ม"},
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "ข้อมูลในเมือง"},
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "เงิน"},
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "แปลงเซฟ"},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), ""},
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "วินิจฉัย"},
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "ปุ่มลัด"},

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "แสดงคำแนะนำ"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "แสดงหรือซ่อนคำแนะนำด้านล่าง"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<สวิตช์การแสดงผล>\n" +
                    "1. ปุ่ม [i]: ซ่อน/แสดง tooltip ทั้งหมดของเกม เช่น อาคาร ประชาชน เครื่องมือ และไอคอนเมนูล่าง\n" +
                    "2. ปุ่มชื่อถนน: ซ่อน/แสดงชื่อถนน ปุ่มลัด: \\.\n" +
                    "3. ปุ่มลูกศรถนน: บังคับแสดง/ซ่อนลูกศรถนนทางเดียว (ซ่อนชื่อถนนด้วย)\n" +
                    "4. ไอคอน CWD บนแถบชื่อ: แสดง/ซ่อน tooltip ของแผง City Watchdog\n" +
                    "\n" +
                    "<ไอคอนแจ้งเตือน>\n" +
                    "1. คลิกปุ่ม City Watchdog มุมซ้ายบน หรือกด Shift+N เพื่อเปิดแผง\n" +
                    "2. ปุ่มเรียงลำดับใช้สลับขึ้น/ลง\n" +
                    "3. Toggle All ใช้ปิด/เปิดทั้งหมดอย่างเร็ว หรือขยายหมวดเพื่อปรับทีละรายการ\n" +
                    "4. ซ่อนเฉพาะไอคอน ไม่ได้แก้ปัญหาของเมือง\n" +
                    "\n" +
                    "<เครื่องมือเงิน>\n" +
                    "1. เพิ่มหรือลดเงิน: ใช้ปุ่มเริ่มต้น [ และ ]\n" +
                    "2. เพิ่มเงินอัตโนมัติจะเพิ่มเงินเมื่อยอดเมืองต่ำกว่าขีดจำกัดที่ตั้งไว้\n" +
                    "3. แปลงเซฟ Unlimited Money ใช้กับเมืองที่เริ่มแบบ Unlimited Money เท่านั้น และ<ย้อนกลับไม่ได้>\n" +
                    "\n" +
                    "<Tooltip เมนูล่าง>\n" +
                    "Money View เพิ่มค่าทิศทางของเงินและประชากร พร้อมรายละเอียดเมื่อชี้เมาส์\n" +
                    "\n" +
                    "<Milestone กำหนดเอง>\n" +
                    "ตั้งเงินเริ่มต้นและ Milestone ใน ตั้งค่าเมืองใหม่ตอนเริ่ม ก่อนโหลดหรือเริ่มเมือง"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), ""},

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "สลับไอคอนแจ้งเตือน"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับคำสั่งเดียวกับปุ่ม <[TOGGLE ALL]> ในเกม\n" +
                    "แสดงหรือซ่อนไอคอนแจ้งเตือนทั้งหมดทันที"},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "แสดง/ซ่อนไอคอนแจ้งเตือนทั้งหมดทันที"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "เปิด/ปิดแผงแจ้งเตือน"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับเปิดหรือปิด\n" +
                    "<แผงแจ้งเตือน> ในเมือง\n" +
                    "เหมือนคลิกปุ่มมุมซ้ายบน"},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "เปิด/ปิดแผงแจ้งเตือน"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "ซ่อน/แสดงชื่อถนน"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อนหรือแสดงชื่อถนนของเกมทันที\n" +
                    "เหมือนไอคอนชื่อถนนในแถบเครื่องมือ City Watchdog"},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "ซ่อน/แสดงชื่อถนน"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "ปิด tooltip เมาส์ทั้งหมด"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อนหรือแสดง tooltip ทั้งหมดของเกม — อาคาร ประชาชน เครื่องมือ และไอคอนเมนูล่าง\n" +
                    "<popup เงิน/ประชากรของ City Watchdog ยังอยู่>; ควบคุมด้วย Money View\n" +
                    "เหมือนไอคอน [i] ในแผง City Watchdog"},
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "ซ่อน/แสดง tooltip ทั้งหมดของเกม"},

                // --------------------------------------------------------------------
                // Actions tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "เงินเริ่มต้น"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "ตั้งยอดเงินเริ่มต้นสำหรับเมืองใหม่แบบ <limited money> หรือเมืองแรกที่โหลด\n" +
                    "แล้วรีเซ็ตเป็น Game Default หลังใช้งาน\n" +
                    "จะเป็นสีเทาหากมีเมืองโหลดอยู่แล้ว\n" +
                    "ตั้งก่อนเริ่ม/โหลดเมือง จากนั้นใช้ <จำนวนเงินปุ่มลัด> หรือ <เพิ่มเงินอัตโนมัติ>"},
                { m_Settings.GetOptionLocaleID("GameDefault"), "ค่าเริ่มต้นเกม"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "ตัวเลือก Milestone"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "เปิด <ก่อนโหลดหรือเริ่มเมือง> เพื่อปลดล็อก milestone ที่เลือกทันทีหลังโหลด\n" +
                    "เปิดไม่ได้เมื่อมีเมืองโหลดอยู่ แต่ปิดได้หากเผลอเปิดไว้\n" +
                    "ถ้าลืม ให้รีสตาร์ทเกมแล้วเลือกก่อนเข้าเมือง\n" +
                    "City Watchdog ย้อน milestone ที่บันทึกแล้วไม่ได้; ใช้เซฟเก่าหากจำเป็น"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "เลือก milestone ที่จะปลดล็อกในการโหลดเมืองครั้งถัดไป\n" +
                    "ปรับได้เฉพาะตอนยังไม่มีเมืองโหลด และหลังเปิด [ตัวเลือก Milestone] [ ✓ ]"},

                // --------------------------------------------------------------------
                // Money tab - In City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "แสดง ToolTips เงิน + ประชากร"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<แนะนำให้เปิด>\n" +
                    "เมนูล่าง: แสดงค่าทิศทางข้างลูกศรเงินและประชากร\n" +
                    "เป็นฟีเจอร์ชี้เมาส์แบบเบา <แสดงผลเท่านั้น>\n" +
                    "ประหยัดเวลาและอาจเบากว่าเปิดแผงข้อมูลเกม"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "ความถี่ Money View"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "เลือกให้ค่าทิศทางเงินและประชากรแสดงรายชั่วโมงหรือรายเดือน\n" +
                    "รายเดือนใช้รายรับลบรายจ่ายและประมาณประชากร 24 ชั่วโมง"},
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "รายชั่วโมง (/h)"},
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "รายเดือน (/mo)"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "รูปแบบ tooltip เงิน"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "เลือกระดับรายละเอียดของ tooltip เงิน\n" +
                    "Compact = ค่าเริ่มต้นเมื่อติดตั้งครั้งแรก\n" +
                    "<Mini> แสดงเฉพาะ Net 2 ค่า สำหรับ /mo และ /h\n" +
                    "<Compact> ย่อเลขใหญ่\n" +
                    "<Full data> แสดงค่าเต็มและช่อง Total"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact"},
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "ข้อมูลเต็ม"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "ขนาดตัวอักษรเงิน"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลข Money View\n" +
                    "ค่าเกม = 100%\n" +
                    "<ค่า mod = 120%>\n" +
                    "ชี้เมาส์ที่เงินด้านล่างจอ"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "ขนาดตัวอักษรประชากร"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลขประชากร\n" +
                    "ค่าเกม = 100%\n" +
                    "<ค่า mod = 120%>\n" +
                    "ชี้เมาส์ที่ประชากรด้านล่างจอ"},

                // --------------------------------------------------------------------
                // Money tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "จำนวนเงินปุ่มลัด"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "ใช้จำนวนนี้กับปุ่มลัดเพิ่มเงินและลดเงิน\n" +
                    "<ค่า mod = 40,000>\n" +
                    "ไม่มีผลถ้าไม่กดปุ่มลัดในเมือง\n" +
                    "ถ้าต้องการอัตโนมัติ ให้เปิดเพิ่มเงินอัตโนมัติ"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "เพิ่มเงิน"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "ปุ่มลัดเพื่อ <เพิ่มเงิน> ในเมือง"},
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "เพิ่มเงิน"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "ลดเงิน"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "ปุ่มลัดเพื่อ <ลดเงิน> ในเมือง"},
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "ลดเงิน"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "เพิ่มเงินอัตโนมัติ"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "เมื่อเปิด [ ✓ ], City Watchdog จะตรวจยอดเงินขณะโหลดเมือง\n" +
                    "- ถ้ายอดเงิน <ต่ำกว่าเกณฑ์>\n" +
                    "  จะเพิ่มจำนวนเงินที่เลือกไว้\n" +
                    "- แนะนำใช้ปุ่มลัดแบบมือ (<[> หรือ <]>) เมื่อจำเป็น แต่มีตัวเลือกนี้ให้ใช้"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "เกณฑ์เงินอัตโนมัติ"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "ถ้าเปิดเพิ่มเงินอัตโนมัติและยอดเงินต่ำกว่าค่านี้\n" +
                    "จะเพิ่มจำนวนเงินที่เลือกไว้"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "จำนวนเงินอัตโนมัติ"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "จำนวนเงินที่เพิ่มแต่ละครั้งเมื่อทำงานอัตโนมัติ\n" +
                    "เลือกให้สูงพอเพื่อให้เมืองกลับมาเกินเกณฑ์"},

                // --------------------------------------------------------------------
                // Money tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "ตัวแปลง Unlimited Money"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<สำรองเมืองก่อน>\n" +
                    "แปลงเมืองที่เริ่มด้วย Unlimited Money ให้เป็นเมืองปกติที่มีงบประมาณ\n" +
                    "เมื่อเมืองที่โหลดเป็นชนิด <Unlimited Money> การเปิดตัวเลือกนี้จะปลดล็อกปุ่ม <[Convert Unlimited Money Save]>\n" +
                    "City Watchdog ย้อนการแปลงนี้ไม่ได้"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "แปลงเมือง Unlimited Money เป็นปกติ"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "สำหรับเมืองที่เริ่มด้วย <Unlimited Money>\n" +
                    "เมื่อโหลดเมืองนั้น จะเปลี่ยนเซฟเป็นงบประมาณ limited money ปกติ\n" +
                    "ปุ่มจะ <ปิด/เป็นสีเทา> หากเมืองที่โหลดไม่ใช่ <Unlimited Money>\n" +
                    "หรือ <ตัวแปลง Unlimited Money> ไม่ได้ ON [ ✓ ]\n" +
                    "สำรองก่อนและใช้ด้วยความเสี่ยงของคุณ"},

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "แปลงเมืองนี้จาก Unlimited Money เป็น limited money ปกติหรือไม่?\n" +
                    "สำรองก่อน; City Watchdog ย้อนกลับไม่ได้\n" +
                    "แน่ใจหรือไม่?"},

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "ชื่อม็อด"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "ชื่อที่แสดงของม็อดนี้"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "เวอร์ชัน"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "เวอร์ชันปัจจุบันของม็อด"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "เปิดหน้า Paradox Mods ของผู้สร้าง"},

                // --------------------------------------------------------------------
                // Debug tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "รายงาน debug ไปยัง log"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<ไม่จำเป็นสำหรับการเล่นปกติ>\n" +
                    "สำหรับผู้ทดสอบและตรวจหลังแพตช์: เขียนรายงานไปที่ <Logs/CityWatchdog.log>"},

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "เปิด log"},
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "เปิด </Logs/CityWatchdog.log> หากมี\n" +
                    "ถ้าไม่มีไฟล์ log จะเปิดโฟลเดอร์ Logs/ แทน"},
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
