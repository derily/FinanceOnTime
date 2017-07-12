namespace OnTime.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockCodeFieldForCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StockCode", c => c.String(maxLength:6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "StockCode");
        }
    }
}
