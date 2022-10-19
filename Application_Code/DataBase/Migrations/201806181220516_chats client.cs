namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chatsclient : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Architects", newName: "Workers");
            DropForeignKey("dbo.ChartIDrawables", "Chart_Name", "dbo.Charts");
            DropForeignKey("dbo.ChartSignatures", "Chart_Name", "dbo.Charts");
            DropIndex("dbo.ChartIDrawables", new[] { "Chart_Name" });
            DropIndex("dbo.ChartSignatures", new[] { "Chart_Name" });
            RenameColumn(table: "dbo.ChartIDrawables", name: "Chart_Name", newName: "Chart_Id");
            RenameColumn(table: "dbo.ChartSignatures", name: "Chart_Name", newName: "Chart_Id");
            DropPrimaryKey("dbo.Workers");
            DropPrimaryKey("dbo.Charts");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.ChartIDrawables");
            DropPrimaryKey("dbo.ChartSignatures");
            AddColumn("dbo.Workers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Workers", "ChartsHelped", c => c.Int());
            AddColumn("dbo.Workers", "ClientsHelped", c => c.Int());
            AddColumn("dbo.Workers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Charts", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Charts", "ClientTarget_Id", c => c.Int());
            AddColumn("dbo.Charts", "UserCreator_Id", c => c.Int());
            AddColumn("dbo.Clients", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Workers", "UserName", c => c.String());
            AlterColumn("dbo.Workers", "ChartsSigned", c => c.Int());
            AlterColumn("dbo.Clients", "UserName", c => c.String());
            AlterColumn("dbo.ChartIDrawables", "Chart_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ChartSignatures", "Chart_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Workers", "Id");
            AddPrimaryKey("dbo.Charts", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.ChartIDrawables", new[] { "Chart_Id", "IDrawable_ElementID" });
            AddPrimaryKey("dbo.ChartSignatures", new[] { "Chart_Id", "Signature_SignatureID" });
            CreateIndex("dbo.Charts", "ClientTarget_Id");
            CreateIndex("dbo.Charts", "UserCreator_Id");
            CreateIndex("dbo.ChartIDrawables", "Chart_Id");
            CreateIndex("dbo.ChartSignatures", "Chart_Id");
            AddForeignKey("dbo.Charts", "ClientTarget_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Charts", "UserCreator_Id", "dbo.Workers", "Id");
            AddForeignKey("dbo.ChartIDrawables", "Chart_Id", "dbo.Charts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChartSignatures", "Chart_Id", "dbo.Charts", "Id", cascadeDelete: true);
            DropColumn("dbo.Charts", "Name");
            DropTable("dbo.Designers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Designers",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        ChartsHelped = c.Int(nullable: false),
                        ClientsHelped = c.Int(nullable: false),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Registration = c.DateTime(nullable: false),
                        LastEntry = c.DateTime(nullable: false),
                        FirstEntry = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            AddColumn("dbo.Charts", "Name", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.ChartSignatures", "Chart_Id", "dbo.Charts");
            DropForeignKey("dbo.ChartIDrawables", "Chart_Id", "dbo.Charts");
            DropForeignKey("dbo.Charts", "UserCreator_Id", "dbo.Workers");
            DropForeignKey("dbo.Charts", "ClientTarget_Id", "dbo.Clients");
            DropIndex("dbo.ChartSignatures", new[] { "Chart_Id" });
            DropIndex("dbo.ChartIDrawables", new[] { "Chart_Id" });
            DropIndex("dbo.Charts", new[] { "UserCreator_Id" });
            DropIndex("dbo.Charts", new[] { "ClientTarget_Id" });
            DropPrimaryKey("dbo.ChartSignatures");
            DropPrimaryKey("dbo.ChartIDrawables");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Charts");
            DropPrimaryKey("dbo.Workers");
            AlterColumn("dbo.ChartSignatures", "Chart_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ChartIDrawables", "Chart_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Clients", "UserName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Workers", "ChartsSigned", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "UserName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Clients", "Id");
            DropColumn("dbo.Charts", "UserCreator_Id");
            DropColumn("dbo.Charts", "ClientTarget_Id");
            DropColumn("dbo.Charts", "Id");
            DropColumn("dbo.Workers", "Discriminator");
            DropColumn("dbo.Workers", "ClientsHelped");
            DropColumn("dbo.Workers", "ChartsHelped");
            DropColumn("dbo.Workers", "Id");
            AddPrimaryKey("dbo.ChartSignatures", new[] { "Chart_Name", "Signature_SignatureID" });
            AddPrimaryKey("dbo.ChartIDrawables", new[] { "Chart_Name", "IDrawable_ElementID" });
            AddPrimaryKey("dbo.Clients", "UserName");
            AddPrimaryKey("dbo.Charts", "Name");
            AddPrimaryKey("dbo.Workers", "UserName");
            RenameColumn(table: "dbo.ChartSignatures", name: "Chart_Id", newName: "Chart_Name");
            RenameColumn(table: "dbo.ChartIDrawables", name: "Chart_Id", newName: "Chart_Name");
            CreateIndex("dbo.ChartSignatures", "Chart_Name");
            CreateIndex("dbo.ChartIDrawables", "Chart_Name");
            AddForeignKey("dbo.ChartSignatures", "Chart_Name", "dbo.Charts", "Name", cascadeDelete: true);
            AddForeignKey("dbo.ChartIDrawables", "Chart_Name", "dbo.Charts", "Name", cascadeDelete: true);
            RenameTable(name: "dbo.Workers", newName: "Architects");
        }
    }
}
