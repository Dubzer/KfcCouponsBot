using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class ExternalIdentifiers
    {
        [JsonProperty(PropertyName = "rkeeperCode")]
        public uint RkeeperCode { get; set; }
    }
}