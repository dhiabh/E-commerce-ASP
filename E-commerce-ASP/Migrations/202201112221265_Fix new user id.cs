namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixnewuserid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Historiques", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUsers", "RealId", "dbo.Users");
            RenameColumn(table: "dbo.AspNetUsers", name: "RealId", newName: "RefId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_RealId", newName: "IX_RefId");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "Id");
            AddColumn("dbo.Users", "RealId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "RealId");
            AddForeignKey("dbo.Products", "UserId", "dbo.Users", "RealId", cascadeDelete: true);
            AddForeignKey("dbo.Historiques", "UserId", "dbo.Users", "RealId", cascadeDelete: false);
            AddForeignKey("dbo.AspNetUsers", "RefId", "dbo.Users", "RealId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AspNetUsers", "RefId", "dbo.Users");
            DropForeignKey("dbo.Historiques", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "RealId");
            AddPrimaryKey("dbo.Users", "Id");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_RefId", newName: "IX_RealId");
            RenameColumn(table: "dbo.AspNetUsers", name: "RefId", newName: "RealId");
            AddForeignKey("dbo.AspNetUsers", "RealId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Historiques", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
