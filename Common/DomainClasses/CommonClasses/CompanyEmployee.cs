using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.CommonClasses
{
    public class CompanyEmployee
    {
        public CompanyEmployee()
        {
            ID = Guid.NewGuid();
        }
        [Required]
        public Guid ID { get ;  set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string emailAddress { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime birthDate { get; set; }

        [Required]
        [Display(Name = "Company Department")]
        [ForeignKey("companyDepartment")]
        public Guid CompanyDepartment_ID { get; set; }

        public CompanyDepartment companyDepartment { get; set; }

        public virtual string Create(CompanyEmployee Employee)
        {
            return string.Empty;
        }

        public virtual List<CompanyEmployee> Read()
        {
            return null;
        }

        public virtual CompanyEmployee ReadByID(Guid employeeID)
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
