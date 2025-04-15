using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.DataAccess;

namespace WebApplication5.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Dashboard()
        {
            EmployeeDataAccess data = new EmployeeDataAccess();
            List<Models.Employee> employeelist = data.GetEmployeeList();

            return View(employeelist);
        }
    }
}