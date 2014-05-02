using System.Collections.Generic;
using LinkingTable.Models;

namespace LinkingTable.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ClinicalTrialContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ClinicalTrialContext context)
        {
           var drugs = new []{
               new Drug{ Name="X123"},
               new Drug{ Name="Z44"},
               new Drug{ Name="XY222"}
           };
            
            var studies = new[]
            {                
                new Study {Name = "ATHENA", Drugs=new [] { drugs[0], drugs[1]}},
                new Study {Name = "APOLLO", Drugs=new [] { drugs[1], drugs[2]}}
            };
            
            context.Drugs.AddOrUpdate(d=> d.Name, drugs);
            context.Studies.AddOrUpdate(s => s.Name, studies);
            base.Seed(context);
        }
    }
}
