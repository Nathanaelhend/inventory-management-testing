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
        private string name = null;

        public ReceiptDetailForm(string name)
        {
            InitializeComponent();
            //LoadExisting();
        }

        private async void ReceiptDetailForm_Load(object sender, EventArgs e)
        {
            //labelName.Text = name;
        }

        //public async Task LoadExisting()
        //{
        //    try
        //    {
        //        var detail = await stockMoveService.GetStockMoveByName(name);

        //        labelName.Text = detail?.data.name;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
