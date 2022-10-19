namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDrawable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IDrawables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Orientation = c.Int(),
                        Orientation1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Dimensions_Id = c.Int(),
                        Chart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PointContainers", t => t.Dimensions_Id)
                .ForeignKey("dbo.Charts", t => t.Chart_Id, cascadeDelete: true)
                .Index(t => t.Dimensions_Id)
                .Index(t => t.Chart_Id);
            
            CreateTable(
                "dbo.PointContainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IDrawables", "Chart_Id", "dbo.Charts");
            DropForeignKey("dbo.IDrawables", "Dimensions_Id", "dbo.PointContainers");
            DropIndex("dbo.IDrawables", new[] { "Chart_Id" });
            DropIndex("dbo.IDrawables", new[] { "Dimensions_Id" });
            DropTable("dbo.PointContainers");
            DropTable("dbo.IDrawables");
        }
    }
}
