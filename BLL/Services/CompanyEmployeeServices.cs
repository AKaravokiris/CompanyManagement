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
                List<CompanyDepartment > departments=_internalService._departmentRepo.Read();
                employee.companyDepartment=departments.Find(x => x.ID == employee.CompanyDepartment_ID);
                if (DepartmentIsMaxed(employee))
                {
                    result = Messages.sDepartmentIsMax;
                }
                else
                {
                    IncreaseCurrentEmployeesInNewDepartment(employee);
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

        private void IncreaseCurrentEmployeesInNewDepartment(CompanyEmployee employee)
        {
            employee.companyDepartment.CurrentEmployees++;
            _internalService._departmentRepo.Update(employee.companyDepartment);
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
                if (DepartmentIsMaxed(editedEmployee))
                {
                    result = Messages.sDepartmentIsMax;
                }
                else
                {
                    result = UpdateEmployeeAndDepartmentCurrentEmployee(editedEmployee, oldEmployee);
                }
            }
            else
            {
                result = _internalService._EmployeeRepo.Update(editedEmployee);
            }
            return result;
        }

        private string UpdateEmployeeAndDepartmentCurrentEmployee(CompanyEmployee editedEmployee, CompanyEmployee oldEmployee)
        {
            IncreaseCurrentEmployeesInNewDepartment(editedEmployee);
            string result = _internalService._EmployeeRepo.Update(editedEmployee);
            DecreaseCurrentEmployessInOldDepartment(oldEmployee);            
            return result;
        }

        private  void DecreaseCurrentEmployessInOldDepartment(CompanyEmployee oldEmployee)
        {
            oldEmployee.companyDepartment.CurrentEmployees--;
            _internalService._departmentRepo.Update(oldEmployee.companyDepartment);
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
            _internalService._departmentRepo.Update(Employee.companyDepartment);
            return _internalService._EmployeeRepo.Delete(Employee);
        }

        public string DeleteEmployeeByID(System.Guid employeeID)
        {
            List<CompanyEmployee> employees = GetAllEmployees();
            CompanyEmployee employee = employees.Find(x => x.ID == employeeID);
            return DeleteEmployee(employee);
        }
    }
}
