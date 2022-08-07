using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Footballers.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var data = context.Coaches
                .Where(x => x.Footballers.Count > 0)
                .ToArray()
                .Select(c => new ExportCoachesDto()
                {
                    FootballersCount = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers.Select(f => new ExportFootballersDto()
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    })
                        .OrderBy(f => f.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.Footballers.Length).ThenBy(c => c.CoachName)
                .ToList();

            var xmlData = XmlConverter.Serialize(data, "Coaches");

            return xmlData;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
          

            var data = context.Teams
                .ToList()
                .Where(t => t.TeamsFootballers.Any(f => DateTime.Compare(f.Footballer.ContractStartDate, date) >= 0))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(f => DateTime.Compare(f.Footballer.ContractStartDate, date) >= 0)
                        .OrderByDescending(f => f.Footballer.ContractEndDate).ThenBy(f => f.Footballer.Name)
                        .Select(f => new
                        {
                            FootballerName = f.Footballer.Name,
                            ContractStartDate =
                                f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = f.Footballer.BestSkillType.ToString(),
                            PositionType = f.Footballer.PositionType.ToString(),
                        })
                        .ToList()
                })
                .OrderByDescending(t => t.Footballers.Count()).ThenBy(t => t.Name)
                .Take(5)
                .ToList();

            var JsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

            return JsonData;
        }
    }
}
