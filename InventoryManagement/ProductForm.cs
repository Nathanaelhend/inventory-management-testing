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
    public partial class ProductForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\IMS Program\dbMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            ProductModuleForm formProduct = new ProductModuleForm();
            formProduct.btnSave.Enabled = true;
            formProduct.btnUpdate.Enabled = false;
            formProduct.ShowDialog();
            LoadProduct();
        }

        private void LoadProduct()
        {
            int i = 0;
            dataGridProduct.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pName, pPrice, pDescription, pCategory) LIKE '%" + txtBoxSearch.Text +"%' ", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            con.Close();
            dr.Close();
        }

        private void dataGridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridProduct.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                ProductModuleForm productForm = new ProductModuleForm();
                productForm.lblProductId.Text = dataGridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productForm.txtProductName.Text = dataGridProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productForm.txtQty.Text = dataGridProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productForm.txtPrice.Text = dataGridProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productForm.txtDesc.Text = dataGridProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productForm.comboBoxCategory.Text = dataGridProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                productForm.btnSave.Enabled = false;
                productForm.btnUpdate.Enabled = true;
                productForm.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "Deleted Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tbProduct WHERE pId LIKE '" + dataGridProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been successfully deleted!");
                }
            }
            LoadProduct();
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
