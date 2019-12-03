using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Price
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }
    }
}