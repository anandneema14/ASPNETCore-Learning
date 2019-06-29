﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETLearning_EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _empList;

        public MockEmployeeRepository()
        {
            _empList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Anand", Department = Dept.IT, Email = "anand.neema14@gmail.com" },
                new Employee() { Id = 2, Name = "Vidhi", Department = Dept.HR, Email = "vidhianandneema@gmail.com" },
                new Employee() { Id = 3, Name = "Aarav", Department = Dept.None, Email = "anand.neema14@gmail.com" },
            };
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _empList.Max(e => e.Id) + 1;
            _empList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _empList;
        }

        public Employee GetEmployee(int id)
        {
            return _empList.FirstOrDefault(e => e.Id == id);
        }
    }
}
