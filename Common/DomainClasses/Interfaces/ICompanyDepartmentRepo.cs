using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Interfaces
{
    public interface ICompanyDepartmentRepo: ICompanyDepartment
    {
        string InsertNewDepartment(ICompanyDepartment department);
        IEnumerable<ICompanyDepartment> GetAllDepartments();
        string EditDepartment(ICompanyDepartment department);
        string DeleteDepartment(ICompanyDepartment department);
    }
}
