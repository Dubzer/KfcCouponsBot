namespace KfcCoupons.Models
{
    public class PostedProduct
    {
        public PostedProduct(long id, int messageId)
        {
            Id = id;
            MessageId = messageId;
        }

        public long Id { get; }
        public int MessageId { get; }
    }
}