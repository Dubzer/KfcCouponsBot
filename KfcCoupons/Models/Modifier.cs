using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Modifier
    {
        [JsonProperty("title")]
        public Title Title { get; set; }
    }
}