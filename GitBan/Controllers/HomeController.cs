using System;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GitBan.Infrastructure;

namespace GitBan.Controllers
{
    public class HomeController : Controller
    {
        private const string GITHUB_AUTH_URL = "https://github.com/login/oauth/access_token";
        private const string GITHUB_CLIENT_ID = "7ce4ceec9afd17668e3c";
        private const string GITHUB_SECRET = "2dcc4709333963e6d9086068ea0b84711ec03ab8";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Board()
        {
            return View();
        }

        public ActionResult Auth()
        {
            var authCode = Request.Params["code"];
            if (string.IsNullOrEmpty(authCode))
            {
                Logger.LogDebugMessage("No code found.");
                return View("Index");
            }

            var data = GetPostContentsForGitHubAuth(authCode);
            var gitHubAuthResponse = GetAuthResponseFromGitHub(data);
            var accessToken = GetAccessTokenFromResponse(gitHubAuthResponse);

            if (string.IsNullOrEmpty(accessToken))
            {
                Logger.LogDebugMessage("No access token found.");
                return View("Index");
            }

            return View("Projects", new { AccessToken = accessToken });
        }

        private string GetAccessTokenFromResponse(HttpWebResponse response)
        {
            var contents = GetResponseContents(response);
            Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("GitHub response: " + contents));
            try
            {
                var values = HttpUtility.ParseQueryString(contents);
                return values["access_token"];
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                return null;
            }
        }

        private static string GetResponseContents(HttpWebResponse response)
        {
            var contentBytes = new byte[response.ContentLength];
            var respStream = response.GetResponseStream();
            if (respStream == null)
                return null;
            respStream.Read(contentBytes, 0, (int) response.ContentLength);
            respStream.Close();
            return Encoding.ASCII.GetString(contentBytes);
        }

        private static byte[] GetPostContentsForGitHubAuth(string authCode)
        {
            var content = new StringBuilder();
            content.AppendFormat("client_id={0}&client_secret={1}&code={2}",
                GITHUB_CLIENT_ID,
                GITHUB_SECRET,
                authCode);
            return Encoding.ASCII.GetBytes(content.ToString());
        }

        private HttpWebResponse GetAuthResponseFromGitHub(byte[] data)
        {
            var gitHubAuthRequest = (HttpWebRequest) WebRequest.Create(GITHUB_AUTH_URL);
            gitHubAuthRequest.Method = "POST";
            gitHubAuthRequest.ContentLength = data.Length;
            gitHubAuthRequest.ContentType = "application/x-www-form-urlencoded";
            var requestStream = gitHubAuthRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            return (HttpWebResponse) gitHubAuthRequest.GetResponse();
        }
    }
}
