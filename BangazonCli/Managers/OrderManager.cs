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
            string sql = $"INSERT into CurrentOrder {order.CustomerId}, {order.StartedOn}";
            int lastInsertId = dbManager.Insert(sql);
            string sqlSelect = $"SELECT * FROM CurrentOrder WHERE order.Id={lastInsertId}";
            Order lastOrder = dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    public Order emptyOrder;
                    
                    emptyOrder.Id = reader.GetInt32(0);
                    emptyOrder.CustomerId = reader[2].ToString();
                    emptyOrder.StartedOn = reader[3].ToString();


                }
            });
            return lastOrder;
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