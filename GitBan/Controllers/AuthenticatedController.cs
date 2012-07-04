using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using GitBan.Models;

namespace GitBan.Controllers
{
    public abstract class AuthenticatedController : Controller
    {
        protected User CurrentUser { get; private set; }
        protected IGitBanDataContext CurrentDataContext { get; private set; }

        protected AuthenticatedController()
        {
            CurrentDataContext = new GitBanDataContext();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = Int32.Parse(User.Identity.Name);
            CurrentUser = CurrentDataContext.Users.SingleOrDefault(x => x.Id == userId);
            ViewBag.CurrentUser = CurrentUser;
            if (CurrentUser == null)
            {
                FormsAuthentication.SignOut();
                RedirectToAction("Index", "Home");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}