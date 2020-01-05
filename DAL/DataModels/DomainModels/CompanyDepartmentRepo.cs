using DataModels.Context;
using DomainClasses.CommonClasses;
using DomainClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.DomainModels
{
    [NotMapped]
    public class CompanyDepartmentRepo : ICompanyDepartmentRepo
    {
        private readonly CompanyContext _context;

        public CompanyDepartmentRepo()
        {
            _context = GetDBContext();
        }
        

        public ICollection<CompanyEmployeeRepo> employees { get; set; }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int maxEmployee { get; set; }

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

        public IEnumerable<ICompanyDepartment> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public string EditDepartment(ICompanyDepartment department)
        {
            throw new NotImplementedException();
        }

        public string DeleteDepartment(ICompanyDepartment department)
        {
            throw new NotImplementedException();
        }
    }
}