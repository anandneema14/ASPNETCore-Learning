using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPNETLearning_EmployeeManagement.Models;
using ASPNETLearning_EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        private readonly IHostingEnvironment HostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            HostingEnvironment = hostingEnvironment;
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
            Employee model = _employeeRepository.GetEmployee(Id ?? 1);
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
        public IActionResult Create(EmployeeCreateViewModel employee)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                #region Uploading Multiple Files
                //if (employee.Photos != null && employee.Photos.Count > 0)
                //{
                //    foreach (IFormFile photo in employee.Photos)
                //    {
                //        string uploadFolder = Path.Combine(HostingEnvironment.WebRootPath, "images");
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName.Split("\\")[3];
                //        string filePath = Path.Combine(uploadFolder, uniqueFileName);
                //        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                //    }
                //}
                #endregion

                if (employee.Photo != null)
                {
                    string uploadFolder = Path.Combine(HostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + employee.Photo.FileName.Split("\\")[3];
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    employee.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Employee emp = new Employee
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.AddEmployee(emp);
                return RedirectToAction("Details", new { Id = emp.Id });
            }

            return View();
        }
    }
}