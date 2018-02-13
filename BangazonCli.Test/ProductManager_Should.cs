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
        public void FilterProduct_Should()
        {
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
            List<Product> filteredList = productmanager.FilteredProducts(customerManager.ActiveCustomer.Id, listProduct);
            
            foreach (Product p in filteredList)
            {
                Assert.Equal(p.CustomerId, customerManager.ActiveCustomer.Id);
            }
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
        public void addProductToOrder()
        {
            CustomerManager customerManager = new CustomerManager("BangazonTestDB");
            ProductManager productManager = new ProductManager("BangazonTestDB");
            OrderManager orderManager = new OrderManager("BangazonTestDB");


            Customer newCust = customerManager.Add(_customer2);
            customerManager.ActivateCustomer(newCust.Id);

            Order newOrder = new Order(
                customerManager.ActiveCustomer.Id,
                dt

            );
            Order newestOrder = orderManager.StoreOrder(newOrder);

            Product _product2 = new Product(
                    customerManager.ActiveCustomer.Id,
                    45.27,
                    "Movie",
                    "Instructional Film about See Sherp",
                    8,
                    0,
                    dt
                );

            Product newProduct = productManager.Add(_product2);

            ProductOrderJoin newPOJ = new ProductOrderJoin(
                newestOrder.Id,
                newProduct.Id
            );

            ProductOrderJoin freshPOJ = productManager.storeProductOrderJoin(newPOJ);

            Assert.Equal(newestOrder.Id, freshPOJ.OrderId);

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
            List<Product> listProduct = productManager.GetAllProducts();
            List<Product> filteredList = productManager.FilteredProducts(customerManager.ActiveCustomer.Id, listProduct);
            Product productToEdit = productManager.GetSingleProduct(2);
            Product updatedProduct1 = productManager.UpdatePrice(productToEdit, 38.99);
            Product updatedProduct2 = productManager.UpdateTitle(productToEdit, "Bonkers");
            Product updatedProduct3 = productManager.UpdateDescription(productToEdit, "Cows are Nuts");
            Product updatedProduct4 = productManager.UpdateQuantity(productToEdit, 2);
                                    

            Assert.Equal(38.99, updatedProduct1.Price);
            Assert.Equal("Bonkers", updatedProduct2.Name);
            Assert.Equal("Cows are Nuts", updatedProduct3.Description);
            Assert.Equal(2, updatedProduct4.Quantity);
                                    

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