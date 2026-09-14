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
    public partial class VendorBillForm : Form
    {
        private readonly BillService _billService = new BillService();

        public VendorBillForm()
        {
            InitializeComponent();
            LoadVendorBill();
        }

        private async Task LoadVendorBill()
        {
            dataGridBill.Rows.Clear();
            try
            {
                var vb = await _billService.GetBill();

                foreach (var vbill in vb)
                {
                    dataGridBill.Rows.Add(
                        vbill.name,
                        vbill.date,
                        vbill.total,
                        vbill.vendor_id,
                        vbill.state
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridBill.Columns[e.ColumnIndex].Name;
            string name = dataGridBill.Rows[e.RowIndex].Cells[0].Value?.ToString();

            //if(colName == "Edit")
            //{
            //    ReceiptDetailForm receiptDetail = new ReceiptDetailForm(name);
            //    receiptDetail.ShowDialog();
            //}
        }
    }
}
