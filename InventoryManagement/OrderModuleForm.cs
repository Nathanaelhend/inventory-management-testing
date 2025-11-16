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
    public partial class OrderModuleForm : Form
    {
        int selectedRowIndex = -1;
        bool isEditMode = false;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\IMS Program\dbMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;

        public OrderModuleForm()
        {
            InitializeComponent();
            LoadProduct();
            LoadCustomer();
            dateTimePickerOrder.Value = DateTime.Now;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dataGridCustomer.Rows.Clear();
            cmd = new SqlCommand("SELECT cid,cname FROM tbCustomer WHERE CONCAT(cid,cname) LIKE '%" + txtCust.Text + "%'",con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void LoadProduct()
        {
            int i = 0;
            dataGridProduct.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pName, pPrice, pDescription, pCategory) LIKE '%" + txtProduct.Text + "%' ", con);
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

        private void txtCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void numericQty_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
            if (Convert.ToInt32(numericQty.Value) > qty)
            {
                MessageBox.Show("Instock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericQty.Value = numericQty.Value - 1;
                return;
            }
            else if (Convert.ToInt32(numericQty.Value) > 0)
            {
                int total = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(numericQty.Value);
                txtTotal.Text = total.ToString();
            }
        }

        private void dataGridCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustId.Text = dataGridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCustName.Text = dataGridCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dataGridProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductId.Text = dataGridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProductName.Text = dataGridProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dataGridProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            //qty = Convert.ToInt32(dataGridProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        //private void btnCreate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtCustId.Text == "")
        //        {
        //            MessageBox.Show("Please select customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (MessageBox.Show("Are you sure you want to save this order?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            foreach (DataGridViewRow row in dataGridOrderModule.Rows)
        //            {
        //                cmd = new SqlCommand("INSERT INTO tbOrder(odate,total) VALUES(@odate,@total)", con);
        //                cmd.Parameters.AddWithValue("@odate", dateTimePickerOrder.Value);
        //                cmd.Parameters.AddWithValue("@total", Convert.ToInt32(row.Cells["ptotal"].Value));
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //                MessageBox.Show("Order has been successfully created!");

        //                Clear();
        //                LoadProduct();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void Clear()
        {
            txtProductId.Clear();
            txtCustId.Clear();
            numericQty.Value = 0;
            txtPrice.Clear();
            txtTotal.Clear();
            txtCustName.Clear();
            txtProductName.Clear();
            dateTimePickerOrder.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void ClearProduct()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            numericQty.Value = 0;
            txtTotal.Clear();
        }
        
        private void GetQty()
        {
            cmd = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid ='" + txtProductId.Text + "'", con);

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }
            con.Close();
            dr.Close();
        }

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {
            string noOrder = txtBoxNoOrder.Text;
            int productId = Convert.ToInt32(txtProductId.Text);
            string name = txtProductName.Text;
            int customerId = Convert.ToInt32(txtCustId.Text);
            int qty = Convert.ToInt32(numericQty.Value);
            int price = Convert.ToInt32(txtPrice.Text);
            int total = Convert.ToInt32(txtTotal.Text);

            try
            {
                if (txtCustId.Text == "")
                {
                    MessageBox.Show("Please select customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection cons = new SqlConnection(con.ConnectionString))
                {
                    cons.Open();

                    // ============================================
                    // 1. MODE EDIT
                    // ============================================
                    if (isEditMode && selectedRowIndex >= 0)
                    {
                        // Ambil qty lama
                        int oldQty = Convert.ToInt32(
                            dataGridOrderModule.Rows[selectedRowIndex].Cells[2].Value);

                        int selisihQty = qty - oldQty;

                        // Update stok
                        cmd = new SqlCommand(@"
                        UPDATE tbProduct SET pqty = pqty - @selisih 
                        WHERE pid=@pid", cons);
                        cmd.Parameters.AddWithValue("@selisih", selisihQty);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        cmd.ExecuteNonQuery();

                        // Update order line
                        cmd = new SqlCommand(@"
                        UPDATE tbOrderLine 
                        SET qty=@qty, price=@price, total=@total 
                        WHERE noOrder=@noOrder AND pid=@pid", cons);

                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        cmd.Parameters.AddWithValue("@noOrder", noOrder);
                        cmd.ExecuteNonQuery();

                        // Update datagrid
                        var row = dataGridOrderModule.Rows[selectedRowIndex];
                        row.Cells[2].Value = qty;
                        row.Cells[3].Value = price;
                        row.Cells[4].Value = total;

                        MessageBox.Show("Item updated!");

                        cons.Close();
                        ClearProduct();
                        isEditMode = false;
                        selectedRowIndex = -1;
                        return;
                    }

                    // ============================================
                    // 2. CEK ORDER HEADER
                    // ============================================
                    cmd = new SqlCommand("SELECT COUNT(*) FROM tbOrder WHERE noOrder=@noOrder", cons);
                    cmd.Parameters.AddWithValue("@noOrder", noOrder);
                    int orderExists = (int)cmd.ExecuteScalar();

                    if (orderExists == 0)
                    {
                        cmd = new SqlCommand(@"
                        INSERT INTO tbOrder(noOrder,odate,customerId,total)
                        VALUES(@noOrder,@odate,@cid,@total)", cons);

                        cmd.Parameters.AddWithValue("@noOrder", noOrder);
                        cmd.Parameters.AddWithValue("@odate", dateTimePickerOrder.Value);
                        cmd.Parameters.AddWithValue("cid", customerId);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand(@"
                        UPDATE tbOrder SET total = total + @add 
                        WHERE noOrder=@noOrder", cons);
                        cmd.Parameters.AddWithValue("@add", total);
                        cmd.Parameters.AddWithValue("@noOrder", noOrder);
                        cmd.ExecuteNonQuery();
                    }

                    // ============================================
                    // 3. UPDATE STOCK (kurangi)
                    // ============================================
                    cmd = new SqlCommand(@"
                    UPDATE tbProduct SET pqty = pqty - @qty 
                    WHERE pid=@pid", cons);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.ExecuteNonQuery();

                    // ============================================
                    // 4. CEK ITEM ADA / TIDAK
                    // ============================================
                    cmd = new SqlCommand(@"
                    SELECT COUNT(*) FROM tbOrderLine 
                    WHERE noOrder=@noOrder AND pid=@pid", cons);
                    cmd.Parameters.AddWithValue("@noOrder", noOrder);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    int exists = (int)cmd.ExecuteScalar();

                    if (exists == 0)
                    {
                        // INSERT
                        cmd = new SqlCommand(@"
                        INSERT INTO tbOrderLine(odate,pid,qty,price,total,noOrder)
                        VALUES(@odate,@pid,@qty,@price,@total,@noOrder)", cons);
                    }
                    else
                    {
                        // UPDATE (tambah qty)
                        cmd = new SqlCommand(@"
                        UPDATE tbOrderLine 
                        SET qty = qty + @qty, 
                            total = total + @total
                        WHERE noOrder=@noOrder AND pid=@pid", cons);
                    }

                    cmd.Parameters.AddWithValue("@odate", dateTimePickerOrder.Value);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.Parameters.AddWithValue("@noOrder", noOrder);
                    cmd.ExecuteNonQuery();

                    // ============================================
                    // 5. UPDATE DATAGRID
                    // ============================================

                    if (exists == 0)
                    {
                        dataGridOrderModule.Rows.Add(productId, name, qty, price, total);
                    }
                    else
                    {
                        foreach (DataGridViewRow r in dataGridOrderModule.Rows)
                        {
                            if ((int)r.Cells[0].Value == productId)
                            {
                                r.Cells[2].Value = Convert.ToInt32(r.Cells[2].Value) + qty;
                                r.Cells[4].Value = Convert.ToInt32(r.Cells[4].Value) + total;
                                break;
                            }
                        }
                    }

                    cons.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ClearProduct();
        }

        private void dataGridOrderModule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            selectedRowIndex = e.RowIndex;
            isEditMode = true;

            DataGridViewRow row = dataGridOrderModule.Rows[e.RowIndex];

            txtProductId.Text = row.Cells[0].Value.ToString();
            txtProductName.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            numericQty.Value = Convert.ToInt32(row.Cells[2].Value);
            txtTotal.Text = row.Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Select item first!");
                return;
            }

            string noOrder = txtBoxNoOrder.Text;
            int productId = Convert.ToInt32(txtProductId.Text);
            int qtyToReturn = 0;

            using (SqlConnection cons = new SqlConnection(con.ConnectionString))
            {
                cons.Open();

                // 1. ambil qty dari database
                cmd = new SqlCommand(@"
                SELECT qty 
                FROM tbOrderLine 
                WHERE noOrder=@noOrder AND pid=@pid", cons);

                cmd.Parameters.AddWithValue("@noOrder", noOrder);
                cmd.Parameters.AddWithValue("@pid", productId);

                object result = cmd.ExecuteScalar();
                if (result != null)
                    qtyToReturn = Convert.ToInt32(result);

                // 2. kembalikan stok
                cmd = new SqlCommand(@"
                UPDATE tbProduct 
                SET pqty = pqty + @qty 
                WHERE pid=@pid", cons);

                cmd.Parameters.AddWithValue("@qty", qtyToReturn);
                cmd.Parameters.AddWithValue("@pid", productId);
                cmd.ExecuteNonQuery();

                // 3. hapus baris orderline
                cmd = new SqlCommand(@"
                DELETE FROM tbOrderLine 
                WHERE noOrder=@noOrder AND pid=@pid", cons);

                cmd.Parameters.AddWithValue("@noOrder", noOrder);
                cmd.Parameters.AddWithValue("@pid", productId);
                cmd.ExecuteNonQuery();

                cons.Close();
            }

            // 4. hapus Row di grid
            dataGridOrderModule.Rows.RemoveAt(selectedRowIndex);
            selectedRowIndex = -1;
            isEditMode = false;

            ClearProduct();
        }

        private string GetProductName(int pid)
        {
            using (SqlConnection cons = new SqlConnection(con.ConnectionString))
            {
                cons.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT pname FROM tbProduct WHERE pid=@pid", cons);
                cmd.Parameters.AddWithValue("@pid", pid);

                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";
            }
        }

        private void LoadExistingOrder()
        {
            string noOrder = txtBoxNoOrder.Text.Trim();
            if (noOrder == "") return;

            using (SqlConnection cons = new SqlConnection(con.ConnectionString))
            {
                cons.Open();

                // ============================================
                // 1. CEK ORDER HEADER ADA / TIDAK
                // ============================================
                SqlCommand cmd = new SqlCommand(
                    "SELECT odate, customerId, total FROM tbOrder WHERE noOrder=@noOrder",
                    cons
                );
                cmd.Parameters.AddWithValue("@noOrder", noOrder);

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.HasRows)
                {
                    // Order tidak ditemukan → clear grid
                    dataGridOrderModule.Rows.Clear();
                    dr.Close();
                    cons.Close();
                    return; // biarkan user membuat order baru
                }

                // Ada order → isi header
                if (dr.Read())
                {
                    dateTimePickerOrder.Value = Convert.ToDateTime(dr["odate"]);
                    txtCustId.Text = dr["customerId"].ToString();
                }
                dr.Close();

                // ============================================
                // 2. LOAD ORDER LINE KE GRIDVIEW
                // ============================================
                cmd = new SqlCommand(
                    @"SELECT pid, qty, price, total 
              FROM tbOrderLine 
              WHERE noOrder=@noOrder", cons
                );
                cmd.Parameters.AddWithValue("@noOrder", noOrder);

                dr = cmd.ExecuteReader();

                dataGridOrderModule.Rows.Clear();

                while (dr.Read())
                {
                    int pid = Convert.ToInt32(dr["pid"]);
                    int qty = Convert.ToInt32(dr["qty"]);
                    int price = Convert.ToInt32(dr["price"]);
                    int total = Convert.ToInt32(dr["total"]);

                    // ambil nama produk
                    string name = GetProductName(pid);

                    dataGridOrderModule.Rows.Add(pid, name, qty, price, total);
                }

                dr.Close();
                cons.Close();
            }
        }

        private void txtBoxNoOrder_Leave(object sender, EventArgs e)
        {
            LoadExistingOrder();
        }
    }
}
