using System;
using System.Collections.Generic;

namespace BangazonCli
{
    public class Order
    {
        public int OrderId {get; set;}
        public int PaymentId {get; set;}
        public int CustomerId {get; set;}
        public DateTime StartedOn {get; set;}
        
        public Order (int orderId, int customerId, int paymentId, DateTime startedOn) 
        {
            OrderId = orderId;
            CustomerId = customerId;
            StartedOn = startedOn;
            PaymentId = paymentId;
        }

    }
}