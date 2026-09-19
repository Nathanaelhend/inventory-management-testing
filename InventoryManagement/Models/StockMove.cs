using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class StockMove
    {
        public string name { get; set; }
        public string mref { get; set; }
        public string @ref { get; set; }
        public string state { get; set; }
        public string type { get; set; }

        public List<StockMoveLine> lines { get; set; } = new List<StockMoveLine>();
    }

    public class StockMoveLine
    {
        public int id { get; set; }
        public string pcode { get; set; }
        public string pName { get; set; }
        public float qty { get; set; }
        public float qty_real { get; set; }
        public string @ref { get; set; }
        public string type_line { get; set; }
        public int move_id { get; set; }
        public string state { get; set; }
    }

    public class StockMoveResponse
    {
        public string status { get; set; }
        public List<StockMove> data { get; set; } = new List<StockMove>();
    }

    public class StockMoveDetailResponse
    {
        public StockMove header { get; set; }
        public List<StockMoveLine> lines { get; set; } = new List<StockMoveLine>();
    }
}
