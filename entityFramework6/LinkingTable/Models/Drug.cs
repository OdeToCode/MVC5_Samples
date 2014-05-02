using System.Collections.Generic;

namespace LinkingTable.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Study> Studies { get; set; }
    }
}