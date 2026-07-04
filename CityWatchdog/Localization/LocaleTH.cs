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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "การกระทำ" },
                { m_Settings.GetOptionTabLocaleID(Setting.MiniHudTab), "Mini-HUD" },
                { m_Settings.GetOptionTabLocaleID(Setting.MoneyTab), "เงิน-ไมล์สโตน" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "เกี่ยวกับ" },

                // --- Groups, ordered by Options menu location ---
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "วิธีใช้" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "การแจ้งเตือน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "ตัวดูข้อมูลในเมือง" },
                { m_Settings.GetOptionGroupLocaleID(Setting.MiniHudGroup), "การแจ้งเตือน Mini HUD" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "ตั้งค่าเริ่มเมืองใหม่" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "เงิน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "แปลงเซฟเงินไม่จำกัด" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "วินิจฉัย" },

                // --------------------------------------------------------------------
                // Actions tab - Usage
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "แสดงคำแนะนำ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "แสดงหรือซ่อนคำแนะนำด้านล่าง" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<สวิตช์การแสดงผล>\n" +
                    "1. ปุ่ม [i]: ซ่อน/แสดง tooltip ทั้งหมดของเกม\n" +
                    "2. ปุ่มชื่อถนน: ซ่อน/แสดงชื่อถนน ปุ่มลัด: \\.\n" +
                    "3. ปุ่มชื่อเขต: ซ่อน/แสดงชื่อเขต โดยไม่เปลี่ยนขอบเขต\n" +
                    "4. ปุ่มลูกศรถนน: บังคับเปิด/ปิดลูกศรทางเดียว (ซ่อนชื่อถนนด้วย)\n" +
                    "5. ไอคอน CWD: ซ่อน/แสดง tooltip ของแผง City Watchdog\n\n" +
                    "<การแจ้งเตือน>\n" +
                    "1. คลิกปุ่ม City Watchdog มุมซ้ายบน หรือกด Shift+N เพื่อเปิดแผง\n" +
                    "2. ปุ่มเรียงลำดับ: น้อยไปมาก/มากไปน้อย\n" +
                    "3. Toggle All เปิด/ปิดทั้งหมดเร็ว ๆ หรือขยายหมวดเพื่อปรับแยก\n" +
                    "4. ซ่อนเฉพาะไอคอน ไม่ได้แก้ปัญหาในเมืองจริง\n\n" +
                    "<เครื่องมือเงิน>\n" +
                    "1. เพิ่มหรือลดเงิน: ใช้ปุ่มเริ่มต้น [ และ ]\n" +
                    "2. เพิ่มเงินอัตโนมัติเมื่อเงินเมืองต่ำกว่าขีดที่ตั้งไว้\n" +
                    "3. แปลงเซฟเงินไม่จำกัด ใช้เฉพาะเมืองที่เริ่มด้วยเงินไม่จำกัด และ<ย้อนกลับไม่ได้>\n\n" +
                    "<Tooltip เมนูล่าง>\n" +
                    "Money View เพิ่มค่าแนวโน้มเงิน/ประชากรและรายละเอียดเมื่อชี้เมาส์\n\n" +
                    "<ไมล์สโตนกำหนดเอง>\n" +
                    "ตั้งเงินเริ่มต้นและไมล์สโตนก่อนโหลดหรือเริ่มเมือง"
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --------------------------------------------------------------------
                // Actions tab - Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "สลับไอคอนแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<ปุ่มลัด> ทำงานเหมือนปุ่ม <[TOGGLE ALL]> ในเกม\n" +
                    "แสดงหรือซ่อนไอคอนแจ้งเตือนเมืองทั้งหมดทันที" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "แสดง/ซ่อนไอคอนแจ้งเตือนทั้งหมดทันที" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับเปิดหรือปิด\n" +
                    "<แผงแจ้งเตือน> ในเมือง\n" +
                    "เหมือนคลิกไอคอนมุมซ้ายบนเพื่อเปิดแผงเต็ม"
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "เปิด/ปิดแผงแจ้งเตือน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PanelButtonsOnlyStart)), "เริ่มแบบปุ่มอย่างเดียว" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PanelButtonsOnlyStart)),
                    "เมื่อเปิด [ ✓ ], City Watchdog จะเปิดเป็นมุมมองเล็กแบบปุ่มอย่างเดียวก่อน\n" +
                    "ใช้ลูกศรแถบชื่อหรือปุ่มจำนวนแถวเพื่อขยายแผงเต็ม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)), "ซ่อน/แสดงชื่อถนน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleRoadNamesKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อนหรือแสดงชื่อถนนแบบ vanilla ทันที\n" +
                    "เหมือนคลิกไอคอนชื่อถนนในแถบ City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleRoadNamesAction), "ซ่อน/แสดงชื่อถนน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)), "ปิด tooltip เมื่อชี้เมาส์ทั้งหมด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleAllTooltipsKeyboardBinding)),
                    "<ปุ่มลัด> เพื่อซ่อนหรือแสดง tooltip ทั้งหมดของเกม\n" +
                    "<Popup เงิน/ประชากรของ City Watchdog ยังเปิดอยู่>; ควบคุมด้วย Money View\n" +
                    "เหมือนคลิกไอคอน [i] ในแผง City Watchdog" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleAllTooltipsAction), "ซ่อน/แสดง tooltip ของเกม" },

                // --------------------------------------------------------------------
                // Actions tab - In-City Info Viewer
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "แสดง tooltip เงิน + ประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "<แนะนำ>\n" +
                    "เมนูล่าง: แสดงค่าแนวโน้มที่ลูกศรเงินและประชากร\n" +
                    "ฟีเจอร์เบา ๆ เมื่อชี้เมาส์บน toolbar <แสดงผลเท่านั้น>;\n" +
                    "ช่วยลดการเปิดแผง Info ของเกม"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "ความถี่ Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "เลือกให้ข้อความแนวโน้มเมนูล่างเป็นรายชั่วโมงหรือรายเดือน\n" +
                    "รายเดือนใช้รายรับลบรายจ่าย และคาดการณ์ประชากร 24 ชั่วโมง" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "รายชั่วโมง (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "รายเดือน (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "รูปแบบ tooltip เงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "เลือกว่าจะแสดงรายละเอียดเงินมากแค่ไหน\n" +
                    "กะทัดรัด = ค่าเริ่มต้นเมื่อติดตั้งครั้งแรก\n" +
                    "<Mini> แสดงเฉพาะค่า Net 2 ค่า สำหรับ /mo และ /h\n" +
                    "<กะทัดรัด> ย่อเลขใหญ่ (15.21M แทน 15,212,318)\n" +
                    "<ข้อมูลเต็ม> แสดงเลขยาวและยอดรวม" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "กะทัดรัด" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "ข้อมูลเต็ม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "ขนาดตัวอักษรเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ตัวเลข tooltip ของ Money View\n" +
                    "ค่าเริ่มต้นเกม = 100%\n" +
                    "<ค่าเริ่มต้นม็อด = 120%>\n" +
                    "ชี้เมาส์ที่เงินด้านล่างหน้าจอ\n" +
                    "สำหรับผู้เล่นที่อ่าน tooltip เล็ก ๆ ยาก"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "ขนาดตัวอักษรประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ตัวเลข tooltip ประชากร\n" +
                    "ค่าเริ่มต้นเกม = 100%\n" +
                    "<ค่าเริ่มต้นม็อด = 120%>\n" +
                    "ชี้เมาส์ที่ประชากรด้านล่างหน้าจอ"
                },

                // --------------------------------------------------------------------
                // Mini-HUD tab - Mini HUD Notifications
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudEnabled)), "Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudEnabled)),
                    "แสดง HUD เล็กพร้อมจำนวนแจ้งเตือนสำคัญ\n" +
                    "ใช้เป็นแถบเตือนเร็วโดยไม่ต้องเปิดแผงเต็ม\n" +
                    "คลิกไอคอนเพื่อข้ามไปยังจุดปัญหาที่ตรงกัน\n" +
                    "คลิกไอคอนเดิมซ้ำเพื่อวนดูจุดอื่น แล้วกลับมาจุดแรก"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)), "ชุดเริ่มต้นแนะนำ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ApplyMiniHudRecommendedPreset)),
                    "ใช้การตั้งค่า Mini HUD ที่แนะนำ:\n" +
                    "รายการโปรด, 5 ไอคอน, แนวนอน, กลางบน, 100%, แผงมืด\n" +
                    "การแจ้งเตือนที่เป็นศูนย์ยังแสดงอยู่\n" +
                    "เพิ่ม/ลบรายการโปรด **ดาวสีน้ำเงิน** ได้ในแผง Watchdog แบบขยาย\n" +
                    "รายการโปรด **ดาวสีน้ำเงิน** เริ่มต้นรวมอยู่ใน **[แนะนำ]**"
                  },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudMode)), "โหมด Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudMode)),
                    "เลือกแถวแจ้งเตือนที่ Mini HUD ใช้\n" +
                    "**แจ้งเตือนสูงสุด** แสดงจำนวนปัจจุบันสูงสุด\n" +
                    "**รายการโปรด** รวมแถวที่มี **ดาวสีน้ำเงิน** ในแผงหลัก\n" +
                    "เลือกได้หลายรายการโปรดตามต้องการ\n" +
                    "แต่ Mini HUD จะแสดงเฉพาะ 5 หรือ 10 อันดับแรกจากรายการนั้น" },
                { m_Settings.GetOptionLocaleID("MiniHudModeTopActive"), "แจ้งเตือนสูงสุด" },
                { m_Settings.GetOptionLocaleID("MiniHudModeFavorites"), "รายการโปรด" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudItemCount)), "จำนวนไอคอน Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudItemCount)),
                    "เลือกจำนวนไอคอนแจ้งเตือนที่ Mini HUD แสดงได้พร้อมกัน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudScale)), "ขนาด Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudScale)),
                    "ปรับขนาดไอคอนและตัวเลข Mini HUD\n" +
                    "90% = กะทัดรัด 100% = ปกติ เพิ่มถึง 130% เพื่อมองเห็นง่ายขึ้น" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudOrientation)), "ทิศทาง Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudOrientation)),
                    "เลือกให้เรียงเป็นแถวหรือคอลัมน์" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationHorizontal"), "แนวนอน" },
                { m_Settings.GetOptionLocaleID("MiniHudOrientationVertical"), "แนวตั้ง" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPlacement)), "ตำแหน่ง Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPlacement)),
                    "เลือกตำแหน่งของ Mini HUD\n" +
                    "แบบลากได้ช่วยให้ย้ายใน UI เมืองได้" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopCenter"), "กลางบน" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementTopRight"), "ขวาบน" },
                { m_Settings.GetOptionLocaleID("MiniHudPlacementDraggable"), "ลากได้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelStyle)), "สไตล์ Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelStyle)),
                    "เลือกสไตล์พื้นหลัง Mini HUD\n" +
                    "แผงกระจกจะจากใสเป็นขาวขุ่น ไม่มืดลง\n" +
                    "ใช้แผงมืดสำหรับ HUD แบบ vanilla ที่มืดกว่า" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleDark"), "แผงมืด" },
                { m_Settings.GetOptionLocaleID("MiniHudPanelStyleGlass"), "แผงกระจก" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudPanelOpacity)), "ความทึบ Mini HUD" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudPanelOpacity)),
                    "ปรับความโปร่งใสพื้นหลัง Mini HUD\n" +
                    "ค่าน้อย = โปร่งใสกว่า ค่าสูง = ทึบกว่า\n" +
                    "กระจกจะขาว/ขุ่นขึ้น แผงมืดจะทึบ/มืดขึ้น" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MiniHudHideZero)), "ซ่อนแจ้งเตือนศูนย์" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MiniHudHideZero)),
                    "เมื่อเปิด [ ✓ ], Mini HUD จะซ่อนแถวที่มีจำนวน 0" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - New City Start Settings
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "เงินเริ่มต้น" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "ตั้งยอดเงินเริ่มต้นสำหรับเมืองใหม่แบบ <เงินจำกัด> หรือเมืองแรกที่โหลด\n" +
                    "แล้วรีเซ็ตกลับเป็นค่าเริ่มต้นเกมหลังใช้\n" +
                    "จะเป็นสีเทาถ้ามีเมืองโหลดอยู่แล้ว\n" +
                    "ตั้งก่อนเริ่ม/โหลดเมือง หลังจากนั้นใช้ <จำนวนเงินปุ่มลัด> หรือ <เพิ่มเงินอัตโนมัติ>" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ค่าเริ่มต้นเกม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "ตัวเลือกไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "เปิด <ก่อนโหลดหรือเริ่มเมือง> เพื่อปลดล็อกไมล์สโตนที่เลือกหลังโหลด\n" +
                    "- เปิดไม่ได้หลังโหลดเมืองแล้ว แต่ปิดได้ถ้าเปิดผิด\n" +
                    "- ถ้าลืม ให้รีสตาร์ทเกมแล้วเลือกก่อนเข้าเมือง\n" +
                    "- ม็อดย้อนการเปลี่ยนไมล์สโตนที่เซฟไปแล้วไม่ได้ ให้ใช้เซฟเก่าถ้าจำเป็น"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "ไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "เลือกไมล์สโตนที่จะปลดล็อกในการโหลดเมืองครั้งถัดไป\n" +
                    "ปรับได้เฉพาะ <นอกเมืองที่โหลดอยู่> และหลังเปิด [ตัวเลือกไมล์สโตน] [ ✓ ]\n" +
                    "ถ้าเมืองอยู่ถึงหรือเกินไมล์สโตนนั้นแล้ว จะไม่เกิดอะไรขึ้น\n" +
                    "เปลี่ยนเฉพาะเมื่อไมล์สโตนที่เลือกสูงกว่าปัจจุบัน"
                },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Money
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "จำนวนเงินปุ่มลัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "ใช้จำนวนนี้กับปุ่มลัดเพิ่มเงินและลดเงิน\n" +
                    "<ค่าเริ่มต้นม็อด = 40,000>\n" +
                    "ไม่ทำงานถ้าไม่ได้ใช้ปุ่มลัดในเมือง\n" +
                    "สำหรับเงินอัตโนมัติ ให้เปิดตัวเลือกเพิ่มเงินอัตโนมัติ"
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
                    "เมื่อเปิด [ ✓ ], City Watchdog จะตรวจยอดเงินเมือง\n" +
                    "- ถ้ายอดเงิน <ต่ำกว่าเกณฑ์>, \n" +
                    "  จะเพิ่มจำนวนเงินที่เลือก\n" +
                    "- แนะนำให้ใช้เงินแบบกดเองด้วยปุ่มลัด (<[> หรือ <]>) เมื่อจำเป็น" +
                    "  แทนแบบอัตโนมัติ แต่มีตัวเลือกนี้ไว้ให้"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "เกณฑ์เงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "ถ้าเปิดเพิ่มเงินอัตโนมัติและยอดเงินต่ำกว่าค่านี้\n" +
                    "จะเพิ่มจำนวนเงินที่เลือก" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "จำนวนเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "จำนวนเงินที่เพิ่มทุกครั้งที่อัตโนมัติทำงาน\n" +
                    "เลือกให้สูงพอเพื่อให้เงินกลับมาเกินเกณฑ์อย่างปลอดภัย" },

                // --------------------------------------------------------------------
                // Money-Milestones tab - Save Conversion
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "ตัวแปลงเงินไม่จำกัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<สำรองเมืองก่อน>.\n" +
                    "แปลงเมืองที่เริ่มด้วยเงินไม่จำกัดให้เป็นเมืองปกติ\n" +
                    "เปิดปุ่ม <[แปลงเซฟเงินไม่จำกัด]> เมื่อเมืองที่โหลดเป็นชนิด <เงินไม่จำกัด>\n" +
                    "City Watchdog ไม่สามารถย้อนการแปลงนี้ได้\n" +
                    "ถ้าเป็นเมืองปกติ ไม่ต้องใช้ตัวเลือกนี้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "แปลงเมืองเงินไม่จำกัดเป็นเมืองปกติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "สำหรับเมืองที่เริ่มด้วย <เงินไม่จำกัด>\n" +
                    "เมื่อโหลดเมืองนั้นอยู่ จะแปลงเซฟเป็นงบประมาณเงินจำกัดปกติ\n" +
                    "ปุ่มจะ <ปิด/เทา> เว้นแต่เมืองที่โหลดเป็นชนิด <เงินไม่จำกัด>\n" +
                    "และ <ตัวแปลงเงินไม่จำกัด> เปิดอยู่ [ ✓ ]\n" +
                    "สำรองเซฟและใช้ด้วยความเสี่ยงของคุณเอง; City Watchdog ย้อนกลับไม่ได้" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "แปลงเมืองนี้จากเงินไม่จำกัดเป็นเงินจำกัดปกติหรือไม่?\n" +
                    "สำรองเซฟก่อน; City Watchdog ย้อนกลับไม่ได้\n" +
                    "แน่ใจไหม?" },

                // --------------------------------------------------------------------
                // About tab
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "ชื่อม็อด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "ชื่อที่แสดงของม็อดนี้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "เวอร์ชัน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "เวอร์ชันม็อดปัจจุบัน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "เปิดหน้า Paradox Mods ของผู้สร้าง" },

                // --------------------------------------------------------------------
                // About tab - Diagnostics
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "เขียนรายงาน debug ลง log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "<ไม่จำเป็นสำหรับเล่นปกติ>\n" +
                    "สำหรับทดสอบและตรวจหลังแพตช์เกม: เขียนรายงาน <Logs/CityWatchdog.log>\n" +
                    "เปรียบเทียบ prefab แจ้งเตือนจริงกับไอคอนที่ Watchdog ควบคุม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "เปิด Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "เปิด </Logs/CityWatchdog.log> ถ้ามี\n" +
                    "ถ้าไม่มีไฟล์ log จะเปิดโฟลเดอร์ Logs/" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
