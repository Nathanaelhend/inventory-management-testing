using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class BillDetailForm : Form
    {
        private readonly BillService billService = new BillService();
        CultureInfo cultureInfo = new CultureInfo("id-ID");
        private int billId;

        public BillDetailForm(int id)
        {
            InitializeComponent();
            billId = id;
            LoadExisting();
        }

        private async void BillDetailForm_Load(object sender, EventArgs e)
        {
            
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
                txtVendorName.Text = vendor.cname;
                labelState.Text = detail?.header.state;
                txtJumlah.Text = detail?.header.jumlah.ToString("N0", cultureInfo);
                txtDiscPrs.Text = detail?.header.discPrs.ToString("N0", cultureInfo);
                lblDisc.Text = detail?.header.discPrs.ToString("N0", cultureInfo);
                txtDpp.Text = detail?.header.dpp.ToString("N0", cultureInfo);
                txtPPn.Text = detail?.header.ppnPrs.ToString("N0", cultureInfo);
                lblPPn.Text = detail?.header.ppnRph.ToString("N0", cultureInfo);
                txtFinalPrice.Text = detail?.header.total.ToString("N0", cultureInfo);

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
