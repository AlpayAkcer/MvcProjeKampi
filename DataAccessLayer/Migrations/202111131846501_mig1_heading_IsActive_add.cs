namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1_heading_IsActive_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "IsActive");
        }
    }
}
