using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InventoryManagement
{
    public partial class ProductForm : Form
    {
        private readonly ProductService _productService = new ProductService();

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
            formProduct.txtQty.Enabled = false;
            LoadProduct();
        }

        private async Task LoadProduct()
        {
            dataGridProduct.Rows.Clear();

            try
            {
                var products = await _productService.GetProducts();

                foreach (var product in products)
                {
                    dataGridProduct.Rows.Add(
                        product.pcode,
                        product.pName,
                        product.pQty,
                        product.pPrice,
                        product.pDescription,
                        product.catname
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private async void dataGridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridProduct.Columns[e.ColumnIndex].Name;
            ProductModuleForm productForm = new ProductModuleForm();
            //string productId = dataGridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (colName == "Edit")
            {
                //productForm.lblProductId.Text = productId;
                productForm.txtCode.Enabled = false;
                productForm.txtQty.Enabled = false;
                productForm.txtCode.Text = dataGridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                productForm.txtProductName.Text = dataGridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productForm.txtQty.Text = dataGridProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productForm.txtPrice.Text = dataGridProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productForm.txtDesc.Text = dataGridProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productForm.comboBoxCategory.Text = dataGridProduct.Rows[e.RowIndex].Cells[5].Value.ToString();

                productForm.btnSave.Enabled = false;
                productForm.btnUpdate.Enabled = true;

                productForm.ShowDialog();

                await LoadProduct();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure want to delete this record?",
                    "Delete Record",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        await _productService.DeleteProduct(productForm.txtCode.Text);

                        MessageBox.Show("Product has been successfully deleted!");
                        await LoadProduct();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
