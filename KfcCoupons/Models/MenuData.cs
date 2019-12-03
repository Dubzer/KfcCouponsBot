using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class MenuData
    {
        [JsonProperty("value")]
        public Value Value { get; set; }
    }
}