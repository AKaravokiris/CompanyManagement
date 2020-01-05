using System;

namespace DomainClasses.Interfaces
{
    interface ICompanyEmployee
    {
        Guid ID { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }

        string emailAddress { get; set; }

        DateTime birthDate { get; set; }

        ICompanyDepartment departmentID { get; set; }
    }
}
