using DataModels.Context;
using DataModels.DomainModels;
using DomainClasses.CommonBussinessServices;
using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class EmployeeServices: IEmployeeService
    {
        Repository<CompanyEmployee> employeeRepo;
        Repository<CompanyDepartment> departmentRepo;
        public EmployeeServices(CompanyContext _context)
        {
            departmentRepo = new Repository<CompanyDepartment>(_context);
            employeeRepo = new Repository<CompanyEmployee>(_context);            
        }
        public List<CompanyEmployee> GetAllEmployees()
        {            
            return employeeRepo.List().ToList();
        }
        public CompanyEmployee GetEmployeeByID(Guid employeeID)
        {
            return employeeRepo.GetById(employeeID);
        }
        public string InsertNewEmployee(CompanyEmployee employee)
        {
            string result = string.Empty;
            try
            {
                employee.companyDepartment= departmentRepo.GetById(employee.CompanyDepartment_ID);
                if (DepartmentIsMaxed(employee))
                {
                    result = Messages.sDepartmentIsMax;
                }
                else
                {
                    IncreaseCurrentEmployeesInNewDepartment(employee);
                    employeeRepo.Add(employee);
                    employeeRepo.Save();
                    result = "new Employee Saved";
                }
            }
            catch (Exception ex)
            {
                result = string.Format("{0} {1}", ex.Message ?? string.Empty, ex.InnerException.Message ?? string.Empty);
            }
            return result;
        }//todo
        public string EditExistingEmployee(CompanyEmployee editedEmployee)
        {
            string result = string.Empty;
            editedEmployee.companyDepartment = GetNewDepartment(editedEmployee.CompanyDepartment_ID);
            CompanyEmployee oldEmployee = GetOldDataOfEditingEmployee(editedEmployee);
            oldEmployee.companyDepartment = GetOldDepartment(oldEmployee.CompanyDepartment_ID);
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
                employeeRepo.Update(editedEmployee);
                employeeRepo.Save();
                result = "updated employee and count of current employees in new and old department";
            }
            return result;
        }
        public string DeleteEmployee(CompanyEmployee employee)
        {
            employee.companyDepartment = GetOldDepartment(employee.CompanyDepartment_ID);
            employee.companyDepartment.CurrentEmployees--;
            departmentRepo.Update(employee.companyDepartment);
            departmentRepo.Save();
            employeeRepo.Delete(employee);
            employeeRepo.Save();
            return "Deleted employee and current employe count decreased";
        }
        public string DeleteEmployeeByID(Guid employeeID)
        {
            CompanyEmployee employee =employeeRepo.GetById(employeeID);            
            return DeleteEmployee(employee);
        }
        private CompanyDepartment GetOldDepartment(Guid companyDepartment_ID)
        {
            return departmentRepo.GetById(companyDepartment_ID);
        }
        private CompanyDepartment GetNewDepartment(Guid companyDepartment_ID)
        {
            return departmentRepo.GetById(companyDepartment_ID);
        }
        private string UpdateEmployeeAndDepartmentCurrentEmployee(CompanyEmployee editedEmployee, CompanyEmployee oldEmployee)
        {
            IncreaseCurrentEmployeesInNewDepartment(editedEmployee);

            UpdateEmployee(editedEmployee);
            string result = "Updated employee and department";
            DecreaseCurrentEmployeesInOldDepartment(oldEmployee);
            return result;
        }
        private void UpdateEmployee(CompanyEmployee editedEmployee)
        {
            editedEmployee.CompanyDepartment_ID = editedEmployee.companyDepartment.ID;
            employeeRepo.Update(editedEmployee);
            employeeRepo.Save();
        }
        private void IncreaseCurrentEmployeesInNewDepartment(CompanyEmployee employee)
        {
            employee.companyDepartment.CurrentEmployees++;
           departmentRepo.Update(employee.companyDepartment);
        }
        private  bool DepartmentIsMaxed(CompanyEmployee employee)
        {
            return employee.companyDepartment.maxEmployees == employee.companyDepartment.CurrentEmployees;
        }
        private  void DecreaseCurrentEmployeesInOldDepartment(CompanyEmployee oldEmployee)
        {
            oldEmployee.companyDepartment.CurrentEmployees--;
            departmentRepo.Update(oldEmployee.companyDepartment);
            departmentRepo.Save();
        }
        private  CompanyEmployee GetOldDataOfEditingEmployee(CompanyEmployee editedEmployee)
        {
            return employeeRepo.GetById( editedEmployee.ID);
        }
        private  bool employeeStayedInSameDepartment(CompanyEmployee editedEmployee, CompanyEmployee oldEmployee)
        {
            return oldEmployee != null && oldEmployee.companyDepartment.ID == editedEmployee.companyDepartment.ID;
        }

        public List<CompanyEmployee> GetAllEmployeesWithEagerLoad() {
            return employeeRepo.GetAll(x=>x.companyDepartment).ToList();
        }
    }
}
