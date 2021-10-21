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
    public class PlantInformationController : ControllerBase
    {
        // GET: api/PlantInformation
        [HttpGet]
        public List<PlantInformation> Get()
        {
            IPlantInformationDataHandler dataHandler = new PlantInformationDataHandler();
            return dataHandler.Select();
        }

        // GET: api/PlantInformation/5
        [HttpGet("{id}", Name = "GetPlantInformation")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PlantInformation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/PlantInformation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/PlantInformation/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
