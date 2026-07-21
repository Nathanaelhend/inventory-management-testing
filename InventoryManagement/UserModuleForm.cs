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

namespace InventoryManagement
{
    public partial class UserModuleForm : Form
    {

        public UserModuleForm()
        {
            InitializeComponent();
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
