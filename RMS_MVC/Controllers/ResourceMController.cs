using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_MVC.Controllers
{
    public class ResourceMController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SkillUp()
        {
            return View();
        }
        public IActionResult SkillMap()
        {
            return View();
        }

    }
}
