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
             Order newOrder = new Order();

            string sqlSelect = $"SELECT * FROM CustomerOrder WHERE Id={orderId}";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    newOrder.Id = Convert.ToInt32(reader["Id"]);
                    newOrder.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    newOrder.StartedOn = Convert.ToDateTime(reader["StartedOn"]);
                    newOrder.PaymentId = Convert.ToInt32(reader["PaymentId"]);
                }
            });
            return newOrder;
        }

        public int ActiveCustOrderCheck (int activeCustId)
        {
            int orderOpen = 0;

            List<Order> orders = this.GetAllOrders();

            foreach (Order o in orders)
            {
                if (o.CustomerId == activeCustId && o.PaymentId == 0)
                {
                    orderOpen = o.Id;
                }
            }

            return orderOpen;
        }

        public Order CompleteOrder (int orderId, int paymentTypeId)
        {
            Order updatedOrder = new Order();
            string SqlCmd = $"UPDATE CustomerOrder SET PaymentId={paymentTypeId} WHERE Id={orderId}";
            dbManager.Update(SqlCmd);
            string LastIdSql = $"SELECT * FROM CustomerOrder WHERE Id={orderId}";
            dbManager.Query(LastIdSql, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    updatedOrder.Id = Convert.ToInt32(reader["Id"]);
                    updatedOrder.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    updatedOrder.PaymentId = Convert.ToInt32(reader["PaymentId"]);

                }
            });

            return updatedOrder;
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


    }
}