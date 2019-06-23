using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETLearning_EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETLearning_EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(2);
            ViewData["PageTitle"] = "Employee Details";
            return View(model);
        }
    }
}