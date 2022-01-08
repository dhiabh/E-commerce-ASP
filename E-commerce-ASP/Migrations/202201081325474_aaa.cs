namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "FirsName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FirsName", c => c.String());
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
