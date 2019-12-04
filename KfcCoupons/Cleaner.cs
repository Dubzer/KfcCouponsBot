using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KfcCoupons.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace KfcCoupons
{
    public class Cleaner
    {
        private readonly TelegramBotClient _client;
        private readonly ChatId _chatId;

        public Cleaner(TelegramBotClient client,ChatId chatId) =>
            (_client, _chatId) = (client, chatId);

        public async Task Clean(Dictionary<long, int> messageIdOfProduct, IEnumerable<Product> currentProducts)
        {
            foreach (KeyValuePair<long, int> product in messageIdOfProduct.Where(product => 
                !currentProducts.Select(p => p.Id).Contains(product.Key)))
            {
                await _client.DeleteMessageAsync(_chatId, product.Value);
            }
        }
    }
}