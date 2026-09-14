using InventoryManagement.Models;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class PurchaseForm : Form
    {
        private readonly PurchaseService _purchaseService = new PurchaseService();
        private readonly StockMoveService _stockMoveService = new StockMoveService();

        public PurchaseForm()
        {
            InitializeComponent();
        }

        private async void PurchaseForm_Load(object sender, EventArgs e)
        {
            dataGridOrder.CellPainting += dataGridOrder_CellPainting;
            await LoadPO();
        }

        public async Task LoadPO()
        {
            dataGridOrder.Rows.Clear();

            try
            {
                var purchases = await _purchaseService.GetPurchase();
                int i = 0;

                foreach (var pr in purchases)
                {
                    i++;
                    System.Diagnostics.Debug.WriteLine($"PO[{i}]: {pr.noOrder} - {pr.vendor} - {pr.netAmount}");

                    dataGridOrder.Rows.Add(
                        pr.noOrder,
                        pr.odate.ToShortDateString(),
                        pr.vendor,
                        pr.netAmount.ToString("N0", new CultureInfo("id-ID")),
                        pr.state
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Purchase Orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (PurchaseModuleForm moduleForm = new PurchaseModuleForm())
            {
                moduleForm.btnCreate.Enabled = true;
                moduleForm.ShowDialog();
            }

            await LoadPO();
        }

        private async void dataGridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridOrder.Columns[e.ColumnIndex].Name;
            string noOrder = dataGridOrder.Rows[e.RowIndex].Cells[0].Value?.ToString();

            if (string.IsNullOrWhiteSpace(noOrder))
            {
                MessageBox.Show("Order number is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (colName == "Edit")
            {
                using (PurchaseModuleForm moduleForm = new PurchaseModuleForm(noOrder))
                {
                    moduleForm.ShowDialog();
                }

                await LoadPO();
            }

            else if (colName == "Delete")
            {
                if (MessageBox.Show($"Are you sure you want to delete order {noOrder}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        await _purchaseService.DeletePurchase(noOrder);
                        MessageBox.Show($"Order {noOrder} deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadPO();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete order {noOrder}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else if (colName == "Confirm")
            { 
                try
                {
                    Purchase po = await _purchaseService.GetPurchaseById(noOrder);

                    if (po != null)
                    {
                        if (po.lines != null && po.lines.Count > 0)
                        {
                            string nameSM = await _stockMoveService.GenerateNumber();
                            foreach (var line in po.lines)
                            {
                                var stockMove = new StockMove
                                {
                                    name = nameSM,
                                    pcode = line.prCode,
                                    qty = line.qty,
                                    type = "IN",
                                    mref = noOrder,
                                    @ref = noOrder,
                                    type_line = "IN",
                                    state = "DRAFT"
                                };

                                await _stockMoveService.CreateStockMove(stockMove);
                            }
                        }

                        po.state = "CONFIRM";
                        await _purchaseService.ConfirmPurchase(noOrder, po);

                        await LoadPO();
                        MessageBox.Show($"Order {noOrder} confirmed successfully.", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
    }
}