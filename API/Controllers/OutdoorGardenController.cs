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
    public class OutdoorGardenController : ControllerBase
    {
        // GET: api/OutdoorGarden
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<OutdoorGarden> Get()
        {
            IOutdoorGardenDataHandler dataHandler = new OutdoorGardenDataHandler();
            return dataHandler.Select();
        }

        // GET: api/OutdoorGarden/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetOutdoorGarden")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OutdoorGarden
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/OutdoorGarden/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/OutdoorGarden/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
