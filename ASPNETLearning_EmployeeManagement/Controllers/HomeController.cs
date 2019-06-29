using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETLearning_EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETLearning_EmployeeManagement.Controllers
{
    //[Route("Home")]

    //In below approach of Attribute Routing, 
    //Token inside Route parameter ([controller]) will take the value of the controller,
    //and we no need to worry if we change the Controller name in future. 
    //Same applies for Action methods also.
    [Route("[controller]")]     
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("")]
        [Route("~/")] //This is to handle for navigatng through root URL.
        public ViewResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        [Route("[action]/{id?}")]
        public ViewResult Details(int? Id)
        {
            //Parameter in GetEmployee method is called as Colesace operator, 
            //and it tells that if Id is null it will take 1 as default value.
            Employee model = _employeeRepository.GetEmployee(Id??1);    
            ViewData["PageTitle"] = "Employee Details";
            return View(model);
        }

        [Route("[action]")]
        public ViewResult Create()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = _employeeRepository.AddEmployee(employee);
                return RedirectToAction("Details", new { Id = emp.Id });
            }

            return View();
        }
    }
}