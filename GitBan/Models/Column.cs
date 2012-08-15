using System.Collections.Generic;

namespace GitBan.Models
{
    public class Column
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public int SortOrder { get; set; }
        public string Name { get; set; }
        public int WipLimit { get; set; }
        public IEnumerable<Issue> Issues { get; set; }
    }
}