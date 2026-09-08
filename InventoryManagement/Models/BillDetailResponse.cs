using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class BillDetailResponse
    {
        public VendorBill header { get; set; }
        public BillLine lines { get; set; }
    }

    public class BillLine
    {
        public int id { get; set; }
        public string product_id { get; set; }
        public float qty { get; set; }
        public float price { get; set; }
        public float total {  get; set; }
        public string state { get; set; }
        public int bill_id { get; set; }
    }
}
