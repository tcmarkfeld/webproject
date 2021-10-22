using System.Collections.Generic;
using System.Dynamic;
using API.Interfaces;
using API.Models;

namespace API.database
{
    public class CustomerDataHandler : ICustomerDataHandler
    {
        private Database db { get; set; }
        public CustomerDataHandler()
        {
            db = new Database();
        }
        public void Delete(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> Select()
        {
            List<Customer> myCustomer = new List<Customer>();

            string stm = @"SELECT * from customer";
            db.Open();
            List<ExpandoObject> results = db.Select(stm);

            foreach (dynamic item in results)
            {
                Customer temp = new Customer()
                {
                    CustomerID = item.customerid,
                    FirstName = item.firstname,
                    LastName = item.lastname,
                    Birthdate = item.birthdate,
                    Email = item.email,
                    CreditCard = item.creditcard,
                    ShippingAddress = item.shippingaddress,
                    BillingAddress = item.billingaddress,
                    PastPurchases = item.pastPurchases,
<<<<<<< HEAD
                    Status = item.status
=======
                    Status = item.Status
>>>>>>> 44b01e3e13f31688109179f92188febf5336ff1a
                };
                myCustomer.Add(temp);
            }
            db.Close();
            return myCustomer;
        }

        public void Update(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}