namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_other_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsInFavList = c.Boolean(nullable: false),
                        IsInBlackList = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "FirsName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
            AddColumn("dbo.AspNetUsers", "WebSite", c => c.String());
            AddColumn("dbo.AspNetUsers", "NumPatente", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nature", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsInFavList", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsInBlackList", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "first_name");
            DropColumn("dbo.AspNetUsers", "last_name");
            DropColumn("dbo.AspNetUsers", "date_of_birth");
            DropColumn("dbo.AspNetUsers", "company_name");
            DropColumn("dbo.AspNetUsers", "web_site");
            DropColumn("dbo.AspNetUsers", "num_patente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "num_patente", c => c.String());
            AddColumn("dbo.AspNetUsers", "web_site", c => c.String());
            AddColumn("dbo.AspNetUsers", "company_name", c => c.String());
            AddColumn("dbo.AspNetUsers", "date_of_birth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "last_name", c => c.String());
            AddColumn("dbo.AspNetUsers", "first_name", c => c.String());
            DropForeignKey("dbo.Products", "RefId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "RefId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropColumn("dbo.AspNetUsers", "IsInBlackList");
            DropColumn("dbo.AspNetUsers", "IsInFavList");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Nature");
            DropColumn("dbo.AspNetUsers", "NumPatente");
            DropColumn("dbo.AspNetUsers", "WebSite");
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirsName");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
        }
    }
}
