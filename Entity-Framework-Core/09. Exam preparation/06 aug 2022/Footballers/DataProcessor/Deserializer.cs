using System.Globalization;
using System.Linq;
using System.Text;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var ImportedCoachesXml = XmlConverter.Deserializer<ImportCoachesDto>(xmlString, "Coaches");

            foreach (var importCoach in ImportedCoachesXml)
            {
                if (!IsValid(importCoach) || string.IsNullOrEmpty(importCoach.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validFootballers = new List<Footballer>();

                foreach (var importedFootballer in importCoach.Footballers)
                {
                    var IsValidStartDate = DateTime.TryParseExact(importedFootballer.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractStartDate);

                    var IsValidEndDate = DateTime.TryParseExact(importedFootballer.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractEndDate);

                    var IsValidSkillType = Enum.TryParse(importedFootballer.BestSkillType, out BestSkillType SkillType);

                    var IsValidPositionType = Enum.TryParse(importedFootballer.PositionType, out PositionType PositionType);

                    var IsStarDateAfterEndDate = DateTime.Compare(contractStartDate, contractEndDate) > 0;
                    
                    if (!IsValid(importedFootballer) || !IsValidStartDate 
                                                     || !IsValidEndDate || IsStarDateAfterEndDate
                                                     || !IsValidSkillType || !IsValidPositionType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer Footballer = new Footballer()
                    {
                        Name = importedFootballer.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        BestSkillType = SkillType,
                        PositionType = PositionType
                    };

                    validFootballers.Add(Footballer);
                }

                Coach coach = new Coach()
                {
                    Name = importCoach.Name,
                    Nationality = importCoach.Nationality,
                    Footballers = validFootballers
                };

                context.Coaches.Add(coach);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, validFootballers.Count));
            }

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var ImportedTeams = JsonConvert.DeserializeObject<List<ImportTeamsDto>>(jsonString);

            foreach (var importedTeam in ImportedTeams)
            {
                if (!IsValid(importedTeam) || importedTeam.Trophies < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var existingFootballers = new List<TeamFootballer>();

                foreach (var footballerId in importedTeam.Footballers.Distinct())
                {
                    var footballer = context.Footballers.FirstOrDefault(x => x.Id == footballerId);

                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    existingFootballers.Add(new TeamFootballer()
                    {
                        FootballerId = footballer.Id
                    });
                }

                Team team = new Team()
                {
                    Name = importedTeam.Name,
                    Nationality = importedTeam.Nationality,
                    Trophies = importedTeam.Trophies,
                    TeamsFootballers = existingFootballers.ToList()
                };

                context.Teams.Add(team);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            return  sb.ToString().TrimEnd(); //$"{context.Teams.Count()} {context.TeamsFootballers.Count()}"; 
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
