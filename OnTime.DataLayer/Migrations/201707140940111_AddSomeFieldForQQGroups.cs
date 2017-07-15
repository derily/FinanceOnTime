namespace OnTime.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeFieldForQQGroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QQGroups", "Valid", c => c.Boolean(nullable: false));
            AddColumn("dbo.QQGroups", "JoinLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.QQGroups", "JoinLink");
            DropColumn("dbo.QQGroups", "Valid");
        }
    }
}
