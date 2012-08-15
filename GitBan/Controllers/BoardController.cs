using System.Collections.Generic;
using System.Web.Http;
using GitBan.Models;

namespace GitBan.Controllers
{
    public class BoardController : ApiController, IAuthenticatedController
    {
        public User CurrentUser { get; set; }
        public IGitBanDataContext CurrentDataContext { get; set; }

        public BoardController(IGitBanDataContext dataContext)
        {
            CurrentDataContext = dataContext;
        }

        // GET api/board
        public IEnumerable<string> Get() 
        {
            return new[] { "value1", "value2" };
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
