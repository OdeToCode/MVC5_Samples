namespace Library.Web.DataContexts.BookDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "library.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "library.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("library.OrderDetails", t => t.Details_Id)
                .Index(t => t.Details_Id);
            
            CreateTable(
                "library.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("library.Products", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "library.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("library.Orders", "Details_Id", "library.OrderDetails");
            DropForeignKey("library.OrderDetails", "Item_Id", "library.Products");
            DropIndex("library.Orders", new[] { "Details_Id" });
            DropIndex("library.OrderDetails", new[] { "Item_Id" });
            DropTable("library.Products");
            DropTable("library.OrderDetails");
            DropTable("library.Orders");
            DropTable("library.Books");
        }
    }
}
