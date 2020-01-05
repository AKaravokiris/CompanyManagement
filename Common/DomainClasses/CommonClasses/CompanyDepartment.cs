using DomainClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.CommonClasses
{
    public class CompanyDepartment : ICompanyDepartment
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public int maxEmployee { get; set; }
    }
}
