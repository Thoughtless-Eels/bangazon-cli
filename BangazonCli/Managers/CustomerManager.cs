using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BangazonCli
{
    public class CustomerManager
    {
        public List<Customer> _customerTable = new List<Customer>();

        public Customer ActiveCustomer;

        private DatabaseManager dbManager;



        public CustomerManager(string envVar)
        {
            dbManager = new DatabaseManager(envVar);

        }

        public Customer Add(Customer freshCust)
        {
            Customer emptyCust = new Customer();
            dbManager.CheckTables();
            string custSql = $"INSERT into Customer (Id, FirstName, LastName, Address, City, State, PostalCode, PhoneNumber, CreatedOn, LastLogin) VALUES (null, '{freshCust.FirstName}', '{freshCust.LastName}','{freshCust.Address}', '{freshCust.City}', '{freshCust.State}', '{freshCust.PostalCode}', '{freshCust.PhoneNumber}', '{freshCust.CreatedOn}', '{freshCust.LastLogin}')";
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
            List<Customer> customers = this.GetAllCustomers();
            ActiveCustomer = customers.Where(c => Id == c.Id).Single();
        }

        public List<Customer> GetAllCustomers ()
        {

            List<Customer> allCusts = new List<Customer>();

            string sqlSelect = $"SELECT * FROM Customer";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    Customer currentCust = new Customer();

                    currentCust.Id = Convert.ToInt32(reader["Id"]);
                    currentCust.FirstName = Convert.ToString(reader["FirstName"]);
                    currentCust.LastName = Convert.ToString(reader["LastName"]);
                    currentCust.Address = Convert.ToString(reader["Address"]);
                    currentCust.City = Convert.ToString(reader["City"]);
                    currentCust.State = Convert.ToString(reader["State"]);
                    currentCust.PostalCode = Convert.ToString(reader["PostalCode"]);
                    currentCust.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                    currentCust.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                    currentCust.LastLogin = Convert.ToDateTime(reader["LastLogin"]);
                    
                    allCusts.Add(currentCust);
                    
                }
            });


            return allCusts;
        }

        public Customer GetSingleCustomer(int id)
        {
            return _customerTable.Where(c => c.Id == id).Single();
        }
    }
}