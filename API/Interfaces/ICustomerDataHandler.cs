using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface ICustomerDataHandler
    {
        public List<Customer> Select();
        public void Delete(Customer customer);
        public void Insert(Customer customer);
        public void Update(Customer customer);
    }
}