using System.Collections.Generic;
using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class ModifierGroup
    {
        [JsonProperty("modifiers")]
        public Modifier[] Modifiers { get; set; }

        [JsonProperty("title")]
        private Dictionary<string, string> _title;
        public string Title => _title["ru"];
    }
}