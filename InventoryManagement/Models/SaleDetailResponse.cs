using InventoryManagement.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class SaleDetailResponse
    {
        public Sale header { get; set; }
        public List<SaleLine> lines { get; set; }
    }

    public class SaleLine
    {
        public string pcode { get; set; }
        public string pName { get; set; }
        public int qty { get; set; }
        public int price { get; set; }
        public int total { get; set; }
    }

    public class SaleLineRequest
    {
        public DateTime odate { get; set; }
        public string pcode { get; set; }
        public int price { get; set; }
        public int qty { get; set; }
        public int total { get; set; }
        public string customer { get; set; }
    }
}
