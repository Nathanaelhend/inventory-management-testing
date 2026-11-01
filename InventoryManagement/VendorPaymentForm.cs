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
using System.Windows.Shapes;

namespace InventoryManagement
{
    public partial class VendorPaymentForm : Form
    {
        private int _selectedBillId = 0;
        private int _selectedVendorId = 0;

        VendorPaymentService vps = new VendorPaymentService();
        BillService billService = new BillService();

        private ToolStripDropDown popUpContainer;

        int selectedRowIndex = -1;
        bool isEditMode = false;
        bool headerCreated = false;

        public VendorPaymentForm()
        {
            InitializeComponent();
        }

        private async Task LoadPayment()
        {
            dataGridListBill.Rows.Clear();

            var name = txtNoBukti.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name))
                return;

            try
            {
                VendorPaymentDetailResponse response = await vps.GetPaymentById(name);

                var header = response?.data?.header ?? response?.header;

                if (header != null)
                {
                    comboType.Text = header.type_payment ?? "";
                    txtVendorId.Text = header.vendor_id ?? "";
                    txtVendorName.Text = header.vendor_name ?? "";
                    txtTotalPembayaran.Text = header.total_amount ?? "";
                    if (header.date_payment.HasValue)
                    {
                        datePickerPayment.Value = header.date_payment.Value;
                    }
                }

                var lines = response?.data?.lines ?? new List<PaymentLine>();

                dataGridListBill.SuspendLayout();

                foreach (var line in lines)
                {
                    DateTime? displayDate = line.date_nota ?? line.date_payment ?? line.bill_date;
                    if (!displayDate.HasValue && header != null && header.date_payment.HasValue)
                    {
                        displayDate = header.date_payment.Value;
                    }
                    if (!displayDate.HasValue && line.create_date.HasValue)
                    {
                        displayDate = line.create_date.Value;
                    }

                    int rIdx = dataGridListBill.Rows.Add
                    (
                        line.bill_name,
                        displayDate.HasValue ? displayDate.Value.ToString("dd/MM/yyyy") : "",
                        line.bill_total_amount.ToString("N0"),
                        line.total_paid_accumulated.ToString("N0"),
                        line.amount.ToString("N0")
                    );
                    dataGridListBill.Rows[rIdx].Tag = line.bill_id;
                }

                dataGridListBill.ResumeLayout();
                dataGridListBill.Refresh();
                HitungTotalPembayaran();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to load payment line " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HitungTotalPembayaran()
        {
            float total = 0f;
            foreach (DataGridViewRow row in dataGridListBill.Rows)
            {
                if (row.IsNewRow) continue;
                string val = row.Cells[4].Value?.ToString()?.Replace(".", "").Replace(",", "").Trim();
                if (float.TryParse(val, out float amt))
                {
                    total += amt;
                }
            }
            txtTotalPembayaran.Text = total.ToString("N0");
            textBox5.Text = total.ToString("N0");
        }

        private async Task LoadPaymentList()
        {
            dataGridPayment.Rows.Clear();

            try
            {
                List<VendorPayment> payment = await vps.GetPayments(); 

                foreach (var pay in payment)
                {
                    dataGridPayment.Rows.Add(
                        pay.name,
                        pay.date_payment?.ToShortDateString() ?? "",
                        pay.vendor_id,
                        pay.vendor_name,
                        pay.total_amount,
                        pay.type_payment
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.ActiveControl is Button || this.ActiveControl is DataGridView || this.ActiveControl == txtNoNota || this.ActiveControl == txtNoBukti || this.ActiveControl == txtJumBayar)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetupModernUI()
        {
            UITheme.ApplyGridStyle(dataGridListBill);
            UITheme.ApplyGridStyle(dataGridVendor);
            UITheme.ApplyGridStyle(dataGridBill);
            UITheme.ApplyGridStyle(dataGridPayment);

            UITheme.StylePrimaryButton(btnSave);
            UITheme.StyleSecondaryButton(btnLoad);
            UITheme.StyleSecondaryButton(btnNew);

            UITheme.StylePrimaryButton(btnSaveDetail);
            UITheme.StyleDangerButton(btnDeleteDetail);
            UITheme.StyleSecondaryButton(btnClearDetail);

            panel1.Paint += (s, e) =>
            {
                using (var pen = new Pen(UITheme.Border, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel1.Width - 1, panel1.Height - 1);
                }
            };

            panel2.Paint += (s, e) =>
            {
                using (var pen = new Pen(UITheme.Border, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel2.Width - 1, panel2.Height - 1);
                }
            };
        }

        private async void VendorPaymentForm_Load(object sender, EventArgs e)
        {
            SetupModernUI();
            dateTimeNota.Value = DateTime.Today;
            datePickerPayment.Value = DateTime.Today;

            SetupPopUpContainer();
            await LoadVendor();
            await LoadPaymentList();
        }

        private void SetupPopUpContainer()
        {
            popUpContainer = new ToolStripDropDown
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };
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
                        dataGridVendor.Rows.Add(v.sequence,v.ccode, v.cname);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadBill()
        {
            dataGridBill.Rows.Clear();
            string vendorId = txtVendorId.Text?.Trim();
            if (string.IsNullOrWhiteSpace(vendorId))
            {
                return;
            }

            try
            {
                var vendorBill = await billService.GetBillByVendorId(vendorId);

                foreach (var vb in vendorBill)
                {
                    dataGridBill.Rows.Add(
                        vb.id,
                        vb.date,
                        vb.name,
                        vb.total.ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    txtVendorId.Text = dataGridVendor.CurrentRow.Cells[1].Value?.ToString() ?? "";
                    txtVendorName.Text = dataGridVendor.CurrentRow.Cells[2].Value?.ToString() ?? "";
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

        private void dataGridVendor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridVendor.Rows.Count)
            {
                txtVendorId.Text = dataGridVendor.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                txtVendorName.Text = dataGridVendor.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                popUpContainer?.Close();
            }
        }

        private async Task<float> GetAccumulatedPaymentForBill(string billName)
        {
            float totalPaid = 0f;
            if (string.IsNullOrWhiteSpace(billName)) return 0f;

            try
            {
                var payments = await vps.GetPayments();
                if (payments != null)
                {
                    foreach (var pay in payments)
                    {
                        if (pay.lines != null)
                        {
                            foreach (var line in pay.lines)
                            {
                                if (string.Equals(line.bill_name, billName, StringComparison.OrdinalIgnoreCase))
                                {
                                    totalPaid += line.amount;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAccumulatedPaymentForBill error: {ex.Message}");
            }

            return totalPaid;
        }

        private async void txtNoNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                var noNota = txtNoNota.Text.Trim();

                if (string.IsNullOrWhiteSpace(noNota))
                {
                    MessageBox.Show("Harap isi nomor bill!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNoNota.Focus();
                    return;
                }

                try
                {
                    // 1. Cari data Bill berdasarkan Nomor Nota
                    var bill = await billService.GetBillByName(noNota);

                    // 2. Validasi apakah Bill ditemukan
                    if (bill == null || bill.status != "success" || bill.header == null)
                    {
                        MessageBox.Show("Bill tidak ditemukan!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNoNota.Focus();
                        txtNoNota.SelectAll();
                        return;
                    }

                    // 3. Set data Bill ke UI Form
                    _selectedBillId = bill.header.id;
                    dateTimeNota.Value = bill.header.date;
                    txtTotalNota.Text = bill.header.total.ToString("N0");

                    // 4. Ambil akumulasi pembayaran yang sudah pernah dibayar di nota itu
                    float totalAkumulasi = await GetAccumulatedPaymentForBill(noNota);
                    txtTotalBayar.Text = totalAkumulasi.ToString("N0");

                    // 5. Default sisa tagihan ke txtJumBayar jika belum lunas
                    float sisa = bill.header.total - totalAkumulasi;
                    txtJumBayar.Text = sisa > 0 ? sisa.ToString("N0") : "0";

                    txtJumBayar.Focus();
                    txtJumBayar.SelectAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (txtVendorId.Text == null)
                {
                    MessageBox.Show("Silahkan pilih Vendor terlebih dahulu!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ShowFloatingGrid(txtNoNota, dataGridBill, new Size(500, 200));
            }
        }

        private async void txtVendorId_TextChanged(object sender, EventArgs e)
        {
            await LoadBill();
        }

        private void ClearDetailFields()
        {
            txtNoNota.Clear();
            txtTotalNota.Clear();
            txtTotalBayar.Clear();
            txtJumBayar.Clear();
            _selectedBillId = 0;
            selectedRowIndex = -1;
            isEditMode = false;
            dateTimeNota.Value = DateTime.Today;
        }

        private void ResetForm()
        {
            txtNoBukti.Clear();
            txtVendorId.Clear();
            txtVendorName.Clear();
            txtTotalPembayaran.Clear();
            textBox5.Clear();
            comboType.SelectedIndex = -1;
            comboType.Text = "";
            datePickerPayment.Value = DateTime.Today;
            dataGridListBill.Rows.Clear();
            ClearDetailFields();
            headerCreated = false;
        }

        private async void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
            var numberPayment = await vps.GeneratePaymentNumber();
            txtNoBukti.Text = numberPayment;
            comboType.Focus();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtNoBukti.Focus();
            txtNoBukti.ReadOnly = false;
            ShowFloatingGrid(txtNoBukti, dataGridPayment, new Size(500, 200));
        }

        private async Task SelectBillFromRow(DataGridViewRow row)
        {
            if (row != null && row.Index >= 0)
            {
                _selectedBillId = Convert.ToInt32(row.Cells[0].Value?.ToString() ?? "0");
                dateTimeNota.Text = row.Cells[1].Value?.ToString() ?? "";
                string billName = row.Cells[2].Value?.ToString() ?? "";
                txtNoNota.Text = billName;
                txtTotalNota.Text = row.Cells[3].Value?.ToString() ?? "";

                float totalAkumulasi = await GetAccumulatedPaymentForBill(billName);
                txtTotalBayar.Text = totalAkumulasi.ToString("N0");

                float.TryParse(txtTotalNota.Text?.Replace(".", "").Replace(",", ""), out float totalTagihan);
                float sisa = totalTagihan - totalAkumulasi;
                txtJumBayar.Text = sisa > 0 ? sisa.ToString("N0") : "0";
            }

            popUpContainer?.Close();
            txtJumBayar.Focus();
            txtJumBayar.SelectAll();
        }

        private async void dataGridBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                await SelectBillFromRow(dataGridBill.CurrentRow);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                popUpContainer?.Close();
            }
        }

        private async void dataGridBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridBill.Rows.Count)
            {
                await SelectBillFromRow(dataGridBill.Rows[e.RowIndex]);
            }
        }

        private async void btnSaveDetail_Click(object sender, EventArgs e)
        {
            string noBukti = txtNoBukti.Text?.Trim();
            if (string.IsNullOrWhiteSpace(noBukti))
            {
                MessageBox.Show("Nomor bukti tidak boleh kosong!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTotalNota.Text == txtTotalBayar.Text && !isEditMode)
            {
                MessageBox.Show("Pembayaran Nota tersebut sudah selesai. Silahkan Pilih Nota lain!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (comboType.SelectedIndex == -1 && string.IsNullOrWhiteSpace(comboType.Text))
            {
                MessageBox.Show("Type Pembayaran tidak boleh kosong!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboType.Focus();
                return;
            }
           
            if (_selectedBillId <= 0)
            {
                MessageBox.Show("Silakan pilih Nota Tagihan (Bill) terlebih dahulu!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Bersihkan format ribuan/titik/koma sebelum parse
            string rawAmount = txtJumBayar.Text.Replace(".", "").Replace(",", "").Replace("Rp", "").Trim();
            if (!float.TryParse(rawAmount, out float amount) || amount <= 0)
            {
                MessageBox.Show("Nominal pembayaran tidak valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float.TryParse(txtTotalNota.Text.Replace(".", "").Replace(",", ""), out float totalNota);
            float.TryParse(txtTotalBayar.Text.Replace(".", "").Replace(",", ""), out float totalBayar);
            float sisaTagihan = totalNota - totalBayar;
            if (!isEditMode && sisaTagihan > 0 && amount > sisaTagihan)
            {
                var dialogResult = MessageBox.Show(
                    $"Jumlah bayar (Rp {amount:N0}) melebihi sisa tagihan (Rp {sisaTagihan:N0}). Apakah Anda yakin ingin melanjutkan?",
                    "Konfirmasi Pembayaran",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            var detail = new PaymentLineRequest
            {
                vendor_payment_id = noBukti,
                date_nota = dateTimeNota.Value,
                date_payment = datePickerPayment.Value,
                vendor_id = txtVendorId.Text,
                bill_id = _selectedBillId,
                amount = amount,
                type_payment = comboType.SelectedItem?.ToString() ?? comboType.Text,
            };

            try
            {
                btnSaveDetail.Enabled = false;

                if (isEditMode && selectedRowIndex >= 0)
                {
                    var row = dataGridListBill.Rows[selectedRowIndex];
                    string oldBill = row.Cells[0].Value?.ToString();
                    await vps.UpdateLine(noBukti, oldBill, detail);
                    MessageBox.Show("Line berhasil diupdate!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await vps.AddLine(noBukti, detail);
                    MessageBox.Show("Payment line successfully created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadPayment();
                HitungTotalPembayaran();
                ClearDetailFields();
                headerCreated = true;
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

        private void comboType_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                datePickerPayment.Focus();
            }
        }

        private void datePickerPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtVendorId.Focus();
            }
        }

        private async void txtNoBukti_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                ShowFloatingGrid(txtNoBukti, dataGridPayment, new Size(500, 200));
            }

            else if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                await LoadPayment();
            }
        }

        private void txtJumBayar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSaveDetail.Focus();
            }
        }

        private async Task SelectPaymentFromGrid(DataGridViewRow row)
        {
            if (row != null && row.Index >= 0)
            {
                txtNoBukti.Text = row.Cells[0].Value?.ToString() ?? "";
                if (DateTime.TryParse(row.Cells[1].Value?.ToString(), out DateTime dtPayment))
                {
                    datePickerPayment.Value = dtPayment;
                }
                comboType.Text = row.Cells[5].Value?.ToString() ?? "";
                txtVendorId.Text = row.Cells[2].Value?.ToString() ?? "";
                txtVendorName.Text = row.Cells[3].Value?.ToString() ?? "";
            }

            popUpContainer?.Close();
            await LoadPayment();
        }

        private async void dataGridPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                await SelectPaymentFromGrid(dataGridPayment.CurrentRow);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                popUpContainer?.Close();
            }
        }

        private async void dataGridPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridPayment.Rows.Count)
            {
                await SelectPaymentFromGrid(dataGridPayment.Rows[e.RowIndex]);
            }
        }

        private async void dataGridListBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridListBill.Rows.Count)
            {
                selectedRowIndex = e.RowIndex;
                isEditMode = true;

                var row = dataGridListBill.Rows[e.RowIndex];
                string billName = row.Cells[0].Value?.ToString() ?? "";
                txtNoNota.Text = billName;
                if (DateTime.TryParse(row.Cells[1].Value?.ToString(), out DateTime dtBill))
                {
                    dateTimeNota.Value = dtBill;
                }
                txtTotalNota.Text = row.Cells[2].Value?.ToString() ?? "";
                txtTotalBayar.Text = row.Cells[3].Value?.ToString() ?? "";
                txtJumBayar.Text = row.Cells[4].Value?.ToString() ?? "";

                if (row.Tag != null && int.TryParse(row.Tag.ToString(), out int bId) && bId > 0)
                {
                    _selectedBillId = bId;
                }
                else if (!string.IsNullOrWhiteSpace(billName))
                {
                    try
                    {
                        var bill = await billService.GetBillByName(billName);
                        if (bill?.header != null)
                        {
                            _selectedBillId = bill.header.id;
                            row.Tag = _selectedBillId;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Failed to resolve bill id: {ex.Message}");
                    }
                }

                txtJumBayar.Focus();
                txtJumBayar.SelectAll();
            }
        }

        private async Task DeleteSelectedLine()
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= dataGridListBill.Rows.Count)
            {
                MessageBox.Show("Silakan pilih baris nota di tabel yang ingin dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dataGridListBill.Rows[selectedRowIndex];
            string billName = row.Cells[0].Value?.ToString() ?? "";
            string noBukti = txtNoBukti.Text?.Trim();

            if (string.IsNullOrWhiteSpace(noBukti))
            {
                MessageBox.Show("Nomor bukti pembayaran tidak valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Apakah Anda yakin ingin menghapus nota {billName} dari pembayaran ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    btnDeleteDetail.Enabled = false;
                    await vps.DeleteLine(noBukti, billName);
                    MessageBox.Show("Line pembayaran berhasil dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPayment();
                    ClearDetailFields();
                    HitungTotalPembayaran();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus line: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnDeleteDetail.Enabled = true;
                }
            }
        }

        private async void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            await DeleteSelectedLine();
        }

        private async void dataGridListBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (dataGridListBill.CurrentRow != null && dataGridListBill.CurrentRow.Index >= 0)
                {
                    selectedRowIndex = dataGridListBill.CurrentRow.Index;
                    await DeleteSelectedLine();
                }
            }
        }

        private void btnClearDetail_Click(object sender, EventArgs e)
        {
            ClearDetailFields();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string noBukti = txtNoBukti.Text?.Trim();
            if (string.IsNullOrWhiteSpace(noBukti))
            {
                MessageBox.Show("Nomor bukti pembayaran tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoBukti.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVendorId.Text))
            {
                MessageBox.Show("Supplier / Vendor tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVendorId.Focus();
                return;
            }

            if (comboType.SelectedIndex == -1 && string.IsNullOrWhiteSpace(comboType.Text))
            {
                MessageBox.Show("Tipe pembayaran tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboType.Focus();
                return;
            }

            if (dataGridListBill.Rows.Count == 0)
            {
                MessageBox.Show("Harap tambahkan minimal satu nota pembayaran pada daftar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HitungTotalPembayaran();

            float.TryParse(txtTotalPembayaran.Text.Replace(".", "").Replace(",", "").Trim(), out float totalAmt);

            var payment = new VendorPayment
            {
                name = noBukti,
                date_payment = datePickerPayment.Value,
                type_payment = comboType.SelectedItem?.ToString() ?? comboType.Text,
                vendor_id = txtVendorId.Text.Trim(),
                vendor_name = txtVendorName.Text.Trim(),
                total_amount = totalAmt.ToString()
            };

            try
            {
                btnSave.Enabled = false;
                await vps.UpdatePayment(noBukti, payment);
                MessageBox.Show("Pembayaran Vendor berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPaymentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan pembayaran: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}
