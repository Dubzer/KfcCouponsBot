using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace KfcCoupons.Models
{
    public class PostedProduct
    {
        public readonly long Id;
        public readonly int MessageId;

        public PostedProduct(long id, int messageId)
        {
            Id = id;
            MessageId = messageId;
        }
    }
}