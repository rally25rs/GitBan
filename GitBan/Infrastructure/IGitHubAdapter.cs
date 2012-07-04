using System.Collections.Generic;
using GitBan.Models;

namespace GitBan.Infrastructure
{
    public interface IGitHubAdapter
    {
        string GetAccessToken(string authCode);
        User GetUser(string accessToken);
        IEnumerable<Project> GetRepos(string accessToken);
    }
}