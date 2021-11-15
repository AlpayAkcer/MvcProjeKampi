namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1_contact_adding_table_subject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Subject", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Subject");
        }
    }
}
