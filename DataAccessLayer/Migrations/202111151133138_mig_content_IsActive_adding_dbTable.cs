namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_content_IsActive_adding_dbTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "IsActive");
        }
    }
}
