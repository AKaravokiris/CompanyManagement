namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyEmployees", "CompanyDepartment_ID", c => c.Guid(nullable: false));
            CreateIndex("dbo.CompanyEmployees", "CompanyDepartment_ID");
            AddForeignKey("dbo.CompanyEmployees", "CompanyDepartment_ID", "dbo.CompanyDepartments", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyEmployees", "CompanyDepartment_ID", "dbo.CompanyDepartments");
            DropIndex("dbo.CompanyEmployees", new[] { "CompanyDepartment_ID" });
            DropColumn("dbo.CompanyEmployees", "CompanyDepartment_ID");
        }
    }
}
