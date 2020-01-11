using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.CommonBussinessServices
{
    public interface IEmployeeService
    {
        List<CompanyEmployee> GetAllEmployees();
        CompanyEmployee GetEmployeeByID(Guid employeeID);
        string InsertNewEmployee(CompanyEmployee employee);
        string EditExistingEmployee(CompanyEmployee editedEmployee);
        string DeleteEmployee(CompanyEmployee Employee);
        string DeleteEmployeeByID(System.Guid employeeID);
       
    }
}
