namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productinternationalization : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Image", c => c.String());
        }
    }
}
