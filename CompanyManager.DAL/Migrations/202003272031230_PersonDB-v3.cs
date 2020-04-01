namespace CompanyManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonDBv3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.People", name: "PostId_Id", newName: "PostId");
            RenameIndex(table: "dbo.People", name: "IX_PostId_Id", newName: "IX_PostId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.People", name: "IX_PostId", newName: "IX_PostId_Id");
            RenameColumn(table: "dbo.People", name: "PostId", newName: "PostId_Id");
        }
    }
}
