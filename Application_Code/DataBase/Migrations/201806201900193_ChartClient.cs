namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChartClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Charts", "ClientTarget_Id", c => c.Int());
            CreateIndex("dbo.Charts", "ClientTarget_Id");
            AddForeignKey("dbo.Charts", "ClientTarget_Id", "dbo.Clients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Charts", "ClientTarget_Id", "dbo.Clients");
            DropIndex("dbo.Charts", new[] { "ClientTarget_Id" });
            DropColumn("dbo.Charts", "ClientTarget_Id");
        }
    }
}
