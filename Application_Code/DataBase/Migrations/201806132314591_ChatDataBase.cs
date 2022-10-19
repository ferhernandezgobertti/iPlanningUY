namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Charts", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Charts", "Price");
        }
    }
}
