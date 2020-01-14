using DataModels.DomainModels;
using DomainClasses.CommonClasses;
using System.Data.Entity;

namespace DataModels.Context
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base()
        {
            
        }

        public DbSet<CompanyDepartment> departments { get; set; }
        public DbSet<CompanyEmployee> employees { get; set; }
    }
}
