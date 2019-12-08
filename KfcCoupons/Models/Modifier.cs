using System.Collections.Generic;
using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Modifier
    {
        [JsonProperty("title")]
        private Dictionary<string, string> _title;

        public string Title => _title["ru"];
    }
}