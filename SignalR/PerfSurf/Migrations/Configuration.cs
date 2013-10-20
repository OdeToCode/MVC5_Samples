namespace PerfSurf.Migrations
{
    using PerfSurf.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PerfSurf.Models.PerfDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PerfSurf.Models.PerfDb context)
        {
            context.Counters.AddOrUpdate(
                    new PerfCounter {  Name="Processor Time", Category="Processor" , Counter="% Processor Time", Instance="_Total"},
                    new PerfCounter { Name="Paging", Category="Memory", Counter="Pages/sec", Instance=""},
                    new PerfCounter { Name="Disk", Category="PhysicalDisk", Counter="% Disk Time", Instance="_Total"}
                );
        }
    }
}
