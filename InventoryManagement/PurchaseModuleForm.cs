using InventoryManagement.Models;
using MySql.Data.MySqlClient;
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
    public partial class PurchaseModuleForm : Form
    {
        int selectedRowIndex = -1;
        bool isEditMode = false;
        int qty = 0;

        private readonly PurchaseService purchaseService = new PurchaseService();
        private readonly ProductService productService = new ProductService();

        public PurchaseModuleForm()
        {
            InitializeComponent();
            LoadProduct();
            LoadVendor();
        }

        private async Task LoadVendor()
        {
            dataGridVendor.Rows.Clear();

            try
            {
                PartnerService service = new PartnerService();
                var vendor = await service.GetPartner();

                foreach (var v in vendor)
                {
                    if (v.cType == "Vendor")
                    {
                        dataGridVendor.Rows.Add(v.ccode, v.cname);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadProduct()
        {
            dataGridProduct.Rows.Clear();

            try
            {
               ProductService service = new ProductService();
               var product = await service.GetProducts();

                foreach (var pr in product)
                {
                    dataGridProduct.Rows.Add(pr.pcode, pr.pName, pr.pQty, pr.pPrice, pr.pDescription, pr.catname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ClearProduct()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            numericQty.Value = 0;
            txtTotal.Clear();
        }

        private bool ValidatePODetail()
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
                txtVendorId,
                string.IsNullOrWhiteSpace(txtVendorId.Text)
                    ? "Vendor is required"
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
                string.IsNullOrWhiteSpace(txtVendorId.Text) ||
                string.IsNullOrWhiteSpace(txtProductId.Text) ||
                numericQty.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                Convert.ToInt32(txtPrice.Text) <= 0
            )
                valid = false;

            return valid;
        }

        private void txtVendor_TextChanged(object sender, EventArgs e)
        {
            LoadVendor();
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        //private async Task GetQty()
        //{
        //    if (string.IsNullOrWhiteSpace(txtProductId.Text))
        //        return;

        //    try
        //    {
        //        qty = await productService.GetStock(txtProductId.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void dataGridPurchaseModule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedRowIndex = e.RowIndex;
            isEditMode = true;

            DataGridViewRow row = dataGridPurchaseModule.Rows[selectedRowIndex];

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

        //    using(MySqlConnection cons = new MySqlConnection(con.ConnectionString))
        //    {
        //        cons.Open();
        //        MySqlTransaction tran = cons.BeginTransaction();

        //        try
        //        {
        //            cmd = new MySqlCommand(@"
        //            SELECT qty FROM tbpurchaseline
        //            WHERE noOrder=@noOrder AND prCode=@pcode", cons,tran);

        //            cmd.Parameters.AddWithValue("@noOrder", noOrder);
        //            cmd.Parameters.AddWithValue("@pcode", productId);

        //            object result = cmd.ExecuteScalar();
        //            if(result == null)
        //            {
        //                throw new Exception("Item not found");
        //            }
        //            qtyToReturn = Convert.ToInt32(result);

        //            cmd = new MySqlCommand(@"
        //            UPDATE tbproduct SET pQty= pQty + @pqty WHERE pcode=@pcode", cons, tran);

        //            cmd.Parameters.AddWithValue("@pqty", qtyToReturn);
        //            cmd.Parameters.AddWithValue("@pcode", productId);
        //            cmd.ExecuteNonQuery();

        //            cmd = new MySqlCommand(@"
        //            DELETE FROM tbpurchaseline WHERE noOrder=@noOrder AND prCode=@prCode", cons, tran);
                    
        //            cmd.Parameters.AddWithValue("@noOrder", noOrder);
        //            cmd.Parameters.AddWithValue("@prCode", productId);
        //            cmd.ExecuteNonQuery();
        //            tran.Commit();
        //        }
        //        catch(Exception ex)
        //        {
        //            tran.Rollback();
        //            MessageBox.Show(ex.Message);
        //            return;
        //        }
        //    }


        //    dataGridPurchaseModule.Rows.RemoveAt(selectedRowIndex);
        //    selectedRowIndex = -1;
        //    isEditMode = false;
        //    ClearProduct();
        //}

        //private string GetProductName(int pid)
        //{
        //    using (MySqlConnection cons = new MySqlConnection(con.ConnectionString))
        //    {
        //        cons.Open();
        //        cmd = new MySqlCommand("SELECT pName FROM tbproduct WHERE pcode=@pcode", cons);
        //        cmd.Parameters.AddWithValue("@pcode", pid);
        //        object result = cmd.ExecuteScalar();
        //        return result?.ToString() ?? "";
        //    }
        //}

        //private void LoadExistingOrder()
        //{
        //    string noOrder = txtBoxNoOrder.Text.Trim();
        //    if (noOrder == "") return;

        //    using (MySqlConnection cons = new MySqlConnection(con.ConnectionString))
        //    {
        //        cons.Open();

        //        MySqlCommand cmd = new MySqlCommand(
        //            "SELECT odate, vendor FROM tbpurchaseorder WHERE noOrder=@noOrder", cons);
        //        cmd.Parameters.AddWithValue("@noOrder", noOrder);

        //        MySqlDataReader dr = cmd.ExecuteReader();

        //        if (!dr.Read())
        //        {
        //            dr.Close();
        //            cons.Close();
        //            return;
        //        }

        //        if (dr.Read())
        //        {
        //            dateTimePickerOrder.Value = Convert.ToDateTime(dr["odate"]);
        //            txtVendorId.Text = dr["customerId"].ToString();
        //        }
        //        dr.Close();
        //        cmd = new MySqlCommand(
        //            @"SELECT pCode, qty, price, total
        //            FROM tbpurchaseline
        //            WHERE noOrder=@noOrder", cons
        //        );
        //        cmd.Parameters.AddWithValue("@noOrder", noOrder);

        //        dr = cmd.ExecuteReader();

        //        dataGridPurchaseModule.Rows.Clear();

        //        while (dr.Read())
        //        {
        //            int pid = Convert.ToInt32(dr["pCode"]);
        //            int qty = Convert.ToInt32(dr["qty"]);
        //            int price = Convert.ToInt32(dr["price"]);
        //            int total = Convert.ToInt32(dr["total"]);

        //            string name = GetProductName(pid);

        //            dataGridPurchaseModule.Rows.Add(pid, name, qty, price, total);
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

                double discRph = (disc / 100) * dpp;
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

            if (e.KeyChar == (char)Keys.Enter)
            {
                double.TryParse(txtFinalPrice.Text, out priceAftDisc);
                double.TryParse(txtPPn.Text, out ppn);

                double ppnRph = (ppn / 100) * priceAftDisc;
                lblPPn.Text = ppnRph.ToString();

                double finalPrice = double.Parse(txtDpp.Text) - double.Parse(lblDisc.Text) + double.Parse(lblPPn.Text);
                txtFinalPrice.Text = finalPrice.ToString();
            }
        }

        private void PurchaseModuleForm_Load(object sender, EventArgs e)
        {
            HitungTotalGrid();
        }

        private void HitungTotalGrid()
        {
            decimal total = 0;
            foreach(DataGridViewRow row in dataGridPurchaseModule.Rows)
            {
                if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "")
                {
                    total += Convert.ToDecimal(row.Cells[4].Value);
                }
            }
            txtDpp.Text = total.ToString();
        }

        private void dataGridPurchaseModule_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            HitungTotalGrid();
        }

        private void dataGridPurchaseModule_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            HitungTotalGrid();
        }

        private void dataGridPurchaseModule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            HitungTotalGrid();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridVendor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVendorId.Text = dataGridVendor.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtVendorName.Text = dataGridVendor.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dataGridProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductId.Text = dataGridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = dataGridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dataGridProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private async void numericQty_ValueChanged(object sender, EventArgs e)
        {
            int qty = (int)numericQty.Value;

            if (qty <= 0)
            {
                errorProvider1.SetError(numericQty, "Please increase qty");
                txtTotal.Text = "0";
                return;
            }

            errorProvider1.SetError(numericQty, "");

            float price = 0;
            float.TryParse(txtPrice.Text, out price);

            float total = price * qty;

            txtTotal.Text = total.ToString();
        }

        private async void btnSaveDetail_Click(object sender, EventArgs e)
        {
            if (!ValidatePODetail())
                return;

            var detail = new PurchaseLineRequest
            {
                prDate = dateTimePickerOrder.Value,
                prCode = txtProductId.Text,
                pPrice = Convert.ToInt32(txtPrice.Text),
                qty = Convert.ToInt32(numericQty.Value),
                total = Convert.ToInt32(txtTotal.Text),
                vendor = txtVendorId.Text
            };

            try
            {
                await purchaseService.AddLine(txtBoxNoOrder.Text, detail);

                LoadProduct();
                ClearProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string noOrder = txtBoxNoOrder.Text;

            if (string.IsNullOrWhiteSpace(noOrder))
            {
                MessageBox.Show("No Order tidak boleh kosong!");
                return;
            }

            var purchase = new Purchase
            {
                odate = dateTimePickerOrder.Value,
                vendor = txtVendorId.Text,
                dpp = float.Parse(txtDpp.Text),
                discPrs = float.Parse(txtDiscPrs.Text),
                discRph = float.Parse(lblDisc.Text),
                ppnPrs = float.Parse(txtPPn.Text),
                ppnRph = float.Parse(lblPPn.Text),
                netAmount = float.Parse(txtFinalPrice.Text)
            };

            try
            {
                btnCreate.Enabled = false;

                await purchaseService.UpdatePurchase(noOrder, purchase);

                MessageBox.Show("Purchase berhasil disimpan!",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCreate.Enabled = true;
            }
        }

        //private void GenerateJournal(string noOrder, double finalPrice)
        //{
        //    int accountCash = 1;
        //    int accountPurchase = 3;

        //    using (SqlConnection cons = new SqlConnection(con.ConnectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmdJE = new SqlCommand(@"
        //        INSERT INTO JournalEntry (date, reference, description, total_debit, total_credit, posted)
        //        VALUES (@date, @ref, @desc, @debit, @credit,1);
        //        ", cons);
        //        cmdJE.Parameters.AddWithValue("@date", DateTime.Now);
        //        cmdJE.Parameters.AddWithValue("@ref", noOrder);
        //        cmdJE.Parameters.AddWithValue("@desc", "Purchase Order " + noOrder);
        //        cmdJE.Parameters.AddWithValue("@debit", finalPrice);
        //        cmdJE.Parameters.AddWithValue("@credit", finalPrice);

        //        int journalEntryId = Convert.ToInt32(cmdJE.ExecuteScalar());

        //        SqlCommand cmdDebit = new SqlCommand(@"
        //        INSERT INTO JournalItem (journal_entry_id, account_id, debit, credit, description)
        //        VALUES (@jeId, @acc, @debit, 0, @desc);
        //        ", cons);

        //        cmdDebit.Parameters.AddWithValue("@jeId", journalEntryId);
        //        cmdDebit.Parameters.AddWithValue("@acc", accountCash);
        //        cmdDebit.Parameters.AddWithValue("@debit", finalPrice);
        //        cmdDebit.Parameters.AddWithValue("@desc", "Penerimaan Kas Penjualan");
        //        cmdDebit.ExecuteNonQuery();

        //        SqlCommand cmdCredit = new SqlCommand(@"
        //        INSERT INTO JournalItem(journal_entry_id, account_id, debit, credit, description)
        //        VALUES (@jeId, @acc, 0, @credit, @desc);
        //        ", cons);
        //        cmdCredit.Parameters.AddWithValue("@jeId", journalEntryId);
        //        cmdCredit.Parameters.AddWithValue("@acc", accountPurchase);
        //        cmdCredit.Parameters.AddWithValue("@credit", finalPrice);
        //        cmdCredit.Parameters.AddWithValue("@desc", "Pembelian Barang");
        //        cmdCredit.ExecuteNonQuery();
        //    }
        //}
    }
}
