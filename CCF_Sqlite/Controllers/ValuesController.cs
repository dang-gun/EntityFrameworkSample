using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ModelDB;
using CCF_Sqlite.Global;

namespace CCF_Sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 모든 리스트를 반환 한다.
        /// GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get()
        {
            List<TestUser> tuList = new List<TestUser>();

            using (CoreCodeFirstContext db1 = new CoreCodeFirstContext())
            {
                //유저 검색
                tuList
                    = db1.TestUser
                        .ToList();
            }

            return new JsonResult(tuList);
        }

        /// <summary>
        /// 지정한 아이디를 리턴한다.
        /// GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
