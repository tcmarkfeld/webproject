using System;
using API.database;
using API.Interfaces;

namespace API.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreditCard { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string PastPurchases { get; set; }
        public string Status { get; set; }
        public ICustomerDataHandler DataHandler { get; set; }

        public Customer()
        {
            DataHandler = new CustomerDataHandler();
        }
    }
}