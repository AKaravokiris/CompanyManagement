using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.CommonClasses
{
    public class CompanyDepartment
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public int maxEmployees { get; set; }
        public int CurrentEmployees { get; set; }

        public virtual string Create(CompanyDepartment department)
        {
            return string.Empty;
        }

        public virtual List<CompanyDepartment> Read()
        {
            return null;
        }

        public virtual string Update(CompanyDepartment department)
        {
            return string.Empty;
        }

        public virtual string Delete(CompanyDepartment department)
        {
            return string.Empty;
        }
    }
}
