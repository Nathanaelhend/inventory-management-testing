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
            UITheme.ApplyGridStyle(dataGridDO);
            UITheme.StyleSecondaryButton(btnRefresh);
            LoadStockMove();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadStockMove();
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

        private async void dataGridSM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridDO.Columns[e.ColumnIndex].Name;
            string name = dataGridDO.Rows[e.RowIndex].Cells[0].Value?.ToString();

            if (colName == "Edit")
            {
                DeliveryDetailForm deliveryDetail = new DeliveryDetailForm(name);
                deliveryDetail.ShowDialog();
                await LoadStockMove();
            }
        }
    }
}
