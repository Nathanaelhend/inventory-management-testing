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
    public partial class StockMoveForm : Form
    {
        private readonly StockMoveService _stockMoveService = new StockMoveService();

        public StockMoveForm()
        {
            InitializeComponent();
            LoadStockMove();
        }

        private async Task LoadStockMove()
        {
            dataGridSM.Rows.Clear();
            try
            {
                var stockMoves = await _stockMoveService.GetStockMove();

                foreach (var stockMove in stockMoves)
                {
                    dataGridSM.Rows.Add(
                        stockMove.name,
                        stockMove.type,
                        stockMove.@ref
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
