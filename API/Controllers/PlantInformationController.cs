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
        public List<PlantInformation> Get(int id)
        {
            IPlantInformationDataHandler dataHandler = new PlantInformationDataHandler();
            return dataHandler.SelectID(id);
        }

        // GET: api/PlantInformation/highestid
        [EnableCors("OpenPolicy")]
        [HttpGet("highestid", Name = "highestid")]
        public List<PlantInformation> GetHighestID()
        {
            IPlantInformationDataHandler dataHandler = new PlantInformationDataHandler();
            return dataHandler.SelectHighest();
        }

        // POST: api/PlantInformation
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] PlantInformation value)
        {
            value.DataHandler.Insert(value);
        }

        // PUT: api/PlantInformation/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PlantInformation value)
        {
            value.DataHandler.Update(value);
        }

        // DELETE: api/PlantInformation/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IPlantInformationDataHandler dataHandler = new PlantInformationDataHandler();
            dataHandler.Delete(id);
        }
    }
}
