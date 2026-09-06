using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.models
{
    public class Sale
    {
        public string noOrder { get; set; }
        public DateTime odate { get; set; }
        public string customerId { get; set; }
        public float dpp { get; set; }
        public float discPrs { get; set; }
        public float discRph { get; set; }
        public float ppnPrs { get; set; }
        public float ppnRph { get; set; }
        public float total { get; set; }
        public string state { get; set; }
    }
}
