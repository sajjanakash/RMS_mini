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
                EmailId=employee.EmailId,
                DateOfBirth =employee.DateOfBirth,
                Skills=employee.Skills,
                Designation=employee.Designation,
                Experience=employee.Experience
            };
            _context.Employees.Add(data);
            _context.SaveChanges();

       
        }

        public Employee UpdateEmployeeSkills(string EmpId,Employee employee)
        {
            var _data = _context.Employees.Where(n => n.EmpId == EmpId).FirstOrDefault();
            if(_data!=null)
            {
                _data.Skills = employee.Skills;
                _context.SaveChanges();
            }
            return _data;
        }

        public Employee UpdateEmployeeExperience(string EmpId, Employee employee)
        {
            var _data = _context.Employees.Where(n => n.EmpId == EmpId).FirstOrDefault();
            if (_data != null)
            {
                _data.Experience = employee.Experience;
                _context.SaveChanges();
            }
            return _data;
        }

        public Employee GetEmployeeDetailsById(string empId)
        {
            var _employee = _context.Employees.Where(n => n.EmpId == empId).FirstOrDefault();
            return _employee;
        }
    }
}
