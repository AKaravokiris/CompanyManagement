using DataModels.DomainModels;
using DomainClasses.CommonClasses;
using System.Collections.Generic;

namespace Services
{
    public class CompanyDepartmentServices
    {
        InternalService _internalService;
        public CompanyDepartmentServices()
        {
            _internalService = new InternalService();
        }

        public string InsertNewDepartment(CompanyDepartment department) {
            department.CurrentEmployees = 0;
            return _internalService._departmentRepo.Create(department);
        }

        public List<CompanyDepartment> GetAllDepartments()
        {
            return _internalService._departmentRepo.Read();
        }

        public string EditExistingDepartment(CompanyDepartment department)
        {
            return _internalService._departmentRepo.Update(department);
        }

        public string DeleteDepartment(CompanyDepartment department)
        {
            string result = string.Empty;
            if (!DepartmentHasEmployees(department))
            {
                result= _internalService._departmentRepo.Delete(department);
            }
            else
            {
                result=string.Format(Messages.sNotEmptyDepartment,department.CurrentEmployees);
            }
            return result;
        }

        private  bool DepartmentHasEmployees(CompanyDepartment department)
        {
            return department.CurrentEmployees > 0;
        }
    }
}
