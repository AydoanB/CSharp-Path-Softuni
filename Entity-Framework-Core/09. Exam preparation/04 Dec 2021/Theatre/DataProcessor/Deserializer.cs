using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Theatre.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var xmlPlays = Xml.Deserializer<ImportPlaysDto>(xmlString, "Plays");

            foreach (var xmlPlay in xmlPlays)
            {
                bool genreString = Enum.TryParse<Genre>(xmlPlay.Genre, out Genre genre);
                TimeSpan parsedTime =
                    TimeSpan.ParseExact(xmlPlay.Duration, "hh\\:ss\\:mm", CultureInfo.InvariantCulture);
                if (!IsValid(xmlPlay) || parsedTime.Hours < 1 || !genreString)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play()
                {
                    Title = xmlPlay.Title,
                    Duration = parsedTime,
                    Rating = xmlPlay.Rating,
                    Genre = genre,
                    Description = xmlPlay.Description,
                    Screenwriter = xmlPlay.Screenwriter
                };
                context.Plays.Add(play);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }
            return sb.ToString().TrimEnd();

        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            string pattern = @"([+44])+(-\d{2})(-\d{3})(-\d{4})";
            var sb = new StringBuilder();
            var xmlCasts = Xml.Deserializer<ImportCastsDto>(xmlString, "Casts");

            foreach (var xmlCast in xmlCasts)
            {
                if (!IsValid(xmlCast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = xmlCast.FullName,
                    IsMainCharacter = xmlCast.IsMainCharacter,
                    PhoneNumber = xmlCast.PhoneNumber,
                    PlayId = xmlCast.PlayId
                };
                context.Casts.Add(cast);
                context.SaveChanges();

                var typeOfCasting = cast.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine($"Successfully imported actor {cast.FullName} as a {typeOfCasting} character!");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonTheatres = JsonConvert.DeserializeObject<List<ImportTheatersAndTicketsDto>>(jsonString);

            foreach (var jsonTheatre in jsonTheatres)
            {
                if (!IsValid(jsonTheatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validTickets = new List<ImportTicketsDto>();
                foreach (var jsonTicket in jsonTheatre.Tickets)
                {
                    if (!IsValid(jsonTicket))
                    {
                        sb.AppendLine(ErrorMessage);

                    }
                    else
                    {
                        validTickets.Add(jsonTicket);
                    }
                }

                var theatre = new Data.Models.Theatre()
                {
                    Name = jsonTheatre.Name,
                    NumberOfHalls = jsonTheatre.NumberOfHalls,
                    Director = jsonTheatre.Director,
                    Tickets = validTickets.Select(t => new Ticket()
                    {
                        PlayId = t.PlayId,
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    }).ToList()
                };
                context.Theatres.Add(theatre);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }
            return sb.ToString().Trim();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
