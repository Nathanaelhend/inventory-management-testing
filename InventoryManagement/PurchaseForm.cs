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

                // Refresh grid after edit
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
            else if (colName == "Confirm")
            {
                try
                {
                    var detail = await purchaseService.GetPurchaseById(noOrder);

                    var purchase = new Purchase();

                    if (detail?.lines != null)
                    {
                        foreach (var line in detail.lines)
                        {
                            var stockMove = new StockMove
                            {
                                name = $"IN//{noOrder}",
                                pcode = line.prCode,
                                qty = line.qty,
                                type = "IN",
                                mref = noOrder,
                                @ref = noOrder,
                                type_line = "IN"
                            };

                            await stockMoveService.CreateStockMove(stockMove);
                        }

                        foreach(var data in purchase)
                        {
                            var po = new Purchase
                            {
                                odate = data.odate,
                                vendor = data.vendor,
                                discPrs = data.discPrs,
                                discRph = data.discRph,
                                dpp = data.dpp,
                                netAmount = data.netAmount,
                                state = "CONFIRM"
                            };

                            await purchaseService.UpdatePurchase(noOrder, po);
                            LoadPO();
                        }

                    }
                    MessageBox.Show($"Order {noOrder} confirmed and stock moves created.", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to confirm order {noOrder}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridOrder_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Cek apakah ini kolom tombol "Action" dan bukan header row
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridOrder.Columns[e.ColumnIndex].Name == "Action")
            {
                var row = dataGridOrder.Rows[e.RowIndex];

                // Ambil nilai kolom State (pastikan penulisan "state" atau "State" sesuai Name kolom)
                string state = row.Cells["State"].Value?.ToString()?.Trim().ToUpper();

                if (state != "DRAFT")
                {
                    // Menggambar latar belakang sel biasa (tanpa bingkai tombol)
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    // Tandai bahwa penggambaran sel sudah ditangani (jangan gambar tombol bawaan)
                    e.Handled = true;
                }
            }
        }
    }
}
