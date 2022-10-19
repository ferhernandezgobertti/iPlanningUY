namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Architectnowindatabase : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Designers");
            CreateTable(
                "dbo.Architects",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        ChartsSigned = c.Int(nullable: false),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Registration = c.DateTime(nullable: false),
                        LastEntry = c.DateTime(nullable: false),
                        FirstEntry = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            AlterColumn("dbo.Clients", "NumberID", c => c.String());
            AlterColumn("dbo.Clients", "UserName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Designers", "ChartsHelped", c => c.Int(nullable: false));
            AlterColumn("dbo.Designers", "UserName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Clients", "UserName");
            AddPrimaryKey("dbo.Designers", "UserName");
            DropColumn("dbo.Charts", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Charts", "Price", c => c.Double(nullable: false));
            DropPrimaryKey("dbo.Designers");
            DropPrimaryKey("dbo.Clients");
            AlterColumn("dbo.Designers", "UserName", c => c.String());
            AlterColumn("dbo.Designers", "ChartsHelped", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Clients", "UserName", c => c.String());
            AlterColumn("dbo.Clients", "NumberID", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Architects");
            AddPrimaryKey("dbo.Designers", "ChartsHelped");
            AddPrimaryKey("dbo.Clients", "NumberID");
        }
    }
}
