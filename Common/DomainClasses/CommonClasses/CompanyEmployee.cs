using DomainClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.CommonClasses
{
    public class CompanyEmployee : ICompanyEmployee
    {
        public Guid ID { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public DateTime birthDate { get; set; }

        [ForeignKey("ID")]
        public ICompanyDepartment departmentID { get; set; }
    }
}
