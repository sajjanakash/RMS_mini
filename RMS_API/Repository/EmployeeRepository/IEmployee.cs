using RMS_API.Model;
using RMS_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.Repository.EmployeeRepository
{
    interface IEmployee
    {
        public void AddEmployeeCredentials(EmployeeVM employee);
        public Employee UpdateEmployeeSkills(string EmpId, Employee employee);
        public Employee UpdateEmployeeExperience(string EmpId, Employee employee);

        public Employee GetEmployeeDetailsById(string empId);
    }
}
