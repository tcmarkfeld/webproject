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
    public class HealthCalculatorController : ControllerBase
    {
        // GET: api/HealthCalculator
        [HttpGet]
        public List<HealthCalculator> Get()
        {
            IHealthCalculatorDataHandler dataHandler = new HealthCalculatorDataHandler();
            return dataHandler.Select();
        }

        // GET: api/HealthCalculator/5
        [HttpGet("{id}", Name = "GetHealthCalculator")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HealthCalculator
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HealthCalculator/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/HealthCalculator/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
