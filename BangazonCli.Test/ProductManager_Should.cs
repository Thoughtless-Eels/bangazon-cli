using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test
{
    public class ProductManager_Should
    {
        private Product _product;
        private Customer _customer;
        private Customer _customer2;
        private DateTime dt = DateTime.Now;

        public ProductManager_Should()
        {

            _product = new Product(
                1,
                1,
                12.55,
                "Book",
                "A Handcrafted book about See Sherp",
                2,
                72,
                dt
            );

            _customer = new Customer(
                1,
                "Chaz",
                "Vanderbilt",
                "Brentwood",
                "777 Money Stacks Way",
                "TN",
                "37027",
                "615-555-1234",
                DateTime.Now,
                DateTime.Now
            );

            _customer2 = new Customer(
                "Bootsy",
                "Collins",
                "Outer Space",
                "1000 the moon",
                "MOON",
                "102938",
                "123-987-3476",
                DateTime.Now,
                DateTime.Now
            );
        }

        [Fact]
        public void AddProduct()
        {
            CustomerManager customerManager = new CustomerManager("BangazonTestDB");
            ProductManager productmanager = new ProductManager("BangazonTestDB");
            Customer newCust = customerManager.Add(_customer2);
            customerManager.ActivateCustomer(newCust.Id);

            Product _product2 = new Product(
            customerManager.ActiveCustomer.Id,
            45.27,
            "Movie",
            "Instructional Film about See Sherp",
            8,
            0,
            dt
        );


            Product newProduct = productmanager.Add(_product2);
            Assert.Equal("Movie", newProduct.Name);
        }

        [Fact]
        public void ListAllProducts()
        {
            // DatabaseManager dbManager = new DatabaseManager("BangazonTestDB");
            // dbManager.CheckCustomerTable();
            ProductManager productmanager = new ProductManager("BangazonTestDB");
            CustomerManager customerManager = new CustomerManager("BangazonTestDB");
            Customer newCust = customerManager.Add(_customer2);
            customerManager.ActivateCustomer(newCust.Id);
            Product _product2 = new Product(
                customerManager.ActiveCustomer.Id,
                45.27,
                "Movie",
                "Instructional Film about See Sherp",
                8,
                0,
                dt
            );
            List<Product> listProduct = productmanager.GetAllProducts();
            bool movieExists = false;
            foreach (Product p in listProduct)
            {
                if (p.Name == "Movie")
                {
                    movieExists = true;
                }
            }
            Assert.True(movieExists);
        }

        [Fact]
        public void RemoveProduct()
        {
            ProductManager productmanager = new ProductManager("BangazonTestDB");
            productmanager.Add(_product);
            List<Product> listProduct = productmanager.GetAllProducts();

            productmanager.RemoveSingleProduct(_product);

            Assert.DoesNotContain(_product, listProduct);
        }

        [Fact]
        public void UpdateProduct()
        {
            ProductManager productManager = new ProductManager("BangazonTestDB");
            CustomerManager customerManager = new CustomerManager("BangazonTestDB");
            Customer newCust = customerManager.Add(_customer2);
            customerManager.ActivateCustomer(newCust.Id);
            Product _product2 = new Product(
                customerManager.ActiveCustomer.Id,
                45.27,
                "Movie",
                "Instructional Film about See Sherp",
                8,
                0,
                dt
            );
            Product newProd = productManager.Add(_product2);
            List<Product> listProduct = productManager.GetAllProducts();

            productManager.UpdateSingleProduct(_product);

            Assert.Equal(1, _product.Id);
        }

        // [Fact]
        // public void CreateProductOrderJoin () {
        //     ProductManager productmanager = new ProductManager ("BangazonTestDB");
        //     CustomerManager customerManager = new CustomerManager
        //     productmanager.Add (_product);
        //     List<Product> listProduct = productmanager.GetAllProducts ();
        //     Assert.Contains (_product, listProduct);
        // }
    }
}