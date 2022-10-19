namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signatures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signatures", "FirstSigner_Id", c => c.Int());
            CreateIndex("dbo.Signatures", "FirstSigner_Id");
            AddForeignKey("dbo.Signatures", "FirstSigner_Id", "dbo.Workers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Signatures", "FirstSigner_Id", "dbo.Workers");
            DropIndex("dbo.Signatures", new[] { "FirstSigner_Id" });
            DropColumn("dbo.Signatures", "FirstSigner_Id");
        }
    }
}
