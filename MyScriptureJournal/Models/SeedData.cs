using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Context>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Date = DateTime.Parse("2016-2-24"),
                        Book = "Alma",
                        Chapter = 37,
                        Verse = 37
                    },
                    new Scripture
                    {
                        Date = DateTime.Parse("2016-5-13"),
                        Book = "1 Nephi",
                        Chapter = 1,
                        Verse = 5
                    },
                    new Scripture
                    {
                        Date = DateTime.Parse("2016-9-05"),
                        Book = "Moroni",
                        Chapter = 7,
                        Verse = 34
                    },
                    new Scripture
                    {
                        Date = DateTime.Parse("2016-12-04"),
                        Book = "2 Nephi",
                        Chapter = 2,
                        Verse = 22
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
