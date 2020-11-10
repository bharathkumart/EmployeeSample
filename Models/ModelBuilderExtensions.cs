using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSample.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Employee>().HasData(
           new Employee
           {
               Id = 1,
               Name = "Bharath",
               Department = Dept.IT,
               Email = "bharath@gmail.com"
           },
            new Employee
            {
                Id = 2,
                Name = "Rajesh",
                Department = Dept.HR,
                Email = "rajesd@gmail.com"
            }
       );
        }
    }
}
