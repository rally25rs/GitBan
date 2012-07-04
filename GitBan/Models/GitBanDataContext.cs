using System.Data.Entity;

namespace GitBan.Models
{
    public class GitBanDataContext : DbContext, IGitBanDataContext
    {
        public IDbSet<User> Users { get; set; }
    }
}