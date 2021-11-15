namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1_about_table_summary_adding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Summary", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "Summary");
        }
    }
}
