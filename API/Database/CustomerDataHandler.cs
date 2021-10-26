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
        public void Delete(int id)
        {
            string stm = $@"DELETE FROM customer WHERE customerid = {id}";

            db.Open();
            db.Delete(stm);
            db.Close();
        }

        public void Insert(Customer customer)
        {
            string stm = @"INSERT INTO customer(customerid,firstname,lastname,birthdate,email,creditcard,shippingaddress,billingaddress,pastPurchases,status) VALUES(@id,@fn,@ln,@bd,@email,@cc,@sa,@ba,@pp,@status)";
            var values = GetValues(customer);

            db.Open();
            db.Insert(stm, values);
            db.Close();
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
                    Status = item.status
                };
                myCustomer.Add(temp);
            }
            db.Close();
            return myCustomer;
        }

        public void Update(Customer customer)
        {
            var values = GetValues(customer);
            string stm = @"UPDATE customer SET firstname = @fn, lastname = @ln, birthdate = @bd, email = @email, creditcard = @cc, shippingaddress = @sa, billingaddress = @ba, pastPurchases = @pp, status = @status WHERE customerid = @id";

            db.Open();
            db.Update(stm, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(Customer customer)
        {
            var values = new Dictionary<string, object>(){
                {"@id", customer.CustomerID},
                {"@fn", customer.FirstName},
                {"@ln", customer.LastName},
                {"@bd", customer.Birthdate},
                {"@email", customer.Email},
                {"@cc", customer.CreditCard},
                {"@sa", customer.ShippingAddress},
                {"@ba", customer.BillingAddress},
                {"@pp", customer.PastPurchases},
                {"@status", customer.Status}
            };

            return values;
        }
    }
}