using System.Web.Mvc;
using GitBan.Infrastructure;
using GitBan.Models;

namespace GitBan.Controllers
{
    public class ProjectsController : Controller, IAuthenticatedController
    {
        private readonly IGitHubAdapter _gitHub;
        public User CurrentUser { get; set; }
        public IGitBanDataContext CurrentDataContext { get; set; }

        public ProjectsController(IGitBanDataContext dataContext, IGitHubAdapter gitHubAdapter)
        {
            CurrentDataContext = dataContext;
            _gitHub = gitHubAdapter;
        }

        public ActionResult Index()
        {
            var projects = _gitHub.GetRepos(CurrentUser.AccessToken);
            return View(projects);
        }

        public ActionResult Board(string id)
        {
            return View();
        }
    }
}
