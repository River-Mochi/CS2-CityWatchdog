// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: src/Localization/LocaleTH.cs
// Purpose: English (en-US) for City Watchdog Options UI menu.

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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "การทำงาน" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "เงิน-ไมล์สโตน" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "เกี่ยวกับ" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "วิธีใช้" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "การแจ้งเตือน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "ตัวแสดงข้อมูลในเมือง" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "การแจ้งเตือน Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "การตั้งค่าเริ่มเมืองใหม่" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "เงิน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "แปลงเซฟเงินไม่จำกัด" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "การวินิจฉัย" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "แสดงคำแนะนำ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "แสดงหรือซ่อนคำแนะนำด้านล่าง" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<ปุ่มแสดงผล>\n" +
                    "1. ปุ่ม [i]: ซ่อน/แสดง tooltip ของเกมทั้งหมด เช่น อาคาร ชาวเมือง เครื่องมือ และไอคอนเมนูล่าง\n" +
                    "2. ปุ่มชื่อถนน: ซ่อน/แสดงป้ายชื่อถนน ปุ่มลัด: \\.\n" +
                    "3. ปุ่มชื่อเขต: ซ่อน/แสดงชื่อเขตโดยไม่เปลี่ยนขอบเขตเขต\n" +
                    "4. ปุ่มลูกศรถนน: บังคับเปิด/ปิดลูกศรถนนทางเดียว (ซ่อนชื่อถนนด้วย)\n" +
                    "5. ไอคอนแถบชื่อ CWD: แสดง/ซ่อน tooltip ของแผง City Watchdog\n" +
                    "\n" +
                    "<แจ้งเตือน>\n" +
                    "1. คลิกปุ่ม City Watchdog มุมซ้ายบน หรือกด Shift+N เพื่อเปิดแผง\n" +
                    "2. ปุ่มเรียงลำดับขึ้น/ลง\n" +
                    "3. Toggle All ใช้ปิด/เปิดทั้งหมดอย่างรวดเร็ว หรือขยายหมวดเพื่อเปลี่ยนบางรายการ\n" +
                    "4. แสดงหรือซ่อนไอคอนเท่านั้น ไม่ได้แก้ปัญหาในเมือง\n" +
                    "\n" +
                    "<ตัวช่วยเงิน>\n" +
                    "1. เพิ่มหรือลดเงิน: ใช้ <จำนวนเงินของปุ่มลัด> กับปุ่ม [ และ ]\n" +
                    "2. เพิ่มเงินอัตโนมัติจะเพิ่มเงินเมื่อเงินเมืองต่ำกว่าขีดจำกัดที่ตั้งไว้\n" +
                    "3. แปลงเซฟเงินไม่จำกัดใช้เฉพาะเมืองที่เริ่มด้วยเงินไม่จำกัด และ <ย้อนกลับไม่ได้>\n" +
                    "\n" +
                    "<tooltip เมนูล่าง>\n" +
                    "Money View เพิ่มค่าทิศทางเงินและประชากรบนแถบเครื่องมือ พร้อมรายละเอียดเมื่อชี้เมาส์\n" +
                    "\n" +
                    "<ไมล์สโตนกำหนดเอง>\n" +
                    "ตั้งค่าเงินเริ่มต้นและไมล์สโตนใน เงิน-ไมล์สโตน > การตั้งค่าเริ่มเมืองใหม่ ก่อนโหลดหรือเริ่มเมือง"
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "สลับไอคอนแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับคำสั่งเดียวกับปุ่ม <[TOGGLE ALL]> ในเกม\n" +
                    "แสดงหรือซ่อนไอคอนแจ้งเตือนทั้งหมดทันที" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "แสดง/ซ่อนไอคอนแจ้งเตือนทั้งหมดทันที" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับเปิดหรือปิด\n" +
                    "<แผงแจ้งเตือน> ในเมือง\n" +
                    "เหมือนคลิกปุ่มมุมซ้ายบน"
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "เปิด/ปิดแผงแจ้งเตือน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "เริ่มแบบปุ่มอย่างเดียว" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "เมื่อเปิด [ ✓ ] การเปิด City Watchdog จากปุ่มมุมซ้ายบนจะเริ่มเป็นมุมมองปุ่มขนาดเล็ก\n" +
                    "ใช้ลูกศรบนแถบชื่อหรือปุ่มจำนวนแถวเพื่อเปิดแผงเต็ม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "ซ่อน/แสดงชื่อถนน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อนหรือแสดงชื่อถนนของเกมทันที\n" +
                    "เหมือนไอคอนชื่อถนนในแถบเครื่องมือ City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "ซ่อน/แสดงชื่อถนน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "ปิด tooltip เมาส์ทั้งหมด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อนหรือแสดง tooltip ทั้งหมดของเกม — อาคาร ประชาชน เครื่องมือ และไอคอนเมนูล่าง\n" +
                    "<popup เงิน/ประชากรของ City Watchdog ยังอยู่>; ควบคุมด้วย Money View\n" +
                    "เหมือนไอคอน [i] ในแผง City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "ซ่อน/แสดง tooltip ทั้งหมดของเกม" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "แสดง ToolTips เงิน + ประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<แนะนำให้เปิด>\n" +
                    "เมนูล่าง: แสดงค่าทิศทางข้างลูกศรเงินและประชากร\n" +
                    "เป็นฟีเจอร์ชี้เมาส์แบบเบา <แสดงผลเท่านั้น>\n" +
                    "ประหยัดเวลาและอาจเบากว่าเปิดแผงข้อมูลเกม"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "ความถี่ Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "เลือกให้ค่าทิศทางเงินและประชากรแสดงรายชั่วโมงหรือรายเดือน\n" +
                    "รายเดือนใช้รายรับลบรายจ่ายและประมาณประชากร 24 ชั่วโมง" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "รายชั่วโมง (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "รายเดือน (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "รูปแบบ tooltip เงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "เลือกระดับรายละเอียดของ tooltip เงิน\n" +
                    "Compact = ค่าเริ่มต้นเมื่อติดตั้งครั้งแรก\n" +
                    "<Mini> แสดงเฉพาะ Net 2 ค่า สำหรับ /mo และ /h\n" +
                    "<Compact> ย่อเลขใหญ่\n" +
                    "<Full data> แสดงค่าเต็มและช่อง Total" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "ข้อมูลเต็ม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "ขนาดตัวอักษรเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลข Money View\n" +
                    "ค่าเกม = 100%\n" +
                    "<ค่า mod = 120%>\n" +
                    "ชี้เมาส์ที่เงินด้านล่างจอ"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "ขนาดตัวอักษรประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลขประชากร\n" +
                    "ค่าเกม = 100%\n" +
                    "<ค่า mod = 120%>\n" +
                    "ชี้เมาส์ที่ประชากรด้านล่างจอ"
                },

                // --------------------------------------------------------------------
                // Actions tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "การแจ้งเตือน Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "แสดง HUD ขนาดเล็กในเมืองพร้อมจำนวนการแจ้งเตือนที่สำคัญที่สุด\n" +
                    "ใช้เป็นแถบเตือนเร็วโดยไม่ต้องเปิดแผง City Watchdog เต็ม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "ค่าที่แนะนำ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "ใช้การตั้งค่า Mini HUD ที่แนะนำ:\n" +
                    "แจ้งเตือนที่เยอะสุด, 5 ไอคอน, แนวตั้ง, ลากได้, ซ่อนค่า 0 และสไตล์กระจก\n" +
                    "พรีเซ็ตแนวตั้งแบบลากได้จะเริ่มใกล้มุมขวาบน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "โหมด Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "เลือกแถวการแจ้งเตือนที่ Mini HUD ใช้\n" +
                    "แจ้งเตือนสูงสุดจะแสดงจำนวนปัจจุบันที่มากที่สุด\n" +
                    "รายการโปรดจะแสดงเฉพาะแถวที่ติดดาวในแผง City Watchdog" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "แจ้งเตือนสูงสุด" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "รายการโปรด" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "จำนวนไอคอน Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "เลือกจำนวนไอคอนการแจ้งเตือนที่ Mini HUD แสดงได้พร้อมกัน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "แนว Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "เลือกให้ไอคอน Mini HUD เรียงเป็นแถวหรือคอลัมน์" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "แนวนอน" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "แนวตั้ง" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "ตำแหน่ง Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "เลือกตำแหน่งที่ Mini HUD แสดง\n" +
                    "แบบลากได้ช่วยให้ย้ายใน UI เมืองได้" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "บนกลาง" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "บนขวา" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "ลากได้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "ซ่อนแจ้งเตือนที่เป็นศูนย์" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "เมื่อเปิด [ ✓ ] Mini HUD จะซ่อนแถวการแจ้งเตือนที่มีจำนวน 0" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudGlassStyle)), "สไตล์กระจก" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudGlassStyle)),
                    "เพิ่มพื้นหลังแบบกระจกนุ่มๆ หลัง Mini HUD เพื่อให้อ่านง่ายขึ้น" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "เงินเริ่มต้น" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "ตั้งยอดเงินเริ่มต้นสำหรับเมืองใหม่แบบ <limited money> หรือเมืองแรกที่โหลด\n" +
                    "แล้วรีเซ็ตเป็น Game Default หลังใช้งาน\n" +
                    "จะเป็นสีเทาหากมีเมืองโหลดอยู่แล้ว\n" +
                    "ตั้งก่อนเริ่ม/โหลดเมือง จากนั้นใช้ <จำนวนเงินปุ่มลัด> หรือ <เพิ่มเงินอัตโนมัติ>" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ค่าเริ่มต้นเกม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "ตัวเลือก Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "เปิด <ก่อนโหลดหรือเริ่มเมือง> เพื่อปลดล็อก milestone ที่เลือกทันทีหลังโหลด\n" +
                    "เปิดไม่ได้เมื่อมีเมืองโหลดอยู่ แต่ปิดได้หากเผลอเปิดไว้\n" +
                    "ถ้าลืม ให้รีสตาร์ทเกมแล้วเลือกก่อนเข้าเมือง\n" +
                    "City Watchdog ย้อน milestone ที่บันทึกแล้วไม่ได้; ใช้เซฟเก่าหากจำเป็น" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "เลือก milestone ที่จะปลดล็อกในการโหลดเมืองครั้งถัดไป\n" +
                    "ปรับได้เฉพาะตอนยังไม่มีเมืองโหลด และหลังเปิด [ตัวเลือก Milestone] [ ✓ ]" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "จำนวนเงินปุ่มลัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "ใช้จำนวนนี้กับปุ่มลัดเพิ่มเงินและลดเงิน\n" +
                    "<ค่า mod = 40,000>\n" +
                    "ไม่มีผลถ้าไม่กดปุ่มลัดในเมือง\n" +
                    "ถ้าต้องการอัตโนมัติ ให้เปิดเพิ่มเงินอัตโนมัติ"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "เพิ่มเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "ปุ่มลัดเพื่อ <เพิ่มเงิน> ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "เพิ่มเงิน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "ลดเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "ปุ่มลัดเพื่อ <ลดเงิน> ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "ลดเงิน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "เพิ่มเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "เมื่อเปิด [ ✓ ], City Watchdog จะตรวจยอดเงินขณะโหลดเมือง\n" +
                    "- ถ้ายอดเงิน <ต่ำกว่าเกณฑ์>\n" +
                    "  จะเพิ่มจำนวนเงินที่เลือกไว้\n" +
                    "- แนะนำใช้ปุ่มลัดแบบมือ (<[> หรือ <]>) เมื่อจำเป็น แต่มีตัวเลือกนี้ให้ใช้"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "เกณฑ์เงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "ถ้าเปิดเพิ่มเงินอัตโนมัติและยอดเงินต่ำกว่าค่านี้\n" +
                    "จะเพิ่มจำนวนเงินที่เลือกไว้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "จำนวนเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "จำนวนเงินที่เพิ่มแต่ละครั้งเมื่อทำงานอัตโนมัติ\n" +
                    "เลือกให้สูงพอเพื่อให้เมืองกลับมาเกินเกณฑ์" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "ตัวแปลง Unlimited Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<สำรองเมืองก่อน>\n" +
                    "แปลงเมืองที่เริ่มด้วย Unlimited Money ให้เป็นเมืองปกติที่มีงบประมาณ\n" +
                    "เมื่อเมืองที่โหลดเป็นชนิด <Unlimited Money> การเปิดตัวเลือกนี้จะปลดล็อกปุ่ม <[Convert Unlimited Money Save]>\n" +
                    "City Watchdog ย้อนการแปลงนี้ไม่ได้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "แปลงเมือง Unlimited Money เป็นปกติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "สำหรับเมืองที่เริ่มด้วย <Unlimited Money>\n" +
                    "เมื่อโหลดเมืองนั้น จะเปลี่ยนเซฟเป็นงบประมาณ limited money ปกติ\n" +
                    "ปุ่มจะ <ปิด/เป็นสีเทา> หากเมืองที่โหลดไม่ใช่ <Unlimited Money>\n" +
                    "หรือ <ตัวแปลง Unlimited Money> ไม่ได้ ON [ ✓ ]\n" +
                    "สำรองก่อนและใช้ด้วยความเสี่ยงของคุณ" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "แปลงเมืองนี้จาก Unlimited Money เป็น limited money ปกติหรือไม่?\n" +
                    "สำรองก่อน; City Watchdog ย้อนกลับไม่ได้\n" +
                    "แน่ใจหรือไม่?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "ชื่อม็อด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "ชื่อที่แสดงของม็อดนี้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "เวอร์ชัน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "เวอร์ชันปัจจุบันของม็อด" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "เปิดหน้า Paradox Mods ของผู้สร้าง" },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "รายงาน debug ไปยัง log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<ไม่จำเป็นสำหรับการเล่นปกติ>\n" +
                    "สำหรับผู้ทดสอบและตรวจหลังแพตช์: เขียนรายงานไปที่ <Logs/CityWatchdog.log>" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "เปิด log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "เปิด </Logs/CityWatchdog.log> หากมี\n" +
                    "ถ้าไม่มีไฟล์ log จะเปิดโฟลเดอร์ Logs/ แทน" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
