namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chartname : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Architects", newName: "Workers");
            AddColumn("dbo.Workers", "ChartsHelped", c => c.Int());
            AddColumn("dbo.Workers", "ClientsHelped", c => c.Int());
            AddColumn("dbo.Workers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Charts", "Name", c => c.String());
            AddColumn("dbo.Charts", "UserCreator_Id", c => c.Int());
            AlterColumn("dbo.Workers", "ChartsSigned", c => c.Int());
            CreateIndex("dbo.Charts", "UserCreator_Id");
            AddForeignKey("dbo.Charts", "UserCreator_Id", "dbo.Workers", "Id");
            DropTable("dbo.Designers");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.Charts", "UserCreator_Id", "dbo.Workers");
            DropIndex("dbo.Charts", new[] { "UserCreator_Id" });
            AlterColumn("dbo.Workers", "ChartsSigned", c => c.Int(nullable: false));
            DropColumn("dbo.Charts", "UserCreator_Id");
            DropColumn("dbo.Charts", "Name");
            DropColumn("dbo.Workers", "Discriminator");
            DropColumn("dbo.Workers", "ClientsHelped");
            DropColumn("dbo.Workers", "ChartsHelped");
            RenameTable(name: "dbo.Workers", newName: "Architects");
        }
    }
}
