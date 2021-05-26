using RMS_API.Data;
using RMS_API.Model;
using RMS_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.Repository.EmployeeRepository
{
    public class EmployeeRepo
    {
        private DatabaseContext _context;
        public EmployeeRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void AddEmployeeCredentials(EmployeeVM employee)
        {
            
            var data = new Employee()
            {
                UserName=employee.UserName,
                Password=employee.Password,
                EmpId = employee.EmpId,
                EmpName = employee.EmpName,
                DateOfBirth =employee.DateOfBirth,
                Designation=employee.Designation,
                Experience=employee.Experience
            };
            _context.Employees.Add(data);
            _context.SaveChanges();

            foreach (var skill in employee.Skill)
            {
                var _data = new EmployeeSkill()
                {
                    EmpId = data.EmpId,
                    SkillSet = skill
                };
                _context.EmployeeSkill.Add(_data);
                _context.SaveChanges();
            }
        }
    }
}
