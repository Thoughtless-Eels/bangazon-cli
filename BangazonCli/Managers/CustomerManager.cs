using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BangazonCli
{
    public class CustomerManager
    {
        public List<Customer> _customerTable = new List<Customer>();

        public int ActiveCustomerId;

        private DatabaseManager dbManager;

        public CustomerManager(string envVar)
        {
            dbManager = new DatabaseManager(envVar);

        }

            // this.Id = 0;
            // this.FirstName = "";
            // this.LastName = "";
            // this.City = "";
            // this.State = "";
            // this.PostalCode = "";
            // this.PhoneNumber = "";

        public Customer Add(Customer freshCust)
        {
            Customer emptyCust = new Customer();
            dbManager.CheckTables();
            string custSql = $"INSERT into Customer (Id, FirstName, LastName, City, State, PostalCode, PhoneNumber, CreatedOn, LastLogin) VALUES (null, '{freshCust.FirstName}', '{freshCust.LastName}', '{freshCust.City}', '{freshCust.State}', '{freshCust.PostalCode}', '{freshCust.PhoneNumber}', '{freshCust.CreatedOn}', '{freshCust.LastLogin}')";
            int lastInsertId = dbManager.Insert(custSql);
            string sqlSelect = $"SELECT * FROM Customer WHERE Customer.Id={lastInsertId}";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {

                    emptyCust.Id = Convert.ToInt32(reader["Id"]);
                    emptyCust.FirstName = Convert.ToString(reader["FirstName"]);
                    emptyCust.LastName = Convert.ToString(reader["LastName"]);
                    
                }
            });
            return emptyCust;
        }

        // public void Add(Customer monkeybutt)
        // {
        //     _customerTable.Add(monkeybutt);
        // }
        public void ActivateCustomer(int Id)
        {
            ActiveCustomerId = Id;
        }

        public List<Customer> GetAllCustomers ()
        {
            return _customerTable;
        }

        public Customer GetSingleCustomer(int id)
        {
            return _customerTable.Where(c => c.Id == id).Single();
        }
    }
}