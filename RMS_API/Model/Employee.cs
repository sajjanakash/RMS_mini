using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.Model
{
    public class Employee
    {
       
        [Key]
        public string EmpId { get; set; }
        public string Password { get; set; }
        public string EmpName { get; set; }
        public string EmailId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
        public string Skills { get; set; }
        public string Designation { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsAssigned { get; set; }
        public string ProjectCode { get; set; }
        public bool? Status { get; set; }

        

    }
}
