using InventoryManagement.Models;
using MySql.Data.MySqlClient;
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
    public partial class PurchaseModuleForm : Form
    {
        private ToolStripDropDown popUpContainer;

        int selectedRowIndex = -1;
        bool isEditMode = false;
        int qty = 0;
        bool headerCreated = false;
        private string existingOrderNo = null;

        private readonly PurchaseService purchaseService = new PurchaseService();
        private readonly ProductService productService = new ProductService();

        // Constructor untuk mode CREATE
        public PurchaseModuleForm()
        {
            InitializeComponent();
            LoadProduct();
            LoadVendor();
            isEditMode = false;

            SetupPopUpContainer();

            txtBoxNoOrder.TabIndex = 0;
            dateTimePickerOrder.TabIndex = 1;
            txtProductId.TabIndex = 2;
            dataGridVendor.TabIndex = 3;
            numericQty.TabIndex = 4;
            btnSaveDetail.TabIndex = 5;
            txtDiscPrs.TabIndex = 6;
            txtPPn.TabIndex = 7;
            btnCreate.TabIndex = 8;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                // Jangan ubah fungsi Enter jika user sedang berada di Button atau DataGridView
                if (this.ActiveControl is Button || this.ActiveControl is DataGridView || this.ActiveControl == txtPPn || this.ActiveControl == txtDiscPrs)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                // Otomatis pindah ke kontrol selanjutnya berdasarkan TabIndex
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                return true; // Hilangkan suara "beep" Windows
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Constructor untuk mode EDIT
        public PurchaseModuleForm(string orderNo)
        {
            InitializeComponent();
            LoadProduct();
            LoadVendor();

            existingOrderNo = orderNo;
            isEditMode = true;

            // Lock PO number field - tidak bisa diubah saat edit
            txtBoxNoOrder.Text = orderNo;
            txtBoxNoOrder.ReadOnly = true;

            // Load existing data
            LoadExistingPurchase();
        }

        private async Task LoadVendor()
        {
            dataGridVendor.Rows.Clear();

            try
            {
                PartnerService service = new PartnerService();
                var vendor = await service.GetPartner();

                foreach (var v in vendor)
                {
                    if (v.cType == "Vendor")
                    {
                        dataGridVendor.Rows.Add(v.ccode, v.cname);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadProduct()
        {
            dataGridProduct.Rows.Clear();

            try
            {
               ProductService service = new ProductService();
               var product = await service.GetProducts();

                foreach (var pr in product)
                {
                    dataGridProduct.Rows.Add(pr.pcode, pr.pName, pr.pPrice, pr.pQty, pr.pDescription, pr.catname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadExistingPurchase()
        {
            if (string.IsNullOrWhiteSpace(existingOrderNo))
                return;

            try
            {
                var detail = await purchaseService.GetPurchaseById(existingOrderNo);

                if (detail?.header != null)
                {
                    // Load header data
                    txtBoxNoOrder.Text = detail.header.noOrder;
                    dateTimePickerOrder.Value = detail.header.odate;
                    txtVendorId.Text = detail.header.vendor;
                    
                    // Load vendor name
                    try
                    {
                        PartnerService partnerService = new PartnerService();
                        var partners = await partnerService.GetPartner();
                        var vendor = partners.FirstOrDefault(p => p.ccode == detail.header.vendor);
                        if (vendor != null)
                        {
                            txtVendorName.Text = vendor.cname;
                        }
                    }
                    catch
                    {
                        txtVendorName.Text = detail.header.vendor;
                    }

                    txtDpp.Text = detail.header.dpp.ToString("N0", new CultureInfo("id-ID"));
                    txtDiscPrs.Text = detail.header.discPrs.ToString("N0", new CultureInfo("id-ID"));
                    txtPPn.Text = detail.header.ppnPrs.ToString("N0", new CultureInfo("id-ID"));
                    txtFinalPrice.Text = detail.header.netAmount.ToString("N0", new CultureInfo("id-ID"));
                }

                // Load lines data
                if (detail?.lines != null)
                {
                    dataGridPurchaseModule.Rows.Clear();
                    foreach (var line in detail.lines)
                    {
                        dataGridPurchaseModule.Rows.Add(
                            line.prCode,
                            line.pName,
                            line.pPrice,
                            line.qty,
                            line.total
                        );
                    }
                }

                HitungTotalGrid();
                headerCreated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load purchase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearProduct()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            numericQty.Value = 0;
            txtTotal.Clear();
        }

        private async Task LoadPurchaseLines()
        {
            dataGridPurchaseModule.Rows.Clear();

            var noOrder = txtBoxNoOrder.Text?.Trim();
            if (string.IsNullOrWhiteSpace(noOrder))
                return;

            try
            {
                var detail = await purchaseService.GetPurchaseById(noOrder);

                // If the API returns 404 it will return null - treat as empty lines (no header yet)
                if (detail?.lines != null)
                {
                    foreach (var line in detail.lines)
                    {
                        dataGridPurchaseModule.Rows.Add(line.prCode, line.pName, line.qty, line.pPrice, line.total);
                    }
                }

                HitungTotalGrid();
            }
            catch (Exception ex)
            {
                // Log detailed error and show non-blocking message
                System.Diagnostics.Debug.WriteLine($"LoadPurchaseLines error: {ex.Message}");
                MessageBox.Show("Failed to load purchase lines. Check the server or network.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePODetail()
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
                txtVendorId,
                string.IsNullOrWhiteSpace(txtVendorId.Text)
                    ? "Vendor is required"
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

            // Price - use TryParse to avoid FormatException
            decimal price;
            var priceValid = decimal.TryParse(txtPrice.Text, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out price) && price > 0m;
            errorProvider1.SetError(
                txtPrice,
                !priceValid ? "Price must be a positive number" : ""
            );

            if (
                string.IsNullOrWhiteSpace(txtBoxNoOrder.Text) ||
                string.IsNullOrWhiteSpace(txtVendorId.Text) ||
                string.IsNullOrWhiteSpace(txtProductId.Text) ||
                numericQty.Value <= 0 ||
                !priceValid
            )
                valid = false;

            return valid;
        }

        private void txtVendor_TextChanged(object sender, EventArgs e)
        {
            LoadVendor();
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void dataGridPurchaseModule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedRowIndex = e.RowIndex;
            isEditMode = true;

            DataGridViewRow row = dataGridPurchaseModule.Rows[selectedRowIndex];

            txtProductId.Text = row.Cells[0].Value.ToString();
            txtProductName.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            numericQty.Value = Convert.ToInt32(row.Cells[2].Value);
            txtTotal.Text = row.Cells[4].Value.ToString();

            txtProductId.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearProduct();
            selectedRowIndex = -1;
            isEditMode = false;
        }
        
        private async void txtBoxNoOrder_Leave(object sender, EventArgs e)
        {
            string noOrder = txtBoxNoOrder.Text?.Trim();
            if (string.IsNullOrWhiteSpace(noOrder))
            {
                headerCreated = false;
                return;
            }

            // Check if purchase header already exists on server
            try
            {
                var existing = await purchaseService.GetPurchaseById(noOrder);
                headerCreated = (existing != null);
                System.Diagnostics.Debug.WriteLine($"txtBoxNoOrder_Leave: Order '{noOrder}' exists={headerCreated}");
            }
            catch
            {
                headerCreated = false;
            }

            await LoadPurchaseLines();
        }

        private async void PurchaseModuleForm_Load(object sender, EventArgs e)
        {
            HitungTotalGrid();

            var po = await purchaseService.GetPurchaseById(txtBoxNoOrder.Text?.Trim());

            if(po.header.state != "DRAFT")
            {
                btnClear.Visible = false;
                btnDelete.Visible = false;
                btnCreate.Visible = false;
                btnSaveDetail.Visible = false;
                btnConfirm.Visible = false;

                dateTimePickerOrder.Enabled = false;
                txtVendorId.ReadOnly = true;
                txtProductId.ReadOnly = true;
                txtPrice.ReadOnly = true;
                txtDiscPrs.ReadOnly = true;
                txtFinalPrice.ReadOnly = true;
                txtPPn.ReadOnly = true;
                numericQty.ReadOnly = true;
                dataGridProduct.ReadOnly = true;

                dataGridProduct.Enabled = false;
            }
        }

        private void HitungTotalGrid()
        {
            decimal total = 0;
            foreach(DataGridViewRow row in dataGridPurchaseModule.Rows)
            {
                if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "")
                {
                    total += Convert.ToDecimal(row.Cells[4].Value);
                }
            }
            txtDpp.Text = total.ToString();
        }

        private void dataGridPurchaseModule_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            HitungTotalGrid();
        }

        private void dataGridPurchaseModule_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            HitungTotalGrid();
        }

        private void dataGridPurchaseModule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            HitungTotalGrid();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridVendor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVendorId.Text = dataGridVendor.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtVendorName.Text = dataGridVendor.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dataGridProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductId.Text = dataGridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = dataGridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dataGridProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private async void numericQty_ValueChanged(object sender, EventArgs e)
        {
            int qty = (int)numericQty.Value;

            if (qty <= 0)
            {
                errorProvider1.SetError(numericQty, "Please increase qty");
                txtTotal.Text = "0";
                return;
            }

            errorProvider1.SetError(numericQty, "");

            float price = 0;
            float.TryParse(txtPrice.Text, out price);

            float total = price * qty;

            txtTotal.Text = total.ToString("N0", new CultureInfo("id-ID"));
        }

        private async void btnSaveDetail_Click(object sender, EventArgs e)
        {
            if (!ValidatePODetail())
                return;

            if (!System.Decimal.TryParse(txtPrice.Text, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out decimal priceDecimal))
            {
                MessageBox.Show("Invalid price format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int qtyInt = Convert.ToInt32(numericQty.Value);
            decimal totalDecimal = priceDecimal * qtyInt;

            var detail = new PurchaseLineRequest
            {
                prDate = dateTimePickerOrder.Value,
                prCode = txtProductId.Text,
                pPrice = Convert.ToInt32(Math.Round(priceDecimal)),
                qty = qtyInt,
                total = Convert.ToInt32(Math.Round(totalDecimal)),
                state = "DRAFT",
                vendor = txtVendorId.Text
            };

            string orderNo = txtBoxNoOrder.Text?.Trim();
            if (string.IsNullOrWhiteSpace(orderNo))
            {
                MessageBox.Show("Order number is required before adding detail.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                btnSaveDetail.Enabled = false;

                // If in edit mode, update the existing line
                if (isEditMode && selectedRowIndex >= 0)
                {
                    var row = dataGridPurchaseModule.Rows[selectedRowIndex];
                    string oldPrCode = row.Cells[0].Value.ToString();
                    
                    await purchaseService.UpdateLine(orderNo, oldPrCode, detail);
                    MessageBox.Show("Line berhasil diupdate!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Add new line
                    await purchaseService.AddLine(orderNo, detail);
                }

                await LoadPurchaseLines();
                ClearProduct();
                selectedRowIndex = -1;
                isEditMode = false;
                headerCreated = true;

                txtProductId.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSaveDetail.Enabled = true;
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string noOrder = txtBoxNoOrder.Text?.Trim();

            if (string.IsNullOrWhiteSpace(noOrder))
            {
                MessageBox.Show("No Order tidak boleh kosong!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVendorId.Text))
            {
                MessageBox.Show("Pilih vendor terlebih dahulu!");
                return;
            }

            // ensure totals are up-to-date
            HitungTotalGrid();

            // Compute header amounts from current inputs and grid to ensure values are populated even if user didn't press Enter
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

            lblDisc.Text = discRphDec.ToString("0.##");

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

            var purchase = new Purchase
            {
                noOrder = noOrder,
                odate = dateTimePickerOrder.Value,
                vendor = txtVendorId.Text,
                dpp = (float)dppDec,
                discPrs = (float)discPrsDec,
                discRph = (float)discRphDec,
                ppnPrs = (float)ppnPrsDec,
                ppnRph = (float)ppnRphDec,
                netAmount = (float)netAmountDec,
                state = "CONFIRM"
            };

            try
            {
                btnCreate.Enabled = false;

                // Try to create first. If server returns conflict/already exists, fall back to update.
                try
                {
                    bool re = headerCreated;
                    if (headerCreated == false)
                    {
                        await purchaseService.CreatePurchase(noOrder, purchase);
                    }
                    else
                    {
                        await purchaseService.UpdatePurchase(noOrder, purchase);
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message ?? string.Empty;
                    if (msg.IndexOf("Conflict", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        msg.IndexOf("already exists", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        msg.IndexOf("409", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        // If already exists, update instead
                        await purchaseService.UpdatePurchase(noOrder, purchase);
                    }
                    else
                    {
                        throw; // rethrow other exceptions
                    }
                }

                MessageBox.Show("Purchase berhasil disimpan!",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // reload purchase lines after saving header
                await LoadPurchaseLines();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                headerCreated = false;
                btnCreate.Enabled = true;
            }
        }

        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Pilih line yang ingin dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridPurchaseModule.Rows[selectedRowIndex];
            string prCode = row.Cells[0].Value.ToString();
            string orderNo = txtBoxNoOrder.Text?.Trim();

            if (string.IsNullOrWhiteSpace(orderNo))
            {
                MessageBox.Show("Order number is required!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Yakin ingin menghapus line {prCode}?",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await purchaseService.DeleteLine(orderNo, prCode);
                    await LoadPurchaseLines();
                    ClearProduct();
                    selectedRowIndex = -1;
                    isEditMode = false;
                    MessageBox.Show("Line berhasil dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void SetupPopUpContainer()
        {
            popUpContainer = new ToolStripDropDown
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };
        }

        private void ShowFloatingGrid(TextBox targetTextBox, DataGridView targetGrid, Size popupSize)
        {
            // Kosongkan item sebelumnya agar tidak menumpuk
            popUpContainer.Items.Clear();

            // Bungkus DataGridView target ke Host
            targetGrid.Visible = true;
            targetGrid.Size = popupSize;

            ToolStripControlHost host = new ToolStripControlHost(targetGrid)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false,
                Size = popupSize
            };

            popUpContainer.Items.Add(host);
            popUpContainer.Size = popupSize;

            // Tampilkan tepat di bawah TextBox target
            popUpContainer.Show(targetTextBox, new Point(0, targetTextBox.Height));

            // Pindahkan fokus ke grid agar bisa langsung navigasi panah/Enter
            targetGrid.Focus();
        }

        private void txtVendorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                ShowFloatingGrid(txtVendorId,dataGridVendor,new Size(500,200));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (popUpContainer.Visible)
                {
                    popUpContainer.Close();
                }
            }
        }

        private void dataGridVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (dataGridVendor.CurrentRow != null)
                {
                    txtVendorId.Text = dataGridVendor.CurrentRow.Cells[0].Value.ToString();
                    txtVendorName.Text = dataGridVendor.CurrentRow.Cells[1].Value.ToString();
                }
                popUpContainer?.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                popUpContainer.Close();
            }
        }

        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                ShowFloatingGrid(txtProductId,dataGridProduct,new Size(500,200));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (popUpContainer.Visible)
                {
                    popUpContainer.Close();
                }

                if(isEditMode == true)
                {
                    txtDiscPrs.Focus();
                }
            }
        }

        private void dataGridProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridProduct.CurrentRow != null)
                {
                    txtProductId.Text = dataGridProduct.CurrentRow.Cells[0].Value.ToString();
                    txtProductName.Text = dataGridProduct.CurrentRow.Cells[1].Value.ToString();
                    txtPrice.Text = dataGridProduct.CurrentRow.Cells[3].Value.ToString();
                }
                popUpContainer.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                popUpContainer.Close();
            }
        }

        private void txtBoxNoOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if(isEditMode == true)
            {
                if(e.KeyCode == Keys.Escape)
                {
                    txtDiscPrs.Focus();
                }
            }
        }

        private void txtDiscPrs_KeyDown(object sender, KeyEventArgs e)
        {
            double dpp = 0;
            double disc = 0;

            if (e.KeyCode == Keys.Enter)
            {
                double.TryParse(txtDpp.Text, out dpp);
                double.TryParse(txtDiscPrs.Text, out disc);

                double discRph = (disc / 100) * dpp;
                lblDisc.Text = discRph.ToString();

                double finalPrice = double.Parse(txtDpp.Text) - double.Parse(lblDisc.Text);
                txtFinalPrice.Text = finalPrice.ToString();
                txtPPn.Focus();
            }
        }

        private void txtPPn_KeyDown(object sender, KeyEventArgs e)
        {
            double priceAftDisc = 0;
            double ppn = 0;

            if (e.KeyCode == Keys.Enter)
            {
                double.TryParse(txtFinalPrice.Text, out priceAftDisc);
                double.TryParse(txtPPn.Text, out ppn);

                double ppnRph = (ppn / 100) * priceAftDisc;
                lblPPn.Text = ppnRph.ToString();

                double finalPrice = double.Parse(txtDpp.Text) - double.Parse(lblDisc.Text) + double.Parse(lblPPn.Text);
                txtFinalPrice.Text = finalPrice.ToString();
                btnCreate.Focus();
            }
        }
    }
}
