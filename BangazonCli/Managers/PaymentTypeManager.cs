using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BangazonCli
{
    public class PaymentTypeManager
    {

        // create an empty list that you can add your Payment Type info into:
        public List<PaymentType> _paymentTypeTable = new List<PaymentType>();

        private DatabaseManager dbManager;

        public PaymentTypeManager(string envVar)
        {
            dbManager = new DatabaseManager(envVar);

        }

            // this.Id = id;
            // this.Name = name;
            // this.AccountNumber = accountNumber;
            // this.CustomerId = customerId;
        public PaymentType AddPaymentType(PaymentType monkeybutt)
        {
            PaymentType emptyPt = new PaymentType();
            dbManager.CheckTables();
            string ptSql = $"INSERT into PaymentType (Id, Name, AccountNumber, CustomerId) VALUES (null, '{monkeybutt.Name}', '{monkeybutt.AccountNumber}', '{monkeybutt.CustomerId}')";
            int lastInsertId = dbManager.Insert(ptSql);
            string sqlSelect = $"SELECT * FROM PaymentType WHERE PaymentType.Id={lastInsertId}";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {

                    emptyPt.Id = Convert.ToInt32(reader["Id"]);
                    emptyPt.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                    emptyPt.Name = Convert.ToString(reader["Name"]);
                    emptyPt.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                }
            });
            return emptyPt;
        }

        public List<PaymentType> GetCustomerPaymentTypes(int id)
        {
            List<PaymentType> paymentOptions = new List<PaymentType>();
            string sqlString = $"SELECT * FROM PaymentType WHERE CustomerId={id}";
            dbManager.Query(sqlString, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    PaymentType emptyPt = new PaymentType();
                    emptyPt.Id = Convert.ToInt32(reader["Id"]);
                    emptyPt.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                    emptyPt.Name = Convert.ToString(reader["Name"]);
                    emptyPt.CustomerId = Convert.ToInt32(reader["CustomerId"]);

                    paymentOptions.Add(emptyPt);
                }
            });
        
            return paymentOptions;
        }



    }
}