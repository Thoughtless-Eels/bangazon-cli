using System;
using BangazonCli;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test {
    public class OrderManager_Should {

        private Order _order;
        private PaymentType _paymentType;
        private Customer _customer;
        private Customer _customer2;
        
        private Product _product;

        private DateTime _dt = DateTime.Now;

        public OrderManager_Should () {
            _customer = new Customer (
                1,
                "Chaz",
                "Vanderbilt",
                "777 MoneyStacks way",
                "Brentwood",
                "TN",
                "37027",
                "615-555-1234",
                _dt,
                _dt
            );

            _customer2 = new Customer (
                "KIKI",
                "OALALALA",
                "777 HAAHA way",
                "Brentwood",
                "TN",
                "37227",
                "615-455-1284",
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

            CustomerManager customerManager = new CustomerManager ("BangazonTestDB");
            OrderManager orderManager = new OrderManager ("BangazonTestDB");
            customerManager.Add (_customer);
            customerManager.ActivateCustomer (_customer.Id);    

            _order = new Order (
                1,
                customerManager.ActiveCustomer.Id,
                0,
                _dt
            );
            
            Order updatedOrder = orderManager.StoreOrder (_order);

            Assert.Equal (customerManager.ActiveCustomer.Id, updatedOrder.CustomerId);

        }

        [Fact]
        public void CompleteOrder () {
            _paymentType = new PaymentType (
                1,
                "12",
                "Visa",
                1
            );

            CustomerManager customerManager = new CustomerManager ("BangazonTestDB");
            OrderManager orderManager = new OrderManager ("BangazonTestDB");
            Customer newCust = customerManager.Add (_customer2);
            customerManager.ActivateCustomer (newCust.Id);
            _order = new Order (
                customerManager.ActiveCustomer.Id,
                0,
                _dt
            );
            Order thatOrder = orderManager.StoreOrder (_order);
            Order newOrd = orderManager.CompleteOrder(thatOrder.Id, _paymentType.Id);
            Order updatedOrder = orderManager.GetSingleOrder(newOrd.Id);
            Assert.Equal(_paymentType.Id, updatedOrder.PaymentId);
        }

        [Fact]
        public void GetAllOrders_Should () 
        {
            OrderManager orderManager = new OrderManager ("BangazonTestDB");
            CustomerManager customerManager = new CustomerManager ("BangazonTestDB");
            customerManager.Add (_customer2);
            
            _order = new Order (
                customerManager.ActiveCustomer.Id,
                0,
                _dt
            );
            Order freshOrder = orderManager.StoreOrder (_order);

            List<Order> orders = orderManager.GetAllOrders();
            bool orderPassed = false;

            foreach(Order o in orders)
            {
                if (o.CustomerId == customerManager.ActiveCustomer.Id)
                {
                    orderPassed = true;
                }
            } 

            Assert.True(orderPassed);
            
        } 
    }
}