using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class ReceiptDetailForm : Form
    {
        private readonly StockMoveService stockMoveService = new StockMoveService();
        private readonly BillService bilService = new BillService();

        //penampung datagridview
        List<StockMoveLine> ml = new List<StockMoveLine>();
        private string nameSM = null;

        public ReceiptDetailForm(string name)
        {
            InitializeComponent();

            nameSM = name;
            labelName.Text = nameSM;
        }

        private async void ReceiptDetailForm_Load(object sender, EventArgs e)
        {
            await LoadExisting();

            if(labelState.Text == "DONE")
            {
                btnCrtBill.Visible = true;
            }
        }

        public async Task LoadExisting()
        {
            if (string.IsNullOrWhiteSpace(nameSM))
                return;

            try
            {
                var detail = await stockMoveService.GetStockMoveByName(nameSM);
                if (detail?.lines != null)
                {
                    dataGridReceipt.Rows.Clear();
                    foreach (var line in detail.lines)
                    {
                        dataGridReceipt.Rows.Add(
                            line.pName,
                            line.qty,
                            line.qty_real,
                            line.@ref,
                            line.pcode,
                            line.state,
                            line.type_line
                        );
                    }
                }

                labelState.Text = detail?.state;

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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ml.Clear();

                foreach (DataGridViewRow row in dataGridReceipt.Rows)
                {
                    string pcode = row.Cells["pcode"].Value?.ToString();

                    if (!string.IsNullOrEmpty(pcode))
                    {
                        ml.Add(new StockMoveLine
                        {
                            pcode = row.Cells["pcode"].Value?.ToString(),
                            pName = row.Cells["pname"].Value?.ToString(),
                            qty = Convert.ToInt32(row.Cells["qty"].Value ?? 0),
                            qty_real = Convert.ToInt32(row.Cells["qty_real"].Value ?? 0),
                            @ref = row.Cells["ref"].Value?.ToString(),
                            state = row.Cells["state"].Value?.ToString(),
                            type_line = row.Cells["line_type"].Value?.ToString()
                        });
                    }
                }

                var payload = new StockMoveDetailResponse
                {
                    header = new StockMove
                    {
                        name = nameSM,
                        state = "DRAFT",
                        type= "IN",
                    },
                    lines = ml
                };

                await stockMoveService.UpdateReceipt(nameSM, payload);

                MessageBox.Show($"Receipt {nameSM} updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridReceipt.Rows)
                {
                    ml.Add(new StockMoveLine
                    {
                        pcode = row.Cells["pcode"].Value?.ToString(),
                        pName = row.Cells["pname"].Value?.ToString(),
                        qty = Convert.ToInt32(row.Cells["qty"].Value ?? 0),
                        qty_real = Convert.ToInt32(row.Cells["qty_real"].Value ?? 0),
                        @ref = row.Cells["ref"].Value?.ToString(),
                        state = "DONE",
                        type_line = row.Cells["line_type"].Value?.ToString()
                    });
                }

                var payload = new StockMoveDetailResponse
                {
                    header = new StockMove
                    {
                        name = nameSM,
                        state = "DONE",
                    },
                    lines = ml
                };

                await stockMoveService.ConfirmReceipt(nameSM, payload);

                MessageBox.Show($"Receipt {nameSM} Confirm successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCrtBill_Click(object sender, EventArgs e)
        {
            var bl = new List<BillLine>();

            try
            {
                string billName = await bilService.GenerateNumber();

                foreach (DataGridViewRow row in dataGridReceipt.Rows)
                {
                    bl.Add(new BillLine
                    {
                        product_id = row.Cells["pcode"].Value?.ToString(),
                        qty = Convert.ToInt32(row.Cells["qty_real"].Value ?? 0),
                        bill_id = 0,
                    });
                }

                var payload = new VendorBillDetailResponse
                {
                    header = new VendorBill
                    {
                        name = billName,
                        move_id = nameSM,
                        state = "DRAFT"
                    },
                    lines = bl
                };

                await bilService.CreateBill(payload);

                MessageBox.Show($"Create Bill successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
