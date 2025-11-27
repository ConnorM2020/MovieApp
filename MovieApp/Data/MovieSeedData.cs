
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data
{
    public static class MovieSeedData
    {
        public static async Task SeedData(IServiceCollection services)
        {
            var dbContext = services.BuildServiceProvider().CreateScope().ServiceProvider.GetService<MovieContext>();

           

            var movies = new List<Movie>
            {
                new Movie
                {
                    ID = 1,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Description = "Harry discovers he is a wizard and begins his first year at Hogwarts.",
                    Rating = 8,
                  //  Budget = 125_000_000m,
                    NumberOfCast = 25,
                //    genre = MovieGenre.Fantasy  // definition from Movie.cs declarition 

                },
                new Movie
                {
                    ID = 2,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Description = "Harry returns for his second year as a dark force terrorizes Hogwarts.",
                    Rating = 8,
                 //   Budget = 100_000_000m,
                    NumberOfCast = 27,
                //    genre = MovieGenre.Fantasy
                },
                new Movie
                {
                    ID = 3,
                    Title = "Harry Potter and the Prisoner of Azkaban",
                    Description = "Sirius Black escapes from Azkaban and Harry uncovers hidden truths.",
                    Rating = 9,
                //    Budget = 130_000_000m,
                    NumberOfCast = 28,
                //    genre = MovieGenre.Fantasy
                },
                new Movie
                {
                    ID = 4,
                    Title = "Harry Potter and the Goblet of Fire",
                    Description = "Harry is unexpectedly entered into the dangerous Triwizard Tournament.",
                    Rating = 8,
                //    Budget = 150_000_000m,
                    NumberOfCast = 30,
                //    genre = MovieGenre.Fantasy
                },
                new Movie
                {
                    ID = 5,
                    Title = "Harry Potter and the Order of the Phoenix",
                    Description = "Harry faces the Ministry’s denial of Voldemort’s return and forms Dumbledore’s Army.",
                    Rating = 8,
                 //   Budget = 150_000_000m,
                    NumberOfCast = 32,
                 //   genre = MovieGenre.Fantasy
                },
                new Movie
                {
                    ID = 6,
                    Title = "Harry Potter and the Half-Blood Prince",
                    Description = "Harry uncovers Voldemort’s past while Draco receives a dark mission.",
                    Rating = 8,
                 //   Budget = 250_000_000m,
                    NumberOfCast = 31,
                 //   genre = MovieGenre.Fantasy
                },
                new Movie
                {
                    ID = 7,
                    Title = "Harry Potter and the Deathly Hallows – Part 1",
                    Description = "Harry, Ron, and Hermione search for Horcruxes as Voldemort’s power grows.",
                    Rating = 8,
                //    Budget = 250_000_000m,
                    NumberOfCast = 33,
                //    genre = MovieGenre.Fantasy
                },
                new Movie
                {
                    ID = 8,
                    Title = "Harry Potter and the Deathly Hallows – Part 2",
                    Description = "The final battle for Hogwarts erupts as Harry faces Voldemort.",
                    Rating = 9,
                //    Budget = 250_000_000m,
                    NumberOfCast = 34,
                 //   genre = MovieGenre.Fantasy
                },
                new Movie
                {
                    ID = 9,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Description = "A hobbit begins a perilous quest to destroy the One Ring.",
                    Rating = 9,
                 //   Budget = 93_000_000m,
                    NumberOfCast = 30,
                //    genre = MovieGenre.SciFi
                },
                new Movie
                {
                    ID = 10,
                    Title = "The Lord of the Rings: The Two Towers",
                    Description = "The Fellowship is broken but continues the quest against Sauron.",
                    Rating = 9,
                 //   Budget = 94_000_000m,
                    NumberOfCast = 32,
                 //   genre = MovieGenre.SciFi
                },
                new Movie
                {
                    ID = 11,
                    Title = "The Lord of the Rings: The Return of the King",
                    Description = "The final battle for Middle-earth begins as Frodo nears Mount Doom.",
                    Rating = 10,
                 //   Budget = 94_000_000m,
                    NumberOfCast = 35,
                 //    genre = MovieGenre.SciFi
                },
                new Movie
                {
                    ID = 12,
                    Title = "Batman Begins",
                    Description = "Bruce Wayne becomes Batman and faces the League of Shadows.",
                    Rating = 8,
                 //   Budget = 150_000_000m,
                    NumberOfCast = 20,
                 //   genre = MovieGenre.Action
                },
                new Movie
                {
                    ID = 13,
                    Title = "The Dark Knight",
                    Description = "Batman faces the Joker in a battle for Gotham’s soul.",
                    Rating = 10,
               //     Budget = 185_000_000m,
                    NumberOfCast = 22,
                //    genre = MovieGenre.Action
                },
                new Movie
                {
                    ID = 14,
                    Title = "The Dark Knight Rises",
                    Description = "Batman returns from exile to confront Bane and save Gotham.",
                    Rating = 9,
                 //   Budget = 230_000_000m,
                    NumberOfCast = 24,
                 //   genre = MovieGenre.Action
                }
            };


            await dbContext.AddRangeAsync(movies);
            await dbContext.SaveChangesAsync();
        }
    }
}
