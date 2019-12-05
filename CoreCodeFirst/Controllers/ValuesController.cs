using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCodeFirst.Global;
using CoreCodeFirst.ModelDB;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private CoreCodeFirstContext DB 
            = new CoreCodeFirstContext(GlobalStatic.DBMgr.DbContext().Options);

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<TestUser> tuList
                = this.DB.TestUser
                    .Where(m => m.idTestUser > 0)
                    .ToList();

            return new string[] { "value1", tuList.Count().ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
