using System.Collections.Generic;
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

        public async Task Clean(Dictionary<long, int> messageIdOfProduct, Product[] currentProducts)
        {
            
        }
    }
}