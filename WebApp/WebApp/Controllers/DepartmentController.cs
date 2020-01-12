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
    public class DepartmentController : Controller
    {
        private readonly EmployeeServices employeeService;
        private readonly DepartmentServices departmentService;
        public DepartmentController(CompanyContext dbContext)
        {
            employeeService = new EmployeeServices(dbContext as CompanyContext);
            departmentService = new DepartmentServices(dbContext as CompanyContext);
        }

        // GET: Department
        public ActionResult Index()
        {
            List<CompanyDepartment> departments = departmentService.GetAllDepartments();
            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            try
            {
            CompanyDepartment department = new CompanyDepartment();
            return View(department);
            }
            catch (Exception ex)
            {
                return ShowExceptionMessage(ex);
            }
        }

        [HttpPost]
        // POST: Department/Create
        public ActionResult Create(CompanyDepartment department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    departmentService.InsertNewDepartment(department);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return ShowExceptionMessage(ex);
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(departmentService.GetDepartmentByID(id));
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(CompanyDepartment department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string result = departmentService.EditExistingDepartment(department);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(department);
                }
            }
            catch (Exception ex)
            {
                return ShowExceptionMessage(ex);
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
            return View(departmentService.GetDepartmentByID(id));   
            }
            catch (Exception ex)
            {
                return ShowExceptionMessage(ex);
            }
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                string result= departmentService.DeleteDepartmentByID(id);
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

        public JsonResult CreateDepartment(CompanyDepartment department) {
            try
            {
                return Json(departmentService.InsertNewDepartment(department));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult EditDepartment(CompanyDepartment department)
        {
            try
            {
                return Json(departmentService.EditExistingDepartment(department));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
