using System.Data.Entity;

namespace GitBan.Models
{
    public interface IGitBanDataContext
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }
        IDbSet<Board> Boards { get; set; }
        IDbSet<Column> Columns { get; set; }
        IDbSet<Issue> Issues { get; set; }
    }
}