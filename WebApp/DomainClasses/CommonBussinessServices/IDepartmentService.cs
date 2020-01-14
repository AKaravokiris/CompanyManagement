using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.CommonBussinessServices
{
    public interface IDepartmentService
    {
        string InsertNewDepartment(CompanyDepartment department);
        List<CompanyDepartment> GetAllDepartments();
        CompanyDepartment GetDepartmentByID(Guid departmentID);
        string EditExistingDepartment(CompanyDepartment department);
        string DeleteDepartment(CompanyDepartment department);
        string DeleteDepartmentByID(System.Guid departmentID);
    }
}
