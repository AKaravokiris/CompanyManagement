using DomainClasses.CommonClasses;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly BusinessServices businessServices;

        public EmployeeController()
        {
            this.businessServices = new BusinessServices();
        }
        public EmployeeController(BusinessServices businessServices)
        {

            this.businessServices = businessServices;
        }



        // GET: Employee
        public ActionResult Index()
        {
            List<CompanyEmployee> employees= businessServices.companyEmployeService.GetAllEmployees();
            return View(employees );
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            CreateEmployeModel createEmployeModel = new CreateEmployeModel();
            List<CompanyDepartment> departments = businessServices.companyDepartmentService.GetAllDepartments();
            createEmployeModel.departments = departments;
            return View(createEmployeModel);
        }


        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(CreateEmployeModel createEmployeModel)
        {
            try
            {
                CompanyEmployee employee = new CompanyEmployee();
                employee = createEmployeModel.employee;
                businessServices.companyEmployeService.InsertNewEmployee(employee);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
