namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Charts",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        NumberID = c.String(nullable: false, maxLength: 128),
                        Telephone = c.String(),
                        Address = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Registration = c.DateTime(nullable: false),
                        LastEntry = c.DateTime(nullable: false),
                        FirstEntry = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NumberID);
            
            CreateTable(
                "dbo.Designers",
                c => new
                    {
                        ChartsHelped = c.Int(nullable: false, identity: true),
                        ClientsHelped = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Registration = c.DateTime(nullable: false),
                        LastEntry = c.DateTime(nullable: false),
                        FirstEntry = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ChartsHelped);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Designers");
            DropTable("dbo.Clients");
            DropTable("dbo.Charts");
        }
    }
}
