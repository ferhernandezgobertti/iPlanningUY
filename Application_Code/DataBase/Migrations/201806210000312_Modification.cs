namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IntContainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Width = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoubleContainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PointCoordinatesContainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginX = c.Int(nullable: false),
                        OriginY = c.Int(nullable: false),
                        DestinationX = c.Int(nullable: false),
                        DestinationY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IDrawables", "Name", c => c.String());
            AddColumn("dbo.IDrawables", "HeightFromFloor", c => c.Double());
            AddColumn("dbo.IDrawables", "Dimension_Id", c => c.Int());
            AddColumn("dbo.IDrawables", "Location_Id", c => c.Int());
            AddColumn("dbo.IDrawables", "Money_Id", c => c.Int());
            AddColumn("dbo.IDrawables", "Coordinates_Id", c => c.Int());
            CreateIndex("dbo.IDrawables", "Dimension_Id");
            CreateIndex("dbo.IDrawables", "Location_Id");
            CreateIndex("dbo.IDrawables", "Money_Id");
            CreateIndex("dbo.IDrawables", "Coordinates_Id");
            AddForeignKey("dbo.IDrawables", "Dimension_Id", "dbo.IntContainers", "Id");
            AddForeignKey("dbo.IDrawables", "Location_Id", "dbo.PointContainers", "Id");
            AddForeignKey("dbo.IDrawables", "Money_Id", "dbo.DoubleContainers", "Id");
            AddForeignKey("dbo.IDrawables", "Coordinates_Id", "dbo.PointCoordinatesContainers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IDrawables", "Coordinates_Id", "dbo.PointCoordinatesContainers");
            DropForeignKey("dbo.IDrawables", "Money_Id", "dbo.DoubleContainers");
            DropForeignKey("dbo.IDrawables", "Location_Id", "dbo.PointContainers");
            DropForeignKey("dbo.IDrawables", "Dimension_Id", "dbo.IntContainers");
            DropIndex("dbo.IDrawables", new[] { "Coordinates_Id" });
            DropIndex("dbo.IDrawables", new[] { "Money_Id" });
            DropIndex("dbo.IDrawables", new[] { "Location_Id" });
            DropIndex("dbo.IDrawables", new[] { "Dimension_Id" });
            DropColumn("dbo.IDrawables", "Coordinates_Id");
            DropColumn("dbo.IDrawables", "Money_Id");
            DropColumn("dbo.IDrawables", "Location_Id");
            DropColumn("dbo.IDrawables", "Dimension_Id");
            DropColumn("dbo.IDrawables", "HeightFromFloor");
            DropColumn("dbo.IDrawables", "Name");
            DropTable("dbo.PointCoordinatesContainers");
            DropTable("dbo.DoubleContainers");
            DropTable("dbo.IntContainers");
        }
    }
}
