using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Theta.Customers.Models;


namespace Theta.Customers.Repository
{
    public class CustomerRepos
    {
        public CustomerRepos()
        {

        }

        private IMongoCollection<Customer> Initialize()
        {
            var client = new MongoClient("yourconnection string");
            var database = client.GetDatabase("CustomersDB");
            var collection = database.GetCollection<Customer>("Customers");
            return collection;
        }

        public List<Customer> GetCustomer(int customerID)
        {
            IMongoCollection<Customer> collection = Initialize();
            var Dbcustomer = collection.Find<Customer>(x => x._id == customerID);
            return Dbcustomer.ToList();
        }
        public List<Customer> GetAllCustomers()
        {
            IMongoCollection<Customer> collection = Initialize();
            var Dbcustomer = collection.Find(x => true);
            return Dbcustomer.ToList();
        }

        public long DeleteCustomer(int customerID)
        {
            IMongoCollection<Customer> collection = Initialize();
            var result = collection.DeleteOne<Customer>(x => x._id == customerID);
            return result.DeletedCount;
        }
    }
}
