using DomainClasses.CommonRepos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.CommonClasses
{
    public class CompanyDepartment: EntityBase
    {
        public CompanyDepartment()
        {
            if (ID==Guid.Empty)
            {
             ID = Guid.NewGuid();
            }
            CurrentEmployees = 0;
        }

        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Max Employees")]
        public int maxEmployees { get; set; }
        [Required]
        [Display(Name = "Current Employees")]
        public int CurrentEmployees { get; set; }
    }
}
