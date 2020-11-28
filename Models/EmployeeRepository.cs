using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSample.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(Guid id)
        {
            Employee employee = _context.Employees.Find(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }
        public IEnumerable<Employee> GetAllManagers()
        {
            return _context.Employees.Where(E => E.IsManager == true).ToList();
        }

        public Employee GetEmployee(Guid id)
        {
           return _context.Employees.Find(id);
        }

        public Employee Update(Employee employee)
        {
            var emp = _context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employee;        
        }
    }
}
