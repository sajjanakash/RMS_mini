using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.ViewModel
{
    public class EmployeeVM
    {
        [Required(ErrorMessage = "Please enter UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Employee Name")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Please enter Employee Id")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Please enter Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Enter Experience")]
        public int Experience { get; set; }

        [Required(ErrorMessage = "Please Enter Designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Please enter Skills")]
        public List<string> Skill { get; set; }
    }
}
