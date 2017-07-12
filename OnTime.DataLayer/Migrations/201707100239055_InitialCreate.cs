namespace OnTime.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageImages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Path = c.String(),
                        Valid = c.Boolean(nullable: false),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeChatAccounts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AccountId = c.String(),
                        NickName = c.String(),
                        BarCode = c.String(),
                        Valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeChatAccounts");
            DropTable("dbo.PageImages");
        }
    }
}
