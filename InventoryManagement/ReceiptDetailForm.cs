using InventoryManagement.Models;
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
    public partial class ReceiptDetailForm : Form
    {
        private readonly StockMoveService stockMoveService = new StockMoveService();

        //penampung datagridview
        List<StockMoveLine> ml = new List<StockMoveLine>();
        private string nameSM = null;

        public ReceiptDetailForm(string name)
        {
            InitializeComponent();

            nameSM = name;
            labelName.Text = nameSM;
            LoadExisting();
        }

        private async void ReceiptDetailForm_Load(object sender, EventArgs e)
        {
            
        }

        public async Task LoadExisting()
        {
            try
            {
                var detail = await stockMoveService.GetStockMoveByName(nameSM);

                if(detail?.lines != null)
                {
                    dataGridReceipt.Rows.Clear();

                    foreach(var line in detail.lines)
                    {
                        dataGridReceipt.Rows.Add(
                            line.pcode,
                            line.pName,
                            line.qty,
                            line.qty_real,
                            line.@ref
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async Task btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(DataGridViewRow row in dataGridReceipt.Rows)
                {
                    var item = new StockMoveLine
                    {
                        pcode = row.Cells["pcode"].Value?.ToString(),
                        pName = row.Cells["pname"].Value?.ToString(),
                        qty = row.Cells["qty"].Value?.ToString(),
                        qty_real = row.Cells["qty_real"].Value?.ToString(),
                        @ref = row.Cells["ref"].Value?.ToString()
                    };

                    ml.Add(item);

                    await stockMoveService.
                }
            }
        }
    }
}
