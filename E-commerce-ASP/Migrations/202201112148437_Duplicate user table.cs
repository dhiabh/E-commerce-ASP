namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Duplicateusertable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "RefId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Historiques", "RefId", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "RefId" });
            DropIndex("dbo.Historiques", new[] { "RefId" });
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FullName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        CompanyName = c.String(),
                        WebSite = c.String(),
                        NumPatente = c.String(),
                        Nature = c.String(),
                        Address = c.String(),
                        IsInFavList = c.Boolean(nullable: false),
                        IsInBlackList = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "RefId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "RefId", c => c.Int(nullable: false));
            AlterColumn("dbo.Historiques", "RefId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "RefId");
            CreateIndex("dbo.Historiques", "RefId");
            CreateIndex("dbo.AspNetUsers", "RefId");
            AddForeignKey("dbo.AspNetUsers", "RefId", "dbo.Users", "RefId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "RefId", "dbo.Users", "RefId", cascadeDelete: true);
            AddForeignKey("dbo.Historiques", "RefId", "dbo.Users", "RefId", cascadeDelete: false);
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "WebSite");
            DropColumn("dbo.AspNetUsers", "NumPatente");
            DropColumn("dbo.AspNetUsers", "Nature");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "IsInFavList");
            DropColumn("dbo.AspNetUsers", "IsInBlackList");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsInBlackList", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsInFavList", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nature", c => c.String());
            AddColumn("dbo.AspNetUsers", "NumPatente", c => c.String());
            AddColumn("dbo.AspNetUsers", "WebSite", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropForeignKey("dbo.Historiques", "RefId", "dbo.Users");
            DropForeignKey("dbo.Products", "RefId", "dbo.Users");
            DropForeignKey("dbo.AspNetUsers", "RefId", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "RefId" });
            DropIndex("dbo.Historiques", new[] { "RefId" });
            DropIndex("dbo.Products", new[] { "RefId" });
            AlterColumn("dbo.Historiques", "RefId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "RefId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "RefId");
            DropColumn("dbo.Products", "Description");
            DropTable("dbo.Users");
            CreateIndex("dbo.Historiques", "RefId");
            CreateIndex("dbo.Products", "RefId");
            AddForeignKey("dbo.Historiques", "RefId", "dbo.AspNetUsers", "RefId");
            AddForeignKey("dbo.Products", "RefId", "dbo.AspNetUsers", "RefId");
        }
    }
}
