using DataModels.DomainModels;
using DomainClasses.CommonClasses;
using DomainClasses.Interfaces;

namespace Services
{
    public class CompanyDepartmentServices
    {
        public string InsertNewDepartment(ICompanyDepartment department) {
            CompanyDepartmentRepo departmentRepo = new CompanyDepartmentRepo();
            return departmentRepo.InsertNewDepartment(department);
        }

    }
}
