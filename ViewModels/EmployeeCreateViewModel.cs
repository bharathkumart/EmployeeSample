using EmployeeSample.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSample.ViewModels
{
    public class EmployeeCreateViewModel 
    {
       
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }

        public IFormFile Photo { get; set; }
        public bool IsManager { get; set; } = false;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string City { get; set; }
        public Guid ParentId { get; set; } = new Guid();
    }
}
