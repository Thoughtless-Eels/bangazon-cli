using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Sqlite;

namespace BangazonCli
{
    public class OrderManager
    {
        public List<Order> Orders = new List<Order>();
        DatabaseManager dbManager;

        public OrderManager(string dbEnvironment)
        {
            dbManager = new DatabaseManager(dbEnvironment);
        }

        public Order StoreOrder(Order order)
        {
            dbManager.CheckTables();
            Order emptyOrder = new Order(); 
            string sql = $"INSERT into CustomerOrder (Id, PaymentId, CustomerId, StartedOn) VALUES (null, '{order.PaymentId}', '{order.CustomerId}', '{order.StartedOn}')";
            int lastInsertId = dbManager.Insert(sql);
            string sqlSelect = $"SELECT * FROM CustomerOrder WHERE CustomerOrder.Id={lastInsertId}";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    emptyOrder.Id = Convert.ToInt32(reader["Id"]);
                    emptyOrder.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    emptyOrder.StartedOn = Convert.ToDateTime(reader["StartedOn"]);
                }
            });

            return emptyOrder;
        }

        public Order GetSingleOrder (int orderId) 
        {
            return Orders.Where(o => o.Id == orderId).Single();
        }

        public int ActiveCustOrderCheck (int activeCustId)
        {
            int orderOpen = 0;

            List<Order> orders = this.GetAllOrders();

            foreach (Order o in orders)
            {
                if (o.CustomerId == activeCustId && o.PaymentId != 0)
                {
                    orderOpen = o.Id;
                }
            }

            return orderOpen;
        }

        public List<Order> GetAllOrders ()
        {
            List<Order> orders = new List<Order>();

            string sqlSelect = $"SELECT * FROM CustomerOrder";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    Order newOrder = new Order();
                    newOrder.Id = Convert.ToInt32(reader["Id"]);
                    newOrder.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    newOrder.StartedOn = Convert.ToDateTime(reader["StartedOn"]);
                    newOrder.PaymentId = Convert.ToInt32(reader["PaymentId"]);
                    orders.Add(newOrder);                                        
                }
            });
            return orders;
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