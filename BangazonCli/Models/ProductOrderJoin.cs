namespace BangazonCli
{
    public class ProductOrderJoin
    {
        public int Id {get; set;}
        public int OrderId {get; set;}
        public int ProductId {get; set;}

        public ProductOrderJoin (int productOrderJoinId, int orderId,
        int productId)
        {
            Id = productOrderJoinId;
            OrderId = orderId;
            ProductId = productId;
        }
            
    }
}