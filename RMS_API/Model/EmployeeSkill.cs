using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.Model
{
    public class EmployeeSkill
    {
        [Key]
        public long TempId { get; set; }
        public string SkillSet { get; set; }
        public Skill Skill { get; set; }
        public string EmpId { get; set; }
        public Employee Employee { get; set; }
    }
}
