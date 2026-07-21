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
    public partial class CategoryModuleForm : Form
    {
        public CategoryModuleForm()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtName.Clear();
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
                int id = Convert.ToInt32(lblCatId.Text);
                string name = txtName.Text;

                CategoryService service = new CategoryService();
                await service.UpdateCategory(id, name);

                MessageBox.Show("Category updated successfully");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to save this record?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Category category = new Category
                    {
                        catname = txtName.Text,
                    };

                    CategoryService service = new CategoryService();
                    await service.AddCategory(category);

                    MessageBox.Show("Category successfully saved!");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed: " + ex.Message);
            }
        }
    }
}
