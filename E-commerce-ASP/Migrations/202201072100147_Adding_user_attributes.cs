namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_user_attributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "first_name", c => c.String());
            AddColumn("dbo.AspNetUsers", "last_name", c => c.String());
            AddColumn("dbo.AspNetUsers", "date_of_birth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "company_name", c => c.String());
            AddColumn("dbo.AspNetUsers", "web_site", c => c.String());
            AddColumn("dbo.AspNetUsers", "num_patente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "num_patente");
            DropColumn("dbo.AspNetUsers", "web_site");
            DropColumn("dbo.AspNetUsers", "company_name");
            DropColumn("dbo.AspNetUsers", "date_of_birth");
            DropColumn("dbo.AspNetUsers", "last_name");
            DropColumn("dbo.AspNetUsers", "first_name");
        }
    }
}
