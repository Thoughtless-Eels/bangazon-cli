using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BangazonCli {
    public class ProductManager {
        public List<Product> _productTable = new List<Product> ();
        private DatabaseManager dbManager;

        public ProductManager(string envVar)
        {
            dbManager = new DatabaseManager(envVar);

        }

            // this.Id = id;
            // this.CustomerId = customerId;
            // this.Price = price;
            // this.Name = name;
            // this.Description = description;
            // this.Quantity = quantity;
            // this.QuantitySold = quantitySold;
            // this.CreatedOn = createdOn;
        public Product Add (Product product) {

            Product emptyProduct = new Product();
            dbManager.CheckTables();
            string productSql = $"INSERT into Product (Id, CustomerId, Price, Name, Description, Quantity, QuantitySold, CreatedOn) VALUES (null, '{product.CustomerId}', '{product.Price}', '{product.Name}', '{product.Description}', '{product.Quantity}', '{product.QuantitySold}', '{product.CreatedOn}')";
            int lastInsertId = dbManager.Insert(productSql);
            string sqlSelect = $"SELECT * FROM Product WHERE Product.Id={lastInsertId}";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {

                    emptyProduct.Id = Convert.ToInt32(reader["Id"]);
                    emptyProduct.Price = Convert.ToInt32(reader["Price"]);
                    emptyProduct.Name = Convert.ToString(reader["Name"]);
                    
                }
            });
            return emptyProduct;
        }

        // public Product CreateProduct (int id, int customerid, double price, string name, string description, int quantity, int quantitysold, DateTime createdon) {

        //         Product _product = new Product ();
        //         return _product;
        // }


        public List<Product> GetAllProducts () {
            return _productTable;
        }

        public Product GetSingleProduct (int id) {
            return _productTable.Where (p => p.Id == id).Single ();
        }

        public void RemoveSingleProduct (Product product) {
            _productTable.Remove (product);
        }

        public void UpdatePrice (Product product, double price) {
            product.Price = price;
        }

        public void UpdateSingleProduct (Product product) {
            product.Id = 1;
        }
        public void AddProductToCustomer (Product product, Customer customer) {
            product.CustomerId = customer.Id;
        }
    }
}