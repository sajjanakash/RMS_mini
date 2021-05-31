using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS_API.Repository.EmployeeRepository;
using RMS_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeRepo _repo;
        public EmployeeController()
        {
            _repo = new EmployeeRepo();
        }

        [HttpPost]
        public IActionResult AddEmployeeCredentials(EmployeeVM employee)
        {
            _repo.AddEmployeeCredentials(employee);
            return Ok("Data Added Successfully");

        }

       

    }
}
