using Newtonsoft.Json;

namespace KfcCoupons.Models
{
    public class Product
    {
        [JsonProperty("productId")]
        public long Id { get; set; }

        [JsonProperty("price")]
        private Price _price;
        public long Price => _price.Amount;
        
        [JsonProperty("oldPrice")]
        public long OldPrice { get; set; }
        
        // TODO: Convert to enum
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("translation")]
        private Translation Translation { get; set; }
        public string Description => Translation.Ru.Description;
        public uint Coupon => Translation.Ru.Short;
        
        // TODO: Media
        //[JsonProperty("media")]
        //public Media Media { get; set; }

        /*
         Maybe use it later to create menu like:
         Combo: 
         1. 3 Strips original / 3 Strips hot
         2. Cheese sauce
        [JsonProperty("modifierGroups")]
        public ModifierGroup[] ModifierGroups { get; set; }
        */
    }
}