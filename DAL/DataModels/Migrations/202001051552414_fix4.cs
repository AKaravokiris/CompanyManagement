namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix4 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CompanyEmployees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CompanyEmployees",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        firstName = c.String(),
                        surName = c.String(),
                        lastName = c.String(),
                        emailAddress = c.String(),
                        birthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
