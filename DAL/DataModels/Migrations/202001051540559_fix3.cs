namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyEmployees", "surName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyEmployees", "surName");
        }
    }
}
