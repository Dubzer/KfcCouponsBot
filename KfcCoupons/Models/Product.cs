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
        public long? _oldPrice;
        public double? OldPrice => _oldPrice * 0.01;
        
        [JsonProperty("translation")]
        private Translation Translation { get; set; }
        public string Description => Translation.Ru.Description;
        public string Coupon => Translation.Ru.Short;
        
        [JsonProperty("media")]
        private Media _media;
        public string Thumbnail => _media.Image;
        
        [JsonProperty("modifierGroups")]
        public ModifierGroup[] ModifierGroups { get; set; }
    }
}