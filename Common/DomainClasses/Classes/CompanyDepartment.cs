using DomainClasses.Interfaces;
using System;

namespace DomainClasses.Classes
{
    class CompanyDepartment : ICompanyDepartment
    {
        public CompanyDepartment()
        {
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public int maxEmployee { get; set; }
    }
}
