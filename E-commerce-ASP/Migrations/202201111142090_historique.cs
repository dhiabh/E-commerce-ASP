namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class historique : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            CreateTable(
                "dbo.Historiques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Transaction = c.String(),
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            AlterColumn("dbo.Products", "RefId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "RefId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historiques", "RefId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Historiques", "ProductId", "dbo.Products");
            DropIndex("dbo.Historiques", new[] { "ProductId" });
            DropIndex("dbo.Historiques", new[] { "RefId" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "RefId", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Historiques");
            AddPrimaryKey("dbo.Products", "RefId");
        }
    }
}
