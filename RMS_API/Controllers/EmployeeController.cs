using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS_API.Model;
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

        [HttpGet("{Id}")]
        public IActionResult GetEmployeeDetailsById(string Id)
        {
            var _employee=_repo.GetEmployeeDetailsById(Id);
            return Ok(_employee);
        }

        [HttpPut("Skills/{EmpId}")]
        public IActionResult UpdateEmployeeSkills(string EmpId, Employee employee)
        {
            var updateEmployee = _repo.UpdateEmployeeSkills(EmpId, employee);
            return Ok(updateEmployee);
        }

        [HttpPut("Experience/{EmpId}")]
        public IActionResult UpdateEmployeeExperience(string EmpId, Employee employee)
        {
            var updateEmployee = _repo.UpdateEmployeeExperience(EmpId, employee);
            return Ok(updateEmployee);
        }



    }
}
