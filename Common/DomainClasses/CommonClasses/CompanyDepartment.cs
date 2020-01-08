using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.CommonClasses
{
    public class CompanyDepartment
    {
        public CompanyDepartment()
        {
            ID = Guid.NewGuid();
        }

        [Required]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Max Employees")]
        public int maxEmployees { get; set; }
        [Required]
        [Display(Name = "Current Employees")]
        public int CurrentEmployees { get; set; }

        public virtual string Create(CompanyDepartment department)
        {
            return string.Empty;
        }

        public virtual List<CompanyDepartment> Read()
        {
            return null;
        }

        public virtual CompanyDepartment ReadByID(Guid departmentID)
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
