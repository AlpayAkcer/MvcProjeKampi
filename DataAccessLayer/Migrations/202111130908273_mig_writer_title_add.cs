﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_title_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "Title", c => c.String(maxLength: 70));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "Title");
        }
    }
}