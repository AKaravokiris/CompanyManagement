using DomainClasses.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.DomainModels
{
    public class CompanyEmployee : ICompanyEmployee
    {
        public CompanyEmployee()
        {

        }
        public Guid ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public DateTime birthDate { get; set; }

        [ForeignKey("ID")]
        public ICompanyDepartment departmentID { get; set; }
    }
}
