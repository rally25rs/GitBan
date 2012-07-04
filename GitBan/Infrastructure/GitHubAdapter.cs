using System;
using System.Collections.Generic;
using System.Web;
using GitBan.Models;

namespace GitBan.Infrastructure
{
    public class GitHubAdapter : IGitHubAdapter
    {
        private const string GITHUB_AUTH_URL = "https://github.com/login/oauth/access_token";
        private const string GITHUB_USER_INFO_URL = "https://api.github.com/user?access_token={0}";
        private const string GITHUB_USER_REPOS_URL = "https://api.github.com/user/repos?access_token={0}";
        private const string GITHUB_CLIENT_ID = "7ce4ceec9afd17668e3c";
        private const string GITHUB_SECRET = "2dcc4709333963e6d9086068ea0b84711ec03ab8";

        public string GetAccessToken(string authCode)
        {
            var response = WebClient.Post(GITHUB_AUTH_URL, null, string.Format("client_id={0}&client_secret={1}&code={2}",
                                 GITHUB_CLIENT_ID,
                                 GITHUB_SECRET,
                                 authCode));
            try
            {
                var values = HttpUtility.ParseQueryString(response);
                return values["access_token"];
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                return null;
            }
        }

        public User GetUser(string accessToken)
        {
            dynamic data = WebClient.GetJson(GITHUB_USER_INFO_URL, accessToken);
            return new User
                       {
                           Id = data.id,
                           Name = data.login,
                           AccessToken = accessToken,
                           AvatarUrl = data.avatar_url
                       };
        }

        public IEnumerable<Project> GetRepos(string accessToken)
        {
            dynamic data = WebClient.GetJson(GITHUB_USER_REPOS_URL, accessToken);
            foreach(var repo in data)
            {
                yield return new Project
                                 {
                                     Id = repo.id,
                                     Name = repo.name,
                                     ApiUrl = repo.url,
                                     HtmlUrl = repo.html_url,
                                     OpenIssuesCount = repo.open_issues
                                 };
            }
        }
    }
}