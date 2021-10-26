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
    public class HealthCalculatorController : ControllerBase
    {
        // GET: api/HealthCalculator
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<HealthCalculator> Get()
        {
            IHealthCalculatorDataHandler dataHandler = new HealthCalculatorDataHandler();
            return dataHandler.Select();
        }

        // GET: api/HealthCalculator/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetHealthCalculator")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HealthCalculator
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] HealthCalculator value)
        {
            value.DataHandler.Insert(value);
        }

        // PUT: api/HealthCalculator/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] HealthCalculator value)
        {
            value.DataHandler.Update(value);
        }

        // DELETE: api/HealthCalculator/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IHealthCalculatorDataHandler dataHandler = new HealthCalculatorDataHandler();
            dataHandler.Delete(id);
        }
    }
}
