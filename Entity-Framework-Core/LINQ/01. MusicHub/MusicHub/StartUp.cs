using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));


        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();
            var albums = context.Albums
                .ToList()
                .Where(producer => producer.ProducerId==(producerId))
                .OrderByDescending(a=>a.Price)
                .Select(album => new
                {
                    album.Name,
                    ReleaseDate = album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = album.Producer.Name,
                    Songs = album.Songs
                        .ToArray()
                        .Select(song => new
                    {
                        song.Name,
                        song.Price,
                        SongWriterName = song.Writer.Name
                    })
                        .OrderByDescending(x=>x.Name)
                        .ThenBy(x=>x.SongWriterName),
                    albumPrice = album.Songs.Sum(x => x.Price).ToString("f2"),
                })
                .ToArray();


            foreach (var album in albums)
            {

                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");

                int counter = 1;
                sb.AppendLine($"-Songs:");
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.SongWriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.albumPrice:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songs = context.Songs
                .ToList()
                .Where(song => song.Duration.Seconds > duration)
                .Select(song => new
                {
                    song.Name,
                    writerName = song.Writer.Name,
                    performerName = song.SongPerformers
                        .ToList()
                        .Select(performer => $"{performer.Performer.FirstName} {performer.Performer.LastName}")
                        .FirstOrDefault(),
                    albumProducerName = song.Album.Producer.Name,
                    songDuration = song.Duration.ToString("c")
                })
                .OrderBy(x => x.Name).ThenBy(x => x.writerName).ThenBy(x => x.performerName)
                .ToList();

            int count = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{count++}");

                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.writerName}");
                sb.AppendLine($"---AlbumProducer: {song.albumProducerName}");

                sb.AppendLine($"Duration: {song.songDuration}");
            }
            return sb.ToString().Trim();
        }
    }
}
