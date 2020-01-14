namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyDepartments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyEmployees", "firstName", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyEmployees", "lastName", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyEmployees", "emailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyEmployees", "emailAddress", c => c.String());
            AlterColumn("dbo.CompanyEmployees", "lastName", c => c.String());
            AlterColumn("dbo.CompanyEmployees", "firstName", c => c.String());
            AlterColumn("dbo.CompanyDepartments", "Name", c => c.String());
        }
    }
}
