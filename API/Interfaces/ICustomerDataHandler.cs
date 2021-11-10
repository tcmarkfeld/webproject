using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface ICustomerDataHandler
    {
        public List<Customer> Select();
        public List<Customer> SelectEmail(string email);
        public void Delete(int id);
        public void Insert(Customer customer);
        public void Update(Customer customer);
    }
}