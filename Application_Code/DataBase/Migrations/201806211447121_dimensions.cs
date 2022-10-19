namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dimensions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Charts", "Dimensions_Id", c => c.Int());
            CreateIndex("dbo.Charts", "Dimensions_Id");
            AddForeignKey("dbo.Charts", "Dimensions_Id", "dbo.IntContainers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Charts", "Dimensions_Id", "dbo.IntContainers");
            DropIndex("dbo.Charts", new[] { "Dimensions_Id" });
            DropColumn("dbo.Charts", "Dimensions_Id");
        }
    }
}
