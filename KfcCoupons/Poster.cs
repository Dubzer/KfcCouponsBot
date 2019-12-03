using Telegram.Bot;

namespace KfcCoupons
{
    public class Poster
    {
        private TelegramBotClient _client;
        
        public Poster(TelegramBotClient client)
        {
            _client = client;
        }
    }
}