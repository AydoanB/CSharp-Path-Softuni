using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var data = context.Projects
                .ToList()
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectsDto()
                {
                    TasksCount = p.Tasks.Count,
                    Name = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new ExportTasksDto()
                    {
                        Name = t.Name,
                        LabelType = t.LabelType.ToString()
                    }).OrderBy(t => t.Name)
                        .ToArray()
                }).OrderByDescending(p => p.TasksCount).ThenBy(p => p.Name)
                .ToList();

            return XmlConverter.Serialize(data, "Projects");
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var data = context.Employees
                .ToList()
                .Where(e => e.EmployeesTasks.Any(t => DateTime.Compare(t.Task.OpenDate, date) >= 0))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et => DateTime.Compare(et.Task.OpenDate, date) >= 0)
                        .OrderByDescending(t => t.Task.DueDate).ThenBy(t => t.Task.Name)
                        .Select(et => new
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                })
                .OrderByDescending(e => e.Tasks.Count()).ThenBy(e => e.Username)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
}
}