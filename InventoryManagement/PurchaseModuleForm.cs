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

            SetupPopUpContainer();

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
                System.Diagnostics.Debug.WriteLine($"LoadPurchaseLines error: {ex.Message}");
                MessageBox.Show("Failed to load purchase lines. Check the server or network.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePODetail()
        {
            bool valid = true;

            errorProvider1.SetError(txtBoxNoOrder, string.IsNullOrWhiteSpace(txtBoxNoOrder.Text) ? "Order number is required" : "");
            errorProvider1.SetError(txtVendorId, string.IsNullOrWhiteSpace(txtVendorId.Text) ? "Vendor is required" : "");
            errorProvider1.SetError(txtProductId, string.IsNullOrWhiteSpace(txtProductId.Text) ? "Product is required" : "");
            errorProvider1.SetError(numericQty, numericQty.Value <= 0 ? "Quantity must be greater than 0" : "");

            decimal price;
            var priceValid = decimal.TryParse(txtPrice.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out price) && price > 0m;
            errorProvider1.SetError(txtPrice, !priceValid ? "Price must be a positive number" : "");

            if (string.IsNullOrWhiteSpace(txtBoxNoOrder.Text) ||
                string.IsNullOrWhiteSpace(txtVendorId.Text) ||
                string.IsNullOrWhiteSpace(txtProductId.Text) ||
                numericQty.Value <= 0 ||
                !priceValid)
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

            txtProductId.Text = row.Cells[0].Value?.ToString();
            txtProductName.Text = row.Cells[1].Value?.ToString();
            txtPrice.Text = row.Cells[3].Value?.ToString();
            numericQty.Value = Convert.ToInt32(row.Cells[2].Value ?? 0);
            txtTotal.Text = row.Cells[4].Value?.ToString();

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

            try
            {
                var existing = await purchaseService.GetPurchaseById(noOrder);
                headerCreated = (existing != null);
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
            foreach (DataGridViewRow row in dataGridPurchaseModule.Rows)
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
            if (e.RowIndex >= 0)
            {
                txtVendorId.Text = dataGridVendor.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                txtVendorName.Text = dataGridVendor.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                popUpContainer?.Close();
            }
        }

        private void dataGridProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProductId.Text = dataGridProduct.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                txtProductName.Text = dataGridProduct.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                txtPrice.Text = dataGridProduct.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
                popUpContainer?.Close();
            }
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
            if (!ValidatePODetail()) return;

            if (!decimal.TryParse(txtPrice.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal priceDecimal))
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

                if (isEditMode && selectedRowIndex >= 0)
                {
                    var row = dataGridPurchaseModule.Rows[selectedRowIndex];
                    string oldPrCode = row.Cells[0].Value.ToString();
                    await purchaseService.UpdateLine(orderNo, oldPrCode, detail);
                    MessageBox.Show("Line berhasil diupdate!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
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

            HitungTotalGrid();

            decimal dppDec = 0m, discPrsDec = 0m, discRphDec = 0m, ppnPrsDec = 0m, ppnRphDec = 0m, netAmountDec = 0m;

            decimal.TryParse(txtDpp.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out dppDec);
            decimal.TryParse(txtDiscPrs.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out discPrsDec);

            discRphDec = (discPrsDec / 100m) * dppDec;
            lblDisc.Text = discRphDec.ToString("0.##");

            decimal priceAfterDisc = dppDec - discRphDec;

            decimal.TryParse(txtPPn.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out ppnPrsDec);

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
                state = "DRAFT"
            };

            try
            {
                btnCreate.Enabled = false;

                try
                {
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
                        await purchaseService.UpdatePurchase(noOrder, purchase);
                    }
                    else
                    {
                        throw;
                    }
                }

                MessageBox.Show("Purchase berhasil disimpan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPurchaseLines();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                headerCreated = false;
                btnCreate.Enabled = true;
            }
        }

        private void FilterGridView(DataGridView grid, string keyword)
        {
            string searchKey = keyword.Trim().ToLower();
            grid.CurrentCell = null;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;

                if (string.IsNullOrWhiteSpace(searchKey))
                {
                    row.Visible = true;
                }
                else
                {
                    string code = row.Cells[0].Value?.ToString().ToLower() ?? "";
                    string name = row.Cells[1].Value?.ToString().ToLower() ?? "";

                    bool isMatch = code.Contains(searchKey) || name.Contains(searchKey);
                    row.Visible = isMatch;
                }
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

            if (MessageBox.Show($"Yakin ingin menghapus line {prCode}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void btnConfirm_Click(object sender, EventArgs e) { }

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
            popUpContainer.Items.Clear();

            Panel panel = new Panel
            {
                Size = popupSize,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            TextBox txtSearch = new TextBox
            {
                Dock = DockStyle.Top,
                Font = new Font(this.Font.FontFamily, 10, FontStyle.Regular),
            };

            targetGrid.Visible = true;
            targetGrid.Dock = DockStyle.Fill;

            panel.Controls.Add(targetGrid);
            panel.Controls.Add(txtSearch);

            txtSearch.TextChanged += (s, e) =>
            {
                FilterGridView(targetGrid, txtSearch.Text);
            };

            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Down)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    targetGrid.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    popUpContainer.Close();
                }
            };

            ToolStripControlHost host = new ToolStripControlHost(panel)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false,
                Size = popupSize
            };

            popUpContainer.Items.Add(host);
            popUpContainer.Size = popupSize;

            popUpContainer.Show(targetTextBox, new Point(0, targetTextBox.Height));
            txtSearch.Focus();
        }

        private void txtVendorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ShowFloatingGrid(txtVendorId, dataGridVendor, new Size(500, 200));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (popUpContainer != null && popUpContainer.Visible)
                {
                    popUpContainer.Close();
                }
            }
        }

        private void dataGridVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (dataGridVendor.CurrentRow != null && dataGridVendor.CurrentRow.Index >= 0)
                {
                    txtVendorId.Text = dataGridVendor.CurrentRow.Cells[0].Value?.ToString() ?? "";
                    txtVendorName.Text = dataGridVendor.CurrentRow.Cells[1].Value?.ToString() ?? "";
                }
                popUpContainer?.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                popUpContainer?.Close();
            }
        }

        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ShowFloatingGrid(txtProductId, dataGridProduct, new Size(500, 200));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (popUpContainer != null && popUpContainer.Visible)
                {
                    popUpContainer.Close();
                }
                txtDiscPrs.Focus();
            }
        }

        private void dataGridProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (dataGridProduct.CurrentRow != null && dataGridProduct.CurrentRow.Index >= 0)
                {
                    txtProductId.Text = dataGridProduct.CurrentRow.Cells[0].Value?.ToString() ?? "";
                    txtProductName.Text = dataGridProduct.CurrentRow.Cells[1].Value?.ToString() ?? "";
                    txtPrice.Text = dataGridProduct.CurrentRow.Cells[3].Value?.ToString() ?? "";
                }
                popUpContainer?.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                popUpContainer?.Close();
            }
        }

        private void txtBoxNoOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (isEditMode && e.KeyCode == Keys.Escape)
            {
                txtDiscPrs.Focus();
            }
        }

        private void txtPPn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                decimal.TryParse(txtDpp.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal dpp);
                decimal.TryParse(txtDiscPrs.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal discPrs);
                decimal.TryParse(txtPPn.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ppnPrs);

                decimal discRph = (discPrs / 100m) * dpp;
                decimal priceAfterDisc = dpp - discRph;
                decimal ppnRph = (ppnPrs / 100m) * priceAfterDisc;
                decimal finalPrice = priceAfterDisc + ppnRph;

                lblPPn.Text = ppnRph.ToString("N0", new CultureInfo("id-ID"));
                txtFinalPrice.Text = finalPrice.ToString("N0", new CultureInfo("id-ID"));

                btnCreate.Focus();
            }
        }

        // PERBAIKAN UTAMA: Menggunakan KeyDown menggantikan KeyPress
        private void txtDiscPrs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                decimal.TryParse(txtDpp.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal dpp);
                decimal.TryParse(txtDiscPrs.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal discPrs);

                decimal discRph = (discPrs / 100m) * dpp;
                decimal priceAfterDisc = dpp - discRph;

                lblDisc.Text = discRph.ToString("N0", new CultureInfo("id-ID"));
                txtFinalPrice.Text = priceAfterDisc.ToString("N0", new CultureInfo("id-ID"));

                txtPPn.Focus();
                txtPPn.SelectAll();
            }
        }
    }
}