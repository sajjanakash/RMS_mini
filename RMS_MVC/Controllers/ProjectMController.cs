using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_MVC.Controllers
{
    public class ProjectMController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProjRequirement()
        {
            return View();
        }
    }
}
