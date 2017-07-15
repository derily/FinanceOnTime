namespace OnTime.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableQQGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QQGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AccountId = c.String(),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QQGroups");
        }
    }
}
