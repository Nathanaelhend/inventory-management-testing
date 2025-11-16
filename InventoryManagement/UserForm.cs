using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\IMS Program\dbMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dataGridUser.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbUser", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridUser.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void dataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridUser.Columns[e.ColumnIndex].Name;
            if(colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.txtUsername.Text = dataGridUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtName.Text = dataGridUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtPassword.Text = dataGridUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPhone.Text = dataGridUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                
                userModule.btnSave.Enabled = false;
                userModule.btnUpdate.Enabled = true;
                userModule.txtUsername.Enabled = false;
                userModule.ShowDialog();
            }
            else if(colName == "Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this user?","Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbUser where username LIKE '" + dataGridUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            LoadUser();
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
