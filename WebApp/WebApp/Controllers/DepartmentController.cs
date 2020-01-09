using DomainClasses.CommonClasses;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly BusinessServices businessServices;

        public DepartmentController()
        {
            this.businessServices = new BusinessServices();
        }
        public DepartmentController(BusinessServices businessServices)
        {

            this.businessServices = businessServices;
        }
        // GET: Department
        public ActionResult Index()
        {
            List<CompanyDepartment> departments = businessServices.companyDepartmentService.GetAllDepartments();
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
            CompanyDepartment department = new CompanyDepartment();
            return View(department);
        }

        [HttpPost]
        // POST: Department/Create
        public ActionResult Create(CompanyDepartment department)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    businessServices.companyDepartmentService.InsertNewDepartment(department);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(businessServices.companyDepartmentService.GetDepartmentByID(id));
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(CompanyDepartment department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string result = businessServices.companyDepartmentService.EditExistingDepartment(department);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(department);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            return View(businessServices.companyDepartmentService.GetDepartmentByID(id));
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                string result=businessServices.companyDepartmentService.DeleteDepartmentByID(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public JsonResult CreateDepartment(CompanyDepartment department) {
            try
            {
                return Json(businessServices.companyDepartmentService.InsertNewDepartment(department));
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
                return Json(businessServices.companyDepartmentService.EditExistingDepartment(department));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
