using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class PurchaseForm : Form
    {
        PurchaseService purchaseService = new PurchaseService();

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
                    dataGridOrder.Rows.Add(pr.noOrder, pr.odate.ToShortDateString(), pr.vendor, pr.netAmount.ToString("N0", new CultureInfo("id-ID")));
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

        private void dataGridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            else if(colName == "Delete")
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
        }
    }
}
