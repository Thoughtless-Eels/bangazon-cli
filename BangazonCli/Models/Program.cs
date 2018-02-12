using System;
using BangazonCli;
using BangazonCli.Menu;
using System.Collections.Generic;

namespace BangazonCli {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("You can do anything you want");
            Console.Clear ();
            Console.Beep ();


            int menuSelection;
            ProductManager productManager = new ProductManager ("BangazonDB");
            CustomerManager customerManager = new CustomerManager ("BangazonDB");
            PaymentTypeManager paymentTypeManager = new PaymentTypeManager ("BangazonDB");

            do {
                menuSelection = MainMenu.Show ();

                switch (menuSelection) {
                    case 1:

                        // Create Customer 

                        Console.WriteLine ("Enter customer name");
                        string custName = Console.ReadLine ();
                        Console.WriteLine ("Enter street address");
                        string streetAddress = Console.ReadLine ();
                        Console.WriteLine ("Enter city");
                        string custCity = Console.ReadLine ();
                        Console.WriteLine ("Enter state");
                        string custState = Console.ReadLine ();
                        Console.WriteLine ("Enter postal code");
                        string custPostalCode = Console.ReadLine ();
                        Console.WriteLine ("Enter phone number");
                        string custPhone = Console.ReadLine ();

                        var names = custName.Split (' ');
                        string firstName = names[0];
                        string lastName = names[1];

                        Customer newCust = new Customer (
                            firstName,
                            lastName,
                            streetAddress,
                            custCity,
                            custState,
                            custPostalCode,
                            custPhone,
                            DateTime.Now,
                            DateTime.Now
                        );

                        Customer newestCustomer = customerManager.Add (newCust);

                        Console.WriteLine ($"Customer {newestCustomer.FirstName} {newestCustomer.LastName} created successfully, press any key to continue");
                        Console.ReadKey ();

                        break;
                    case 2:
                        //choose active customer

                        List<Customer> customers = customerManager.GetAllCustomers ();
                        Console.WriteLine ("Which customer will be active?");
                        customers.ForEach (c => Console.WriteLine ($"{c.Id}. {c.FirstName} {c.LastName}"));
                        int custToActivate = Convert.ToInt32 (Console.ReadLine ());
                        customerManager.ActivateCustomer (custToActivate);
                        Console.WriteLine ($"{customerManager.ActiveCustomer.FirstName} {customerManager.ActiveCustomer.LastName} has been set to active, press any key to continue");
                        Console.ReadKey ();

                        break;
                    case 3:
                        //create payment option
                        if (customerManager.ActiveCustomer.Id != 0) {
                            Console.WriteLine ("Enter Payment Type (e.g. AMEX, VISA, MC, ect.)");
                            string paymentType = Console.ReadLine ();
                            Console.WriteLine ("Account Number");
                            string accountNumber = Console.ReadLine ();
                            PaymentType newPaymentType = new PaymentType (
                                paymentType,
                                accountNumber,
                                customerManager.ActiveCustomer.Id
                            );
                            PaymentType newestPaymentType = paymentTypeManager.AddPaymentType (newPaymentType);

                            Console.WriteLine ($"{newestPaymentType.Name} #{newestPaymentType.AccountNumber} created for {customerManager.ActiveCustomer.FirstName} {customerManager.ActiveCustomer.LastName}, press any key to continue");
                            Console.ReadLine ();

                        } else {
                            Console.WriteLine ("Please set a customer to active before creating a payment type, press any key to return to the main menu");
                            Console.ReadLine ();
                        }

                        break;
                    case 4:
                        //add product to active customer

                        if (customerManager.ActiveCustomer.Id != 0) {
                            Console.WriteLine ("Enter Product Name");
                            string productName = Console.ReadLine ();
                            Console.WriteLine ("Enter Product Description");
                            string productDescription = Console.ReadLine ();
                            Console.WriteLine ("Enter Product Price (ex: 14.99)");
                            double productPrice = Convert.ToDouble (Console.ReadLine ());
                            Console.WriteLine ("Enter number of available units");
                            int quantity = Convert.ToInt32 (Console.ReadLine ());
                            Console.WriteLine ("Is the information entered correct? (y/n)");
                            string answer = Console.ReadLine ();

                            if (answer == "y" || answer == "Y") {
                                Product newProduct = new Product (
                                    customerManager.ActiveCustomer.Id,
                                    productPrice,
                                    productName,
                                    productDescription,
                                    quantity,
                                    0,
                                    DateTime.Now
                                );

                                Product newestProduct = productManager.Add (newProduct);

                                Console.WriteLine ($"{customerManager.ActiveCustomer.FirstName}'s {newestProduct.Name} was succesfully added to the system, press any key to continue");
                                Console.ReadLine ();
                            }
                        } else {
                            Console.WriteLine ("Please set a customer to active before creating a product, press any key to return to the main menu");
                            Console.ReadLine ();
                        }

                        break;
                    case 5:
                        //update active customers product

                        break;
                    case 6:
                        //add product to shopping to cart

                        break;
                    case 7:
                        //complete an order

                        break;
                    case 8:
                        //view reports

                        break;
                    case 9:
                        //Leave Bangazon

                        break;
                }
            } while (menuSelection < 10 & menuSelection > 0);
        }
    }
}