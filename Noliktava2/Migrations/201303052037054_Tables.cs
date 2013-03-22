//namespace Noliktava2.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class Tables : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Employee",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        PositionId = c.Int(nullable: false),
//                        TelephoneNumber = c.String(maxLength: 20),
//                        LastName = c.String(nullable: false, maxLength: 30),
//                        FirstName = c.String(nullable: false, maxLength: 30),
//                        FromDate = c.DateTime(nullable: false),
//                        ToDate = c.DateTime(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Position", t => t.PositionId, cascadeDelete: true)
//                .Index(t => t.PositionId);
            
//            CreateTable(
//                "dbo.Item",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Name = c.String(nullable: false, maxLength: 30),
//                        Price = c.Double(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "dbo.Vendor",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        EmployeeId = c.Int(nullable: false),
//                        TelephoneNumber = c.String(maxLength: 20),
//                        Name = c.String(nullable: false, maxLength: 30),
//                        Address = c.String(nullable: false, maxLength: 50),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
//                .Index(t => t.EmployeeId);
            
//            CreateTable(
//                "dbo.Client",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        EmployeeId = c.Int(nullable: false),
//                        TelephoneNumber = c.String(maxLength: 20),
//                        Name = c.String(nullable: false, maxLength: 30),
//                        Address = c.String(nullable: false, maxLength: 50),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
//                .Index(t => t.EmployeeId);
            
//            CreateTable(
//                "dbo.Purchase",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        VendorId = c.Int(nullable: false),
//                        Date = c.DateTime(nullable: false),
//                        IsCompleted = c.Boolean(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Vendor", t => t.VendorId, cascadeDelete: true)
//                .Index(t => t.VendorId);
            
//            CreateTable(
//                "dbo.Sale",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        ClientId = c.Int(nullable: false),
//                        Date = c.DateTime(nullable: false),
//                        IsCompleted = c.Boolean(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
//                .Index(t => t.ClientId);
            
//            CreateTable(
//                "dbo.PurchaseLine",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        PurchaseId = c.Int(nullable: false),
//                        ItemId = c.Int(nullable: false),
//                        Quantity = c.Double(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Purchase", t => t.PurchaseId, cascadeDelete: true)
//                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
//                .Index(t => t.PurchaseId)
//                .Index(t => t.ItemId);
            
//            CreateTable(
//                "dbo.SalesLine",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        SaleId = c.Int(nullable: false),
//                        ItemId = c.Int(nullable: false),
//                        Quantity = c.Double(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
//                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
//                .Index(t => t.SaleId)
//                .Index(t => t.ItemId);
            
//            AlterColumn("dbo.Position", "Code", c => c.String(nullable: false, maxLength: 20));
//            AlterColumn("dbo.Position", "Name", c => c.String(nullable: false, maxLength: 100));
//        }
        
//        public override void Down()
//        {
//            DropIndex("dbo.SalesLine", new[] { "ItemId" });
//            DropIndex("dbo.SalesLine", new[] { "SaleId" });
//            DropIndex("dbo.PurchaseLine", new[] { "ItemId" });
//            DropIndex("dbo.PurchaseLine", new[] { "PurchaseId" });
//            DropIndex("dbo.Sale", new[] { "ClientId" });
//            DropIndex("dbo.Purchase", new[] { "VendorId" });
//            DropIndex("dbo.Client", new[] { "EmployeeId" });
//            DropIndex("dbo.Vendor", new[] { "EmployeeId" });
//            DropIndex("dbo.Employee", new[] { "PositionId" });
//            DropForeignKey("dbo.SalesLine", "ItemId", "dbo.Item");
//            DropForeignKey("dbo.SalesLine", "SaleId", "dbo.Sale");
//            DropForeignKey("dbo.PurchaseLine", "ItemId", "dbo.Item");
//            DropForeignKey("dbo.PurchaseLine", "PurchaseId", "dbo.Purchase");
//            DropForeignKey("dbo.Sale", "ClientId", "dbo.Client");
//            DropForeignKey("dbo.Purchase", "VendorId", "dbo.Vendor");
//            DropForeignKey("dbo.Client", "EmployeeId", "dbo.Employee");
//            DropForeignKey("dbo.Vendor", "EmployeeId", "dbo.Employee");
//            DropForeignKey("dbo.Employee", "PositionId", "dbo.Position");
//            AlterColumn("dbo.Position", "Name", c => c.String(maxLength: 100));
//            AlterColumn("dbo.Position", "Code", c => c.String(maxLength: 20));
//            DropTable("dbo.SalesLine");
//            DropTable("dbo.PurchaseLine");
//            DropTable("dbo.Sale");
//            DropTable("dbo.Purchase");
//            DropTable("dbo.Client");
//            DropTable("dbo.Vendor");
//            DropTable("dbo.Item");
//            DropTable("dbo.Employee");
//        }
//    }
//}
