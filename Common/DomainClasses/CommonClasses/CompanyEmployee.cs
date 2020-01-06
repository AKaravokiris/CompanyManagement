using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.CommonClasses
{
    public class CompanyEmployee
    {
        public Guid ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public DateTime birthDate { get; set; }
        [ForeignKey("companyDepartment")]
        public Guid CompanyDepartment_ID { get; set; }

        [Required]
        public CompanyDepartment companyDepartment { get; set; }

        public virtual string Create(CompanyEmployee Employee)
        {
            return string.Empty;
        }

        public virtual List<CompanyEmployee> Read()
        {
            return null;
        }

        public virtual string Update(CompanyEmployee Employee)
        {
            return string.Empty;
        }

        public virtual string Delete(CompanyEmployee Employee)
        {
            return string.Empty;
        }
    }
}
