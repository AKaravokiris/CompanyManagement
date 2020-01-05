using DataModels.DomainModels;
using DomainClasses.Interfaces;

namespace Services
{
    public class CompanyDepartmentServices
    {
        public string InsertNewDepartment(ICompanyDepartment department) {
            CompanyDepartment departmentRepo = new CompanyDepartment();
            return departmentRepo.InsertNewDepartment(department);
        }

    }
}
