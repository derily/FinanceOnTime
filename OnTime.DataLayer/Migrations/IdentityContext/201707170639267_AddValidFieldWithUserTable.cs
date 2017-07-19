namespace OnTime.DataLayer.Migrations.IdentityContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidFieldWithUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Valid", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Valid");
        }
    }
}
