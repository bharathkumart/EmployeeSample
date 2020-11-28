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
               Id = Guid.NewGuid(),
               UserName = "Bharath",
               Department = Dept.IT,
               Email = "bharath@gmail.com"
           },
            new Employee
            {
                Id = Guid.NewGuid(),
                UserName = "Rajesh",
                Department = Dept.HR,
                Email = "rajesd@gmail.com"
            }
       );
        }
    }
}
