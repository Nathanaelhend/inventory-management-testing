using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public class Purchase
    {
        public string noOrder { get; set; }
        public DateTime odate { get; set; }
        public string vendor { get; set; }
        public float jumlah { get; set; }
        public float discPrs { get; set; }
        public float discRph { get; set; }
        public float dpp { get; set; }
        public float ppnPrs { get; set; }
        public float ppnRph { get; set; }
        public float netAmount { get; set; }
        public string state { get; set; }

        public List<PurchaseLine> lines { get; set; } = new List<PurchaseLine>();
    }

    public class PurchaseLine
    {
        public string prCode { get; set; }
        public string pName { get; set; }
        public float qty { get; set; }
        public float jumlah { get; set; }
        public float pPrice { get; set; }
        public float discPrs { get; set; }
        public float discRph { get; set; }
        public float total { get; set; }
        public string purchaseNo { get; set; }
    }

    public class PurchaseLineRequest
    {
        public DateTime prDate { get; set; }
        public string prCode { get; set; }
        public float pPrice { get; set; }
        public float qty { get; set; }
        public float jumlah { get; set; }
        public float discPrs { get; set; }
        public float discRph { get; set; }
        public float total { get; set; }
        public string vendor { get; set; }
        public string state { get; set; }
    }

    public class PurchaseResponse
    {
        public string status { get; set; }
        public List<Purchase> data { get; set; }
    }

    public class PurchaseDetailResponse
    {
        public Purchase header { get; set; }
        public List<PurchaseLine> lines { get; set; }
    }
}