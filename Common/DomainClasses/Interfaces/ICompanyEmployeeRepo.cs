using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Interfaces
{
    public interface ICompanyEmployeeRepo: ICompanyEmployee
    {
        string InsertNewEmployee(ICompanyEmployee Employee);
        IEnumerable<ICompanyEmployee> GetAllEmployees();
        string EditEmployee(ICompanyEmployee Employee);
        string DeleteEmployee(ICompanyEmployee Employee);
    }
}
