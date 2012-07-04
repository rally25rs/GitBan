using System.Data.Entity;

namespace GitBan.Models
{
    public interface IGitBanDataContext
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }
    }
}