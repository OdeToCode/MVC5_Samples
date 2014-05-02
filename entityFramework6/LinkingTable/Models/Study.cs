using System.Collections.Generic;

namespace LinkingTable.Models
{
    public class Study
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Drug> Drugs { get; set; }
    }
}