using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public class VendorPayment
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date_payment { get; set; }
        public string type_payment { get; set; }
        public string vendor_id { get; set; }
        public string total_amount { get; set; }

        public List<PaymentLine> lines { get; set; } = new List<PaymentLine>();
    }

    public class PaymentLine
    {
        public int id { get; set; }

        public int vendor_payment_id { get; set; }
        public int bill_id { get; set; }
        public float amount { get; set; }
    }

    // Untuk response berisikan list (misal: Halaman Index Vendor Bill)
    public class VendorPaymentResponse
    {
        public string status { get; set; }
        public List<VendorPayment> data { get; set; } = new List<VendorPayment>();
    }

    public class VendorPaymentlDetailResponse
    {
        public VendorPayment header { get; set; }
        public List<PaymentLine> lines { get; set; } = new List<PaymentLine>();
    }
}