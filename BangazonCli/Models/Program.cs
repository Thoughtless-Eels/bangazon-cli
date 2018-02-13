using System;
using System.Collections.Generic;
using BangazonCli;
using BangazonCli.Menu;


namespace BangazonCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You can do anything you want");

            Console.WriteLine ("*********************************************************");            
            Console.WriteLine ("****************************************************** **");
            Console.WriteLine ("*      ****      ****  *******      ******    ****  *  **");
            Console.WriteLine ("*  ********  ********  *******  **********  ** ***  *****");
            Console.WriteLine ("*      ****      ****  *******      ******  *** **  *****");
            Console.WriteLine ("*  ********  ********  ***********  ******  **** *  *****");
            Console.WriteLine ("*      ****      ****       **      ******  *****   *****");
            Console.WriteLine ("*********************************************************");
            Console.WriteLine ("**********     ****      *****  ******  ********      ***");
            Console.WriteLine ("**********  **  ***  ********  *  ****  ********  *******");
            Console.WriteLine ("**********  ***  **      ***       ***  ********      ***");
            Console.WriteLine ("**********  **  ***  ******  *****  **  ************  ***");
            Console.WriteLine ("**********    *****      *  *******  *        **      ***");
            Console.WriteLine ("*********************************************************");
            Console.Clear();
            
            
            
                                                                

            int menuSelection;
            ProductManager productManager = new ProductManager("BangazonDB");
            OrderManager orderManager = new OrderManager("BangazonDB");
            CustomerManager customerManager = new CustomerManager("BangazonDB");
            PaymentTypeManager paymentTypeManager = new PaymentTypeManager("BangazonDB");

            do
            {
                menuSelection = MainMenu.Show();

                switch(menuSelection)
                {
                    case 1:

                        // Create Customer 

                        Console.WriteLine("Enter customer name");
                        string custName = Console.ReadLine();
                        Console.WriteLine("Enter street address");
                        string streetAddress = Console.ReadLine();
                        Console.WriteLine("Enter city");
                        string custCity = Console.ReadLine();
                        Console.WriteLine("Enter state");
                        string custState= Console.ReadLine();
                        Console.WriteLine("Enter postal code");
                        string custPostalCode = Console.ReadLine();
                        Console.WriteLine("Enter phone number");
                        string custPhone = Console.ReadLine();
                        
                        var names = custName.Split(' ');
                        string firstName = names[0];
                        string lastName = names[1];


                        Customer newCust = new Customer(
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

                        Customer newestCustomer = customerManager.Add(newCust);

                        Console.WriteLine($"Customer {newestCustomer.FirstName} {newestCustomer.LastName} created successfully, press any key to continue");
                        Console.ReadKey();
                        
                        break;
                    case 2:
                        //choose active customer

                        List<Customer> customers = customerManager.GetAllCustomers();
                        Console.WriteLine("Which customer will be active?");
                        customers.ForEach(c => Console.WriteLine($"{c.Id}. {c.FirstName} {c.LastName}"));
                        int custToActivate = Convert.ToInt32(Console.ReadLine());
                        customerManager.ActivateCustomer(custToActivate);
                        Console.WriteLine($"{customerManager.ActiveCustomer.FirstName} {customerManager.ActiveCustomer.LastName} has been set to active, press any key to continue");
                        Console.ReadKey();

                        break;
                    case 3:
                        //create payment option
                        if (customerManager.ActiveCustomer.Id != 0) 
                        {
                            Console.WriteLine("Enter Payment Type (e.g. AMEX, VISA, MC, ect.)");
                            string paymentType = Console.ReadLine();
                            Console.WriteLine("Account Number");
                            string accountNumber = Console.ReadLine();
                            PaymentType newPaymentType = new PaymentType(
                                paymentType,
                                accountNumber,
                                customerManager.ActiveCustomer.Id
                            );
                            PaymentType newestPaymentType = paymentTypeManager.AddPaymentType(newPaymentType);

                            Console.WriteLine($"{newestPaymentType.Name} #{newestPaymentType.AccountNumber} created for {customerManager.ActiveCustomer.FirstName} {customerManager.ActiveCustomer.LastName}, press any key to continue");
                            Console.ReadKey();

                        } else 
                        {
                            Console.WriteLine("Please set a customer to active before creating a payment type, press any key to return to the main menu");
                            Console.ReadKey();
                        }

                        break;
                    case 4:
                        //add product to active customer

                        if (customerManager.ActiveCustomer.Id != 0)
                        {
                            Console.WriteLine("Enter Product Name");
                            string productName = Console.ReadLine();
                            Console.WriteLine("Enter Product Description");
                            string productDescription = Console.ReadLine();
                            Console.WriteLine("Enter Product Price (ex: 14.99)");
                            double productPrice = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter number of available units");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Is the information entered correct? (y/n)");
                            string answer = Console.ReadLine();

                            if (answer == "y" || answer == "Y")
                            {
                                Product newProduct = new Product(
                                    customerManager.ActiveCustomer.Id,
                                    productPrice,
                                    productName,
                                    productDescription,
                                    quantity,
                                    0,
                                    DateTime.Now
                                );

                                Product newestProduct = productManager.Add(newProduct);

                                Console.WriteLine($"{customerManager.ActiveCustomer.FirstName}'s {newestProduct.Name} was succesfully added to the system, press any key to continue");
                                Console.ReadKey();
                            }
                        } else
                        {
                            Console.WriteLine("Please set a customer to active before creating a product, press any key to return to the main menu");
                            Console.ReadKey(); 
                        }

                        break;
                    case 5:
                        
                        if (customerManager.ActiveCustomer.Id != 0)
                        {
                            Console.Clear();
                            List<Product> allProducts = productManager.GetAllProducts();
                            List<Product> activeCustProducts = productManager.FilteredProducts(customerManager.ActiveCustomer.Id, allProducts);
                            foreach (Product p in activeCustProducts)
                            {
                                Console.WriteLine($"{p.Id}. {p.Name}");
                            }
                            Console.WriteLine("Select a product to edit");
                            int productId= Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Product productToEdit = productManager.GetSingleProduct(productId);
                            Console.WriteLine($"1.Change title '{productToEdit.Name}'");
                            Console.WriteLine($"2.Change description '{productToEdit.Description}'");
                            Console.WriteLine($"3.Change price '{productToEdit.Price}'");
                            Console.WriteLine($"4.Change quantity '{productToEdit.Quantity}'");
                            Console.WriteLine("Please choose the item to edit");
                            int editChoice = Convert.ToInt32(Console.ReadLine());
                            if (editChoice == 1)
                            {
                                Console.WriteLine("Enter new title");
                                string newTitle = Console.ReadLine();
                                Product updatedProduct = productManager.UpdateTitle(productToEdit, newTitle);
                                Console.WriteLine($"Name updated to {newTitle} from {productToEdit.Name} for {customerManager.ActiveCustomer.FirstName}'s {updatedProduct.Name}, press any key to continue");
                                Console.ReadKey();


                            } else if (editChoice == 2)
                            {
                                Console.WriteLine("Enter new description");
                                string newDescription = Console.ReadLine();
                                Product updatedProduct = productManager.UpdateDescription(productToEdit, newDescription);
                                Console.WriteLine($"Description updated to {newDescription} from {productToEdit.Description} for {customerManager.ActiveCustomer.FirstName}'s {updatedProduct.Name}, press any key to continue");
                                Console.ReadKey();
                                
                                
                            } else if (editChoice == 3)
                            {
                                Console.WriteLine("Enter new price");
                                double newPrice = Convert.ToDouble(Console.ReadLine());
                                Product updatedProduct = productManager.UpdatePrice(productToEdit, newPrice);
                                Console.WriteLine($"Price updated to {newPrice} from {productToEdit.Price} for {customerManager.ActiveCustomer.FirstName}'s {updatedProduct.Name}, press any key to continue");
                                Console.ReadKey();

                            } else if (editChoice == 4)
                            {
                                Console.WriteLine("Enter new quantity");
                                int quantity = Convert.ToInt32(Console.ReadLine());
                                Product updatedProduct = productManager.UpdateQuantity(productToEdit, quantity);
                                Console.WriteLine($"Quantity updated to {quantity} from {productToEdit.Quantity} for {customerManager.ActiveCustomer.FirstName}'s {updatedProduct.Name}, press any key to continue");
                                Console.ReadKey();                      
                            }                                                           

                        } else 
                        {
                            Console.WriteLine("Please set a customer to active before updating a product, press any key to return to the main menu");
                            Console.ReadKey(); 
                        }

                        break;
                    case 6:
                        //add product to shopping to cart

                        if (customerManager.ActiveCustomer.Id != 0)
                        {
                            int activeOrderCheck = orderManager.ActiveCustOrderCheck(customerManager.ActiveCustomer.Id);
                            if (activeOrderCheck == 0)
                            {
                                Order newOrder = new Order(
                                    customerManager.ActiveCustomer.Id,
                                    0,
                                    DateTime.Now
                                );

                                Order newestOrder = orderManager.StoreOrder(newOrder);
                                List<Product> products = productManager.GetAllProducts();
                                double numberOfProducts = products.Count;
                                double listLength = numberOfProducts + 1;
                                double lastId = 0;
                                double selection = 0;

                                do 
                                {
                                    for (int i = 0; i < listLength; i++)
                                    {
                                        if (i != numberOfProducts)
                                        {
                                            double currentNumb = i +1;
                                            Product currentProd = products[i];
                                            Console.WriteLine($"{currentProd.Id}. {currentProd.Name}");
                                            lastId = currentProd.Id;

                                        } else 
                                        {
                                            double lastNumb = lastId + 1;
                                            Console.WriteLine($"{lastNumb}. Done Adding Products? Return to Main Menu");
                                        }
                                    }

                                    Console.WriteLine("Select a Product to Add to Cart");
                                    selection = Convert.ToDouble(Console.ReadLine());

                                    if (selection < lastId && selection > 0)
                                    {
                                        int intCopy = Convert.ToInt32(selection);
                                        ProductOrderJoin newPOj = new ProductOrderJoin(
                                            newestOrder.Id,
                                            intCopy
                                        );

                                        Console.WriteLine("Product added successfully, press any key to continue");
                                        Console.ReadKey();
                                    }   

                                } while (selection != lastId + 1);



                            } else 
                            {

                            }


                        } else 
                        {
                            Console.WriteLine("Please set a customer to active before using shopping cart, press any key to return to the main menu");
                            Console.ReadKey(); 
                        }


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
