namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedatefield : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
