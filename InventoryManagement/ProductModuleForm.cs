using InventoryManagement.models;
using System;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class ProductModuleForm : Form
    {
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        private async void LoadCategory()
        {
            comboBoxCategory.Items.Clear();

            try
            {
                CategoryService service = new CategoryService();
                var categories = await service.GetCategories();

                foreach (var cat in categories)
                {
                    comboBoxCategory.Items.Add(new ComboboxItem
                    {
                        Text = cat.catname,
                        Value = cat.catid,
                    });
                }

                if (comboBoxCategory.Items.Count > 0)
                    comboBoxCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load categories: " + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Clear()
        {
            txtCode.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtDesc.Clear();
            txtQty.Clear();

            if (comboBoxCategory.Items.Count > 0)
            {
                comboBoxCategory.SelectedIndex = 0;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this record?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var category = (ComboboxItem)comboBoxCategory.SelectedItem;

                    Product product = new Product
                    {
                        pcode = txtCode.Text,
                        pName = txtProductName.Text,
                        pQty = 0,
                        pPrice = Convert.ToInt32(txtPrice.Text),
                        pDescription = txtDesc.Text,
                        pCategory = (int)category.Value
                    };

                    ProductService service = new ProductService();
                    await service.AddProduct(product);

                    MessageBox.Show("Product successfully saved!");
                    Clear();
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
                if (string.IsNullOrWhiteSpace(txtCode.Text) ||
                    string.IsNullOrWhiteSpace(txtProductName.Text) ||
                    string.IsNullOrWhiteSpace(txtQty.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text) ||
                    comboBoxCategory.SelectedItem == null)
                    {
                        MessageBox.Show("Please fill all required fields!", "Validation Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                if (MessageBox.Show("Are you sure want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var category = (ComboboxItem)comboBoxCategory.SelectedItem;

                    Product product = new Product
                    {
                        pcode = txtCode.Text,
                        pName = txtProductName.Text,
                        pQty = Convert.ToInt32(txtQty.Text),
                        pPrice = Convert.ToInt32(txtPrice.Text),
                        pDescription = txtDesc.Text,
                        pCategory = (int)category.Value
                    };

                    ProductService service = new ProductService();
                    await service.UpdateProduct(product.pcode, product);
                    MessageBox.Show("Update Successfully");
                    this.Close();
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Update failed: " + ex.Message);
                }
        }
    }
}
