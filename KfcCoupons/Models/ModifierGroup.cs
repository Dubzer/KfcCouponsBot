using System.Collections.Generic;
using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class ModifierGroup
    {
        [JsonProperty("title")]
        private Dictionary<string, string> _title;

        [JsonProperty("modifiers")]
        public Modifier[] Modifiers { get; set; }

        public string Title => _title["ru"];
    }
}