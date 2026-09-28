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

                var header = response?.data?.header;

                if (response != null)
                {
                    comboType.Text = header.type_payment ?? "";
                    txtVendorId.Text = header.vendor_id ?? "";
                    txtVendorName.Text = header.vendor_name ?? "";
                    txtTotalPembayaran.Text = header.total_amount ?? "";
                    datePickerPayment.Value = header.date_payment;
                }

                var lines = response?.data?.lines ?? new List<PaymentLine>();

                dataGridListBill.SuspendLayout();

                foreach (var line in lines)
                {
                    dataGridListBill.Rows.Add
                    (
                        line.bill_name,
                        line.date_payment,
                        line.amount.ToString("N0"),
                        line.bill_total_amount.ToString("N0")
                    );
                }

                dataGridListBill.ResumeLayout();
                dataGridListBill.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to load payment line " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        pay.date_payment.ToShortDateString(),
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
                if (this.ActiveControl is Button || this.ActiveControl is DataGridView || this.ActiveControl == txtNoNota || this.ActiveControl == txtNoBukti)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void VendorPaymentForm_Load(object sender, EventArgs e)
        {
            dateTimeNota.Value = DateTime.Today;
            datePickerPayment.Value = DateTime.Today;

            SetupPopUpContainer();
            await LoadVendor();
            await LoadPaymentList();

            dataGridListBill.DefaultCellStyle.ForeColor = Color.Black;
            dataGridListBill.DefaultCellStyle.BackColor = Color.White;
            dataGridListBill.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridListBill.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;

            dataGridListBill.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridListBill.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
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
            try
            {
                var vendorBill = await billService.GetBillByVendorId(txtVendorId.Text);

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

        private async void txtNoNota_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                txtJumBayar.Focus();

            }
            else if(e.KeyCode == Keys.F5)
            {
                if(txtVendorId.Text == null)
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

        private async void btnNew_Click(object sender, EventArgs e)
        {
            var numberPayment = await vps.GeneratePaymentNumber();
            txtNoBukti.Text = numberPayment;

            comboType.Focus();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtNoBukti.Focus();
            txtNoBukti.ReadOnly = false;
            isEditMode = true;
        }

        private void dataGridBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(dataGridVendor.CurrentRow != null && dataGridVendor.CurrentRow.Index >= 0)
                {
                    _selectedBillId = Convert.ToInt32(dataGridBill.CurrentRow.Cells[0].Value?.ToString());
                    txtNoNota.Text = dataGridBill.CurrentRow.Cells[2].Value?.ToString();
                    dateTimeNota.Text = dataGridBill.CurrentRow.Cells[1].Value?.ToString();
                    txtTotalNota.Text = dataGridBill.CurrentRow?.Cells[3].Value?.ToString();
                    txtJumBayar.Text = dataGridBill.CurrentRow?.Cells[3].Value?.ToString();
                }

                popUpContainer?.Close();
                txtJumBayar.Focus();
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

            if (comboType.SelectedIndex == -1)
            {
                MessageBox.Show("Type Pembayaran tidak boleh kosong!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            var detail = new PaymentLineRequest
            {
                vendor_payment_id = noBukti,
                date_payment = datePickerPayment.Value,
                vendor_id = txtVendorId.Text,
                bill_id = _selectedBillId,
                amount = amount,
                type_payment = comboType.SelectedItem?.ToString(),
            };

            try
            {
                btnSaveDetail.Enabled = false;

                if (isEditMode && selectedRowIndex >= 0)
                {
                    var row = dataGridListBill.Rows[selectedRowIndex];
                    string oldBill = row.Cells[0].Value.ToString();
                    await vps.UpdateLine(noBukti, oldBill, detail);
                    MessageBox.Show("Line berhasil diupdate!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await vps.AddLine(noBukti, detail);
                    MessageBox.Show("Payment successfully created!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                isEditMode = false;
                headerCreated = true;

                // Reset input form detail
                txtJumBayar.Clear();
                _selectedBillId = 0;

                // Reload data lines dari backend (sekarang aman karena backend mengembalikan 200 OK)
                //await LoadPaymentLines();
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

        private void dataGridPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                if(dataGridPayment.CurrentRow != null && dataGridPayment.CurrentRow.Index >= 0)
                {
                    txtNoBukti.Text = dataGridPayment.CurrentRow.Cells[0].Value?.ToString();
                    datePickerPayment.Text = dataGridPayment.CurrentRow.Cells[1].Value?.ToString();
                    comboType.Text = dataGridPayment.CurrentRow.Cells[5].Value?.ToString();
                    txtVendorId.Text = dataGridPayment.CurrentRow.Cells[2].Value?.ToString();
                    txtVendorName.Text = dataGridPayment.CurrentRow.Cells[3].Value?.ToString();
                }

                popUpContainer?.Close();
            }
        }
    }
}
