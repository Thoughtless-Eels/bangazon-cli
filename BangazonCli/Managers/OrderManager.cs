using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BangazonCli
{
    public class OrderManager
    {
        public List<Order> Orders = new List<Order>();

        public void StoreOrder(Order order)
        {
            Orders.Add(order);
        }

        public Order GetSingleOrder (int orderId) 
        {
            return Orders.Where(o => o.Id == orderId).Single();
        }

        public void CompleteOrder(int orderId, int paymentTypeId)
        {

                foreach(Order o in Orders)
                {
                    if (o.Id == orderId)
                    {
                        // Type type = o.GetType();

                        // PropertyInfo prop = type.GetProperty("PaymentId");

                        // prop.SetValue (type, prop, paymentTypeId);
                        
                        o.PaymentId = paymentTypeId;
                    }
                }
        }

    }
}