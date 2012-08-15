using System;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using GitBan.Controllers;
using GitBan.Models;

namespace GitBan
{
    public class SetCurrentUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authenticatedController = filterContext.Controller as IAuthenticatedController;
            if (authenticatedController != null)
            {
                var currentUser = GetCurrentUser(authenticatedController.CurrentDataContext);
                if (currentUser == null)
                {
                    FormsAuthentication.SignOut();
                    filterContext.Result = new RedirectResult("Index/Home");
                }
                else
                {
                    authenticatedController.CurrentUser = currentUser;
                }
            }
            base.OnActionExecuting(filterContext);
        }

        private static User GetCurrentUser(IGitBanDataContext dataContext)
        {
            int userId;
            return Int32.TryParse(Thread.CurrentPrincipal.Identity.Name, out userId) ? dataContext.Users.SingleOrDefault(x => x.Id == userId) : null;
        }
    }
}