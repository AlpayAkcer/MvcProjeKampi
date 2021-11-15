namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1_add_about_picture_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Picture", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "Picture");
        }
    }
}
