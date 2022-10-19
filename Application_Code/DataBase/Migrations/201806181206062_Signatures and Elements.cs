namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SignaturesandElements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IDrawables",
                c => new
                    {
                        ElementID = c.Int(nullable: false, identity: true),
                        Orientation = c.Int(),
                        Orientation1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ElementID);
            
            CreateTable(
                "dbo.Signatures",
                c => new
                    {
                        SignatureID = c.Int(nullable: false, identity: true),
                        FirstSigning = c.DateTime(nullable: false),
                        SecondSigning = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SignatureID);
            
            CreateTable(
                "dbo.ChartIDrawables",
                c => new
                    {
                        Chart_Name = c.String(nullable: false, maxLength: 128),
                        IDrawable_ElementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chart_Name, t.IDrawable_ElementID })
                .ForeignKey("dbo.Charts", t => t.Chart_Name, cascadeDelete: true)
                .ForeignKey("dbo.IDrawables", t => t.IDrawable_ElementID, cascadeDelete: true)
                .Index(t => t.Chart_Name)
                .Index(t => t.IDrawable_ElementID);
            
            CreateTable(
                "dbo.ChartSignatures",
                c => new
                    {
                        Chart_Name = c.String(nullable: false, maxLength: 128),
                        Signature_SignatureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chart_Name, t.Signature_SignatureID })
                .ForeignKey("dbo.Charts", t => t.Chart_Name, cascadeDelete: true)
                .ForeignKey("dbo.Signatures", t => t.Signature_SignatureID, cascadeDelete: true)
                .Index(t => t.Chart_Name)
                .Index(t => t.Signature_SignatureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChartSignatures", "Signature_SignatureID", "dbo.Signatures");
            DropForeignKey("dbo.ChartSignatures", "Chart_Name", "dbo.Charts");
            DropForeignKey("dbo.ChartIDrawables", "IDrawable_ElementID", "dbo.IDrawables");
            DropForeignKey("dbo.ChartIDrawables", "Chart_Name", "dbo.Charts");
            DropIndex("dbo.ChartSignatures", new[] { "Signature_SignatureID" });
            DropIndex("dbo.ChartSignatures", new[] { "Chart_Name" });
            DropIndex("dbo.ChartIDrawables", new[] { "IDrawable_ElementID" });
            DropIndex("dbo.ChartIDrawables", new[] { "Chart_Name" });
            DropTable("dbo.ChartSignatures");
            DropTable("dbo.ChartIDrawables");
            DropTable("dbo.Signatures");
            DropTable("dbo.IDrawables");
        }
    }
}
