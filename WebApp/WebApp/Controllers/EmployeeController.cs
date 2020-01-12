using DataModels.Context;
using DomainClasses.CommonBussinessServices;
using DomainClasses.CommonClasses;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeServices employeeService;
        private readonly DepartmentServices departmentService;
        public EmployeeController(CompanyContext dbContext)
        {
           employeeService=new EmployeeServices(dbContext as CompanyContext);
           departmentService = new DepartmentServices(dbContext as CompanyContext);
        }

        // GET: Employee
        public ActionResult Index()
        {
            try
            {
            List<CompanyEmployee> employees= employeeService.GetAllEmployeesWithEagerLoad();
            return View(employees );
            }
            catch (Exception ex)
            {

                return ShowExceptionMessage(ex);
            }
        }

        //// GET: Employee/Details/5
        //public ActionResult Details(Guid id)
        //{            
        //    return View(employeeService.GetEmployeeByID(id));
        //}

        // GET: Employee/Create
        public ActionResult Create()
        {
            try
            {
                CreateEmployeModel createEmployeModel = new CreateEmployeModel();
                List<CompanyDepartment> departments = departmentService.GetAllDepartments();
                createEmployeModel.departments = departments;
                return View(createEmployeModel);
            }
            catch (Exception ex)
            {
                return ShowExceptionMessage(ex);
            }
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
                    employeeService.InsertNewEmployee(createEmployeModel.employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    List<CompanyDepartment> departments = departmentService.GetAllDepartments();
                    createEmployeModel.departments = departments;
                    return View(createEmployeModel);
                }
            }
            catch (Exception ex)
            {
                return ShowExceptionMessage(ex);
            }
        }


        // GET: Employee/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                CreateEmployeModel createEmployeModel = new CreateEmployeModel();
                CompanyEmployee employee = employeeService.GetEmployeeByID(id);
                createEmployeModel.employee = employee;
                List<CompanyDepartment> departments = departmentService.GetAllDepartments();
                createEmployeModel.departments = departments;
                createEmployeModel.employee.companyDepartment = departments.Find(x => x.ID == createEmployeModel.employee.CompanyDepartment_ID);
                return View(createEmployeModel);

            }
            catch (Exception ex)
            {
                return ShowExceptionMessage(ex);
            }
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
                    CompanyDepartment department = departmentService.GetDepartmentByID(employeeModel.employee.CompanyDepartment_ID);
                    employeeModel.employee.companyDepartment = department;
                    string result = employeeService.EditExistingEmployee(employeeModel.employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(employeeModel);
                }
            }
            catch (Exception ex)
            {
               return ShowExceptionMessage(ex);
            }
        }


        // GET: Employee/Delete/5
        public ActionResult Delete( Guid id,FormCollection collection)
        {
            try
            {
            return View(employeeService.GetEmployeeByID(id));
            }
            catch (Exception ex)
            {
                return ShowExceptionMessage(ex);
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                employeeService.DeleteEmployeeByID(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return ShowExceptionMessage(ex);
            }
        }

        private ActionResult ShowExceptionMessage(Exception ex)
        {
            ErrorModel errorModel = new ErrorModel();
            errorModel.ErrorMessage = ex.Message;
            return View("Error", errorModel);
        }
    }
}
