using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagement.Models;

namespace InventoryManagement
{
    public partial class UserForm : Form
    {
        UserService userService = new UserService();

        public UserForm()
        {
            InitializeComponent();
            UITheme.ApplyGridStyle(dataGridUser);
            UITheme.StylePrimaryButton(btnAdd);
            LoadUser();
        }

        private void panelTopBar_Paint(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Pen pen = new System.Drawing.Pen(UITheme.Border, 1))
            {
                e.Graphics.DrawLine(pen, 0, panelTopBar.Height - 1, panelTopBar.Width, panelTopBar.Height - 1);
            }
        }

        public async Task LoadUser()
        {
            dataGridUser.Rows.Clear();

            try
            {
                var users = await userService.GetUsers();
                foreach (var user in users)
                {
                    dataGridUser.Rows.Add(
                        user.id,
                        user.username, 
                        user.fullname, 
                        user.password, 
                        user.phone
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void dataGridUser_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridUser.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                UserModuleForm userForm = new UserModuleForm();
                userForm.lbliduser.Text = dataGridUser.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                userForm.txtUsername.Text = dataGridUser.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                userForm.txtName.Text = dataGridUser.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                userForm.txtPhone.Text = dataGridUser.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "";
                userForm.btnSave.Enabled = false;
                userForm.btnUpdate.Enabled = true;

                userForm.ShowDialog();
                LoadUser();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure want to delete this record?",
                    "Deleted Record",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string userId = dataGridUser.Rows[e.RowIndex].Cells[0].Value?.ToString();

                    if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out int id))
                    {
                        UserService service = new UserService();
                        await service.DeleteUser(id);

                        MessageBox.Show("Deleted!");
                        LoadUser();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User ID");
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();
            LoadUser();
        }
    }
}
