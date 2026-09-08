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
    public partial class DeliveryDetailForm : Form
    {
        private readonly StockMoveService stockMoveService = new StockMoveService();

        //penampung datagridview
        List<StockMoveLine> ml = new List<StockMoveLine>();
        private string nameSM = null;

        public DeliveryDetailForm(string name)
        {
            InitializeComponent();

            nameSM = name;
            labelName.Text = nameSM;
            LoadExisting();
        }

        private async void ReceiptDetailForm_Load(object sender, EventArgs e)
        {
            
        }

        public async Task LoadExisting()
        {
            try
            {
                var detail = await stockMoveService.GetStockMoveByName(nameSM);

                if(detail?.lines != null)
                {
                    dataGridDelivery.Rows.Clear();

                    foreach(var line in detail.lines)
                    {
                        dataGridDelivery.Rows.Add(
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
                foreach (DataGridViewRow row in dataGridDelivery.Rows)
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

                var payload = new StockMoveDetailResponse
                {
                    header = new StockMoveHeader
                    {
                        name = nameSM,
                    },
                    lines = ml
                };

                await stockMoveService.UpdateReceipt(nameSM, payload);

                MessageBox.Show($"Delivery {nameSM} updated successfully.");
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
                foreach (DataGridViewRow row in dataGridDelivery.Rows)
                {
                    ml.Add(new StockMoveLine
                    {
                        pcode = row.Cells["pcode"].Value?.ToString(),
                        pName = row.Cells["pname"].Value?.ToString(),
                        qty = Convert.ToInt32(row.Cells["qty"].Value ?? 0),
                        qty_real = Convert.ToInt32(row.Cells["qty_real"].Value ?? 0),
                        @ref = row.Cells["ref"].Value?.ToString(),
                        state = "CONFIRM",
                        type_line = row.Cells["line_type"].Value?.ToString()
                    });
                }

                var payload = new StockMoveDetailResponse
                {
                    header = new StockMoveHeader
                    {
                        name = nameSM,
                    },
                    lines = ml
                };

                await stockMoveService.ConfirmReceipt(nameSM, payload);

                MessageBox.Show($"Receipt {nameSM} updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
