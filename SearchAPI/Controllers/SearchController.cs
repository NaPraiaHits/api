
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SearchAPI.ElasticSearchCore.Implementation;

namespace SearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IElasticSearch _elastic;

        public SearchController(IElasticSearch elastic)
        {
            _elastic = elastic;
        }            
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var elasticResult = _elastic.Get(1);
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return string.Concat("value: ",id);
        }       
    }
}
