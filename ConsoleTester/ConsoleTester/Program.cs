using DomainClasses.CommonClasses;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            TestingCompanyDepartmentServices();
            //TestingCompanyEmployeeServices();
            Console.Read();
        }

        private static void TestingCompanyEmployeeServices()
        {
            throw new NotImplementedException();
        }

        private static void TestingCompanyDepartmentServices()
        {
            CompanyDepartmentServices service = new CompanyDepartmentServices();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(InsertCompanyDepartment(service));

            }
            List<CompanyDepartment> departments = GetAllDepartments(service);
            Console.WriteLine(updateFirstDepartment(service, departments));
            Console.WriteLine(DeleteLastDepartment(service, departments));
            departments = GetAllDepartments(service);
        }

        private static string DeleteLastDepartment(CompanyDepartmentServices service, List<CompanyDepartment> departments)
        {
            CompanyDepartment department = departments.LastOrDefault();
            return service.DeleteDepartment(department);
        }

        private static string updateFirstDepartment(CompanyDepartmentServices service,List<CompanyDepartment> departments)
        {

            CompanyDepartment department = departments.FirstOrDefault();
            if (department!=null)
            {
                department.Name = "Logistics";
                department.maxEmployees = 7;
            }
            return service.EditExistingDepartment(department);
        }

        private static List<CompanyDepartment> GetAllDepartments(CompanyDepartmentServices service)
        {
            List<CompanyDepartment> departments = service.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine(string.Format("{0} : {1}", department.Name,department.maxEmployees));
            }
            
            return departments;
        }

        private static string InsertCompanyDepartment(CompanyDepartmentServices service)
        {
            CompanyDepartment department = new CompanyDepartment()
            {                
                Name="HR",
                maxEmployees=1                              
            };            
            return service.InsertNewDepartment(department);
        }
    }
}
