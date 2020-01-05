using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;

namespace Services
{
    class CompanyEmployeeServices
    {
        InternalService _internalService;
        public CompanyEmployeeServices()
        {
            _internalService = new InternalService();
        }

        public string InsertNewEmployee(CompanyEmployee employee)
        {
            string result = string.Empty;
            try
            {
                List<CompanyDepartment> departments = _internalService._departmentRepo.Read();
                if (!DepartmentExists(employee, departments))
                {
                    result = Messages.sDepartmentNotExists;
                }
                else if (DepartmentIsMaxed(employee, departments))
                {
                    result = Messages.sDepartmentIsMax;
                }
                else
                {
                    result = _internalService._EmployeeRepo.Create(employee);
                    IncreaseCurrentEmployeesInDepartment(employee, departments);
                }
            }
            catch (Exception ex)
            {
                result = string.Format("{0} {1}", ex.Message ?? string.Empty, ex.InnerException.Message ?? string.Empty);
            }
            return result;
        }

        private void IncreaseCurrentEmployeesInDepartment(CompanyEmployee employee, List<CompanyDepartment> departments)
        {
            CompanyDepartment department = departments.Find(x => x.ID == employee.CompanyDepartment.ID);
            department.CurrentEmployees++;
            _internalService._departmentRepo.Update(department);
        }

        private static bool DepartmentIsMaxed(CompanyEmployee employee, List<CompanyDepartment> departments)
        {
            return departments.Find(x => x.ID == employee.CompanyDepartment.ID).maxEmployees == departments.Find(x => x.ID == employee.CompanyDepartment.ID).CurrentEmployees;
        }

        private  bool DepartmentExists(CompanyEmployee employee, List<CompanyDepartment> departments)
        {
            return departments.Exists(x => x.ID == employee.CompanyDepartment.ID);
        }

        public List<CompanyEmployee> GetAllEmployees()
        {
            return _internalService._EmployeeRepo.Read();
        }

        public string EditExistingEmployee(CompanyEmployee Employee)
        {

            return _internalService._EmployeeRepo.Update(Employee);
        }

        public string DeleteEmployee(CompanyEmployee Employee)
        {

            return _internalService._EmployeeRepo.Delete(Employee);
        }
    }
}
