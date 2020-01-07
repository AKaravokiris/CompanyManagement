using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BusinessServices
    {
        readonly InternalService internalService;
        public readonly CompanyDepartmentServices companyDepartmentService;
        public readonly CompanyEmployeeServices companyEmployeService;

        public BusinessServices()
        {
            this.internalService = new InternalService();
            this.companyDepartmentService = new CompanyDepartmentServices();
            this.companyEmployeService = new CompanyEmployeeServices();
        }
    }
}
