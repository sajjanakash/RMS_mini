using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.Model
{
    public class Employee
    {
        [Required(ErrorMessage = "Please enter UserName")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmpName { get; set; }
        [Key]
        public string EmpId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
        public string Designation { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsAssigned { get; set; }
        public string ProjectCode { get; set; }
        public bool? Status { get; set; }

        //Navigation Property

        public List<EmployeeSkill> EmployeeSkill { get; set; }

    }
}
