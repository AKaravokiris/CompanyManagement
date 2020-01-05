using System;

namespace DomainClasses.Interfaces
{
    interface ICompanyDepartment
    {
        Guid ID { get; set; }
        string Name { get; set; }
        int maxEmployee { get; set; }
    }
}