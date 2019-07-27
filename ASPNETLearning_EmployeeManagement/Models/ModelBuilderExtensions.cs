using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETLearning_EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Anand",
                    Email = "anand.neema14@gmail.com",
                    Department = Dept.IT
                },
                new Employee
                {
                    Id = 2,
                    Name = "Vidhi",
                    Email = "vidhianandneema@gmail.com",
                    Department = Dept.HR
                },
                new Employee
                {
                    Id = 3,
                    Name = "Aarav",
                    Email = "anand.neema14@gmail.com",
                    Department = Dept.MD
                });
        }
    }
}
