using System;
using System.Collections.Generic;

namespace BangazonCli
{
    public class Order
    {
        public int Id {get; set;}
        public int PaymentId {get; set;}
        public int CustomerId {get; set;}
        public DateTime StartedOn {get; set;}
        
        public Order (int orderId, int customerId, int paymentId, DateTime startedOn) 
        {
            Id = orderId;
            PaymentId = paymentId;
            CustomerId = customerId;
            StartedOn = startedOn;
        }

        public Order (int customerId, DateTime startedOn)
        {
            CustomerId = customerId;
            StartedOn = startedOn;   
        }

        public Order (int customerId, int paymentId, DateTime startedOn)
        {
            CustomerId = customerId;
            PaymentId = paymentId;
            StartedOn = startedOn;   
        }

        public Order ()
        {
            Id = 0;
            PaymentId = 0;
            CustomerId = 0;
            StartedOn = DateTime.Now;
        }

    }
}