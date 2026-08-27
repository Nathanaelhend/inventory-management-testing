using InventoryManagement.models;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class OrderModuleForm : Form
    {
        int selectedRowIndex = -1;
        bool isEditMode = false;
        int qty = 0;
        bool headerCreated = false;
        private string existingNoOrder = null;

        private readonly  SaleService saleService = new SaleService();
        private readonly ProductService productService = new ProductService();

        public OrderModuleForm()
        {
            InitializeComponent();
            LoadProduct();
            LoadCustomer();
            dateTimePickerOrder.Value = DateTime.Now;
        }

        public OrderModuleForm(string noOrder)
        {
            InitializeComponent();
            LoadProduct();
            LoadCustomer();

            existingNoOrder = noOrder;
            isEditMode = true;

            txtBoxNoOrder.Text = existingNoOrder;
            txtBoxNoOrder.ReadOnly = true;

            LoadExistingOrder();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public async Task LoadCustomer()
        {
            dataGridCustomer.Rows.Clear();

            try
            {
                PartnerService partnerService = new PartnerService();
                var customers = await partnerService.GetPartner();

                foreach (var c in customers)
                {
                    if (c.cType == "Customer")
                    {
                        dataGridCustomer.Rows.Add(c.ccode, c.cname, c.cphone, c.cType);
                    }

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LoadProduct()
        {
            dataGridCustomer.Rows.Clear();

            try
            {
                ProductService productService = new ProductService();
                var product = await productService.GetProducts();

                foreach (var p in product)
                {
                    dataGridProduct.Rows.Add(p.pcode, p.pName, p.pQty, p.pPrice, p.pDescription, p.catname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadExistingOrder()
        {
            if(string.IsNullOrWhiteSpace(existingNoOrder))
            {
                return;
            }

            try
            {
                var detail = await saleService.GetSaleById(existingNoOrder);

                if (detail?.header != null)
                {
                    txtBoxNoOrder.Text = detail.header.noOrder;
                    dateTimePickerOrder.Value = detail.header.odate;
                    txtCustId.Text = detail.header.customer;

                    try
                    {
                        PartnerService partnerService = new PartnerService();
                        var partners = await partnerService.GetPartner();
                        var cust = partners.FirstOrDefault(p => p.ccode == detail.header.customer);
                        if (cust != null)
                        {
                            txtCustName.Text = cust.cname;
                        }
                    }
                    catch
                    {
                        txtCustName.Text = detail.header.customer;
                    }

                    txtDpp.Text = detail.header.dpp.ToString("N0", new CultureInfo("id-ID"));
                    txtDiscPrs.Text = detail.header.discPrs.ToString("N0", new CultureInfo("id-ID"));
                    txtPPn.Text = detail.header.ppnPrs.ToString("N0", new CultureInfo("id-ID"));
                    txtFinalPrice.Text = detail.header.total.ToString("N0", new CultureInfo("id-ID"));
                }
                if (detail?.lines != null)
                {
                    dataGridOrderModule.Rows.Clear();
                    foreach (var line in detail.lines)
                    {
                        dataGridOrderModule.Rows.Add(line.prCode, line.pName, line.qty, line.pPrice, line.total);
                    }
                }

                HitungTotalGrid();
                headerCreated = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to load existing order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadOrderLines()
        {
            dataGridOrderModule.Rows.Clear();

            var noOrder = txtBoxNoOrder.Text?.Trim();
            if(string.IsNullOrWhiteSpace(noOrder))
                return;

            try
            {
                var detail = await saleService.GetSaleById(noOrder);

                if(detail?.lines != null)
                {
                    foreach (var line in detail.lines)
                    {
                        dataGridOrderModule.Rows.Add(line.prCode, line.pName, line.qty, line.pPrice, line.total);
                    }
                }

                HitungTotalGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load order lines: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private bool ValidateOrderDetail()
        {
            bool valid = true;

            // No Order
            errorProvider1.SetError(
                txtBoxNoOrder,
                string.IsNullOrWhiteSpace(txtBoxNoOrder.Text)
                    ? "Order number is required"
                    : ""
            );

            // Customer
            errorProvider1.SetError(
                txtCustId,
                string.IsNullOrWhiteSpace(txtCustId.Text)
                    ? "Customer is required"
                    : ""
            );

            // Product
            errorProvider1.SetError(
                txtProductId,
                string.IsNullOrWhiteSpace(txtProductId.Text)
                    ? "Product is required"
                    : ""
            );

            // Qty
            errorProvider1.SetError(
                numericQty,
                numericQty.Value <= 0
                    ? "Quantity must be greater than 0"
                    : ""
            );

            // Price
            errorProvider1.SetError(
                txtPrice,
                string.IsNullOrWhiteSpace(txtPrice.Text) || Convert.ToInt32(txtPrice.Text) <= 0
                    ? "Price must be greater than 0"
                    : ""
            );

            if (
                string.IsNullOrWhiteSpace(txtBoxNoOrder.Text) ||
                string.IsNullOrWhiteSpace(txtCustId.Text) ||
                string.IsNullOrWhiteSpace(txtProductId.Text) ||
                numericQty.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                Convert.ToInt32(txtPrice.Text) <= 0
            )
                valid = false;

            return valid;
        }

        private void numericQty_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(numericQty.Value) > qty)
            {
                MessageBox.Show("Instock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericQty.Value = numericQty.Value - 1;
                return;
            }
            else if (Convert.ToInt32(numericQty.Value) > 0)
            {
                int total = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(numericQty.Value);
                txtTotal.Text = total.ToString();
            }

            if(numericQty.Value <= 0)
            {
                errorProvider1.SetError(numericQty, "Please increase qty");
            }
            else
            {
                errorProvider1.SetError(numericQty, "");
            }
        }

        private void dataGridCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustId.Text = dataGridCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCustName.Text = dataGridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dataGridProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductId.Text = dataGridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = dataGridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dataGridProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            qty = Convert.ToInt32(dataGridProduct.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        private void Clear()
        {
            txtProductId.Clear();
            txtCustId.Clear();
            numericQty.Value = 0;
            txtPrice.Clear();
            txtTotal.Clear();
            txtCustName.Clear();
            txtProductName.Clear();
            dateTimePickerOrder.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void ClearProduct()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            numericQty.Value = 0;
            txtTotal.Clear();
        }

        private void dataGridOrderModule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            selectedRowIndex = e.RowIndex;
            isEditMode = true;

            DataGridViewRow row = dataGridOrderModule.Rows[e.RowIndex];

            txtProductId.Text = row.Cells[0].Value.ToString();
            txtProductName.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            numericQty.Value = Convert.ToInt32(row.Cells[2].Value);
            txtTotal.Text = row.Cells[4].Value.ToString();
        }

        private async void txtBoxNoOrder_Leave(object sender, EventArgs e)
        {
            string noOrder = txtBoxNoOrder.Text?.Trim();

            if(string.IsNullOrWhiteSpace(noOrder))
            {
                headerCreated = false;
                return;
            }

            try
            {
                var existing = await saleService.GetSaleById(noOrder);
                headerCreated = (existing != null);
            }
            catch
            {
                headerCreated = false;
            }

            await LoadOrderLines();
        }

        private void txtDiscPrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dpp = 0;
            double disc = 0;

            if (e.KeyChar == (char)Keys.Enter)
            {
                double.TryParse(txtDpp.Text, out dpp);
                double.TryParse(txtDiscPrs.Text, out disc);

                double discRph = (dpp * disc) / 100;
                lblDisc.Text = discRph.ToString();

                double finalPrice = double.Parse(txtDpp.Text) - double.Parse(lblDisc.Text);
                txtFinalPrice.Text = finalPrice.ToString();
                txtDiscPrs.Focus();
            }
        }

        private void txtPPn_KeyPress(object sender, KeyPressEventArgs e)
        {
            double priceAftDisc = 0;
            double ppn = 0;

            if(e.KeyChar == (char)Keys.Enter)
            {
                double.TryParse(lblDisc.Text, out priceAftDisc);
                double.TryParse(txtPPn.Text, out ppn);

                double ppnRph = (priceAftDisc * ppn) / 100;
                lblPPn.Text = ppnRph.ToString();

                double finalPrice = double.Parse(txtDpp.Text) - double.Parse(lblDisc.Text) + double.Parse(lblPPn.Text);
                txtFinalPrice.Text = finalPrice.ToString();
            }
        }

        private void OrderModuleForm_Load(object sender, EventArgs e)
        {
            HitungTotalGrid();
        }

        private void HitungTotalGrid()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridOrderModule.Rows)
            {
                if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "")
                {
                    total += Convert.ToDecimal(row.Cells[4].Value);
                }
            }

            txtDpp.Text = total.ToString();
        }

        private void dataGridOrderModule_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            HitungTotalGrid();
        }

        private void dataGridOrderModule_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            HitungTotalGrid();
        }

        private void dataGridOrderModule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            HitungTotalGrid();
        }

        private void txtBoxNoOrder_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtBoxNoOrder, string.IsNullOrWhiteSpace(txtBoxNoOrder.Text) ? "Order number is required" : "");
        }

        private void txtCustId_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCustId, string.IsNullOrWhiteSpace(txtCustId.Text) ? "Customer Id is required" : "");
        }

        private void txtCustName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCustName, string.IsNullOrWhiteSpace(txtCustName.Text) ? "Customer name is required" : "");
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtProductId, string.IsNullOrWhiteSpace(txtProductId.Text) ? "Product Id is required" : "");
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtProductName, string.IsNullOrWhiteSpace(txtProductName.Text) ? "Product name is required" : "");
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPrice, string.IsNullOrWhiteSpace(txtPrice.Text) ? "Product price is required" : "");
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string noOrder = txtBoxNoOrder.Text?.Trim();

            if(string.IsNullOrWhiteSpace(noOrder))
            {
                MessageBox.Show("Order number is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(string.IsNullOrWhiteSpace(txtCustId.Text))
            {
                MessageBox.Show("Customer is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HitungTotalGrid();

            decimal dppDec = 0m;
            decimal discPrsDec = 0m;
            decimal discRphDec = 0m;
            decimal ppnPrsDec = 0m;
            decimal ppnRphDec = 0m;
            decimal netAmountDec = 0m;

            // parse dpp from textbox (HitungTotalGrid sets txtDpp)
            if (!decimal.TryParse(txtDpp.Text, System.Globalization.NumberStyles.Number, CultureInfo.CurrentCulture, out dppDec))
            {
                decimal.TryParse(txtDpp.Text, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out dppDec);
            }

            // parse discount % and compute discount amount
            if (!decimal.TryParse(txtDiscPrs.Text, System.Globalization.NumberStyles.Number, CultureInfo.CurrentCulture, out discPrsDec))
            {
                decimal.TryParse(txtDiscPrs.Text, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out discPrsDec);
            }

            lblDisc.Text = discRphDec.ToString("N0", new CultureInfo("id-ID"));

            decimal priceAfterDisc = dppDec - discRphDec;

            // parse ppn % and compute ppn amount
            if (!decimal.TryParse(txtPPn.Text, System.Globalization.NumberStyles.Number, CultureInfo.CurrentCulture, out ppnPrsDec))
            {
                decimal.TryParse(txtPPn.Text, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out ppnPrsDec);
            }
            ppnRphDec = (ppnPrsDec / 100m) * priceAfterDisc;
            lblPPn.Text = ppnRphDec.ToString("0.##");

            netAmountDec = priceAfterDisc + ppnRphDec;
            txtFinalPrice.Text = netAmountDec.ToString("0.##");

            var sales = new Sale
            {
                noOrder = noOrder,
                odate = dateTimePickerOrder.Value,
                customer = txtCustId.Text,
                dpp = Convert.ToSingle(dppDec),
                discPrs = Convert.ToSingle(discPrsDec),
                discRph = Convert.ToSingle(discRphDec),
                ppnPrs = Convert.ToSingle(ppnPrsDec),
                ppnRph = Convert.ToSingle(ppnRphDec),
                total = Convert.ToSingle(netAmountDec)
            };

            try
            {
                btnCreate.Enabled = false;

                try
                {
                    bool re = headerCreated;
                    if (headerCreated == false)
                    {
                        await saleService.CreateSale(noOrder, sales);
                    }
                    else
                    {
                        await saleService.UpdateSale(noOrder, sales);
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message ?? string.Empty;
                    if (msg.IndexOf("Conflict", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        msg.IndexOf("already exists", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        msg.IndexOf("409", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        await saleService.UpdateSale(noOrder, sales);
                    }
                    else
                    {
                        throw;
                    }
                }
                MessageBox.Show("Order successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadOrderLines();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                headerCreated = false;
                btnCreate.Enabled = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if(selectedRowIndex < 0)
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dataGridOrderModule.Rows[selectedRowIndex];
            string prCode = row.Cells[0].Value.ToString();
            string noOrder = txtBoxNoOrder.Text?.Trim();

            if(string.IsNullOrWhiteSpace(noOrder))
            {
                MessageBox.Show("Order number is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Yakin menghapus line {prCode}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await saleService.DeleteLine(noOrder, prCode);
                    MessageBox.Show("Order line deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadOrderLines();
                    ClearProduct();
                    selectedRowIndex = -1;
                    isEditMode = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete order line: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSaveDetail_Click(object sender, EventArgs e)
        {
            if (!ValidateOrderDetail())
            {
                MessageBox.Show("Please fill in all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Decimal.TryParse(txtPrice.Text, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out decimal priceDecimal))
            {
                MessageBox.Show("Invalid price format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int qtyInt = Convert.ToInt32(numericQty.Value);
            decimal totalDecimal = priceDecimal * qtyInt;

            var detail = new SaleLineRequest
            {
                prDate = dateTimePickerOrder.Value,
                prCode = txtProductId.Text,
                qty = qtyInt,
                pPrice = Convert.ToInt32(Math.Round(priceDecimal)),
                total = Convert.ToInt32(Math.Round(totalDecimal)),
                customer = txtCustId.Text
            };

            string noOrder = txtBoxNoOrder.Text?.Trim();

            if (string.IsNullOrWhiteSpace(noOrder))
            {
                MessageBox.Show("Order number is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnSaveDetail.Enabled = false;

                if (isEditMode && selectedRowIndex >= 0)
                {
                    var row = dataGridOrderModule.Rows[selectedRowIndex];
                    string oldPrCode = row.Cells[0].Value.ToString();

                    await saleService.UpdateLine(noOrder, oldPrCode, detail);
                    MessageBox.Show("Order line updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await saleService.AddLine(noOrder, detail);
                    MessageBox.Show("Order line added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadOrderLines();
                ClearProduct();
                selectedRowIndex = -1;
                isEditMode = false;
                headerCreated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save order line: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSaveDetail.Enabled = true;
            }
        }
    }
}
