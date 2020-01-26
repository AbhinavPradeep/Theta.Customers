using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Theta.Customers.API.Configuration;
using Theta.Customers.Models;
using Theta.Customers.Repository;




namespace Theta.Customers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        IOptions<CustomerSettings> settings;
        public CustomersController(IOptions<CustomerSettings> settings)
        {
            this.settings = settings;
        }

        [HttpGet]
        public JsonResult ListPeople()
        {
            CustomerRepos CustomerRepo = new CustomerRepos(settings.Value.ConnectionString);
            var customers = CustomerRepo.GetAllCustomers();
            return new JsonResult(customers);
            
        }

        [HttpGet("{personID}")]
        public List<Customer> ListCustomer(int customerID)
        {
            CustomerRepos CustomerRepo = new CustomerRepos(settings.Value.ConnectionString);
            var customer = CustomerRepo.GetCustomer(customerID);
            return customer;

        }
        [HttpDelete("{personID}")]
        public long DeleteCustomer(int customerID)
        {
            CustomerRepos CustomerRepo = new CustomerRepos(settings.Value.ConnectionString);
            var DeletedCount = CustomerRepo.DeleteCustomer(customerID);
            return DeletedCount;
        }

    }
}
