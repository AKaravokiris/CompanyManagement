namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingCurrentNoOfEmployees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyDepartments", "maxEmployees", c => c.Int(nullable: false));
            AddColumn("dbo.CompanyDepartments", "CurrentEmployees", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyDepartments", "maxEmployee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyDepartments", "maxEmployee", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyDepartments", "CurrentEmployees");
            DropColumn("dbo.CompanyDepartments", "maxEmployees");
        }
    }
}
