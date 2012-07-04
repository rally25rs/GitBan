using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using GitBan.Infrastructure;
using GitBan.Models;

namespace GitBan.Controllers
{
    public class AuthController : Controller
    {
        private readonly IGitBanDataContext _dataContext;
        private readonly IGitHubAdapter _gitHub;

        public AuthController()
        {
            _dataContext = new GitBanDataContext();
            _gitHub = new GitHubAdapter();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var authCode = Request.Params["code"];
            if (String.IsNullOrEmpty(authCode))
            {
                Logger.LogDebugMessage("No code found.");
                return RedirectToAction("Index", "Home");
            }

            var accessToken = _gitHub.GetAccessToken(authCode);

            if (String.IsNullOrEmpty(accessToken))
            {
                Logger.LogDebugMessage("No access token found.");
                return RedirectToAction("Index", "Home");
            }

            var user = _gitHub.GetUser(accessToken);
            var existingUser = _dataContext.Users.SingleOrDefault(x => x.Id == user.Id);
            if (existingUser != null && existingUser.AccessToken != accessToken)
            {
                existingUser.Name = user.Name;
                existingUser.AccessToken = user.AccessToken;
                existingUser.AvatarUrl = user.AvatarUrl;
            }
            else
            {
                _dataContext.Users.Add(user);
            }
            _dataContext.SaveChanges();

            FormsAuthentication.SetAuthCookie(user.Id.ToString(CultureInfo.InvariantCulture), false);
            return RedirectToAction("Index", "Projects");
        }
    }
}
