using System;

namespace BangazonCli
{
    public class Order
    {
        public string Id {get; set;}
        public string PaymentId {get; set;}
        public string CustomerId {get; set;}
        public DateTime CompletedOn {get; set;}
        public DateTime StartedOn {get; set;}
        
        public Order (string orderId, string paymentId, string customerId, 
        DateTime completedOn, DateTime startedOn) 
        {
            Id = orderId;
            PaymentId = paymentId;
            CustomerId = customerId;
            CompletedOn = completedOn;
            StartedOn = startedOn;
        }

    }
}