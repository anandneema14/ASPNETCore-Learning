using System;
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
                new Employee() { Id = 1, Name = "Anand", Department = "IT", Email = "anand.neema14@gmail.com" },
                new Employee() { Id = 2, Name = "Vidhi", Department = "Home", Email = "vidhianandneema@gmail.com" },
                new Employee() { Id = 3, Name = "Aarav", Department = "School", Email = "anand.neema14@gmail.com" },
            };
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
