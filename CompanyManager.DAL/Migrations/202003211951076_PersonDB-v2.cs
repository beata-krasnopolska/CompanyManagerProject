namespace CompanyManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonDBv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PostId_Id", c => c.Int());
            CreateIndex("dbo.People", "PostId_Id");
            AddForeignKey("dbo.People", "PostId_Id", "dbo.Posts", "Id");
            DropColumn("dbo.People", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "PostId", c => c.Int(nullable: false));
            DropForeignKey("dbo.People", "PostId_Id", "dbo.Posts");
            DropIndex("dbo.People", new[] { "PostId_Id" });
            DropColumn("dbo.People", "PostId_Id");
        }
    }
}
