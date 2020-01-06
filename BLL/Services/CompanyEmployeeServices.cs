using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CompanyEmployeeServices
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
                if (DepartmentIsMaxed(employee))
                {
                    result = Messages.sDepartmentIsMax;
                }
                else
                {
                    IncreaseCurrentEmployeesInDepartment(employee);
                    result = _internalService._EmployeeRepo.Create(employee);
                }

            }
            catch (Exception ex)
            {
                result = string.Format("{0} {1}", ex.Message ?? string.Empty, ex.InnerException.Message ?? string.Empty);
            }
            return result;
        }

        private string CheckDepartmentMaximumLimit(CompanyEmployee employee)
        {
            string result = string.Empty;
            if (DepartmentIsMaxed(employee))
            {
                result = Messages.sDepartmentIsMax;
            }

            return result;
        }

        private void IncreaseCurrentEmployeesInDepartment(CompanyEmployee employee)
        {
            employee.companyDepartment.CurrentEmployees++;
        }

        private static bool DepartmentIsMaxed(CompanyEmployee employee)
        {
            return employee.companyDepartment.maxEmployees == employee.companyDepartment.CurrentEmployees;
        }

        private  bool DepartmentExists(CompanyEmployee employee, List<CompanyDepartment> departments)
        {
            return departments.Exists(x => x.ID == employee.companyDepartment.ID);
        }

        public List<CompanyEmployee> GetAllEmployees()
        {
            return _internalService._EmployeeRepo.Read();
        }

        public string EditExistingEmployee(CompanyEmployee editedEmployee)
        {
            string result = string.Empty;
            List<CompanyEmployee> employees = _internalService._EmployeeRepo.Read();
            CompanyEmployee oldEmployee = GetOldDataOfEditingEmployee(editedEmployee, employees);
            if (!employeeStayedInSameDepartment(editedEmployee, oldEmployee))
            {
                //List<CompanyDepartment> departments = _internalService._departmentRepo.Read();
                if (DepartmentIsMaxed(editedEmployee))
                {
                    result = Messages.sDepartmentIsMax;
                }
                else
                {
                    IncreaseCurrentEmployeesInDepartment(editedEmployee);
                    result = _internalService._EmployeeRepo.Update(editedEmployee);
                    oldEmployee.companyDepartment.CurrentEmployees--;
                    _internalService._departmentRepo.Update(oldEmployee.companyDepartment);
                }
            }
            else
            {
                result = _internalService._EmployeeRepo.Update(editedEmployee);
            }
            return result;
        }

        private  bool NewDepartmentIsMaxedOut(string result)
        {
            return !string.IsNullOrEmpty(result);
        }

        private  CompanyEmployee GetOldDataOfEditingEmployee(CompanyEmployee editedEmployee, List<CompanyEmployee> employees)
        {
            return employees.FirstOrDefault(x => x.ID == editedEmployee.ID);
        }

        private  bool employeeStayedInSameDepartment(CompanyEmployee editedEmployee, CompanyEmployee oldEmployee)
        {
            return oldEmployee != null && oldEmployee.companyDepartment.ID == editedEmployee.companyDepartment.ID;
        }

        public string DeleteEmployee(CompanyEmployee Employee)
        {
            Employee.companyDepartment.CurrentEmployees--;
            //_internalService._departmentRepo.Update(Employee.companyDepartment);
            return _internalService._EmployeeRepo.Delete(Employee);
        }
    }
}
