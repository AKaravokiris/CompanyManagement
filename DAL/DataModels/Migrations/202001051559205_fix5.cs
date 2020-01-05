namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix5 : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.CompanyEmployees");
        }
    }
}
