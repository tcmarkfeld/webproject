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
    public class PlantInformationController : ControllerBase
    {
        // GET: api/PlantInformation
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<PlantInformation> Get()
        {
            IPlantInformationDataHandler dataHandler = new PlantInformationDataHandler();
            return dataHandler.Select();
        }

        // GET: api/PlantInformation/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetPlantInformation")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PlantInformation
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/PlantInformation/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/PlantInformation/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
