using System.Collections.Generic;
using System.Linq;

namespace BangazonCli
{
    public class OrderManager
    {
        public List<Order> Orders = new List<Order>();

        public void StoreOrder(Order order)
        {
            Orders.Add(order);
        }

        public void CompleteOrder(int orderId, int paymentTypeId)
        {

                foreach(Order o in Orders)
                {
                    if (o.OrderId == orderId)
                    {
                        o.PaymentId = paymentTypeId;
                    }
                }
        }

    }
}