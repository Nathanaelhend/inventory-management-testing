using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class StockMoveDetailResponse
    {
        public StockMoveHeader header { get; set; }
        public List<StockMoveLine> lines { get; set; }
    }

    public class StockMoveHeader
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string @ref { get; set; }
    }

    public class StockMoveLine
    {
        public int id { get; set; }
        public string pcode { get; set; }
        public string pName { get; set; }
        public int qty { get; set; }
        public int qty_real { get; set; }
        public string @ref { get; set; }
        public string type_line { get; set; }
        public int move_id { get; set; }
        public string state { get; set; }
    }
}