using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateGardenController : ControllerBase
    {
        // GET: api/CorporateGarden
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CorporateGarden/5
        [HttpGet("{id}", Name = "GetCorporateGarden")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CorporateGarden
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CorporateGarden/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/CorporateGarden/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
