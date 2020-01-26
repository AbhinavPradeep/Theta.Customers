using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Theta.Customers.Models;
using Theta.Customers.Repository;




namespace Theta.Customers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {

        [HttpGet]
        public JsonResult ListPeople()
        {
            CustomerRepos CustomerRepo = new CustomerRepos();
            var customers = CustomerRepo.GetAllCustomers();
            return new JsonResult(customers);
            
        }

        [HttpGet("{personID}")]
        public List<Customer> ListCustomer(int customerID)
        {
            CustomerRepos customerRepos = new CustomerRepos();
            var customer = customerRepos.GetCustomer(customerID);
            return customer;

        }
        [HttpDelete("{personID}")]
        public long DeleteCustomer(int customerID)
        {
            CustomerRepos customerRepos = new CustomerRepos();
            var DeletedCount = customerRepos.DeleteCustomer(customerID);
            return DeletedCount;
        }

    }
}
