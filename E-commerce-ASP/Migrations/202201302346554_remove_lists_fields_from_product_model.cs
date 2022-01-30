namespace E_commerce_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_lists_fields_from_product_model : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "IsInFavList");
            DropColumn("dbo.Products", "IsInBlackList");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IsInBlackList", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsInFavList", c => c.Boolean(nullable: false));
        }
    }
}
