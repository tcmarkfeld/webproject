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
    public class ReportsController : ControllerBase
    {
        // GET: api/Reports
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Reports> Get()
        {
            IReportsDataHandler dataHandler = new ReportsDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Reports/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetReports")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reports
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Reports value)
        {
            value.DataHandler.Insert(value);
        }

        // PUT: api/Reports/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Reports value)
        {
            value.DataHandler.Update(value);
        }

        // DELETE: api/Reports/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IReportsDataHandler dataHandler = new ReportsDataHandler();
            dataHandler.Delete(id);
        }
    }
}
