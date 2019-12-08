using System.Collections.Generic;
using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "externalIdentifiers")]
        private ExternalIdentifiers _identifiers;

        [JsonProperty("media")]
        private Dictionary<string, string> _media;

        [JsonProperty("oldPrice")]
        private long? _oldPrice;

        [JsonProperty("price")]
        private Dictionary<string, string> _price;

        [JsonProperty("productId")]
        public long Id { get; set; }

        public double Price => long.Parse(_price["amount"]) * 0.01;
        public double? OldPrice => _oldPrice * 0.01;
        public uint Coupon => _identifiers.RkeeperCode;
        public string Thumbnail => _media["image"];

        [JsonProperty("modifierGroups")]
        public ModifierGroup[] ModifierGroups { get; set; }
    }
}