namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFK2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyEmployees", "CompanyDepartment_ID", c => c.Guid());
            CreateIndex("dbo.CompanyEmployees", "CompanyDepartment_ID");
            AddForeignKey("dbo.CompanyEmployees", "CompanyDepartment_ID", "dbo.CompanyDepartments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyEmployees", "CompanyDepartment_ID", "dbo.CompanyDepartments");
            DropIndex("dbo.CompanyEmployees", new[] { "CompanyDepartment_ID" });
            DropColumn("dbo.CompanyEmployees", "CompanyDepartment_ID");
        }
    }
}
