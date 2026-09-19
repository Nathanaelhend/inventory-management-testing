using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.models
{
    public class Product
    {
        public string pcode { get; set; }
        public string pName { get; set; }
        public int pQty { get; set; }
        public int pPrice { get; set; }
        public string pDescription { get; set; }
        public int pCategory { get; set; }
        public string catname { get; set; }
    }

    public class StockResponse
    {
        public int pQty { get; set; }
    }
}
