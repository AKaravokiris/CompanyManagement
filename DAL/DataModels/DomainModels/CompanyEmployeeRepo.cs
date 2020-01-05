using DataModels.Context;
using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataModels.DomainModels
{
    
    public class CompanyEmployeeRepo : CompanyEmployee
    {
        private readonly CompanyContext _context;
        public CompanyEmployeeRepo()
        {
            _context = GetDBContext();
        }

        private CompanyContext GetDBContext()
        {
            return new CompanyContext();
        }
        public override string Create(CompanyEmployee employee)
        {
            string result = "Created";
            try
            {
                employee.ID = Guid.NewGuid();
                _context.employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result = GetExceptiopnMessage(ex);
            }
            return result;
        }

        private  string GetExceptiopnMessage(Exception ex)
        {
            return string.Format("{0} {1}", ex.Message ?? string.Empty, ex.InnerException.Message ?? string.Empty);
        }

        public override List<CompanyEmployee> Read()
        {
            try
            {

                return  _context.employees.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override string Update(CompanyEmployee employee)
        {
            string result = "Updated";
            try
            {
                _context.employees.Attach(employee);
                _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();            
            }
            catch (Exception ex)
            {
                result = string.Format("{0} {1}", ex.Message ?? string.Empty, ex.InnerException.Message ?? string.Empty);
            }
            return result;
        }

        public override string Delete(CompanyEmployee employee)
        {
            string result = "Deleted";
            try
            {
                _context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                result = string.Format("{0} {1}", ex.Message ?? string.Empty, ex.InnerException.Message ?? string.Empty);
            }
            return result;
        }
    }
}
