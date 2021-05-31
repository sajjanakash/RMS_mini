using RMS_API.Data;
using RMS_API.Model;
using RMS_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.Repository.EmployeeRepository
{
    public class EmployeeRepo:IEmployee
    {
        private DatabaseContext _context;
        public EmployeeRepo()
        {
            _context = new DatabaseContext();
        }

        public void AddEmployeeCredentials(EmployeeVM employee)
        {
            
            var data = new Employee()
            {

                EmpId = employee.EmpId,
                Password =employee.Password,
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

        /*public Employee SkillsUpdation(EmployeeVM employee)
        {
            
            return employee;
        }*/
    }
}
