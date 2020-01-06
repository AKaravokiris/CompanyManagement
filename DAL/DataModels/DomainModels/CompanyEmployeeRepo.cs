using DataModels.Context;
using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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
            string result = string.Format("Creating {0} \n", employee.firstName); ;
                try
                {
                    employee.ID = Guid.NewGuid();
                    _context.employees.Add(employee);
                    _context.Entry(employee.companyDepartment).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    result = string.Format("Created {0} \n", employee.firstName);
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
            using (CompanyContext context = GetDBContext())
            {
                try
                {

                    return context.employees.Include(x=>x.companyDepartment).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public override string Update(CompanyEmployee employee)
        {
            string result = string.Format("Updating {0} \n", employee.firstName);
            try
            {
                using (CompanyContext context = GetDBContext())
                {
                    context.employees.Attach(employee);
                    context.departments.Attach(employee.companyDepartment);
                    context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    context.Entry(employee.companyDepartment).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    result = string.Format("Updated {0} \n", employee.firstName);
                }
            }
            catch (Exception ex)
            {
                result = string.Format("{0} {1}", ex.Message ?? string.Empty, ex.InnerException.Message ?? string.Empty);
            }
            return result;
        }

        public override string Delete(CompanyEmployee employee)
        {
            string result = string.Format("Deleting {0} \n", employee.firstName); ;
            try
            {
                using (CompanyContext context = GetDBContext())
                {
                    context.employees.Attach(employee);
                    context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    result = "Deleted \n";
                }
            }
            catch (Exception ex)
            {
                result = string.Format("{0} {1}", ex.Message ?? string.Empty, ex.InnerException.Message ?? string.Empty);
            }
            return result;
        }
    }
}
