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
    public class AdminController : ControllerBase
    {
        // GET: api/Admin
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Admin> Get()
        {
            IAdminDataHandler dataHandler = new AdminDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Admin/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{email}", Name = "GetAdmin")]
        public List<Admin> Get(string email)
        {
            IAdminDataHandler dataHandler = new AdminDataHandler();
            return dataHandler.SelectEmail(email);
        }

        // POST: api/Admin
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Admin value)
        {
            value.DataHandler.Insert(value);
        }

        // PUT: api/Admin/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Admin value)
        {
            value.DataHandler.Update(value);
        }

        // DELETE: api/Admin/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IAdminDataHandler dataHandler = new AdminDataHandler();
            dataHandler.Delete(id);
        }
    }
}
