using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSample.Models;
using EmployeeSample.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSample.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepo;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository _employee, IHostingEnvironment _hostingEnvironment)
        {
            employeeRepo = _employee;
            hostingEnvironment = _hostingEnvironment;


        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = employeeRepo.GetAllEmployees();
            // Pass the list of employees to the view
            return View(model);
        }
        [AllowAnonymous]
        public ViewResult Details(int id)
        {
            Employee employee = employeeRepo.GetEmployee(id);
            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                employee = employee
            };
            //Employee employee = employeeRepo.GetEmployee(1);
            return View(model );
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = employeeRepo.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id=employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department =employee.Department,
                ExistingPhotoPath = employee.Photopath
            };
            return View(employeeEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = employeeRepo.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                if(model.Photo != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.Photopath = ProcessUploadedFile(model);
                }
                employeeRepo.Update(employee);
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filepath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }                   
            }

            return uniqueFileName;
        }
        public IActionResult Delete(int id)
        {
            Employee employee = employeeRepo.Delete(id);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

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
