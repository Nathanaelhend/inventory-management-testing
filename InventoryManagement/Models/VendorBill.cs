using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public class VendorBill
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public DateTime date_edit { get; set; }
        public float ppn { get; set; }
        public float discount { get; set; }
        public float total { get; set; }
        public string vendor_id { get; set; }
        public string state { get; set; }

        public List<BillLine> lines { get; set; } = new List<BillLine>();
    }

    public class BillLine
    {
        public int id { get; set; }
        public string product_id { get; set; }
        public float qty { get; set; }
        public float price { get; set; }
        public float total { get; set; }
        public string state { get; set; }
        public int bill_id { get; set; }
    }

    public class VendorBillResponse
    {
        public string status { get; set; }
        public List<VendorBill> data { get; set; }
    }
}