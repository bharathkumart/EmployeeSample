using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSample.Models;
using EmployeeSample.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepo;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository _employee, IHostingEnvironment _hostingEnvironment)
        {
            employeeRepo = _employee;
            hostingEnvironment = _hostingEnvironment;


        }

        public IActionResult Index()
        {
            var model = employeeRepo.GetAllEmployees();
            // Pass the list of employees to the view
            return View(model);
        }
       
        public ViewResult Details(int id)
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                employee = employeeRepo.GetEmployee(id)
            };
            //Employee employee = employeeRepo.GetEmployee(1);
            return View(model );
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                   string uploadsFolder =  Path.Combine(hostingEnvironment.WebRootPath,"images");
                   uniqueFileName=Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                   string filepath =Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
                }

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Department = model.Department,
                    Email = model.Email,
                    Photopath = uniqueFileName
                };
                employeeRepo.AddEmployee(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
