using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSample.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
        public Dept? Department { get; set; }
        public string Photopath { get; set; }
        public bool IsManager { get; set; } = false;
        public  Guid ParentId { get; set; }
    }

}

