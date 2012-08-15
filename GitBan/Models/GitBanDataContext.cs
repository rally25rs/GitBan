using System.Data.Entity;

namespace GitBan.Models
{
    public class GitBanDataContext : DbContext, IGitBanDataContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<Board> Boards { get; set; }
        public IDbSet<Column> Columns { get; set; }
        public IDbSet<Issue> Issues { get; set; }
    }
}