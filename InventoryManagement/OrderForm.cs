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

        private void dataGridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
