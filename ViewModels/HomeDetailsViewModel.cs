using EmployeeSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSample.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee employee { get; set; }
        public String PageTitle { get; set; }

        public string ManagerName { get; set; }
       
    }
}
