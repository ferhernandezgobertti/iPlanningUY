namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDrawableerror : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Workers", newName: "Architects");
            DropForeignKey("dbo.Charts", "ClientTarget_Id", "dbo.Clients");
            DropForeignKey("dbo.ChartIDrawables", "Chart_Id", "dbo.Charts");
            DropForeignKey("dbo.ChartIDrawables", "IDrawable_ElementID", "dbo.IDrawables");
            DropForeignKey("dbo.ChartSignatures", "Chart_Id", "dbo.Charts");
            DropForeignKey("dbo.ChartSignatures", "Signature_SignatureID", "dbo.Signatures");
            DropForeignKey("dbo.Charts", "UserCreator_Id", "dbo.Workers");
            DropIndex("dbo.Charts", new[] { "ClientTarget_Id" });
            DropIndex("dbo.Charts", new[] { "UserCreator_Id" });
            DropIndex("dbo.ChartIDrawables", new[] { "Chart_Id" });
            DropIndex("dbo.ChartIDrawables", new[] { "IDrawable_ElementID" });
            DropIndex("dbo.ChartSignatures", new[] { "Chart_Id" });
            DropIndex("dbo.ChartSignatures", new[] { "Signature_SignatureID" });
            CreateTable(
                "dbo.Designers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChartsHelped = c.Int(nullable: false),
                        ClientsHelped = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Registration = c.DateTime(nullable: false),
                        LastEntry = c.DateTime(nullable: false),
                        FirstEntry = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Architects", "ChartsSigned", c => c.Int(nullable: false));
            DropColumn("dbo.Architects", "ChartsHelped");
            DropColumn("dbo.Architects", "ClientsHelped");
            DropColumn("dbo.Architects", "Discriminator");
            DropColumn("dbo.Charts", "ClientTarget_Id");
            DropColumn("dbo.Charts", "UserCreator_Id");
            DropTable("dbo.IDrawables");
            DropTable("dbo.Signatures");
            DropTable("dbo.ChartIDrawables");
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
            
            CreateTable(
                "dbo.ChartIDrawables",
                c => new
                    {
                        Chart_Id = c.Int(nullable: false),
                        IDrawable_ElementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chart_Id, t.IDrawable_ElementID });
            
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
                "dbo.IDrawables",
                c => new
                    {
                        ElementID = c.Int(nullable: false, identity: true),
                        Orientation = c.Int(),
                        Orientation1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ElementID);
            
            AddColumn("dbo.Charts", "UserCreator_Id", c => c.Int());
            AddColumn("dbo.Charts", "ClientTarget_Id", c => c.Int());
            AddColumn("dbo.Architects", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Architects", "ClientsHelped", c => c.Int());
            AddColumn("dbo.Architects", "ChartsHelped", c => c.Int());
            AlterColumn("dbo.Architects", "ChartsSigned", c => c.Int());
            DropTable("dbo.Designers");
            CreateIndex("dbo.ChartSignatures", "Signature_SignatureID");
            CreateIndex("dbo.ChartSignatures", "Chart_Id");
            CreateIndex("dbo.ChartIDrawables", "IDrawable_ElementID");
            CreateIndex("dbo.ChartIDrawables", "Chart_Id");
            CreateIndex("dbo.Charts", "UserCreator_Id");
            CreateIndex("dbo.Charts", "ClientTarget_Id");
            AddForeignKey("dbo.Charts", "UserCreator_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.ChartSignatures", "Signature_SignatureID", "dbo.Signatures", "SignatureID", cascadeDelete: true);
            AddForeignKey("dbo.ChartSignatures", "Chart_Id", "dbo.Charts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChartIDrawables", "IDrawable_ElementID", "dbo.IDrawables", "ElementID", cascadeDelete: true);
            AddForeignKey("dbo.ChartIDrawables", "Chart_Id", "dbo.Charts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Charts", "ClientTarget_Id", "dbo.Clients", "Id");
            RenameTable(name: "dbo.Architects", newName: "Workers");
        }
    }
}
