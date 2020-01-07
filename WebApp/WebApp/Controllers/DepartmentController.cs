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
                businessServices.companyDepartmentService.InsertNewDepartment(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Department/Edit/5
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

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Department/Delete/5
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
