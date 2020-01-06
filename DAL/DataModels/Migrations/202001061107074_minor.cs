﻿namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CompanyEmployees", new[] { "CompanyDepartment_ID" });
            CreateIndex("dbo.CompanyEmployees", "companyDepartment_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CompanyEmployees", new[] { "companyDepartment_ID" });
            CreateIndex("dbo.CompanyEmployees", "CompanyDepartment_ID");
        }
    }
}
