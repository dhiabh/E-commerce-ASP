namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixuserid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "UserId", newName: "RefId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_UserId", newName: "IX_RealId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_RealId", newName: "IX_UserId");
            RenameColumn(table: "dbo.AspNetUsers", name: "RefId", newName: "UserId");
        }
    }
}
