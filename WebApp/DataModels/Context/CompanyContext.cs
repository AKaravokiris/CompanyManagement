using DataModels.DomainModels;
using DomainClasses.CommonClasses;
using System.Data.Entity;

namespace DataModels.Context
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(string connString)
        : base(connString)
        {
            
        }

        public DbSet<CompanyDepartment> departments { get; set; }
        public DbSet<CompanyEmployee> employees { get; set; }
    }
}
