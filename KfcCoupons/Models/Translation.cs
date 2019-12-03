using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Translation
    {
        [JsonProperty("ru")]
        public RuTranslation Ru { get; set; }
    }

    public class RuTranslation
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }
    }
}