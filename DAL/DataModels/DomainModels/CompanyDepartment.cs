﻿using DataModels.Context;
using DomainClasses.Interfaces;
using System;
using System.Collections.Generic;

namespace DataModels.DomainModels
{
    public class CompanyDepartment : ICompanyDepartmentRepo
    {
        private readonly CompanyContext _context;

        public CompanyDepartment()
        {
            _context = GetDBContext();
        }


        public Guid ID { get; set; }
        public string Name { get; set; }
        public int maxEmployee { get; set; }
        public ICollection<CompanyEmployee> employees { get; set; }

        private CompanyContext GetDBContext()
        {
            return new CompanyContext();
        }


        public string InsertNewDepartment(ICompanyDepartment department)
        {
            string result = "OK";
            CompanyDepartment compDepartment = (department as CompanyDepartment);
            try
            {
                compDepartment.ID = Guid.NewGuid();
                _context.departments.Add(compDepartment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.InnerException.Message;
            }
            return result;
        }
    }
}