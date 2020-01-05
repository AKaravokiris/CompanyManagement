using DataModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class InternalService
    {
        public CompanyDepartmentRepo _departmentRepo { get; private set; }
        public CompanyEmployeeRepo _EmployeeRepo { get; private set; }
        public InternalService()
        {
            _departmentRepo = new CompanyDepartmentRepo();
            _EmployeeRepo = new CompanyEmployeeRepo();
        }
    }
}
