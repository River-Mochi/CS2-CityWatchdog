// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>
//
// File: src/Localization/LocaleTH.cs
// Purpose: Thai (th-TH) strings for City Watchdog Options UI (settings menu).

namespace CityWatchdog
{
    using System.Collections.Generic; // Dictionary and KeyValuePair
    using Colossal;                   // IDictionarySource

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
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)), "แสดงค่าตัวเลขแนวโน้มข้างลูกศรเงินและประชากรแบบปกติที่แถบเครื่องมือด้านล่าง\nนี่เป็นการแสดงผลเบา ๆ เมื่อชี้เมาส์บนแถบเครื่องมือ <แสดงผลเท่านั้น>;\nไม่เปลี่ยนเงินหรือประชากรของเมือง" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "ความถี่ Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)), "เลือกว่าข้อความแนวโน้มที่แถบด้านล่างจะแสดงค่ารายชั่วโมงหรือรายเดือนสำหรับเงินและประชากร\nรายเดือนใช้รายได้งบประมาณลบค่าใช้จ่ายสำหรับเงิน และใช้การคาดการณ์ 24 ชั่วโมงสำหรับประชากร" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "รายชั่วโมง (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "รายเดือน (/mo)" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "รูปแบบทูลทิปเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)), "เลือกว่าทูลทิปเงินเมื่อชี้เมาส์จะแสดงรายละเอียดมากแค่ไหน\nกะทัดรัด = ค่าเริ่มต้นเมื่อติดตั้งครั้งแรก\n<มินิ> แสดงเฉพาะค่า Net 2 ค่า สำหรับ /mo และ /h\n<กะทัดรัด> ย่อค่าขนาดใหญ่ (15.21M แทน 15,212,318)\n<ข้อมูลเต็ม> แสดงค่ายาวและช่อง Total" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "มินิ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "กะทัดรัด" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "ข้อมูลเต็ม" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "ขนาดตัวอักษรเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)), "ปรับ <ขนาดตัวอักษร> ของตัวเลขในทูลทิป Money View\nค่าเริ่มต้นเกม = 100%\n<ค่าเริ่มต้นม็อด = 120%>\nชี้เมาส์ที่เงินด้านล่างของหน้าจอ\nทำตามคำขอของผู้เล่นที่มองทูลทิปเล็ก ๆ ในเกมได้ยาก" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "ขนาดตัวอักษรประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)), "ปรับ <ขนาดตัวอักษร> ของตัวเลขในทูลทิปประชากร\nค่าเริ่มต้นเกม = 100%\n<ค่าเริ่มต้นม็อด = 120%>\nชี้เมาส์ที่ประชากรด้านล่างของหน้าจอ" },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "จำนวนเงินปุ่มลัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "ใช้จำนวนนี้กับปุ่มลัดเพิ่มเงินและลดเงิน\n<ค่าเริ่มต้นม็อด = 40,000>\nจะไม่ทำอะไรถ้าคุณไม่ได้ใช้ปุ่มลัดเพื่อเพิ่ม/ลดเงิน (ในเมือง)\nสำหรับเงินอัตโนมัติ ให้เปิดตัวเลือกเพิ่มเงินอัตโนมัติ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "เพิ่มเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "ปุ่มลัดเพื่อ <เพิ่มเงิน> ภายในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "เพิ่มเงิน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "ลดเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "ปุ่มลัดเพื่อ <ลดเงิน> ภายในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "ลดเงิน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "เพิ่มเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "เมื่อเปิดใช้ [ ✓ ], City Watchdog จะตรวจยอดเงินของเมืองขณะมีเมืองโหลดอยู่\n- ถ้ายอดเงิน <ต่ำกว่าเกณฑ์>, \n  จะเพิ่มจำนวนเงินอัตโนมัติที่เลือกไว้\n- แนะนำให้ใช้เงินแบบแมนนวลด้วยปุ่มลัด (<[> หรือ <]>) เมื่อจำเป็นแทนตัวเลือกอัตโนมัตินี้ แต่มีไว้ให้ถ้าคุณต้องการ" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "เกณฑ์เงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "ถ้าเปิดเพิ่มเงินอัตโนมัติและยอดเงินของเมืองต่ำกว่าค่านี้,\nจะเพิ่มจำนวนเงินอัตโนมัติที่เลือกไว้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "จำนวนเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "จำนวนเงินที่เพิ่มทุกครั้งเมื่อเพิ่มเงินอัตโนมัติทำงาน\nเลือกค่าที่สูงพอให้เมืองกลับมาอยู่เหนือเกณฑ์อย่างปลอดภัย" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "เงินเริ่มต้น" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "ตั้งยอดเงินเริ่มต้นสำหรับเมืองใหม่แบบ <เงินจำกัด> หรือเมืองแรกที่โหลด,\nจากนั้นรีเซ็ตเป็นค่าเริ่มต้นของเกมหลังจากใช้แล้ว\nตัวเลือกนี้จะเป็นสีเทาถ้ามีเมืองโหลดอยู่แล้ว\nตั้งค่าก่อนเริ่ม/โหลดเมือง → ใช้ครั้งเดียว → จากนั้นใช้ <จำนวนเงินปุ่มลัด> หรือ <เพิ่มเงินอัตโนมัติ>" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ค่าเริ่มต้นเกม" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "สลับไอคอนแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "<ปุ่มลัด> สำหรับการทำงานเดียวกับปุ่มไอคอน <[TOGGLE ALL]> ในแผงของเกม\nแสดงหรือซ่อนไอคอนแจ้งเตือนเมืองทั้งหมดในรายการทันที" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "แสดง/ซ่อนไอคอนแจ้งเตือนทั้งหมดทันที" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "<ปุ่มลัด> สำหรับเปิดหรือปิด\n<แผงแจ้งเตือน> ในเมือง\nทำงานเหมือนคลิกไอคอนมุมซ้ายบนเพื่อเปิดแผงเต็ม" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "ซ่อน/แสดงชื่อถนน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "<ปุ่มลัด> เพื่อซ่อนหรือแสดงป้ายชื่อถนนแบบปกติในเมืองทันที\nเหมือนกับการคลิกไอคอนชื่อถนนบนแถบเครื่องมือของแผง City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "ซ่อน/แสดงชื่อถนน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DisableAllTooltips)), "ปิดทูลทิปเมื่อชี้เมาส์ทั้งหมด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DisableAllTooltips)), "ปิดทูลทิปเมื่อชี้เมาส์ของเกม — ทั้งทูลทิปที่ตามเคอร์เซอร์เหนืออาคาร/ประชาชน/เครื่องมือ และป๊อปอัปเล็ก ๆ บนปุ่ม UI ของเกม (ชื่อแถบบน ปุ่มปกติ ฯลฯ)\n<ป๊อปอัปเงิน/ประชากรของ City Watchdog เองยังเปิดอยู่>; ควบคุมด้วยตัวเลือก Money View ด้านบน\nเหมือนกับคลิกไอคอน [i] บนแผง City Watchdog ในเมือง" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "ตัวเลือกไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "เปิดก่อนโหลดหรือเริ่มเมืองเพื่อปลดล็อกไมล์สโตนที่เลือกทันทีหลังเมืองโหลด\nไม่สามารถเปิดได้ขณะมีเมืองโหลดอยู่ แต่สามารถปิดได้ถ้าเปิดทิ้งไว้โดยไม่ตั้งใจ\nCity Watchdog ไม่สามารถย้อนการเปลี่ยนแปลงไมล์สโตนที่บันทึกลงในเมืองแล้วได้; ใช้เซฟเก่าถ้าจำเป็น" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "ไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "เลือกระดับไมล์สโตนที่จะปลดล็อกในการโหลดเมืองครั้งถัดไป\nปรับได้เฉพาะเมื่อไม่มีเมืองโหลดอยู่ และหลังจาก [ตัวเลือกไมล์สโตน] เปิดอยู่ [ ✓ ] เท่านั้น" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "ตัวแปลงเงินไม่จำกัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "<สำรองเมืองก่อน>.\nแปลงเมืองที่เริ่มด้วยเงินไม่จำกัดให้เป็นเมืองปกติที่มีความท้าทายด้านเงินตามปกติ\nเมื่อเปิด จะปลดล็อกปุ่ม <[แปลงเซฟเงินไม่จำกัด]> เมื่อเมืองที่โหลดเป็นประเภท <เงินไม่จำกัด>\nCity Watchdog ไม่สามารถย้อนการแปลงนี้ได้\nถ้าคุณมีเมืองปกติ ไม่ต้องกังวล; ไม่จำเป็นต้องใช้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "แปลงเมืองเซฟเงินไม่จำกัดเป็นปกติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "สำหรับเมืองที่เริ่มด้วย <เงินไม่จำกัด>\nขณะเมืองนั้นโหลดอยู่ จะเปลี่ยนเซฟเป็นงบประมาณเงินจำกัดปกติ เพื่อให้เมืองมีความท้าทายด้านเงินตามปกติอีกครั้ง\nปุ่มจะ <ปิดใช้/เป็นสีเทา> เว้นแต่เมืองที่โหลดเป็นประเภท <เงินไม่จำกัด>\nและ <ตัวแปลงเงินไม่จำกัด> เป็น ON [ ✓ ]\nทำเซฟสำรองและใช้ด้วยความเสี่ยงของคุณเอง; City Watchdog ไม่สามารถย้อนการแปลงนี้ได้" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "แปลงเมืองนี้จากเงินไม่จำกัดเป็นเงินจำกัดปกติหรือไม่?\nบันทึกสำรองก่อน; City Watchdog ไม่สามารถย้อนกลับได้\nแน่ใจหรือไม่?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "ชื่อม็อด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "ชื่อที่แสดงของม็อดนี้" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "เวอร์ชัน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "เวอร์ชันม็อดปัจจุบัน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "เปิดหน้าของผู้สร้างบน Paradox Mods" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "รายงานดีบักไปยังล็อก" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)), "<ไม่จำเป็นสำหรับการเล่นปกติ>\nสำหรับผู้ทดสอบและการตรวจหลังแพตช์เกม: เขียนรายงาน <Logs/CityWatchdog.log>\nเพื่อเปรียบเทียบ prefab การแจ้งเตือนของเกมจริงกับไอคอนแจ้งเตือนที่ Watchdog ควบคุมอยู่" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "เปิดล็อก" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "เปิด </Logs/CityWatchdog.log> ถ้ามีอยู่\nถ้าไม่มีไฟล์ล็อก จะเปิดโฟลเดอร์ Logs/ แทน" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "แสดงคำแนะนำ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "แสดงหรือซ่อนคำแนะนำการใช้งานด้านล่าง" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)), "<แผงแจ้งเตือน>\n1. คลิกปุ่ม City Watchdog (มุมซ้ายบน) หรือกด Shift+N เพื่อเปิดแผง\n2. เรียง ASC/DESC\n3. ใช้ Toggle All เพื่อปิด/เปิดทั้งหมดอย่างรวดเร็ว หรือขยายหมวดเพื่อเปลี่ยนบางไอคอน\n4. แสดงหรือซ่อนไอคอนเท่านั้น; ไม่ได้แก้ปัญหาของเมือง\n\n<ตัวช่วยเงิน>\n1. เพิ่มหรือลดเงิน: ใช้ <จำนวนเงินปุ่มลัด> ค่าเริ่มต้น [ หรือ ]\n2. เพิ่มเงินอัตโนมัติจะดูงบประมาณขณะเมืองโหลดอยู่และเพิ่มเงินเมื่อต่ำกว่าเกณฑ์\n3. Money View เพิ่มค่าตัวเลขให้แถบเงินและประชากร รวมถึงทูลทิปเมื่อชี้เมาส์\n4. แปลงเซฟเงินไม่จำกัดใช้เฉพาะเมืองที่เริ่มด้วยเงินไม่จำกัด และ <ย้อนกลับไม่ได้>\n\n<ไมล์สโตนกำหนดเอง>\nตั้งเงินเริ่มต้นและเลือกไมล์สโตนจากเมนูตัวเลือกก่อนโหลดหรือเริ่มเมือง" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
