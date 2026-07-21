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
    public partial class OrderModuleForm : Form
    {
        int selectedRowIndex = -1;
        bool isEditMode = false;
        MySqlCommand cmd;
        MySqlConnection con;
        MySqlDataReader dr;

        int qty = 0;

        public OrderModuleForm()
        {
            InitializeComponent();
            con = DbConnection.GetConnection();
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

            try
            {
                string query = "SELECT * FROM tbpartner WHERE cType = 'Customer' AND CONCAT(ccode, cname) LIKE @search ORDER BY sequence";

                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + txtCust.Text + "%");
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridCustomer.Rows.Add(dr[1].ToString(), dr[2].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadProduct()
        {
            int i = 0;
            dataGridProduct.Rows.Clear();

            try
            {
                string query = @"
                SELECT 
                    p.pcode,
                    p.pName,
                    p.pQty,
                    p.pPrice,
                    p.pDescription,
                    c.catname AS Category
                FROM tbproduct p
                LEFT JOIN tbcategory c ON p.pCategory = c.catid
                WHERE CONCAT(p.pName, p.pDescription) LIKE @search";

                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + txtProduct.Text + "%");
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridProduct.Rows.Add(
                    dr["pcode"].ToString(),
                    dr["pName"].ToString(),
                    dr["pQty"].ToString(),
                    dr["pPrice"].ToString(),
                    dr["pDescription"].ToString(),
                    dr["Category"].ToString()
                    );
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private bool ValidateOrderDetail()
        {
            bool valid = true;

            // No Order
            errorProvider1.SetError(
                txtBoxNoOrder,
                string.IsNullOrWhiteSpace(txtBoxNoOrder.Text)
                    ? "Order number is required"
                    : ""
            );

            // Customer
            errorProvider1.SetError(
                txtCustId,
                string.IsNullOrWhiteSpace(txtCustId.Text)
                    ? "Customer is required"
                    : ""
            );

            // Product
            errorProvider1.SetError(
                txtProductId,
                string.IsNullOrWhiteSpace(txtProductId.Text)
                    ? "Product is required"
                    : ""
            );

            // Qty
            errorProvider1.SetError(
                numericQty,
                numericQty.Value <= 0
                    ? "Quantity must be greater than 0"
                    : ""
            );

            // Price
            errorProvider1.SetError(
                txtPrice,
                string.IsNullOrWhiteSpace(txtPrice.Text) || Convert.ToInt32(txtPrice.Text) <= 0
                    ? "Price must be greater than 0"
                    : ""
            );

            if (
                string.IsNullOrWhiteSpace(txtBoxNoOrder.Text) ||
                string.IsNullOrWhiteSpace(txtCustId.Text) ||
                string.IsNullOrWhiteSpace(txtProductId.Text) ||
                numericQty.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                Convert.ToInt32(txtPrice.Text) <= 0
            )
                valid = false;

            return valid;
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

            if(numericQty.Value <= 0)
            {
                errorProvider1.SetError(numericQty, "Please increase qty");
            }
            else
            {
                errorProvider1.SetError(numericQty, "");
            }
        }

        private void dataGridCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustId.Text = dataGridCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCustName.Text = dataGridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dataGridProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductId.Text = dataGridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = dataGridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dataGridProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            //qty = Convert.ToInt32(dataGridProduct.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

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
            string query = "SELECT pqty FROM tbproduct WHERE pcode like @search";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@search", txtProductId.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }
            con.Close();
            dr.Close();
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

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (selectedRowIndex < 0)
        //    {
        //        MessageBox.Show("Select item first!");
        //        return;
        //    }

        //    string noOrder = txtBoxNoOrder.Text;
        //    int productId = Convert.ToInt32(txtProductId.Text);
        //    int qtyToReturn = 0;

        //    using (SqlConnection cons = new SqlConnection(con.ConnectionString))
        //    {
        //        cons.Open();

        //        // 1. ambil qty dari database
        //        cmd = new SqlCommand(@"
        //        SELECT qty 
        //        FROM tbOrderLine 
        //        WHERE noOrder=@noOrder AND pid=@pid", cons);

        //        cmd.Parameters.AddWithValue("@noOrder", noOrder);
        //        cmd.Parameters.AddWithValue("@pid", productId);

        //        object result = cmd.ExecuteScalar();
        //        if (result != null)
        //            qtyToReturn = Convert.ToInt32(result);

        //        // 2. kembalikan stok
        //        cmd = new SqlCommand(@"
        //        UPDATE tbProduct 
        //        SET pqty = pqty + @qty 
        //        WHERE pid=@pid", cons);

        //        cmd.Parameters.AddWithValue("@qty", qtyToReturn);
        //        cmd.Parameters.AddWithValue("@pid", productId);
        //        cmd.ExecuteNonQuery();

        //        // 3. hapus baris orderline
        //        cmd = new SqlCommand(@"
        //        DELETE FROM tbOrderLine 
        //        WHERE noOrder=@noOrder AND pid=@pid", cons);

        //        cmd.Parameters.AddWithValue("@noOrder", noOrder);
        //        cmd.Parameters.AddWithValue("@pid", productId);
        //        cmd.ExecuteNonQuery();

        //        cons.Close();
        //    }

        //    // 4. hapus Row di grid
        //    dataGridOrderModule.Rows.RemoveAt(selectedRowIndex);
        //    selectedRowIndex = -1;
        //    isEditMode = false;

        //    ClearProduct();
        //}

        //private string GetProductName(int pid)
        //{
        //    using (SqlConnection cons = new SqlConnection(con.ConnectionString))
        //    {
        //        cons.Open();
        //        SqlCommand cmd = new SqlCommand(
        //            "SELECT pname FROM tbProduct WHERE pid=@pid", cons);
        //        cmd.Parameters.AddWithValue("@pid", pid);

        //        object result = cmd.ExecuteScalar();
        //        return result?.ToString() ?? "";
        //    }
        //}

        //private void LoadExistingOrder()
        //{
        //    string noOrder = txtBoxNoOrder.Text.Trim();
        //    if (noOrder == "") return;

        //    using (SqlConnection cons = new SqlConnection(con.ConnectionString))
        //    {
        //        cons.Open();

        //        // ============================================
        //        // 1. CEK ORDER HEADER ADA / TIDAK
        //        // ============================================
        //        SqlCommand cmd = new SqlCommand(
        //            "SELECT odate, customerId, total FROM tbOrder WHERE noOrder=@noOrder",
        //            cons
        //        );
        //        cmd.Parameters.AddWithValue("@noOrder", noOrder);

        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (!dr.HasRows)
        //        {
        //            // Order tidak ditemukan → clear grid
        //            dataGridOrderModule.Rows.Clear();
        //            dr.Close();
        //            cons.Close();
        //            return; // biarkan user membuat order baru
        //        }

        //        // Ada order → isi header
        //        if (dr.Read())
        //        {
        //            dateTimePickerOrder.Value = Convert.ToDateTime(dr["odate"]);
        //            txtCustId.Text = dr["customerId"].ToString();
        //        }
        //        dr.Close();

        //        // ============================================
        //        // 2. LOAD ORDER LINE KE GRIDVIEW
        //        // ============================================
        //        cmd = new SqlCommand(
        //            @"SELECT pid, qty, price, total 
        //          FROM tbOrderLine 
        //          WHERE noOrder=@noOrder", cons
        //        );
        //        cmd.Parameters.AddWithValue("@noOrder", noOrder);

        //        dr = cmd.ExecuteReader();

        //        dataGridOrderModule.Rows.Clear();

        //        while (dr.Read())
        //        {
        //            int pid = Convert.ToInt32(dr["pid"]);
        //            int qty = Convert.ToInt32(dr["qty"]);
        //            int price = Convert.ToInt32(dr["price"]);
        //            int total = Convert.ToInt32(dr["total"]);

        //            // ambil nama produk
        //            string name = GetProductName(pid);

        //            dataGridOrderModule.Rows.Add(pid, name, qty, price, total);
        //        }

        //        dr.Close();
        //        cons.Close();
        //    }
        //}

        private void txtBoxNoOrder_Leave(object sender, EventArgs e)
        {
            //LoadExistingOrder();
        }

        private void txtDiscPrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dpp = 0;
            double disc = 0;

            if (e.KeyChar == (char)Keys.Enter)
            {
                double.TryParse(txtDpp.Text, out dpp);
                double.TryParse(txtDiscPrs.Text, out disc);

                double discRph = (dpp * disc) / 100;
                lblDisc.Text = discRph.ToString();

                double finalPrice = double.Parse(txtDpp.Text) - double.Parse(lblDisc.Text);
                txtFinalPrice.Text = finalPrice.ToString();
                txtDiscPrs.Focus();
            }
        }

        private void txtPPn_KeyPress(object sender, KeyPressEventArgs e)
        {
            double priceAftDisc = 0;
            double ppn = 0;

            if(e.KeyChar == (char)Keys.Enter)
            {
                double.TryParse(lblDisc.Text, out priceAftDisc);
                double.TryParse(txtPPn.Text, out ppn);

                double ppnRph = (priceAftDisc * ppn) / 100;
                lblPPn.Text = ppnRph.ToString();

                double finalPrice = double.Parse(txtDpp.Text) - double.Parse(lblDisc.Text) + double.Parse(lblPPn.Text);
                txtFinalPrice.Text = finalPrice.ToString();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string noOrder = txtBoxNoOrder.Text;
            double dpp = double.Parse(txtDpp.Text);
            double discPrs = double.Parse(txtDiscPrs.Text);
            double discRph = double.Parse(lblDisc.Text);
            double ppnPrs = double.Parse(txtPPn.Text);
            double ppnRph = double.Parse(lblPPn.Text);
            double finalPrice = double.Parse(txtFinalPrice.Text);

            using (MySqlConnection cons = new MySqlConnection(con.ConnectionString))
            {
                cons.Open();
                cmd = new MySqlCommand(@"
                            UPDATE tbOrder SET dpp = @dpp, discPrs = @discPrs, discRph = @discRph, ppnPrs = @ppnPrs, ppnRph = @ppnRph, total = @finalPrice
                            WHERE noOrder=@noOrder", cons);
                cmd.Parameters.AddWithValue("@dpp", dpp);
                cmd.Parameters.AddWithValue("@discPrs", discPrs);
                cmd.Parameters.AddWithValue("@discRph", discRph);
                cmd.Parameters.AddWithValue("@ppnPrs", ppnPrs);
                cmd.Parameters.AddWithValue("@ppnRph", ppnRph);
                cmd.Parameters.AddWithValue("@finalPrice", finalPrice);
                cmd.Parameters.AddWithValue("@noOrder", noOrder);
                cmd.ExecuteNonQuery();

            }
            //GenerateJournal(noOrder, finalPrice);
            MessageBox.Show("Order Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OrderModuleForm_Load(object sender, EventArgs e)
        {
            HitungTotalGrid();
        }

        private void HitungTotalGrid()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridOrderModule.Rows)
            {
                if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "")
                {
                    total += Convert.ToDecimal(row.Cells[4].Value);
                }
            }

            txtDpp.Text = total.ToString();
        }

        private void dataGridOrderModule_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            HitungTotalGrid();
        }

        private void dataGridOrderModule_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            HitungTotalGrid();
        }

        private void dataGridOrderModule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            HitungTotalGrid();
        }

        private void txtBoxNoOrder_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtBoxNoOrder, string.IsNullOrWhiteSpace(txtBoxNoOrder.Text) ? "Order number is required" : "");
        }

        private void txtCustId_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCustId, string.IsNullOrWhiteSpace(txtCustId.Text) ? "Customer Id is required" : "");
        }

        private void txtCustName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCustName, string.IsNullOrWhiteSpace(txtCustName.Text) ? "Customer name is required" : "");
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtProductId, string.IsNullOrWhiteSpace(txtProductId.Text) ? "Product Id is required" : "");
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtProductName, string.IsNullOrWhiteSpace(txtProductName.Text) ? "Product name is required" : "");
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPrice, string.IsNullOrWhiteSpace(txtPrice.Text) ? "Product price is required" : "");
        }

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {
            if (!ValidateOrderDetail())
                return;

            string noOrder = txtBoxNoOrder.Text;
            string productId = txtProductId.Text;
            string name = txtProductName.Text;
            string customerId = txtCustId.Text;
            int qty = Convert.ToInt32(numericQty.Value);
            int price = Convert.ToInt32(txtPrice.Text);
            int total = Convert.ToInt32(txtTotal.Text);

            using (MySqlConnection cons = DbConnection.GetConnection())
            {
                cons.Open();
                MySqlTransaction trans = cons.BeginTransaction();

                try
                {
                    MySqlCommand cmd;

                    if (isEditMode && selectedRowIndex >= 0)
                    {
                        int oldQty = Convert.ToInt32(dataGridOrderModule.Rows[selectedRowIndex].Cells[2].Value);

                        int selisihQty = qty - oldQty;

                        //update stock
                        cmd = new MySqlCommand(
                        "UPDATE tbproduct SET pqty= pqty - @selisih WHERE pcode=@pcode", cons, trans);
                        cmd.Parameters.AddWithValue("@selisih", selisihQty);
                        cmd.Parameters.AddWithValue("@pcode", productId);
                        cmd.ExecuteNonQuery();

                        //UPDATE orderLine
                        cmd = new MySqlCommand(
                        "UPDATE tborderline SET qty=@qty,price=@price, total=@total WHERE noOrder=@noOrder AND ccode=@ccode", cons, trans);

                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@noOrder", noOrder);
                        cmd.Parameters.AddWithValue("@ccode", productId);
                        cmd.ExecuteNonQuery();

                        trans.Commit();

                        var row = dataGridOrderModule.Rows[selectedRowIndex];
                        row.Cells[2].Value = qty;
                        row.Cells[3].Value = price;
                        row.Cells[4].Value = total;

                        isEditMode = false;
                        selectedRowIndex = -1;
                        ClearProduct();
                        return;
                    }

                    //cek header order
                    cmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM tborder WHERE noOrder=@noOrder", cons, trans);
                    cmd.Parameters.AddWithValue("@noOrder", noOrder);
                    int orderExists = Convert.ToInt32(cmd.ExecuteScalar());

                    if (orderExists == 0)
                    {
                        cmd = new MySqlCommand(@"INSERT INTO tborder (noOrder,odate, customerId, dpp, discPrs, discRph, ppnPrs, ppnRph, total) VALUES (@noOrder, @odate, @cid,0,0,0,0,0,@total)", cons, trans);

                        cmd.Parameters.AddWithValue("@noOrder", noOrder);
                        cmd.Parameters.AddWithValue("@odate", dateTimePickerOrder.Value);
                        cmd.Parameters.AddWithValue("@cid", customerId);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.ExecuteNonQuery();
                    }

                    //update stock
                    cmd = new MySqlCommand("UPDATE tbproduct SET pqty= pqty - @qty WHERE pcode=@pcode", cons, trans);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@pcode", productId);
                    cmd.ExecuteNonQuery();

                    //order line
                    cmd = new MySqlCommand("SELECT COUNT(*) FROM tborderline WHERE noOrder=@noOrder AND ccode=@pcode", cons, trans);
                    cmd.Parameters.AddWithValue("@noOrder", noOrder);
                    cmd.Parameters.AddWithValue("@pcode", productId);

                    int exists = Convert.ToInt32(cmd.ExecuteScalar());

                    if (exists == 0)
                    {
                        cmd = new MySqlCommand(@"
                                INSERT INTO tborderline(odate,ccode,qty,price,total,noOrder) VALUES (@odate,@pid,@qty,@price,@total,@noOrder)", cons, trans);
                    }
                    else
                    {
                        cmd = new MySqlCommand(@"
                                UPDATE tborderline SET qty = qty + @qty,total = total + @total WHERE noOrder=@noOrder AND ccode=@pid", cons, trans);
                    }

                    cmd.Parameters.AddWithValue("@odate", dateTimePickerOrder.Value);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.Parameters.AddWithValue("qty", qty);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@noOrder", noOrder);
                    cmd.ExecuteNonQuery();
                    trans.Commit();

                    //update GRID
                    if (exists == 0)
                    {
                        dataGridOrderModule.Rows.Add(productId, name, qty, price, total);
                    }
                    else
                    {
                        foreach (DataGridViewRow r in dataGridOrderModule.Rows)
                        {
                            if (r.Cells[0].Value == productId)
                            {
                                r.Cells[2].Value = Convert.ToInt32(r.Cells[2].Value) + qty;
                                r.Cells[4].Value = Convert.ToInt32(r.Cells[4].Value) + total;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cons.Close();
                    LoadProduct();
                    ClearProduct();
                }

            }

        }

        //private void GenerateJournal(string noOrder, double finalPrice)
        //{
        //    int accountCash = 1;     // contoh id akun kas
        //    int accountSales = 2;    // contoh id akun penjualan

        //    using (SqlConnection cons = new SqlConnection(con.ConnectionString))
        //    {
        //        cons.Open();

        //        // 1. INSERT journal_entry
        //        SqlCommand cmdJE = new SqlCommand(@"
        //    INSERT INTO JournalEntry(date, reference, description, total_debit, total_credit, posted)
        //    VALUES(@date, @ref, @desc, @debit, @credit, 1);
        //    SELECT SCOPE_IDENTITY();
        //", cons);

        //        cmdJE.Parameters.AddWithValue("@date", DateTime.Now);
        //        cmdJE.Parameters.AddWithValue("@ref", noOrder);
        //        cmdJE.Parameters.AddWithValue("@desc", "Penjualan No Order " + noOrder);
        //        cmdJE.Parameters.AddWithValue("@debit", finalPrice);
        //        cmdJE.Parameters.AddWithValue("@credit", finalPrice);

        //        int journalEntryId = Convert.ToInt32(cmdJE.ExecuteScalar());

        //        // 2. INSERT Debit – Kas
        //        SqlCommand cmdDebit = new SqlCommand(@"
        //    INSERT INTO JournalItem(journal_entry_id, account_id, debit, credit, description)
        //    VALUES(@jeId, @acc, @debit, 0, @desc);
        //", cons);

        //        cmdDebit.Parameters.AddWithValue("@jeId", journalEntryId);
        //        cmdDebit.Parameters.AddWithValue("@acc", accountCash);
        //        cmdDebit.Parameters.AddWithValue("@debit", finalPrice);
        //        cmdDebit.Parameters.AddWithValue("@desc", "Penerimaan Kas Penjualan");
        //        cmdDebit.ExecuteNonQuery();

        //        // 3. INSERT Credit – Penjualan
        //        SqlCommand cmdCredit = new SqlCommand(@"
        //    INSERT INTO JournalItem(journal_entry_id, account_id, debit, credit, description)
        //    VALUES(@jeId, @acc, 0, @credit, @desc);
        //", cons);

        //        cmdCredit.Parameters.AddWithValue("@jeId", journalEntryId);
        //        cmdCredit.Parameters.AddWithValue("@acc", accountSales);
        //        cmdCredit.Parameters.AddWithValue("@credit", finalPrice);
        //        cmdCredit.Parameters.AddWithValue("@desc", "Pendapatan Penjualan");
        //        cmdCredit.ExecuteNonQuery();
        //    }
        //}

    }
}
