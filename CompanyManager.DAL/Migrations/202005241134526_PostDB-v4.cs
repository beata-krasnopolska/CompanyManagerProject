namespace CompanyManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostDBv4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Posts", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "Name" });
        }
    }
}
