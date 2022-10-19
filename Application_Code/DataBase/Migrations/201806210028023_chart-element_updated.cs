namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chartelement_updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChartIDrawables", "Chart_Id", "dbo.Charts");
            DropForeignKey("dbo.ChartIDrawables", "IDrawable_Id", "dbo.IDrawables");
            DropIndex("dbo.ChartIDrawables", new[] { "Chart_Id" });
            DropIndex("dbo.ChartIDrawables", new[] { "IDrawable_Id" });
            AddColumn("dbo.IDrawables", "Chart_Id", c => c.Int());
            CreateIndex("dbo.IDrawables", "Chart_Id");
            AddForeignKey("dbo.IDrawables", "Chart_Id", "dbo.Charts", "Id");
            DropTable("dbo.ChartIDrawables");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ChartIDrawables",
                c => new
                    {
                        Chart_Id = c.Int(nullable: false),
                        IDrawable_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chart_Id, t.IDrawable_Id });
            
            DropForeignKey("dbo.IDrawables", "Chart_Id", "dbo.Charts");
            DropIndex("dbo.IDrawables", new[] { "Chart_Id" });
            DropColumn("dbo.IDrawables", "Chart_Id");
            CreateIndex("dbo.ChartIDrawables", "IDrawable_Id");
            CreateIndex("dbo.ChartIDrawables", "Chart_Id");
            AddForeignKey("dbo.ChartIDrawables", "IDrawable_Id", "dbo.IDrawables", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChartIDrawables", "Chart_Id", "dbo.Charts", "Id", cascadeDelete: true);
        }
    }
}
