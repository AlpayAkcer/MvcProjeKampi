namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_image_size_change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "Picture", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "Picture", c => c.String(maxLength: 150));
        }
    }
}
