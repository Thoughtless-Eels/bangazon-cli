using System;
using BangazonCli;
using BangazonCli.Menu;


namespace BangazonCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You can do anything you want");

            int menuSelection;
            CustomerManager customerManager = new CustomerManager("BangazonDB");

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
                        
                        break;
                    case 3:
                        //create payment option

                        break;
                    case 4:
                        //add product to active customer

                        break;
                    case 5:
                        //popular items

                        break;
                    case 6:
                        //popular items

                        break;
                    case 7:
                        //popular items

                        break;
                    case 8:
                        //popular items

                        break;
                    case 9:
                        //popular items

                        break;
                }
            } while (menuSelection < 10 & menuSelection > 0);
        }
    }
}
