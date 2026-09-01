using InventoryManagement.Models;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class PurchaseForm : Form
    {
        PurchaseService purchaseService = new PurchaseService();
        StockMoveService stockMoveService = new StockMoveService();

        public PurchaseForm()
        {
            InitializeComponent();
            LoadPO();
        }

        public async Task LoadPO()
        {
            dataGridOrder.Rows.Clear();

            try
            {
                var purchase = await purchaseService.GetPurchase();
                System.Diagnostics.Debug.WriteLine($"LoadPO: received {purchase?.Count ?? 0} purchases from API");
                int i = 0;

                foreach (var pr in purchase)
                {
                    i++;
                    System.Diagnostics.Debug.WriteLine($"PO[{i}]: {pr.noOrder} - {pr.vendor} - {pr.netAmount}");
                    dataGridOrder.Rows.Add(pr.noOrder, pr.odate.ToShortDateString(), pr.vendor, pr.netAmount.ToString("N0", new CultureInfo("id-ID")), pr.state);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PurchaseModuleForm moduleForm = new PurchaseModuleForm();
            moduleForm.btnCreate.Enabled = true;
            moduleForm.ShowDialog();
        }

        private async void dataGridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridOrder.Columns[e.ColumnIndex].Name;
            string noOrder = dataGridOrder.Rows[e.RowIndex].Cells[0].Value?.ToString();

            if (colName == "Edit")
            {
                if (string.IsNullOrWhiteSpace(noOrder))
                {
                    MessageBox.Show("Order number is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PurchaseModuleForm moduleForm = new PurchaseModuleForm(noOrder);
                moduleForm.ShowDialog();

                LoadPO();
            }
            else if (colName == "Delete")
            {
                if (string.IsNullOrWhiteSpace(noOrder))
                {
                    MessageBox.Show("Order number is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show($"Are you sure you want to delete order {noOrder}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        purchaseService.DeletePurchase(noOrder).Wait();
                        MessageBox.Show($"Order {noOrder} deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPO();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete order {noOrder}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (colName == "Confirm" || (e.RowIndex < 0 || e.ColumnIndex < 0))
            {
                try
                {
                    PurchaseDetailResponse detail = await purchaseService.GetPurchaseById(noOrder);

                    if (detail?.lines != null && detail.lines.Count > 0)
                    {
                        foreach (var line in detail.lines)
                        {
                            var stockMove = new StockMove
                            {
                                name = $"IN/{noOrder}",
                                pcode = line.prCode,
                                qty = line.qty,
                                type = "IN",
                                mref = noOrder,
                                @ref = noOrder,
                                type_line = "IN",
                                state = "DRAFT"
                            };

                            await stockMoveService.CreateStockMove(stockMove);
                        }
                    }
                    if (detail.header != null)
                    {
                        var po = new Purchase
                        {
                            noOrder = detail.header.noOrder,
                            odate = detail.header.odate,
                            vendor = detail.header.vendor,
                            dpp = detail.header.dpp,
                            discPrs = detail.header.discPrs,
                            discRph = detail.header.discRph,
                            ppnPrs = detail.header.ppnPrs,
                            ppnRph = detail.header.ppnRph,
                            netAmount = detail.header.netAmount,
                            state = "CONFIRMED"
                        };

                        await purchaseService.UpdatePurchase(noOrder, po);
                    }
                    await LoadPO();

                    MessageBox.Show($"Order {noOrder} confirmed successfully.", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to confirm order {noOrder}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridOrder_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridOrder.Columns[e.ColumnIndex].Name.Equals("Confirm", StringComparison.OrdinalIgnoreCase))
                {
                    var row = dataGridOrder.Rows[e.RowIndex];

                    string state = row.Cells["State"].Value?.ToString()?.Trim().ToUpper();

                    if (state != "DRAFT")
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                        e.Handled = true;
                    }
                }
            }
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            dataGridOrder.CellPainting += dataGridOrder_CellPainting;
        }
    }
}
