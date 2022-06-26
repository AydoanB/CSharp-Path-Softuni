using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Data;

namespace SoftUni
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var connection = new SoftUniContext();
            var employees = GetEmployeesFromResearchAndDevelopment(connection);
            Console.WriteLine(employees);
        }


        //Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
            {
                id=x.EmployeeId,
                x.FirstName,
                x.LastName,
                x.MiddleName,
                x.JobTitle,
                x.Salary
            }).OrderBy(x=>x.id);

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {Math.Round(employee.Salary, 2)}");
            }

            return sb.ToString().TrimEnd();
        }


        //Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
                {
                    x.FirstName,
                    x.Salary
                }).Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName);

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} - {Math.Round(employee.Salary, 2)}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
                {
                    x.FirstName,
                    x.LastName, 
                    DepartmentName=x.Department.Name,
                    x.Salary
                }).Where(x => x.DepartmentName.Equals("Research and Development") )
                .OrderBy(x => x.Salary).ThenByDescending(x=>x.FirstName).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - {Math.Round(employee.Salary, 2)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


