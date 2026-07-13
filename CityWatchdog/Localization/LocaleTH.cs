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
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "คำสั่ง" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "มินิ HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "เงิน-ไมล์สโตน" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "เกี่ยวกับ" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "วิธีใช้" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "การแจ้งเตือน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "ข้อมูลในเมือง" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "แจ้งเตือนมินิ HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "ตั้งค่าเมืองใหม่" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "เงิน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "แปลงเซฟเงินไม่จำกัด" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "วินิจฉัย" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "แสดงวิธีใช้" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "แสดงหรือซ่อนคำแนะนำด้านล่าง" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<ปุ่มแสดงผล>\n" +
                    "1. ปุ่ม [i]: ซ่อน/แสดงทูลทิปทั้งหมดของเกม เช่น อาคาร ชาวเมือง เครื่องมือ และไอคอนเมนูล่าง\n" +
                    "2. ปุ่มชื่อถนน: ซ่อน/แสดงป้ายชื่อถนน ปุ่มลัด: \\.\n" +
                    "3. ปุ่มชื่อเขต: ซ่อน/แสดงชื่อเขต โดยไม่เปลี่ยนขอบเขต\n" +
                    "4. ปุ่มลูกศรถนน: บังคับเปิด/ปิดลูกศรถนนทางเดียว (ซ่อนชื่อถนนด้วย)\n" +
                    "5. ไอคอน CWD บนแถบชื่อ: แสดง/ซ่อนทูลทิปของแผง City Watchdog\n" +
                    "\n" +
                    "<แจ้งเตือน>\n" +
                    "1. คลิกปุ่ม City Watchdog มุมซ้ายบน หรือกด Shift+N เพื่อเปิดแผง\n" +
                    "2. ปุ่มเรียงลำดับ: น้อยไปมาก/มากไปน้อย\n" +
                    "3. สลับทั้งหมดเพื่อปิด/เปิดเร็ว หรือเปิดหมวดเพื่อปรับทีละรายการ\n" +
                    "4. แค่ซ่อนหรือแสดงไอคอน ไม่ได้แก้ปัญหาของเมือง\n" +
                    "\n" +
                    "<ช่วยเรื่องเงิน>\n" +
                    "1. เพิ่มหรือลดเงิน: ใช้ <จำนวนเงินปุ่มลัด> ค่าเริ่มต้นคือ [ และ ]\n" +
                    "2. เพิ่มเงินอัตโนมัติจะเติมเงินเมื่อเมืองต่ำกว่าขีดที่ตั้งไว้\n" +
                    "3. แปลงเซฟเงินไม่จำกัดใช้เฉพาะเมืองที่เริ่มด้วยเงินไม่จำกัด และ<ย้อนกลับไม่ได้>\n" +
                    "\n" +
                    "<ทูลทิปเมนูล่าง>\n" +
                    "ตัวแสดงเงินเพิ่มแนวโน้มเงิน/ประชากรบนแถบล่าง และรายละเอียดเมื่อชี้เมาส์\n" +
                    "\n" +
                    "<ไมล์สโตนกำหนดเอง>\n" +
                    "ตั้งเงินเริ่มต้นและเลือกไมล์สโตนใน เงิน-ไมล์สโตน > ตั้งค่าเมืองใหม่ ก่อนโหลดหรือเริ่มเมือง" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "สลับไอคอนแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<ปุ่มลัด> สำหรับคำสั่งเดียวกับปุ่มไอคอน <[สลับทั้งหมด]> ในเกม\n" +
                    "แสดงหรือซ่อนไอคอนแจ้งเตือนทั้งหมดในรายการทันที" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "แสดง/ซ่อนไอคอนแจ้งเตือนทั้งหมดทันที" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<ปุ่มลัด> เพื่อเปิดหรือปิด\n" +
                    "<แผงแจ้งเตือน> ในเมือง\n" +
                    "ทำงานเหมือนคลิกไอคอนซ้ายบน" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "เริ่มแบบปุ่มอย่างเดียว" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "เมื่อเปิด [ ✓ ] การเปิด City Watchdog จากปุ่มซ้ายบนจะเริ่มด้วยมุมมองเล็กแบบปุ่มอย่างเดียว\n" +
                    "ใช้ลูกศรแถบชื่อหรือปุ่มนับแถวเพื่อเปิดแผงเต็ม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "ซ่อน/แสดงชื่อถนน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<ปุ่มลัด> เพื่อซ่อนหรือแสดงป้ายชื่อถนนของเกมหลักทันที\n" +
                    "เหมือนไอคอนชื่อถนนในแผง City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "ซ่อน/แสดงชื่อถนน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "ปิดทูลทิปเมื่อชี้เมาส์ทั้งหมด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "<ปุ่มลัด> เพื่อซ่อนหรือแสดงทูลทิปทั้งหมดของเกมทันที — อาคาร ชาวเมือง เครื่องมือ และไอคอนเมนูล่าง\n" +
                    "<ป็อปอัปเงิน/ประชากรของ City Watchdog ยังเปิดอยู่>; ควบคุมด้วยตัวเลือกตัวแสดงเงิน\n" +
                    "เหมือนไอคอน [i] ในแผง City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "ซ่อน/แสดงทูลทิปเกมทั้งหมด" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "แสดงทูลทิปเงิน + ประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "<แนะนำให้เปิด>\n" +
                    "เมนูล่าง: แสดงค่าแนวโน้มกับ <ลูกศรเงินและประชากร> บนแถบเครื่องมือ\n" +
                    "เป็นฟีเจอร์ชี้เมาส์แบบเบา <แสดงผลเท่านั้น>;\n" +
                    "ประหยัดเวลาและอาจลื่นกว่าเปิดแผงข้อมูลของเกม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "ความถี่ตัวแสดงเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "เลือกให้ข้อความแนวโน้มด้านล่างแสดงค่าเงินและประชากรแบบรายชั่วโมงหรือรายเดือน\n" +
                    "รายเดือนใช้รายรับงบประมาณลบรายจ่าย และคาดการณ์ประชากร 24 ชั่วโมง" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "รายชั่วโมง (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "รายเดือน (/เดือน)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "รูปแบบทูลทิปเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "เลือกจำนวนรายละเอียดในทูลทิปเงิน\n" +
                    "กะทัดรัด = ค่าเริ่มต้นเมื่อติดตั้งครั้งแรก\n" +
                    "<มินิ> แสดงแค่ค่าสุทธิ 2 ค่า สำหรับ /เดือน และ /h\n" +
                    "<กะทัดรัด> ย่อเลขใหญ่ (15.21M แทน 15,212,318)\n" +
                    "<ข้อมูลเต็ม> แสดงเลขยาวและยอดรวม" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "มินิ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "กะทัดรัด" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "ข้อมูลเต็ม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "ขนาดตัวอักษรเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "ปรับ <ขนาดตัวอักษร> ของตัวเลขในทูลทิปเงิน\n" +
                    "ค่าเกมเดิม = 100%\n" +
                    "<ค่าเริ่มต้นม็อด = 120%>\n" +
                    "ชี้เมาส์ที่เงินด้านล่างหน้าจอ\n" +
                    "สำหรับผู้เล่นที่อ่านทูลทิปเล็กยาก" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "ขนาดตัวอักษรประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "ปรับ <ขนาดตัวอักษร> ของตัวเลขทูลทิปประชากร\n" +
                    "ค่าเกมเดิม = 100%\n" +
                    "<ค่าเริ่มต้นม็อด = 120%>\n" +
                    "ชี้เมาส์ที่ประชากรด้านล่างหน้าจอ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "มินิ HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)), "แสดง HUD เมืองขนาดเล็กพร้อมจำนวนแจ้งเตือนสำคัญ\n" +
                    "ใช้เป็นแถบเตือนเร็ว โดยไม่ต้องเปิดแผง City Watchdog เต็ม\n" +
                    "คลิกไอคอนเพื่อข้ามไปยังจุดปัญหาที่ตรงกัน\n" +
                    "คลิกไอคอนเดิมต่อเพื่อวนจุดที่ตรงกัน แล้วกลับจุดแรก" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "ชุดเริ่มเร็ว" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "ใช้การตั้งค่ามินิ HUD ที่แนะนำ:\n" +
                    "รายการโปรด, 5 ไอคอน, แนวนอน, บนกลาง, ขนาด 100%, แผงสีเข้ม\n" +
                    "แจ้งเตือนที่นับเป็นศูนย์ยังแสดงอยู่\n" +
                    "เพิ่ม/ลบรายการโปรด **ดาวสีน้ำเงิน** ได้ทุกเวลาในแผง Watchdog แบบขยาย\n" +
                    "ชุดเริ่มต้น **ดาวสีน้ำเงิน** รวมอยู่ใน **[แนะนำ]**" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "โหมดมินิ HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)), "เลือกแถวแจ้งเตือนที่มินิ HUD ใช้\n" +
                    "**แจ้งเตือนสูงสุด** แสดงจำนวนปัจจุบันที่สูงที่สุด\n" +
                    "**รายการโปรด** รวมทุกแถวที่ทำเครื่องหมาย **ดาวสีน้ำเงิน** ในแผงหลัก\n" +
                    "เลือกกี่รายการโปรดก็ได้\n" +
                    "แต่มินิ HUD จะแสดงเฉพาะ 5 หรือ 10 จำนวนสูงสุดจากรายการ **ดาวสีน้ำเงิน** นั้น" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "แจ้งเตือนสูงสุด" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "รายการโปรด" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "จำนวนไอคอน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)), "เลือกจำนวนไอคอนแจ้งเตือนที่มินิ HUD แสดงพร้อมกัน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "ขนาดไอคอน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)), "ปรับขนาดไอคอนและตัวเลขมินิ HUD\n" +
                    "90% = กะทัดรัด 100% = ค่าเดิม เพิ่มได้ถึง 130% เพื่อให้มองชัดขึ้น" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "แนววาง" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)), "เลือกให้ไอคอนมินิ HUD วางเป็นแถวหรือคอลัมน์" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "แนวนอน" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "แนวตั้ง" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "ตำแหน่ง HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)), "เลือกตำแหน่งที่มินิ HUD แสดง\n" +
                    "ลากได้ช่วยให้ย้ายใน UI เมืองได้" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "บนกลาง" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "บนขวา" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "ลากได้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "แบบเข้มหรือกระจก" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)), "เลือกพื้นหลังมินิ HUD\n" +
                    "แผงกระจกจะจากใสไปเป็นขาวมัว ไม่เข้มขึ้น\n" +
                    "ใช้แผงเข้มสำหรับ HUD สไตล์เกมที่มืดกว่า" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "แผงเข้ม" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "แผงกระจก" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "ความทึบพื้นหลัง" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)), "ปรับความโปร่งใสของพื้นหลังมินิ HUD\n" +
                    "ค่าน้อย = โปร่งใสกว่า ค่าสูง = ทึบกว่า\n" +
                    "กระจกจะขาว/มัวขึ้น เข้มจะทึบ/เข้มขึ้น" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "ซ่อนแจ้งเตือนศูนย์" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)), "เมื่อเปิด [ ✓ ] มินิ HUD จะซ่อนแถวแจ้งเตือนที่มีจำนวน 0" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "เงินเริ่มต้น" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "ตั้งยอดเงินเริ่มต้นสำหรับเมืองใหม่แบบ <เงินจำกัด> หรือเมืองแรกที่โหลด\n" +
                    "แล้วกลับเป็นค่าเริ่มต้นเกมหลังใช้\n" +
                    "จะเป็นสีเทาถ้ามีเมืองโหลดอยู่แล้ว\n" +
                    "ตั้งก่อนเริ่ม/โหลดเมือง ใช้ครั้งเดียว จากนั้นใช้ <จำนวนเงินปุ่มลัด> หรือ <เพิ่มเงินอัตโนมัติ>" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ค่าเริ่มต้นเกม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "เลือกไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "เปิด <ก่อนโหลดหรือเริ่มเมือง> เพื่อปลดล็อกไมล์สโตนที่เลือกทันทีหลังโหลดเมือง\n" +
                    "- เปิดไม่ได้หลังเมืองโหลดแล้ว แต่ปิดได้ถ้าเปิดค้างไว้โดยพลาด\n" +
                    "- ถ้าลืมและโหลดเมืองแล้ว ให้รีสตาร์ตเกมแล้วเลือกไมล์สโตนก่อนเข้าเมือง\n" +
                    "- ม็อดย้อนการเปลี่ยนไมล์สโตนที่บันทึกในเมืองแล้วไม่ได้ ใช้เซฟเก่าหากจำเป็น" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "ไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "เลือกระดับไมล์สโตนที่จะปลดล็อกในการโหลดเมืองครั้งถัดไป\n" +
                    "ปรับได้ <เฉพาะตอนยังไม่มีเมืองโหลด> และหลังเปิด [เลือกไมล์สโตน] [ ✓ ] เท่านั้น\n" +
                    "ถ้าเมืองอยู่ที่ไมล์สโตนนั้นหรือสูงกว่าแล้ว จะไม่เกิดอะไรขึ้น\n" +
                    "จะเปลี่ยนเฉพาะเมื่อไมล์สโตนที่เลือกสูงกว่าปัจจุบัน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "จำนวนเงินปุ่มลัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "ใช้จำนวนนี้กับปุ่มลัดเพิ่มเงินและลดเงิน\n" +
                    "<ค่าเริ่มต้นม็อด = 40,000>\n" +
                    "ไม่มีผลถ้าไม่ใช้ปุ่มลัดในเมือง\n" +
                    "ถ้าต้องการอัตโนมัติ ให้เปิดเพิ่มเงินอัตโนมัติ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "เพิ่มเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "ปุ่มลัดสำหรับ <เพิ่มเงิน> ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "เพิ่มเงิน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "ลดเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "ปุ่มลัดสำหรับ <ลดเงิน> ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "ลดเงิน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "เพิ่มเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "เมื่อเปิด [ ✓ ] City Watchdog จะตรวจยอดเงินเมืองขณะมีเมืองโหลด\n" +
                    "- ถ้ายอดเงิน <ต่ำกว่าเกณฑ์>\n" +
                    "  จะเพิ่มจำนวนเงินอัตโนมัติที่เลือก\n" +
                    "- แนะนำให้ใช้เงินแบบปุ่มลัด (<[> หรือ <]>) เมื่อต้องการ\n" +
                    "  แทนตัวเลือกอัตโนมัติ แต่มีไว้ให้ใช้หากต้องการ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "เกณฑ์เงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "ถ้าเปิดเพิ่มเงินอัตโนมัติและยอดเงินเมืองต่ำกว่าค่านี้\n" +
                    "จะเพิ่มจำนวนเงินอัตโนมัติที่เลือก" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "จำนวนเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "จำนวนเงินที่เพิ่มทุกครั้งที่ระบบอัตโนมัติทำงาน\n" +
                    "เลือกให้สูงพอเพื่อพาเมืองกลับขึ้นเหนือเกณฑ์อย่างปลอดภัย" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "ตัวแปลงเงินไม่จำกัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<สำรองเมืองก่อน>\n" +
                    "แปลงเมืองที่เริ่มด้วยเงินไม่จำกัดให้เป็นเมืองปกติที่มีความท้าทายเรื่องเงิน\n" +
                    "การเปิดตัวเลือกนี้จะปลดล็อกปุ่ม <[แปลงเซฟเงินไม่จำกัด]> เมื่อเมืองที่โหลดเป็นชนิด <เงินไม่จำกัด>\n" +
                    "City Watchdog ย้อนการแปลงนี้ไม่ได้\n" +
                    "ถ้าเป็นเมืองปกติ ไม่จำเป็นต้องใช้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "แปลงเมืองเงินไม่จำกัดเป็นปกติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "สำหรับเมืองที่เริ่มด้วย <เงินไม่จำกัด>\n" +
                    "ขณะเมืองนั้นโหลดอยู่ จะเปลี่ยนเซฟเป็นงบเงินจำกัดปกติ\n" +
                    "ปุ่มจะ <ปิด/สีเทา> เว้นแต่เมืองที่โหลดเป็นชนิด <เงินไม่จำกัด>\n" +
                    "และ <ตัวแปลงเงินไม่จำกัด> เปิดอยู่ [ ✓ ]\n" +
                    "สำรองก่อนและใช้ด้วยความเสี่ยงของคุณเอง; City Watchdog ย้อนกลับไม่ได้" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "จะแปลงเมืองนี้จากเงินไม่จำกัดเป็นเงินจำกัดปกติหรือไม่?\n" +
                    "บันทึกสำรองก่อน; City Watchdog ย้อนกลับไม่ได้\n" +
                    "แน่ใจหรือไม่?" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "ชื่อม็อด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "ชื่อที่แสดงของม็อดนี้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "เวอร์ชัน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "เวอร์ชันม็อดปัจจุบัน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "เปิดหน้า Paradox Mods ของผู้สร้าง" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "เขียนรายงานดีบักลง log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<ไม่จำเป็นสำหรับเล่นปกติ>\n" +
                    "สำหรับผู้ทดสอบและตรวจหลังแพตช์เกม: เขียนรายงานไปที่ <Logs/CityWatchdog.log>\n" +
                    "เทียบ prefab แจ้งเตือนจริงของเกมกับไอคอนที่ Watchdog ควบคุมอยู่" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "เปิด log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "เปิด </Logs/CityWatchdog.log> ถ้ามี\n" +
                    "ถ้าไม่มีไฟล์ log จะเปิดโฟลเดอร์ Logs/ แทน" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
