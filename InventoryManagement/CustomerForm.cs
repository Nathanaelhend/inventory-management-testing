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
    public partial class CustomerForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\IMS Program\dbMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dataGridCustomer.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbCustomer", con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dataGridCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerModuleForm custForm = new CustomerModuleForm();
            custForm.btnSave.Enabled = true;
            custForm.btnUpdate.Enabled = false;
            custForm.ShowDialog();
            LoadCustomer();
        }

        private void dataGridCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridCustomer.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                CustomerModuleForm customerModule = new CustomerModuleForm();
                customerModule.lblCId.Text = dataGridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                customerModule.txtName.Text = dataGridCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                customerModule.txtPhone.Text = dataGridCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                customerModule.btnSave.Enabled = false;
                customerModule.btnUpdate.Enabled = true;
                customerModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this customer?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbCustomer where cid LIKE '" + dataGridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been Successfully deleted!");
                }
            }
            LoadCustomer();
        }
    }
}
