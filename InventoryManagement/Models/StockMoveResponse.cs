using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class StockMoveCreateResponse
    {
        public string message { get; set; }
        public StockMove data { get; set; }
    }

    public class StockMoveData
    {
        public int move_id { get; set; }
        public int line_id { get; set; }
    }
}
