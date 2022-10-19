namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _virtual : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Charts", "Money_Id", c => c.Int());
            CreateIndex("dbo.Charts", "Money_Id");
            AddForeignKey("dbo.Charts", "Money_Id", "dbo.DoubleContainers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Charts", "Money_Id", "dbo.DoubleContainers");
            DropIndex("dbo.Charts", new[] { "Money_Id" });
            DropColumn("dbo.Charts", "Money_Id");
        }
    }
}
