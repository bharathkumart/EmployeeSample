using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSample.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(Guid Id);
        IEnumerable<Employee> GetAllEmployees();
        Employee AddEmployee(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(Guid id);
        IEnumerable<Employee> GetAllManagers();
    }
}
