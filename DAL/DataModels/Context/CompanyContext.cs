using DataModels.DomainModels;
using DomainClasses.CommonClasses;
using DomainClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
