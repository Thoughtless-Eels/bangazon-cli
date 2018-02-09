using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test {
    public class OrderManager_Should {

        private Order _order;
        private PaymentType _paymentType;
        private Customer _customer;
        private Product _product;

        private DateTime _dt = DateTime.Now;
        private DateTime? _nullDt = null;

        public OrderManager_Should () {
            _customer = new Customer (
                1,
                "Chaz",
                "Vanderbilt",
                "Brentwood",
                "TN",
                "37027",
                "615-555-1234",
                _dt,
                _dt
            );

            _product = new Product (
                1,
                4,
                12.55,
                "Book",
                "A Handcrafted book about See Sherp",
                2,
                72,
                _dt
            );

        }

        [Fact]
        public void CreateNewOrder () {

            _paymentType = new PaymentType (
                1,
                "12",
                "Visa",
                1
            );
            CustomerManager customerManager = new CustomerManager ();
            OrderManager orderManager = new OrderManager ();
            customerManager.Add (_customer);
            customerManager.ActivateCustomer (_customer.Id);

            _order = new Order (
                1,
                customerManager.ActiveCustomerId,
                0,
                _dt
            );

            orderManager.StoreOrder (_order);

            Assert.Contains (_order, orderManager.Orders);

        }

        [Fact]
        public void CompleteOrder () {

            CustomerManager customerManager = new CustomerManager ();
            OrderManager orderManager = new OrderManager ();
            customerManager.Add (_customer);
            customerManager.ActivateCustomer (_customer.Id);
            _order = new Order (
                1,
                customerManager.ActiveCustomerId,
                0,
                _dt
            );

            orderManager.CompleteOrder (_order.Id, _paymentType.Id);

            Assert.Equal (1, _order.PaymentId);
        }
    }
}