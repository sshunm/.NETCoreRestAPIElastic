using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticSearchRestAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Nest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElasticSearchRestAPI.Controller
{
    [Route("api/[controller]")]
    public class AlarmController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("alarms");

            var client = new ElasticClient(settings);
            //return new string[] { "value1", "value2" };
            var searchResponse = client.Search<Alarm>(s => s
                .Query(q => q
                    //.MatchAll()
                    .DateRange(r => r
                        .Field(f => f.datetime)
                        .GreaterThanOrEquals("20190118T101000Z")
                        )
                )
            );
            return Ok(searchResponse.Documents);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
