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
    public partial class CustomerForm : Form
    {
        PartnerService partnerService = new PartnerService();

        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomer();
            
        }

        public async Task LoadCustomer()
        {
            dataGridCustomer.Rows.Clear();

            try
            {
                var partners = await partnerService.GetPartner();
                int i = 0;

                foreach (var partner in partners)
                {
                    i++;
                    dataGridCustomer.Rows.Add(i, partner.ccode, partner.cname, partner.cphone, partner.cType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerModuleForm custForm = new CustomerModuleForm();
            custForm.btnSave.Enabled = true;
            custForm.btnUpdate.Enabled = false;
            custForm.ShowDialog();
        }

        private async void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadCustomer();
        }

        private async void dataGridCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string colName = dataGridCustomer.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                CustomerModuleForm custForm = new CustomerModuleForm();
                custForm.lblCId.Text = dataGridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                custForm.txtCustCode.Text = dataGridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                custForm.txtName.Text = dataGridCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                custForm.txtPhone.Text = dataGridCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                string cType = dataGridCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();

                if(cType == "Customer")
                {
                    custForm.rbCustomer.Checked = true;
                }
                else
                {
                    custForm.rbVendor.Checked = true;
                }

                custForm.btnSave.Enabled = false;
                custForm.txtCustCode.Enabled = false;
                custForm.btnUpdate.Enabled = true;
                custForm.ShowDialog();

                await LoadCustomer();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "Deleted Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int partnerId = Convert.ToInt32(dataGridCustomer.Rows[e.RowIndex].Cells[1]);
                    PartnerService service = new PartnerService();
                    await service.DeletePartner(partnerId);

                    MessageBox.Show("Deleted!");
                    await LoadCustomer();
                }
            }
        }
    }
}
