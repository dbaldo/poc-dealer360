namespace Dealer360WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductSalesKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductSales");
            AlterColumn("dbo.ProductSales", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ProductSales", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProductSales");
            AlterColumn("dbo.ProductSales", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProductSales", "Id");
        }
    }
}
