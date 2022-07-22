using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;


    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var importedGames = JsonConvert.DeserializeObject<List<ImportGamesDto>>(jsonString);

            foreach (var importedGame in importedGames)
            {
                var IsValidDate = DateTime.TryParseExact(importedGame.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);


                if (!IsValid(importedGame) || importedGame.Tags.Count <= 0 || !IsValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Developer dev = context.Developers.FirstOrDefault(x => x.Name == importedGame.Developer);
                if (dev == null)
                {
                    dev = new Developer()
                    {
                        Name = importedGame.Developer
                    };
                    context.Developers.Add(dev);
                    context.SaveChanges();
                }


                Genre genre = context.Genres.FirstOrDefault(x => x.Name == importedGame.Genre);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = importedGame.Genre
                    };
                    context.Genres.Add(genre);
                    context.SaveChanges();
                }
                


                var gameTags = new List<Tag>();
                foreach (var tag in importedGame.Tags)
                {
                    Tag tagToCreate = context.Tags.FirstOrDefault(x => x.Name == tag);
                    if (tagToCreate == null)
                    {
                        tagToCreate = new Tag()
                        {
                            Name = tag

                        };
                        context.Tags.Add(tagToCreate);
                        context.SaveChanges();
                        gameTags.Add(tagToCreate);
                    }
                    else
                    {
                        gameTags.Add(tagToCreate);
                    }
                }

                Game game = new Game()
                {
                    Name = importedGame.Name,
                    Price = importedGame.Price,
                    ReleaseDate = releaseDate,
                    Developer = dev,
                    Genre = genre,
                    GameTags = gameTags.Select(x => new GameTag()
                    {
                        TagId = x.Id
                    }).ToList()
                };
                context.Games.Add(game);
                context.SaveChanges();
                sb.AppendLine($"Added {game.Name} ({genre.Name}) with {game.GameTags.Count} tags");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}