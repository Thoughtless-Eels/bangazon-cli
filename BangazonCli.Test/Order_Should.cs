using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test
{
    public class Order_Should
    {
        private Order _order;
        private DateTime _dt = DateTime.Now;

        public Order_Should()
        {
            _order = new Order(
                1,
                1,
                0,
                _dt
            );
        }

        [Fact]
        public void createOrderObj()
        {

            Assert.Equal(1, _order.Id);
            Assert.Equal(1, _order.CustomerId);
            Assert.Equal(0, _order.PaymentId);
            Assert.Equal(_dt, _order.StartedOn);

        }
    }
}