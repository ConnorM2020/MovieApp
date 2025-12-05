using MovieApp.Data;
public static class CastMovieSeedData
{
    // Assign actors to specific movies
    public static async Task SeedData(IServiceCollection services)
    {
        var dbContext = services.BuildServiceProvider()
                                .CreateScope()
                                .ServiceProvider
                                .GetService<MovieContext>();

        var castMovies = new List<CastMovie>();

        // ============================
        // HARRY POTTER (Movies 1–8)
        // IDs from CastSeedData:
        // 1 Daniel, 2 Emma, 3 Rupert, 4 Alan, 5 Tom Felton,
        // 6 Gary Oldman, 7 Evanna, 8 Ralph Fiennes,
        // 19 Maggie Smith, 20 Matthew Lewis
        // ============================
        // 1: Sorcerer's Stone
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 1, CastID = 1 },  // Daniel
            new CastMovie { MovieID = 1, CastID = 2 },  // Emma
            new CastMovie { MovieID = 1, CastID = 3 },  // Rupert
            new CastMovie { MovieID = 1, CastID = 4 },  // Alan
            new CastMovie { MovieID = 1, CastID = 19 }, // Maggie
        });

        // 2: Chamber of Secrets
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 2, CastID = 1 },
            new CastMovie { MovieID = 2, CastID = 2 },
            new CastMovie { MovieID = 2, CastID = 3 },
            new CastMovie { MovieID = 2, CastID = 4 },
            new CastMovie { MovieID = 2, CastID = 5 },  // Tom Felton
            new CastMovie { MovieID = 2, CastID = 19 },
            new CastMovie { MovieID = 2, CastID = 20 }, // Matthew Lewis
        });

        // 3: Prisoner of Azkaban
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 3, CastID = 1 },
            new CastMovie { MovieID = 3, CastID = 2 },
            new CastMovie { MovieID = 3, CastID = 3 },
            new CastMovie { MovieID = 3, CastID = 6 },  // Gary Oldman
            new CastMovie { MovieID = 3, CastID = 19 },
        });

        // 4: Goblet of Fire
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 4, CastID = 1 },
            new CastMovie { MovieID = 4, CastID = 2 },
            new CastMovie { MovieID = 4, CastID = 3 },
            new CastMovie { MovieID = 4, CastID = 4 },
            new CastMovie { MovieID = 4, CastID = 5 },
            new CastMovie { MovieID = 4, CastID = 8 },  // Ralph Fiennes
        });

        // 5: Order of the Phoenix
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 5, CastID = 1 },
            new CastMovie { MovieID = 5, CastID = 2 },
            new CastMovie { MovieID = 5, CastID = 3 },
            new CastMovie { MovieID = 5, CastID = 7 },  // Evanna
            new CastMovie { MovieID = 5, CastID = 8 },
            new CastMovie { MovieID = 5, CastID = 19 },
            new CastMovie { MovieID = 5, CastID = 20 },
        });

        // 6: Half-Blood Prince
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 6, CastID = 1 },
            new CastMovie { MovieID = 6, CastID = 2 },
            new CastMovie { MovieID = 6, CastID = 3 },
            new CastMovie { MovieID = 6, CastID = 4 },
            new CastMovie { MovieID = 6, CastID = 6 },
            new CastMovie { MovieID = 6, CastID = 8 },
        });

        // 7: Deathly Hallows – Part 1
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 7, CastID = 1 },
            new CastMovie { MovieID = 7, CastID = 2 },
            new CastMovie { MovieID = 7, CastID = 3 },
            new CastMovie { MovieID = 7, CastID = 7 },
            new CastMovie { MovieID = 7, CastID = 8 },
            new CastMovie { MovieID = 7, CastID = 20 },
        });

        // 8: Deathly Hallows – Part 2
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 8, CastID = 1 },
            new CastMovie { MovieID = 8, CastID = 2 },
            new CastMovie { MovieID = 8, CastID = 3 },
            new CastMovie { MovieID = 8, CastID = 7 },
            new CastMovie { MovieID = 8, CastID = 8 },
            new CastMovie { MovieID = 8, CastID = 19 },
            new CastMovie { MovieID = 8, CastID = 20 },
        });

        // ============================
        // LORD OF THE RINGS (Movies 9–11)
        // IDs:
        // 9 Elijah, 10 Ian, 11 Viggo, 12 Sean, 13 Andy,
        // 21 Orlando, 22 Cate
        // ============================

        // 9: Fellowship of the Ring
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 9, CastID = 9 },   // Elijah
            new CastMovie { MovieID = 9, CastID = 10 },  // Ian
            new CastMovie { MovieID = 9, CastID = 11 },  // Viggo
            new CastMovie { MovieID = 9, CastID = 12 },  // Sean
            new CastMovie { MovieID = 9, CastID = 21 },  // Orlando
            new CastMovie { MovieID = 9, CastID = 22 },  // Cate
        });

        // 10: The Two Towers
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 10, CastID = 9 },
            new CastMovie { MovieID = 10, CastID = 10 },
            new CastMovie { MovieID = 10, CastID = 11 },
            new CastMovie { MovieID = 10, CastID = 12 },
            new CastMovie { MovieID = 10, CastID = 13 }, // Andy (Gollum)
            new CastMovie { MovieID = 10, CastID = 21 },
        });

        // 11: The Return of the King
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 11, CastID = 9 },
            new CastMovie { MovieID = 11, CastID = 10 },
            new CastMovie { MovieID = 11, CastID = 11 },
            new CastMovie { MovieID = 11, CastID = 12 },
            new CastMovie { MovieID = 11, CastID = 13 },
            new CastMovie { MovieID = 11, CastID = 22 },
        });

        // ============================
        // BATMAN TRILOGY (Movies 12–14)
        // IDs:
        // 14 Christian, 15 Liam, 16 Michael,
        // 17 Heath, 18 Tom Hardy, 23 Morgan, 24 Anne
        // ============================

        // 12: Batman Begins
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 12, CastID = 14 }, // Christian Bale
            new CastMovie { MovieID = 12, CastID = 15 }, // Liam Neeson (Begins only)
            new CastMovie { MovieID = 12, CastID = 16 }, // Michael Caine
            new CastMovie { MovieID = 12, CastID = 23 }, // Morgan Freeman
        });

        // 13: The Dark Knight
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 13, CastID = 14 }, // Bale
            new CastMovie { MovieID = 13, CastID = 16 }, // Caine
            new CastMovie { MovieID = 13, CastID = 17 }, // Heath Ledger (only here)
            new CastMovie { MovieID = 13, CastID = 23 }, // Freeman
        });

        // 14: The Dark Knight Rises
        castMovies.AddRange(new[]
        {
            new CastMovie { MovieID = 14, CastID = 14 }, // Bale
            new CastMovie { MovieID = 14, CastID = 16 }, // Caine
            new CastMovie { MovieID = 14, CastID = 18 }, // Tom Hardy (only here)
            new CastMovie { MovieID = 14, CastID = 24 }, // Anne Hathaway
        });

        await dbContext.CastMovies.AddRangeAsync(castMovies);
        await dbContext.SaveChangesAsync();
    }
}
