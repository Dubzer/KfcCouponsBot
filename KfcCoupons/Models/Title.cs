using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Title
    {
        [JsonProperty("ru")]
        public string Ru { get; set; }
    }
}