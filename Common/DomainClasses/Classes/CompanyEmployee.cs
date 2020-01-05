﻿using DomainClasses.Interfaces;
using System;

namespace DomainClasses.Classes
{
    class CompanyEmployee : ICompanyEmployee
    {
        public CompanyEmployee()
        {

        }
        public Guid ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public DateTime birthDate { get; set; }
        public ICompanyDepartment departmentID { get; set; }
    }
}
