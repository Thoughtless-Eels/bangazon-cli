using System;
using System.Collections.Generic;

namespace BangazonCli
{
    public class Order
    {
        public string Id {get; set;}
        public string PaymentId {get; set;}
        public string CustomerId {get; set;}
        public DateTime CompletedOn {get; set;}
        public DateTime StartedOn {get; set;}
        
        public Order (int orderId, int customerId, int paymentId, DateTime startedOn) 
        {
            Id = orderId;
            PaymentId = paymentId;
            CustomerId = customerId;
            StartedOn = startedOn;
            PaymentId = paymentId;
        }

    }
}