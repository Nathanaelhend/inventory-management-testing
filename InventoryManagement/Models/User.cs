using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InventoryManagement.models
{
    public class User
    {
        [JsonProperty("userid")]
        public string id { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("fullname")]
        public string fullname { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("phone")]
        public string phone { get; set; }
    }
}
