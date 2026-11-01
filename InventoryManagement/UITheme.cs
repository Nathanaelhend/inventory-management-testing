using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagement
{
    public static class UITheme
    {
        // --- Color Palette: Corporate Slate & Crisp Navy ---
        public static readonly Color Primary = Color.FromArgb(37, 99, 235);         // #2563EB
        public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);    // #1D4ED8
        public static readonly Color PrimaryActive = Color.FromArgb(30, 64, 175);   // #1E40AF

        public static readonly Color SidebarBg = Color.FromArgb(15, 23, 42);        // #0F172A
        public static readonly Color SidebarHover = Color.FromArgb(30, 41, 59);     // #1E293B
        public static readonly Color SidebarActive = Color.FromArgb(51, 65, 85);    // #334155
        public static readonly Color SidebarHeader = Color.FromArgb(2, 6, 23);      // #020617
        public static readonly Color SidebarText = Color.FromArgb(241, 245, 249);   // #F1F5F9
        public static readonly Color SidebarTextMuted = Color.FromArgb(148, 163, 184); // #94A3B8

        public static readonly Color AppBg = Color.FromArgb(248, 250, 252);         // #F8FAFC
        public static readonly Color CardBg = Color.White;
        public static readonly Color Border = Color.FromArgb(226, 232, 240);        // #E2E8F0
        public static readonly Color BorderDark = Color.FromArgb(203, 213, 225);    // #CBD5E1

        public static readonly Color TextMain = Color.FromArgb(15, 23, 42);         // #0F172A
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);     // #64748B

        public static readonly Color Danger = Color.FromArgb(239, 68, 68);          // #EF4444
        public static readonly Color DangerHover = Color.FromArgb(220, 38, 38);     // #DC2626
        public static readonly Color Success = Color.FromArgb(16, 185, 129);        // #10B981
        public static readonly Color Warning = Color.FromArgb(245, 158, 11);        // #F59E0B

        // --- Typography: Segoe UI Modern Scale ---
        public static readonly Font FontAppTitle = new Font("Segoe UI", 13f, FontStyle.Bold);
        public static readonly Font FontSectionTitle = new Font("Segoe UI", 11f, FontStyle.Bold);
        public static readonly Font FontSubTitle = new Font("Segoe UI", 9.75f, FontStyle.Bold);
        public static readonly Font FontBody = new Font("Segoe UI", 9f, FontStyle.Regular);
        public static readonly Font FontBodyBold = new Font("Segoe UI", 9f, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI", 8.25f, FontStyle.Regular);
        public static readonly Font FontSmallBold = new Font("Segoe UI", 8.25f, FontStyle.Bold);

        /// <summary>
        /// Terapkan styling tabel DataGridView yang bersih, modern, dan ergonomis.
        /// </summary>
        public static void ApplyGridStyle(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Border;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowTemplate.Height = 36;

            // Header Style
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(241, 245, 249),
                Font = FontBodyBold,
                ForeColor = TextMain,
                SelectionBackColor = Color.FromArgb(241, 245, 249),
                SelectionForeColor = TextMain,
                WrapMode = DataGridViewTriState.False,
                Padding = new Padding(8, 0, 8, 0)
            };
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 38;

            // Default Row Style
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.White,
                Font = FontBody,
                ForeColor = TextMain,
                SelectionBackColor = Color.FromArgb(224, 231, 255), // #E0E7FF (Soft Indigo)
                SelectionForeColor = Color.FromArgb(30, 27, 75),     // #1E1B4B
                Padding = new Padding(8, 2, 8, 2)
            };
            dgv.DefaultCellStyle = rowStyle;

            // Alternating Row Style (Zebra Striping)
            DataGridViewCellStyle altStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(248, 250, 252), // #F8FAFC
                Font = FontBody,
                ForeColor = TextMain,
                SelectionBackColor = Color.FromArgb(224, 231, 255),
                SelectionForeColor = Color.FromArgb(30, 27, 75),
                Padding = new Padding(8, 2, 8, 2)
            };
            dgv.AlternatingRowsDefaultCellStyle = altStyle;
        }

        /// <summary>
        /// Styling tombol aksi primer (Corporate Blue)
        /// </summary>
        public static void StylePrimaryButton(Button btn)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Primary;
            btn.ForeColor = Color.White;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;
            btn.MouseEnter += (s, e) => btn.BackColor = PrimaryHover;
            btn.MouseLeave += (s, e) => btn.BackColor = Primary;
        }

        /// <summary>
        /// Styling tombol aksi sekunder (Outline / Neutral)
        /// </summary>
        public static void StyleSecondaryButton(Button btn)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = BorderDark;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = Color.White;
            btn.ForeColor = TextMain;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(241, 245, 249);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.White;
        }

        /// <summary>
        /// Styling tombol aksi danger (Hapus / Batal)
        /// </summary>
        public static void StyleDangerButton(Button btn)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Danger;
            btn.ForeColor = Color.White;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;
            btn.MouseEnter += (s, e) => btn.BackColor = DangerHover;
            btn.MouseLeave += (s, e) => btn.BackColor = Danger;
        }

        /// <summary>
        /// Styling tombol aksi sukses (Konfirmasi / Create Bill / Hijau Emerald)
        /// </summary>
        public static void StyleSuccessButton(Button btn)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Success;
            btn.ForeColor = Color.White;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(4, 120, 87);
            btn.MouseLeave += (s, e) => btn.BackColor = Success;
        }

        /// <summary>
        /// Styling item navigasi sidebar
        /// </summary>
        public static void StyleSidebarButton(Button btn, bool isActive = false)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = SidebarActive;
            btn.FlatAppearance.MouseOverBackColor = SidebarHover;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(16, 0, 0, 0);
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;

            if (isActive)
            {
                btn.Tag = "active";
                btn.BackColor = SidebarActive;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.Tag = "inactive";
                btn.BackColor = SidebarBg;
                btn.ForeColor = SidebarTextMuted;
            }

            btn.MouseEnter += (s, e) =>
            {
                if ((btn.Tag as string) != "active")
                {
                    btn.BackColor = SidebarHover;
                    btn.ForeColor = Color.White;
                }
            };

            btn.MouseLeave += (s, e) =>
            {
                if ((btn.Tag as string) != "active")
                {
                    btn.BackColor = SidebarBg;
                    btn.ForeColor = SidebarTextMuted;
                }
            };
        }

        /// <summary>
        /// Terapkan state aktif / tidak aktif pada tombol navigasi sidebar
        /// </summary>
        public static void SetSidebarActive(Button btn, bool isActive)
        {
            if (btn == null) return;
            if (isActive)
            {
                btn.Tag = "active";
                btn.BackColor = SidebarActive;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.Tag = "inactive";
                btn.BackColor = SidebarBg;
                btn.ForeColor = SidebarTextMuted;
            }
        }
    }
}
