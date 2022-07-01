using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var connection = new SoftUniContext();
            GetEmployeesFullInformation(connection);

        }



        //Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
            {
                id = x.EmployeeId,
                x.FirstName,
                x.LastName,
                x.MiddleName,
                x.JobTitle,
                x.Salary
            }).OrderBy(x => x.id).ToList();

            //foreach (var employee in employees)
            //{
            //    sb.AppendLine(
            //        $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {Math.Round(employee.Salary, 2)}");
            //}
            employees.ForEach(employee => sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {Math.Round(employee.Salary, 2)}"));
            return sb.ToString().Trim();
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

        //Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                DepartmentName = x.Department.Name,
                x.Salary
            }).Where(x => x.DepartmentName.Equals("Research and Development"))
                .OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - {Math.Round(employee.Salary, 2)}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employeeNakov = context
                .Employees.First(e => e.LastName == "Nakov");

            employeeNakov.Address = newAddress;
            context.SaveChanges();


            List<string> addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(x => x.Address.AddressText).ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine(address);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 7 
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var sb = new StringBuilder();
            var employeesProjects = context.Employees.Where(e => e.EmployeesProjects
                    .Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                .Take(10).Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Manager = x.Manager.FirstName + " " + x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(ep => new
                    {
                        ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                    }).ToList()
                }).ToList();



            foreach (var employee in employeesProjects)
            {
                sb.AppendLine($"{employee.FullName} - {employee.Manager}");

                foreach (var ep in employee.Projects)
                {
                    sb.AppendLine($"-- {ep.Name} - {ep.StartDate} - {ep.EndDate}");
                }

            }

            return sb.ToString().Trim();
        }
        //Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var result = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10).ToList();

            foreach (var address in result)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().Trim();

        }

        //Problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var result = context.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .OrderBy(ep => ep.Project.Name)
                        .Select(ep => ep.Project.Name)
                }).Where(e => e.Id == 147)
                .ToList();

            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName}");
                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"{project}");
                }
            }

            return sb.ToString().Trim();

        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var result = context.Departments
                .Select(d => new
                {
                    d.Name,
                    Manager = d.Manager.FirstName + " " + d.Manager.LastName,
                    EmployeesCount = d.Employees.Count,
                    Employees = d.Employees
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName)
                            .Select(e => new
                            {
                                EmployeeName = e.FirstName + " " + e.LastName,
                                e.JobTitle
                            })

                }).OrderBy(d => d.EmployeesCount)
                .ThenBy(d => d.Name)
                .Where(d => d.EmployeesCount >= 5)
                .ToList();

            foreach (var department in result)
            {
                sb.AppendLine($"{department.Name} - {department.Manager}");
                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().Trim();

        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var result = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                }
                )
                .OrderBy(p => p.Name)
                .ToList();



            foreach (var projects in result)
            {
                sb.AppendLine($"{projects.Name}\n" +
                              $"{projects.Description}\n" +
                              $"{projects.StartDate}");

            }

            return sb.ToString().Trim();

        }
        // Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            List<string> departmentNames = new List<string>()
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            IQueryable<Employee> employeesToIncrease = context.Employees
                .Where(e => departmentNames.Contains(e.Department.Name));

            foreach (Employee employee in employeesToIncrease)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employees = employeesToIncrease
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Project project = context.Projects
                .Where(p => p.ProjectId == 2)
                .Single();

            context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList()
                .ForEach(p => context.EmployeesProjects.Remove(p));

            context.Projects.Remove(project);

            context.SaveChanges();


            context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList()
                .ForEach(p => sb.AppendLine(p));

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        //public static string RemoveTown(SoftUniContext context)
        //{
        //Town townToDelete = context.Towns
        //.First(t => t.Name == "Seattle");


        //IQueryable<Address> addressesToDelete = context.Addresses
        //.Where(a => a.TownId == townToDelete.TownId);

        //int addressesCount = addressesToDelete.Count();

        //IQueryable<Employee> employeesOnDeletedAddress = context.Employees
        //.Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

        //foreach (Employee e in employeesOnDeletedAddress)
        //{
        //e.AddressId = null;
        //}

        //foreach (var a in addressesToDelete)
        //{
        //context.Addresses.Remove(a);
        //}

        //context.Towns.Remove(townToDelete);

        //context.SaveChanges();

        //return $"{addressesCount} addresses in {townToDelete.Name} were deleted";
        //}
    }
}


