namespace CheckoutAppDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckedoutProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        InvoiceDetails_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.InvoiceDetails", t => t.InvoiceDetails_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.InvoiceDetails_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.Guid(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckedoutProducts", "InvoiceDetails_Id", "dbo.InvoiceDetails");
            DropForeignKey("dbo.CheckedoutProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.CheckedoutProducts", new[] { "InvoiceDetails_Id" });
            DropIndex("dbo.CheckedoutProducts", new[] { "Product_Id" });
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Products");
            DropTable("dbo.CheckedoutProducts");
        }
    }
}
