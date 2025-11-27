using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data
{
    public static class CastSeedData
    {
        public static async Task SeedData(IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MovieContext>();

            // optional: apply migrations
            // await dbContext.Database.MigrateAsync();

            // avoid reseeding if data exists
            if (await dbContext.Movies.AnyAsync() ||
                await dbContext.Casts.AnyAsync() ||
                await dbContext.CastMovies.AnyAsync())
            {
                return;
            }

            // 1) Movies
            var movies = new List<Movie>
            {
                new Movie
                {
                    ID = 1,
                    Title = "Harry Potter and the Philosopher's Stone",
                    Description = "First Harry Potter movie",
                    Rating = 9,
                    Budget = 125_000_000
                },
                new Movie
                {
                    ID = 13,
                    Title = "The Dark Knight",
                    Description = "Batman faces the Joker",
                    Rating = 10,
                    Budget = 185_000_000
                }
            };

            await dbContext.Movies.AddRangeAsync(movies);

            // 2) Cast (people only, no MovieID / Role / AmountPaid here)
            var castMembers = new List<Cast>
            {
                new Cast
                {
                    ID = 1,
                    FirstName = "Daniel",
                    LastName = "Radcliffe",
                    Age = 33
                },
                new Cast
                {
                    ID = 2,
                    FirstName = "Emma",
                    LastName = "Watson",
                    Age = 32
                },
                new Cast
                {
                    ID = 3,
                    FirstName = "Rupert",
                    LastName = "Grint",
                    Age = 34
                },
                new Cast
                {
                    ID = 4,
                    FirstName = "Christian",
                    LastName = "Bale",
                    Age = 49
                },
                new Cast
                {
                    ID = 5,
                    FirstName = "Heath",
                    LastName = "Ledger",
                    Age = 28
                },
                new Cast
                {
                    ID = 6,
                    FirstName = "Gary",
                    LastName = "Oldman",
                    Age = 65
                }
            };

            await dbContext.Casts.AddRangeAsync(castMembers);

            // 3) CastMovie (link table: who is in which movie, with role + pay)
            var castMovies = new List<CastMovie>
            {
                // Harry Potter 1 (MovieID = 1)
                new CastMovie
                {
                    Id = 1,
                    CastID = 1,   // Daniel Radcliffe
                    MovieID = 1,
                    Role = Role.Lead,
                    AmountPaid = 10_000_000
                },
                new CastMovie
                {
                    Id = 2,
                    CastID = 2,   // Emma Watson
                    MovieID = 1,
                    Role = Role.Supporting,
                    AmountPaid = 9_000_000
                },
                new CastMovie
                {
                    Id = 3,
                    CastID = 3,   // Rupert Grint
                    MovieID = 1,
                    Role = Role.Supporting,
                    AmountPaid = 8_500_000
                },

                // The Dark Knight (MovieID = 13)
                new CastMovie
                {
                    Id = 4,
                    CastID = 4,   // Christian Bale
                    MovieID = 12,
                    Role = Role.Lead,
                    AmountPaid = 15_000_000
                },
                new CastMovie
                {
                    Id = 5,
                    CastID = 5,   // Heath Ledger
                    MovieID = 12,
                    Role = Role.Supporting,
                    AmountPaid = 5_000_000
                },
                new CastMovie
                {
                    Id = 6,
                    CastID = 6,   // Gary Oldman
                    MovieID = 12,
                    Role = Role.Extra,
                    AmountPaid = 4_000_000
                },
                new CastMovie
                {
                    Id = 4,
                    CastID = 1,   // Daniel Radcliffe
                    MovieID = 2,
                    Role = Role.Lead,
                    AmountPaid = 11_000_000
                },
                new CastMovie
                {
                    Id = 5,
                    CastID = 2,   // Emma Watson
                    MovieID = 2,
                    Role = Role.Supporting,
                    AmountPaid = 9_500_000
                },
                new CastMovie
                {
                    Id = 6,
                    CastID = 3,   // Rupert Grint
                    MovieID = 2,
                    Role = Role.Supporting,
                    AmountPaid = 9_000_000
                },

                // --------------------------
                // Harry Potter 3 (MovieID = 3)
                // --------------------------
                new CastMovie
                {
                    Id = 7,
                    CastID = 1,   // Daniel Radcliffe
                    MovieID = 3,
                    Role = Role.Lead,
                    AmountPaid = 12_000_000
                },
                new CastMovie
                {
                    Id = 8,
                    CastID = 2,   // Emma Watson
                    MovieID = 3,
                    Role = Role.Supporting,
                    AmountPaid = 10_000_000
                },
                new CastMovie
                {
                    Id = 9,
                    CastID = 3,   // Rupert Grint
                    MovieID = 3,
                    Role = Role.Supporting,
                    AmountPaid = 9_250_000
                },
                new CastMovie
                {
                    Id = 10,
                    CastID = 4,   // Christian Bale
                    MovieID = 13,
                    Role = Role.Lead,
                    AmountPaid = 15_000_000
                },
                new CastMovie
                {
                    Id = 11,
                    CastID = 5,   // Heath Ledger
                    MovieID = 13,
                    Role = Role.Supporting,
                    AmountPaid = 5_000_000
                },
                new CastMovie
                {
                    Id = 12,
                    CastID = 6,   // Gary Oldman
                    MovieID = 13,
                    Role = Role.Extra,
                    AmountPaid = 4_000_000
                }





            };

            await dbContext.CastMovies.AddRangeAsync(castMovies);

            await dbContext.SaveChangesAsync();
        }
    }
}