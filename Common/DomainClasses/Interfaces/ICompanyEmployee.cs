using System;

namespace DomainClasses.Interfaces
{
    public interface ICompanyEmployee
    {
        Guid ID { get; }
        string firstName { get; set; }
        string lastName { get; set; }

        string emailAddress { get; set; }

        DateTime birthDate { get; set; }

        ICompanyDepartment departmentID { get; set; }
    }
}
