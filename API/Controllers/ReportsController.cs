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
    public class ReportsController : ControllerBase
    {
        // GET: api/Reports
        [HttpGet]
        public List<Reports> Get()
        {
            IReportsDataHandler dataHandler = new ReportsDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Reports/5
        [HttpGet("{id}", Name = "GetReports")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reports
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Reports/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Reports/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
