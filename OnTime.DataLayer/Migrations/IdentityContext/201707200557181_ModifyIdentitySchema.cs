namespace OnTime.DataLayer.Migrations.IdentityContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyIdentitySchema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
    }
}
