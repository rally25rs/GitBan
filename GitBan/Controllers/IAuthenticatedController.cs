using GitBan.Models;

namespace GitBan.Controllers
{
    public interface IAuthenticatedController
    {
        User CurrentUser { get; set; }
        IGitBanDataContext CurrentDataContext { get; set; }
    }
}