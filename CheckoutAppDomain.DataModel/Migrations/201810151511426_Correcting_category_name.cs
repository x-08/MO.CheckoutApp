namespace CheckoutAppDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcting_category_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Category", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Category");
        }
    }
}
