namespace Noliktava2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "ToDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "ToDate", c => c.DateTime(nullable: false));
        }
    }
}
