namespace BangazonCli
{
    public class ProductOrderJoin
    {
        public string Id {get; set;}
        public string OrderId {get; set;}
        public string ProductId {get; set;}

        public ProductOrderJoin (string productOrderJoinId, string orderId,
        string productId)
        {
            Id = productOrderJoinId;
            OrderId = orderId;
            ProductId = productId;
        }
            
    }
}