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
        private readonly CwdSettings m_Settings;

        public LocaleTH(CwdSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName + " (ผู้เฝ้าเมือง)";

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.Actions), "การทำงาน" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.MoneyTab), "เงิน-ไมล์สโตน" },
                { m_Settings.GetOptionTabLocaleID(CwdSettings.About), "เกี่ยวกับ" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutUsage), "วิธีใช้" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Notifications), "การแจ้งเตือน" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MoneyViewGroup), "ข้อมูลในเมือง" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.MiniHudGroup), "แจ้งเตือน Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Milestone), "ตั้งค่าเมืองใหม่" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.Money), "เงิน" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.SaveConversion), "แปลงเซฟเงินไม่จำกัด" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(CwdSettings.AboutDiagnostics), "วินิจฉัย" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ShowUsage)), "แสดงคำแนะนำ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ShowUsage)), "แสดงหรือซ่อนคำแนะนำด้านล่าง" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.UsageText)),
                    "A. ใช้ไอคอนอุ้งเท้ามุมซ้ายบนของเมือง หรือกด Shift+N เพื่อเปิดแผงหลัก\n" +
                    "<ปุ่มแสดงผล>\n" +
                    "1. ไอคอนแถบชื่อ: แสดง/ซ่อน tooltip ของ City Watchdog\n" +
                    "\n" +
                    "2. ปุ่ม **[i]**: ซ่อน/แสดง tooltip ของเกม <ทั้งหมด> เช่น อาคาร ชาวเมือง เครื่องมือ ไอคอนเมนูล่าง\n" +
                    "3. ปุ่มถนน: ซ่อน/แสดงชื่อถนน ปุ่มลัด: \\.\n" +
                    "4. ปุ่มเขต: ซ่อน/แสดงชื่อเขต\n" +
                    "5. ปุ่มลูกศรถนน: บังคับลูกศรทางเดียว ON/OFF (ซ่อนชื่อถนนด้วย)\n" +
                    "\n" +
                    "<แจ้งเตือน>\n" +
                    "1. ปุ่มเรียงลำดับ: A→Z, Z→A, เฉพาะที่ active\n" +
                    "2. <[0/62]> = ไอคอน ON/ทั้งหมด คลิกเพื่อขยาย/ย่อทุกแถว\n" +
                    "3a. [สลับทั้งหมด] ปิด/เปิดไอคอนแจ้งเตือนทั้งหมดทันที\n" +
                    "3b. ซ่อนแค่ไอคอน ไม่ได้แก้ปัญหาในเมือง\n" +
                    "\n" +
                    "<ช่วยเรื่องเงิน>\n" +
                    "1. เพิ่ม / ลบเงิน: ใช้ปุ่มเริ่มต้น <[ หรือ ]> สำหรับ <จำนวนเงินปุ่มลัด>\n" +
                    "2. เงินอัตโนมัติจะเติมเงินเมื่อเงินเมืองต่ำกว่าขีดที่ตั้งไว้\n" +
                    "3. แปลงเซฟเงินไม่จำกัดใช้เฉพาะเมืองที่เริ่มด้วยเงินไม่จำกัด และ <ย้อนกลับไม่ได้>\n" +
                    "\n" +
                    "<tooltip เมนูล่าง>\n" +
                    "มุมมองเงิน เพิ่มรายละเอียด เช่น แนวโน้ม เมื่อชี้เมาส์บนเงินหรือประชากร\n" +
                    "\n" +
                    "<ไมล์สโตนกำหนดเอง>\n" +
                    "เงิน-ไมล์สโตน > ตั้งค่าเมืองใหม่ ใช้ตั้งเงินเริ่มต้นหรือไมล์สโตนก่อนโหลด/เริ่มเมือง" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)), "สลับไอคอนแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationsKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับคำสั่งเดียวกับปุ่ม <[สลับทั้งหมด]> ในเกม\n" +
                    "แสดงหรือซ่อนไอคอนแจ้งเตือนทั้งหมดในรายการทันที" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationsAction), "แสดง/ซ่อนไอคอนแจ้งเตือนทั้งหมด" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleNotificationPanelKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับเปิดหรือปิด\n" +
                    "<แผงแจ้งเตือน> ในเมือง\n" +
                    "เหมือนคลิกไอคอนมุมซ้ายบน" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleNotificationPanelAction), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)), "เริ่มแบบปุ่มล้วน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PanelButtonsOnlyStart)),
                    "เมื่อเปิด [ ✓ ] City Watchdog จะเปิดเป็นมุมมองเล็กแบบปุ่มล้วนก่อน\n" +
                    "ใช้ลูกศรแถบชื่อหรือปุ่มจำนวนแถวเพื่อเปิดแผงเต็ม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)), "ซ่อน/แสดงชื่อถนน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleRoadNamesKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อน/แสดงชื่อถนนเดิมของเกมทันที\n" +
                    "เหมือนไอคอนชื่อถนนใน City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleRoadNamesAction), "ซ่อน/แสดงชื่อถนน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)), "ปิด tooltip hover ทั้งหมด" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ToggleAllTooltipsKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อน/แสดง tooltip hover ของเกมทั้งหมด: อาคาร ชาวเมือง เครื่องมือ และไอคอนล่าง\n" +
                    "<popup เงิน/ประชากรของ City Watchdog ยังอยู่>; ควบคุมโดย มุมมองเงิน\n" +
                    "เหมือนไอคอน [i] ในแผง City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.ToggleAllTooltipsAction), "ซ่อน/แสดง tooltip hover ของเกม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MainPanelOpacity)), "ความทึบของแผงหลัก" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MainPanelOpacity)),
                    "ปรับความโปร่งใสของพื้นหลังแผงการแจ้งเตือนหลัก\n" +
                    "ค่าต่ำจะโปร่งใสมากขึ้น ค่าสูงจะมืดและทึบมากขึ้น" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyView)), "แนวโน้มเงิน + tooltip ประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyView)),
                    "<แนะนำให้เปิด>\n" +
                    "เมนูล่าง: แสดงค่าแนวโน้มที่ลูกศร <เงินและประชากร>\n" +
                    "ฟีเจอร์ hover แบบเบา <แสดงผลเท่านั้น>;\n" +
                    "ประหยัดเวลาและอาจลื่นกว่าเปิดแผงข้อมูลเกม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyViewMode)), "ความถี่ มุมมองเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyViewMode)),
                    "เลือกให้แถบล่างแสดงค่ารายชั่วโมงหรือรายเดือน\n" +
                    "รายเดือนใช้รายรับลบรายจ่าย และคาดการณ์ประชากร 24 ชม." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "รายชั่วโมง (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "รายเดือน (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipMode)), "สไตล์ tooltip เงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipMode)),
                    "เลือกว่าจะแสดงรายละเอียดเงินมากแค่ไหน\n" +
                    "กะทัดรัด = ค่าเริ่มต้นเมื่อติดตั้งครั้งแรก\n" +
                    "<Mini> แสดง Net แค่ 2 ค่า สำหรับ /mo และ /h\n" +
                    "<กะทัดรัด> ย่อเลขใหญ่ (เช่น 15.21M)\n" +
                    "<ข้อมูลเต็ม> แสดงค่ายาวและยอดรวม" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "กะทัดรัด" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "ข้อมูลเต็ม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)), "ขนาดตัวอักษรเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MoneyTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลข มุมมองเงิน\n" +
                    "ค่าเกม = 100%\n" +
                    "<ค่า mod = 120%>\n" +
                    "ชี้เมาส์ที่เงินด้านล่างจอ\n" +
                    "สำหรับผู้เล่นที่อ่าน tooltip เล็กยาก" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)), "ขนาดตัวอักษรประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.PopulationTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลขประชากร\n" +
                    "ค่าเกม = 100%\n" +
                    "<ค่า mod = 120%>\n" +
                    "ชี้เมาส์ที่ประชากรด้านล่างจอ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudEnabled)),
                    "แสดง HUD เล็กพร้อมจำนวนแจ้งเตือนสำคัญ\n" +
                    "ใช้เป็นแถบเตือนเร็วโดยไม่ต้องเปิดแผงเต็ม\n" +
                    "คลิกไอคอนเพื่อไปยังปัญหาที่ตรงกัน\n" +
                    "คลิกซ้ำเพื่อวนจุดที่ตรงกัน แล้วกลับจุดแรก" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)), "คลิก: เริ่มเร็ว" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ApplyMiniHudRecommendedPreset)),
                    "ใช้ <ตั้งค่าเริ่มเร็ว> สำหรับแผงย่อ:\n" +
                    "มี **ชุดเริ่มต้นดาวสีน้ำเงิน**.\n" +
                    "แจ้งเตือนที่มี **ดาวสีน้ำเงิน** จะมีสิทธิ์แสดงในแผงย่อ ถ้าอยู่ใน 5 หรือ 10 อันดับแรกตามจำนวนรวม.\n" +
                    "เพิ่ม/ลบ **ดาวสีน้ำเงิน** ในแผง Watchdog แบบขยาย.\n" +
                    "ชุดนี้รวม: รายการโปรด, 5 ไอคอน, แนวตั้ง, ลากได้, ขนาด 100 %, แผงมืด, ซ่อนไอคอนที่นับได้ 0."
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudMode)), "โหมดแผงย่อ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudMode)),
                    "เลือกแถวแจ้งเตือนที่แผงย่อจะใช้.\n" +
                    "**ใช้งานสูงสุด** แสดงจำนวนปัจจุบันที่สูงที่สุด.\n" +
                    "**รายการโปรด** ใช้แถวที่มี **ดาวสีน้ำเงิน** ในแผงหลัก City Watchdog.\n" +
                    "เลือกได้กี่รายการโปรดก็ได้,\n" +
                    "แต่แผงย่อจะแสดงแค่ 5 หรือ 10 อันดับแรกจากรายการ **ดาวสีน้ำเงิน** นี้."
                  },          
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "แจ้งเตือน active สูงสุด" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "รายการโปรด" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudItemCount)), "จำนวนไอคอน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudItemCount)), "เลือกจำนวนไอคอนที่ Mini HUD แสดงได้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudScale)), "ขนาดไอคอน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudScale)),
                    "ปรับขนาดไอคอนและตัวเลข Mini HUD\n" +
                    "90% = กะทัดรัด 100% = ค่าเริ่มต้น เพิ่มได้ถึง 130%" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudOrientation)), "ทิศทาง" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudOrientation)), "เลือกแนวนอนหรือแนวตั้ง" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "แนวนอน" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "แนวตั้ง" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPlacement)), "ตำแหน่ง HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPlacement)),
                    "เลือกตำแหน่ง Mini HUD\n" +
                    "แบบลากได้จะย้ายใน UI เมืองได้" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "บนกลาง" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "บนขวา" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "ลากได้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelStyle)), "สไตล์มืดหรือกระจก" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelStyle)),
                    "เลือกพื้นหลัง Mini HUD\n" +
                    "กระจกจะจากใสไปเป็นขาวหม่น ไม่มืดลง\n" +
                    "ใช้แผงมืดเพื่อ HUD แบบเกมที่เข้มขึ้น" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "แผงมืด" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "แผงกระจก" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)), "ความทึบพื้นหลัง" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudPanelOpacity)),
                    "ปรับความโปร่งใสพื้นหลัง Mini HUD\n" +
                    "ค่าน้อย = โปร่งใสกว่า ค่าสูง = ทึบกว่า\n" +
                    "กระจกจะขาวขึ้น มืดจะเข้มขึ้น" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MiniHudHideZero)), "ซ่อนแจ้งเตือน 0" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MiniHudHideZero)), "เมื่อเปิด [ ✓ ] Mini HUD จะซ่อนแถวที่มีจำนวน 0" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.InitialMoney)), "เงินเริ่มต้น" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.InitialMoney)),
                    "ตั้งเงินเริ่มต้นสำหรับเมืองใหม่แบบ <เงินจำกัด> หรือเมืองแรกที่โหลด\n" +
                    "แล้วรีเซ็ตกลับค่าเกม\n" +
                    "เป็นสีเทาหากโหลดเมืองอยู่แล้ว\n" +
                    "ตั้งก่อนโหลด/เริ่มเมือง จากนั้นใช้ <จำนวนเงินปุ่มลัด> หรือ <เงินอัตโนมัติ>" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ค่าเกม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.CustomMilestone)), "เลือกไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.CustomMilestone)),
                    "เปิด <ก่อนโหลดหรือเริ่มเมือง> เพื่อปลดล็อกไมล์สโตนที่เลือกเมื่อโหลดเมือง\n" +
                    "- เปิดไม่ได้หลังโหลดเมืองแล้ว แต่ปิดได้ถ้าเปิดไว้ผิด\n" +
                    "- ถ้าลืม ให้รีสตาร์ทเกม แล้วเลือกก่อนเข้าเมือง\n" +
                    "- mod ย้อนการเปลี่ยนไมล์สโตนที่บันทึกแล้วไม่ได้ ใช้เซฟเก่าหากจำเป็น" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.MilestoneLevel)), "ไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.MilestoneLevel)),
                    "เลือกไมล์สโตนที่จะปลดล็อกในการโหลดเมืองครั้งถัดไป\n" +
                    "ปรับได้ <เฉพาะนอกเมืองที่โหลดแล้ว> และเมื่อ [เลือกไมล์สโตน] เปิด [ ✓ ]\n" +
                    "ถ้าเมืองถึงหรือเกินไมล์สโตนนี้แล้ว จะไม่เกิดอะไร\n" +
                    "จะเปลี่ยนเฉพาะเมื่อไมล์สโตนที่เลือกสูงกว่าเดิม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ManualMoneyAmount)), "จำนวนเงินปุ่มลัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ManualMoneyAmount)),
                    "ใช้จำนวนนี้กับปุ่มลัดเพิ่มเงินและลบเงิน\n" +
                    "<ค่า mod = 40,000>\n" +
                    "ไม่ทำงานถ้าไม่ใช้ปุ่มลัดในเมือง\n" +
                    "ถ้าต้องการอัตโนมัติ ให้เปิดเงินอัตโนมัติ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "เพิ่มเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AddMoneyKeyboardBinding)), "ปุ่มลัดสำหรับ <เพิ่มเงิน> ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.AddMoneyAction), "เพิ่มเงิน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "ลบเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.SubtractMoneyKeyboardBinding)), "ปุ่มลัดสำหรับ <ลบเงิน> ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(CwdSettings.SubtractMoneyAction), "ลบเงิน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoney)), "เงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoney)),
                    "เมื่อเปิด [ ✓ ] City Watchdog จะตรวจเงินเมือง\n" +
                    "- ถ้าเงิน <ต่ำกว่าขีดจำกัด>\n" +
                    "  จะเพิ่มจำนวนที่เลือก\n" +
                    "- แนะนำให้ใช้เงินแบบกดเองด้วยปุ่มลัด (<[> หรือ <]>) เมื่อจำเป็น\n" +
                    "  แต่ออปชันนี้มีไว้ให้ถ้าต้องการ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)), "ขีดจำกัดเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyThreshold)),
                    "ถ้าเปิดและเงินเมืองต่ำกว่าค่านี้\n" +
                    "จะเพิ่มจำนวนที่เลือก" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)), "จำนวนเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.AutomaticAddMoneyAmount)),
                    "จำนวนเงินที่เพิ่มทุกครั้งที่ระบบทำงาน\n" +
                    "เลือกให้พอขึ้นเหนือขีดจำกัด" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)), "ตัวแปลงเงินไม่จำกัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<สำรองเมืองก่อน>\n" +
                    "แปลงเมืองที่เริ่มด้วยเงินไม่จำกัดเป็นเมืองปกติ\n" +
                    "เปิดสิ่งนี้เพื่อปลดล็อกปุ่ม <[แปลงเซฟเงินไม่จำกัด]> เมื่อเมืองที่โหลดเป็น <เงินไม่จำกัด>\n" +
                    "City Watchdog ย้อนกลับไม่ได้\n" +
                    "เมืองปกติไม่จำเป็นต้องใช้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)), "แปลงเมืองเงินไม่จำกัดเป็นปกติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "สำหรับเมืองที่เริ่มด้วย <เงินไม่จำกัด>\n" +
                    "เมื่อโหลดเมืองนั้นอยู่ จะเปลี่ยนเซฟเป็นงบจำกัดปกติ\n" +
                    "ปุ่มจะ <ปิด/เทา> เว้นแต่เมืองเป็น <เงินไม่จำกัด>\n" +
                    "และ <ตัวแปลงเงินไม่จำกัด> เป็น ON [ ✓ ]\n" +
                    "สำรองก่อนและใช้ด้วยความเสี่ยงเอง; City Watchdog ย้อนกลับไม่ได้" },
                { m_Settings.GetOptionWarningLocaleID(nameof(CwdSettings.ConvertUnlimitedMoneySave)),
                    "แปลงเมืองนี้จากเงินไม่จำกัดเป็นเงินจำกัดปกติหรือไม่?\n" +
                    "สำรองก่อน; City Watchdog ย้อนกลับไม่ได้\n" +
                    "แน่ใจไหม?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.NameText)), "ชื่อ mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.NameText)), "ชื่อที่แสดงของ mod นี้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.VersionText)), "เวอร์ชัน" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.VersionText)), "เวอร์ชัน mod ปัจจุบัน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenParadox)), "เปิดหน้า Paradox Mods ของผู้สร้าง" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)), "รายงาน debug ลง log" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.WriteNotificationAuditLog)),
                    "<ไม่จำเป็นสำหรับการเล่นปกติ>\n" +
                    "สำหรับเทสเตอร์และเช็กหลังแพตช์: เขียนรายงานลง <Logs/CityWatchdog.log>\n" +
                    "เทียบ prefab แจ้งเตือนเกมกับไอคอนที่ Watchdog คุม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(CwdSettings.OpenLog)), "เปิด log" },
                { m_Settings.GetOptionDescLocaleID(nameof(CwdSettings.OpenLog)),
                    "เปิด </Logs/CityWatchdog.log> ถ้ามี\n" +
                    "ถ้าไม่มี จะเปิดโฟลเดอร์ Logs/" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
