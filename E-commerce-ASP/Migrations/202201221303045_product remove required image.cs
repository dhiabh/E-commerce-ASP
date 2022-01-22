namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productremoverequiredimage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Image", c => c.String(nullable: false));
        }
    }
}
