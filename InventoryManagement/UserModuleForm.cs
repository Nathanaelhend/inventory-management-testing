using InventoryManagement.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace InventoryManagement
{
    public partial class UserModuleForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public UserModuleForm()
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

        private void UserModuleForm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(UITheme.BorderDark, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void Clear()
        {
            txtUsername.Clear(); txtName.Clear(); txtPassword.Clear(); txtPhone.Clear(); txtRePass.Clear();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtRePass.Text)
                {
                    MessageBox.Show("Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure want to save this record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    User user = new User
                    {
                        fullname = txtName.Text,
                        username = txtUsername.Text,
                        phone = txtPhone.Text,
                        password = txtRePass.Text,
                    };

                    UserService service = new UserService();
                    await service.AddUser(user);

                    MessageBox.Show("User successfully saved!");
                    Clear();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed: " + ex.Message);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtUsername.Text) ||
                   string.IsNullOrWhiteSpace(txtName.Text) ||
                   string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(MessageBox.Show("Are you sure want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    User user = new User
                    {
                        id = lbliduser.Text,
                        username = txtUsername.Text,
                        fullname = txtName.Text,
                        phone = txtPhone.Text,
                        password = txtRePass.Text,
                    };
                    UserService service = new UserService();
                    await service.UpdateUser(user.id, user);
                    MessageBox.Show("User successfully updated!");
                    Clear();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }
    }
}
