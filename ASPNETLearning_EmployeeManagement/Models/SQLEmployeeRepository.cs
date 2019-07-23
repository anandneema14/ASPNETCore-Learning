using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETLearning_EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee emp = context.Employees.Find(id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var emp = context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employee;
        }
    }
}
