using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "externalIdentifiers")]
        private ExternalIdentifiers _identifiers;

        [JsonProperty("media")]
        private Media _media;

        [JsonProperty("oldPrice")]
        private long? _oldPrice;

        [JsonProperty("price")]
        private Price _price;

        [JsonProperty("productId")]
        public long Id { get; set; }

        public double Price => _price.Amount * 0.01;
        public double? OldPrice => _oldPrice * 0.01;
        public uint Coupon => _identifiers.RkeeperCode;
        public string Thumbnail => _media.Image;

        [JsonProperty("modifierGroups")]
        public ModifierGroup[] ModifierGroups { get; set; }
    }
}