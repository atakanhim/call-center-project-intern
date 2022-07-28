namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg34 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CallLogs",
                c => new
                    {
                        CallLogId = c.Int(nullable: false, identity: true),
                        CallLogDesc = c.String(),
                        CallLogStatus = c.Boolean(),
                        CreatingTime = c.DateTime(),
                        UpdatingTime = c.DateTime(),
                        CalllNumber = c.Long(),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.CallLogId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerPhone = c.Long(),
                        CustomerAddress = c.String(),
                        CustomerDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobDescription = c.String(),
                        JobMethods = c.String(),
                        IsImportant = c.Boolean(),
                        JobStatus = c.String(),
                        CreatingTime = c.DateTime(),
                        UpdatingTime = c.DateTime(),
                        CallLogId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.CallLogs", t => t.CallLogId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CallLogId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPhone = c.Long(),
                        UserMail = c.String(),
                        UserPassword = c.String(),
                        UserAddress = c.String(),
                        UserPosition = c.String(),
                        UserDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Jobs", "CallLogId", "dbo.CallLogs");
            DropForeignKey("dbo.CallLogs", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "CallLogId" });
            DropIndex("dbo.CallLogs", new[] { "CustomerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Jobs");
            DropTable("dbo.Customers");
            DropTable("dbo.CallLogs");
        }
    }
}
