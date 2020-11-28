using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSample.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
        {
            new Employee() { Id = Guid.NewGuid(), UserName = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
            new Employee() { Id = Guid.NewGuid(), UserName = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
            new Employee() { Id = Guid.NewGuid(), UserName = "Sam", Department = Dept.Finance, Email = "sam@pragimtech.com" },
        };
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(Guid id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public IEnumerable<Employee> GetAllManagers()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(Guid Id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee GetEmployee(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employee)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.Id == employee.Id);
            if (employee != null)
            {
                employee.UserName = employee.UserName;
                employee.Email = employee.Email;
                employee.Department = employee.Department;
            }
            return employee;
        }
    }
}
