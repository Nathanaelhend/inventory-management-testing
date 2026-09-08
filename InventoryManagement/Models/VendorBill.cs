using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class VendorBill
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public DateTime date_edit { get; set; }
        public float ppn {  get; set; }
        public float discount { get; set; }
        public float total { get; set;  }
        public string vendor_id { get; set; }
        public string state { get; set; }

    }
}
