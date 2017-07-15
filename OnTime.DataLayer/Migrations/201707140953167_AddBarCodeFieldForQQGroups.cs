namespace OnTime.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBarCodeFieldForQQGroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QQGroups", "BarCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.QQGroups", "BarCode");
        }
    }
}
