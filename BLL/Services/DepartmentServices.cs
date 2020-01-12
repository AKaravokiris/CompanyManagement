using DataModels.Context;
using DataModels.DomainModels;
using DomainClasses.CommonBussinessServices;
using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
     public class DepartmentServices: IDepartmentService
    {
        Repository<CompanyDepartment> departmentRepo;
        public DepartmentServices(CompanyContext _context)
        {
            departmentRepo = new Repository<CompanyDepartment>(_context);
        }
        public string InsertNewDepartment(CompanyDepartment department) {
            department.CurrentEmployees = 0;
            departmentRepo.Add(department);
            departmentRepo.Save();
            return "New department added";
        }
        public List<CompanyDepartment> GetAllDepartments()
        {
            return departmentRepo.List().ToList();
        }
        public CompanyDepartment GetDepartmentByID(Guid departmentID)
        {
            return departmentRepo.GetById(departmentID);
        }
        public string EditExistingDepartment(CompanyDepartment department)
        {
            if (department.maxEmployees<department.CurrentEmployees)
            {
                throw new Exception(string.Format(Messages.sCurrentGreaterThanMax, department.CurrentEmployees,department.maxEmployees));
            }
            departmentRepo.Update(department);
            departmentRepo.Save();
            return "Department updated";
        }
        public string DeleteDepartment(CompanyDepartment department)
        {
            string result = string.Empty;
            if (!DepartmentHasEmployees(department))
            {
                departmentRepo.Delete(department);
                departmentRepo.Save();
                result = "Department has been deleted";
            }
            else
            {
                throw new Exception( string.Format(Messages.sNotEmptyDepartment, department.CurrentEmployees));
            }
            return result;
        }
        public string DeleteDepartmentByID(System.Guid departmentID) {
            CompanyDepartment department= departmentRepo.GetById(departmentID);
            return DeleteDepartment(department);
        }
        private  bool DepartmentHasEmployees(CompanyDepartment department)
        {
            return department.CurrentEmployees > 0;
        }
    }
}
