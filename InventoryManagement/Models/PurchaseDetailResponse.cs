using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class PurchaseDetailResponse
    {
        public Purchase header {  get; set; }
        public List<PurchaseLine> lines { get; set; }
    }

    public class PurchaseLine
    {
        public string prCode { get; set; }
        public string pName { get; set; }
        public int qty { get; set; }
        public int pPrice { get; set; }
        public int total {  get; set; }
    }

    public class PurchaseLineRequest
    {
        public DateTime prDate { get; set; }
        public string prCode { get; set; }
        public int pPrice { get; set; }
        public int qty { get; set; }
        public int total { get; set; }
        public string vendor { get; set; }
        public string state { get; set; }
    }
}
