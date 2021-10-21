using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.database;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // GET: api/Admin
        [HttpGet]
        public List<Admin> Get()
        {
            IAdminDataHandler dataHandler = new AdminDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Admin/5
        [HttpGet("{id}", Name = "GetAdmin")]
        public List<Admin> Get(int id) // not made
        {
            IAdminDataHandler dataHandler = new AdminDataHandler();
            return dataHandler.Select();
        }

        // POST: api/Admin
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
