using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public class VendorBill
    {
        public int id { get; set; }
        public string name { get; set; } // Nomor Bill (e.g., BILL/0912/001)
        public DateTime date { get; set; }
        public DateTime date_edit { get; set; }
        public float jumlah { get; set; }
        public float discPrs { get; set; }
        public float discRph { get; set; }
        public float dpp { get; set; }
        public float ppnPrs { get; set; }
        public float ppnRph { get; set; }
        public float total { get; set; }
        public string vendor_id { get; set; }
        public string po_id { get; set;  }
        public string state { get; set; }
        public string move_id { get; set; } // Reference ke Stock Move (nameSM)

        public List<BillLine> lines { get; set; } = new List<BillLine>();
    }

    public class BillLine
    {
        public int id { get; set; }
        public string product_id { get; set; }
        public float qty { get; set; }
        public float qty_real { get; set; }
        public float price { get; set; }
        public float jumlah { get; set; }
        public float discPrs { get; set; }
        public float discRph { get; set; }
        public float total { get; set; }
        public int bill_id { get; set; }
    }

    // Untuk response berisikan list (misal: Halaman Index Vendor Bill)
    public class VendorBillResponse
    {
        public string status { get; set; }
        public List<VendorBill> data { get; set; } = new List<VendorBill>();
    }

    public class VendorBillDetailResponse
    {
        public string status { get; set; }
        public VendorBill header { get; set; }
        public List<BillLine> lines { get; set; } = new List<BillLine>();
    }
}