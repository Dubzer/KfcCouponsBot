using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class ModifierGroup
    {
        [JsonProperty("modifiers")]
        public Modifier[] Modifiers { get; set; }
    }
}