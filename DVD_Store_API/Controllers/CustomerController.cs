using DVD_Store_API.Exceptions;
using DVD_Store_API.Interfaces;
using DVD_Store_API.Models;
using DVD_Store_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DVD_Store_API.Controllers
{
    [Route("api/controllers")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpPost]
        [Route("/Customers/Add/Name")]
        public ActionResult AddCustomer(string Name)
        {
            try
            {
                Customer customer = new Customer();
                customer.Name = Name;
                customer.JoinedDate = DateTime.Now;
                customerRepository.AddCustomer(customer);

                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("/Customers/Del/id")]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                Customer customer = customerRepository.GetCustomer(id);
                customerRepository.DeleteCustomer(customer);
                return Ok();
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("Customer/Upd/id/NewName")]
        public ActionResult UpdateCustomer(int id, string NewName)
        {
            try
            {
                Customer OldCustomer = customerRepository.GetCustomer(id);
                Customer customer=new Customer();
                customer.Name = NewName;
                customer.JoinedDate = OldCustomer.JoinedDate;
                customerRepository.UpdateCustomer(id, customer);

                return Ok();
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("/Customers/get/all")]
        public ActionResult<ICollection<Customer>> GetCustomers()
        {
            try
            {
                ICollection<Customer> customers = customerRepository.GetCustomers();

                return Ok(customers);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("/Customers/get/id")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            try
            {
                Customer customer = customerRepository.GetCustomer(id);

                return Ok(customer);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
