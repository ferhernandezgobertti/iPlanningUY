namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orientation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IDrawables", "OrientationDoor", c => c.Int());
            AddColumn("dbo.IDrawables", "OrientationWindow", c => c.Int());
            DropColumn("dbo.IDrawables", "Orientation");
            DropColumn("dbo.IDrawables", "Orientation1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IDrawables", "Orientation1", c => c.Int());
            AddColumn("dbo.IDrawables", "Orientation", c => c.Int());
            DropColumn("dbo.IDrawables", "OrientationWindow");
            DropColumn("dbo.IDrawables", "OrientationDoor");
        }
    }
}
