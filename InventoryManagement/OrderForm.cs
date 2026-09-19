using InventoryManagement.models;
using InventoryManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class OrderForm : Form
    {
        SaleService saleService = new SaleService();
        StockMoveService stockMoveService = new StockMoveService();

        public OrderForm()
        {
            InitializeComponent();
            LoadOrder();
        }

        public async Task LoadOrder()
        {
            dataGridOrder.Rows.Clear();

            try
            {
                var sale = await saleService.GetSale();
                int i = 0;

                foreach (var sl in sale)
                {
                    i++;
                    dataGridOrder.Rows.Add(sl.noOrder, sl.odate.ToShortDateString(), sl.customerId, sl.total.ToString("N0", new CultureInfo("id-ID")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm moduleForm = new OrderModuleForm();
            moduleForm.btnCreate.Enabled = true;
            moduleForm.ShowDialog();
        }

        private async void dataGridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridOrder.Columns[e.ColumnIndex].Name;
            string noOrder = dataGridOrder.Rows[e.RowIndex].Cells[0].Value?.ToString();

            if(colName == "edit")
            {
                if(string.IsNullOrWhiteSpace(noOrder))
                {
                    MessageBox.Show("Order number is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OrderModuleForm moduleForm = new OrderModuleForm(noOrder);
                moduleForm.ShowDialog();

                LoadOrder();
            }

            else if (colName == "Confirm" || (e.RowIndex < 0 || e.ColumnIndex < 0))
            {
                try
                {
                    SaleDetailResponse detail = await saleService.GetSaleById(noOrder);

                    if (detail?.lines != null && detail.lines.Count > 0)
                    {
                        foreach (var line in detail.lines)
                        {
                            var stockMove = new StockMove
                            {
                                name = $"OUT/{noOrder}",
                                type = "OUT",
                                mref = noOrder,
                                @ref = noOrder,
                                state = "DRAFT"
                            };

                            await stockMoveService.CreateStockMove(stockMove);
                        }
                    }
                    if (detail.header != null)
                    {
                        var so = new Sale
                        {
                            noOrder = detail.header.noOrder,
                            odate = detail.header.odate,
                            customerId = detail.header.customerId,
                            dpp = detail.header.dpp,
                            discPrs = detail.header.discPrs,
                            discRph = detail.header.discRph,
                            ppnPrs = detail.header.ppnPrs,
                            ppnRph = detail.header.ppnRph,
                            total = detail.header.total,
                            state = "CONFIRMED"
                        };

                        await saleService.UpdateSale(noOrder, so);
                    }
                    await LoadOrder();

                    MessageBox.Show($"Order {noOrder} confirmed successfully.", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to confirm order {noOrder}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if(colName == "delete")
            {
                if (string.IsNullOrWhiteSpace(noOrder))
                {
                    MessageBox.Show("Order number is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var confirmResult = MessageBox.Show($"Are you sure to delete order {noOrder}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Call the API to delete the order
                        saleService.DeleteSale(noOrder).Wait();
                        LoadOrder();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
