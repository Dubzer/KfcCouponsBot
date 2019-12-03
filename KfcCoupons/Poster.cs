using KfcCoupons.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace KfcCoupons
{
    public class Poster
    {
        private readonly ChatId _chatId;
        private readonly TelegramBotClient _client;

        public Poster(TelegramBotClient client, ChatId chatId) =>
            (_client, _chatId) = (client, chatId);

        public void Post(Product product)
        {
            string text = $"{product.Description}\n\nКупон: `{product.Coupon}`\nНовая цена: {product.Price}\nДешевле на: {product.OldPrice - product.Price}";
            _client.SendTextMessageAsync(_chatId, text);
        }
    }
}