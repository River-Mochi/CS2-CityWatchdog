// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

//
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
            string title = Mod.ModName + " (ยามเมือง)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "การทำงาน" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "ปุ่มลัด" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "เกี่ยวกับ" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "ดีบัก" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "ตัวดูข้อมูล" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "เงิน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "การแจ้งเตือน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "ไมล์สโตน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "แปลงเซฟ" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "ปุ่มลัด" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "วินิจฉัย" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "วิธีใช้" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "แสดงรายละเอียดเมื่อชี้เมาส์" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "แสดงค่าตัวเลขแนวโน้มข้างลูกศรเงินและประชากรแบบ vanilla ที่แถบล่าง\n" +
                    "เป็นการแสดงผลแบบเบาเมื่อชี้เมาส์บนแถบ <แสดงผลเท่านั้น>\n" +
                    "ไม่เปลี่ยนเงินหรือประชากรของเมือง" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "ความถี่ของ Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "เลือกให้ข้อความแนวโน้มบนแถบล่างแสดงค่าเงินและประชากรแบบรายชั่วโมงหรือรายเดือน\n" +
                    "รายเดือนใช้รายรับงบประมาณลบรายจ่ายสำหรับเงิน และใช้การคาดการณ์ 24 ชั่วโมงสำหรับประชากร" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "รายชั่วโมง (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "รายเดือน (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "รูปแบบทูลทิปเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "เลือกจำนวนรายละเอียดที่จะแสดงในทูลทิปเงินเมื่อชี้เมาส์\n" +
                    "กะทัดรัด = ค่าเริ่มต้นเมื่อติดตั้งครั้งแรก\n" +
                    "<มินิ> แสดงเฉพาะค่า Net 2 ค่า สำหรับ /mo และ /h\n" +
                    "<กะทัดรัด> ย่อค่าขนาดใหญ่ (15.21M แทน 15,212,318)\n" +
                    "<ข้อมูลเต็ม> แสดงค่าตัวยาวและช่อง Total" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "มินิ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "กะทัดรัด" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "ข้อมูลเต็ม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "ขนาดตัวอักษรเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลขในทูลทิป Money View\n" +
                    "ค่าเริ่มต้นของเกม = 100%\n" +
                    "<ค่าเริ่มต้นของม็อด = 120%>\n" +
                    "ชี้เมาส์ที่เงินด้านล่างของหน้าจอ\n" +
                    "เพิ่มตามคำขอของผู้เล่นที่มองทูลทิปเล็ก ๆ ในเกมได้ยาก" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "ขนาดตัวอักษรประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลขในทูลทิปประชากร\n" +
                    "ค่าเริ่มต้นของเกม = 100%\n" +
                    "<ค่าเริ่มต้นของม็อด = 120%>\n" +
                    "ชี้เมาส์ที่ประชากรด้านล่างของหน้าจอ" },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "จำนวนเงินของปุ่มลัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "ใช้จำนวนนี้กับปุ่มลัดเพิ่มเงินและลบเงิน\n" +
                    "<ค่าเริ่มต้นของม็อด = 40,000>\n" +
                    "จะไม่ทำอะไรถ้าคุณไม่ได้ใช้ปุ่มลัดเพื่อเพิ่ม/ลบเงินในเมือง\n" +
                    "ถ้าต้องการเงินอัตโนมัติ ให้เปิดตัวเลือกเพิ่มเงินอัตโนมัติ" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "เพิ่มเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "ปุ่มลัดสำหรับ <เพิ่มเงิน> ภายในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "เพิ่มเงิน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "ลบเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "ปุ่มลัดสำหรับ <ลบเงิน> ภายในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "ลบเงิน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "เพิ่มเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "เมื่อเปิด [ ✓ ], City Watchdog จะตรวจยอดเงินของเมืองขณะมีเมืองโหลดอยู่\n" +
                    "- ถ้ายอดเงิน <ต่ำกว่าขีดจำกัด>, \n" +
                    "  จะเพิ่มจำนวนเงินอัตโนมัติที่เลือกไว้\n" +
                    "- แนะนำให้ใช้เงินแบบแมนนวลด้วยปุ่มลัด (<[> หรือ <]>) เมื่อจำเป็น  แทนตัวเลือกอัตโนมัตินี้ แต่มีไว้ให้ถ้าคุณต้องการ" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "ขีดจำกัดเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "ถ้าเปิดเพิ่มเงินอัตโนมัติและยอดเงินของเมืองต่ำกว่าค่านี้\n" +
                    "จะเพิ่มจำนวนเงินอัตโนมัติที่เลือกไว้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "จำนวนเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "จำนวนเงินที่เพิ่มทุกครั้งที่เพิ่มเงินอัตโนมัติทำงาน\n" +
                    "เลือกค่าสูงพอให้เมืองกลับมาอยู่เหนือขีดจำกัดอย่างปลอดภัย" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "เงินเริ่มต้น" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "ตั้งยอดเงินเริ่มต้นสำหรับเมืองใหม่แบบ <เงินจำกัด> หรือเมืองแรกที่โหลด\n" +
                    "จากนั้นรีเซ็ตกลับเป็นค่าเริ่มต้นของเกมหลังจากใช้แล้ว\n" +
                    "ตัวเลือกนี้จะเป็นสีเทาถ้ามีเมืองโหลดอยู่แล้ว\n" +
                    "ตั้งค่าก่อนเริ่ม/โหลดเมือง → ใช้ครั้งเดียว → จากนั้นใช้ <จำนวนเงินของปุ่มลัด> หรือ <เพิ่มเงินอัตโนมัติ>" },

                { m_Settings.GetOptionLocaleID("GameDefault"), "ค่าเริ่มต้นของเกม" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "สลับไอคอนแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับการทำงานเดียวกับปุ่มไอคอน <[TOGGLE ALL]> ในแผงเกม\n" +
                    "แสดงหรือซ่อนไอคอนแจ้งเตือนของเมืองทั้งหมดในรายการทันที" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "แสดง/ซ่อนไอคอนแจ้งเตือนทั้งหมดทันที" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับเปิดหรือปิด\n" +
                    "<แผงแจ้งเตือน> ในเมือง\n" +
                    "ทำงานเหมือนการคลิกไอคอนมุมซ้ายบนเพื่อเปิดแผงเต็ม" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "เปิด/ปิดแผงแจ้งเตือน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "ซ่อน/แสดงชื่อถนน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อนหรือแสดงป้ายชื่อถนนแบบ vanilla ในเมืองทันที\n" +
                    "เหมือนคลิกไอคอนชื่อถนนบนแถบเครื่องมือของแผง City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "ซ่อน/แสดงชื่อถนน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "ปิดทูลทิปเมื่อชี้เมาส์ทั้งหมด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อนหรือแสดงทูลทิปทั้งหมดเมื่อชี้เมาส์ในเกมทันที — อาคาร, cims, เครื่องมือ และไอคอนเมนูล่าง\n" +
                    "<ป๊อปอัปเงิน/ประชากรของ City Watchdog ยังคงเปิดอยู่> ซึ่งควบคุมโดยตัวเลือก Money View ด้านบน\n" +
                    "เหมือนกับการคลิกไอคอน [i] บนแผง City Watchdog ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "ซ่อน/แสดงทูลทิปเกมทั้งหมด" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "ตัวเลือกไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "เปิดก่อนโหลดหรือเริ่มเมืองเพื่อปลดล็อกไมล์สโตนที่เลือกทันทีหลังจากเมืองโหลดเสร็จ\n" +
                    "ไม่สามารถเปิดขณะมีเมืองโหลดอยู่ แต่สามารถปิดได้ถ้าเปิดค้างไว้โดยไม่ตั้งใจ\n" +
                    "ถ้าลืมและโหลดเมืองไปแล้ว แค่รีสตาร์ทเกม แล้วเลือกหมุดหมายก่อนเข้าเมือง\n" +
                    "City Watchdog ไม่สามารถย้อนการเปลี่ยนไมล์สโตนที่บันทึกลงเมืองแล้วได้; ใช้เซฟก่อนหน้าถ้าจำเป็น" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "ไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "เลือกระดับไมล์สโตนที่จะปลดล็อกในการโหลดเมืองครั้งถัดไป\n" +
                    "ปรับได้เฉพาะตอนอยู่นอกเมืองที่โหลดแล้ว และต้องเปิด [ตัวเลือกไมล์สโตน] [ ✓ ] ก่อน" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "ตัวแปลงเงินไม่จำกัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<สำรองเมืองก่อน>.\n" +
                    "แปลงเมืองที่เริ่มด้วยเงินไม่จำกัดให้เป็นเมืองปกติที่มีความท้าทายเรื่องเงินตามปกติ\n" +
                    "เมื่อเปิด ตัวเลือกนี้จะปลดล็อกปุ่ม <[แปลงเซฟเงินไม่จำกัด]> เมื่อเมืองที่โหลดเป็นประเภท <เงินไม่จำกัด>\n" +
                    "City Watchdog ไม่สามารถย้อนการแปลงนี้ได้\n" +
                    "ถ้าคุณมีเมืองปกติ ไม่ต้องกังวล; ไม่จำเป็นต้องใช้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "แปลงเมืองเงินไม่จำกัดเป็นเมืองปกติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "สำหรับเมืองที่เริ่มด้วย <เงินไม่จำกัด>\n" +
                    "ขณะเมืองนั้นโหลดอยู่ ตัวเลือกนี้จะแปลงเซฟเป็นงบประมาณเงินจำกัดแบบปกติ เพื่อให้เมืองกลับมามีความท้าทายเรื่องเงินอีกครั้ง\n" +
                    "ปุ่มจะ <ปิดใช้/เป็นสีเทา> เว้นแต่เมืองที่โหลดจะเป็นประเภท <เงินไม่จำกัด>\n" +
                    "และ <ตัวแปลงเงินไม่จำกัด> เป็น ON [ ✓ ]\n" +
                    "ทำเซฟสำรองและใช้ด้วยความเสี่ยงของคุณเอง; City Watchdog ไม่สามารถย้อนการแปลงนี้ได้" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "แปลงเมืองนี้จากเงินไม่จำกัดเป็นเงินจำกัดแบบปกติหรือไม่?\n" +
                    "บันทึกสำรองก่อน; City Watchdog ไม่สามารถย้อนกลับได้\n" +
                    "แน่ใจหรือไม่?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "ชื่อม็อด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "ชื่อที่แสดงของม็อดนี้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "เวอร์ชัน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "เวอร์ชันปัจจุบันของม็อด" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "เปิดหน้าของผู้สร้างใน Paradox Mods" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "รายงานดีบักไปยัง log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<ไม่จำเป็นสำหรับการเล่นปกติ>\n" +
                    "สำหรับผู้ทดสอบและการเช็กหลังแพตช์เกม: เขียนรายงาน <Logs/CityWatchdog.log>\n" +
                    "เพื่อเปรียบเทียบ prefab การแจ้งเตือนสดของเกมกับไอคอนแจ้งเตือนที่ Watchdog ควบคุมอยู่" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "เปิด log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "เปิด </Logs/CityWatchdog.log> ถ้ามีอยู่\n" +
                    "ถ้าไม่มีไฟล์ log จะเปิดโฟลเดอร์ Logs/ แทน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "แสดงคำแนะนำ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "แสดงหรือซ่อนคำแนะนำการใช้งานด้านล่าง" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<สวิตช์การแสดงผล>\n" +
                    "1. ปุ่ม [i]: ซ่อน/แสดงทูลทิปเกมทั้งหมดเมื่อชี้เมาส์ (อาคาร, cims, เครื่องมือ, ไอคอนเมนูล่าง)\n" +
                    "2. ปุ่มชื่อถนน: ซ่อน/แสดงป้ายชื่อถนน ปุ่มลัด: \\.\n" +
                    "3. ปุ่มลูกศรถนน: บังคับเปิด/ปิดลูกศรถนนทางเดียว (ซ่อนชื่อถนนด้วย)\n" +
                    "4. ไอคอนแถบชื่อ CWD: แสดง/ซ่อนทูลทิปของแผง City Watchdog\n" +
                    "\n" +
                    "<แจ้งเตือน>\n" +
                    "1. คลิกปุ่ม City Watchdog (ซ้ายบน) หรือกด Shift+N เพื่อเปิดแผง\n" +
                    "2. ปุ่มจัดเรียงสำหรับน้อยไปมาก/มากไปน้อย\n" +
                    "3. Toggle All เพื่อ Off/On ทั้งหมดอย่างรวดเร็ว หรือขยายหมวดเพื่อเปลี่ยนไอคอนเฉพาะ\n" +
                    "4. แสดงหรือซ่อนไอคอนเท่านั้น; ไม่ได้แก้ปัญหาของเมือง\n" +
                    "\n" +
                    "<ตัวช่วยเงิน>\n" +
                    "1. เพิ่มหรือลบเงิน: ใช้ปุ่มเริ่มต้นของ <จำนวนเงินของปุ่มลัด> [ และ ]\n" +
                    "2. เพิ่มเงินอัตโนมัติจะเพิ่มเงินเมื่อเมืองต่ำกว่าขีดจำกัดที่คุณตั้งไว้\n" +
                    "3. แปลงเซฟเงินไม่จำกัดใช้เฉพาะเมืองที่เริ่มด้วยเงินไม่จำกัด และ <ย้อนกลับไม่ได้>\n" +
                    "\n" +
                    "<ทูลทิปเมนูล่าง>\n" +
                    "Money View เพิ่มค่าแนวโน้มให้แถบเงินและประชากร พร้อมรายละเอียดเพิ่มเมื่อชี้เมาส์\n" +
                    "\n" +
                    "<ไมล์สโตนกำหนดเอง>\n" +
                    "ตั้งเงินเริ่มต้นและเลือกไมล์สโตนจากเมนูตัวเลือกก่อนโหลดหรือเริ่มเมือง" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
