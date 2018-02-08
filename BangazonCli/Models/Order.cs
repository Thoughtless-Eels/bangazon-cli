using System;

namespace BangazonCli
{
    public class Order
    {
        public string OrderId {get; set;}
        public string PaymentId {get; set;}
        public string CustomerId {get; set;}
        public DateTime CompletedOn {get; set;}
        public DateTime StartedOn {get; set;}
        
        public Order (string orderId, string paymentId, string customerId, 
        DateTime completedOn, DateTime startedOn) 
        {
            OrderId = orderId;
            PaymentId = paymentId;
            CustomerId = customerId;
            CompletedOn = completedOn;
            StartedOn = startedOn;
        }

    }
}