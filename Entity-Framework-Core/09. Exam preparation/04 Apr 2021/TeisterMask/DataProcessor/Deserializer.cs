using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var xmlProjects = XmlConverter.Deserializer<ImportProjectsDto>(xmlString, "Projects");
            foreach (var xmlProject in xmlProjects)
            {
                var isValidFirstDate = DateTime.TryParseExact(xmlProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime firstDate);
                var isValidSecondDate = DateTime.TryParseExact(xmlProject.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime secondDate);

                if (!IsValid(xmlProject) || !isValidFirstDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!isValidSecondDate)
                {
                    secondDate = new DateTime(9999, 12, 31);
                }
                var validTasks = new List<Task>();
                foreach (var xmlProjectTask in xmlProject.Tasks)
                {
                    var isOpenDateValid = DateTime.TryParseExact(xmlProjectTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime taskFirstDate);
                    var isDueDateValid = DateTime.TryParseExact(xmlProjectTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime taskSecondDate);
                    var isValidExecutionType =
                        Enum.TryParse<ExecutionType>(xmlProjectTask.ExecutionType, out ExecutionType executionType);
                    var isValidLabelType =
                        Enum.TryParse<LabelType>(xmlProjectTask.LabelType, out LabelType labelType);

                    if (!IsValid(xmlProjectTask) || !isOpenDateValid || !isDueDateValid ||
                        !isValidExecutionType || !isValidLabelType ||
                        DateTime.Compare(taskFirstDate, firstDate) < 0 || DateTime.Compare(taskSecondDate, secondDate) > 0)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;

                    }
                    Task task = new Task()
                    {
                        Name = xmlProjectTask.Name,
                        OpenDate = taskFirstDate,
                        DueDate = taskSecondDate,
                        ExecutionType = executionType,
                        LabelType = labelType
                    };
                    validTasks.Add(task);
                }

                Project project = new Project()
                {
                    Name = xmlProject.Name,
                    OpenDate = firstDate,
                    DueDate = isValidSecondDate ? (DateTime?)secondDate : null,
                    Tasks = validTasks
                };
                context.Projects.Add(project);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            //var jsonEmployees = JsonConvert.DeserializeObject<List<ImportEmployeesDto>>(jsonString);
            //var sb = new StringBuilder();
            //foreach (var jsonEmp in jsonEmployees)
            //{
            //    if (!IsValid(jsonEmp))
            //    {
            //        sb.AppendLine(ErrorMessage);
            //        continue;
            //    }

            //    Employee employee = new Employee()
            //    {
            //        Username = jsonEmp.Username,
            //        Email = jsonEmp.Email,
            //        Phone = jsonEmp.Phone,
            //    };

            //    foreach (var jsonEmpTask in jsonEmp.Tasks.Distinct())
            //    {
            //        if (context.Tasks.Any(x => x.Id == jsonEmpTask))
            //        {
            //            employee.EmployeesTasks.Add(new EmployeeTask() { TaskId = jsonEmpTask });
            //        }
            //        else
            //        {
            //            sb.Append(ErrorMessage);
            //        }
            //    }
            //    context.Employees.Add(employee);
            //    context.SaveChanges();
            //    sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username,
            //        employee.EmployeesTasks.Count));
            //}

            //return sb.ToString().TrimEnd();

            var jsonImport = JsonConvert.DeserializeObject<List<ImportEmployeesDto>>(jsonString);
            var sb = new StringBuilder();

            foreach (var employeeDto in jsonImport)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var employeeTask in employeeDto.Tasks.Distinct())
                {
                    if (context.Tasks.FirstOrDefault(x => x.Id == employeeTask) != null)
                    {
                        employee.EmployeesTasks.Add(new EmployeeTask()
                        {
                            TaskId = employeeTask
                        });
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                }

                context.Employees.Add(employee);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username,
                    employee.EmployeesTasks.Count));
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}