namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDrawable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IDrawables", "Chart_Id", "dbo.Charts");
            DropIndex("dbo.IDrawables", new[] { "Chart_Id" });
            CreateTable(
                "dbo.ChartIDrawables",
                c => new
                    {
                        Chart_Id = c.Int(nullable: false),
                        IDrawable_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chart_Id, t.IDrawable_Id })
                .ForeignKey("dbo.Charts", t => t.Chart_Id, cascadeDelete: true)
                .ForeignKey("dbo.IDrawables", t => t.IDrawable_Id, cascadeDelete: true)
                .Index(t => t.Chart_Id)
                .Index(t => t.IDrawable_Id);
            
            DropColumn("dbo.IDrawables", "Chart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IDrawables", "Chart_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.ChartIDrawables", "IDrawable_Id", "dbo.IDrawables");
            DropForeignKey("dbo.ChartIDrawables", "Chart_Id", "dbo.Charts");
            DropIndex("dbo.ChartIDrawables", new[] { "IDrawable_Id" });
            DropIndex("dbo.ChartIDrawables", new[] { "Chart_Id" });
            DropTable("dbo.ChartIDrawables");
            CreateIndex("dbo.IDrawables", "Chart_Id");
            AddForeignKey("dbo.IDrawables", "Chart_Id", "dbo.Charts", "Id", cascadeDelete: true);
        }
    }
}
