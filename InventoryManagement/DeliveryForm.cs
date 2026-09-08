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
    public partial class DeliveryForm : Form
    {
        private readonly StockMoveService _stockMoveService = new StockMoveService();

        public DeliveryForm()
        {
            InitializeComponent();
            LoadStockMove();
        }

        private async Task LoadStockMove()
        {
            dataGridDO.Rows.Clear();
            try
            {
                var stockMoves = await _stockMoveService.GetStockMove();

                foreach (var stockMove in stockMoves)
                {
                    dataGridDO.Rows.Add(
                        stockMove.name,
                        stockMove.type,
                        stockMove.@ref,
                        stockMove.state
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridSM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridDO.Columns[e.ColumnIndex].Name;
            string name = dataGridDO.Rows[e.RowIndex].Cells[0].Value?.ToString();

            if(colName == "Edit")
            {
                ReceiptDetailForm receiptDetail = new ReceiptDetailForm(name);
                receiptDetail.ShowDialog();
            }
        }
    }
}
