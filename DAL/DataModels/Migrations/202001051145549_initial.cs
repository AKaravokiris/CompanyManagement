namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyDepartments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        maxEmployee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CompanyEmployees",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        firstName = c.String(),
                        lastName = c.String(),
                        emailAddress = c.String(),
                        birthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompanyEmployees");
            DropTable("dbo.CompanyDepartments");
        }
    }
}
