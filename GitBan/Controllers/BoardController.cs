using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GitBan.Controllers
{
    public class BoardController : ApiController
    {
        // GET api/board
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/board/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/board
        public void Post(string value)
        {
        }

        // PUT api/board/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/board/5
        public void Delete(int id)
        {
        }
    }
}
