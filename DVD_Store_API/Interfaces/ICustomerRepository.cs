using DVD_Store_API.Models;

namespace DVD_Store_API.Interfaces
{
    public interface ICustomerRepository
    {
        public ICollection<Customer> GetCustomers();
        public Customer GetCustomer(int id);
        public int GetCustomerId(string name);
        public bool Exists(int id);
        public bool Exists(string Name);
        public void AddCustomer(Customer customer);
        public void UpdateCustomer(int id, Customer customer);
        public void DeleteCustomer(Customer customer);
    }
}
