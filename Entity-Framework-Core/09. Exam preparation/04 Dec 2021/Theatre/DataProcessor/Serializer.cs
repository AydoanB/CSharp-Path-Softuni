using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;

namespace Theatre.DataProcessor
{
    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {

            var data = context.Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = t.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Select(t => new
                        {
                            Price = t.Price,
                            RowNumber = t.RowNumber
                        }).OrderByDescending(ticket => ticket.Price)
                }).OrderByDescending(theater => theater.Halls).ThenBy(theater => theater.Name)
                .ToList();

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var data = context.Plays
                .ToList()
                .Where(p => p.Rating <= rating)
                .Select(p => new XmlExportPlaysDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = $"{(p.Rating == 0 ? "Premier" : p.Rating.ToString())}",
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Where(a => a.IsMainCharacter == true).Select(a => new ExportActorsDto()
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{a.Play.Title}'."

                    }).OrderByDescending(a => a.FullName)
                        .ToArray()
                }).OrderBy(p => p.Title).ThenByDescending(p => p.Genre)
                .ToList();

            return Xml.Serialize(data, "Plays");
        }
    }
}
