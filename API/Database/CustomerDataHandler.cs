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
            string stm = $@"DELETE FROM customer WHERE customerid = {customer.CustomerID}";
            db.Delete(stm);
        }

        public void Insert(Customer customer)
        {
            string stm = @"INSERT INTO customer(customerid,firstname,lastname,birthdate,email,creditcard,shippingaddress,billingaddress,pastPurchases,status) VALUES(@id,@fn,@ln,@bd,@email,@cc,@sa,@ba,@pp,@status)";
            db.Open();
            Dictionary<string,object> fields = new Dictionary<string, object>();
            fields.Add("@id",customer.CustomerID);
            fields.Add("@fm",customer.FirstName);
            fields.Add("@ln",customer.LastName);
            fields.Add("@bd",customer.Birthdate);
            fields.Add("@email",customer.Email);
            fields.Add("@cc",customer.CreditCard);
            fields.Add("@sa",customer.ShippingAddress);
            fields.Add("@ba",customer.BillingAddress);
            fields.Add("@pp",customer.PastPurchases);
            fields.Add("@status",customer.Status);
            db.Insert(stm,fields);
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
            string stm = @"UPDATE customer SET firstname = @fn, lastname = @ln, birthdate = @bd, email = @email, creditcard = @cc, shippingaddress = @sa, billingaddress = @ba, pastPurchases = @pp, status = @status WHERE customerid = @id";
            db.Open();
            Dictionary<string,object> fields = new Dictionary<string, object>();
            fields.Add("@id",customer.CustomerID);
            fields.Add("@fm",customer.FirstName);
            fields.Add("@ln",customer.LastName);
            fields.Add("@bd",customer.Birthdate);
            fields.Add("@email",customer.Email);
            fields.Add("@cc",customer.CreditCard);
            fields.Add("@sa",customer.ShippingAddress);
            fields.Add("@ba",customer.BillingAddress);
            fields.Add("@pp",customer.PastPurchases);
            fields.Add("@status",customer.Status);
            db.Update(stm,fields);
            db.Close();
        }
    }
}