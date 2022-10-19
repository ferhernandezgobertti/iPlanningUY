namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDrawable3 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.ChartSignatures",
                c => new
                    {
                        Chart_Id = c.Int(nullable: false),
                        Signature_SignatureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chart_Id, t.Signature_SignatureID })
                .ForeignKey("dbo.Charts", t => t.Chart_Id, cascadeDelete: true)
                .ForeignKey("dbo.Signatures", t => t.Signature_SignatureID, cascadeDelete: true)
                .Index(t => t.Chart_Id)
                .Index(t => t.Signature_SignatureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChartSignatures", "Signature_SignatureID", "dbo.Signatures");
            DropForeignKey("dbo.ChartSignatures", "Chart_Id", "dbo.Charts");
            DropIndex("dbo.ChartSignatures", new[] { "Signature_SignatureID" });
            DropIndex("dbo.ChartSignatures", new[] { "Chart_Id" });
            DropTable("dbo.ChartSignatures");
            DropTable("dbo.Signatures");
        }
    }
}
