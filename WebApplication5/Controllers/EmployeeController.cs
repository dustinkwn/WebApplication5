using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.DataAccess;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            EmployeeDataAccess data = new EmployeeDataAccess();
            bool success = data.CreateEmployee(employee);

            if (success)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }

            ViewBag.Error = "Could not create employee.";
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    }
}