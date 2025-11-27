using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data
{
    public static class CastMovieSeedData
    {
        public static async Task SeedData(IServiceCollection services)
        {
            var dbContext = services.BuildServiceProvider()
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<MovieContext>();

            if (await dbContext.CastMovies.AnyAsync())
                return;

            var castMovies = new List<CastMovie>
            {
                // Harry Potter 1 (MovieID = 1)
                new CastMovie
                {
                    Id = 1,
                    CastID = 1,           // Daniel Radcliffe
               
                    MovieID = 1,

                    Role = Role.Lead,
                    AmountPaid = 10_000_000
                },
                new CastMovie
                {
                    Id = 2,
                    CastID = 2,           // Emma Watson
                    MovieID = 1,
                    Role = Role.Supporting,
                    AmountPaid = 9_000_000
                },
                new CastMovie
                {
                    Id = 3,
                    CastID = 3,           // Rupert Grint
                    MovieID = 1,
                    Role = Role.Supporting,
                    AmountPaid = 8_500_000
                },

                // The Dark Knight (MovieID = 13)
                new CastMovie
                {
                    Id = 4,
                    CastID = 4,           // Christian Bale
                    MovieID = 12,
                    Role = Role.Lead,
                    AmountPaid = 15_000_000
                },
                new CastMovie
                {
                    Id = 5,
                    CastID = 5,           // Heath Ledger
                    MovieID = 12,
                    Role = Role.Supporting,
                    AmountPaid = 5_000_000
                },
                new CastMovie
                {
                    Id = 6,
                    CastID = 6,           // Gary Oldman
                    MovieID = 12,
                    Role = Role.Extra,
                    AmountPaid = 4_000_000
                }
            };

            await dbContext.CastMovies.AddRangeAsync(castMovies);
            await dbContext.SaveChangesAsync();
        }
    }
}
