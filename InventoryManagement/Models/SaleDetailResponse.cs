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
        public string prCode { get; set; }
        public string pName { get; set; }
        public int qty { get; set; }
        public int pPrice { get; set; }
        public int total { get; set; }
    }

    public class SaleLineRequest
    {
        public DateTime prDate { get; set; }
        public string prCode { get; set; }
        public int pPrice { get; set; }
        public int qty { get; set; }
        public int total { get; set; }
        public string customer { get; set; }
    }
}
