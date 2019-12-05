using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KfcCoupons.Models;
using Newtonsoft.Json;

namespace KfcCoupons
{
    public class KfcClient
    {
        private readonly HttpClient _httpClient;
        private const string MenuEndpoint = "menu/74020442/website/finger_lickin_good";
        
        public KfcClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://api.kfc.com/api/menu/api/v1/") };
        }

        public async Task<MenuData> GetMenuData()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(MenuEndpoint);
            string content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<MenuData>(content);
        }
        
        /// <returns>Products and hash code of result</returns>
        public async Task<(IEnumerable<Product> products, string hash)> GetProductsWithCoupon()
        {
            MenuData menuData = await GetMenuData();

            return (menuData.Value.Products.Where(pair => menuData.Value.Categories.Coupons[0].Products.Contains(pair.Value.Id))
                .Select(x => x.Value), menuData.Value.HashCode);
        }
    }
}