using System.Collections.Generic;
using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Value
    {
        [JsonProperty("hashCode")]
        public string HashCode { get; set; }

        [JsonProperty("products")]
        public Dictionary<string, Product> Products { get; set; }

        [JsonProperty("categories")]
        public ValueCategories Categories { get; set; }
    }
}