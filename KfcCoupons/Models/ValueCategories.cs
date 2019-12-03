using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class ValueCategories
    {
        [JsonProperty("coupons")]
        public Coupon[] Coupons { get; set; }
    }
}