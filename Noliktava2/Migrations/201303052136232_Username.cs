namespace Noliktava2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Username : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "UserName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "UserName");
        }
    }
}
