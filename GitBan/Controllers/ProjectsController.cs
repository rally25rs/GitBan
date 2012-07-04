using System.Web.Mvc;
using GitBan.Infrastructure;

namespace GitBan.Controllers
{
    public class ProjectsController : AuthenticatedController
    {
        private readonly IGitHubAdapter _gitHub;

        public ProjectsController()
        {
            _gitHub = new GitHubAdapter();
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
