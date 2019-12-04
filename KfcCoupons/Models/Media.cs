using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Media
    {
        [JsonProperty("image")]
        public string Image { get; set; }
    }
}