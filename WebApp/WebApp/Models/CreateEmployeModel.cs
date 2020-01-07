using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CreateEmployeModel
    {
        public CompanyEmployee employee { get; set; }
        public List<CompanyDepartment> departments { get; set; }
    }
}