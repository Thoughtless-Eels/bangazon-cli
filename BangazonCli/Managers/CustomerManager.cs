using System.Collections.Generic;
using System.Linq;



namespace BangazonCli
{
    public class CustomerManager
    {
        public List<Customer> _customerTable = new List<Customer>();

        public int ActiveCustomerId;

        public void Add(Customer monkeybutt)
        {
            _customerTable.Add(monkeybutt);
        }
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