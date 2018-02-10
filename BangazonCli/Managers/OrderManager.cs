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
            string sql = $"INSERT into CustomerOrder (Id, PaymentId, CustomerId, StartedOn) VALUES (null, null, '{order.CustomerId}', '{order.StartedOn}')";
            int lastInsertId = dbManager.Insert(sql);
            string sqlSelect = $"SELECT * FROM CurrentOrder WHERE order.Id={lastInsertId}";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    emptyOrder.Id = reader.GetInt32(0);
                    emptyOrder.CustomerId = reader.GetInt32(2);
                    emptyOrder.StartedOn = reader.GetDateTime(3);
                }
            });

            return emptyOrder;
        }

        public Order GetSingleOrder (int orderId) 
        {
            return Orders.Where(o => o.Id == orderId).Single();
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