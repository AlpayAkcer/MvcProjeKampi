namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1_contact_adding_datetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "CreateDate");
        }
    }
}
