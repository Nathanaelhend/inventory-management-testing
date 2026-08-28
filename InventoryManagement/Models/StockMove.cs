using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class StockMove
    {
        public string mname { get; set; }
        public string pcode { get; set; }
        public int qty { get; set; }
        public int qty_real { get; set; }
        public string mref { get; set; }
        public string @ref { get; set; }
        public string type { get; set; }
        public string type_line { get; set; }
    }
}
