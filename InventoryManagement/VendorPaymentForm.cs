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

        VendorPaymentService vps = new VendorPaymentService();
        BillService billService = new BillService();

        private ToolStripDropDown popUpContainer;

        public VendorPaymentForm()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.ActiveControl is Button || this.ActiveControl is DataGridView || this.ActiveControl == txtNoNota)
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
            datePickerPayment.Value = DateTime.Today;
            dateTimeNota.Value = DateTime.Today;

            SetupPopUpContainer();
            await LoadVendor();
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
                        dataGridVendor.Rows.Add(v.ccode, v.cname);
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
                        vb.name,
                        vb.date.ToShortDateString(),
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

        private async void txtNoNota_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;


            }
            else if(e.KeyCode == Keys.F5)
            {
                await LoadBill();
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

            datePickerPayment.Focus();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtNoBukti.Focus();
            txtNoBukti.ReadOnly = false;
        }

        private void dataGridBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(dataGridVendor.CurrentRow != null && dataGridVendor.CurrentRow.Index >= 0)
                {
                    txtNoNota.Text = dataGridBill.CurrentRow.Cells[0].Value?.ToString();
                    dateTimeNota.Text = dataGridBill.CurrentRow.Cells[1].Value?.ToString();
                    txtTotalNota.Text = dataGridBill.CurrentRow?.Cells[2].Value?.ToString();
                    txtJumBayar.Text = dataGridBill.CurrentRow?.Cells[2].Value?.ToString();
                }

                popUpContainer?.Close();
                txtJumBayar.Focus();
            }
        }
    }
}
