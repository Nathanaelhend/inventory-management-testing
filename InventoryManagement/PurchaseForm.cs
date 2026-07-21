using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class PurchaseForm : Form
    {
        PurchaseService purchaseService = new PurchaseService();

        public PurchaseForm()
        {
            InitializeComponent();
            LoadPO();
        }

        public async Task LoadPO()
        {
            dataGridOrder.Rows.Clear();

            try
            {
                var purchase = await purchaseService.GetPurchase();
                int i = 0;

                foreach (var pr in purchase)
                {
                    i++;
                    dataGridOrder.Rows.Add(pr.noOrder, pr.odate.ToShortDateString(), pr.vendor, pr.netAmount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PurchaseModuleForm moduleForm = new PurchaseModuleForm();
            moduleForm.btnCreate.Enabled = true;
            moduleForm.ShowDialog();
        }

        //private void dataGridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string colName = dataGridOrder.Columns[e.ColumnIndex].Name;
        //    if (colName == "Edit")
        //    {
        //        OrderModuleForm formModule = new OrderModuleForm();
        //        formModule.lblOid.Text = dataGridOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
        //        formModule.dateTimePickerOrder.Text = dataGridOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
        //        formModule.txtProductId.Text = dataGridOrder.Rows[e.RowIndex].Cells[3].Value.ToString();
        //        formModule.txtCustId.Text = dataGridOrder.Rows[e.RowIndex].Cells[4].Value.ToString();
        //        formModule.numericQty.Value = Convert.ToInt32(dataGridOrder.Rows[e.RowIndex].Cells[5].Value.ToString());
        //        formModule.txtPrice.Text = dataGridOrder.Rows[e.RowIndex].Cells[6].Value.ToString();

        //        formModule.btnCreate.Enabled = false;
        //        formModule.btnUpdate.Enabled = true;
        //        formModule.ShowDialog();
        //    }
        //    if (colName == "Delete")
        //    {
        //        if (MessageBox.Show("Are you sure you want to delete this order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            con.Open();
        //            cmd = new SqlCommand("DELETE FROM tbOrder WHERE orderId LIKE '" + dataGridOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //            MessageBox.Show("Record has been successfully deleted!");

        //            cmd = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dataGridOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
        //            cmd.Parameters.AddWithValue("@pqty", Convert.ToInt32(dataGridOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    //LoadOrder();
        //}
    }
}
