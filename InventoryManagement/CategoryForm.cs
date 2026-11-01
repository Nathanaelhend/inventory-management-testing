using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class CategoryForm : Form
    {
        CategoryService categoryService = new CategoryService();

        public CategoryForm()
        {
            InitializeComponent();
            UITheme.ApplyGridStyle(dataGridCategory);
            UITheme.StylePrimaryButton(btnAddCategory);
            LoadCategory();
        }

        private void panelTopBar_Paint(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Pen pen = new System.Drawing.Pen(UITheme.Border, 1))
            {
                e.Graphics.DrawLine(pen, 0, panelTopBar.Height - 1, panelTopBar.Width, panelTopBar.Height - 1);
            }
        }

        private async Task LoadCategory()
        {
            dataGridCategory.Rows.Clear();

            try
            {
                var categories = await categoryService.GetCategories();

                foreach(var cat in categories)
                {
                    dataGridCategory.Rows.Add(cat.catid, cat.catname);
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            CategoryModuleForm categoryModule = new CategoryModuleForm();
            categoryModule.btnSave.Enabled = true;
            categoryModule.btnUpdate.Enabled = false;
            categoryModule.ShowDialog();
        }

        private async void dataGridCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridCategory.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                CategoryModuleForm catForm = new CategoryModuleForm();
                catForm.lblCatId.Text = dataGridCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                catForm.txtName.Text = dataGridCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                catForm.btnSave.Enabled = false;
                catForm.btnUpdate.Enabled = true;

                catForm.ShowDialog();
                LoadCategory();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure want to delete this record?",
                    "Deleted Record",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int catId = Convert.ToInt32(
                        dataGridCategory.Rows[e.RowIndex].Cells[1].Value);

                    CategoryService service = new CategoryService();
                    await service.DeleteCategory(catId);

                    MessageBox.Show("Deleted!");
                    LoadCategory();
                }
            }
        }
    }
}