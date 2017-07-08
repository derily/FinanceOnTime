namespace OnTime.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidFieldForPageImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageImages", "Valid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageImages", "Valid");
        }
    }
}
