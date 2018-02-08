namespace BangazonCli
{
    public class ProductOrderJoin
    {
        public string ProductOrderJoinId {get; set;}
        public string OrderId {get; set;}
        public string ProductId {get; set;}

        public ProductOrderJoin (string productOrderJoinId, string orderId,
        string productId)
        {
            ProductOrderJoinId = productOrderJoinId;
            OrderId = orderId;
            ProductId = productId;
        }
            
    }
}