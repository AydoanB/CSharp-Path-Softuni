using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Export;
using XmlFacade;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var data = context.Genres
                .ToList()
                .Where(x => genreNames.Contains(x.Name))
                .Select(genre => new
                {
                    Id = genre.Id,
                    Genre = genre.Name,
                    Games = genre.Games.Where(x => x.Purchases.Any())
                        .Select(game => new
                        {
                            Id = game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = string.Join(", ", game.GameTags.Select(x => x.Tag.Name)),
                            Players = game.Purchases.Count
                        }).OrderByDescending(g => g.Players).ThenBy(g => g.Id),
                    TotalPlayers = genre.Games.Sum(x => x.Purchases.Count)
                }).OrderByDescending(x => x.TotalPlayers).ThenBy(x => x.Id)
                .ToList();

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {

            var users = context.Users
                .ToList()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(x => new ExportUserAndPurchasesDto()
                {
                    Username = x.Username,
                    TotalSpent = x.Cards
                        .Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType)
                            .Sum(p => p.Game.Price)),
                    Purchases = x.Cards.SelectMany(c => c.Purchases)
                        .Where(p => p.Type.ToString() == storeType)
                        .Select(p => new ExportPurchasesForUserDto()
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGamesInPurchasesDto()
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(p => p.Date)
                        .ToArray()
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserAndPurchasesDto[]), new XmlRootAttribute("Users"));

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
           

            var sw = new StringWriter();
            xmlSerializer.Serialize(sw, users, ns);

            return sw.ToString().TrimEnd();
        }
    }
}