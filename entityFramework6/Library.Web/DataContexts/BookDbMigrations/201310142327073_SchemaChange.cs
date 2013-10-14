namespace Library.Web.DataContexts.BookDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemaChange : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Books", newSchema: "library");
        }
        
        public override void Down()
        {
            MoveTable(name: "library.Books", newSchema: "dbo");
        }
    }
}
