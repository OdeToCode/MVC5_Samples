namespace BasicIdentityWithDiagrams.Migrations
{
    using BasicIdentityWithDiagrams.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BasicIdentityWithDiagrams.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //SeedUserOnly(context);
            SeedUserWithUserManager(context);
            //SeedUserAndRole(context);
        }

        private void SeedUserWithUserManager(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "sallen"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "sallen" };

                manager.Create(user, "password");
            }
        }

        private static void SeedUserOnly(ApplicationDbContext context)
        {
            var hasher = new PasswordHasher();          
            var user = new ApplicationUser
            {
                UserName = "sallen",
                PasswordHash = hasher.HashPassword("password")
            };
           
            context.Users.AddOrUpdate(u => u.UserName, user);
        }

        void SeedUserAndRole(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "sallen"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);               
                var user = new ApplicationUser { UserName = "sallen" };

                userManager.Create(user, "password");                    
                roleManager.Create(new IdentityRole { Name = "admin" });
                userManager.AddToRole(user.Id, "admin");
            } 
        }
    }
}
