using DataModels.Context;
using DomainClasses.CommonClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataModels.DomainModels
{
   
    public class CompanyDepartmentRepo : CompanyDepartment
    {
        private readonly CompanyContext _context;

        public CompanyDepartmentRepo()
        {
            _context = GetDBContext();
        }
       

        private CompanyContext GetDBContext()
        {
            return new CompanyContext();
        }


        public override string Create(CompanyDepartment department)
        {
            string result = "Created";
            CompanyDepartment compDepartment = (department as CompanyDepartment);
            try
            {
                compDepartment.ID = Guid.NewGuid();
                _context.departments.Add(compDepartment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result =  string.Format("{0} {1}",ex.Message ?? string.Empty , ex.InnerException.Message ?? string.Empty);
            }
            return result;
        }

        public override List<CompanyDepartment> Read()
        {
            try
            {
              
              return _context.departments.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override string Update (CompanyDepartment department)
        {
            string result = "Updated";
            try
            {
                _context.departments.Attach(department);
                _context.Entry(department).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result = string.Format("{0} {1}", ex.Message ?? string.Empty, ex.InnerException.Message ?? string.Empty);
            }
            return result;
        }

        public override string Delete(CompanyDepartment department)
        {
            string result = "Deleted";
            try
            {
                ///this way i can delete without having to fetch the department first                
                _context.Entry(department).State = System.Data.Entity.EntityState.Deleted;
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