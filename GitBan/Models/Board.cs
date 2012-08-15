using System.Collections.Generic;

namespace GitBan.Models
{
    public class Board
    {
        public int Id { get; set; }
        public IEnumerable<Column> Columns { get; set; }
    }
}