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
    public class GardenController : ControllerBase
    {
        // GET: api/Garden
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Garden> Get()
        {
            IGardenDataHandler dataHandler = new GardenDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Garden/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public List<Garden> Get(int id)
        {
            IGardenDataHandler dataHandler = new GardenDataHandler();
            return dataHandler.SelectID(id);
        }

        // POST: api/Garden
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Garden value)
        {
            value.DataHandler.Insert(value);
        }

        // PUT: api/Garden/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Garden value)
        {
            value.DataHandler.Update(value);
        }

        // DELETE: api/Garden/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IGardenDataHandler dataHandler = new GardenDataHandler();
            dataHandler.Delete(id);
        }
    }
}
