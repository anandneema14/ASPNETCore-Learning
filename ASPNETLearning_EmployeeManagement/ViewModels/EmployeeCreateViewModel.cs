using ASPNETLearning_EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETLearning_EmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        public Dept Department { get; set; }

        [Required]
        public string Email { get; set; }

        //
        //
        /// <summary>
        ///File uploaded to the server can be accessed through ModelBinding using IFormFile Interface
        ///File Upload control on UI is also because of IFormFiel Interface
        /// </summary>
        public List<IFormFile> Photos { get; set; }
    }
}
