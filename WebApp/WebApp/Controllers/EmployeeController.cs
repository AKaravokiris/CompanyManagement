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
        public ActionResult Details(Guid id)
        {
            
            return View(businessServices.companyEmployeService.GetEmployeeByID(id));
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
                if (createEmployeModel.employee.CompanyDepartment_ID==null)
                {
                    ModelState.AddModelError(nameof(createEmployeModel.employee.CompanyDepartment_ID),"Department can not be empty. Please select one.");
                }
                if (ModelState.IsValid)
                {
                    CompanyEmployee employee = new CompanyEmployee();
                    employee = createEmployeModel.employee;
                    businessServices.companyEmployeService.InsertNewEmployee(employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    List<CompanyDepartment> departments = businessServices.companyDepartmentService.GetAllDepartments();
                    createEmployeModel.departments = departments;
                    return View(createEmployeModel);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        // GET: Employee/Edit/5
        public ActionResult Edit(Guid id)
        {
            CreateEmployeModel createEmployeModel = new CreateEmployeModel();
            CompanyEmployee employee= businessServices.companyEmployeService.GetEmployeeByID(id);
            createEmployeModel.employee = employee;
            List<CompanyDepartment> departments = businessServices.companyDepartmentService.GetAllDepartments();
            createEmployeModel.departments = departments;
            return View(createEmployeModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEmployeModel employeeModel)
        {
            try
            {
                if (employeeModel.employee.CompanyDepartment_ID == null)
                {
                    ModelState.AddModelError(nameof(employeeModel.employee.CompanyDepartment_ID), "Department can not be empty. Please select one.");
                }
                if (ModelState.IsValid)
                {
                    string result = businessServices.companyEmployeService.EditExistingEmployee(employeeModel.employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(employeeModel);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        // GET: Employee/Delete/5
        public ActionResult Delete( Guid id,FormCollection collection)
        {            
            return View(businessServices.companyEmployeService.GetEmployeeByID(id));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                businessServices.companyEmployeService.DeleteEmployeeByID(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
