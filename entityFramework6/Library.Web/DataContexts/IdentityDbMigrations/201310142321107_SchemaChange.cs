namespace Library.Web.DataContexts.IdentityDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemaChange : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.AspNetRoles", newSchema: "identity");
            MoveTable(name: "dbo.AspNetUserClaims", newSchema: "identity");
            MoveTable(name: "dbo.AspNetUsers", newSchema: "identity");
            MoveTable(name: "dbo.AspNetUserLogins", newSchema: "identity");
            MoveTable(name: "dbo.AspNetUserRoles", newSchema: "identity");
        }
        
        public override void Down()
        {
            MoveTable(name: "identity.AspNetUserRoles", newSchema: "dbo");
            MoveTable(name: "identity.AspNetUserLogins", newSchema: "dbo");
            MoveTable(name: "identity.AspNetUsers", newSchema: "dbo");
            MoveTable(name: "identity.AspNetUserClaims", newSchema: "dbo");
            MoveTable(name: "identity.AspNetRoles", newSchema: "dbo");
        }
    }
}
