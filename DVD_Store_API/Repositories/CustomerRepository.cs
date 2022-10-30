using DVD_Store_API.Data;
using DVD_Store_API.Exceptions;
using DVD_Store_API.Interfaces;
using DVD_Store_API.Models;

namespace DVD_Store_API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<Customer> GetCustomers()
        {
            ICollection<Customer> customers=_dataContext.Customers.OrderBy(p=>p.Name).ToList();
            if (customers.Count <= 0)
                throw new ObjectNotFoundException();
            else
                return customers;
        }
        public Customer GetCustomer(int id)
        {
            if (!Exists(id))
                throw new ObjectNotFoundException();
            else
            {
                Customer? customer = _dataContext.Customers.Where(p => p.Id == id).FirstOrDefault();
                if (customer == null)
                    throw new ObjectNotFoundException();
                else
                    return customer;
            }
        }
        public bool Exists(int id)
        {
            return _dataContext.Customers.Any(p => p.Id == id);
        }
        public bool Exists(string Name)
        {
            return _dataContext.Customers.Any(p => p.Name == Name);
        }
        public int GetCustomerId(string Name)
        {
            if (!Exists(Name))
                throw new ObjectNotFoundException();
            else
            {
                Customer? customer = _dataContext.Customers.Where(p => p.Name == Name).FirstOrDefault();
                if (customer == null)
                    throw new ObjectNotFoundException();
                else
                    return customer.Id;
            }
        }
        public void AddCustomer(Customer customer)
        {
            if (customer.Name != null)
            {
                if (Exists(customer.Name))
                    throw new ObjectAlreadyExists();

                else
                {
                    _dataContext.Customers.Add(customer);
                    _dataContext.SaveChanges();
                }
            }
            else
                throw new Exception();
        }
        public void DeleteCustomer(Customer customer)
        {
            int customerId = customer.Id;
            ICollection<Rent> rents = _dataContext.Rents.Where(p => p.CustomerId == customerId).ToList();
            for (int i = 0; i < rents.Count; i++)
                _dataContext.Rents.Remove(rents.ElementAt(i));
            _dataContext.Customers.Remove(customer);
            _dataContext.SaveChanges();
        }
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!Exists(id))
                throw new ObjectNotFoundException();
            else
            {
                Customer? c = _dataContext.Customers.Where(p => p.Id == id).FirstOrDefault();
                if (c == null)
                    throw new ObjectNotFoundException();
                else
                {
                    c.Name = customer.Name;
                    _dataContext.SaveChanges();
                }
            }
        }
    }
}
