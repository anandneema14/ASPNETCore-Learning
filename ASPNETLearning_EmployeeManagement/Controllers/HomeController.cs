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
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
    }
}