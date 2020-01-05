using DomainClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.DomainModels
{
    [NotMapped]
    public class CompanyEmployeeRepo : ICompanyEmployeeRepo
    {
        public CompanyEmployeeRepo()
        {

        }
        public Guid ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public DateTime birthDate { get; set; }

        
        public ICompanyDepartment departmentID { get; set; }

        public string DeleteEmployee(ICompanyEmployee Employee)
        {
            throw new NotImplementedException();
        }

        public string EditEmployee(ICompanyEmployee Employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICompanyEmployee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public string InsertNewEmployee(ICompanyEmployee Employee)
        {
            throw new NotImplementedException();
        }
    }
}
