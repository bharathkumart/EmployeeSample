using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSample.Models;
using EmployeeSample.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepo;
        public HomeController(IEmployeeRepository _employee)
        {
            employeeRepo = _employee;
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
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = employeeRepo.AddEmployee(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
