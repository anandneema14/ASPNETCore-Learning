using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETLearning_EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Dept Department { get; set; }

        [Required]
        public string Email { get; set; }   
    }
}
