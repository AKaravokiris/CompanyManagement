using DomainClasses.Interfaces;
using DomainClasses.CommonClasses;
using Services;
using System;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(InsertCompanyDepartment());
            Console.Read();
        }

        private static string InsertCompanyDepartment()
        {
            ICompanyDepartment department = new CompanyDepartment()
            {                
                Name="HR3",
                maxEmployee=1
            };

            CompanyDepartmentServices service = new CompanyDepartmentServices();
            return service.InsertNewDepartment(department);
        }
    }
}
