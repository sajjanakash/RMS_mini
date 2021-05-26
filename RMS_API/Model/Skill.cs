using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.Model
{
    public class Skill
    {
        [Key]
        public string SkillSet { get; set; }

        //Navigation Property
        public List<EmployeeSkill> EmployeeSkill { get; set; }
    }
}
