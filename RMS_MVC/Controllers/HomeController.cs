using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RMS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RMS_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> LoginUser(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44308/api/Token", content))
                    {
                        string token = await response.Content.ReadAsStringAsync();
                        var op = token.Split(",")[1].Split(":")[1].Split('"')[1];

                       /* if (token == "Invalid Credentials")
                        {
                            return Redirect("~/Home/Login");
                        }*/
                        if (op == "Admin")
                        {
                            return Redirect("~/Admin/Index");
                        }
                        else if (op == "Resource Manager")
                        {
                            HttpContext.Session.SetString("JWToken", token);
                            return Redirect("~/ResourceM/Index");
                        }
                        else if (op == "Project Manager")
                        {
                            HttpContext.Session.SetString("JWToken", token);
                            return Redirect("~/ProjectM/Index");
                        }
                        else if (op == "Employee")
                        {
                            HttpContext.Session.SetString("JWToken", token);
                            return Redirect("~/Employee/Index");
                        }
                        else
                        {
                            return Redirect("~/Home/Login");
                        }
                    }

                }
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }   

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
