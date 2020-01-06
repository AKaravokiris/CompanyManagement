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
            TestingCompanyEmployeeServices();
            Console.Read();
        }

        private static void TestingCompanyEmployeeServices()
        {
            CompanyEmployeeServices service = new CompanyEmployeeServices();
            Console.WriteLine(InsertCompanyEmployee(service));
            List<CompanyEmployee> Employees = GetAllEmployees(service);
            Console.WriteLine(updateFirstEmployee(service, Employees));
            Console.WriteLine(DeleteLastEmployee(service, Employees));
            Employees = GetAllEmployees(service);
        }

        private static string DeleteLastEmployee(CompanyEmployeeServices service, List<CompanyEmployee> employees)
        {
            CompanyEmployee employee = employees.LastOrDefault();
            return service.DeleteEmployee(employee);
        }

        private static string updateFirstEmployee(CompanyEmployeeServices service, List<CompanyEmployee> employees)
        {
            CompanyDepartmentServices departmentService = new CompanyDepartmentServices();
            List<CompanyDepartment> departments = departmentService.GetAllDepartments();
            CompanyDepartment department = departments.Find(x => x.Name == "Logistics");
            CompanyEmployee employee = employees.Find(x => x.firstName == "John");
            if (employee != null)
            {
                employee.firstName = "Jonathan";
                employee.CompanyDepartment_ID = department.ID;
                employee.companyDepartment= department;
            }
            return service.EditExistingEmployee(employee);
        }

        private static List<CompanyEmployee> GetAllEmployees(CompanyEmployeeServices service)
        {
            List<CompanyEmployee> employees = service.GetAllEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine(string.Format("{0} : {1}", employee.firstName, employee.companyDepartment.Name));
            }

            return employees;
        }

        private static string InsertCompanyEmployee(CompanyEmployeeServices service)
        {
            CompanyDepartmentServices departmentService = new CompanyDepartmentServices();
            List<CompanyDepartment> departments = departmentService.GetAllDepartments();
            CompanyDepartment department = departments.Find(x => x.maxEmployees == 1);
            CompanyEmployee employee = new CompanyEmployee()
            {
                firstName="John",
                lastName="Black",
                birthDate=DateTime.Now,
                emailAddress="test1@gmail.com",
                CompanyDepartment_ID= department.ID,
                companyDepartment = department
            };
            string result=    service.InsertNewEmployee(employee);
            CompanyEmployee employee2 = new CompanyEmployee()
            {
                firstName = "George",
                lastName = "Blue",
                birthDate = DateTime.Now,
                emailAddress = "test1@gmail.com",
                CompanyDepartment_ID = departments.Find(x => x.CurrentEmployees < x.maxEmployees).ID,
                companyDepartment = departments.Find(x => x.CurrentEmployees < x.maxEmployees)
            };
            result = result +" "+service.InsertNewEmployee(employee2);
            return result;
        }

        private static CompanyDepartment GetCompanyDepartment()
        {
            CompanyDepartmentServices service = new CompanyDepartmentServices();
            List<CompanyDepartment> departments = service.GetAllDepartments();
            return departments.Find(x => x.maxEmployees == 1);
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
                department.maxEmployees = 3;
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
