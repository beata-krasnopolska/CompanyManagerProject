namespace CompanyManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonDBv4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PhoneNo", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "PhoneNo");
        }
    }
}
