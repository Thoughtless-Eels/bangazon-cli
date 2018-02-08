using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test
{
    public class Order_Should
    {
        private Order _order;
        private DateTime dt = DateTime.Now;
        public Order_Should () {
            _order = new Order (
                "1",
                "1",
                "1",
                dt,
                dt

            );
        }
        [Fact]
        public void createOrderObj () {
            
            Assert.Equal("1", _order.OrderId);
            Assert.Equal("1", _order.CustomerId);
            Assert.Equal("1", _order.PaymentId);
            Assert.Equal(dt, _order.CompletedOn);
            Assert.Equal(dt, _order.StartedOn);
            
        }
    }
}