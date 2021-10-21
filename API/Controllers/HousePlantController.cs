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
    public class HousePlantController : ControllerBase
    {
        // GET: api/HousePlant
        [HttpGet]
        public List<HousePlant> Get()
        {
            IHousePlantDataHandler dataHandler = new HousePlantDataHandler();
            return dataHandler.Select();
        }

        // GET: api/HousePlant/5
        [HttpGet("{id}", Name = "GetHousePlant")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HousePlant
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HousePlant/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/HousePlant/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
