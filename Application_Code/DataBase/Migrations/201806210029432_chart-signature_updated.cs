namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chartsignature_updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChartSignatures", "Chart_Id", "dbo.Charts");
            DropForeignKey("dbo.ChartSignatures", "Signature_SignatureID", "dbo.Signatures");
            DropIndex("dbo.ChartSignatures", new[] { "Chart_Id" });
            DropIndex("dbo.ChartSignatures", new[] { "Signature_SignatureID" });
            AddColumn("dbo.Signatures", "Chart_Id", c => c.Int());
            CreateIndex("dbo.Signatures", "Chart_Id");
            AddForeignKey("dbo.Signatures", "Chart_Id", "dbo.Charts", "Id");
            DropTable("dbo.ChartSignatures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ChartSignatures",
                c => new
                    {
                        Chart_Id = c.Int(nullable: false),
                        Signature_SignatureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chart_Id, t.Signature_SignatureID });
            
            DropForeignKey("dbo.Signatures", "Chart_Id", "dbo.Charts");
            DropIndex("dbo.Signatures", new[] { "Chart_Id" });
            DropColumn("dbo.Signatures", "Chart_Id");
            CreateIndex("dbo.ChartSignatures", "Signature_SignatureID");
            CreateIndex("dbo.ChartSignatures", "Chart_Id");
            AddForeignKey("dbo.ChartSignatures", "Signature_SignatureID", "dbo.Signatures", "SignatureID", cascadeDelete: true);
            AddForeignKey("dbo.ChartSignatures", "Chart_Id", "dbo.Charts", "Id", cascadeDelete: true);
        }
    }
}
