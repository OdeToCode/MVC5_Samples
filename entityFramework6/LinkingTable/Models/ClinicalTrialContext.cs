using System.Data.Entity;

namespace LinkingTable.Models
{
    public class ClinicalTrialContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Study> Studies { get; set; }
    }
}