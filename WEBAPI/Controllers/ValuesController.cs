using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
       static List<string> getAll = new List<string>()
        {
            "value1", "value2"
        };
        // GET api/values
        public IEnumerable<string> Get()
        {
            return getAll;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return getAll[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            getAll.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            getAll[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            getAll.RemoveAt(id);
        }
    }
}
