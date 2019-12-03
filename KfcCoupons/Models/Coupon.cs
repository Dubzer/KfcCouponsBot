using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Coupon
    {
        [JsonProperty("products")]
        public long[] Products { get; set; }
    }
}