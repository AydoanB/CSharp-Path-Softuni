using System;
using System.Linq;
using Excercises.App.Data.Entities;
using Excercises.Data;

namespace Excercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=Excercises;Integrated Security=true;TrustServerCertificate=true";

            SoftUniDbContext dbContext = new SoftUniDbContext(connectionString);

            dbContext.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = dbContext.Departments.First().Id,
                IsEmployed = true,
            });

            Employee employee = dbContext.Employees.Last();
            employee.FirstName = "Modified";

            dbContext.SaveChanges(); 
        }
    }
}
