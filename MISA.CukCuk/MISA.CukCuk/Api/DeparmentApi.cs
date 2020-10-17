using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeparmentApi : ControllerBase
    {
        // GET: api/<DeparmentApi>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DeparmentApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeparmentApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DeparmentApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeparmentApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
