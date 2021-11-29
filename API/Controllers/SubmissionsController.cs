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
    public class SubmissionsController : ControllerBase
    {
        // GET: api/Submissions
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Submissions> Get()
        {
            ISubmissionsDataHandler dataHandler = new SubmissionsDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Submissions/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetSubmissions")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Submissions
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Submissions value)
        {
            value.DataHandler.Insert(value);
        }

        // PUT: api/Submissions/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Submissions value)
        {
            value.DataHandler.Update(value);
        }

        // DELETE: api/Submissions/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ISubmissionsDataHandler dataHandler = new SubmissionsDataHandler();
            dataHandler.Delete(id);
        }
    }
}
