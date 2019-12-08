using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Product
    {
        [JsonProperty("productId")]
        public long Id { get; set; }

        [JsonProperty("price")]
        private Price _price;
        public double Price => _price.Amount * 0.01;

        [JsonProperty("oldPrice")]
        private long? _oldPrice;
        public double? OldPrice => _oldPrice * 0.01;
        
        [JsonProperty(PropertyName = "externalIdentifiers")]
        private ExternalIdentifiers _identifiers;
        public uint Coupon => _identifiers.RkeeperCode;
        
        [JsonProperty("media")]
        private Media _media;
        public string Thumbnail => _media.Image;
        
        [JsonProperty("modifierGroups")]
        public ModifierGroup[] ModifierGroups { get; set; }
    }
}