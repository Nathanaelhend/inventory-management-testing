using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagement
{
    public partial class CategoryForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\IMS Program\dbMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public CategoryForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        private void LoadCategory()
        {
            int i = 0;
            dataGridCategory.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbCategory", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridCategory.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            con.Close();
            dr.Close();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            CategoryModuleForm categoryModule = new CategoryModuleForm();
            categoryModule.btnSave.Enabled = true;
            categoryModule.btnUpdate.Enabled = false;
            categoryModule.ShowDialog();
        }

        private void dataGridCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridCategory.Columns[e.ColumnIndex].Name;

            if(colName == "Edit")
            {
                CategoryModuleForm catForm = new CategoryModuleForm();
                catForm.lblCatId.Text = dataGridCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                catForm.txtName.Text = dataGridCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                catForm.btnSave.Enabled = false;
                catForm.btnUpdate.Enabled = true;
                catForm.ShowDialog();
            }
            else if(colName == "Delete")
            {
                if(MessageBox.Show("Are you sure want to delete this record?", "Deleted Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE '" + dataGridCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'",con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Category has been successfully deleted!");
                }
            }
            LoadCategory();
        }
    }
}