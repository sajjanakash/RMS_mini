using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult AddEmployee()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateEmployee()
        {
            return View();
        }
    }
}
