namespace OnTime.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientAccessInfoForCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Source", c => c.String());
            AddColumn("dbo.Customers", "ClientIPAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ClientIPAddress");
            DropColumn("dbo.Customers", "Source");
        }
    }
}
