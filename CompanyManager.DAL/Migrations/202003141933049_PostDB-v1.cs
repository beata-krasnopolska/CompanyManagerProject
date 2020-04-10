namespace CompanyManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.People", "PostId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "PostId");
            DropTable("dbo.Posts");
        }
    }
}
