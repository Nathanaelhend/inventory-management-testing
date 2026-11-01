using InventoryManagement.Models;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;
using System.Runtime.InteropServices;

namespace InventoryManagement
{
    public partial class CustomerModuleForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public CustomerModuleForm()
        {
            InitializeComponent();
            UITheme.StylePrimaryButton(btnSave);
            UITheme.StyleSecondaryButton(btnUpdate);
            UITheme.StyleSecondaryButton(btnClear);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(UITheme.Border, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panelCard.Width - 1, panelCard.Height - 1);
            }
        }

        private void CustomerModuleForm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(UITheme.BorderDark, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }

        private bool ValidateForm()
        {
            return
                (rbCustomer.Checked || rbVendor.Checked) &&
                !string.IsNullOrWhiteSpace(txtCustCode.Text) &&
                !string.IsNullOrWhiteSpace(txtName.Text);
        }

        private void ShowAllErrors()
        {
            ValidateType();

            errorProvider1.SetError(
                txtCustCode,
                string.IsNullOrWhiteSpace(txtCustCode.Text)
                    ? "Partner Code is required"
                    : ""
            );

            errorProvider1.SetError(
                txtName,
                string.IsNullOrWhiteSpace(txtName.Text)
                    ? "Partner name is required"
                    : ""
            );
        }

        private void Clear()
        {
            txtName.Clear();
            txtPhone.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string ccode = lblCId.Text;
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string cType = rbCustomer.Checked ? "Customer" : "Vendor";

                PartnerService service = new PartnerService();
                await service.UpdatePartner(ccode, name, phone, cType);

                MessageBox.Show("Update Successfully");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        private void lblCId_Click(object sender, EventArgs e)
        {

        }

        private void ValidateType()
        {
            errorProvider1.SetError(
                gbType,
                (!rbVendor.Checked && !rbCustomer.Checked)
                    ? "Please select partner type"
                    : ""
            );
        }

        private void rbVendor_CheckedChanged(object sender, EventArgs e)
        {
            ValidateType();
        }

        private void rbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            ValidateType();
        }

        private void txtCustCode_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(
                txtCustCode,
                string.IsNullOrWhiteSpace(txtCustCode.Text)
                    ? "Partner Code is required"
                    : ""
            );
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(
                txtName,
                string.IsNullOrWhiteSpace(txtName.Text)
                    ? "Partner name is required"
                    : ""
            );
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                ShowAllErrors();
                return;
            }
            string cType = rbCustomer.Checked ? "Customer" : "Vendor";

            try
            {
                Partner partner = new Partner
                {
                    ccode = txtCustCode.Text,
                    cname = txtName.Text,
                    cphone = txtPhone.Text,
                    cType = cType,
                };

                PartnerService service = new PartnerService();
                await service.AddPartner(partner);

                MessageBox.Show("Data Partner Successfully Saved!");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    MessageBox.Show(
                        $"Partner dengankode '{txtCustCode.Text} dan tipe '{cType} sudah ada.", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Save failed: " + ex.Message);
                }
            }
        }
    }
}
