namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class robustVersion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CompanyEmployees", "surName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyEmployees", "surName", c => c.String());
        }
    }
}
