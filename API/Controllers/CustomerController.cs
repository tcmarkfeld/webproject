using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.database;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/Customer
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Customer> Get()
        {
            ICustomerDataHandler dataHandler = new CustomerDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Customer/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetCustomer")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Customer/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
