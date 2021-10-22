using System;

namespace API.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string CreditCard { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string PastPurchases { get; set; }
<<<<<<< HEAD
        public string Status { get; set; }
=======
        public string Status {  get; set; } 
>>>>>>> 44b01e3e13f31688109179f92188febf5336ff1a
    }
}