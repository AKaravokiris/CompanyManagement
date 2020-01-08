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
        public CompanyDepartmentRepo()
        {
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
                using (CompanyContext context = GetDBContext())
                {
                    context.departments.Add(compDepartment);
                    context.SaveChanges();
                }
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
                using (CompanyContext context = GetDBContext())
                {
                    return context.departments.ToList();
                }               
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override CompanyDepartment ReadByID(Guid departmentID)
        {
            try
            {
                using (CompanyContext context = GetDBContext())
                {
                    return context.departments.FirstOrDefault(x => x.ID == departmentID);
                }
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
                using (CompanyContext context = GetDBContext())
                {
                    context.departments.Attach(department);
                    context.Entry(department).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
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
                using (CompanyContext context = GetDBContext())
                {
                    ///this way i can delete without having to fetch the department first                
                    context.Entry(department).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
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