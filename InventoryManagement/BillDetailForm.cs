using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class BillDetailForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private readonly BillService billService = new BillService();
        CultureInfo cultureInfo = new CultureInfo("id-ID");
        private int billId;

        public BillDetailForm(int id)
        {
            InitializeComponent();
            billId = id;

            UITheme.ApplyGridStyle(dataGridBill);
            UITheme.StylePrimaryButton(btnConfirm);
            UITheme.StyleSecondaryButton(btnSave);
            UITheme.StyleSecondaryButton(btnClear);

            dataGridBill.Columns["qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridBill.Columns["qty_real"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridBill.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridBill.Columns["jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridBill.Columns["discPrs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridBill.Columns["discRph"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridBill.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.Paint += (s, ev) =>
            {
                using (Pen pen = new Pen(UITheme.BorderDark, 1))
                {
                    ev.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            };

            panel3.Paint += (s, ev) =>
            {
                using (Pen pen = new Pen(UITheme.Border, 1))
                {
                    ev.Graphics.DrawLine(pen, 0, 0, panel3.Width, 0);
                }
            };

            panel1.MouseDown += (s, ev) =>
            {
                if (ev.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };

            this.Load += BillDetailForm_Load;
        }

        private async void BillDetailForm_Load(object sender, EventArgs e)
        {
            await LoadExisting();
        }

        private void ApplyStateUI(string state)
        {
            state = (state ?? "DRAFT").Trim().ToUpper();
            labelState.Text = state;

            if (state == "DONE")
            {
                labelState.ForeColor = UITheme.Success;
                btnConfirm.Visible = false;
            }
            else
            {
                labelState.ForeColor = UITheme.Primary;
                btnConfirm.Visible = true;
            }
        }

        public async Task LoadExisting()
        {
            try
            {
                var detail = await billService.GetBillById(billId);

                PartnerService partnerService = new PartnerService();
                var partners = await partnerService.GetPartner();
                var vendor = partners.FirstOrDefault(p => p.ccode == detail?.header.vendor_id);

                labelName.Text = detail?.header.name;
                txtVendorName.Text = vendor?.cname ?? "";
                txtJumlah.Text = detail?.header.jumlah.ToString("N0", cultureInfo) ?? "0";
                txtDiscPrs.Text = detail?.header.discPrs.ToString("N0", cultureInfo) ?? "0";
                lblDisc.Text = detail?.header.discPrs.ToString("N0", cultureInfo) ?? "0";
                txtDpp.Text = detail?.header.dpp.ToString("N0", cultureInfo) ?? "0";
                txtPPn.Text = detail?.header.ppnPrs.ToString("N0", cultureInfo) ?? "0";
                lblPPn.Text = detail?.header.ppnRph.ToString("N0", cultureInfo) ?? "0";
                txtFinalPrice.Text = detail?.header.total.ToString("N0", cultureInfo) ?? "0";

                ApplyStateUI(detail?.header?.state);

                if (detail?.lines != null)
                {
                    dataGridBill.Rows.Clear();

                    foreach(var line in detail.lines)
                    {
                        dataGridBill.Rows.Add(
                            line.product_id,
                            line.qty,
                            line.qty_real,
                            line.price,
                            line.jumlah,
                            line.discPrs,
                            line.discRph,
                            line.total
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var header = new VendorBill
                {
                    state = "DONE"
                };

                await billService.ConfirmBill(billId, header);

                MessageBox.Show($"Vendor Bill {billId} Confirmed");
                await LoadExisting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private async void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in dataGridBill.Rows)
        //        {
        //            ml.Add(new StockMoveLine
        //            {
        //                pcode = row.Cells["pcode"].Value?.ToString(),
        //                pName = row.Cells["pname"].Value?.ToString(),
        //                qty = Convert.ToInt32(row.Cells["qty"].Value ?? 0),
        //                qty_real = Convert.ToInt32(row.Cells["qty_real"].Value ?? 0),
        //                @ref = row.Cells["ref"].Value?.ToString(),
        //                state = row.Cells["state"].Value?.ToString(),
        //                type_line = row.Cells["line_type"].Value?.ToString()
        //            });
        //        }

        //        var payload = new StockMoveDetailResponse
        //        {
        //            header = new StockMove
        //            {
        //                name = nameSM,
        //            },
        //            lines = ml
        //        };

        //        await stockMoveService.UpdateReceipt(nameSM, payload);

        //        MessageBox.Show($"Receipt {nameSM} updated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private async void btnConfirm_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in dataGridBill.Rows)
        //        {
        //            ml.Add(new StockMoveLine
        //            {
        //                pcode = row.Cells["pcode"].Value?.ToString(),
        //                pName = row.Cells["pname"].Value?.ToString(),
        //                qty = Convert.ToInt32(row.Cells["qty"].Value ?? 0),
        //                qty_real = Convert.ToInt32(row.Cells["qty_real"].Value ?? 0),
        //                @ref = row.Cells["ref"].Value?.ToString(),
        //                state = "CONFIRM",
        //                type_line = row.Cells["line_type"].Value?.ToString()
        //            });
        //        }

        //        var payload = new StockMoveDetailResponse
        //        {
        //            header = new StockMove
        //            {
        //                name = nameSM,
        //            },
        //            lines = ml
        //        };

        //        await stockMoveService.ConfirmReceipt(nameSM, payload);

        //        MessageBox.Show($"Receipt {nameSM} updated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
