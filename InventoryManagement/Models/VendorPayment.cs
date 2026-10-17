using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public class VendorPayment
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? date_payment { get; set; }
        public string type_payment { get; set; }
        public string vendor_id { get; set; }
        public string vendor_name { get; set; }
        public string total_amount { get; set; }

        public List<PaymentLine> lines { get; set; } = new List<PaymentLine>();
    }

    public class PaymentLine
    {
        public int id { get; set; }

        public string vendor_payment_id { get; set; }
        public int bill_id { get; set; }
        public string bill_name { get; set; }
        public DateTime? date_payment { get; set; }
        public DateTime? date_nota { get; set; }
        public DateTime? bill_date { get; set; }
        public DateTime? create_date { get; set; }
        public float amount { get; set; }
        public float bill_total_amount { get; set; } 
        public float total_paid_accumulated { get; set; }
    }

    public class PaymentLineRequest
    {
        public string vendor_payment_id { get; set; }
        public DateTime? date_payment { get; set; }
        public DateTime? date_nota { get; set; }
        public string vendor_id { get; set; }
        public int bill_id { get; set; }
        public float amount { get; set; }
        public string type_payment { get; set; }
    }

    public class VendorPaymentResponse
    {
        public string status { get; set; }
        public List<VendorPayment> data { get; set; } = new List<VendorPayment>();
    }

    public class VendorPaymentDetailResponse
    {
        public VendorPayment header { get; set; }
        public VendorPaymentDetailData data { get; set; }
    }

    public class VendorPaymentDetailData
    {
        public VendorPayment header { get; set; }
        public List<PaymentLine> lines { get; set; } = new List<PaymentLine>();
    }
}