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
    public partial class OrderForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\IMS Program\dbMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;

        public OrderForm()
        {
            InitializeComponent();
            //LoadOrder();
        }

        //public void LoadOrder()
        //{
        //    int i = 0;
        //    dataGridOrder.Rows.Clear();
        //    cmd = new SqlCommand("SELECT orderId, odate, O.pid, P.pname, O.cid, C.cname, qty,price,total FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid = C.cid JOIN tbProduct AS P ON O.pid = P.id", con);
        //    con.Open();
        //    dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        i++;
        //        dataGridOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
        //    }
        //    dr.Close();
        //    con.Close();
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm moduleForm = new OrderModuleForm();
            moduleForm.btnCreate.Enabled = true;
            moduleForm.ShowDialog();
        }

        private void dataGridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridOrder.Columns[e.ColumnIndex].Name;
            //if (colName == "Edit")
            //{
            //    OrderModuleForm formModule = new OrderModuleForm();
            //    formModule.lblOid.Text = dataGridOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    formModule.dateTimePickerOrder.Text = dataGridOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    formModule.txtProductId.Text = dataGridOrder.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    formModule.txtCustId.Text = dataGridOrder.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    formModule.numericQty.Value = Convert.ToInt32(dataGridOrder.Rows[e.RowIndex].Cells[5].Value.ToString());
            //    formModule.txtPrice.Text = dataGridOrder.Rows[e.RowIndex].Cells[6].Value.ToString();

            //    formModule.btnCreate.Enabled = false;
            //    formModule.btnUpdate.Enabled = true;
            //    formModule.ShowDialog();
            //}
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbOrder WHERE orderId LIKE '" + dataGridOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");

                    cmd = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dataGridOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt32(dataGridOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            //LoadOrder();
        }
    }
}
