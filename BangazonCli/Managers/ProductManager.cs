using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BangazonCli
{
    public class ProductManager
    {
        public List<Product> _productTable = new List<Product>();
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
        public Product Add(Product product)
        {

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

        public List<Product> GetAllProducts()
        {
            dbManager.CheckTables();
            List<Product> prodList = new List<Product>();
            string cmdStr = "SELECT * From Product";
            dbManager.Query(cmdStr, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    Product newProduct = new Product();

                    newProduct.Id = Convert.ToInt32(reader["Id"]);
                    newProduct.Name = Convert.ToString(reader["Name"]);
                    newProduct.Price = Convert.ToDouble(reader["Price"]);
                    newProduct.Description = Convert.ToString(reader["Description"]);
                    newProduct.Quantity = Convert.ToInt32(reader["Quantity"]);
                    newProduct.QuantitySold = Convert.ToInt32(reader["QuantitySold"]);
                    newProduct.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                    newProduct.CustomerId = Convert.ToInt32(reader["CustomerId"]);

                    prodList.Add(newProduct);

                }
            });
            return prodList;
        }

        public Product GetSingleProduct(int id)
        {
            Product returnedProduct = new Product();
            string sqlSelect = $"SELECT * FROM Product WHERE Product.Id={id}";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    returnedProduct.Id = Convert.ToInt32(reader["Id"]);
                    returnedProduct.Name = Convert.ToString(reader["Name"]);
                    returnedProduct.Description = Convert.ToString(reader["Description"]);
                    returnedProduct.Price = Convert.ToDouble(reader["Price"]);
                    returnedProduct.Quantity= Convert.ToInt32(reader["Quantity"]);
                    returnedProduct.QuantitySold = Convert.ToInt32(reader["QuantitySold"]);
                    returnedProduct.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                }

            });
            return returnedProduct;
        }

        public void RemoveSingleProduct(Product product)
        {
            _productTable.Remove(product);
        }

        public Product UpdatePrice(Product monkeyButt, double price)
        {
            Product updatedProduct = new Product();
            string sqlStr = $"UPDATE Product SET Price={price} WHERE Id={monkeyButt.Id}";  
            dbManager.Update(sqlStr);
            string showMe = $"SELECT * FROM Product WHERE Id={monkeyButt.Id}";
            dbManager.Query(showMe, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    updatedProduct.Id = Convert.ToInt32(reader["Id"]);
                    updatedProduct.Name = Convert.ToString(reader["Name"]);
                    updatedProduct.Price = Convert.ToDouble(reader["Price"]);

                }
            });

            return updatedProduct;
        }

        public List<ProductOrderJoin> ListActiveOrderProducts (int id)
        {

            List<ProductOrderJoin> matchingJoins = new List<ProductOrderJoin>();

            string sqlString = $"SELECT * FROM ProductOrderJoin WHERE OrderId={id}";

            dbManager.Query(sqlString, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ProductOrderJoin poj = new ProductOrderJoin();

                    poj.Id = Convert.ToInt32(reader["Id"]);
                    poj.OrderId = Convert.ToInt32(reader["OrderId"]);
                    poj.ProductId = Convert.ToInt32(reader["ProductId"]);

                    matchingJoins.Add(poj);
                }
            });

            return matchingJoins;
        }

        public double TotalProducts (List<ProductOrderJoin> mathingJoins)
        {
            double ticketTotal = 0;
            foreach (ProductOrderJoin poj in mathingJoins)
            {
                string sqlString = $"SELECT Price FROM Product WHERE Id={poj.ProductId}";
                dbManager.Query(sqlString, (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ticketTotal += Convert.ToDouble(reader["Price"]);
                    }
                });
            }

            return ticketTotal;
        }

        public Product UpdateDescription(Product monkeyButt, string description)
        {
            Product updatedProduct = new Product();
            string sqlStr = $"UPDATE Product SET Description='{description}' WHERE Id={monkeyButt.Id}";  
            dbManager.Update(sqlStr);
            string showMe = $"SELECT * FROM Product WHERE Id={monkeyButt.Id}";
            dbManager.Query(showMe, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    updatedProduct.Id = Convert.ToInt32(reader["Id"]);
                    updatedProduct.Name = Convert.ToString(reader["Name"]);
                    updatedProduct.Price = Convert.ToDouble(reader["Price"]);
                    updatedProduct.Description = Convert.ToString(reader["Description"]);

                }
            });

            return updatedProduct;
        }

        public Product UpdateTitle(Product monkeyButt, string title)
        {
            Product updatedProduct = new Product();
            string sqlStr = $"UPDATE Product SET Name='{title}' WHERE Id={monkeyButt.Id}";  
            dbManager.Update(sqlStr);
            string showMe = $"SELECT * FROM Product WHERE Id={monkeyButt.Id}";
            dbManager.Query(showMe, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    updatedProduct.Id = Convert.ToInt32(reader["Id"]);
                    updatedProduct.Name = Convert.ToString(reader["Name"]);
                    updatedProduct.Price = Convert.ToDouble(reader["Price"]);

                }
            });

            return updatedProduct;
        }

        public Product UpdateQuantity(Product monkeyButt, int quant)
        {
            Product updatedProduct = new Product();
            string sqlStr = $"UPDATE Product SET Quantity={quant} WHERE Id={monkeyButt.Id}";  
            dbManager.Update(sqlStr);
            string showMe = $"SELECT * FROM Product WHERE Id={monkeyButt.Id}";
            dbManager.Query(showMe, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    updatedProduct.Id = Convert.ToInt32(reader["Id"]);
                    updatedProduct.Name = Convert.ToString(reader["Name"]);
                    updatedProduct.Price = Convert.ToDouble(reader["Price"]);
                    updatedProduct.Quantity = Convert.ToInt32(reader["Quantity"]);

                }
            });

            return updatedProduct;
        }

        public List<Product> FilteredProducts(int ActiveCustomerId, List<Product> listProducts)
        {
            List<Product> filteredList = new List<Product>();
            foreach (Product p in listProducts)
            {
                if (p.CustomerId == ActiveCustomerId)
                {
                    filteredList.Add(p);
                }
            }
            return filteredList;
        }

        public void UpdateSingleProduct(Product product)
        {
            product.Id = 1;
        }
        public void AddProductToCustomer(Product product, Customer customer)
        {
            product.CustomerId = customer.Id;
        }

        public ProductOrderJoin storeProductOrderJoin(ProductOrderJoin poj)
        {
            ProductOrderJoin emptyPOJ = new ProductOrderJoin();
            dbManager.CheckTables();
            string pojSql = $"INSERT into ProductOrderJoin (Id, OrderId, ProductId) VALUES (null, '{poj.OrderId}', '{poj.ProductId}')";
            int lastInsertId = dbManager.Insert(pojSql);
            string sqlSelect = $"SELECT * FROM ProductOrderJoin WHERE ProductOrderJoin.Id={lastInsertId}";
            dbManager.Query(sqlSelect, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {

                    emptyPOJ.Id = Convert.ToInt32(reader["Id"]);
                    emptyPOJ.OrderId = Convert.ToInt32(reader["OrderId"]);
                    emptyPOJ.ProductId = Convert.ToInt32(reader["ProductId"]);

                }
            });
            return emptyPOJ;
        }


    }
}