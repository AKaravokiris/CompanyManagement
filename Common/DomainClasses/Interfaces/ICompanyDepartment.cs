using System;

namespace DomainClasses.Interfaces
{
    public interface ICompanyDepartment
    {
        Guid ID { get; }
        string Name { get; set; }
        int maxEmployee { get; set; }

    }
}