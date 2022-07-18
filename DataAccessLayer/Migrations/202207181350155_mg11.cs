namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CallLogs", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CallLogs", new[] { "CustomerId" });
            AlterColumn("dbo.CallLogs", "CallLogStatus", c => c.Boolean());
            AlterColumn("dbo.CallLogs", "CreatingTime", c => c.DateTime());
            AlterColumn("dbo.CallLogs", "UpdatingTime", c => c.DateTime());
            AlterColumn("dbo.CallLogs", "CalllNumber", c => c.Long());
            AlterColumn("dbo.CallLogs", "CustomerId", c => c.Int());
            AlterColumn("dbo.Customers", "CustomerPhone", c => c.Long());
            AlterColumn("dbo.Customers", "CustomerDate", c => c.DateTime());
            AlterColumn("dbo.Jobs", "JobDescription", c => c.String());
            AlterColumn("dbo.Jobs", "IsImportant", c => c.Boolean());
            AlterColumn("dbo.Jobs", "CreatingTime", c => c.DateTime());
            AlterColumn("dbo.Jobs", "UpdatingTime", c => c.DateTime());
            AlterColumn("dbo.Users", "UserPhone", c => c.Long());
            AlterColumn("dbo.Users", "UserDate", c => c.DateTime());
            CreateIndex("dbo.CallLogs", "CustomerId");
            AddForeignKey("dbo.CallLogs", "CustomerId", "dbo.Customers", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CallLogs", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CallLogs", new[] { "CustomerId" });
            AlterColumn("dbo.Users", "UserDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UserPhone", c => c.Long(nullable: false));
            AlterColumn("dbo.Jobs", "UpdatingTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "CreatingTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "IsImportant", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jobs", "JobDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustomerDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "CustomerPhone", c => c.Long(nullable: false));
            AlterColumn("dbo.CallLogs", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.CallLogs", "CalllNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.CallLogs", "UpdatingTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CallLogs", "CreatingTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CallLogs", "CallLogStatus", c => c.Boolean(nullable: false));
            CreateIndex("dbo.CallLogs", "CustomerId");
            AddForeignKey("dbo.CallLogs", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
